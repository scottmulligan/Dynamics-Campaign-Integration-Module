// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityMetadataExtensions.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Defines the EntityMetadataExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Core
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Attribute.Metadata;
  using CRMSecurityProvider.Sources.Entity;

  public static class EntityMetadataExtensions
  {
    /// <summary>
    /// Gets the attributes by names.
    /// </summary>
    /// <param name="metadata">The metadata.</param>
    /// <param name="names">The names.</param>
    public static IEnumerable<ICrmAttributeMetadata> GetAttributesByNames(this CrmEntityMetadata metadata, IEnumerable<string> names)
    {
      var attributes = new List<ICrmAttributeMetadata>();
      if (names != null)
      {
        foreach (var name in names)
        {
          if (string.IsNullOrEmpty(name))
          {
            continue;
          }

          var attribute = metadata.GetAttribute(name);
          if (attribute != null)
          {
            attributes.Add(attribute);
          }
        }
      }

      return attributes;
    }

    /// <summary>
    /// Audits the allowed fields.
    /// </summary>
    /// <param name="metadata">The metadata.</param>
    public static IEnumerable<ICrmAttributeMetadata> AuditAllowedFields(this CrmEntityMetadata metadata)
    {
      if (metadata.Attributes != null)
      {
        return metadata.Attributes.Where(a => a.AttributeType == CrmAttributeType.Memo).OrderBy(a => a.Title);
      }

      return new List<ICrmAttributeMetadata>();
    }

    public static bool IsSupportActiveState(this CrmEntityMetadata metadata)
    {
      var state = metadata.GetAttribute("statecode") as ICrmStateAttributeMetadata;
      return state != null && state.Options != null && state.Options.Any(o => o.Value.Equals("Active", StringComparison.InvariantCultureIgnoreCase));
    }
  }
}