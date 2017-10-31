#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sitecore.Extensions.XElementExtensions;

#endregion

namespace Sitecore.CrmCampaignIntegration.Core.Crm
{
    using System.Xml.Linq;

    using CRMSecurityProvider.Sources.Attribute;
    using CRMSecurityProvider.Sources.Attribute.Metadata;
    using CRMSecurityProvider.Sources.Entity;
    using HtmlAgilityPack;
    using System.IO;

    /// <summary>
    /// XCrmEntry definition
    /// </summary>
    [Serializable]
  public class XCrmEntry : IEnumerable<XCrmField>, ISerializable
  {
    private XDocument xml;
    private List<XCrmField> fields;

    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="XCrmEntry"/> class.
    /// </summary>
    /// <param name="info">The info.</param>
    /// <param name="context">The context.</param>
    protected XCrmEntry(SerializationInfo info, StreamingContext context)
      : this(info.GetString("Entity"))
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XCrmEntry"/> class.
    /// </summary>
    /// <param name="xml">The XML.</param>
    private XCrmEntry(string xml)
    {
      if (string.IsNullOrEmpty(xml))
      {
        this.xml = XDocument.Parse("<e />");
      }
      else
      {
        var doc = new HtmlDocument();
        doc.LoadHtml(xml);
        doc.OptionOutputAsXml = true;
        this.xml = XDocument.Load(new StringReader(doc.DocumentNode.OuterHtml));
      }
    }

    /// <summary>
    /// Parses the specified XML.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    public static XCrmEntry Parse(string xml)
    {
      return new XCrmEntry(xml);
    }

    public void Remove(Func<XCrmField, bool> condition)
    {
      foreach (var field in Fields.ToArray())
      {
        if (condition(field))
        {
          Remove(field.Name);
        }
      }
    }

    public void Remove(string value)
    {
      xml.Root.Elements("f").Where(e => e.GetAttributeValue("n") == value).Remove();
      fields = null;
    }

    /// <summary>
    /// Adds the specified attribute.
    /// </summary>
    /// <param name="attribute">The metadata.</param>
    public void Add(ICrmAttributeMetadata attribute)
    {
      var field = this[attribute.LogicalName];
      if (field != null)
      {
        field.Disabled = false;
        field.Merge(attribute);
      }
      else
      {
        xml.Root.Add(XElement.Parse(XCrmField.Parse(attribute).ToString()));
        fields = null;
      }
    }

    /// <summary>
    /// Adds the range.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    public void AddRange(IEnumerable<ICrmAttributeMetadata> attributes)
    {
      foreach (var attribute in attributes)
      {
        if (!Contains(attribute.LogicalName))
        {
          Add(attribute);
        }
      }
    }

    /// <summary>
    /// Clears this instance.
    /// </summary>
    public void Clear()
    {
      xml.Root.Elements("f").Remove();
      fields = null;
    }

    /// <summary>
    /// Determines whether [contains] the field with [the specified name].
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>
    /// 	<c>true</c> if [contains] the field with [the specified name]; otherwise, <c>false</c>.
    /// </returns>
    public bool Contains(string name)
    {
      return this[name] != null;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return xml.ToString();
    }

    /// <summary>
    /// Merges with the specified metadata.
    /// </summary>
    /// <param name="metadata">The metadata.</param>
    public void Merge(CrmEntityMetadata metadata)
    {
      foreach (var field in Fields)
      {
        field.Disabled = true;

        var attribute = metadata.GetAttribute(field.Name);

        if (attribute != null)
        {
          field.Disabled = false;
          field.Merge(attribute);
        }
      }
    }

    /// <summary>
    /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
    /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
    /// <exception cref="T:System.Security.SecurityException">
    /// The caller does not have the required permission.
    /// </exception>
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Entity", ToString(), typeof(string));
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<XCrmField> GetEnumerator()
    {
      return Fields.GetEnumerator();
    }

    #endregion

    #region Protected

    /// <summary>
    /// Gets the fields.
    /// </summary>
    /// <value>The fields.</value>
    public IEnumerable<XCrmField> Fields
    {
      get
      {
        if (fields == null)
        {
          fields = new List<XCrmField>(xml.Root.Elements("f").Select(element => new XCrmField(element)));
        }
        return fields;
      }
    }

    /// <summary>
    /// Gets the <see cref="XCrmField"/> with the specified name.
    /// </summary>
    /// <value></value>
    public XCrmField this[string name]
    {
      get
      {
        return Fields.FirstOrDefault(f => f.Name == name);
      }
    }

    /// <summary>
    /// Gets the required fields.
    /// </summary>
    /// <value>The required fields.</value>
    public IEnumerable<XCrmField> RequiredFields
    {
      get
      {
        return Fields.Where(f => f.Required && !f.Disabled);
      }
    }

    /// <summary>
    /// Gets the additional fields.
    /// </summary>
    /// <value>The additional fields.</value>
    public IEnumerable<XCrmField> AdditionalFields
    {
      get
      {
        return Fields.Where(f => !f.Required && !f.Disabled);
      }
    }

    public bool IsEmpty
    {
      get
      {
        return Fields.Count() == 0;
      }
    }

    public CrmAttributeType AuditAttributeType
    {
      get
      {
        var value = xml.Root.GetAttributeValue("aat");
        var crmAttributeType = CrmAttributeType.Unknown;
        Enum.TryParse(value, out crmAttributeType);
        return crmAttributeType;
      }
      internal set
      {
        xml.Root.SetAttributeValue("aat", value.ToString());
      }
    }

    public string Audit
    {
      get
      {
        return xml.Root.GetAttributeValue("a");
      }
      internal set
      {
        xml.Root.SetAttributeValue("a", value ?? string.Empty);
      }
    }

    public bool SupportStateCode
    {
      get
      {
        return MainUtil.GetBool(xml.Root.GetAttributeValue("ss"), true);
      }
      internal set
      {
        xml.Root.SetAttributeValue("ss", value);
      }
    }

    public string PrimaryFieldName
    {
      get
      {
        return xml.Root.GetAttributeValue("pf");
      }
      set
      {
        xml.Root.SetAttributeValue("pf", value ?? string.Empty);
      }
    }

    public string EntityName
    {
      get
      {
        return xml.Root.GetAttributeValue("en");
      }
      set
      {
        xml.Root.SetAttributeValue("en", value ?? string.Empty);
      }
    }

    public XCrmField PrimaryField
    {
      get
      {
        return this[PrimaryFieldName];
      }
    }

    public string PrimaryKey
    {
      get
      {
        return xml.Root.GetAttributeValue("pk");
      }
      set
      {
        xml.Root.SetAttributeValue("pk", value ?? string.Empty);
      }
    }

    public bool OverwriteNotEmptyField
    {
      get
      {
        return MainUtil.GetBool(xml.Root.GetAttributeValue("ow"), false);
      }
      set
      {
        xml.Root.SetAttributeValue("ow", value);
      }
    }

    #endregion
  }
}