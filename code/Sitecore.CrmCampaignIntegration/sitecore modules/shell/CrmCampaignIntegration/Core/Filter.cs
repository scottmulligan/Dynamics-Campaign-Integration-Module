#region

using System.Linq;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using Sitecore.CrmCampaignIntegration.Services;

  public static class Filter
   {
      #region Methods

      public static FilterExpression And(params ConditionExpression[] expressions)
      {
         var source = expressions.Where(exp => exp != null);
         if (source.Count() == 0)
         {
            return null;
         }

         var expression2 = new FilterExpression {FilterOperator = LogicalOperator.And, Conditions = source.ToArray()};
         return expression2;
      }

      public static FilterExpression And(params FilterExpression[] filters)
      {
         var source = filters.Where(exp => exp != null);
         if (source.Count() == 0)
         {
            return null;
         }

         var expression2 = new FilterExpression {FilterOperator = LogicalOperator.And, Filters = source.ToArray()};
         return expression2;
      }

      public static FilterExpression Or(params ConditionExpression[] expressions)
      {
         var source = expressions.Where(exp => exp != null);
         if (source.Count() == 0)
         {
            return null;
         }
         var expression2 = new FilterExpression {FilterOperator = LogicalOperator.Or, Conditions = source.ToArray()};
         return expression2;
      }

      public static FilterExpression Or(params FilterExpression[] filters)
      {
         var source = filters.Where(exp => exp != null);
         if (source.Count() == 0)
         {
            return null;
         }
         var expression2 = new FilterExpression {FilterOperator = LogicalOperator.Or, Filters = source.ToArray()};
         return expression2;
      }

      #endregion
   }
}