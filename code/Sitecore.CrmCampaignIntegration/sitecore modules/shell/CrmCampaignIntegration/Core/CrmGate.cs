// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmGate.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   Crm gate provider
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Core
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Services.Protocols;
  using Sitecore.CrmCampaignIntegration.Core.Extension;
  using Sitecore.CrmCampaignIntegration.DataViewer;
  using Sitecore.CrmCampaignIntegration.Services;
  using Sitecore.CrmCampaignIntegrations.Core;
  using Sitecore.Data;
  using Sitecore.Diagnostics;

  using Sitecore.Form.Core.Utility;  
  using Sitecore.Reflection;
  using Sitecore.Web.UI.Grids;

  [Obsolete]
  public sealed class CrmGate
  {
    #region Methods

    #region Fields

    /// <summary>
    /// The _instance.
    /// </summary>
    private static CrmBase _instance;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes static members of the <see cref="CrmGate"/> class. 
    /// </summary>
    static CrmGate()
    {
      try
      {
        if (!string.IsNullOrEmpty(Sitecore.CrmCampaignIntegration.Configuration.Settings.CrmGateType))
        {
          ReflectionUtil.CreateObject(Sitecore.CrmCampaignIntegration.Configuration.Settings.CrmGateType);
        }
      }
      catch
      {
      }

      if (Instance == null)
      {
        Instance = new CustomCrm();
      }
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="CrmGate"/> class from being created.
    /// </summary>
    private CrmGate()
    {
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets the instance of the <see cref="CustomCrm"/>.
    /// </summary>
    /// <value>The instance.</value>
    public static CrmBase Instance
    {
      get
      {
        Error.AssertLicense("Sitecore.MSCRM", "CRM Save actions");
        return _instance;
      }

      private set
      {
        _instance = value;
      }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Gets the managed entity collection.
    /// </summary>
    /// <param name="entityName">
    /// The entity Name.
    /// </param>
    /// <param name="primaryKey">
    /// The primary Key.
    /// </param>
    /// <param name="supportState">
    /// The support State.
    /// </param>
    /// <returns>
    /// </returns>
    public static ISortedFilterable<DynamicEntity> GetEntities(string entityName, string primaryKey, bool supportState)
    {
      Assert.ArgumentNotNull(entityName, "entityName");

      var gate = new CrmSubGate(entityName, primaryKey, supportState);
      return new SortedFilterable<DynamicEntity>(gate.GetPage, gate.GetCount);
    }

    /// <summary>
    /// Sets the CRM instance.
    /// </summary>
    /// <param name="crmBase">
    /// The CRM.
    /// </param>
    public static void SetCrmInstance(CrmBase crmBase)
    {
      Assert.ArgumentNotNull(crmBase, "crmBase");
      Instance = crmBase;
    }

    #endregion

    #endregion

    #region Nested Types

    /// <summary>
    /// The crm sub gate.
    /// </summary>
    private class CrmSubGate
    {
      #region Fields

      /// <summary>
      /// The entity name.
      /// </summary>
      private readonly string entityName;

      /// <summary>
      /// The primary key.
      /// </summary>
      private readonly string primaryKey;

      /// <summary>
      /// The support state.
      /// </summary>
      private readonly bool supportState;

      #endregion

      #region Methods

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="CrmSubGate"/> class.
      /// </summary>
      /// <param name="entityName">
      /// The entity name.
      /// </param>
      /// <param name="primaryKey">
      /// The primary key.
      /// </param>
      /// <param name="supportState">
      /// The support state.
      /// </param>
      public CrmSubGate(string entityName, string primaryKey, bool supportState)
      {
        Assert.ArgumentNotNullOrEmpty(entityName, "entityName");
        Assert.ArgumentNotNullOrEmpty(primaryKey, "primaryKey");

        this.entityName = entityName;
        this.primaryKey = primaryKey;
        this.supportState = supportState;
      }

      #endregion

      #region Public methods

      /// <summary>
      /// The get count.
      /// </summary>
      /// <param name="arg">
      /// The arg.
      /// </param>
      /// <returns>
      /// The get count.
      /// </returns>
      public int GetCount(IList<GridFilter> arg)
      {
        try
        {
          return Instance.GetEntitiesCount(this.entityName, this.primaryKey, arg.ToFilterExpression(this.supportState));
        }
        catch (SoapException ex)
        {
          Log.Warn("Crm service:" + ex.GetFormatedMessage(), this);
        }

        return 0;
      }

      /// <summary>
      /// The get page.
      /// </summary>
      /// <param name="pageInfo">
      /// The page info.
      /// </param>
      /// <param name="sorting">
      /// The sorting.
      /// </param>
      /// <param name="filters">
      /// The filters.
      /// </param>
      /// <returns>
      /// </returns>
      public IEnumerable<DynamicEntity> GetPage(
        PageCriteria pageInfo, IList<SortCriteria> sorting, IList<GridFilter> filters)
      {
        try
        {
          IEnumerable<BusinessEntity> results = Instance.GetEntities(
            this.entityName, 
            pageInfo.ToPagingInfo(), 
            filters.ToFilterExpression(this.supportState), 
            sorting.ToOrderExpressionArray());
          return results.Cast<DynamicEntity>().ToList();
        }
        catch (SoapException ex)
        {
          Log.Warn("Crm service:" + ex.GetFormatedMessage(), this);
        }

        return new List<DynamicEntity>();
      }

      #endregion

      #endregion
    }

    #endregion
  }
}