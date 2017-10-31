using System.Collections;
using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Web.UI.Grids;

namespace Sitecore.CrmCampaignIntegration.DataViewer
{
   /// <summary>
   /// sorted and filterable interface
   /// </summary>
   /// <typeparam name="TElement">The type of the element.</typeparam>
   public interface ISortedFilterable<TElement> : IEnumerable<TElement>, IEnumerable
   {
      /// <summary>
      /// Gets the count of entries.
      /// </summary>
      /// <param name="filter">The filter.</param>
      /// <returns></returns>
      int GetCount(IList<GridFilter> filter);

      /// <summary>
      /// Gets the page.
      /// </summary>
      /// <param name="page">The page.</param>
      /// <param name="sort">The sort.</param>
      /// <param name="filter">The filter.</param>
      /// <returns></returns>
      IEnumerable<TElement> GetPage(PageCriteria page, IList<SortCriteria> sort, IList<GridFilter> filter);
   }
}         