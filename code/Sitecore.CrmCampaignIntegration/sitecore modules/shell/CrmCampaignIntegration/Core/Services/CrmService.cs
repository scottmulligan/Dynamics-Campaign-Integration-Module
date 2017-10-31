#region

using System;
using System.Collections.Specialized;

using Sitecore.Form.Core.Utility;


#endregion

namespace Sitecore.CrmCampaignIntegration.Services
{
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.Form.Core.Configuration;


  [Obsolete]
  public partial class CrmService
   {
      #region Field

      private readonly DateTime expirationDate = DateTime.MaxValue;

      #endregion

      /// <summary>
      /// Initializes a new instance of the <see cref="CrmService"/> class.
      /// </summary>
      /// <param name="connecitonString">The conneciton string.</param>
      public CrmService(string connecitonString)
      {
         NameValueCollection parameters = CrmRemoteSettings.GetServiceParameters(connecitonString);

         if (parameters != null && parameters.Count > 0)
         {
           if (!string.IsNullOrEmpty(parameters[CrmRemoteSettings.CrmUrlKey]))
            {
              Url = parameters[CrmRemoteSettings.CrmUrlKey].ToLower().Replace(@"/2006/", @"/2007/");
            }

            if (!string.IsNullOrEmpty(parameters[RemoteSettings.UserId]))
            {
               var serviceCredentials = SecurityUtil.CreateNetworkCredential(parameters[RemoteSettings.UserId],
                                                                             parameters[RemoteSettings.PasswordKey]);
               Credentials = serviceCredentials;
               ConnectionGroupName = SecurityUtil.CreateSecureGroupName(serviceCredentials);
               CrmAuthenticationTokenValue = new CrmAuthenticationToken
                                                {
                                                   AuthenticationType =
                                                      SecurityUtil.GetAuthenticationType(
                                                      parameters[RemoteSettings.AuthenticationType]),
                                                   OrganizationName = parameters[RemoteSettings.OrganizationName]
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