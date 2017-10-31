#region

using CRMSecurityProvider.Sources.Attribute;

#endregion

namespace Sitecore.CrmCampaignIntegration.Core
{
  using CRMSecurityProvider.Sources.Attribute.Metadata;

  public static class CrmAttributeExtensions
  {
    /// <summary>
    /// Determines whether the specified attribute is required.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is required; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsRequired(this ICrmAttributeMetadata attribute)
    {
      return attribute.IsSelectable()
             && (attribute.IsApplicationRequiredLevel() || attribute.IsSystemRequredLevel())
             && !attribute.IsStateAttribute() && !attribute.IsOwnerAttribute();
    }

    /// <summary>
    /// Determines whether the specified attribute is required.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is required; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsRequired(this ICrmAttributeMetadata attribute, bool checkForm)
    {
      if (checkForm)
      {
        return attribute.IsRequired();
      }

      return attribute.IsApplicable() && attribute.IsValidForCreate() && attribute.IsValidForAdvancedFind && attribute.IsApplicationRequiredLevel() && !attribute.IsStateAttribute() && !attribute.IsOwnerAttribute();
    }

    /// <summary>
    /// Determines whether the specified attribute is required.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is required; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsAdditional(this ICrmAttributeMetadata attribute)
    {
      return attribute.IsSelectable() && (attribute.IsStateAttribute() || attribute.IsRecommendedLevel() || attribute.IsNoneLevel());
    }

    /// <summary>
    /// Determines whether the specified attribute is valid for update, create and read
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is required; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsAdditional(this ICrmAttributeMetadata attribute, bool checkForm)
    {
      if (checkForm)
      {
        return attribute.IsAdditional();
      }

      return attribute.IsApplicable() && attribute.IsValidForCreate() && (attribute.IsStateAttribute() || attribute.IsRecommendedLevel() || attribute.IsNoneLevel());
    }

    /// <summary>
    /// Determines whether the specified attribute is valid for create and read
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is valid; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidForCreate(this ICrmAttributeMetadata attribute)
    {
      return attribute.IsValidForCreate && attribute.IsValidForRead;
    }

    /// <summary>
    /// Determines whether the specified attribute is valid for update
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is valid; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidForUpdate(this ICrmAttributeMetadata attribute)
    {
      return attribute.IsValidForUpdate;
    }

    /// <summary>
    /// Determines whether the attribute has a none level.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute has a none level; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNoneLevel(this ICrmAttributeMetadata attribute)
    {
      return attribute.RequiredLevel == CrmAttributeRequiredLevel.None;
    }

    /// <summary>
    /// Determines whether the attribute is recommended.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute is recommended; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsRecommendedLevel(this ICrmAttributeMetadata attribute)
    {
      return attribute.RequiredLevel == CrmAttributeRequiredLevel.Recommended;
    }

    /// <summary>
    /// Determines whether the attribute has a required level.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute has a required level; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsApplicationRequiredLevel(this ICrmAttributeMetadata attribute)
    {
      return attribute.RequiredLevel == CrmAttributeRequiredLevel.ApplicationRequired;
    }

    /// <summary>
    /// Determines whether the attribute is system required.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute is system required; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSystemRequredLevel(this ICrmAttributeMetadata attribute)
    {
      return attribute.RequiredLevel == CrmAttributeRequiredLevel.SystemRequired;
    }

    /// <summary>
    /// Determines whether the specified attribute is required.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the specified attribute is selectable; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSelectable(this ICrmAttributeMetadata attribute)
    {
      return attribute.IsApplicable() && attribute.IsValidForAdvancedFind;
    }

    /// <summary>
    /// Determines whether the specified attribute is unfit.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// <c>true</c> if the specified attribute is unfit; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsApplicable(this ICrmAttributeMetadata attribute)
    {
      return attribute.AttributeType != CrmAttributeType.UniqueIdentifier && attribute.AttributeType != CrmAttributeType.PrimaryKey;
    }

    /// <summary>
    /// Determines whether the attribute is a state attribute.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute is a state attribute; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsStateAttribute(this ICrmAttributeMetadata attribute)
    {
      return attribute.AttributeType == CrmAttributeType.State;
    }

    /// <summary>
    /// Determines whether the attribute is a owner attribute.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    /// 	<c>true</c> if the attribute is a owner attribute; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsOwnerAttribute(this ICrmAttributeMetadata attribute)
    {
      return attribute.AttributeType == CrmAttributeType.Owner;
    }
  }
}