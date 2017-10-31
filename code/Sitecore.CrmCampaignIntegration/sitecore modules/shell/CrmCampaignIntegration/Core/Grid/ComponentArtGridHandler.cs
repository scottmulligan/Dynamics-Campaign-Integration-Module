using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

using ComponentArt.Web.UI;

using Sitecore.Common;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Reflection;
using Sitecore.Text;
using Sitecore.Web.UI.Grids;
using Sitecore.Web.UI.HtmlControls;

namespace Sitecore.CrmCampaignIntegration.DataViewer
{
  public class ComponentArtGridHandler<TElement> : IDisposable
  {
    #region Fields

    private readonly Grid _grid;
    private readonly IGridSource<TElement> _source;
    private readonly Switcher<ElementCounter> swither;
    private string _previousFilter;
    private string _previousSort;

    #endregion

    #region Public Methods

    public ComponentArtGridHandler(Grid grid, IGridSource<TElement> source, bool dataBind)
    {
      this.swither = new Switcher<ElementCounter>(Switcher<ElementCounter>.CurrentValue ?? new ElementCounter());
      this._previousFilter = string.Empty;
      this._previousSort = string.Empty;
      Assert.ArgumentNotNull(grid, "grid");
      Assert.ArgumentNotNull(source, "source");
      this._grid = grid;
      this._source = source;
      this.InitializeGrid(dataBind);
    }

    public static void Manage(Grid grid, IGridSource<TElement> source, bool dataBind)
    {
      Assert.ArgumentNotNull(grid, "grid");
      Assert.ArgumentNotNull(source, "source");
      new ComponentArtGridHandler<TElement>(grid, source, dataBind);
    }

    public void Dispose()
    {
      this.swither.Dispose();
    }

    #endregion


    #region Private Methods

    private void ApplyCallbackUrlFix()
    {
      HttpContext current = HttpContext.Current;
      string url = current.Response.ApplyAppPathModifier(current.Request.RawUrl);
      string str2 = System.Convert.ToString(ReflectionUtil.CallMethod(this._grid, "GetSaneId", true, true));
      var str3 = new UrlString(url);
      str3.Add("Cart_" + str2 + "_Callback", "yes");
      this._grid.CallbackPrefix = str3.ToString();
    }

    private void ApplyDataSource()
    {
      bool manualPaging = this._grid.ManualPaging;
      int pageIndex = manualPaging ? this._grid.CurrentPageIndex : 0;
      int pageSize = manualPaging ? this._grid.PageSize : 0x7fffffff;
      this._grid.DataSource = this.GetDataSource(pageIndex, pageSize);
    }

    private void ApplyFilter()
    {
      if (this._grid.Filter != this._previousFilter)
      {
        List<GridFilter> filters = this.ParseFilters(this._grid.Filter);
        this._source.Filter(filters);
        this._previousFilter = this._grid.Filter;
      }
    }

    private void ApplySort()
    {
      if ((this._grid.Sort != this._previousSort) && !string.IsNullOrEmpty(this._grid.Sort))
      {
        string fieldName = StringUtil.GetPrefix(this._grid.Sort, ' ', this._grid.Sort);
        SortDirection direction = StringUtil.GetPostfix(this._grid.Sort, ' ', "ASC").Equals(
                                        "ASC", StringComparison.OrdinalIgnoreCase)
                                        ? SortDirection.Ascending
                                        : SortDirection.Descending;
        if (fieldName.Length != 0)
        {
          var list2 = new List<SortCriteria>();
          list2.Add(new SortCriteria(fieldName, direction));
          List<SortCriteria> sorting = list2;
          this._source.Sort(sorting);
          this._previousSort = this._grid.Sort;
        }
      }
    }

    private void ApplyUI()
    {
      if (this._grid.PageSize <= 0)
      {
        this._grid.PageSize = Settings.GridPageSize;
      }
      this._grid.ClientEvents.Load = new ClientEvent("scInitializeGrid");
      this._grid.FooterCssClass = this._grid.FooterCssClass + " scGridFooter";
      PageScriptManager.Current.ScriptFiles.Add(new ScriptFile("/sitecore/shell/Controls/ComponentArtGrid.js"));
    }

