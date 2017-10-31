namespace Sitecore.CrmCampaignIntegration.Submit
{
  using System;
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using Sitecore.Diagnostics;
  using Sitecore.Form.Core.Submit;

  /// <summary>
  /// Create business entity action 
  /// </summary>
  public abstract class CreateCrmEntityBase : AuditSaveAction
  {
    /// <summary>
    /// Gets or sets the entity repository.
    /// </summary>
    private readonly EntityRepositoryBase entityRepository;

    protected EntityRepositoryBase EntityRepository
    {
      get
      {
        return this.entityRepository;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCrmEntityBase"/> class.
    /// </summary>
    protected CreateCrmEntityBase()
      : this(new EntityRepositoryFactory().GetRepository())
    {
      Error.AssertLicense("Sitecore.MSCRM", "CRM Save actions");
    }

    protected CreateCrmEntityBase(EntityRepositoryBase entityRepository)
    {
      this.entityRepository = entityRepository;

    }

    /// <summary>
    /// Gets the specified entity name.
    /// </summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="attributeName">Name of the attribute.</param>
    /// <param name="attributeValue">The attribute value.</param>
    /// <param name="onlyActive">if set to <c>true</c> [only active].</param>
    /// <param name="columns">The columns.</param>
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