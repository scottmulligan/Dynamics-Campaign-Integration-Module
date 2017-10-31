// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LookupRecordsPage.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Lookup records dialog
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Shell.UI.Dialogs
{
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.Globalization;
  using System.Linq;
  using System.Web.UI.HtmlControls;
  using System.Web.UI.WebControls;
  using CRMSecurityProvider.Sources.Attribute.Metadata;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using ComponentArt.Web.UI;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using Sitecore.Controls;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.DataViewer;
  using Sitecore.CrmCampaignIntegrations.Core;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.Data;
  using Sitecore.Form.Web.UI.Controls;

  using Sitecore.Web;
  using Sitecore.Web.UI.Grids;
  using Sitecore.Web.UI.HtmlControls;
  using Sitecore.Web.UI.Sheer;
  using Literal = Sitecore.Web.UI.HtmlControls.Literal;

  /// <summary>
  /// Lookup records dialog
  /// </summary>
  public class LookupRecordsPage : DialogPage
  {
    public LookupRecordsPage()
    {
      this.EntityRepository = new EntityRepositoryFactory().GetRepository();
    }

    /// <summary>
    /// Gets or sets the entity repository.
    /// </summary>
    /// <value>
    /// The entity repository.
    /// </value>
    private EntityRepositoryBase EntityRepository { get; set; }

    #region Fields

    /// <summary>
    /// The entities
    /// </summary>
    protected Grid Entities;

    /// <summary>
    /// The selected record
    /// </summary>
    protected HtmlInputHidden SelectedRecord;

    /// <summary>
    /// The target types list
    /// </summary>
    protected DropDownList TargetTypesList;

    /// <summary>
    /// The grid container
    /// </summary>
    protected Border GridContainer;

    /// <summary>
    /// The grid callback
    /// </summary>
    protected CallBack GridCallback;

    /// <summary>
    /// The look for literal
    /// </summary>
    protected Literal LookForLiteral;

    /// <summary>
    /// The metadata
    /// </summary>
    private CrmEntityMetadata metadata;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the target entity.
    /// </summary>
    /// <value>The target.</value>
    public string Target
    {
      get
      {
        int i = 0;

        if (this.TargetTypesList.SelectedIndex > -1)
        {
          i = this.TargetTypesList.SelectedIndex;
        }

        if (!string.IsNullOrEmpty(Page.Request.Params["lookfor"]))
        {
          int.TryParse(Page.Request.Params["lookfor"], out i);
        }

        return this.Targets[i];
      }
    }

    /// <summary>
    /// Gets the targets entities.
    /// </summary>
    /// <value>The targets entities.</value>
    public string[] Targets
    {
      get
      {
        return WebUtil.GetQueryString("targets").Split('|');
      }
    }

    /// <summary>
    /// Gets the metadata.
    /// </summary>
    /// <value>The metadata.</value>
    protected CrmEntityMetadata Metadata
    {
      get
      {
        if (this.metadata == null)
        {
          if (Page.Session[this.SessionKey] != null && ((CrmEntityMetadata)Page.Session[this.SessionKey]).LogicalName == this.Target)
          {
            this.metadata = (CrmEntityMetadata)Page.Session[this.SessionKey];
          }
          else
          {
            try
            {
              this.metadata = this.EntityRepository.GetEntityMetadata(this.Target);
              this.Page.Session[this.SessionKey] = this.metadata;
            }
            catch (Exception)
            {
              return CrmEntityMetadata.Empty;
            }
          }
        }

        return this.metadata;
      }
    }

    /// <summary>
    /// Gets the session key.
    /// </summary>
    /// <value>
    /// The session key.
    /// </value>
    protected string SessionKey
    {
      get
      {
        return WebUtil.GetQueryString("skey");
      }
    }

    #endregion

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);

      this.Entities.ItemDataBound += this.OnItemDataBound;
      this.TargetTypesList.TextChanged += this.OnSelectedItemChanged;

      this.TargetTypesList.Items.AddItems(this.Targets);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Load"></see> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!Page.IsPostBack && !AjaxScriptManager.IsEvent)
      {
        this.RenderGrid(false);
        this.Localize();
      }

      this.Entities.SearchText = ResourceManager.Localize("SEARCH");
      this.Entities.GroupingNotificationText = ResourceManager.Localize("DRAG_COLUMN_TO_AREA_TO_GROUP_BY_IT");
    }

    /// <summary>
    /// Localizes this instance.
    /// </summary>
    protected virtual void Localize()
    {
      this.Header = ResourceManager.Localize("LOOK_UP_RECORDS");
      this.Text = ResourceManager.Localize("SELECT_RECORDS_YOU_WANT_AND_CLICK_OK");

      this.LookForLiteral.Text = ResourceManager.Localize("LOOK_FOR");
    }

    /// <summary>
    /// Handles a click on the OK button.
    /// </summary>
    /// <remarks>When the user clicks OK, the dialog is closed by calling
    /// the <see cref="M:Sitecore.Web.UI.Sheer.ClientResponse.CloseWindow">CloseWindow</see> method.</remarks>
    protected override void OK_Click()
    {
      var selectedValue = GridUtil.GetSelectedValue(this.Entities.ID);
      if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "null")
      {
        this.ResetMetadata();

        var value = new LookupValue(this.Metadata.PrimaryKey, this.Metadata.PrimaryField, selectedValue, this.Target);
        SheerResponse.SetDialogValue(value.ToString());

        base.OK_Click();
      }
      else
      {
        SheerResponse.Alert(ResourceManager.Localize("SELECT_RECORD"));
      }
    }

    /// <summary>
    /// Called when the selected item has changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void OnSelectedItemChanged(object sender, EventArgs e)
    {
      this.ResetMetadata();
      this.RenderGrid(true);

      this.Entities.CallbackPrefix = Core.DataViewer.LocationUtil.GetUpdatedUrl(this.Entities.CallbackPrefix, new NameValueCollection { { "lookfor", this.TargetTypesList.SelectedIndex.ToString(CultureInfo.InvariantCulture) } });
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Gets the column.
    /// </summary>
    /// <param name="attribute">the attribute.</param>
    private GridColumn GetColumn(ICrmAttributeMetadata attribute)
    {
      bool isString = attribute.AttributeType == CrmAttributeType.String;
      return new GridColumn
      {
        DataField = attribute.LogicalName,
        HeadingText = attribute.Title,
        AllowSorting = isString ? InheritBool.True : InheritBool.False,
        IsSearchable = isString
      };
    }

    /// <summary>
    /// Grids the render.
    /// </summary>
    /// <param name="update">if set to <c>true</c> [update].</param>
    private void RenderGrid(bool update)
    {
      this.InitColumns();

      var managedEntities = new CrmEntitiesSortedFilterable(this.Target, this.Metadata.PrimaryKey, this.Metadata.IsSupportActiveState());
      var gridSource = new GridSource<ICrmEntity>(managedEntities);
      Web.UI.Grids.ComponentArtGridHandler<ICrmEntity>.Manage(this.Entities, gridSource, (!this.Page.IsPostBack) || update);
    }

    /// <summary>
    /// Init the grid columns.
    /// </summary>
    private void InitColumns()
    {
      if (this.Metadata.Attributes != null)
      {
        this.Entities.Levels[0].Columns.Clear();
        GridColumnCollection gridColumns = this.Entities.Levels[0].Columns;

        gridColumns.Add(new GridColumn { DataField = this.Metadata.PrimaryKey, Visible = false });

        this.Entities.Levels[0].DataKeyField = this.Metadata.PrimaryKey;

        List<ICrmAttributeMetadata> list = this.Metadata.Attributes.Where(a => a.IsSelectable() || a.LogicalName == this.Metadata.PrimaryField).ToList();
        list.ForEach(a => gridColumns.Add(this.GetColumn(a)));

        gridColumns.MoveColumnTo("name", 1);
        gridColumns.MoveColumnTo("firstname", 1);
        gridColumns.MoveColumnTo("lastname", 2);
        gridColumns.MoveColumnTo("fullname", 1);
      }
    }

    /// <summary>
    /// Called when item is bounded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ComponentArt.Web.UI.GridItemDataBoundEventArgs"/> instance containing the event data.</param>
    private void OnItemDataBound(object sender, GridItemDataBoundEventArgs args)
    {
      var record = (ICrmEntity)args.DataItem;

      if (record != null)
      {
        foreach (var property in record.Attributes)
        {
          if (this.Entities.Levels[0].Columns[property.Key] != null)
          {
            var value = property.Value;
            args.Item[property.Key] = value != null ? value.GetStringifiedValue() : string.Empty;
          }
        }
      }
    }

    /// <summary>
    /// Resets the metadata.
    /// </summary>
    private void ResetMetadata()
    {
      this.metadata = null;
      Page.Session[this.SessionKey] = this.metadata;
    }

    #endregion
  }



  /// <summary>
  /// Grid source 
  /// </summary>
  /// <typeparam name="TElement">The type of the element.</typeparam>
  public class GridSource<TElement> : IGridSource<TElement>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GridSource&lt;TElement&gt;"/> class.
    /// </summary>
    /// <param name="entries">The entries.</param>
    public GridSource(ISortedFilterable<TElement> entries)
    {
      Entries = entries;
      Filters = new List<GridFilter>();
      SortCriteria = new List<SortCriteria>();
    }

    /// <summary>
    /// Filters the entries.
    /// </summary>
    /// <param name="filters">The filters.</param>
    public virtual void Filter(IList<GridFilter> filters)
    {
      Filters = new List<GridFilter>(filters);
    }

    /// <summary>
    /// Gets the entries.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <returns></returns>
    public virtual IEnumerable<TElement> GetEntries(int pageIndex, int pageSize)
    {
      return Entries.GetPage(new PageCriteria(pageIndex, pageSize), SortCriteria, Filters);
    }

    /// <summary>
    /// Gets the number of entries.
    /// </summary>
    /// <returns></returns>
    public virtual int GetEntryCount()
    {
      return Entries.GetCount(Filters);
    }

    /// <summary>
    /// Sorts using the specified field name.
    /// </summary>
    /// <param name="sorting">The sorting.</param>
    public virtual void Sort(IList<SortCriteria> sorting)
    {
      SortCriteria = sorting;
    }

    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    /// <value>The entries.</value>
    public ISortedFilterable<TElement> Entries { get; protected set; }

    /// <summary>
    /// Gets or sets the filters.
    /// </summary>
    /// <value>The filters.</value>
    public IList<GridFilter> Filters { get; protected set; }

    /// <summary>
    /// Gets or sets the sort criteria.
    /// </summary>
    /// <value>The sort criteria.</value>
    public IList<SortCriteria> SortCriteria { get; protected set; }
  }



}