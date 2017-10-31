namespace Sitecore.CrmCampaignIntegration.Pipelines
{
  using CRMSecurityProvider.Sources.Entity;
  using Sitecore.Data;
  using Sitecore.Diagnostics;
  using Sitecore.Web.UI.Sheer;
  using Sitecore.WFFM.Abstractions.Actions;

  /// <summary>
  /// The set custom crm property args.
  /// </summary>
  public class SetCustomCrmPropertyArgs : ClientPipelineArgs
  {
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCustomCrmPropertyArgs"/> class.
    /// </summary>
    /// <param name="formId">
    /// The form id.
    /// </param>
    /// <param name="fields">
    /// The fields.
    /// </param>
    /// <param name="entity">
    /// The entity.
    /// </param>
    public SetCustomCrmPropertyArgs(ID formId, AdaptedResultList fields, ICrmEntity entity)
    {
      Assert.ArgumentNotNull(formId, "formId");
      Assert.ArgumentNotNull(fields, "fields");
      Assert.ArgumentNotNull(entity, "entity");

      this.FormID = formId;
      this.Fields = fields;
      this.CrmEntity = entity;
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets crm entity.
    /// </summary>
    public ICrmEntity CrmEntity { get; private set; }

    /// <summary>
    /// Gets or sets Fields.
    /// </summary>
    public AdaptedResultList Fields { get; private set; }

    /// <summary>
    /// Gets or sets FormID.
    /// </summary>
    public ID FormID { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance can be overwritten.
    /// </summary>
    /// <value/>
    public bool CanBeOverwritten { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [overwrite not empty field].
    /// </summary>
    public bool OverwriteNotEmptyField { get; set; }

    #endregion
  }
}