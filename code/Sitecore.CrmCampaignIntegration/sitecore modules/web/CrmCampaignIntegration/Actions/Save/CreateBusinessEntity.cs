using System;
using Sitecore.Diagnostics;
using Sitecore.Form.Core.Submit;

namespace Sitecore.CrmCampaignIntegration.Submit
{
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Services;

  /// <summary>
  /// Create business entity action 
  /// </summary>
  public abstract class CreateBusinessEntity : AuditSaveAction
  {
    protected EntityRepositoryBase EntityRepository { get; set; }

    public CreateBusinessEntity()
    {
      Error.AssertLicense("Sitecore.MSCRM", "CRM Save actions");
      this.EntityRepository = new EntityRepositoryFactory().GetRepository();
    }

    /// <summary>
    /// Gets the specified entity.
    /// </summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="attributeName">Name of the attribute.</param>
    /// <param name="attributeValue">The attribute value.</param>
    /// <param name="onlyActive"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    public virtual ICrmEntity Get(string entityName, string attributeName, string attributeValue, bool onlyActive, string[] columns)
    {
      Assert.ArgumentNotNullOrEmpty(entityName, "entityName");
      Assert.ArgumentNotNullOrEmpty(attributeName, "attributeName");
      Assert.ArgumentNotNullOrEmpty(attributeValue, "attributeValue");

      return this.EntityRepository.GetEntity(entityName, attributeName, attributeValue, onlyActive, columns);
    }

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public virtual Guid Create(ICrmEntity entity)
    {
      Assert.ArgumentNotNull(entity, "entity");
      return this.EntityRepository.Insert(entity);
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public virtual void Update(ICrmEntity entity)
    {
      Assert.ArgumentNotNull(entity, "entity");
      this.EntityRepository.Update(entity);
    }
  }
}