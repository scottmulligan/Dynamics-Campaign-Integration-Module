using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.CrmCampaignIntegration.sitecore_modules.web.CrmCampaignIntegration.Actions.Save
{
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Entity;
  using Sitecore.Diagnostics;
  using Sitecore.StringExtensions;

  public static class CrmEntityExtension
  {
    public static void SetProperty(this ICrmEntity entity, string name, CrmAttributeType attributeType, string value, params string[] data)
    {
      if (string.IsNullOrEmpty(name))
      {
        return;
      }

      if (value == null)
      {
        Log.Warn("'Create crm {0}' action: the {1} crm field cannot contain the null value.".FormatWith(entity.LogicalName, name), entity);
      }

      var crmAttribute = entity.Attributes[name];
      if (crmAttribute != null)
      {
        crmAttribute.SetValue(value, data);
      }
      else
      {
        entity.Attributes.Create(name, attributeType, value, data);
      }
    }

  }
}