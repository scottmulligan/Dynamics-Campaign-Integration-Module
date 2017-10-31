// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCrmEntityPage.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Create business entity editor
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
  using ComponentArt.Web.UI;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Attribute.Metadata;
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.CrmCampaignIntegration.Core.Crm;
  using Sitecore.Diagnostics;
  using Sitecore.Form.Core.Configuration;
  using Sitecore.Form.Core.ContentEditor.Data;
  using Sitecore.Form.Core.Utility;
  using Sitecore.Form.Web.UI.Controls;
  using Sitecore.Forms.Core.Data;
  using Sitecore.Forms.Shell.UI.Controls;
  using Sitecore.Forms.Shell.UI.Dialogs;
  using Sitecore.StringExtensions;
  using Sitecore.Text;
  using Sitecore.Web;
  using Sitecore.Web.UI.HtmlControls;
  using Sitecore.Web.UI.Sheer;
  using Sitecore.Web.UI.WebControls;
  using Checkbox = Sitecore.Web.UI.HtmlControls.Checkbox;
  using FormConstants = Sitecore.WFFM.Abstractions.Constants.Core.Constants;
  using ListItem = System.Web.UI.WebControls.ListItem;
  using Literal = Sitecore.Web.UI.HtmlControls.Literal;
  using TreeView = ComponentArt.Web.UI.TreeView;
  using WebUtil = Sitecore.Web.WebUtil;
  using Sitecore.CrmCampaignIntegration.Shell.UI.Controls;

  /// <summary>
  /// Create business entity editor
  /// </summary>
  public class CreateCrmEntityPage : EditorBase
  {
    #region Fields
    private bool? shouldCheckForm;

    protected TreeView FieldsTree;
    protected Border TreeViewBorder;
    protected Border SettingsBorder;
    protected GridPanel SettingsGrid;
    protected Border SettingsHolder;

    protected Literal AlwaysMarker;
    protected DropDownList FormFieldList;
    protected ControlledChecklist EditModeList;
    protected ComboBox ModeCombobox;

    protected DropDownList CrmValueList;

    protected GridPanel LookupBorder;
    protected Edit LookupValue;
    protected HtmlInputHidden ActiveField;
    protected Edit CrmValueEditbox;
    protected DropDownList AuditField;
    protected DropDownList UseValueFromList;
    protected DropDownList PreviousActionList;
    protected Checkbox UpdateFieldsIfContainValue;
    protected DropDownList EntityList;

    protected Literal Hint;
    protected Literal Description;
    protected Border AuditSettings;
    protected GridPanel AuditGrid;
    protected Border EditModeHolder;

    protected Literal CrmEntityLiteral;
    protected Toolbutton AddFieldsButton;
    protected Toolbutton DeleteFieldsButton;
    protected Literal FieldSettingsLiteral;
    protected Literal CompleteCrmFieldLiteral;
    protected Literal UseValueFromLiteral;
    protected Literal ValueLiteral;
    protected Toolbutton BrowseToolbutton;
    protected Groupbox AuditGroupbox;
    protected Literal SaveAuditInformationTo;
    protected Groupbox UpdateExistingRecordsGroupbox;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCrmEntityPage"/> class.
    /// </summary>
    public CreateCrmEntityPage()
    {
      Error.AssertLicense("Sitecore.MSCRM", "CRM Save actions");
      this.EntityRepository = new EntityRepositoryFactory().GetRepository();
    }

    #region Propeties

    /// <summary>
    /// Gets or sets the entity repository.
    /// </summary>
    /// <value>
    /// The entity repository.
    /// </value>
    private EntityRepositoryBase EntityRepository { get; set; }

    /// <summary>
    /// Gets the allowed field types.
    /// </summary>
    /// <value>
    /// The allowed field types.
    /// </value>
    public string AllowedFieldTypes
    {
      get
      {
        return WebUtil.GetQueryString("AllowedFieldTypes", "*");
      }
    }

    /// <summary>
    /// Gets the name of the entity.
    /// </summary>
    /// <value>
    /// The name of the entity.
    /// </value>
    /// <exception cref="System.NotSupportedException"></exception>
    [NotNull]
    protected virtual string EntityName
    {
      get
      {
        var entityName = WebUtil.GetQueryString("entityname");

        if (!string.IsNullOrEmpty(entityName))
        {
          return entityName;
        }

        if (this.EntityList != null)
        {
          return this.EntityList.SelectedValue;
        }

        throw new NotSupportedException();
      }
    }

    /// <summary>
    /// Gets the metadata key.
    /// </summary>
    /// <value>
    /// The metadata key.
    /// </value>
    protected string MetadataKey
    {
      get
      {
        if (!string.IsNullOrEmpty((string)this.ViewState["metadatkey"]))
        {
          return (string)this.ViewState["metadatkey"];
        }

        var metadataKey = Data.ID.NewID.ToString();
        this.ViewState["metadatkey"] = metadataKey;

        return metadataKey;
      }
    }

    /// <summary>
    /// Gets the crm metadata.
    /// </summary>
    /// <value>The metadata.</value>
    /// <exception cref="Exception"><c>Exception</c>.</exception>
    protected CrmEntityMetadata Metadata
    {
      get
      {
        if (this.Page.Session[this.MetadataKey] != null)
        {
          return (CrmEntityMetadata)this.Page.Session[this.MetadataKey];
        }

        var metadata = this.EntityRepository.GetEntityMetadata(this.EntityName);
        this.Page.Session[this.MetadataKey] = metadata;
        return metadata;
      }
    }

    /// <summary>
    /// Gets the info.
    /// </summary>
    /// <value>
    /// The info.
    /// </value>
    protected XCrmEntry Info
    {
      get
      {
        var value = this.ViewState["xcrmentry"];
        if (value == null)
        {
          this.ViewState["xcrmentry"] = XCrmEntry.Parse(string.Empty);
        }

        return (XCrmEntry)this.ViewState["xcrmentry"];
      }

      private set
      {
        this.ViewState["xcrmentry"] = value;
      }
    }

    /// <summary>
    /// Gets the required attributes.
    /// </summary>
    /// <value>
    /// The required attributes.
    /// </value>
    protected IEnumerable<ICrmAttributeMetadata> RequiredAttributes
    {
      get
      {
        if (this.Metadata != null && this.Metadata.Attributes != null && this.Metadata.Attributes.Length > 0)
        {
          return this.Metadata.Attributes.Where(a => a.IsRequired(this.ShouldCheckForm) || (!string.IsNullOrEmpty(this.PrimaryField) && a.LogicalName == this.PrimaryField));
        }

        return new List<ICrmAttributeMetadata>();
      }
    }

    /// <summary>
    /// Gets the additional attributes.
    /// </summary>
    /// <value>
    /// The additional attributes.
    /// </value>
    protected IEnumerable<ICrmAttributeMetadata> AdditionalAttributes
    {
      get
      {
        if (this.Metadata != null && this.Metadata.Attributes != null && this.Metadata.Attributes.Length > 0)
        {
          return this.Metadata.Attributes.Where(a => a.IsAdditional(this.ShouldCheckForm) && a.LogicalName != this.PrimaryField);
        }

        return new List<ICrmAttributeMetadata>();
      }
    }

    /// <summary>
    /// Gets the primary field.
    /// </summary>
    /// <value>
    /// The primary field.
    /// </value>
    protected string PrimaryField
    {
      get
      {
        if (this.Action != null)
        {
          string primaryField = this.Action[FieldsIds.CrmPrimaryField];
          if (!string.IsNullOrEmpty(primaryField))
          {
            return primaryField;
          }
        }

        return this.Metadata.PrimaryField;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [should check form].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [should check form]; otherwise, <c>false</c>.
    /// </value>
    private bool ShouldCheckForm
    {
      get
      {
        if (this.shouldCheckForm == null)
        {
          this.shouldCheckForm = this.Metadata.Attributes.Any(a => a.IsValidForAdvancedFind);
        }

        return (bool)this.shouldCheckForm;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the Init event
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);

      this.Page.EnableEventValidation = false;

      this.InitEditModeList();

      this.InitUseValueFromList();

      if (this.Info.IsEmpty && string.IsNullOrEmpty(this.Page.Request.Form[this.ActiveField.Name]))
      {
        this.InitFieldsList();

        this.InitPreviousActionList();

        this.FillEntityList();

        this.Info = XCrmEntry.Parse(this.FixXmlFromCrm(this.GetValueByKey("CrmEntityInfo", string.Empty)));

        if (this.EntityList != null)
        {
          this.EntityList.Select(this.Info.EntityName);
        }

        if (this.UpdateFieldsIfContainValue != null)
        {
          this.UpdateFieldsIfContainValue.Checked = this.Info.OverwriteNotEmptyField;
        }

        this.FillAudit(this.AuditField, this.Info.Audit);

        this.SaveInfo(null);
        this.Info.Merge(this.Metadata);

        if (this.UpdateFieldsIfContainValue != null)
        {
          this.UpdateFieldsIfContainValue.Checked = this.Info.OverwriteNotEmptyField;
        }
      }
      else
      {
        this.SettingsBorder.Visible = false;
      }

      this.FieldsTree.LoadFromCrmEntry(this.Info);
      this.FieldsTree.ClientEvents.NodeSelect = new ClientEvent("FieldsTree_onNodeSelect");
    }

        protected virtual string FixXmlFromCrm(string xml)
        {
            return xml;
        }

    /// <summary>
    /// Handles the Load event
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.HideSettings();

      if (this.PreviousActionList.Items.Count == 0)
      {
        this.UseValueFromList.Items.Disable(3);
      }

      if (!this.Page.IsPostBack)
      {
        this.InitRequredAttributes();

        this.FieldsTree.LoadFromCrmEntry(this.Info);

        this.InitSettings();

        this.BuildUpClientDictionary();
      }
    }

    /// <summary>
    /// Localizes this instance.
    /// </summary>
    protected override void Localize()
    {
      base.Localize();

      if (this.CrmEntityLiteral != null)
      {
        this.CrmEntityLiteral.Text = ResourceManager.Localize("CRM_ENTITY");
      }

      this.AddFieldsButton.Header = ResourceManager.Localize("ADD");
      this.AddFieldsButton.ToolTip = ResourceManager.Localize("ADD_FIELDS");

      this.DeleteFieldsButton.Header = ResourceManager.Localize("DELETE");
      this.DeleteFieldsButton.ToolTip = ResourceManager.Localize("DELETE_SELECTED_FIELDS");

      this.FieldSettingsLiteral.Text = ResourceManager.Localize("FIELDS_SETTINGS");
      this.CompleteCrmFieldLiteral.Text = ResourceManager.Localize("COMPLETE_CRM_FIELD");

      this.UseValueFromLiteral.Text = ResourceManager.Localize("USE_VALUE_FROM");
      this.ValueLiteral.Text = ResourceManager.Localize("VALUE");
      this.BrowseToolbutton.ToolTip = ResourceManager.Localize("BROWSE");
      this.Description.Text = ResourceManager.Localize("DESCRIPTION");

      if (this.AuditGroupbox != null)
      {
        this.AuditGroupbox.Header = ResourceManager.Localize("AUDIT");
      }

      if (this.UpdateExistingRecordsGroupbox != null)
      {
        this.UpdateExistingRecordsGroupbox.Header = ResourceManager.Localize("UPDATE_EXISTING_RECORDS");
      }

      if (this.UpdateFieldsIfContainValue != null)
      {
        this.UpdateFieldsIfContainValue.Header = ResourceManager.Localize("OVERWRITE_CRM_FIELDS_IF_THEY_CONTAIN_VALUE");
      }

      this.SaveAuditInformationTo.Text = ResourceManager.Localize("SAVE_AUDIT_INFORMATION_TO");
      this.AlwaysMarker.Text = ResourceManager.Localize("ALWAYS");

      this.Header = Core.Configuration.Translate.Text(this.Header);
      this.Text = Core.Configuration.Translate.Text(this.Text);
    }

    /// <summary>
    /// Builds up client dictionary.
    /// </summary>
    protected virtual void BuildUpClientDictionary()
    {
      this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "scWfmNeverLabel", "var sc = new Object();sc.dictionary = [];sc.dictionary['Never'] = \"{0}\";".FormatWith(ResourceManager.Localize("NEVER")), true);
    }

    /// <summary>
    /// Inits the settings.
    /// </summary>
    protected void InitSettings()
    {
      this.SelectDefaultNode();

      this.UpdateSettings(this.FieldsTree.SelectedNode != null ? this.FieldsTree.SelectedNode.Value : string.Empty, false);

      this.SaveInfo(this.ActiveField.Value);
    }

    /// <summary>
    /// Updates the settings.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="updateUI">if set to <c>true</c> [update UI].</param>
    protected void UpdateSettings(string name, bool updateUI)
    {
      var field = this.Info[name];
      if (field != null)
      {
        this.SetAllowedUseValueTypesForField(field);

        this.FillCurrentSettingsValues(field);

        this.SetAllowedEditMode(field);

        this.ShowSettings(field);

        this.UpdateDescription(field);
      }

      if (updateUI)
      {
        AjaxScriptManager.SetInnerHtml(this.SettingsBorder.ID, this.SettingsHolder);
        AjaxScriptManager.Current.Eval("$('{0}_Input').readOnly = true".FormatWith(this.ModeCombobox.ClientID));
      }
    }

    /// <summary>
    /// Fills the edit mode.
    /// </summary>
    /// <param name="listBox">The list box.</param>
    /// <param name="defaultValue">The default value.</param>          
    /// <param name="allowedTypes">The allowed types.</param>
    protected void FillEditMode(DropDownList listBox, string defaultValue, string allowedTypes)
    {
      listBox.Items.Clear();

      FormItem item = new FormItem(this.CurrentDatabase.GetItem(this.CurrentID));
      var listItem = new ListItem(ResourceManager.Localize("ALWAYS"), "Always");
      if (string.Compare("Always", defaultValue, StringComparison.OrdinalIgnoreCase) == 0)
      {
        listItem.Selected = true;
      }

      listBox.Items.Add(listItem);



      var prop = item.GetType().GetProperty("FieldItems") ?? item.GetType().GetProperty("Fields");
      var fields = prop.GetValue(item) as FieldItem[];

      Assert.IsNotNull(fields, "fields");
      foreach (var property in fields)
      {
        if (string.IsNullOrEmpty(allowedTypes) || allowedTypes.Contains(property.TypeID.ToString()))
        {
          listItem = new ListItem(ResourceManager.Localize("WHEN_IS_SELECTED", property.Name), property.ID.ToString());

          if (string.Compare(listItem.Value, defaultValue, StringComparison.OrdinalIgnoreCase) == 0)
          {
            listItem.Selected = true;
          }

          listBox.Items.Add(listItem);
        }
      }
    }

    /// <summary>
    /// Fills the entity list.
    /// </summary>
    protected virtual void FillEntityList()
    {
      if (this.EntityList != null)
      {
        var allentities = this.EntityRepository.GetAllEntitiesMetadata();
        var entities = allentities.Where(e => (e.IsCustomizable || e.IsCustomEntity) && !e.LogicalName.EndsWith("account") &&
          !e.LogicalName.EndsWith("contact") && !e.LogicalName.EndsWith("productoption") && !e.LogicalName.EndsWith("roleprivileges"));
        foreach (var entity in entities.OrderBy(e => e.Title))
        {
          this.EntityList.Items.AddItem(entity.Title, entity.LogicalName);
        }
      }
    }

    /// <summary>
    /// Fills the audit list.
    /// </summary>
    /// <param name="auditList">The audit list.</param>
    /// <param name="defaultValue">The default value.</param>
    protected void FillAudit(DropDownList auditList, string defaultValue)
    {
      auditList.Items.Clear();

      var empty = new ListItem(ResourceManager.Localize("DO_NOT_SAVE"), "NoAudit");
      auditList.Items.Add(empty);

      foreach (var field in this.Metadata.AuditAllowedFields())
      {
        var item = new ListItem(field.Title, field.LogicalName);
        if (defaultValue == field.LogicalName)
        {
          item.Selected = true;
        }

        auditList.Items.Add(item);
      }
    }

    /// <summary>
    /// Runs the field editor.
    /// </summary>
    protected void OnRunFieldEditor()
    {
      var args = ContinuationManager.Current.CurrentArgs as ClientPipelineArgs;
      Assert.IsNotNull(args, "args");
      if (args.IsPostBack)
      {
        if (args.HasResult)
        {
          string result = args.Result;
          if (result == "-")
          {
            return;
          }

          this.SaveInfo(this.ActiveField.Value);
          this.Info.AddRange(this.Metadata.GetAttributesByNames(result.Split('|')));
          this.FieldsTree.LoadFromCrmEntry(this.Info);

          var field = this.Info.Fields.Where(f => !f.Disabled).Last();
          if (field != null)
          {
            this.ActiveField.Value = field.Name;
            TreeViewExtensions.Select(this.FieldsTree, field.Name);
          }

          this.UpdateSettings(this.ActiveField.Value, true);
          this.SaveInfo(this.ActiveField.Value);
          AjaxScriptManager.Current.SetInnerHtml(this.TreeViewBorder.ID, this.FieldsTree);
        }
      }
      else
      {
        this.SaveInfo(this.ActiveField.Value);
        var urlString = new UrlString(UIUtil.GetUri("control:Forms.SelectFields"));

        var handle = new UrlHandle();

        handle["values"] = ParametersUtil.NameValueCollectionToXml(this.GetListOfAvailableFields(), true);
        handle["title"] = ResourceManager.Localize("SELECT_FIELDS");
        handle["text"] = ResourceManager.Localize("SELECT_FIELDS_DETAILED");
        handle.Add(urlString);

        SheerResponse.ShowModalDialog(
                                      urlString.ToString(),
                                      string.Empty,
                                      string.Empty,
                                      ResourceManager.Localize("SELECT_FIELDS_FOR_EXPORT"),
                                      true);

        args.WaitForPostBack();
      }
    }

    /// <summary>
    /// Refreshes the content of the main.
    /// </summary>
    protected void RefreshMainContent()
    {
      this.SaveInfo(this.ActiveField.Value);
      this.Info.Merge(this.Metadata);

      this.InitRequredAttributes();
      this.HideSettings();

      this.FieldsTree.LoadFromCrmEntry(this.Info);

      this.ActiveField.Value = string.Empty;
      XCrmField field = this.Info.Fields.Where(f => !f.Disabled).FirstOrDefault();
      if (field != null)
      {
        this.ActiveField.Value = field.Name;
        TreeViewExtensions.Select(this.FieldsTree, field.Name);
      }

      this.UpdateSettings(this.ActiveField.Value, true);
      this.SaveInfo(this.ActiveField.Value);
      AjaxScriptManager.Current.SetInnerHtml(this.TreeViewBorder.ID, this.FieldsTree);
    }

    /// <summary>
    /// Hides the settings.
    /// </summary>
    protected void HideSettings()
    {
      this.LookupBorder.Style["display"] = "none";
      this.CrmValueList.Visible = false;
      this.AlwaysMarker.Visible = false;
      this.EditModeHolder.Style["display"] = "none";
      this.CrmValueEditbox.Visible = false;
      this.FormFieldList.Visible = false;
      this.Description.Visible = false;
      this.PreviousActionList.Visible = false;
    }

    /// <summary>
    /// Updates the description.
    /// </summary>
    /// <param name="field">The field.</param>
    protected void UpdateDescription(XCrmField field)
    {
      var attribute = this.Metadata.GetAttribute(field.Name);
      if (attribute != null)
      {
        var desc = attribute.Description;
        if (!string.IsNullOrEmpty(desc))
        {
          this.Hint.Text = desc;
          this.Description.Visible = true;

          return;
        }
      }

      this.Hint.Text = string.Empty;
    }

    /// <summary>
    /// Handles the RemoveSelectedNode event
    /// </summary>
    protected void OnRemoveSelectedNode()
    {
      if (!string.IsNullOrEmpty(this.ActiveField.Value))
      {
        if (!this.Info[this.ActiveField.Value].Required)
        {
          this.Info.Remove(this.ActiveField.Value);
          this.FieldsTree.LoadFromCrmEntry(this.Info);

          this.SaveInfo(this.ActiveField.Value);

          this.ActiveField.Value = string.Empty;
          this.InitSettings();

          AjaxScriptManager.Current.SetInnerHtml(this.TreeViewBorder.ID, this.FieldsTree);
          AjaxScriptManager.Current.SetInnerHtml(this.SettingsBorder.ID, this.SettingsHolder);
          AjaxScriptManager.Current.Eval("$('{0}_Input').readOnly = true".FormatWith(this.ModeCombobox.ClientID));
        }
      }
    }

    /// <summary>
    /// Called when the entity type has changed.
    /// </summary>
    protected void OnEntityTypeChanged()
    {
      this.ClearMetadata();
      this.FillAudit(this.AuditField, this.AuditField.SelectedValue);
      AjaxScriptManager.SetInnerHtml(this.AuditSettings.ID, this.AuditGrid);

      this.RefreshMainContent();
    }

    /// <summary>
    /// Handles the TreeViewNodeSelected event
    /// </summary>
    /// <param name="name">The name of the node.</param>
    protected void OnTreeViewNodeSelected(string name)
    {
      this.SaveInfo(this.ActiveField.Value);

      this.ActiveField.Value = name;

      this.UpdateSettings(name, true);

      this.SaveInfo(this.ActiveField.Value);
    }

    /// <summary>
    /// Saves the customized info.
    /// </summary>
    /// <param name="name">The name of field.</param>
    protected void SaveInfo(string name)
    {
      this.SaveAudit();

      this.Info.EntityName = this.EntityName;
      this.Info.PrimaryFieldName = this.PrimaryField;
      this.Info.PrimaryKey = this.Metadata.PrimaryKey;
      this.Info.SupportStateCode = this.Metadata.GetAttribute("statecode") != null;

      if (this.UpdateFieldsIfContainValue != null)
      {
        this.Info.OverwriteNotEmptyField = this.UpdateFieldsIfContainValue.Checked;
      }

      var field = this.Info[name];
      if (field != null)
      {
        field.UseValueType = this.UseValueFromList.SelectedIndex;
        field.EditMode = string.Join("|", this.EditModeList.GetManagedSelectedValues().ToArray());
        field.FormValueFrom = this.FormFieldList.GetEnabledSelectedValue();

        if (this.UseValueFromList.SelectedIndex == 3)
        {
          field.CrmValue = this.PreviousActionList.SelectedValue;
          return;
        }

        if (field.IsPicklist || field.IsState || field.IsStatus)
        {
          field.CrmValue = this.CrmValueList.SelectedValue;
          return;
        }

        if (!field.IsLookup)
        {
          field.CrmValue = this.Page.Request.Form[this.CrmValueEditbox.ID];
        }
      }
    }

    /// <summary>
    /// Saves the audit.
    /// </summary>
    protected void SaveAudit()
    {
      this.Info.Audit = this.AuditField.SelectedValue;

      var attribute = this.Metadata.GetAttribute(this.Info.Audit);
      if (attribute != null)
      {
        this.Info.AuditAttributeType = attribute.AttributeType;
      }
      else
      {
        this.Info.AuditAttributeType = CrmAttributeType.Empty;
      }
    }

    /// <summary>
    /// Handles the RunPicklistBrowser event
    /// </summary>
    protected void OnRunPicklistBrowser()
    {
      var args = ContinuationManager.Current.CurrentArgs as ClientPipelineArgs;
      var field = this.Info[this.ActiveField.Value];

      Assert.IsNotNull(args, "args");
      if (args.IsPostBack)
      {
        if (args.HasResult)
        {
          string result = args.Result;
          if (result == "-")
          {
            return;
          }

          var value = CrmCampaignIntegrations.Core.LookupValue.Parse(result);

          field.LookupValue = value;

          this.UpdateSettings(this.ActiveField.Value, true);
        }
      }
      else
      {
        var urlString = new UrlString("/sitecore modules/shell/Web Forms for Marketers/Shell/OpenXamlModalDialog/OpenXamlModalDialog.aspx");

        urlString.Add("type", "xaml");
        urlString.Add("control", "Sitecore.CrmCampaignIntegration.Shell.UI.Dialogs.LookupRecords");

        var attribute = (ICrmLookupAttributeMetadata)this.Metadata.GetAttribute(this.ActiveField.Value);
        urlString.Append("field", this.ActiveField.Value);

        var value = attribute.Targets.ToList().IndexOf(field.EntityReference);
        urlString.Append("targets", string.Join("|", attribute.Targets));
        urlString.Append("skey", Data.ID.NewID.ToString());
        urlString.Append("w", "620px");
        urlString.Append("h", "800px");

        ModalDialog.Show(urlString);

        args.WaitForPostBack();
      }
    }

    /// <summary>
    /// Handles a click on the OK button.
    /// </summary>
    /// <remarks>When the user clicks OK, the dialog is closed by calling
    /// the <see cref="M:Sitecore.Web.UI.Sheer.ClientResponse.CloseWindow">CloseWindow</see> method.</remarks>
    protected override void OK_Click()
    {
      foreach (var field in this.Info)
      {
        if (!field.Disabled && field.Required &&
           ((field.IsRestricted && string.IsNullOrEmpty(field.CrmValue)) ||
             field.UseValueType == 0 && string.IsNullOrEmpty(field.FormValueFrom)))
        {
          AjaxScriptManager.Alert(ResourceManager.Localize("SELECT_VALUE_FOR_REQUIRED"));
          return;
        }
      }

      this.SaveInfo(this.ActiveField.Value);

      this.Info.Remove(f => f.Disabled);

      if (this.EntityList != null)
      {
        this.SetValue(FormConstants.ActionSubTitle, this.EntityList.SelectedItem.Text);
      }

      this.SetLongValue("CrmEntityInfo", this.Info.ToString());

      base.OK_Click();
    }

    /// <summary>
    /// <summary>
    /// Handles the UseValueFromChanged event
    /// </summary>
    /// </summary>
    protected void OnUseValueFromChanged()
    {
      this.SaveInfo(this.ActiveField.Value);
      this.UpdateSettings(this.ActiveField.Value, true);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Selects the default node.
    /// </summary>
    private void SelectDefaultNode()
    {
      if (this.FieldsTree.SelectedNode == null && this.FieldsTree.Nodes[0].Nodes.Count > 0)
      {
        this.FieldsTree.SelectedNode = this.FieldsTree.Nodes[0].Nodes[0];
        this.ActiveField.Value = this.FieldsTree.SelectedNode.Value;
      }
    }

    /// <summary>
    /// Inits the requred attributes.
    /// </summary>
    private void InitRequredAttributes()
    {
      this.Info.AddRange(this.RequiredAttributes);

      foreach (var info in this.Info)
      {
        if (info.UseValueType == 0 && string.IsNullOrEmpty(info.FormValueFrom))
        {
          var item = this.FormFieldList.Items.FindByText(info.Title) ?? this.FormFieldList.Items.FirstOrDefault(i => true);
          if (item != null)
          {
            info.FormValueFrom = item.Value;
          }
        }
      }

      var field = this.Info[this.PrimaryField];
      if (field != null)
      {
        field.Required = true;
      }
    }

    /// <summary>
    /// Shows the settings.
    /// </summary>
    /// <param name="field">The field.</param>
    private void ShowSettings(XCrmField field)
    {
      switch (this.UseValueFromList.SelectedIndex)
      {
        case 0:
          this.FormFieldList.Visible = true;
          break;
        case 1:
          if (field.IsPicklist)
          {
            this.FillPicklist(field);
          }
          else if (field.IsLookup)
          {
            this.ShowLookup(field);
          }
          else if (field.IsState)
          {
            this.ShowStates(field);
          }
          else if (field.IsStatus)
          {
            this.ShowStatus(field);
          }
          break;
        case 2:
          this.CrmValueEditbox.Visible = true;
          break;
        case 3:
          this.PreviousActionList.Visible = true;
          this.PreviousActionList.Select(field.CrmValue);
          break;
      }
    }

    /// <summary>
    /// Sets the allowed edit mode.
    /// </summary>
    /// <param name="field">The field.</param>
    private void SetAllowedEditMode(XCrmField field)
    {
      if (field.Required)
      {
        this.AlwaysMarker.Visible = true;
      }
      else
      {
        this.EditModeHolder.Style["display"] = "block";
      }
    }

    /// <summary>
    /// Fills the current settings values.
    /// </summary>
    /// <param name="field">The field.</param>
    private void FillCurrentSettingsValues(XCrmField field)
    {
      this.EditModeList.ClearSelection();
      this.EditModeList.SelectRange(field.EditMode);

      this.ModeCombobox.Text = this.EditModeList.SelectedTitle;

      this.FormFieldList.Select(string.IsNullOrEmpty(field.FormValueFrom) ? field.Title : field.FormValueFrom);
      this.UseValueFromList.Select(field.UseValueType.ToString(CultureInfo.InvariantCulture));
      this.LookupValue.Value = string.Empty;
      this.CrmValueEditbox.Value = field.CrmValue;
    }

    /// <summary>
    /// Sets the allowed use value types for field.
    /// </summary>
    /// <param name="field">The field.</param>
    private void SetAllowedUseValueTypesForField(XCrmField field)
    {
      if (field.IsRestricted)
      {
        this.EnableUseCrmValue();
      }
      else
      {
        this.EnableUseManualValue();
      }
    }

    /// <summary>
    /// Enables the use manual value.
    /// </summary>
    private void EnableUseManualValue()
    {
      this.UseValueFromList.Items.Disable(1);
      this.UseValueFromList.Items.Enable(2);
    }

    /// <summary>
    /// Enables the use CRM value.
    /// </summary>
    private void EnableUseCrmValue()
    {
      this.UseValueFromList.Items.Disable(2);
      this.UseValueFromList.Items.Enable(1);
    }

    /// <summary>
    /// Shows the lookup.
    /// </summary>
    /// <param name="field">The field.</param>
    private void ShowLookup(XCrmField field)
    {
      this.LookupBorder.Style["display"] = "block";

      if (field.LookupValue != null)
      {
        try
        {
          ICrmEntity entity = this.EntityRepository.GetEntity(field.EntityReference, field.LookupValue.PrimaryKey, field.CrmValue, false, null);
          if (entity != null)
          {
            this.LookupValue.Value = entity.Attributes[field.LookupValue.PrimaryField].GetStringifiedValue();
          }
        }
        catch { }
      }
    }

    private void ShowStates(XCrmField field)
    {
      this.CrmValueList.Visible = true;
      this.CrmValueList.Items.Clear();

      var attribute = this.Metadata.GetAttribute(field.Name) as ICrmStateAttributeMetadata;
      if (attribute == null)
      {
        return;
      }

      foreach (var option in attribute.Options)
      {
        var listItem = new ListItem { Text = option.Value, Value = option.Key.ToString(CultureInfo.InvariantCulture) };
        listItem.Selected = listItem.Value == field.CrmValue;
        this.CrmValueList.Items.Add(listItem);
      }
    }

    /// <summary>
    /// Shows the status.
    /// </summary>
    /// <param name="field">The field.</param>
    private void ShowStatus(XCrmField field)
    {
      this.CrmValueList.Visible = true;
      this.CrmValueList.Items.Clear();

      var attribute = this.Metadata.GetAttribute(field.Name) as ICrmStatusAttributeMetadata;
      if (attribute == null)
      {
        return;
      }

      foreach (var option in attribute.Options)
      {
        var listItem = new ListItem
        {
          Text = option.Value,
          Value = option.Key.ToString(CultureInfo.InvariantCulture)
        };

        listItem.Selected = listItem.Value == field.CrmValue;
        this.CrmValueList.Items.Add(listItem);
      }
    }

    /// <summary>
    /// Fills the picklist.
    /// </summary>
    /// <param name="field">The field.</param>
    private void FillPicklist(XCrmField field)
    {
      this.CrmValueList.Visible = true;
      this.CrmValueList.Items.Clear();

      var attribute = this.Metadata.GetAttribute(field.Name) as ICrmPicklistAttributeMetadata;
      if (attribute == null)
      {
        return;
      }

      foreach (var option in attribute.Options)
      {
        var listItem = new ListItem { Text = option.Value, Value = option.Key.ToString(CultureInfo.InvariantCulture) };
        listItem.Selected = listItem.Value == field.CrmValue;
        this.CrmValueList.Items.Add(listItem);
      }

    }

    /// <summary>
    /// Gets the list of available fields.
    /// </summary>
    private NameValueCollection GetListOfAvailableFields()
    {
      var collection = new NameValueCollection();

      var attributes = this.AdditionalAttributes.Where(a => !this.Info.Contains(a.LogicalName));
      var recommended = attributes.Where(a => a.RequiredLevel == CrmAttributeRequiredLevel.Recommended).OrderBy(a => a.DisplayName).ToList();

      var notRecomended = attributes.Where(a => a.RequiredLevel != CrmAttributeRequiredLevel.Recommended).OrderBy(a => a.DisplayName).ToList();

      if (recommended.Count > 0 && notRecomended.Count > 0)
      {
        collection.Add(FormConstants.OptGroupPrefix + CrmAttributeRequiredLevel.Recommended, ResourceManager.Localize("RECOMMENDED_FIEDLS"));
      }

      recommended.ForEach(a => collection.Add(a.LogicalName, a.DisplayName ?? a.LogicalName));

      if (recommended.Count > 0 && notRecomended.Count > 0)
      {
        collection.Add(FormConstants.OptGroupPrefix + "Available", ResourceManager.Localize("OTHER_AVAILABLE_FIELDS"));
      }

      notRecomended.ForEach(a => collection.Add(a.LogicalName, a.DisplayName ?? a.LogicalName));

      return collection;
    }

    /// <summary>
    /// Inits the fields list.
    /// </summary>
    private void InitFieldsList()
    {
      this.FormFieldList.Items.LoadItemsFromForm(this.CurrentForm)
         .DisableAll()
         .EnableFieldTypes(this.AllowedFieldTypes);
    }

    /// <summary>
    /// Inits the edit mode list.
    /// </summary>
    private void InitEditModeList()
    {
      this.EditModeList.AddRange(ConditionalStatementUtil.GetConditionalItems(new FormItem(this.CurrentDatabase.GetItem(this.CurrentID))));
      this.EditModeList.SelectRange(this.GetValueByKey("ChangeMemebrshipMode", "Always"));

      this.ModeCombobox.Text = this.EditModeList.SelectedTitle;
    }

    /// <summary>
    /// Inits the previous action list.
    /// </summary>
    private void InitPreviousActionList()
    {
      var actionDefinition = this.CurrentForm.SaveActions;
      var handle = UrlHandle.Get();
      if (handle != null && !string.IsNullOrEmpty(handle["actiondefinition"]))
      {
        actionDefinition = handle["actiondefinition"];
      }

      var list = ListDefinition.Parse(actionDefinition);

      IEnumerable<string> ids = new List<string>();
      if (list.Groups.Any())
      {
        ids = list.Groups.First().ListItems.TakeWhile(i => i.Unicid != this.UniqID).Select(i => i.Unicid);
      }

      this.PreviousActionList.Items.LoadItemsFromActions(actionDefinition, (i, uniqId) => i.InnerItem.TemplateID == FieldsIds.CrmActionTemplateID && ids.FirstOrDefault(id => id == uniqId) != null);
    }

    /// <summary>
    /// Clears the metadata.
    /// </summary>
    private void ClearMetadata()
    {
      this.Page.Session.Remove(this.MetadataKey);
      this.ViewState.Remove("metadatkey");
    }

    /// <summary>
    /// Inits the use value from list.
    /// </summary>
    private void InitUseValueFromList()
    {
      this.UseValueFromList.Items.Clear();
      this.UseValueFromList.Items.AddRange(
        new[]
        {
          new ListItem(ResourceManager.Localize("FORM_FIELD"), "0"),
          new ListItem(ResourceManager.Localize("CRM"), "1"),
          new ListItem(ResourceManager.Localize("MANUAL"), "2"),
          new ListItem(ResourceManager.Localize("PREVIOUSE_SAVE_ACTION"), "3")
        });
    }

    #endregion
  }
}