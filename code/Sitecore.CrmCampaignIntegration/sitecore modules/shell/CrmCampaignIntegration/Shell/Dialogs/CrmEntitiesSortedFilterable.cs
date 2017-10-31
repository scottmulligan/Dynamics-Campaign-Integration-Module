// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmEntitiesSortedFilterable.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Defines the CrmEntitiesSortedFilterable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Shell.UI.Dialogs
{
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using Sitecore.Common;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.DataViewer;
  using Sitecore.Data;
  using Sitecore.Web.UI.Grids;

  /// <summary>
  /// The crm entities sorted filterable.
  /// </summary>
  public class CrmEntitiesSortedFilterable : ISortedFilterable<ICrmEntity>, IPageable<ICrmEntity>
  {
    /// <summary>
    /// The logical name
    /// </summary>
    private readonly string logicalName;

    /// <summary>
    /// The primary key
    /// </summary>
    private readonly string primaryKey;

    /// <summary>
    /// The is support active state
    /// </summary>
    private bool onlyActive;

    /// <summary>
    /// Initializes a new instance of the <see cref="CrmEntitiesSortedFilterable" /> class.
    /// </summary>
    /// <param name="logicalName">Name of the logical.</param>
    /// <param name="primaryKey">The primary key.</param>
    /// <param name="onlyActive">if set to <c>true</c> [is support active state].</param>
    public CrmEntitiesSortedFilterable(string logicalName, string primaryKey, bool onlyActive)
    {
      this.onlyActive = onlyActive;
      this.primaryKey = primaryKey;
      this.logicalName = logicalName;

      this.EntityRepository = new EntityRepositoryFactory().GetRepository();
    }

    /// <summary>
    /// Gets or sets the entity repository.
    /// </summary>
    /// <value>
    /// The entity repository.
    /// </value>
    private EntityRepositoryBase EntityRepository { get; set; }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<ICrmEntity> GetEnumerator()
    {
      return new List<ICrmEntity>().GetEnumerator();
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    /// <param name="filter">The filter.</param>
    public int GetCount(IList<GridFilter> filter)
    {
      return this.EntityRepository.GetEntitiesCount(this.logicalName, this.primaryKey,
        this.GetFiltersDictionary(filter), this.onlyActive);
    }

    /// <summary>
    /// Gets the page.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="sort">The sort.</param>
    /// <param name="filter">The filter.</param>
    public IEnumerable<ICrmEntity> GetPage(PageCriteria page, IList<SortCriteria> sort, IList<GridFilter> filter)
    {
      return this.EntityRepository.GetEntities(this.logicalName, page.ToPagingInfo(),
        sort.ToOrderExpressionArray(), GetFiltersDictionary(filter), this.onlyActive);
    }

    public IEnumerable<ICrmEntity> GetPage(int pageIndex, int pageSize)
    {
      return this.GetPage(new PageCriteria(pageIndex, pageSize), new List<SortCriteria>(), new List<GridFilter>());
    }

    public IEnumerable<ICrmEntity> GetAll()
    {
      yield break;
    }

    public int GetCount()
    {
      return this.GetCount(new List<GridFilter>());
    }

    private Dictionary<string, string> GetFiltersDictionary(IList<GridFilter> filter)
    {
      Dictionary<string, string> filteredFields = new Dictionary<string, string>();
      if (filter != null && filter.Count > 0)
      {
        foreach (var gridFilter in filter)
        {
          filteredFields.Add(gridFilter.FieldName, gridFilter.Criteria);
        }
      }
      return filteredFields;
    }

  }
}