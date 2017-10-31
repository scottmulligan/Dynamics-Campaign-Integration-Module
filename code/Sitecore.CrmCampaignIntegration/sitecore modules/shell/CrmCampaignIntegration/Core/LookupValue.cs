#region

using System.Collections.Specialized;

using Sitecore.Diagnostics;
using Sitecore.Form.Core.Utility;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core
{
  /// <summary>
  /// Lookup value implementation 
  /// </summary>
  public class LookupValue
  {
    #region Constants

    private static readonly string primaryFieldAttribute = "primaryfield";
    private static readonly string primaryKeyAttribute = "primarykey";
    private static readonly string primaryKeyValueAttribute = "primarykeyvalue";
    private static readonly string entityReferenceAttribute = "entityreference";

    #endregion

    #region Fields

    private readonly NameValueCollection collection;

    #endregion

    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="LookupValue"/> class.
    /// </summary>
    /// <param name="primaryKey">The primary key.</param>
    /// <param name="primaryField">The primary field.</param>
    /// <param name="primaryKeyValue">The primary key value.</param>
    /// <param name="entityreference">The entity reference.</param>
    public LookupValue(string primaryKey, string primaryField, string primaryKeyValue, string entityreference)
    {
      Assert.ArgumentNotNullOrEmpty(primaryKey, "primaryKey");
      Assert.ArgumentNotNullOrEmpty(primaryField, "primaryField");
      Assert.ArgumentNotNullOrEmpty(primaryKeyValue, "primaryKeyValue");
      Assert.ArgumentNotNullOrEmpty(entityreference, "entityreference");

      collection = new NameValueCollection();
      collection[primaryKeyAttribute] = primaryKey;
      collection[primaryFieldAttribute] = primaryField;
      collection[primaryKeyValueAttribute] = primaryKeyValue;
      collection[entityReferenceAttribute] = entityreference;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LookupValue"/> class.
    /// </summary>
    /// <param name="collection">The collection.</param>
    private LookupValue(NameValueCollection collection)
    {
      this.collection = collection;
    }

    /// <summary>
    /// Parses the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static LookupValue Parse(string value)
    {
      return new LookupValue(NameValueCollectionUtil.GetNameValues(value));
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return NameValueCollectionUtil.GetString(collection);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the primary field.
    /// </summary>
    /// <value>The primary field.</value>
    public string PrimaryField
    {
      get
      {
        return collection[primaryFieldAttribute];
      }
    }

    /// <summary>
    /// Gets the primary key.
    /// </summary>
    /// <value>The primary key.</value>
    public string PrimaryKey
    {
      get
      {
        return collection[primaryKeyAttribute];
      }
    }

    /// <summary>
    /// Gets the primary key value.
    /// </summary>
    /// <value>The primary key value.</value>
    public string PrimaryKeyValue
    {
      get
      {
        return collection[primaryKeyValueAttribute];
      }
    }


    /// <summary>
    /// Gets the entity reference value.
    /// </summary>
    /// <value>The entity reference value.</value>
    public string EntityReference
    {
      get
      {
        return collection[entityReferenceAttribute];
      }
    }

    #endregion
  }
}