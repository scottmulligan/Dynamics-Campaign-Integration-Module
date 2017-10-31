// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedFilterable.cs" company="Sitecore A/S">
//   Copyright (C) 2013 by Sitecore A/S
// </copyright>
// <summary>
//   Defines the SortedFilterable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.DataViewer
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using Sitecore.Common;
  using Sitecore.Data;
  using Sitecore.Diagnostics;
  using Sitecore.Web.UI.Grids;

  public class SortedFilterable<TElement> : ISortedFilterable<TElement>
  {
      #region Fields

      private readonly Func<IList<GridFilter>, int> getFilteredCount;
      private Func<PageCriteria, IList<SortCriteria>, IList<GridFilter>, IEnumerable<TElement>> getPage;

      #endregion

      #region Methods

      public SortedFilterable(Func<PageCriteria, IList<SortCriteria>, IList<GridFilter>, IEnumerable<TElement>> getPage, Func<IList<GridFilter>, int> getFilteredCount) 
      {
         Assert.ArgumentNotNull(getPage, "getFiltered");
         Assert.ArgumentNotNull(getFilteredCount, "getFilteredCount");
         this.getPage = getPage;
         this.getFilteredCount = getFilteredCount;
      }

      public int GetCount(IList<GridFilter> filter)
      {
         Assert.ArgumentNotNull(filter, "filter");
         return this.getFilteredCount(filter);
      }

      public IEnumerable<TElement> GetPage(PageCriteria page, IList<SortCriteria> sort, IList<GridFilter> filter)
      {
         Assert.ArgumentNotNull(page, "page");
         Assert.ArgumentNotNull(filter, "filter");
         return this.getPage(page, sort, filter);
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }

      public IEnumerator<TElement> GetEnumerator()
      {
        return new List<TElement>().GetEnumerator();
      }

      #endregion
   }
}
