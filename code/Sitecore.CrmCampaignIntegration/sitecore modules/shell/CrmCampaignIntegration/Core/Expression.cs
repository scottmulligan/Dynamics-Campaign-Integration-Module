#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using Sitecore.CrmCampaignIntegration.Services;

  public class Expression
   {
      #region Methods

      public static OrderExpression BuildOrderExpression(string attribute)
      {
         return BuildOrderExpression(attribute, OrderType.Ascending);
      }

      public static OrderExpression BuildOrderExpression(string attribute, OrderType orderType)
      {
         var expression = new OrderExpression {AttributeName = attribute, OrderType = orderType};
         return expression;
      }

      public static ConditionExpression Equals(string attributeName, object value)
      {
         return GetExpression(ConditionOperator.Equal, attributeName, new[] {value});
      }

      private static ConditionExpression GetExpression(ConditionOperator conditionOperator, string attribute)
      {
         var expression = new ConditionExpression {AttributeName = attribute, Operator = conditionOperator};
         return expression;
      }

      private static ConditionExpression GetExpression(ConditionOperator conditionOperator,
                                                       string attribute,
                                                       object[] values)
      {
         var expression = GetExpression(conditionOperator, attribute);
         if (values != null)
         {
            expression.Values = values;
         }
         return expression;
      }

      public static ConditionExpression GreaterEqual(string attributeName, object value)
      {
         return GetExpression(ConditionOperator.GreaterEqual, attributeName, new[] {value});
      }

      public static ConditionExpression In(string attributeName, IEnumerable values)
      {
         List<string> list = new List<string>();
         foreach (object obj2 in values)
         {
            list.Add(obj2.ToString());
         }
         return GetExpression(ConditionOperator.In, attributeName, list.ToArray());
      }

      public static ConditionExpression LastXDays(string attributeName, int days)
      {
         return GetExpression(ConditionOperator.LastXDays, attributeName, new object[] {days});
      }

      public static ConditionExpression LessEqual(string attributeName, object value)
      {
         return GetExpression(ConditionOperator.LessEqual, attributeName, new[] {value});
      }

      public static ConditionExpression Like(string attributeName, string value)
      {
         return GetExpression(ConditionOperator.Like, attributeName, new object[] {value});
      }

      public static ConditionExpression Null(string attributeName)
      {
         return GetExpression(ConditionOperator.Null, attributeName);
      }
   }

   #endregion
}