    private void DataBind()
    {
      this._grid.DataBind();
      if (this._grid.ManualPaging)
      {
        ElementCounter currentValue = Switcher<ElementCounter, ElementCounter>.CurrentValue;
        int entryCount = (currentValue != null) ? currentValue.Value : -1;
        if (entryCount < 0)
        {
          entryCount = this._source.GetEntryCount();
        }
        this._grid.RecordCount = entryCount;
      }
    }

    private IEnumerable<TElement> GetDataSource(int pageIndex, int pageSize)
    {
      return this._source.GetEntries(pageIndex, pageSize);
    }

    private void InitializeGrid(bool dataBind)
    {
      this._grid.NeedDataSource += new Grid.NeedDataSourceEventHandler(this.Grid_NeedDataSource);
      this._grid.NeedRebind += new Grid.NeedRebindEventHandler(this.Grid_NeedRebind);
      this._grid.PageIndexChanged += new Grid.PageIndexChangedEventHandler(this.Grid_PageIndexChanged);
      this._grid.SortCommand += new Grid.SortCommandEventHandler(this.Grid_Sort);
      this._grid.FilterCommand += new Grid.FilterCommandEventHandler(this.Grid_FilterCommand);
      this.InitializeItemBinding();
      this.ApplyFilter();
      this.ApplySort();

      if (dataBind)
      {
        this.DataBind();
      }
      this.ApplyUI();
      this.ApplyCallbackUrlFix();
    }

    private void InitializeItemBinding()
    {
      if (this._grid.Levels.Count != 0)
      {
        GridLevel level = this._grid.Levels[0];
        if (level.Columns["scGridID"] != null)
        {
          this._grid.ItemDataBound += new Grid.ItemDataBoundEventHandler(this.Grid_ItemDataBound);
        }
      }
    }

    private GridFilter ParseFilter(string filter)
    {
      Assert.ArgumentNotNullOrEmpty(filter, "filter");
      string[] strArray = filter.Split(new string[] { " LIKE " }, StringSplitOptions.None);
      if (strArray.Length == 2)
      {
        string fieldName = strArray[0];
        string criteria = StringUtil.RemovePrefix("'%", StringUtil.RemovePostfix("%'", strArray[1]));
        if ((fieldName.Length != 0) && (criteria.Length != 0))
        {
          return new GridFilter(fieldName, criteria, GridFilter.FilterOperator.Contains);
        }
      }
      return null;
    }

    private List<GridFilter> ParseFilters(string filters)
    {
      Assert.ArgumentNotNullOrEmpty(filters, "filters");
      var list = new List<GridFilter>();
      if (filters.Length != 0)
      {
        filters = StringUtil.RemovePrefix('(', filters);
        filters = StringUtil.RemovePostfix(')', filters);
        foreach (string str in filters.Split(new string[] { ") OR (" }, StringSplitOptions.None))
        {
          GridFilter item = this.ParseFilter(str);
          if (item != null)
          {
            list.Add(item);
          }
        }
      }
      return list;
    }

    private void Grid_FilterCommand(object sender, GridFilterCommandEventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      this._grid.Filter = e.FilterExpression;
    }

    private void Grid_ItemDataBound(object sender, GridItemDataBoundEventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      object obj2 = e.Item["Name"] ?? e.Item["DisplayName"];
      if (obj2 != null)
      {
        e.Item["scGridID"] = StringUtil.GetString(obj2).Replace(" ", "!").Replace(";", "-scsemicolon-");
      }
    }

    private void Grid_NeedDataSource(object sender, EventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      this.ApplyFilter();
      this.ApplySort();
      this.ApplyDataSource();
    }

    private void Grid_NeedRebind(object sender, EventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      this.DataBind();
    }

    private void Grid_PageIndexChanged(object sender, GridPageIndexChangedEventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      this._grid.CurrentPageIndex = e.NewIndex;
    }

    private void Grid_Sort(object sender, GridSortCommandEventArgs e)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(e, "e");
      this._grid.Sort = e.SortExpression;
    }

    #endregion

  }
}