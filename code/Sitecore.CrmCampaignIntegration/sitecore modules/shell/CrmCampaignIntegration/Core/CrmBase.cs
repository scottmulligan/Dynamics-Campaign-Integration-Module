// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmBase.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using System;
  using System.Collections.Generic;
  using CRMSecurityProvider.Sources.PagingInfo;
  using Sitecore.CrmCampaignIntegration.Metadata;
  using Sitecore.CrmCampaignIntegration.Services;
  using Sitecore.Data;

  [Obsolete]
  /// <summary>
  /// Crm provider interface  
  /// </summary>
  public abstract class CrmBase
  {
    /// <summary>
    /// Gets the entity.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="fieldName">Name of the field.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public virtual BusinessEntity GetEntity(string type, string fieldName, string value, bool onlyActive, string[] columns)
    {
      return null;
    }

    /// <summary>
    /// Gets the meta data.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public virtual EntityMetadata GetMetaData(string name)
    {
      return new EntityMetadata();
    }

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public virtual Guid Create(BusinessEntity entity)
    {
      return ID.Null.Guid;
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public virtual void Update(BusinessEntity entity)
    {
    }

    /// <summary>
    /// Gets the entities count.
    /// </summary>
    /// <param name="entityName">The entity name.</param>
    /// <param name="expression">The filter expression.</param>
    /// <returns></returns>
    public virtual int GetEntitiesCount(string entityName, string primaryKey, FilterExpression expression)
    {
      return 0;
    }

    /// <summary>
    /// Gets the entities.
    /// </summary>
    /// <param name="entityName">The entity name.</param>
    /// <param name="pageInfo">The page info.</param>
    /// <param name="expression">The filter expression.</param>
    /// <param name="sortCriteria">The sort criteria.</param>
    /// <returns></returns>
    public virtual IEnumerable<BusinessEntity> GetEntities(
      string entityName, CrmPagingInfo pageInfo, FilterExpression expression, CrmOrderExpression[] sortCriteria)
    {
      return new List<BusinessEntity>();
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="guid">The GUID.</param>
    public virtual void Delete(string name, Guid guid)
    {
    }

    public virtual IEnumerable<EntityMetadata> GetAllEntitiesMetadata()
    {
      return new List<EntityMetadata>();
    }

    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    public virtual Response Execute(Request request)
    {
      return null;
    }
  }
}