#region

using System.Collections.Generic;
using System.Linq;

using Sitecore.Web.UI.Grids;

#endregion

namespace Sitecore.CrmCampaignIntegration.Core.Extension
{
  using Sitecore.CrmCampaignIntegration.Services;

  /// <summary>
   /// <see cref="GridFilter"/> extensions
   /// </summary>
   public static class GridFilterExtensions
   {
      /// <summary>
      /// Convert to the <see cref="ConditionExpression"/>.
      /// </summary>
      /// <param name="filter">The filter.</param>
      /// <returns></returns>
      public static ConditionExpression ToLikeConditionExpression(this GridFilter filter)
      {
         return new ConditionExpression
                   {
                      AttributeName = filter.FieldName,
                      Values = new object[] {string.Format("%{0}%", filter.Criteria)},
                      Operator = ConditionOperator.Like
                   };
      }

      /// <summary>
      /// Convert to the <see cref="FilterExpression"/>.
      /// </summary>
      /// <param name="filters">The filters.</param>
      /// <returns></returns>
      public static FilterExpression ToFilterExpression(this IEnumerable<GridFilter> filters)
      {
         return new FilterExpression
                   {
                      Conditions = filters.Select(f => f.ToLikeConditionExpression()).ToArray(),
                      FilterOperator = LogicalOperator.Or
                   };
      }

      /// <summary>
      /// Toes the filter expression.
      /// </summary>
      /// <param name="filters">The filters.</param>
      /// <param name="supportState">if set to <c>true</c> [support state].</param>
      /// <returns></returns>
      public static FilterExpression ToFilterExpression(this IEnumerable<GridFilter> filters, bool supportState)
      {
         var innerFilters = filters.ToFilterExpression();
         if (supportState)
         {
            return new FilterExpression
                      {
                         Filters = innerFilters.IsEmpty() ? null : new[] {innerFilters},

                         FilterOperator = LogicalOperator.And,
                         Conditions =
                            new[]
                               {
                                  new ConditionExpression
                                     {
                                        AttributeName = "statecode",
                                        Operator = ConditionOperator.Equal,
                                        Values = new object[] {"Active"}
                                     }
                               }
                      };
         }
         return innerFilters;
      }
   }
}