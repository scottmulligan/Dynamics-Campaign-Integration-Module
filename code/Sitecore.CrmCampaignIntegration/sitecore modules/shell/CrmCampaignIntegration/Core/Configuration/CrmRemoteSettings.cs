

namespace Sitecore.CrmCampaignIntegration.Core.Configuration
{
  using System.Collections.Specialized;
  using System.Configuration;
  using Sitecore.CrmCampaignIntegration.Metadata;
  using Sitecore.CrmCampaignIntegration.Services;


  public class CrmRemoteSettings
  {
    #region Constants and Fields

    /// <summary>
    /// The Web Service url key
    /// </summary>
    public static readonly string CrmUrlKey = "crm:url";


    /// <summary>
    /// The crm metadata service
    /// </summary>
    private static MetadataService crmMetadataService;

    /// <summary>
    /// The crm service
    /// </summary>
    private static CrmService crmService;


    /// <summary>
    /// Gets the CRM metadata service.
    /// </summary>
    public static MetadataService CrmMetadataService
    {
      get
      {
        if (crmMetadataService == null || crmMetadataService.IsExpired)
        {
          crmMetadataService = new MetadataService(CrmCampaignIntegration.Configuration.Settings.CrmConnectionName);
        }

        return crmMetadataService;
      }
    }

    /// <summary>
    /// Gets the CRM service.
    /// </summary>
    public static CrmService CrmService
    {
      get
      {
        if (crmService == null || crmService.IsExpired)
        {
          crmService = new CrmService(CrmCampaignIntegration.Configuration.Settings.CrmConnectionName);
        }

        return crmService;
      }
    }

    /// <summary>
    /// Gets the connection string of the web service.
    /// </summary>
    /// <param name="connectionName">Name of the connection.</param>
    /// <returns>
    /// The service parameters.
    /// </returns>
    internal static NameValueCollection GetServiceParameters(string connectionName)
    {
      if (!string.IsNullOrEmpty(connectionName))
      {
        ConnectionStringSettings connectionStringSettings = GetConnectionString(connectionName);
        if (connectionStringSettings != null)
        {
          string connection = connectionStringSettings.ConnectionString;
          NameValueCollection collection = StringUtil.GetNameValues(connection, '=', ';');
          foreach (string key in collection.AllKeys)
          {
            string value = collection[key];
            collection.Remove(key);
            collection.Add(key.ToLower(), value);
          }

          return collection;
        }
      }

      return null;
    }

    public static ConnectionStringSettings GetConnectionString(string connectionString)
    {
      return !string.IsNullOrEmpty(connectionString) ? ConfigurationManager.ConnectionStrings[connectionString] : null;
    }


    #endregion
  
  }
}