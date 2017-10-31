using System;
using System.Collections.Specialized;

using Sitecore.Form.Core.Utility;

namespace Sitecore.CrmCampaignIntegration.Metadata
{
  using Form.Core.Configuration;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;

  [Obsolete]
  /// <summary>
  /// Crm metadata service
  /// </summary>
  public partial class MetadataService
  {
    #region Field

    private DateTime expirationDate = DateTime.MaxValue;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataService"/> class.
    /// </summary>
    /// <param name="connecitonName">Name of the conneciton.</param>
    public MetadataService(string connecitonName)
    {
      NameValueCollection parameters = CrmRemoteSettings.GetServiceParameters(connecitonName);
      if (parameters != null && parameters.Count > 0)
      {
        if (!string.IsNullOrEmpty(parameters[CrmRemoteSettings.CrmUrlKey]))
        {
          Url = parameters[CrmRemoteSettings.CrmUrlKey].ToLower().Replace("crmservice.asmx", "metadataservice.asmx").Replace(@"/2006/", @"/2007/"); ;
        }

        if (!string.IsNullOrEmpty(parameters[RemoteSettings.UserId]))
        {
          var serviceCredentials = SecurityUtil.CreateNetworkCredential(parameters[RemoteSettings.UserId],
                                                                        parameters[RemoteSettings.PasswordKey]);
          Credentials = serviceCredentials;
          ConnectionGroupName = SecurityUtil.CreateSecureGroupName(serviceCredentials);

          CrmAuthenticationTokenValue = new CrmAuthenticationToken
                                           {
                                             OrganizationName = parameters[RemoteSettings.OrganizationName],
                                             AuthenticationType = SecurityUtil.GetAuthenticationType(parameters[RemoteSettings.AuthenticationType])
                                           };

          if (MainUtil.GetBool(parameters[RemoteSettings.UseTicket], false))
          {
            var ticket = CrmTicketManager.Provider.GetTicket(Url,
                                                             parameters[RemoteSettings.UserId],
                                                             parameters[RemoteSettings.PasswordKey],
                                                             parameters[RemoteSettings.OrganizationName],
                                                             parameters[RemoteSettings.PartnerName],
                                                             parameters[RemoteSettings.EnvironmentName],
                                                             CrmAuthenticationTokenValue.AuthenticationType);
            if (ticket != null)
            {
              CrmAuthenticationTokenValue.CrmTicket = ticket.Value;
              CrmAuthenticationTokenValue.OrganizationName = ticket.OrganizationName;
              expirationDate = ticket.ExpirationDate;
            }
          }
        }
      }
      else
      {
        expirationDate = DateTime.MinValue;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is expired.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is expired; otherwise, <c>false</c>.
    /// </value>
    public bool IsExpired
    {
      get
      {
        return DateTime.UtcNow >= expirationDate;
      }
    }
  }
}
