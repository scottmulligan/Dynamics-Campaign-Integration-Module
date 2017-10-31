namespace Sitecore.CrmCampaignIntegration.Core.Extension
{
  using Sitecore.CrmCampaignIntegration.Services;

  /// <summary>
   /// <see cref="RetrieveMultipleResponse"/> extension 
   /// </summary>
   public static class RetrieveMultipleResponseExtension
   {
      /// <summary>
      /// Get the the first business entity.
      /// </summary>
      /// <param name="response">The response.</param>
      /// <returns></returns>
      public static BusinessEntity First(this RetrieveMultipleResponse response)
      {
         if (response.BusinessEntityCollection != null && response.BusinessEntityCollection.BusinessEntities != null 
             && response.BusinessEntityCollection.BusinessEntities.Length > 0)
         {
            return response.BusinessEntityCollection.BusinessEntities[0];
         }
         return null;
      }
   }
}