namespace Sitecore.CrmCampaignIntegration.Core
{
  using CRMSecurityProvider.Sources.PagingInfo;
  using Sitecore.CrmCampaignIntegration.DataViewer;


  /// <summary>
  /// <see cref="PageCriteria"/> extensions
  /// </summary>
  public static class PageCriteriaExtensions
  {
    /// <summary>
    /// Convert to the <see cref="CrmPagingInfo"/>.
    /// </summary>public 
    /// <param name="page">The page.</param>
    /// <returns></returns>
    public static CrmPagingInfo ToPagingInfo(this PageCriteria page)
    {
      return new CrmPagingInfo { PageNumber = page.PageIndex + 1, Count = page.PageSize };
    }
  }
}