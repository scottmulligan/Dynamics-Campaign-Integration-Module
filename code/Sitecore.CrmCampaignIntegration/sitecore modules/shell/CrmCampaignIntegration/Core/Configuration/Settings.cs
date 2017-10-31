namespace Sitecore.CrmCampaignIntegration.Configuration
{  
  using BaseSettings = Sitecore.Configuration.Settings;

  /// <summary>
  /// Config setting values
  /// </summary>
  public class Settings
  {
    #region Properties 

    /// <summary>
    /// Gets the web service connection string.
    /// </summary>
    public static string CrmConnectionName
    {
      get
      {
        return BaseSettings.GetSetting(ConfigKey.CrmService, "CRMConnString");
      }
    }

    /// <summary>
    /// Gets the type of the CRM gate.
    /// </summary>
    /// <value>
    /// The type of the CRM gate.
    /// </value>
    public static string CrmGateType
    {
      get
      {
        return BaseSettings.GetSetting(ConfigKey.CrmGatewayType, string.Empty);
      }
    }

    /// <summary>
    /// Gets the CRM client form author.
    /// </summary>
    public static string CRMClientFormAuthor
    {
      get
      {
        return @"sitecore\CRM Client Form Author";
      }
    }

    #endregion   
  }
}