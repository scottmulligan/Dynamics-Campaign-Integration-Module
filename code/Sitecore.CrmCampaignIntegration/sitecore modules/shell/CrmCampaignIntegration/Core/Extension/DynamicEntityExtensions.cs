#region 

using System.Linq;

#endregion

namespace Sitecore.CrmCampaignIntegration.Core.Extension
{
  using Sitecore.CrmCampaignIntegration.Services;
  using Sitecore.CrmCampaignIntegrations.Core;

  /// <summary>
   /// <see cref="DynamicEntity"/> extensions
   /// </summary>
   public static class DynamicEntityExtensions
   {
      /// <summary>
      /// Gets the name of the property by.
      /// </summary>
      /// <param name="entity">The entity.</param>
      /// <param name="name">The name.</param>
      /// <returns></returns>
      public static Property GetPropertyByName(this DynamicEntity entity, string name)
      {
         if (entity.Properties != null)
         {
            return entity.Properties.FirstOrDefault(p => p.Name == name);
         }
         return null;
      }

      /// <summary>
      /// Gets the friendly value.
      /// </summary>
      /// <param name="entity">The entity.</param>
      /// <param name="propertyName">Name of the property.</param>
      /// <returns></returns>
      public static object GetFriendlyValue(this DynamicEntity entity, string propertyName)
      {
         var property = entity.GetPropertyByName(propertyName);
         if (property != null)
         {
            return PropertyFactory.Instance.GetFriendlyValue(property);
         }
         return string.Empty;
      }
   }
}