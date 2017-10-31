// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmTicketManager.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.CrmCampaignIntegration.Core
{
  using System;
  using System.Globalization;
  using System.Text.RegularExpressions;
  using Sitecore.CrmCampaignIntegration.Discovery;
  using Sitecore.Diagnostics;
  using Sitecore.Form.Core.Utility;
  using Sitecore.Forms.Core.Crm;
  using Sitecore.StringExtensions;

  [Obsolete]
  public class CrmTicketManager : CrmCampaignIntegrations.Core.ITicketProvider
  {
    #region Fields

    /// <summary>
    /// Active <see cref="ITicketProvider"/> instance
    /// </summary>
    private static CrmCampaignIntegrations.Core.ITicketProvider ticketProvider = new CrmTicketManager();

    #endregion

    /// <summary>
    /// Prevents a default instance of the <see cref="CrmTicketManager"/> class from being created. 
    /// Initializes a new instance of the <see cref="CrmTicketManager"/> class.
    /// </summary>
    private CrmTicketManager()
    {
    }

    /// <summary>
    /// Gets the provider.
    /// </summary>
    /// <value>The provider.</value>
    public static CrmCampaignIntegrations.Core.ITicketProvider Provider
    {
      get
      {
        return ticketProvider;
      }
    }

    /// <summary>
    /// Sets the active ticket provider.
    /// </summary>
    /// <param name="provider">The provider.</param>
    public static void SetTicketProvider(CrmCampaignIntegrations.Core.ITicketProvider provider)
    {
      Assert.ArgumentNotNull(provider, "provider");
      ticketProvider = provider;
    }


    /// <summary>
    /// Gets the ticket.
    /// </summary>
    /// <param name="url">
    /// The URL.
    /// </param>
    /// <param name="login">
    /// The login.
    /// </param>
    /// <param name="password">
    /// The password.
    /// </param>
    /// <param name="organizationName">
    /// Name of the organization.
    /// </param>
    /// <param name="partner">
    /// The partner.
    /// </param>
    /// <param name="environment">
    /// The environment.
    /// </param>
    /// <param name="authType">
    /// The auth Type.
    /// </param>
    /// <returns>
    /// returns Ticket
    /// </returns>
    public CrmCampaignIntegrations.Core.Ticket GetTicket(string url, string login, string password, string organizationName, string partner, string environment, int authType)
    {
      var disco = new CrmDiscoveryService();

      if (authType != 1)
      {
        var discoPath = @"{0}/CrmDiscoveryService.asmx".FormatWith(((AuthenticationType)authType).ToString());
        url = url.ToLower().Replace("crmservice.asmx", discoPath).Replace("metadataservice.asmx", discoPath);
        disco.Url = url;

        disco.Credentials = SecurityUtil.CreateNetworkCredential(login, password);

        var ticketRequest = new RetrieveCrmTicketRequest
        {
          OrganizationName = organizationName,
          UserId = login,
          Password = password
        };

        var ticketResponse = (RetrieveCrmTicketResponse)disco.Execute(ticketRequest);

        return new CrmCampaignIntegrations.Core.Ticket(ticketResponse.CrmTicket, organizationName, (AuthenticationType)authType, DateTime.Parse(ticketResponse.ExpirationDate));
      }
      if (string.IsNullOrEmpty(partner))
      {
        var r = new Regex(@"http[s]?://.*?\.(crm[45]?.dynamics.com){1}");
        var match = r.Match(url);
        if (match.Success)
        {
          partner = match.Groups[1].Value;
        }
      }
      return this.GetPassportTiket(login, password, organizationName, partner, environment);
    }

    /// <summary>
    /// Get Passport Tiket
    /// </summary>
    /// <param name="login">
    /// The login.
    /// </param>
    /// <param name="password">
    /// The password.
    /// </param>
    /// <param name="organizationName">
    /// The organization name.
    /// </param>
    /// <param name="partner">
    /// The partner.
    /// </param>
    /// <param name="environment">
    /// The environment.
    /// </param>
    /// <returns>
    /// Passport Tiket
    /// </returns>
    private CrmCampaignIntegrations.Core.Ticket GetPassportTiket(string login, string password, string organizationName, string partner, string environment)
    {
      var disco = new CrmDiscoveryService
      {
        Url = String.Format("https://dev.{0}/MSCRMServices/2007/{1}/CrmDiscoveryService.asmx", string.IsNullOrEmpty(partner) ? "crm.dynamics.com" : partner, "Passport")
      };

      var retrievePolicyResponse = (RetrievePolicyResponse)disco.Execute(new RetrievePolicyRequest());

      var passportTicket = LiveIdTicketManager.RetrieveTicket(Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"), partner, login, password, retrievePolicyResponse.Policy, LiveIdTicketManager.LiveIdEnvironment.PROD);

      var retrieveOrganizationsRequest = new RetrieveOrganizationsRequest
      {
        PassportTicket = passportTicket
      };

      var retrieveOrganizationsResponse = (RetrieveOrganizationsResponse)disco.Execute(retrieveOrganizationsRequest);
      string onlineOrganizationName = string.Empty;
      foreach (OrganizationDetail organizationDetail in retrieveOrganizationsResponse.OrganizationDetails)
      {
        if (!organizationDetail.FriendlyName.Equals(organizationName))
        {
          continue;
        }

        var detail = organizationDetail;
        onlineOrganizationName = detail.OrganizationName;
      }

      var retrieveCrmTicketRequest = new RetrieveCrmTicketRequest();
      retrieveCrmTicketRequest.OrganizationName = onlineOrganizationName;
      retrieveCrmTicketRequest.PassportTicket = passportTicket;

      var retrieveCrmTicketResponse = (RetrieveCrmTicketResponse)disco.Execute(retrieveCrmTicketRequest);
      return new CrmCampaignIntegrations.Core.Ticket(retrieveCrmTicketResponse.CrmTicket, retrieveCrmTicketResponse.OrganizationDetail.OrganizationName, (AuthenticationType)1, DateTime.Parse(retrieveCrmTicketResponse.ExpirationDate, null, DateTimeStyles.AdjustToUniversal));
    }
  }
}