// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCrmEntity.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   The create crm entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Sitecore.WFFM.Abstractions.Dependencies;

namespace Sitecore.CrmCampaignIntegration.Submit
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Services.Protocols;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Entity;
  using CRMSecurityProvider.Sources.Repository;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.CrmCampaignIntegration.Core.Crm;
  using Sitecore.CrmCampaignIntegration.Pipelines;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Form.Core.Configuration;
  using Sitecore.Form.Core.Data;
  using Sitecore.Form.Core.Utility;
  using Sitecore.Forms.Core.Data;
  using Sitecore.Pipelines;
  using Sitecore.SecurityModel.License;
  using Sitecore.StringExtensions;
  using Sitecore.WFFM.Abstractions;
  using Sitecore.WFFM.Abstractions.Actions;

  /// <summary>
  /// The create crm entity.
  /// </summary>
  public class CreateCrmEntity : CreateCrmEntityBase
  {
    #region Fields

    /// <summary>
    /// The cannot be created message.
    /// </summary>
    private string cannotBeCreatedMessage;

    /// <summary>
    /// The entity settings.
    /// </summary>
    private XCrmEntry entitySettings;

    /// <summary>
    /// The form id.
    /// </summary>
    private ID formId;

    /// <summary>
    /// The is created.
    /// </summary>
    private bool isCreated;

    /// <summary>
    /// The key field undefined message.
    /// </summary>
    private string keyFieldUndefinedMessage;

    /// <summary>
    /// The primary field.
    /// </summary>
    private XCrmField primaryField;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCrmEntity"/> class.
    /// </summary>
    public CreateCrmEntity()
    {
      this.CanBeOverwritten = false;
    }

    public CreateCrmEntity(EntityRepositoryBase entityRepository)
      : base(entityRepository)
    {
      this.CanBeOverwritten = false;
    }

    #endregion

    #region Public methods

    protected void SetCustomCrmProperties(ID formId, AdaptedResultList fields, ICrmEntity entity)
    {
      Assert.ArgumentNotNull(formId, "guid");
      Assert.ArgumentNotNull(entity, "entity");
      var args = new SetCustomCrmPropertyArgs(formId, fields, entity)
      {
        CanBeOverwritten = this.CanBeOverwritten,
        OverwriteNotEmptyField = this.EntitySettings != null ? this.EntitySettings.OverwriteNotEmptyField : false
      };

      CorePipeline.Run("setCustomCrmProperty", args);
    }

    public override void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
    {
      Assert.ArgumentNotNull(formId, "formId");
      Assert.ArgumentNotNull(adaptedFields, "fields");

      this.Result = adaptedFields;

      this.formId = formId;
      Guid undoEntityCreation = Guid.Empty;

      try
      {
        if (this.EntitySettings != null && (this.PrimaryField != null || !this.CanBeOverwritten))
        {
          ICrmEntity entity = null;

          if (this.CanBeOverwritten)
          {
            string keyValue = this.GetValue(this.PrimaryField, adaptedFields);

            if (string.IsNullOrEmpty(keyValue))
            {
              throw new ArgumentException(this.KeyFieldUndefinedMessage);
            }

            entity = this.Get(this.EntityName, this.EntitySettings.PrimaryFieldName, keyValue, this.EntitySettings.SupportStateCode, this.GetColumns());
          }

          Guid entityId;
          if (entity == null)
          {
            entity = this.EntityRepository.NewEntity(this.EntityName);
            this.isCreated = true;
            this.InitEntityState(entity);
            this.SetProperties(entity, adaptedFields);
            this.SetCustomCrmProperties(this.formId, adaptedFields, entity);

            undoEntityCreation = this.Create(entity);
            entityId = undoEntityCreation;

            actionCallContext.Parameters.Add(this.UniqueKey, new FormsCrmEntity { Name = this.EntitySettings.EntityName, ID = entityId });

            if (Guid.Empty == undoEntityCreation)
            {
              throw new InvalidOperationException(this.CannotBeCreatedMessage);
            }
            return;
          }

          entityId = new Guid(this.GetPropertyValue(entity, this.EntitySettings.PrimaryKey));

          this.SetProperties(entity, adaptedFields);
          this.SetCustomCrmProperties(this.formId, adaptedFields, entity);
          this.Update(entity);

          actionCallContext.Parameters.Add(this.UniqueKey, new FormsCrmEntity { Name = this.EntitySettings.EntityName, ID = entityId });
        }
        else
        {
          Log.Warn(
            "'The Create CRM {0}' action is not customized.".FormatWith(
              this.EntitySettings != null ? this.EntitySettings.EntityName : "entity"),
            this);
        }
      }
      catch (SoapException ex)
      {
        var exception = new Exception(ex.GetFormatedMessage(), ex);

        this.UndoAction(undoEntityCreation);
        throw exception;
      }
      catch (Exception)
      {
        this.UndoAction(undoEntityCreation);
        throw;
      }
    }

    /// <summary>
    /// Queries the action state.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    public override ActionState QueryState(ActionQueryContext context)
    {
      try
      {
        if (!License.HasModule("Sitecore.MSCRM") ||
            (CrmRemoteSettings.CrmService.IsExpired && CrmRemoteSettings.CrmMetadataService.IsExpired))
        {
          return ActionState.Hidden;
        }
      }
      catch
      {
      }

      return base.QueryState(context);
    }

    #endregion

    #region Protected methods

    protected string GetPropertyValue(ICrmEntity entry, string name)
    {
      if (!string.IsNullOrEmpty(name) && entry != null)
      {
        var property = entry.Attributes[name];
        if (property != null)
        {
          return property.GetStringifiedValue();
        }
      }

      return string.Empty;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="field">
    /// The field.
    /// </param>
    /// <param name="list">
    /// The list.
    /// </param>
    /// <returns>
    /// The get value.
    /// </returns>
    protected string GetValue(XCrmField field, AdaptedResultList list)
    {
      if (field != null && list != null)
      {
        switch ((Core.Data.ValueFromType)field.UseValueType)
        {
          case Core.Data.ValueFromType.FromForm:

            AdaptedControlResult formField = list.GetEntryByID(field.FormValueFrom);

            if (formField != null)
            {
              return formField.Value;
            }

            break;
          case Core.Data.ValueFromType.FromCrm:
          case Core.Data.ValueFromType.Manual:
            return field.CrmValue;

          case Core.Data.ValueFromType.PreviousAction:
            dynamic contextCallWorkAround = this;

            if (contextCallWorkAround.Context != null && contextCallWorkAround.Context.Parameters.ContainsKey(field.CrmValue))
            {
              var result = (FormsCrmEntity)contextCallWorkAround.Context.Parameters[field.CrmValue];
              if (result != null)
              {
                field.EntityReference = result.Name;
                return result.ID == Guid.Empty ? null : result.ID.ToString();
              }
            }

            break;
        }
      }

      return null;
    }

    /// <summary>
    /// Inits the state of the entity.
    /// </summary>
    /// <param name="entity">
    /// The entity.
    /// </param>
    protected void InitEntityState(ICrmEntity entity)
    {
      Assert.ArgumentNotNull(entity, "entity");

      entity.LogicalName = this.EntitySettings != null ? this.EntitySettings.EntityName : string.Empty;
    }

    /// <summary>
    /// Sets the properties of the entity.
    /// </summary>
    /// <param name="entity">
    /// The entity.
    /// </param>
    /// <param name="fields">
    /// The fields.
    /// </param>
    protected virtual void SetProperties(ICrmEntity entity, AdaptedResultList fields)
    {
      if (entity != null && fields != null)
      {
        foreach (XCrmField field in this.EntitySettings.Fields)
        {
          string value = this.GetValue(field, fields);

          if (field.AttributeType == CrmAttributeType.Picklist && String.IsNullOrEmpty(value))
          {
            continue;
          }

          if (value == null)
          {
            Log.Warn(
              "'Create crm {0}' action: the {1} field requires some more settings defined.".FormatWith(
                this.EntitySettings.EntityName, field.Name),
              this);
            continue;
          }

          string previouse = this.GetPropertyValue(entity, field.Name);
          bool allowedToEdit = fields.IsTrueStatement(field.EditMode);
          if (allowedToEdit)
          {
            if (this.EntitySettings.OverwriteNotEmptyField || string.IsNullOrEmpty(previouse))
            {
              this.SetProperty(
                field.Name,
                field.AttributeType,
                value,
                entity,
                field.EntityReference,
                this.EntitySettings.EntityName,
                this.EntitySettings.PrimaryKey);
            }
          }

          if (string.Compare(value, previouse, true) != 0 || this.isCreated)
          {
            bool isUpdated = allowedToEdit &&
                             (this.EntitySettings.OverwriteNotEmptyField || string.IsNullOrEmpty(previouse));
            if (isUpdated)
            {
              this.AuditUpdatedField(this.GetValueSource(field, fields), field.Name, value);
            }
            else
            {
              this.AuditSkippedField(this.GetValueSource(field, fields), field.Name, value);
            }
          }
        }

        if (this.IsAuditEnabled)
        {
          string audit = this.DumpAuditInfomration(this.GetPropertyValue(entity, this.EntitySettings.Audit));
          if (!string.IsNullOrEmpty(audit))
          {
            this.SetProperty(this.EntitySettings.Audit, this.EntitySettings.AuditAttributeType, audit, entity);
          }
        }
      }
    }

    /// <summary>
    /// Sets the property of the entity.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <param name="propertyType">
    /// The property Type.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <param name="entity">
    /// The entity.
    /// </param>
    /// <param name="data">
    /// The data.
    /// </param>
    protected void SetProperty(string name, CrmAttributeType attributeType, string value, ICrmEntity entity, params string[] data)
    {
      Assert.ArgumentNotNull(entity, "entity");

      if (string.IsNullOrEmpty(name))
      {
        return;
      }

      if (value == null)
      {
        string entityName = this.EntitySettings != null ? this.EntitySettings.EntityName : string.Empty;
        Log.Warn("'Create crm {0}' action: the {1} crm field cannot contain the null value.".FormatWith(entityName, name), this);
        return;
      }
      var crmAttribute = entity.Attributes[name];
      if (crmAttribute != null)
      {
        crmAttribute.SetValue(value, data);
      }
      else
      {
        entity.Attributes.Create(name, attributeType, value, data);
      }
    }

    /// <summary>
    /// The set system crm properties.
    /// </summary>
    /// <param name="guid">
    /// The guid.
    /// </param>
    /// <param name="entity">
    /// The entity.
    /// </param>
    /*protected abstract void SetSystemCrmProperties(Guid guid, ICrmEntity entity);*/

    #endregion

    #region Private methods

    /// <summary>
    /// The get columns.
    /// </summary>
    /// <returns>
    /// </returns>
    private string[] GetColumns()
    {
      var fields = new List<string> { this.EntitySettings.PrimaryKey, this.EntitySettings.PrimaryFieldName };
      if (this.EntitySettings.Audit != "NoAudit")
      {
        fields.Add(this.EntitySettings.Audit);
      }

      return this.EntitySettings.Fields.Select(f => f.Name).Union(fields).ToArray();
    }

    /// <summary>
    /// The get value source.
    /// </summary>
    /// <param name="field">
    /// The field.
    /// </param>
    /// <param name="list">
    /// The list.
    /// </param>
    /// <returns>
    /// The get value source.
    /// </returns>
    private string GetValueSource(XCrmField field, AdaptedResultList list)
    {
      switch ((Core.Data.ValueFromType)field.UseValueType)
      {
        case Core.Data.ValueFromType.FromForm:

          AdaptedControlResult formField = list.GetEntryByID(field.FormValueFrom);

          if (formField != null)
          {
            return formField.FieldName;
          }

          break;
        case Core.Data.ValueFromType.FromCrm:
          return "crm";
        case Core.Data.ValueFromType.Manual:
          return "manual";

        case Core.Data.ValueFromType.PreviousAction:
          FormItem form = this.CurrentForm;
          if (form != null)
          {
            IActionItem action = DependenciesManager.ActionExecutor.GetAcitonByUniqId(form, field.CrmValue, true);
            if (action != null)
            {
              return "previous action: {0}".FormatWith(action.DisplayName);
            }
          }

          return "previous action: {0}".FormatWith(field.CrmValue);
      }

      return string.Empty;
    }

    /// <summary>
    /// The undo action.
    /// </summary>
    /// <param name="entityId">
    /// The entity id.
    /// </param>
    private void UndoAction(Guid entityId)
    {
      if (entityId != Guid.Empty)
      {
        this.EntityRepository.Delete(this.EntitySettings.EntityName, entityId);
      }
    }

    #endregion

    #endregion

    #region Properties

    #region Public properties

    /// <summary>
    /// Gets or sets a value indicating whether CanBeOverwritten.
    /// </summary>
    public bool CanBeOverwritten { get; set; }

    /// <summary>
    /// Gets or sets the cannot be created message.
    /// </summary>
    /// <value>The cannot be created message.</value>
    public string CannotBeCreatedMessage
    {
      get
      {
        return string.IsNullOrEmpty(this.cannotBeCreatedMessage)
                 ? Core.Configuration.ResourceManager.Localize("ENTITY_CANNOT_BE_CREATED")
                 : this.cannotBeCreatedMessage;
      }

      set
      {
        this.cannotBeCreatedMessage = value;
      }
    }

    /// <summary>
    /// Gets or sets the crm entity info.
    /// </summary>
    /// <value>The crm entity info.</value>
    public string CrmEntityInfo { get; set; }

    /// <summary>
    /// Gets CurrentForm.
    /// </summary>
    public override FormItem CurrentForm
    {
      get
      {
        if (!ID.IsNullOrEmpty(this.formId))
        {
          return FormItem.GetForm(this.formId);
        }
        return null;
      }
    }

    /// <summary>
    /// Gets the name of the entity.
    /// </summary>
    /// <value>The name of the entity.</value>
    [NotNull]
    public virtual string EntityName
    {
      get
      {
        if (this.EntitySettings != null)
        {
          return this.EntitySettings.EntityName;
        }
        return string.Empty;
      }
    }

    /// <summary>
    /// Gets the crm entry settings.
    /// </summary>
    /// <value>The crm entry settings.</value>
    public XCrmEntry EntitySettings
    {
      get
      {
        if (this.entitySettings == null)
        {
          if (!string.IsNullOrEmpty(this.CrmEntityInfo))
          {
            try
            {
              this.entitySettings = XCrmEntry.Parse(this.CrmEntityInfo);
            }
            catch
            {
            }
          }
        }

        return this.entitySettings;
      }
    }

    /// <summary>
    /// Gets or sets the key field undefined message.
    /// </summary>
    /// <value>The key field undefined message.</value>
    public string KeyFieldUndefinedMessage
    {
      get
      {
        return string.IsNullOrEmpty(this.keyFieldUndefinedMessage)
                 ? Core.Configuration.ResourceManager.Localize("KEY_FIELD_IS_UNDEFINED")
                 : this.keyFieldUndefinedMessage;
      }

      set
      {
        this.keyFieldUndefinedMessage = value;
      }
    }

    /// <summary>
    /// Gets PrimaryField.
    /// </summary>
    public XCrmField PrimaryField
    {
      get
      {
        if (this.primaryField == null)
        {
          Item action = StaticSettings.ContextDatabase.GetItem(this.ActionID);
          if (action != null && !string.IsNullOrEmpty(action[FieldsIds.CrmPrimaryField]))
          {
            string name = action[FieldsIds.CrmPrimaryField];
            if (this.EntitySettings[name] != null)
            {
              this.primaryField = this.EntitySettings[name];
            }
          }

          if (this.primaryField == null && this.EntitySettings != null)
          {
            this.primaryField = this.EntitySettings.PrimaryField;
          }
        }

        return this.primaryField;
      }
    }

    #endregion

    #region Protected properties


    /// <summary>
    /// Gets a value indicating whether IsAuditEnabled.
    /// </summary>
    protected bool IsAuditEnabled
    {
      get
      {
        if (this.EntitySettings != null)
        {
          return !string.IsNullOrEmpty(this.EntitySettings.Audit) && this.EntitySettings.Audit != "NoAudit" &&
                 this.EntitySettings.AuditAttributeType != CrmAttributeType.Empty;
        }

        return false;
      }
    }

    /// <summary>
    /// Gets Result.
    /// </summary>
    protected AdaptedResultList Result { get; private set; }

    #endregion

    #endregion
  }
}