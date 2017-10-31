namespace Sitecore.CrmCampaignIntegration.Core.Extension
{
  using Sitecore.CrmCampaignIntegration.Services;

  /// <summary>
   ///  <see cref="ConditionExpression"/> extensions
   /// </summary>
   public static class ConditionExpressionExtensions
   {
      /// <summary>
      /// Determines whether the specified condition is empty.
      /// </summary>
      /// <param name="condition">The condition.</param>
      /// <returns>
      /// 	<c>true</c> if the specified condition is empty; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsEmpty(this ConditionExpression condition)
      {
         return string.IsNullOrEmpty(condition.AttributeName) || condition.Values == null || condition.Values.Length == 0;
      }
   }
}