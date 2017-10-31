#region

using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Sitecore.Data;

#endregion

namespace Sitecore.CrmCampaignIntegration.Core
{
  using System.ComponentModel;
  using CRMSecurityProvider.Sources.PagingInfo;

  /// <summary>
  /// <see cref="SortCriteria"/> extension
  /// </summary>
  public static class SortCriteriaExtensions
  {
    /// <summary>
    /// Convert to the <see cref="CrmOrderExpression"/>.
    /// </summary>
    /// <param name="sort">The sort criteria.</param>
    /// <returns></returns>
    public static CrmOrderExpression ToOrderExpression(this SortCriteria sort)
    {
      return new CrmOrderExpression
      {
        AttributeName = sort.FieldName,
        OrderType = sort.Direction == SortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending
      };
    }

    /// <summary>
    /// Convert to the <see cref="CrmOrderExpression"/> array.
    /// </summary>
    /// <param name="sortCriteria">The sort criteria.</param>
    /// <returns></returns>
    public static CrmOrderExpression[] ToOrderExpressionArray(this IEnumerable<SortCriteria> sortCriteria)
    {
      return sortCriteria.Where(s => s != null).Select(s => s.ToOrderExpression()).ToArray();
    }
  }
}