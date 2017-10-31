#region

using System;
using System.Globalization;

using Sitecore.Data;
using Sitecore.Diagnostics;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using Sitecore.CrmCampaignIntegration.Services;

  /// <summary>
  /// Crm properties factory
  /// </summary>
  public class PropertyFactory
  {
    static PropertyFactory()
    {
      Instance = new PropertyFactory();
    }

    private PropertyFactory()
    {
    }

    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static PropertyFactory Instance { get; private set; }

    /// <summary>
    /// Sets the default property factory.
    /// </summary>
    /// <param name="factory">The factory.</param>
    protected static void SetDefaultPropertyFactory(PropertyFactory factory)
    {
      Assert.ArgumentNotNull(factory, "factory");
      Instance = factory;
    }

    /// <summary>
    /// Creates the instance.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">value</exception>
    public virtual Property GetProperty(string propertyName, object value)
    {
      Property property;
      if (string.IsNullOrEmpty(propertyName))
      {
        throw new ArgumentException("Property name must be non null.", "propertyName");
      }
      if (value == null)
      {
        throw new ArgumentNullException("Property value must be non null.", "value");
      }

      if (string.Compare(propertyName, "StateCode", true, CultureInfo.InvariantCulture) == 0)
      {
        property = new StateProperty { Value = (string)value };
      }
      else if (value is string)
      {
        property = new StringProperty { Value = (string)value };
      }
      else if (value is UniqueIdentifier)
      {
        property = new UniqueIdentifierProperty { Value = (UniqueIdentifier)value };
      }
      else if (value is Status)
      {
        property = new StatusProperty { Value = (Status)value };
      }
      else if (value is Picklist)
      {
        property = new PicklistProperty { Value = (Picklist)value };
      }
      else if (value is Owner)
      {
        property = new OwnerProperty { Value = (Owner)value };
      }
      else if (value is Lookup)
      {
        property = new LookupProperty { Value = (Lookup)value };
      }
      else if (value is CrmCampaignIntegration.Services.Key)
      {
        property = new KeyProperty { Value = (CrmCampaignIntegration.Services.Key)value };
      }
      else if (value is EntityNameReference)
      {
        property = new EntityNameReferenceProperty { Value = (EntityNameReference)value };
      }
      else if (value is DynamicEntity[])
      {
        property = new DynamicEntityArrayProperty { Value = (DynamicEntity[])value };
      }
      else if (value is Customer)
      {
        property = new CustomerProperty { Value = (Customer)value };
      }
      else if (value is CrmCampaignIntegration.Services.CrmNumber)
      {
        property = new CrmNumberProperty { Value = (CrmCampaignIntegration.Services.CrmNumber)value };
      }
      else if (value is CrmMoney)
      {
        property = new CrmMoneyProperty { Value = (CrmMoney)value };
      }
      else if (value is CrmCampaignIntegration.Services.CrmFloat)
      {
        property = new CrmFloatProperty { Value = (CrmCampaignIntegration.Services.CrmFloat)value };
      }
      else if (value is CrmDecimal)
      {
        property = new CrmDecimalProperty { Value = (CrmDecimal)value };
      }
      else if (value is CrmCampaignIntegration.Services.CrmDateTime)
      {
        property = new CrmDateTimeProperty { Value = (CrmCampaignIntegration.Services.CrmDateTime)value };
      }
      else if (value is CrmCampaignIntegration.Services.CrmBoolean)
      {
        property = new CrmBooleanProperty { Value = (CrmCampaignIntegration.Services.CrmBoolean)value };
      }
      else
      {
        throw new NotSupportedException(string.Format("Unknown value type: {0}", value.GetType()));
      }

      property.Name = propertyName;
      return property;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns></returns>
    public virtual object GetFriendlyValue(Property property)
    {
      Assert.ArgumentNotNull(property, "property");

      if (property is StateProperty)
      {
        return ((StateProperty)(property)).Value;
      }

      if (property is StringProperty)
      {
        return ((StringProperty)property).Value;
      }

      if (property is UniqueIdentifierProperty)
      {
        return ((UniqueIdentifierProperty)property).Value.Value;
      }

      if (property is StatusProperty)
      {
        return ((StatusProperty)property).Value.name;
      }

      if (property is PicklistProperty)
      {
        return ((PicklistProperty)property).Value.name;
      }

      if (property is OwnerProperty)
      {
        return ((OwnerProperty)property).Value.name;
      }

      if (property is LookupProperty)
      {
        return ((LookupProperty)property).Value.name;
      }

      if (property is KeyProperty)
      {
        return ((KeyProperty)property).Value.Value;
      }

      if (property is EntityNameReferenceProperty)
      {
        return ((EntityNameReferenceProperty)property).Value.Value;
      }

      if (property is DynamicEntityArrayProperty)
      {
        var dynamycProperty = (DynamicEntityArrayProperty)property;
        if (dynamycProperty.Value.Length > 0 && dynamycProperty.Value[0] != null && dynamycProperty.Value[0].Properties.Length > 0 &&
            dynamycProperty.Value[0].Properties[0] != null)
        {
          return GetFriendlyValue(((DynamicEntityArrayProperty)property).Value[0].Properties[0]);
        }
        return string.Empty;
      }

      if (property is CustomerProperty)
      {
        return ((CustomerProperty)property).Value.name;
      }

      if (property is CrmNumberProperty)
      {
        return ((CrmNumberProperty)property).Value.Value;
      }

      if (property is CrmMoneyProperty)
      {
        return ((CrmMoneyProperty)property).Value.formattedvalue;
      }

      if (property is CrmFloatProperty)
      {
        return ((CrmFloatProperty)property).Value.formattedvalue;
      }

      if (property is CrmDecimalProperty)
      {
        return ((CrmDecimalProperty)property).Value.formattedvalue;
      }

      if (property is CrmDateTimeProperty)
      {
        return ((CrmDateTimeProperty)property).Value.Value;
      }

      if (property is CrmBooleanProperty)
      {
        return ((CrmBooleanProperty)property).Value.name;
      }

      return string.Empty;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns></returns>
    public virtual object GetValue(Property property)
    {
      Assert.ArgumentNotNull(property, "property");

      if (property is StateProperty)
      {
        return ((StateProperty)property).Value;
      }

      if (property is StringProperty)
      {
        return ((StringProperty)property).Value;
      }

      if (property is UniqueIdentifierProperty)
      {
        return ((UniqueIdentifierProperty)property).Value.Value;
      }

      if (property is StatusProperty)
      {
        return ((StatusProperty)property).Value.Value;
      }

      if (property is PicklistProperty)
      {
        return ((PicklistProperty)property).Value.Value;
      }

      if (property is OwnerProperty)
      {
        return ((OwnerProperty)property).Value.Value;
      }

      if (property is LookupProperty)
      {
        return ((LookupProperty)property).Value.Value;
      }

      if (property is KeyProperty)
      {
        return ((KeyProperty)property).Value.Value;
      }

      if (property is EntityNameReferenceProperty)
      {
        return ((EntityNameReferenceProperty)property).Value.Value;
      }

      if (property is DynamicEntityArrayProperty)
      {
        var dynamycProperty = (DynamicEntityArrayProperty)property;
        if (dynamycProperty.Value.Length > 0 && dynamycProperty.Value[0] != null && dynamycProperty.Value[0].Properties.Length > 0 &&
            dynamycProperty.Value[0].Properties[0] != null)
        {
          return GetValue(((DynamicEntityArrayProperty)property).Value[0].Properties[0]);
        }
        return string.Empty;
      }

      if (property is CustomerProperty)
      {
        return ((CustomerProperty)property).Value.Value;
      }

      if (property is CrmNumberProperty)
      {
        return ((CrmNumberProperty)property).Value.Value;
      }

      if (property is CrmMoneyProperty)
      {
        return ((CrmMoneyProperty)property).Value.Value;
      }

      if (property is CrmFloatProperty)
      {
        return ((CrmFloatProperty)property).Value.Value;
      }

      if (property is CrmDecimalProperty)
      {
        return ((CrmDecimalProperty)property).Value.Value;
      }

      if (property is CrmDateTimeProperty)
      {
        return ((CrmDateTimeProperty)property).Value.Value;
      }

      if (property is CrmBooleanProperty)
      {
        return ((CrmBooleanProperty)property).Value.Value;
      }

      return string.Empty;
    }

    public virtual void SetPropertyValue(Property property, string value, params string[] data)
    {
      Assert.ArgumentNotNull(property, "property");

      if (property is StateProperty)
      {
        ((StateProperty)property).Value = value;
        return;
      }

      if (property is StringProperty)
      {
        ((StringProperty)property).Value = value;
        return;
      }

      if (property is UniqueIdentifierProperty)
      {
        ID idValue = null;
        if (ID.TryParse(value, out idValue))
        {
          var identifier = new UniqueIdentifier { Value = idValue.Guid };
          ((UniqueIdentifierProperty)property).Value = identifier;
        }
        return;
      }

      if (property is StatusProperty)
      {
        int intValue = 0;
        if (int.TryParse(value, out intValue))
        {
          var status = new Status { Value = intValue };
          ((StatusProperty)property).Value = status;
        }

        return;
      }

      if (property is PicklistProperty)
      {
        string picklistValue = value;
        Picklist list = null;
        int intValue = 0;

        if (!string.IsNullOrEmpty(picklistValue) && int.TryParse(picklistValue, out intValue))
        {
          list = new Picklist { Value = intValue };
        }
        else
        {
          picklistValue = null;
        }

        if (string.IsNullOrEmpty(picklistValue))
        {
          list = new Picklist
          {
            IsNull = true,
            IsNullSpecified = true
          };
        }

        ((PicklistProperty)property).Value = list;
        return;
      }

      if (property is OwnerProperty)
      {
        ID idValue = null;
        if (ID.TryParse(value, out idValue))
        {
          var owner = new Owner { Value = idValue.Guid, type = data[0] };
          ((OwnerProperty)property).Value = owner;
        }
        return;
      }

      if (property is LookupProperty)
      {
        ID idValue = null;
        if (ID.TryParse(value, out idValue))
        {
          var lookup = new Lookup { Value = idValue.Guid, type = data[0] };
          ((LookupProperty)property).Value = lookup;
        }
        return;
      }

      if (property is KeyProperty)
      {
        ID idValue = null;
        if (ID.TryParse(value, out idValue))
        {
          var key = new CrmCampaignIntegration.Services.Key { Value = idValue.Guid };
          ((KeyProperty)property).Value = key;
        }
        return;
      }

      if (property is EntityNameReferenceProperty)
      {
        var reference = new EntityNameReference { Value = value };
        ((EntityNameReferenceProperty)property).Value = reference;
        return;
      }

      if (property is DynamicEntityArrayProperty)
      {
        var dynamycProperty = (DynamicEntityArrayProperty)property;

        dynamycProperty.Value = new[]
                                             {
                                                 new DynamicEntity{Name = "activityparty",
                                                 Properties = new []
                                                                 {
                                                                    new LookupProperty
                                                                       {
                                                                          Name = "partyid", 
                                                                          Value = new Lookup
                                                                                     {
                                                                                        Value = new Guid(value),
                                                                                        type = data[0]
                                                                                     }
                                                                       }
                                                                  }} 
                };
      }

      if (property is CustomerProperty)
      {
        ID idValue = null;
        if (ID.TryParse(value, out idValue))
        {
          var customer = new Customer { Value = idValue.Guid, type = data[0] };
          ((CustomerProperty)property).Value = customer;
        }
        return;
      }

      if (property is CrmNumberProperty)
      {
        int intValue = 0;
        if (int.TryParse(value, out intValue))
        {
          var number = new CrmCampaignIntegration.Services.CrmNumber { Value = intValue };
          ((CrmNumberProperty)property).Value = number;
        }
        return;
      }

      if (property is CrmMoneyProperty)
      {
        decimal decimalValue = 0;
        if (decimal.TryParse(value, out decimalValue))
        {
          var money = new CrmMoney { Value = decimalValue };
          ((CrmMoneyProperty)property).Value = money;
        }
        return;
      }

      if (property is CrmFloatProperty)
      {
        float decimalValue = 0;
        if (float.TryParse(value, out decimalValue))
        {
          var crmFloat = new CrmCampaignIntegration.Services.CrmFloat { Value = decimalValue };
          ((CrmFloatProperty)property).Value = crmFloat;
        }
        return;
      }

      if (property is CrmDecimalProperty)
      {
        decimal decimalValue = 0;
        if (decimal.TryParse(value, out decimalValue))
        {
          var crmDecimal = new CrmDecimal { Value = decimalValue };
          ((CrmDecimalProperty)property).Value = crmDecimal;
        }
        return;
      }

      if (property is CrmDateTimeProperty)
      {
        var dateTime = Sitecore.CrmCampaignIntegrations.Core.Utility.DateUtil.ToCrmDateTime(value);
        if (dateTime != null)
        {
          var crmDateTime = new CrmCampaignIntegration.Services.CrmDateTime { Value = dateTime.Value };
          ((CrmDateTimeProperty)property).Value = crmDateTime;
        }
      }

      if (property is CrmBooleanProperty)
      {
        var boolValue = MainUtil.GetBool(value, false);
        var crmBool = new CrmCampaignIntegration.Services.CrmBoolean { Value = boolValue };
        ((CrmBooleanProperty)property).Value = crmBool;
        return;
      }
    }

    public Property CreateProperty(string name, CRMSecurityProvider.Sources.Attribute.CrmAttributeType type, string value, params string[] data)
    {
      Property property = null;
      switch (type)
      {
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Boolean:
          property = new CrmBooleanProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Customer:
          property = new CustomerProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.DateTime:
          property = new CrmDateTimeProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Decimal:
          property = new CrmDecimalProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Float:
          property = new CrmFloatProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Integer:
          property = new CrmNumberProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Lookup:
          property = new LookupProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Memo:
          property = new StringProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Money:
          property = new CrmMoneyProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Owner:
          property = new OwnerProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Picklist:
          property = new PicklistProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.State:
          property = new StateProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Status:
          property = new StatusProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.String:
          property = new StringProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.UniqueIdentifier:
          property = new UniqueIdentifierProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.PartyList:
          property = new DynamicEntityArrayProperty();
          break;
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Virtual:
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.CalendarRules:
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.Internal:
        case CRMSecurityProvider.Sources.Attribute.CrmAttributeType.PrimaryKey:
          break;
      }

      if (property != null)
      {
        SetPropertyValue(property, value, data);
      }

      return property;
    }
  }
}