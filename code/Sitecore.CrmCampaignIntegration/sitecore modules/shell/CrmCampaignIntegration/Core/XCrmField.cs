using System;
using CRMSecurityProvider;

namespace Sitecore.CrmCampaignIntegration.Core.Crm
{
  using System.Xml.Linq;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Attribute.Metadata;
  using Sitecore.CrmCampaignIntegrations.Core;  
  using Sitecore.Diagnostics;
  using Sitecore.Extensions.XElementExtensions;
  using Crm;
  using Sitecore.StringExtensions;

  /// <summary>
  /// The x crm field.
  /// </summary>
  public class XCrmField
  {
    #region Feilds

    /// <summary>
    /// The xml.
    /// </summary>
    private XElement xml;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="XCrmField"/> class.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    internal XCrmField(XElement element)
    {
      this.xml = element;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XCrmField"/> class.
    /// </summary>
    /// <param name="xml">
    /// The xml.
    /// </param>
    private XCrmField(string xml)
      : this(XElement.Parse(xml))
    {
    }

    #endregion

    #region Public methods

    /// <summary>
    /// The to string.
    /// </summary>
    /// <returns>
    /// The to string.
    /// </returns>
    public override string ToString()
    {
      return this.xml.ToString();
    }

    #endregion

    #region Private methods

    /// <summary>
    /// The parse.
    /// </summary>
    /// <param name="xml">
    /// The xml.
    /// </param>
    /// <returns>
    /// </returns>
    private static XCrmField Parse(string xml)
    {
      return new XCrmField(xml);
    }

    #endregion

    /// <summary>
    /// The parse.
    /// </summary>
    /// <param name="metadata">
    /// The metadata.
    /// </param>
    /// <returns>
    /// </returns>
    internal static XCrmField Parse(ICrmAttributeMetadata metadata)
    {
      Assert.ArgumentNotNull(metadata, "metadata");
      XCrmField field = Parse("<f n='{0}' />".FormatWith(metadata.LogicalName ?? string.Empty));
      field.EditMode = "Always";
      field.Merge(metadata);

      return field;
    }

    /// <summary>
    /// The merge.
    /// </summary>
    /// <param name="metadata">
    /// The metadata.
    /// </param>
    internal void Merge(ICrmAttributeMetadata metadata)
    {
      if (metadata != null && this.Name == (metadata.LogicalName ?? string.Empty))
      {
        this.Title = metadata.Title;
        this.Required = metadata.IsRequired();

        string kind = string.Empty;
        switch (metadata.AttributeType)
        {
          case CrmAttributeType.Customer:
          case CrmAttributeType.Lookup:
            kind = "1";
            break;
          case CrmAttributeType.Picklist:
            kind = "2";
            break;
          case CrmAttributeType.State:
            kind = "3";
            break;
          case CrmAttributeType.Status:
            kind = "4";
            break;
        }

        if (!string.IsNullOrEmpty(kind))
        {
          this.SetKind(kind);
        }

        this.DefaultValue = string.Empty;
        this.AttributeType = metadata.AttributeType;

        if (string.IsNullOrEmpty(this.xml.GetAttributeValue("uvt")))
        {
          this.UseValueType = this.IsRestricted ? 1 : 0;
        }
      }
    }

    #endregion

    #region Properties

    #region Public properties

    /// <summary>
    /// Gets AttributeType.
    /// </summary>
    public CrmAttributeType AttributeType
    {
      get
      {
        string value = this.xml.GetAttributeValue("at");
        var attributeType = CrmAttributeType.Unknown;
        Enum.TryParse(value, true, out attributeType);
        return attributeType;
      }

      private set
      {
        this.xml.SetAttributeValue("at", value.ToString());
      }
    }

    /// <summary>
    /// Gets or sets CrmValue.
    /// </summary>
    public string CrmValue
    {
      get
      {
        if (this.xml.Attribute("cv") == null)
        {
          return this.DefaultValue;
        }

        return this.xml.GetAttributeValue("cv");
      }

      set
      {
        this.xml.SetAttributeValue("cv", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets DefaultValue.
    /// </summary>
    public string DefaultValue
    {
      get
      {
        return this.xml.GetAttributeValue("dv");
      }

      set
      {
        this.xml.SetAttributeValue("dv", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Disabled.
    /// </summary>
    public bool Disabled
    {
      get
      {
        return MainUtil.GetBool(this.xml.GetAttributeValue("d"), false);
      }

      set
      {
        this.xml.SetAttributeValue("d", value);
      }
    }

    /// <summary>
    /// Gets or sets EditMode.
    /// </summary>
    public string EditMode
    {
      get
      {
        return this.xml.GetAttributeValue("em");
      }

      set
      {
        this.xml.SetAttributeValue("em", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets EntityReference.
    /// </summary>
    public string EntityReference
    {
      get
      {
        return this.xml.GetAttributeValue("er");
      }

      set
      {
        this.xml.SetAttributeValue("er", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets FormValueFrom.
    /// </summary>
    public string FormValueFrom
    {
      get
      {
        return this.xml.GetAttributeValue("fvf");
      }

      set
      {
        this.xml.SetAttributeValue("fvf", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets a value indicating whether IsLookup.
    /// </summary>
    public bool IsLookup
    {
      get
      {
        return this.xml.GetAttributeValue("k") == "1";
      }
    }

    /// <summary>
    /// Gets a value indicating whether IsPicklist.
    /// </summary>
    public bool IsPicklist
    {
      get
      {
        return this.xml.GetAttributeValue("k") == "2";
      }
    }

    /// <summary>
    /// Gets a value indicating whether a set of possible values is restricted.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if a set of possible values is restricted; otherwise, <c>false</c>.
    /// </value>
    public bool IsRestricted
    {
      get
      {
        return this.IsLookup || this.IsPicklist || this.IsState || this.IsStatus;
      }
    }

    /// <summary>
    /// Gets a value indicating whether IsState.
    /// </summary>
    public bool IsState
    {
      get
      {
        return this.xml.GetAttributeValue("k") == "3";
      }
    }

    /// <summary>
    /// Gets a value indicating whether IsStatus.
    /// </summary>
    public bool IsStatus
    {
      get
      {
        return this.xml.GetAttributeValue("k") == "4";
      }
    }

    /// <summary>
    /// Gets or sets LookupValue.
    /// </summary>
    public LookupValue LookupValue
    {
      get
      {
        if (this.IsLookup && !string.IsNullOrEmpty(this.PrimaryKey) && !string.IsNullOrEmpty(this.PrimaryField) &&
            !string.IsNullOrEmpty(this.CrmValue) && !string.IsNullOrEmpty(this.EntityReference))
        {
          return new LookupValue(this.PrimaryKey, this.PrimaryField, this.CrmValue, this.EntityReference);
        }

        return null;
      }

      set
      {
        if (this.IsLookup)
        {
          if (value == null)
          {
            this.PrimaryKey = string.Empty;
            this.PrimaryField = string.Empty;
            this.CrmValue = string.Empty;
            this.EntityReference = string.Empty;
          }
          else
          {
            this.PrimaryKey = value.PrimaryKey;
            this.PrimaryField = value.PrimaryField;
            this.CrmValue = value.PrimaryKeyValue;
            this.EntityReference = value.EntityReference;
          }
        }
      }
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    [NotNull]
    public string Name
    {
      get
      {
        return this.xml.GetAttributeValue("n");
      }
    }

    /// <summary>
    /// Gets or sets PrimaryField.
    /// </summary>
    public string PrimaryField
    {
      get
      {
        return this.xml.GetAttributeValue("pf");
      }

      set
      {
        this.xml.SetAttributeValue("pf", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets PrimaryKey.
    /// </summary>
    public string PrimaryKey
    {
      get
      {
        return this.xml.GetAttributeValue("pk");
      }

      set
      {
        this.xml.SetAttributeValue("pk", value ?? string.Empty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="XCrmField"/> is required.
    /// </summary>
    /// <value><c>true</c> if required; otherwise, <c>false</c>.</value>
    public bool Required
    {
      get
      {
        return MainUtil.GetBool(this.xml.GetAttributeValue("r"), false);
      }

      internal set
      {
        this.xml.SetAttributeValue("r", value ? "1" : "0");
      }
    }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title
    {
      get
      {
        string title = this.xml.GetAttributeValue("t");
        if (string.IsNullOrEmpty(title))
        {
          return this.Name;
        }

        return title;
      }

      private set
      {
        this.xml.SetAttributeValue("t", value);
      }
    }

    /// <summary>
    /// Gets or sets UseValueType.
    /// </summary>
    public int UseValueType
    {
      get
      {
        string value = this.xml.GetAttributeValue("uvt");
        int i = 0;
        int.TryParse(value, out i);
        return i;
      }

      set
      {
        this.xml.SetAttributeValue("uvt", value.ToString());
      }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// The set kind.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    private void SetKind(string value)
    {
      Assert.ArgumentNotNull(value, "value");
      this.xml.SetAttributeValue("k", value);
    }

    #endregion

    #endregion
  }
}