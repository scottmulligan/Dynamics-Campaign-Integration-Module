using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Threading;
using System.Xml.Serialization;
using System.CodeDom.Compiler;
using System.Web.Services.Description;

namespace Sitecore.CrmCampaignIntegration.Services
{
  using CRMSecurityProvider.Sources.PagingInfo;

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [WebServiceBindingAttribute(Name = "CrmServiceSoap", Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [XmlIncludeAttribute(typeof(CrmReference))]
  [XmlIncludeAttribute(typeof(Property[]))]
  [XmlIncludeAttribute(typeof(activityparty[]))]
  public partial class CrmService : SoapHttpClientProtocol
  {

    private CrmAuthenticationToken crmAuthenticationTokenValueField;

    private CallerOriginToken callerOriginTokenValueField;

    private CorrelationToken correlationTokenValueField;

    private SendOrPostCallback ExecuteOperationCompleted;

    private SendOrPostCallback FetchOperationCompleted;

    private SendOrPostCallback CreateOperationCompleted;

    private SendOrPostCallback DeleteOperationCompleted;

    private SendOrPostCallback RetrieveOperationCompleted;

    private SendOrPostCallback RetrieveMultipleOperationCompleted;

    private SendOrPostCallback UpdateOperationCompleted;

    /// <remarks/>
    public CrmService()
    {

    }

    public CrmAuthenticationToken CrmAuthenticationTokenValue
    {
      get
      {
        return this.crmAuthenticationTokenValueField;
      }
      set
      {
        this.crmAuthenticationTokenValueField = value;
      }
    }

    public CallerOriginToken CallerOriginTokenValue
    {
      get
      {
        return this.callerOriginTokenValueField;
      }
      set
      {
        this.callerOriginTokenValueField = value;
      }
    }

    public CorrelationToken CorrelationTokenValue
    {
      get
      {
        return this.correlationTokenValueField;
      }
      set
      {
        this.correlationTokenValueField = value;
      }
    }

    /// <remarks/>
    public event ExecuteCompletedEventHandler ExecuteCompleted;

    /// <remarks/>
    public event FetchCompletedEventHandler FetchCompleted;

    /// <remarks/>
    public event CreateCompletedEventHandler CreateCompleted;

    /// <remarks/>
    public event DeleteCompletedEventHandler DeleteCompleted;

    /// <remarks/>
    public event RetrieveCompletedEventHandler RetrieveCompleted;

    /// <remarks/>
    public event RetrieveMultipleCompletedEventHandler RetrieveMultipleCompleted;

    /// <remarks/>
    public event UpdateCompletedEventHandler UpdateCompleted;

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Execute", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    [return: XmlElementAttribute("Response")]
    public Response Execute(Request Request)
    {
      object[] results = this.Invoke("Execute", new object[] {
                        Request});
      return ((Response)(results[0]));
    }

    /// <remarks/>
    public IAsyncResult BeginExecute(Request Request, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Execute", new object[] {
                        Request}, callback, asyncState);
    }

    /// <remarks/>
    public Response EndExecute(IAsyncResult asyncResult)
    {
      object[] results = this.EndInvoke(asyncResult);
      return ((Response)(results[0]));
    }

    /// <remarks/>
    public void ExecuteAsync(Request Request)
    {
      this.ExecuteAsync(Request, null);
    }

    /// <remarks/>
    public void ExecuteAsync(Request Request, object userState)
    {
      if ((this.ExecuteOperationCompleted == null))
      {
        this.ExecuteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteOperationCompleted);
      }
      this.InvokeAsync("Execute", new object[] {
                        Request}, this.ExecuteOperationCompleted, userState);
    }

    private void OnExecuteOperationCompleted(object arg)
    {
      if ((this.ExecuteCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.ExecuteCompleted(this, new ExecuteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Fetch", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public string Fetch(string fetchXml)
    {
      object[] results = this.Invoke("Fetch", new object[] {
                        fetchXml});
      return ((string)(results[0]));
    }

    /// <remarks/>
    public IAsyncResult BeginFetch(string fetchXml, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Fetch", new object[] {
                        fetchXml}, callback, asyncState);
    }

    /// <remarks/>
    public string EndFetch(IAsyncResult asyncResult)
    {
      object[] results = this.EndInvoke(asyncResult);
      return ((string)(results[0]));
    }

    /// <remarks/>
    public void FetchAsync(string fetchXml)
    {
      this.FetchAsync(fetchXml, null);
    }

    /// <remarks/>
    public void FetchAsync(string fetchXml, object userState)
    {
      if ((this.FetchOperationCompleted == null))
      {
        this.FetchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFetchOperationCompleted);
      }
      this.InvokeAsync("Fetch", new object[] {
                        fetchXml}, this.FetchOperationCompleted, userState);
    }

    private void OnFetchOperationCompleted(object arg)
    {
      if ((this.FetchCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.FetchCompleted(this, new FetchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Create", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public Guid Create(BusinessEntity entity)
    {
      object[] results = this.Invoke("Create", new object[] {
                        entity});
      return ((System.Guid)(results[0]));
    }

    /// <remarks/>
    public IAsyncResult BeginCreate(BusinessEntity entity, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Create", new object[] {
                        entity}, callback, asyncState);
    }

    /// <remarks/>
    public Guid EndCreate(IAsyncResult asyncResult)
    {
      object[] results = this.EndInvoke(asyncResult);
      return ((System.Guid)(results[0]));
    }

    /// <remarks/>
    public void CreateAsync(BusinessEntity entity)
    {
      this.CreateAsync(entity, null);
    }

    /// <remarks/>
    public void CreateAsync(BusinessEntity entity, object userState)
    {
      if ((this.CreateOperationCompleted == null))
      {
        this.CreateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateOperationCompleted);
      }
      this.InvokeAsync("Create", new object[] {
                        entity}, this.CreateOperationCompleted, userState);
    }

    private void OnCreateOperationCompleted(object arg)
    {
      if ((this.CreateCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.CreateCompleted(this, new CreateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Delete", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public void Delete(string entityName, Guid id)
    {
      this.Invoke("Delete", new object[] {
                        entityName,
                        id});
    }

    /// <remarks/>
    public IAsyncResult BeginDelete(string entityName, Guid id, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Delete", new object[] {
                        entityName,
                        id}, callback, asyncState);
    }

    /// <remarks/>
    public void EndDelete(IAsyncResult asyncResult)
    {
      this.EndInvoke(asyncResult);
    }

    /// <remarks/>
    public void DeleteAsync(string entityName, Guid id)
    {
      this.DeleteAsync(entityName, id, null);
    }

    /// <remarks/>
    public void DeleteAsync(string entityName, Guid id, object userState)
    {
      if ((this.DeleteOperationCompleted == null))
      {
        this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
      }
      this.InvokeAsync("Delete", new object[] {
                        entityName,
                        id}, this.DeleteOperationCompleted, userState);
    }

    private void OnDeleteOperationCompleted(object arg)
    {
      if ((this.DeleteCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.DeleteCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Retrieve", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public BusinessEntity Retrieve(string entityName, Guid id, ColumnSetBase columnSet)
    {
      object[] results = this.Invoke("Retrieve", new object[] {
                        entityName,
                        id,
                        columnSet});
      return ((BusinessEntity)(results[0]));
    }

    /// <remarks/>
    public IAsyncResult BeginRetrieve(string entityName, Guid id, ColumnSetBase columnSet, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Retrieve", new object[] {
                        entityName,
                        id,
                        columnSet}, callback, asyncState);
    }

    /// <remarks/>
    public BusinessEntity EndRetrieve(IAsyncResult asyncResult)
    {
      object[] results = this.EndInvoke(asyncResult);
      return ((BusinessEntity)(results[0]));
    }

    /// <remarks/>
    public void RetrieveAsync(string entityName, Guid id, ColumnSetBase columnSet)
    {
      this.RetrieveAsync(entityName, id, columnSet, null);
    }

    /// <remarks/>
    public void RetrieveAsync(string entityName, Guid id, ColumnSetBase columnSet, object userState)
    {
      if ((this.RetrieveOperationCompleted == null))
      {
        this.RetrieveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveOperationCompleted);
      }
      this.InvokeAsync("Retrieve", new object[] {
                        entityName,
                        id,
                        columnSet}, this.RetrieveOperationCompleted, userState);
    }

    private void OnRetrieveOperationCompleted(object arg)
    {
      if ((this.RetrieveCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.RetrieveCompleted(this, new RetrieveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/RetrieveMultiple", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public BusinessEntityCollection RetrieveMultiple(QueryBase query)
    {
      object[] results = this.Invoke("RetrieveMultiple", new object[] {
                        query});
      return ((BusinessEntityCollection)(results[0]));
    }

    /// <remarks/>
    public IAsyncResult BeginRetrieveMultiple(QueryBase query, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("RetrieveMultiple", new object[] {
                        query}, callback, asyncState);
    }

    /// <remarks/>
    public BusinessEntityCollection EndRetrieveMultiple(IAsyncResult asyncResult)
    {
      object[] results = this.EndInvoke(asyncResult);
      return ((BusinessEntityCollection)(results[0]));
    }

    /// <remarks/>
    public void RetrieveMultipleAsync(QueryBase query)
    {
      this.RetrieveMultipleAsync(query, null);
    }

    /// <remarks/>
    public void RetrieveMultipleAsync(QueryBase query, object userState)
    {
      if ((this.RetrieveMultipleOperationCompleted == null))
      {
        this.RetrieveMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveMultipleOperationCompleted);
      }
      this.InvokeAsync("RetrieveMultiple", new object[] {
                        query}, this.RetrieveMultipleOperationCompleted, userState);
    }

    private void OnRetrieveMultipleOperationCompleted(object arg)
    {
      if ((this.RetrieveMultipleCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.RetrieveMultipleCompleted(this, new RetrieveMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    [SoapHeaderAttribute("CorrelationTokenValue")]
    [SoapHeaderAttribute("CallerOriginTokenValue")]
    [SoapHeaderAttribute("CrmAuthenticationTokenValue")]
    [SoapDocumentMethodAttribute("http://schemas.microsoft.com/crm/2007/WebServices/Update", RequestNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", ResponseNamespace = "http://schemas.microsoft.com/crm/2007/WebServices", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public void Update(BusinessEntity entity)
    {
      this.Invoke("Update", new object[] {
                        entity});
    }

    /// <remarks/>
    public IAsyncResult BeginUpdate(BusinessEntity entity, AsyncCallback callback, object asyncState)
    {
      return this.BeginInvoke("Update", new object[] {
                        entity}, callback, asyncState);
    }

    /// <remarks/>
    public void EndUpdate(IAsyncResult asyncResult)
    {
      this.EndInvoke(asyncResult);
    }

    /// <remarks/>
    public void UpdateAsync(BusinessEntity entity)
    {
      this.UpdateAsync(entity, null);
    }

    /// <remarks/>
    public void UpdateAsync(BusinessEntity entity, object userState)
    {
      if ((this.UpdateOperationCompleted == null))
      {
        this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
      }
      this.InvokeAsync("Update", new object[] {
                        entity}, this.UpdateOperationCompleted, userState);
    }

    private void OnUpdateOperationCompleted(object arg)
    {
      if ((this.UpdateCompleted != null))
      {
        System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
        this.UpdateCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
      }
    }

    /// <remarks/>
    public new void CancelAsync(object userState)
    {
      base.CancelAsync(userState);
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class AsyncServiceOrigin : CallerOrigin
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class ApplicationOrigin : CallerOrigin
  {
  }


  /// <remarks/>
  [XmlIncludeAttribute(typeof(WebServiceApiOrigin))]
  [XmlIncludeAttribute(typeof(OfflineOrigin))]
  [XmlIncludeAttribute(typeof(AsyncServiceOrigin))]
  [XmlIncludeAttribute(typeof(ApplicationOrigin))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [DebuggerNonUserCode]
  public abstract partial class CallerOrigin
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [XmlRootAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices", IsNullable = true)]
  [DebuggerNonUserCode]
  public partial class CallerOriginToken : SoapHeader
  {

    private CallerOrigin callerOriginField;

    /// <remarks/>
    public CallerOrigin CallerOrigin
    {
      get
      {
        return this.callerOriginField;
      }
      set
      {
        this.callerOriginField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [XmlRootAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices", IsNullable = true)]
  [DebuggerNonUserCode]
  public partial class CorrelationToken : SoapHeader
  {

    private System.Guid correlationIdField;

    private CrmDateTime correlationUpdatedTimeField;

    private int depthField;

    /// <remarks/>
    public System.Guid CorrelationId
    {
      get
      {
        return this.correlationIdField;
      }
      set
      {
        this.correlationIdField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime CorrelationUpdatedTime
    {
      get
      {
        return this.correlationUpdatedTimeField;
      }
      set
      {
        this.correlationUpdatedTimeField = value;
      }
    }

    /// <remarks/>
    public int Depth
    {
      get
      {
        return this.depthField;
      }
      set
      {
        this.depthField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmDateTime
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string dateField;

    private string timeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string date
    {
      get
      {
        return this.dateField;
      }
      set
      {
        this.dateField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time
    {
      get
      {
        return this.timeField;
      }
      set
      {
        this.timeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ObjectiveRelation
  {

    private System.Guid resourceSpecIdField;

    private string objectiveExpressionField;

    /// <remarks/>
    public System.Guid ResourceSpecId
    {
      get
      {
        return this.resourceSpecIdField;
      }
      set
      {
        this.resourceSpecIdField = value;
      }
    }

    /// <remarks/>
    public string ObjectiveExpression
    {
      get
      {
        return this.objectiveExpressionField;
      }
      set
      {
        this.objectiveExpressionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ConstraintRelation
  {

    private System.Guid objectIdField;

    private string constraintTypeField;

    private string constraintsField;

    /// <remarks/>
    public System.Guid ObjectId
    {
      get
      {
        return this.objectIdField;
      }
      set
      {
        this.objectIdField = value;
      }
    }

    /// <remarks/>
    public string ConstraintType
    {
      get
      {
        return this.constraintTypeField;
      }
      set
      {
        this.constraintTypeField = value;
      }
    }

    /// <remarks/>
    public string Constraints
    {
      get
      {
        return this.constraintsField;
      }
      set
      {
        this.constraintsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class RequiredResource
  {

    private System.Guid resourceIdField;

    private System.Guid resourceSpecIdField;

    /// <remarks/>
    public System.Guid ResourceId
    {
      get
      {
        return this.resourceIdField;
      }
      set
      {
        this.resourceIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid ResourceSpecId
    {
      get
      {
        return this.resourceSpecIdField;
      }
      set
      {
        this.resourceSpecIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  public enum SearchDirection
  {

    /// <remarks/>
    Forward,

    /// <remarks/>
    Backward,
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetUpdateDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetUpdate
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Lookup : CrmReference
  {
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(Owner))]
  [XmlIncludeAttribute(typeof(Lookup))]
  [XmlIncludeAttribute(typeof(Customer))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class CrmReference
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string nameField;

    private string typeField;

    private int dscField;

    private bool dscFieldSpecified;

    private System.Guid valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get
      {
        return this.typeField;
      }
      set
      {
        this.typeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int dsc
    {
      get
      {
        return this.dscField;
      }
      set
      {
        this.dscField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dscSpecified
    {
      get
      {
        return this.dscFieldSpecified;
      }
      set
      {
        this.dscFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.Guid Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Owner : CrmReference
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Customer : CrmReference
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmNumber
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string formattedvalueField;

    private int valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string formattedvalue
    {
      get
      {
        return this.formattedvalueField;
      }
      set
      {
        this.formattedvalueField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public int Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class UniqueIdentifier
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private System.Guid valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.Guid Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Picklist
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string nameField;

    private int valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public int Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Key
  {

    private System.Guid valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.Guid Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(activityparty))]
  [XmlIncludeAttribute(typeof(DynamicEntity))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class BusinessEntity
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class DynamicEntity : BusinessEntity
  {

    private Property[] propertiesField;

    private string nameField;

    /// <remarks/>
    public Property[] Properties
    {
      get
      {
        return this.propertiesField;
      }
      set
      {
        this.propertiesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class activityparty : BusinessEntity
  {

    private Lookup activityidField;

    private Key activitypartyidField;

    private string addressusedField;

    private CrmBoolean donotemailField;

    private CrmBoolean donotfaxField;

    private CrmBoolean donotphoneField;

    private CrmBoolean donotpostalmailField;

    private CrmFloat effortField;

    private string exchangeentryidField;

    private Picklist participationtypemaskField;

    private Lookup partyidField;

    private Lookup resourcespecidField;

    private CrmDateTime scheduledendField;

    private CrmDateTime scheduledstartField;

    /// <remarks/>
    public Lookup activityid
    {
      get
      {
        return this.activityidField;
      }
      set
      {
        this.activityidField = value;
      }
    }

    /// <remarks/>
    public Key activitypartyid
    {
      get
      {
        return this.activitypartyidField;
      }
      set
      {
        this.activitypartyidField = value;
      }
    }

    /// <remarks/>
    public string addressused
    {
      get
      {
        return this.addressusedField;
      }
      set
      {
        this.addressusedField = value;
      }
    }

    /// <remarks/>
    public CrmBoolean donotemail
    {
      get
      {
        return this.donotemailField;
      }
      set
      {
        this.donotemailField = value;
      }
    }

    /// <remarks/>
    public CrmBoolean donotfax
    {
      get
      {
        return this.donotfaxField;
      }
      set
      {
        this.donotfaxField = value;
      }
    }

    /// <remarks/>
    public CrmBoolean donotphone
    {
      get
      {
        return this.donotphoneField;
      }
      set
      {
        this.donotphoneField = value;
      }
    }

    /// <remarks/>
    public CrmBoolean donotpostalmail
    {
      get
      {
        return this.donotpostalmailField;
      }
      set
      {
        this.donotpostalmailField = value;
      }
    }

    /// <remarks/>
    public CrmFloat effort
    {
      get
      {
        return this.effortField;
      }
      set
      {
        this.effortField = value;
      }
    }

    /// <remarks/>
    public string exchangeentryid
    {
      get
      {
        return this.exchangeentryidField;
      }
      set
      {
        this.exchangeentryidField = value;
      }
    }

    /// <remarks/>
    public Picklist participationtypemask
    {
      get
      {
        return this.participationtypemaskField;
      }
      set
      {
        this.participationtypemaskField = value;
      }
    }

    /// <remarks/>
    public Lookup partyid
    {
      get
      {
        return this.partyidField;
      }
      set
      {
        this.partyidField = value;
      }
    }

    /// <remarks/>
    public Lookup resourcespecid
    {
      get
      {
        return this.resourcespecidField;
      }
      set
      {
        this.resourcespecidField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime scheduledend
    {
      get
      {
        return this.scheduledendField;
      }
      set
      {
        this.scheduledendField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime scheduledstart
    {
      get
      {
        return this.scheduledstartField;
      }
      set
      {
        this.scheduledstartField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(UniqueIdentifierProperty))]
  [XmlIncludeAttribute(typeof(StringProperty))]
  [XmlIncludeAttribute(typeof(StatusProperty))]
  [XmlIncludeAttribute(typeof(StateProperty))]
  [XmlIncludeAttribute(typeof(PicklistProperty))]
  [XmlIncludeAttribute(typeof(OwnerProperty))]
  [XmlIncludeAttribute(typeof(LookupProperty))]
  [XmlIncludeAttribute(typeof(KeyProperty))]
  [XmlIncludeAttribute(typeof(EntityNameReferenceProperty))]
  [XmlIncludeAttribute(typeof(DynamicEntityArrayProperty))]
  [XmlIncludeAttribute(typeof(CustomerProperty))]
  [XmlIncludeAttribute(typeof(CrmNumberProperty))]
  [XmlIncludeAttribute(typeof(CrmMoneyProperty))]
  [XmlIncludeAttribute(typeof(CrmFloatProperty))]
  [XmlIncludeAttribute(typeof(CrmDecimalProperty))]
  [XmlIncludeAttribute(typeof(CrmDateTimeProperty))]
  [XmlIncludeAttribute(typeof(CrmBooleanProperty))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class Property
  {

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class UniqueIdentifierProperty : Property
  {

    private UniqueIdentifier valueField;

    /// <remarks/>
    public UniqueIdentifier Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class StringProperty : Property
  {

    private string valueField;

    /// <remarks/>
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class StatusProperty : Property
  {

    private Status valueField;

    /// <remarks/>
    public Status Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class Status
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string nameField;

    private int valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public int Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class StateProperty : Property
  {

    private string valueField;

    /// <remarks/>
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class PicklistProperty : Property
  {

    private Picklist valueField;

    /// <remarks/>
    public Picklist Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class OwnerProperty : Property
  {

    private Owner valueField;

    /// <remarks/>
    public Owner Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class LookupProperty : Property
  {

    private Lookup valueField;

    /// <remarks/>
    public Lookup Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class KeyProperty : Property
  {

    private Key valueField;

    /// <remarks/>
    public Key Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class EntityNameReferenceProperty : Property
  {

    private EntityNameReference valueField;

    /// <remarks/>
    public EntityNameReference Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class EntityNameReference
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class DynamicEntityArrayProperty : Property
  {

    private DynamicEntity[] valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public DynamicEntity[] Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CustomerProperty : Property
  {

    private Customer valueField;

    /// <remarks/>
    public Customer Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmNumberProperty : Property
  {

    private CrmNumber valueField;

    /// <remarks/>
    public CrmNumber Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmMoneyProperty : Property
  {

    private CrmMoney valueField;

    /// <remarks/>
    public CrmMoney Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmMoney
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string formattedvalueField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string formattedvalue
    {
      get
      {
        return this.formattedvalueField;
      }
      set
      {
        this.formattedvalueField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmFloatProperty : Property
  {

    private CrmFloat valueField;

    /// <remarks/>
    public CrmFloat Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmFloat
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string formattedvalueField;

    private double valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string formattedvalue
    {
      get
      {
        return this.formattedvalueField;
      }
      set
      {
        this.formattedvalueField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public double Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmDecimalProperty : Property
  {

    private CrmDecimal valueField;

    /// <remarks/>
    public CrmDecimal Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmDecimal
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string formattedvalueField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string formattedvalue
    {
      get
      {
        return this.formattedvalueField;
      }
      set
      {
        this.formattedvalueField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmDateTimeProperty : Property
  {

    private CrmDateTime valueField;

    /// <remarks/>
    public CrmDateTime Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmBooleanProperty : Property
  {

    private CrmBoolean valueField;

    /// <remarks/>
    public CrmBoolean Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmBoolean
  {

    private bool isNullField;

    private bool isNullFieldSpecified;

    private string nameField;

    private bool valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNull
    {
      get
      {
        return this.isNullField;
      }
      set
      {
        this.isNullField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsNullSpecified
    {
      get
      {
        return this.isNullFieldSpecified;
      }
      set
      {
        this.isNullFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public bool Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetUpdateDynamic : TargetUpdate
  {

    private DynamicEntity entityField;

    /// <remarks/>
    public DynamicEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetScheduleDynamic : TargetSchedule
  {

    private DynamicEntity entityField;

    /// <remarks/>
    public DynamicEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetRollupDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetRollup
  {
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(QueryExpression))]
  [XmlIncludeAttribute(typeof(QueryByAttribute))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public abstract partial class QueryBase
  {

    private string entityNameField;

    private ColumnSetBase columnSetField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(ColumnSet))]
  [XmlIncludeAttribute(typeof(AllColumns))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public abstract partial class ColumnSetBase
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class ColumnSet : ColumnSetBase
  {

    private string[] attributesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Attribute", IsNullable = false)]
    public string[] Attributes
    {
      get
      {
        return this.attributesField;
      }
      set
      {
        this.attributesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class AllColumns : ColumnSetBase
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class QueryExpression : QueryBase
  {

    private bool distinctField;

    private CrmPagingInfo pageInfoField;

    private LinkEntity[] linkEntitiesField;

    private FilterExpression criteriaField;

    private CrmOrderExpression[] ordersField;

    /// <remarks/>
    public bool Distinct
    {
      get
      {
        return this.distinctField;
      }
      set
      {
        this.distinctField = value;
      }
    }

    /// <remarks/>
    public CrmPagingInfo PageInfo
    {
      get
      {
        return this.pageInfoField;
      }
      set
      {
        this.pageInfoField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public LinkEntity[] LinkEntities
    {
      get
      {
        return this.linkEntitiesField;
      }
      set
      {
        this.linkEntitiesField = value;
      }
    }

    /// <remarks/>
    public FilterExpression Criteria
    {
      get
      {
        return this.criteriaField;
      }
      set
      {
        this.criteriaField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Order", IsNullable = false)]
    public CrmOrderExpression[] Orders
    {
      get
      {
        return this.ordersField;
      }
      set
      {
        this.ordersField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class PagingInfo
  {

    private int pageNumberField;

    private int countField;

    private string pagingCookieField;

    /// <remarks/>
    public int PageNumber
    {
      get
      {
        return this.pageNumberField;
      }
      set
      {
        this.pageNumberField = value;
      }
    }

    /// <remarks/>
    public int Count
    {
      get
      {
        return this.countField;
      }
      set
      {
        this.countField = value;
      }
    }

    /// <remarks/>
    public string PagingCookie
    {
      get
      {
        return this.pagingCookieField;
      }
      set
      {
        this.pagingCookieField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class LinkEntity
  {

    private string linkFromAttributeNameField;

    private string linkFromEntityNameField;

    private string linkToEntityNameField;

    private string linkToAttributeNameField;

    private JoinOperator joinOperatorField;

    private FilterExpression linkCriteriaField;

    private LinkEntity[] linkEntitiesField;

    /// <remarks/>
    public string LinkFromAttributeName
    {
      get
      {
        return this.linkFromAttributeNameField;
      }
      set
      {
        this.linkFromAttributeNameField = value;
      }
    }

    /// <remarks/>
    public string LinkFromEntityName
    {
      get
      {
        return this.linkFromEntityNameField;
      }
      set
      {
        this.linkFromEntityNameField = value;
      }
    }

    /// <remarks/>
    public string LinkToEntityName
    {
      get
      {
        return this.linkToEntityNameField;
      }
      set
      {
        this.linkToEntityNameField = value;
      }
    }

    /// <remarks/>
    public string LinkToAttributeName
    {
      get
      {
        return this.linkToAttributeNameField;
      }
      set
      {
        this.linkToAttributeNameField = value;
      }
    }

    /// <remarks/>
    public JoinOperator JoinOperator
    {
      get
      {
        return this.joinOperatorField;
      }
      set
      {
        this.joinOperatorField = value;
      }
    }

    /// <remarks/>
    public FilterExpression LinkCriteria
    {
      get
      {
        return this.linkCriteriaField;
      }
      set
      {
        this.linkCriteriaField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public LinkEntity[] LinkEntities
    {
      get
      {
        return this.linkEntitiesField;
      }
      set
      {
        this.linkEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  public enum JoinOperator
  {

    /// <remarks/>
    Inner,

    /// <remarks/>
    LeftOuter,

    /// <remarks/>
    Natural,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class FilterExpression
  {

    private LogicalOperator filterOperatorField;

    private ConditionExpression[] conditionsField;

    private FilterExpression[] filtersField;

    /// <remarks/>
    public LogicalOperator FilterOperator
    {
      get
      {
        return this.filterOperatorField;
      }
      set
      {
        this.filterOperatorField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Condition", IsNullable = false)]
    public ConditionExpression[] Conditions
    {
      get
      {
        return this.conditionsField;
      }
      set
      {
        this.conditionsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Filter", IsNullable = false)]
    public FilterExpression[] Filters
    {
      get
      {
        return this.filtersField;
      }
      set
      {
        this.filtersField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  public enum LogicalOperator
  {

    /// <remarks/>
    And,

    /// <remarks/>
    Or,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class ConditionExpression
  {

    private string attributeNameField;

    private ConditionOperator operatorField;

    private object[] valuesField;

    /// <remarks/>
    public string AttributeName
    {
      get
      {
        return this.attributeNameField;
      }
      set
      {
        this.attributeNameField = value;
      }
    }

    /// <remarks/>
    public ConditionOperator Operator
    {
      get
      {
        return this.operatorField;
      }
      set
      {
        this.operatorField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Value")]
    public object[] Values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  public enum ConditionOperator
  {

    /// <remarks/>
    Equal,

    /// <remarks/>
    NotEqual,

    /// <remarks/>
    GreaterThan,

    /// <remarks/>
    LessThan,

    /// <remarks/>
    GreaterEqual,

    /// <remarks/>
    LessEqual,

    /// <remarks/>
    Like,

    /// <remarks/>
    NotLike,

    /// <remarks/>
    In,

    /// <remarks/>
    NotIn,

    /// <remarks/>
    Between,

    /// <remarks/>
    NotBetween,

    /// <remarks/>
    Null,

    /// <remarks/>
    NotNull,

    /// <remarks/>
    Yesterday,

    /// <remarks/>
    Today,

    /// <remarks/>
    Tomorrow,

    /// <remarks/>
    Last7Days,

    /// <remarks/>
    Next7Days,

    /// <remarks/>
    LastWeek,

    /// <remarks/>
    ThisWeek,

    /// <remarks/>
    NextWeek,

    /// <remarks/>
    LastMonth,

    /// <remarks/>
    ThisMonth,

    /// <remarks/>
    NextMonth,

    /// <remarks/>
    On,

    /// <remarks/>
    OnOrBefore,

    /// <remarks/>
    OnOrAfter,

    /// <remarks/>
    LastYear,

    /// <remarks/>
    ThisYear,

    /// <remarks/>
    NextYear,

    /// <remarks/>
    LastXHours,

    /// <remarks/>
    NextXHours,

    /// <remarks/>
    LastXDays,

    /// <remarks/>
    NextXDays,

    /// <remarks/>
    LastXWeeks,

    /// <remarks/>
    NextXWeeks,

    /// <remarks/>
    LastXMonths,

    /// <remarks/>
    NextXMonths,

    /// <remarks/>
    LastXYears,

    /// <remarks/>
    NextXYears,

    /// <remarks/>
    EqualUserId,

    /// <remarks/>
    NotEqualUserId,

    /// <remarks/>
    EqualBusinessId,

    /// <remarks/>
    NotEqualBusinessId,

    /// <remarks/>
    EqualUserLanguage,

    /// <remarks/>
    NotOn,

    /// <remarks/>
    OlderThanXMonths,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class OrderExpression
  {

    private string attributeNameField;

    private OrderType orderTypeField;

    /// <remarks/>
    public string AttributeName
    {
      get
      {
        return this.attributeNameField;
      }
      set
      {
        this.attributeNameField = value;
      }
    }

    /// <remarks/>
    public OrderType OrderType
    {
      get
      {
        return this.orderTypeField;
      }
      set
      {
        this.orderTypeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  public enum OrderType
  {

    /// <remarks/>
    Ascending,

    /// <remarks/>
    Descending,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Query")]
  [DebuggerNonUserCode]
  public partial class QueryByAttribute : QueryBase
  {

    private string[] attributesField;

    private object[] valuesField;

    private PagingInfo pageInfoField;

    private OrderExpression[] ordersField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Attribute", IsNullable = false)]
    public string[] Attributes
    {
      get
      {
        return this.attributesField;
      }
      set
      {
        this.attributesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Value")]
    public object[] Values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }

    /// <remarks/>
    public PagingInfo PageInfo
    {
      get
      {
        return this.pageInfoField;
      }
      set
      {
        this.pageInfoField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Order", IsNullable = false)]
    public OrderExpression[] Orders
    {
      get
      {
        return this.ordersField;
      }
      set
      {
        this.ordersField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ProposalParty
  {

    private System.Guid resourceIdField;

    private System.Guid resourceSpecIdField;

    private string displayNameField;

    private string entityNameField;

    private double effortRequiredField;

    /// <remarks/>
    public System.Guid ResourceId
    {
      get
      {
        return this.resourceIdField;
      }
      set
      {
        this.resourceIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid ResourceSpecId
    {
      get
      {
        return this.resourceSpecIdField;
      }
      set
      {
        this.resourceSpecIdField = value;
      }
    }

    /// <remarks/>
    public string DisplayName
    {
      get
      {
        return this.displayNameField;
      }
      set
      {
        this.displayNameField = value;
      }
    }

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public double EffortRequired
    {
      get
      {
        return this.effortRequiredField;
      }
      set
      {
        this.effortRequiredField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class AppointmentProposal
  {

    private CrmDateTime startField;

    private CrmDateTime endField;

    private System.Guid siteIdField;

    private string siteNameField;

    private ProposalParty[] proposalPartiesField;

    /// <remarks/>
    public CrmDateTime Start
    {
      get
      {
        return this.startField;
      }
      set
      {
        this.startField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime End
    {
      get
      {
        return this.endField;
      }
      set
      {
        this.endField = value;
      }
    }

    /// <remarks/>
    public System.Guid SiteId
    {
      get
      {
        return this.siteIdField;
      }
      set
      {
        this.siteIdField = value;
      }
    }

    /// <remarks/>
    public string SiteName
    {
      get
      {
        return this.siteNameField;
      }
      set
      {
        this.siteNameField = value;
      }
    }

    /// <remarks/>
    public ProposalParty[] ProposalParties
    {
      get
      {
        return this.proposalPartiesField;
      }
      set
      {
        this.proposalPartiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class SearchResults
  {

    private AppointmentProposal[] proposalsField;

    private TraceInfo traceInfoField;

    /// <remarks/>
    public AppointmentProposal[] Proposals
    {
      get
      {
        return this.proposalsField;
      }
      set
      {
        this.proposalsField = value;
      }
    }

    /// <remarks/>
    public TraceInfo TraceInfo
    {
      get
      {
        return this.traceInfoField;
      }
      set
      {
        this.traceInfoField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class TraceInfo
  {

    private ErrorInfo[] errorInfoListField;

    /// <remarks/>
    public ErrorInfo[] ErrorInfoList
    {
      get
      {
        return this.errorInfoListField;
      }
      set
      {
        this.errorInfoListField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ErrorInfo
  {

    private ResourceInfo[] resourceListField;

    private string errorCodeField;

    /// <remarks/>
    public ResourceInfo[] ResourceList
    {
      get
      {
        return this.resourceListField;
      }
      set
      {
        this.resourceListField = value;
      }
    }

    /// <remarks/>
    public string ErrorCode
    {
      get
      {
        return this.errorCodeField;
      }
      set
      {
        this.errorCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ResourceInfo
  {

    private System.Guid idField;

    private string displayNameField;

    private string entityNameField;

    /// <remarks/>
    public System.Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }

    /// <remarks/>
    public string DisplayName
    {
      get
      {
        return this.displayNameField;
      }
      set
      {
        this.displayNameField = value;
      }
    }

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }
  }


  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetRollupDynamic : TargetRollup
  {

    private string entityNameField;

    private System.Guid entityIdField;

    private QueryBase queryField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetRetrieveDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetRetrieve
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetRetrieveDynamic : TargetRetrieve
  {

    private string entityNameField;

    private System.Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }


  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetRemoveParentSystemUser))]
  [XmlIncludeAttribute(typeof(TargetRemoveParentDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetRemoveParent
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetRemoveParentSystemUser : TargetRemoveParent
  {

    private System.Guid entityIdField;

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetRemoveParentDynamic : TargetRemoveParent
  {

    private string entityNameField;

    private System.Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetRelatedDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetRelated
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetRelatedDynamic : TargetRelated
  {

    private string entity1NameField;

    private System.Guid entity1IdField;

    private string entity2NameField;

    private System.Guid entity2IdField;

    /// <remarks/>
    public string Entity1Name
    {
      get
      {
        return this.entity1NameField;
      }
      set
      {
        this.entity1NameField = value;
      }
    }

    /// <remarks/>
    public System.Guid Entity1Id
    {
      get
      {
        return this.entity1IdField;
      }
      set
      {
        this.entity1IdField = value;
      }
    }

    /// <remarks/>
    public string Entity2Name
    {
      get
      {
        return this.entity2NameField;
      }
      set
      {
        this.entity2NameField = value;
      }
    }

    /// <remarks/>
    public System.Guid Entity2Id
    {
      get
      {
        return this.entity2IdField;
      }
      set
      {
        this.entity2IdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetQueuedDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetQueued
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetQueuedDynamic : TargetQueued
  {

    private string entityNameField;

    private Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetQuantifyDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetQuantify
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetQuantifyDynamic : TargetQuantify
  {

    private string entityNameField;

    private System.Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetMergeDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetMerge
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetMergeDynamic : TargetMerge
  {

    private string entityNameField;

    private Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetDeleteDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetDelete
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetDeleteDynamic : TargetDelete
  {

    private string entityNameField;

    private System.Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetCreateDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetCreate
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetCreateDynamic : TargetCreate
  {

    private DynamicEntity entityField;

    /// <remarks/>
    public DynamicEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetCompoundDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetCompound
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetCompoundDynamic : TargetCompound
  {

    private DynamicEntity entityField;

    private DynamicEntity[] childEntitiesField;

    /// <remarks/>
    public DynamicEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }

    /// <remarks/>
    [XmlArrayItemAttribute(IsNullable = false)]
    public DynamicEntity[] ChildEntities
    {
      get
      {
        return this.childEntitiesField;
      }
      set
      {
        this.childEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetScheduleDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetSchedule
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  [DebuggerNonUserCode]
  public partial class BusinessEntityCollection
  {

    private BusinessEntity[] businessEntitiesField;

    private string entityNameField;

    private bool moreRecordsField;

    private string pagingCookieField;

    private string versionField;

    /// <remarks/>
    [XmlArrayItemAttribute(IsNullable = false)]
    public BusinessEntity[] BusinessEntities
    {
      get
      {
        return this.businessEntitiesField;
      }
      set
      {
        this.businessEntitiesField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool MoreRecords
    {
      get
      {
        return this.moreRecordsField;
      }
      set
      {
        this.moreRecordsField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string PagingCookie
    {
      get
      {
        return this.pagingCookieField;
      }
      set
      {
        this.pagingCookieField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Version
    {
      get
      {
        return this.versionField;
      }
      set
      {
        this.versionField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(WinQuoteResponse))]
  [XmlIncludeAttribute(typeof(WinOpportunityResponse))]
  [XmlIncludeAttribute(typeof(WhoAmIResponse))]
  [XmlIncludeAttribute(typeof(ValidateSavedQueryResponse))]
  [XmlIncludeAttribute(typeof(ValidateResponse))]
  [XmlIncludeAttribute(typeof(UtcTimeFromLocalTimeResponse))]
  [XmlIncludeAttribute(typeof(UpdateUserSettingsSystemUserResponse))]
  [XmlIncludeAttribute(typeof(UpdateResponse))]
  [XmlIncludeAttribute(typeof(UnregisterSolutionResponse))]
  [XmlIncludeAttribute(typeof(UnpublishDuplicateRuleResponse))]
  [XmlIncludeAttribute(typeof(UnlockSalesOrderPricingResponse))]
  [XmlIncludeAttribute(typeof(UnlockInvoicePricingResponse))]
  [XmlIncludeAttribute(typeof(TransformImportResponse))]
  [XmlIncludeAttribute(typeof(StatusUpdateBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(SetStateSystemUserResponse))]
  [XmlIncludeAttribute(typeof(SetStateDynamicEntityResponse))]
  [XmlIncludeAttribute(typeof(SetReportRelatedResponse))]
  [XmlIncludeAttribute(typeof(SetRelatedResponse))]
  [XmlIncludeAttribute(typeof(SetParentTeamResponse))]
  [XmlIncludeAttribute(typeof(SetParentSystemUserResponse))]
  [XmlIncludeAttribute(typeof(SetParentBusinessUnitResponse))]
  [XmlIncludeAttribute(typeof(SetLocLabelsResponse))]
  [XmlIncludeAttribute(typeof(SetBusinessSystemUserResponse))]
  [XmlIncludeAttribute(typeof(SetBusinessEquipmentResponse))]
  [XmlIncludeAttribute(typeof(SendTemplateResponse))]
  [XmlIncludeAttribute(typeof(SendFaxResponse))]
  [XmlIncludeAttribute(typeof(SendEmailResponse))]
  [XmlIncludeAttribute(typeof(SendBulkMailResponse))]
  [XmlIncludeAttribute(typeof(SearchResponse))]
  [XmlIncludeAttribute(typeof(SearchByTitleKbArticleResponse))]
  [XmlIncludeAttribute(typeof(SearchByKeywordsKbArticleResponse))]
  [XmlIncludeAttribute(typeof(SearchByBodyKbArticleResponse))]
  [XmlIncludeAttribute(typeof(RouteResponse))]
  [XmlIncludeAttribute(typeof(RollupResponse))]
  [XmlIncludeAttribute(typeof(RevokeAccessResponse))]
  [XmlIncludeAttribute(typeof(ReviseQuoteResponse))]
  [XmlIncludeAttribute(typeof(RetrieveVersionResponse))]
  [XmlIncludeAttribute(typeof(RetrieveUserSettingsSystemUserResponse))]
  [XmlIncludeAttribute(typeof(RetrieveUserPrivilegesResponse))]
  [XmlIncludeAttribute(typeof(RetrieveTeamsSystemUserResponse))]
  [XmlIncludeAttribute(typeof(RetrieveSubsidiaryUsersBusinessUnitResponse))]
  [XmlIncludeAttribute(typeof(RetrieveSubsidiaryTeamsBusinessUnitResponse))]
  [XmlIncludeAttribute(typeof(RetrieveSubGroupsResourceGroupResponse))]
  [XmlIncludeAttribute(typeof(RetrieveSharedPrincipalsAndAccessResponse))]
  [XmlIncludeAttribute(typeof(RetrieveRolePrivilegesRoleResponse))]
  [XmlIncludeAttribute(typeof(RetrieveResponse))]
  [XmlIncludeAttribute(typeof(RetrieveProvisionedLanguagesResponse))]
  [XmlIncludeAttribute(typeof(RetrievePrivilegeSetResponse))]
  [XmlIncludeAttribute(typeof(RetrievePrincipalAccessResponse))]
  [XmlIncludeAttribute(typeof(RetrieveParsedDataImportFileResponse))]
  [XmlIncludeAttribute(typeof(RetrieveParentGroupsResourceGroupResponse))]
  [XmlIncludeAttribute(typeof(RetrieveMultipleResponse))]
  [XmlIncludeAttribute(typeof(RetrieveMembersTeamResponse))]
  [XmlIncludeAttribute(typeof(RetrieveMembersBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(RetrieveLocLabelsResponse))]
  [XmlIncludeAttribute(typeof(RetrieveLicenseInfoResponse))]
  [XmlIncludeAttribute(typeof(RetrieveInstalledLanguagePacksResponse))]
  [XmlIncludeAttribute(typeof(RetrieveFormXmlResponse))]
  [XmlIncludeAttribute(typeof(RetrieveExchangeRateResponse))]
  [XmlIncludeAttribute(typeof(RetrieveDuplicatesResponse))]
  [XmlIncludeAttribute(typeof(RetrieveDeprovisionedLanguagesResponse))]
  [XmlIncludeAttribute(typeof(RetrieveDeploymentLicenseTypeResponse))]
  [XmlIncludeAttribute(typeof(RetrieveByTopIncidentSubjectKbArticleResponse))]
  [XmlIncludeAttribute(typeof(RetrieveByTopIncidentProductKbArticleResponse))]
  [XmlIncludeAttribute(typeof(RetrieveByResourcesServiceResponse))]
  [XmlIncludeAttribute(typeof(RetrieveByResourceResourceGroupResponse))]
  [XmlIncludeAttribute(typeof(RetrieveByGroupResourceResponse))]
  [XmlIncludeAttribute(typeof(RetrieveBusinessHierarchyBusinessUnitResponse))]
  [XmlIncludeAttribute(typeof(RetrieveAvailableLanguagesResponse))]
  [XmlIncludeAttribute(typeof(RetrieveAllChildUsersSystemUserResponse))]
  [XmlIncludeAttribute(typeof(ResetDataFiltersResponse))]
  [XmlIncludeAttribute(typeof(RescheduleResponse))]
  [XmlIncludeAttribute(typeof(ReplacePrivilegesRoleResponse))]
  [XmlIncludeAttribute(typeof(RenewContractResponse))]
  [XmlIncludeAttribute(typeof(RemoveUserRolesRoleResponse))]
  [XmlIncludeAttribute(typeof(RemoveSubstituteProductResponse))]
  [XmlIncludeAttribute(typeof(RemoveRelatedResponse))]
  [XmlIncludeAttribute(typeof(RemoveProductFromKitResponse))]
  [XmlIncludeAttribute(typeof(RemovePrivilegeRoleResponse))]
  [XmlIncludeAttribute(typeof(RemoveParentResponse))]
  [XmlIncludeAttribute(typeof(RemoveMembersTeamResponse))]
  [XmlIncludeAttribute(typeof(RemoveMemberListResponse))]
  [XmlIncludeAttribute(typeof(RemoveItemCampaignResponse))]
  [XmlIncludeAttribute(typeof(RemoveItemCampaignActivityResponse))]
  [XmlIncludeAttribute(typeof(RegisterSolutionResponse))]
  [XmlIncludeAttribute(typeof(ReassignObjectsSystemUserResponse))]
  [XmlIncludeAttribute(typeof(QueryScheduleResponse))]
  [XmlIncludeAttribute(typeof(QueryMultipleSchedulesResponse))]
  [XmlIncludeAttribute(typeof(QueryExpressionToFetchXmlResponse))]
  [XmlIncludeAttribute(typeof(QualifyMemberListResponse))]
  [XmlIncludeAttribute(typeof(PublishXmlResponse))]
  [XmlIncludeAttribute(typeof(PublishDuplicateRuleResponse))]
  [XmlIncludeAttribute(typeof(PublishAllXmlResponse))]
  [XmlIncludeAttribute(typeof(PropagateByExpressionResponse))]
  [XmlIncludeAttribute(typeof(ProcessOneMemberBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(ProcessInboundEmailResponse))]
  [XmlIncludeAttribute(typeof(ParseImportResponse))]
  [XmlIncludeAttribute(typeof(ModifyAccessResponse))]
  [XmlIncludeAttribute(typeof(MergeResponse))]
  [XmlIncludeAttribute(typeof(MakeUnavailableToOrganizationTemplateResponse))]
  [XmlIncludeAttribute(typeof(MakeUnavailableToOrganizationReportResponse))]
  [XmlIncludeAttribute(typeof(MakeAvailableToOrganizationTemplateResponse))]
  [XmlIncludeAttribute(typeof(MakeAvailableToOrganizationReportResponse))]
  [XmlIncludeAttribute(typeof(LoseOpportunityResponse))]
  [XmlIncludeAttribute(typeof(LogSuccessBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(LogFailureBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(LockSalesOrderPricingResponse))]
  [XmlIncludeAttribute(typeof(LockInvoicePricingResponse))]
  [XmlIncludeAttribute(typeof(LocalTimeFromUtcTimeResponse))]
  [XmlIncludeAttribute(typeof(IsValidStateTransitionResponse))]
  [XmlIncludeAttribute(typeof(IsBackOfficeInstalledResponse))]
  [XmlIncludeAttribute(typeof(InstantiateTemplateResponse))]
  [XmlIncludeAttribute(typeof(InitializeFromResponse))]
  [XmlIncludeAttribute(typeof(ImportXmlWithProgressResponse))]
  [XmlIncludeAttribute(typeof(ImportXmlResponse))]
  [XmlIncludeAttribute(typeof(ImportTranslationsXmlWithProgressResponse))]
  [XmlIncludeAttribute(typeof(ImportRecordsImportResponse))]
  [XmlIncludeAttribute(typeof(ImportCompressedXmlWithProgressResponse))]
  [XmlIncludeAttribute(typeof(ImportCompressedTranslationsXmlWithProgressResponse))]
  [XmlIncludeAttribute(typeof(ImportCompressedAllXmlResponse))]
  [XmlIncludeAttribute(typeof(ImportAllXmlResponse))]
  [XmlIncludeAttribute(typeof(HandleResponse))]
  [XmlIncludeAttribute(typeof(GrantAccessResponse))]
  [XmlIncludeAttribute(typeof(GetTrackingTokenEmailResponse))]
  [XmlIncludeAttribute(typeof(GetTimeZoneCodeByLocalizedNameResponse))]
  [XmlIncludeAttribute(typeof(GetSalesOrderProductsFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(GetReportHistoryLimitResponse))]
  [XmlIncludeAttribute(typeof(GetQuoteProductsFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(GetQuantityDecimalResponse))]
  [XmlIncludeAttribute(typeof(GetInvoiceProductsFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(GetHeaderColumnsImportFileResponse))]
  [XmlIncludeAttribute(typeof(GetDistinctValuesImportFileResponse))]
  [XmlIncludeAttribute(typeof(GetDecryptionKeyResponse))]
  [XmlIncludeAttribute(typeof(GetAllTimeZonesWithDisplayNameResponse))]
  [XmlIncludeAttribute(typeof(GenerateSalesOrderFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(GenerateQuoteFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(GenerateInvoiceFromOpportunityResponse))]
  [XmlIncludeAttribute(typeof(FulfillSalesOrderResponse))]
  [XmlIncludeAttribute(typeof(FindParentResourceGroupResponse))]
  [XmlIncludeAttribute(typeof(FetchXmlToQueryExpressionResponse))]
  [XmlIncludeAttribute(typeof(ExportXmlResponse))]
  [XmlIncludeAttribute(typeof(ExportTranslationsXmlResponse))]
  [XmlIncludeAttribute(typeof(ExportCompressedXmlResponse))]
  [XmlIncludeAttribute(typeof(ExportCompressedTranslationsXmlResponse))]
  [XmlIncludeAttribute(typeof(ExportCompressedAllXmlResponse))]
  [XmlIncludeAttribute(typeof(ExportAllXmlResponse))]
  [XmlIncludeAttribute(typeof(ExpandCalendarResponse))]
  [XmlIncludeAttribute(typeof(ExecuteWorkflowResponse))]
  [XmlIncludeAttribute(typeof(ExecuteFetchResponse))]
  [XmlIncludeAttribute(typeof(ExecuteCampaignActivityResponse))]
  [XmlIncludeAttribute(typeof(ExecuteByIdUserQueryResponse))]
  [XmlIncludeAttribute(typeof(ExecuteByIdSavedQueryResponse))]
  [XmlIncludeAttribute(typeof(DownloadReportDefinitionResponse))]
  [XmlIncludeAttribute(typeof(DistributeCampaignActivityResponse))]
  [XmlIncludeAttribute(typeof(DisassociateEntitiesResponse))]
  [XmlIncludeAttribute(typeof(DetachFromQueueEmailResponse))]
  [XmlIncludeAttribute(typeof(DeliverPromoteEmailResponse))]
  [XmlIncludeAttribute(typeof(DeliverIncomingEmailResponse))]
  [XmlIncludeAttribute(typeof(DeleteResponse))]
  [XmlIncludeAttribute(typeof(CreateWorkflowFromTemplateResponse))]
  [XmlIncludeAttribute(typeof(CreateResponse))]
  [XmlIncludeAttribute(typeof(CreateActivitiesListResponse))]
  [XmlIncludeAttribute(typeof(CopyMembersListResponse))]
  [XmlIncludeAttribute(typeof(CopyCampaignResponse))]
  [XmlIncludeAttribute(typeof(ConvertSalesOrderToInvoiceResponse))]
  [XmlIncludeAttribute(typeof(ConvertQuoteToSalesOrderResponse))]
  [XmlIncludeAttribute(typeof(ConvertProductToKitResponse))]
  [XmlIncludeAttribute(typeof(ConvertKitToProductResponse))]
  [XmlIncludeAttribute(typeof(CompoundUpdateResponse))]
  [XmlIncludeAttribute(typeof(CompoundUpdateDuplicateDetectionRuleResponse))]
  [XmlIncludeAttribute(typeof(CompoundCreateResponse))]
  [XmlIncludeAttribute(typeof(CloseQuoteResponse))]
  [XmlIncludeAttribute(typeof(CloseIncidentResponse))]
  [XmlIncludeAttribute(typeof(CloneContractResponse))]
  [XmlIncludeAttribute(typeof(CleanUpBulkOperationResponse))]
  [XmlIncludeAttribute(typeof(CheckPromoteEmailResponse))]
  [XmlIncludeAttribute(typeof(CheckIncomingEmailResponse))]
  [XmlIncludeAttribute(typeof(CancelSalesOrderResponse))]
  [XmlIncludeAttribute(typeof(CancelContractResponse))]
  [XmlIncludeAttribute(typeof(CalculateTotalTimeIncidentResponse))]
  [XmlIncludeAttribute(typeof(CalculateActualValueOpportunityResponse))]
  [XmlIncludeAttribute(typeof(BulkOperationStatusCloseResponse))]
  [XmlIncludeAttribute(typeof(BulkDetectDuplicatesResponse))]
  [XmlIncludeAttribute(typeof(BulkDeleteResponse))]
  [XmlIncludeAttribute(typeof(BookResponse))]
  [XmlIncludeAttribute(typeof(BackgroundSendEmailResponse))]
  [XmlIncludeAttribute(typeof(AutoMapEntityResponse))]
  [XmlIncludeAttribute(typeof(AssociateEntitiesResponse))]
  [XmlIncludeAttribute(typeof(AssignUserRolesRoleResponse))]
  [XmlIncludeAttribute(typeof(AssignResponse))]
  [XmlIncludeAttribute(typeof(AddSubstituteProductResponse))]
  [XmlIncludeAttribute(typeof(AddProductToKitResponse))]
  [XmlIncludeAttribute(typeof(AddPrivilegesRoleResponse))]
  [XmlIncludeAttribute(typeof(AddMembersTeamResponse))]
  [XmlIncludeAttribute(typeof(AddMemberListResponse))]
  [XmlIncludeAttribute(typeof(AddItemCampaignResponse))]
  [XmlIncludeAttribute(typeof(AddItemCampaignActivityResponse))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WinQuoteResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WinOpportunityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WhoAmIResponse : Response
  {

    private Guid userIdField;

    private Guid businessUnitIdField;

    private Guid organizationIdField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public Guid BusinessUnitId
    {
      get
      {
        return this.businessUnitIdField;
      }
      set
      {
        this.businessUnitIdField = value;
      }
    }

    /// <remarks/>
    public Guid OrganizationId
    {
      get
      {
        return this.organizationIdField;
      }
      set
      {
        this.organizationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ValidateSavedQueryResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ValidateResponse : Response
  {

    private ValidationResult[] resultField;

    /// <remarks/>
    public ValidationResult[] Result
    {
      get
      {
        return this.resultField;
      }
      set
      {
        this.resultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class ValidationResult
  {

    private bool validationSuccessField;

    private TraceInfo traceInfoField;

    private Guid activityIdField;

    /// <remarks/>
    public bool ValidationSuccess
    {
      get
      {
        return this.validationSuccessField;
      }
      set
      {
        this.validationSuccessField = value;
      }
    }

    /// <remarks/>
    public TraceInfo TraceInfo
    {
      get
      {
        return this.traceInfoField;
      }
      set
      {
        this.traceInfoField = value;
      }
    }

    /// <remarks/>
    public Guid ActivityId
    {
      get
      {
        return this.activityIdField;
      }
      set
      {
        this.activityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UtcTimeFromLocalTimeResponse : Response
  {

    private CrmDateTime utcTimeField;

    /// <remarks/>
    public CrmDateTime UtcTime
    {
      get
      {
        return this.utcTimeField;
      }
      set
      {
        this.utcTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UpdateUserSettingsSystemUserResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UpdateResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnregisterSolutionResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnpublishDuplicateRuleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnlockSalesOrderPricingResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnlockInvoicePricingResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TransformImportResponse : Response
  {

    private Guid asyncOperationIdField;

    /// <remarks/>
    public Guid AsyncOperationId
    {
      get
      {
        return this.asyncOperationIdField;
      }
      set
      {
        this.asyncOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class StatusUpdateBulkOperationResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetStateSystemUserResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetStateDynamicEntityResponse : Response
  {
  }


  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetReportRelatedResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetRelatedResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentTeamResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentSystemUserResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentBusinessUnitResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetLocLabelsResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetBusinessSystemUserResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetBusinessEquipmentResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendTemplateResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendFaxResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendEmailResponse : Response
  {

    private string subjectField;

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendBulkMailResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchResponse : Response
  {

    private SearchResults searchResultsField;

    /// <remarks/>
    public SearchResults SearchResults
    {
      get
      {
        return this.searchResultsField;
      }
      set
      {
        this.searchResultsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByTitleKbArticleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByKeywordsKbArticleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByBodyKbArticleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RouteResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RollupResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RevokeAccessResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReviseQuoteResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveVersionResponse : Response
  {

    private string versionField;

    /// <remarks/>
    public string Version
    {
      get
      {
        return this.versionField;
      }
      set
      {
        this.versionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveUserSettingsSystemUserResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveUserPrivilegesResponse : Response
  {

    private RolePrivilege[] rolePrivilegesField;

    /// <remarks/>
    public RolePrivilege[] RolePrivileges
    {
      get
      {
        return this.rolePrivilegesField;
      }
      set
      {
        this.rolePrivilegesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class RolePrivilege
  {

    private PrivilegeDepth depthField;

    private Guid privilegeIdField;

    /// <remarks/>
    public PrivilegeDepth Depth
    {
      get
      {
        return this.depthField;
      }
      set
      {
        this.depthField = value;
      }
    }

    /// <remarks/>
    public Guid PrivilegeId
    {
      get
      {
        return this.privilegeIdField;
      }
      set
      {
        this.privilegeIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum PrivilegeDepth
  {

    /// <remarks/>
    Basic,

    /// <remarks/>
    Local,

    /// <remarks/>
    Deep,

    /// <remarks/>
    Global,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveTeamsSystemUserResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubsidiaryUsersBusinessUnitResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubsidiaryTeamsBusinessUnitResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubGroupsResourceGroupResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSharedPrincipalsAndAccessResponse : Response
  {

    private PrincipalAccess[] principalAccessesField;

    /// <remarks/>
    public PrincipalAccess[] PrincipalAccesses
    {
      get
      {
        return this.principalAccessesField;
      }
      set
      {
        this.principalAccessesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class PrincipalAccess
  {

    private SecurityPrincipal principalField;

    private AccessRights accessMaskField;

    /// <remarks/>
    public SecurityPrincipal Principal
    {
      get
      {
        return this.principalField;
      }
      set
      {
        this.principalField = value;
      }
    }

    /// <remarks/>
    public AccessRights AccessMask
    {
      get
      {
        return this.accessMaskField;
      }
      set
      {
        this.accessMaskField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class SecurityPrincipal
  {

    private Guid principalIdField;

    private SecurityPrincipalType typeField;

    /// <remarks/>
    public Guid PrincipalId
    {
      get
      {
        return this.principalIdField;
      }
      set
      {
        this.principalIdField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipalType Type
    {
      get
      {
        return this.typeField;
      }
      set
      {
        this.typeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum SecurityPrincipalType
  {

    /// <remarks/>
    User,

    /// <remarks/>
    Team,
  }

  /// <remarks/>
  [FlagsAttribute()]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum AccessRights
  {

    /// <remarks/>
    ReadAccess = 1,

    /// <remarks/>
    WriteAccess = 2,

    /// <remarks/>
    AppendAccess = 4,

    /// <remarks/>
    AppendToAccess = 8,

    /// <remarks/>
    CreateAccess = 16,

    /// <remarks/>
    DeleteAccess = 32,

    /// <remarks/>
    ShareAccess = 64,

    /// <remarks/>
    AssignAccess = 128,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveRolePrivilegesRoleResponse : Response
  {

    private RolePrivilege[] rolePrivilegesField;

    /// <remarks/>
    public RolePrivilege[] RolePrivileges
    {
      get
      {
        return this.rolePrivilegesField;
      }
      set
      {
        this.rolePrivilegesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveProvisionedLanguagesResponse : Response
  {

    private int[] retrieveProvisionedLanguagesField;

    /// <remarks/>
    public int[] RetrieveProvisionedLanguages
    {
      get
      {
        return this.retrieveProvisionedLanguagesField;
      }
      set
      {
        this.retrieveProvisionedLanguagesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrievePrivilegeSetResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrievePrincipalAccessResponse : Response
  {

    private AccessRights accessRightsField;

    /// <remarks/>
    public AccessRights AccessRights
    {
      get
      {
        return this.accessRightsField;
      }
      set
      {
        this.accessRightsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveParsedDataImportFileResponse : Response
  {

    private string[][] valuesField;

    /// <remarks/>
    [XmlArrayItemAttribute("ArrayOfString")]
    [XmlArrayItemAttribute(NestingLevel = 1)]
    public string[][] Values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveParentGroupsResourceGroupResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMultipleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMembersTeamResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMembersBulkOperationResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveLocLabelsResponse : Response
  {

    private CrmLabel labelField;

    /// <remarks/>
    public CrmLabel Label
    {
      get
      {
        return this.labelField;
      }
      set
      {
        this.labelField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CrmLabel
  {

    private LocLabel[] locLabelsField;

    private LocLabel userLocLabelField;

    /// <remarks/>
    public LocLabel[] LocLabels
    {
      get
      {
        return this.locLabelsField;
      }
      set
      {
        this.locLabelsField = value;
      }
    }

    /// <remarks/>
    public LocLabel UserLocLabel
    {
      get
      {
        return this.userLocLabelField;
      }
      set
      {
        this.userLocLabelField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LocLabel
  {

    private string labelField;

    private CrmNumber languageCodeField;

    /// <remarks/>
    public string Label
    {
      get
      {
        return this.labelField;
      }
      set
      {
        this.labelField = value;
      }
    }

    /// <remarks/>
    public CrmNumber LanguageCode
    {
      get
      {
        return this.languageCodeField;
      }
      set
      {
        this.languageCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveLicenseInfoResponse : Response
  {

    private int availableCountField;

    private int grantedLicenseCountField;

    /// <remarks/>
    public int AvailableCount
    {
      get
      {
        return this.availableCountField;
      }
      set
      {
        this.availableCountField = value;
      }
    }

    /// <remarks/>
    public int GrantedLicenseCount
    {
      get
      {
        return this.grantedLicenseCountField;
      }
      set
      {
        this.grantedLicenseCountField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveInstalledLanguagePacksResponse : Response
  {

    private int[] retrieveInstalledLanguagePacksField;

    /// <remarks/>
    public int[] RetrieveInstalledLanguagePacks
    {
      get
      {
        return this.retrieveInstalledLanguagePacksField;
      }
      set
      {
        this.retrieveInstalledLanguagePacksField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveFormXmlResponse : Response
  {

    private string formXmlField;

    private int customizationLevelField;

    /// <remarks/>
    public string FormXml
    {
      get
      {
        return this.formXmlField;
      }
      set
      {
        this.formXmlField = value;
      }
    }

    /// <remarks/>
    public int CustomizationLevel
    {
      get
      {
        return this.customizationLevelField;
      }
      set
      {
        this.customizationLevelField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveExchangeRateResponse : Response
  {

    private decimal exchangeRateField;

    /// <remarks/>
    public decimal ExchangeRate
    {
      get
      {
        return this.exchangeRateField;
      }
      set
      {
        this.exchangeRateField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDuplicatesResponse : Response
  {

    private BusinessEntityCollection duplicateCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection DuplicateCollection
    {
      get
      {
        return this.duplicateCollectionField;
      }
      set
      {
        this.duplicateCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDeprovisionedLanguagesResponse : Response
  {

    private int[] retrieveDeprovisionedLanguagesField;

    /// <remarks/>
    public int[] RetrieveDeprovisionedLanguages
    {
      get
      {
        return this.retrieveDeprovisionedLanguagesField;
      }
      set
      {
        this.retrieveDeprovisionedLanguagesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDeploymentLicenseTypeResponse : Response
  {

    private string licenseTypeField;

    /// <remarks/>
    public string licenseType
    {
      get
      {
        return this.licenseTypeField;
      }
      set
      {
        this.licenseTypeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByTopIncidentSubjectKbArticleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByTopIncidentProductKbArticleResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByResourcesServiceResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByResourceResourceGroupResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByGroupResourceResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveBusinessHierarchyBusinessUnitResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveAvailableLanguagesResponse : Response
  {

    private int[] localeIdsField;

    /// <remarks/>
    public int[] LocaleIds
    {
      get
      {
        return this.localeIdsField;
      }
      set
      {
        this.localeIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveAllChildUsersSystemUserResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ResetDataFiltersResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RescheduleResponse : Response
  {

    private ValidationResult validationResultField;

    /// <remarks/>
    public ValidationResult ValidationResult
    {
      get
      {
        return this.validationResultField;
      }
      set
      {
        this.validationResultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReplacePrivilegesRoleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RenewContractResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveUserRolesRoleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveSubstituteProductResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveRelatedResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveProductFromKitResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemovePrivilegeRoleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveParentResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveMembersTeamResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveMemberListResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveItemCampaignResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveItemCampaignActivityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RegisterSolutionResponse : Response
  {

    private Guid pluginAssemblyIdField;

    /// <remarks/>
    public Guid PluginAssemblyId
    {
      get
      {
        return this.pluginAssemblyIdField;
      }
      set
      {
        this.pluginAssemblyIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReassignObjectsSystemUserResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryScheduleResponse : Response
  {

    private TimeInfo[] timeInfosField;

    /// <remarks/>
    public TimeInfo[] TimeInfos
    {
      get
      {
        return this.timeInfosField;
      }
      set
      {
        this.timeInfosField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class TimeInfo
  {

    private CrmDateTime startField;

    private CrmDateTime endField;

    private TimeCode timeCodeField;

    private SubCode subCodeField;

    private Guid sourceIdField;

    private Guid calendarIdField;

    private int sourceTypeCodeField;

    private bool isActivityField;

    private int activityStatusCodeField;

    private double effortField;

    private string displayTextField;

    /// <remarks/>
    public CrmDateTime Start
    {
      get
      {
        return this.startField;
      }
      set
      {
        this.startField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime End
    {
      get
      {
        return this.endField;
      }
      set
      {
        this.endField = value;
      }
    }

    /// <remarks/>
    public TimeCode TimeCode
    {
      get
      {
        return this.timeCodeField;
      }
      set
      {
        this.timeCodeField = value;
      }
    }

    /// <remarks/>
    public SubCode SubCode
    {
      get
      {
        return this.subCodeField;
      }
      set
      {
        this.subCodeField = value;
      }
    }

    /// <remarks/>
    public Guid SourceId
    {
      get
      {
        return this.sourceIdField;
      }
      set
      {
        this.sourceIdField = value;
      }
    }

    /// <remarks/>
    public Guid CalendarId
    {
      get
      {
        return this.calendarIdField;
      }
      set
      {
        this.calendarIdField = value;
      }
    }

    /// <remarks/>
    public int SourceTypeCode
    {
      get
      {
        return this.sourceTypeCodeField;
      }
      set
      {
        this.sourceTypeCodeField = value;
      }
    }

    /// <remarks/>
    public bool IsActivity
    {
      get
      {
        return this.isActivityField;
      }
      set
      {
        this.isActivityField = value;
      }
    }

    /// <remarks/>
    public int ActivityStatusCode
    {
      get
      {
        return this.activityStatusCodeField;
      }
      set
      {
        this.activityStatusCodeField = value;
      }
    }

    /// <remarks/>
    public double Effort
    {
      get
      {
        return this.effortField;
      }
      set
      {
        this.effortField = value;
      }
    }

    /// <remarks/>
    public string DisplayText
    {
      get
      {
        return this.displayTextField;
      }
      set
      {
        this.displayTextField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  public enum TimeCode
  {

    /// <remarks/>
    Available,

    /// <remarks/>
    Busy,

    /// <remarks/>
    Unavailable,

    /// <remarks/>
    Filter,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  public enum SubCode
  {

    /// <remarks/>
    Unspecified,

    /// <remarks/>
    Schedulable,

    /// <remarks/>
    Committed,

    /// <remarks/>
    Uncommitted,

    /// <remarks/>
    Break,

    /// <remarks/>
    Holiday,

    /// <remarks/>
    Vacation,

    /// <remarks/>
    Appointment,

    /// <remarks/>
    ResourceStartTime,

    /// <remarks/>
    ResourceServiceRestriction,

    /// <remarks/>
    ResourceCapacity,

    /// <remarks/>
    ServiceRestriction,

    /// <remarks/>
    ServiceCost,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryMultipleSchedulesResponse : Response
  {

    private TimeInfo[][] timeInfosField;

    /// <remarks/>
    [XmlArrayItemAttribute("ArrayOfTimeInfo")]
    [XmlArrayItemAttribute(NestingLevel = 1)]
    public TimeInfo[][] TimeInfos
    {
      get
      {
        return this.timeInfosField;
      }
      set
      {
        this.timeInfosField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryExpressionToFetchXmlResponse : Response
  {

    private string fetchXmlField;

    /// <remarks/>
    public string FetchXml
    {
      get
      {
        return this.fetchXmlField;
      }
      set
      {
        this.fetchXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QualifyMemberListResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishXmlResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishDuplicateRuleResponse : Response
  {

    private Guid jobIdField;

    /// <remarks/>
    public Guid JobId
    {
      get
      {
        return this.jobIdField;
      }
      set
      {
        this.jobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishAllXmlResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PropagateByExpressionResponse : Response
  {

    private Guid bulkOperationIdField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ProcessOneMemberBulkOperationResponse : Response
  {

    private int processResultField;

    /// <remarks/>
    public int ProcessResult
    {
      get
      {
        return this.processResultField;
      }
      set
      {
        this.processResultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ProcessInboundEmailResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ParseImportResponse : Response
  {

    private Guid asyncOperationIdField;

    /// <remarks/>
    public Guid AsyncOperationId
    {
      get
      {
        return this.asyncOperationIdField;
      }
      set
      {
        this.asyncOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ModifyAccessResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MergeResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeUnavailableToOrganizationTemplateResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeUnavailableToOrganizationReportResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeAvailableToOrganizationTemplateResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeAvailableToOrganizationReportResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LoseOpportunityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LogSuccessBulkOperationResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LogFailureBulkOperationResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LockSalesOrderPricingResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LockInvoicePricingResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LocalTimeFromUtcTimeResponse : Response
  {

    private CrmDateTime localTimeField;

    /// <remarks/>
    public CrmDateTime LocalTime
    {
      get
      {
        return this.localTimeField;
      }
      set
      {
        this.localTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class IsValidStateTransitionResponse : Response
  {

    private bool isValidField;

    /// <remarks/>
    public bool IsValid
    {
      get
      {
        return this.isValidField;
      }
      set
      {
        this.isValidField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class IsBackOfficeInstalledResponse : Response
  {

    private bool isInstalledField;

    /// <remarks/>
    public bool IsInstalled
    {
      get
      {
        return this.isInstalledField;
      }
      set
      {
        this.isInstalledField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class InstantiateTemplateResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class InitializeFromResponse : Response
  {

    private BusinessEntity entityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportXmlWithProgressResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportXmlResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportTranslationsXmlWithProgressResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportRecordsImportResponse : Response
  {

    private Guid asyncOperationIdField;

    /// <remarks/>
    public Guid AsyncOperationId
    {
      get
      {
        return this.asyncOperationIdField;
      }
      set
      {
        this.asyncOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedXmlWithProgressResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedTranslationsXmlWithProgressResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedAllXmlResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportAllXmlResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class HandleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GrantAccessResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetTrackingTokenEmailResponse : Response
  {

    private string trackingTokenField;

    /// <remarks/>
    public string TrackingToken
    {
      get
      {
        return this.trackingTokenField;
      }
      set
      {
        this.trackingTokenField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetTimeZoneCodeByLocalizedNameResponse : Response
  {

    private int timeZoneCodeField;

    /// <remarks/>
    public int TimeZoneCode
    {
      get
      {
        return this.timeZoneCodeField;
      }
      set
      {
        this.timeZoneCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetSalesOrderProductsFromOpportunityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetReportHistoryLimitResponse : Response
  {

    private int historyLimitField;

    /// <remarks/>
    public int HistoryLimit
    {
      get
      {
        return this.historyLimitField;
      }
      set
      {
        this.historyLimitField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetQuoteProductsFromOpportunityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetQuantityDecimalResponse : Response
  {

    private int quantityField;

    /// <remarks/>
    public int Quantity
    {
      get
      {
        return this.quantityField;
      }
      set
      {
        this.quantityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetInvoiceProductsFromOpportunityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetHeaderColumnsImportFileResponse : Response
  {

    private string[] columnsField;

    /// <remarks/>
    public string[] Columns
    {
      get
      {
        return this.columnsField;
      }
      set
      {
        this.columnsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetDistinctValuesImportFileResponse : Response
  {

    private string[] valuesField;

    /// <remarks/>
    public string[] Values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetDecryptionKeyResponse : Response
  {

    private string keyField;

    /// <remarks/>
    public string Key
    {
      get
      {
        return this.keyField;
      }
      set
      {
        this.keyField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetAllTimeZonesWithDisplayNameResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateSalesOrderFromOpportunityResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateQuoteFromOpportunityResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateInvoiceFromOpportunityResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FulfillSalesOrderResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FindParentResourceGroupResponse : Response
  {

    private bool resultField;

    /// <remarks/>
    public bool result
    {
      get
      {
        return this.resultField;
      }
      set
      {
        this.resultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FetchXmlToQueryExpressionResponse : Response
  {

    private QueryExpression queryField;

    /// <remarks/>
    public QueryExpression Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportXmlResponse : Response
  {

    private string exportXmlField;

    /// <remarks/>
    public string ExportXml
    {
      get
      {
        return this.exportXmlField;
      }
      set
      {
        this.exportXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportTranslationsXmlResponse : Response
  {

    private string exportXmlField;

    /// <remarks/>
    public string ExportXml
    {
      get
      {
        return this.exportXmlField;
      }
      set
      {
        this.exportXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedXmlResponse : Response
  {

    private byte[] exportCompressedXmlField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] ExportCompressedXml
    {
      get
      {
        return this.exportCompressedXmlField;
      }
      set
      {
        this.exportCompressedXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedTranslationsXmlResponse : Response
  {

    private byte[] exportCompressedXmlField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] ExportCompressedXml
    {
      get
      {
        return this.exportCompressedXmlField;
      }
      set
      {
        this.exportCompressedXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedAllXmlResponse : Response
  {

    private byte[] exportCompressedXmlField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] ExportCompressedXml
    {
      get
      {
        return this.exportCompressedXmlField;
      }
      set
      {
        this.exportCompressedXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportAllXmlResponse : Response
  {

    private string exportXmlField;

    /// <remarks/>
    public string ExportXml
    {
      get
      {
        return this.exportXmlField;
      }
      set
      {
        this.exportXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExpandCalendarResponse : Response
  {

    private TimeInfo[] resultField;

    /// <remarks/>
    public TimeInfo[] result
    {
      get
      {
        return this.resultField;
      }
      set
      {
        this.resultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteWorkflowResponse : Response
  {

    private Guid idField;

    /// <remarks/>
    public Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteFetchResponse : Response
  {

    private string fetchXmlResultField;

    /// <remarks/>
    public string FetchXmlResult
    {
      get
      {
        return this.fetchXmlResultField;
      }
      set
      {
        this.fetchXmlResultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteCampaignActivityResponse : Response
  {

    private Guid bulkOperationIdField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteByIdUserQueryResponse : Response
  {

    private string stringField;

    /// <remarks/>
    public string String
    {
      get
      {
        return this.stringField;
      }
      set
      {
        this.stringField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteByIdSavedQueryResponse : Response
  {

    private string stringField;

    /// <remarks/>
    public string String
    {
      get
      {
        return this.stringField;
      }
      set
      {
        this.stringField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DownloadReportDefinitionResponse : Response
  {

    private string bodyTextField;

    /// <remarks/>
    public string BodyText
    {
      get
      {
        return this.bodyTextField;
      }
      set
      {
        this.bodyTextField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DistributeCampaignActivityResponse : Response
  {

    private Guid bulkOperationIdField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DisassociateEntitiesResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DetachFromQueueEmailResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeliverPromoteEmailResponse : Response
  {

    private Guid emailIdField;

    /// <remarks/>
    public Guid EmailId
    {
      get
      {
        return this.emailIdField;
      }
      set
      {
        this.emailIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeliverIncomingEmailResponse : Response
  {

    private Guid emailIdField;

    /// <remarks/>
    public Guid EmailId
    {
      get
      {
        return this.emailIdField;
      }
      set
      {
        this.emailIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeleteResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateWorkflowFromTemplateResponse : Response
  {

    private Guid idField;

    /// <remarks/>
    public Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateResponse : Response
  {

    private Guid idField;

    /// <remarks/>
    public Guid id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateActivitiesListResponse : Response
  {

    private Guid bulkOperationIdField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CopyMembersListResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CopyCampaignResponse : Response
  {

    private Guid campaignCopyIdField;

    /// <remarks/>
    public Guid CampaignCopyId
    {
      get
      {
        return this.campaignCopyIdField;
      }
      set
      {
        this.campaignCopyIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertSalesOrderToInvoiceResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertQuoteToSalesOrderResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertProductToKitResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertKitToProductResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundUpdateResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundUpdateDuplicateDetectionRuleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundCreateResponse : Response
  {

    private Guid idField;

    /// <remarks/>
    public Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloseQuoteResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloseIncidentResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloneContractResponse : Response
  {

    private BusinessEntity businessEntityField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CleanUpBulkOperationResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CheckPromoteEmailResponse : Response
  {

    private bool shouldPromoteField;

    private int reasonCodeField;

    /// <remarks/>
    public bool ShouldPromote
    {
      get
      {
        return this.shouldPromoteField;
      }
      set
      {
        this.shouldPromoteField = value;
      }
    }

    /// <remarks/>
    public int ReasonCode
    {
      get
      {
        return this.reasonCodeField;
      }
      set
      {
        this.reasonCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CheckIncomingEmailResponse : Response
  {

    private bool shouldDeliverField;

    private int reasonCodeField;

    /// <remarks/>
    public bool ShouldDeliver
    {
      get
      {
        return this.shouldDeliverField;
      }
      set
      {
        this.shouldDeliverField = value;
      }
    }

    /// <remarks/>
    public int ReasonCode
    {
      get
      {
        return this.reasonCodeField;
      }
      set
      {
        this.reasonCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CancelSalesOrderResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CancelContractResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CalculateTotalTimeIncidentResponse : Response
  {

    private long totalTimeField;

    /// <remarks/>
    public long TotalTime
    {
      get
      {
        return this.totalTimeField;
      }
      set
      {
        this.totalTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CalculateActualValueOpportunityResponse : Response
  {

    private decimal valueField;

    /// <remarks/>
    public decimal Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkOperationStatusCloseResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkDetectDuplicatesResponse : Response
  {

    private Guid jobIdField;

    /// <remarks/>
    public Guid JobId
    {
      get
      {
        return this.jobIdField;
      }
      set
      {
        this.jobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkDeleteResponse : Response
  {

    private Guid jobIdField;

    /// <remarks/>
    public Guid JobId
    {
      get
      {
        return this.jobIdField;
      }
      set
      {
        this.jobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BookResponse : Response
  {

    private ValidationResult validationResultField;

    /// <remarks/>
    public ValidationResult ValidationResult
    {
      get
      {
        return this.validationResultField;
      }
      set
      {
        this.validationResultField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BackgroundSendEmailResponse : Response
  {

    private BusinessEntityCollection businessEntityCollectionField;

    private bool[] hasAttachmentsField;

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    public BusinessEntityCollection BusinessEntityCollection
    {
      get
      {
        return this.businessEntityCollectionField;
      }
      set
      {
        this.businessEntityCollectionField = value;
      }
    }

    /// <remarks/>
    public bool[] HasAttachments
    {
      get
      {
        return this.hasAttachmentsField;
      }
      set
      {
        this.hasAttachmentsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AutoMapEntityResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssociateEntitiesResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssignUserRolesRoleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssignResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddSubstituteProductResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddProductToKitResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddPrivilegesRoleResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddMembersTeamResponse : Response
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddMemberListResponse : Response
  {

    private System.Guid idField;

    /// <remarks/>
    public System.Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddItemCampaignResponse : Response
  {

    private System.Guid campaignItemIdField;

    /// <remarks/>
    public System.Guid CampaignItemId
    {
      get
      {
        return this.campaignItemIdField;
      }
      set
      {
        this.campaignItemIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddItemCampaignActivityResponse : Response
  {

    private Guid campaignActivityItemIdField;

    /// <remarks/>
    public Guid CampaignActivityItemId
    {
      get
      {
        return this.campaignActivityItemIdField;
      }
      set
      {
        this.campaignActivityItemIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SdkMessageProcessingStepRegistration
  {

    private string messageNameField;

    private string primaryEntityNameField;

    private string secondaryEntityNameField;

    private string descriptionField;

    private int stageField;

    private int modeField;

    private Guid impersonatingUserIdField;

    private int supportedDeploymentField;

    private string filteringAttributesField;

    private string pluginTypeFriendlyNameField;

    private string pluginTypeNameField;

    private string customConfigurationField;

    private int invocationSourceField;

    private SdkMessageProcessingStepImageRegistration[] imagesField;

    /// <remarks/>
    public string MessageName
    {
      get
      {
        return this.messageNameField;
      }
      set
      {
        this.messageNameField = value;
      }
    }

    /// <remarks/>
    public string PrimaryEntityName
    {
      get
      {
        return this.primaryEntityNameField;
      }
      set
      {
        this.primaryEntityNameField = value;
      }
    }

    /// <remarks/>
    public string SecondaryEntityName
    {
      get
      {
        return this.secondaryEntityNameField;
      }
      set
      {
        this.secondaryEntityNameField = value;
      }
    }

    /// <remarks/>
    public string Description
    {
      get
      {
        return this.descriptionField;
      }
      set
      {
        this.descriptionField = value;
      }
    }

    /// <remarks/>
    public int Stage
    {
      get
      {
        return this.stageField;
      }
      set
      {
        this.stageField = value;
      }
    }

    /// <remarks/>
    public int Mode
    {
      get
      {
        return this.modeField;
      }
      set
      {
        this.modeField = value;
      }
    }

    /// <remarks/>
    public Guid ImpersonatingUserId
    {
      get
      {
        return this.impersonatingUserIdField;
      }
      set
      {
        this.impersonatingUserIdField = value;
      }
    }

    /// <remarks/>
    public int SupportedDeployment
    {
      get
      {
        return this.supportedDeploymentField;
      }
      set
      {
        this.supportedDeploymentField = value;
      }
    }

    /// <remarks/>
    public string FilteringAttributes
    {
      get
      {
        return this.filteringAttributesField;
      }
      set
      {
        this.filteringAttributesField = value;
      }
    }

    /// <remarks/>
    public string PluginTypeFriendlyName
    {
      get
      {
        return this.pluginTypeFriendlyNameField;
      }
      set
      {
        this.pluginTypeFriendlyNameField = value;
      }
    }

    /// <remarks/>
    public string PluginTypeName
    {
      get
      {
        return this.pluginTypeNameField;
      }
      set
      {
        this.pluginTypeNameField = value;
      }
    }

    /// <remarks/>
    public string CustomConfiguration
    {
      get
      {
        return this.customConfigurationField;
      }
      set
      {
        this.customConfigurationField = value;
      }
    }

    /// <remarks/>
    public int InvocationSource
    {
      get
      {
        return this.invocationSourceField;
      }
      set
      {
        this.invocationSourceField = value;
      }
    }

    /// <remarks/>
    public SdkMessageProcessingStepImageRegistration[] Images
    {
      get
      {
        return this.imagesField;
      }
      set
      {
        this.imagesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SdkMessageProcessingStepImageRegistration
  {

    private string messagePropertyNameField;

    private string[] attributesField;

    private string entityAliasField;

    private int imageTypeField;

    /// <remarks/>
    public string MessagePropertyName
    {
      get
      {
        return this.messagePropertyNameField;
      }
      set
      {
        this.messagePropertyNameField = value;
      }
    }

    /// <remarks/>
    public string[] Attributes
    {
      get
      {
        return this.attributesField;
      }
      set
      {
        this.attributesField = value;
      }
    }

    /// <remarks/>
    public string EntityAlias
    {
      get
      {
        return this.entityAliasField;
      }
      set
      {
        this.entityAliasField = value;
      }
    }

    /// <remarks/>
    public int ImageType
    {
      get
      {
        return this.imageTypeField;
      }
      set
      {
        this.imageTypeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class Moniker
  {

    private Guid idField;

    private string nameField;

    /// <remarks/>
    public Guid Id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }

    /// <remarks/>
    public string Name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(TargetOwnedDynamic))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class TargetOwned
  {
  }


  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TargetOwnedDynamic : TargetOwned
  {

    private string entityNameField;

    private Guid entityIdField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(RequestIdOptionalParameter))]
  [XmlIncludeAttribute(typeof(RegardingObjectIdOptionalParameter))]
  [XmlIncludeAttribute(typeof(PersistInSyncOptionalParameter))]
  [XmlIncludeAttribute(typeof(OfflineDataOptionalParameter))]
  [XmlIncludeAttribute(typeof(ExportIdsOptionalParameter))]
  [XmlIncludeAttribute(typeof(CreateDuplicatesOptionalParameter))]
  [XmlIncludeAttribute(typeof(CallPriorityOptionalParameter))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class OptionalParameter
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RequestIdOptionalParameter : OptionalParameter
  {

    private Guid valueField;

    /// <remarks/>
    public Guid Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RegardingObjectIdOptionalParameter : OptionalParameter
  {

    private Guid valueField;

    /// <remarks/>
    public Guid Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PersistInSyncOptionalParameter : OptionalParameter
  {

    private bool valueField;

    /// <remarks/>
    public bool Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class OfflineDataOptionalParameter : OptionalParameter
  {

    private string nameField;

    private string valueField;

    /// <remarks/>
    public string Name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportIdsOptionalParameter : OptionalParameter
  {

    private bool valueField;

    /// <remarks/>
    public bool Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateDuplicatesOptionalParameter : OptionalParameter
  {

    private bool valueField;

    /// <remarks/>
    public bool Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CallPriorityOptionalParameter : OptionalParameter
  {

    private int valueField;

    /// <remarks/>
    public int Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }

  /// <remarks/>
  [XmlIncludeAttribute(typeof(WinQuoteRequest))]
  [XmlIncludeAttribute(typeof(WinOpportunityRequest))]
  [XmlIncludeAttribute(typeof(WhoAmIRequest))]
  [XmlIncludeAttribute(typeof(ValidateSavedQueryRequest))]
  [XmlIncludeAttribute(typeof(ValidateRequest))]
  [XmlIncludeAttribute(typeof(UtcTimeFromLocalTimeRequest))]
  [XmlIncludeAttribute(typeof(UpdateUserSettingsSystemUserRequest))]
  [XmlIncludeAttribute(typeof(UpdateRequest))]
  [XmlIncludeAttribute(typeof(UnregisterSolutionRequest))]
  [XmlIncludeAttribute(typeof(UnpublishDuplicateRuleRequest))]
  [XmlIncludeAttribute(typeof(UnlockSalesOrderPricingRequest))]
  [XmlIncludeAttribute(typeof(UnlockInvoicePricingRequest))]
  [XmlIncludeAttribute(typeof(TransformImportRequest))]
  [XmlIncludeAttribute(typeof(StatusUpdateBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(SetStateSystemUserRequest))]
  [XmlIncludeAttribute(typeof(SetStateDynamicEntityRequest))]
  [XmlIncludeAttribute(typeof(SetReportRelatedRequest))]
  [XmlIncludeAttribute(typeof(SetRelatedRequest))]
  [XmlIncludeAttribute(typeof(SetParentTeamRequest))]
  [XmlIncludeAttribute(typeof(SetParentSystemUserRequest))]
  [XmlIncludeAttribute(typeof(SetParentBusinessUnitRequest))]
  [XmlIncludeAttribute(typeof(SetLocLabelsRequest))]
  [XmlIncludeAttribute(typeof(SetBusinessSystemUserRequest))]
  [XmlIncludeAttribute(typeof(SetBusinessEquipmentRequest))]
  [XmlIncludeAttribute(typeof(SendTemplateRequest))]
  [XmlIncludeAttribute(typeof(SendFaxRequest))]
  [XmlIncludeAttribute(typeof(SendEmailRequest))]
  [XmlIncludeAttribute(typeof(SendBulkMailRequest))]
  [XmlIncludeAttribute(typeof(SearchRequest))]
  [XmlIncludeAttribute(typeof(SearchByTitleKbArticleRequest))]
  [XmlIncludeAttribute(typeof(SearchByKeywordsKbArticleRequest))]
  [XmlIncludeAttribute(typeof(SearchByBodyKbArticleRequest))]
  [XmlIncludeAttribute(typeof(RouteRequest))]
  [XmlIncludeAttribute(typeof(RollupRequest))]
  [XmlIncludeAttribute(typeof(RevokeAccessRequest))]
  [XmlIncludeAttribute(typeof(ReviseQuoteRequest))]
  [XmlIncludeAttribute(typeof(RetrieveVersionRequest))]
  [XmlIncludeAttribute(typeof(RetrieveUserSettingsSystemUserRequest))]
  [XmlIncludeAttribute(typeof(RetrieveUserPrivilegesRequest))]
  [XmlIncludeAttribute(typeof(RetrieveTeamsSystemUserRequest))]
  [XmlIncludeAttribute(typeof(RetrieveSubsidiaryUsersBusinessUnitRequest))]
  [XmlIncludeAttribute(typeof(RetrieveSubsidiaryTeamsBusinessUnitRequest))]
  [XmlIncludeAttribute(typeof(RetrieveSubGroupsResourceGroupRequest))]
  [XmlIncludeAttribute(typeof(RetrieveSharedPrincipalsAndAccessRequest))]
  [XmlIncludeAttribute(typeof(RetrieveRolePrivilegesRoleRequest))]
  [XmlIncludeAttribute(typeof(RetrieveRequest))]
  [XmlIncludeAttribute(typeof(RetrieveProvisionedLanguagesRequest))]
  [XmlIncludeAttribute(typeof(RetrievePrivilegeSetRequest))]
  [XmlIncludeAttribute(typeof(RetrievePrincipalAccessRequest))]
  [XmlIncludeAttribute(typeof(RetrieveParsedDataImportFileRequest))]
  [XmlIncludeAttribute(typeof(RetrieveParentGroupsResourceGroupRequest))]
  [XmlIncludeAttribute(typeof(RetrieveMultipleRequest))]
  [XmlIncludeAttribute(typeof(RetrieveMembersTeamRequest))]
  [XmlIncludeAttribute(typeof(RetrieveMembersBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(RetrieveLocLabelsRequest))]
  [XmlIncludeAttribute(typeof(RetrieveLicenseInfoRequest))]
  [XmlIncludeAttribute(typeof(RetrieveInstalledLanguagePacksRequest))]
  [XmlIncludeAttribute(typeof(RetrieveFormXmlRequest))]
  [XmlIncludeAttribute(typeof(RetrieveExchangeRateRequest))]
  [XmlIncludeAttribute(typeof(RetrieveDuplicatesRequest))]
  [XmlIncludeAttribute(typeof(RetrieveDeprovisionedLanguagesRequest))]
  [XmlIncludeAttribute(typeof(RetrieveDeploymentLicenseTypeRequest))]
  [XmlIncludeAttribute(typeof(RetrieveByTopIncidentSubjectKbArticleRequest))]
  [XmlIncludeAttribute(typeof(RetrieveByTopIncidentProductKbArticleRequest))]
  [XmlIncludeAttribute(typeof(RetrieveByResourcesServiceRequest))]
  [XmlIncludeAttribute(typeof(RetrieveByResourceResourceGroupRequest))]
  [XmlIncludeAttribute(typeof(RetrieveByGroupResourceRequest))]
  [XmlIncludeAttribute(typeof(RetrieveBusinessHierarchyBusinessUnitRequest))]
  [XmlIncludeAttribute(typeof(RetrieveAvailableLanguagesRequest))]
  [XmlIncludeAttribute(typeof(RetrieveAllChildUsersSystemUserRequest))]
  [XmlIncludeAttribute(typeof(ResetDataFiltersRequest))]
  [XmlIncludeAttribute(typeof(RescheduleRequest))]
  [XmlIncludeAttribute(typeof(ReplacePrivilegesRoleRequest))]
  [XmlIncludeAttribute(typeof(RenewContractRequest))]
  [XmlIncludeAttribute(typeof(RemoveUserRolesRoleRequest))]
  [XmlIncludeAttribute(typeof(RemoveSubstituteProductRequest))]
  [XmlIncludeAttribute(typeof(RemoveRelatedRequest))]
  [XmlIncludeAttribute(typeof(RemoveProductFromKitRequest))]
  [XmlIncludeAttribute(typeof(RemovePrivilegeRoleRequest))]
  [XmlIncludeAttribute(typeof(RemoveParentRequest))]
  [XmlIncludeAttribute(typeof(RemoveMembersTeamRequest))]
  [XmlIncludeAttribute(typeof(RemoveMemberListRequest))]
  [XmlIncludeAttribute(typeof(RemoveItemCampaignRequest))]
  [XmlIncludeAttribute(typeof(RemoveItemCampaignActivityRequest))]
  [XmlIncludeAttribute(typeof(RegisterSolutionRequest))]
  [XmlIncludeAttribute(typeof(ReassignObjectsSystemUserRequest))]
  [XmlIncludeAttribute(typeof(QueryScheduleRequest))]
  [XmlIncludeAttribute(typeof(QueryMultipleSchedulesRequest))]
  [XmlIncludeAttribute(typeof(QueryExpressionToFetchXmlRequest))]
  [XmlIncludeAttribute(typeof(QualifyMemberListRequest))]
  [XmlIncludeAttribute(typeof(PublishXmlRequest))]
  [XmlIncludeAttribute(typeof(PublishDuplicateRuleRequest))]
  [XmlIncludeAttribute(typeof(PublishAllXmlRequest))]
  [XmlIncludeAttribute(typeof(PropagateByExpressionRequest))]
  [XmlIncludeAttribute(typeof(ProcessOneMemberBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(ProcessInboundEmailRequest))]
  [XmlIncludeAttribute(typeof(ParseImportRequest))]
  [XmlIncludeAttribute(typeof(ModifyAccessRequest))]
  [XmlIncludeAttribute(typeof(MergeRequest))]
  [XmlIncludeAttribute(typeof(MakeUnavailableToOrganizationTemplateRequest))]
  [XmlIncludeAttribute(typeof(MakeUnavailableToOrganizationReportRequest))]
  [XmlIncludeAttribute(typeof(MakeAvailableToOrganizationTemplateRequest))]
  [XmlIncludeAttribute(typeof(MakeAvailableToOrganizationReportRequest))]
  [XmlIncludeAttribute(typeof(LoseOpportunityRequest))]
  [XmlIncludeAttribute(typeof(LogSuccessBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(LogFailureBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(LockSalesOrderPricingRequest))]
  [XmlIncludeAttribute(typeof(LockInvoicePricingRequest))]
  [XmlIncludeAttribute(typeof(LocalTimeFromUtcTimeRequest))]
  [XmlIncludeAttribute(typeof(IsValidStateTransitionRequest))]
  [XmlIncludeAttribute(typeof(IsBackOfficeInstalledRequest))]
  [XmlIncludeAttribute(typeof(InstantiateTemplateRequest))]
  [XmlIncludeAttribute(typeof(InitializeFromRequest))]
  [XmlIncludeAttribute(typeof(ImportXmlWithProgressRequest))]
  [XmlIncludeAttribute(typeof(ImportXmlRequest))]
  [XmlIncludeAttribute(typeof(ImportTranslationsXmlWithProgressRequest))]
  [XmlIncludeAttribute(typeof(ImportRecordsImportRequest))]
  [XmlIncludeAttribute(typeof(ImportCompressedXmlWithProgressRequest))]
  [XmlIncludeAttribute(typeof(ImportCompressedTranslationsXmlWithProgressRequest))]
  [XmlIncludeAttribute(typeof(ImportCompressedAllXmlRequest))]
  [XmlIncludeAttribute(typeof(ImportAllXmlRequest))]
  [XmlIncludeAttribute(typeof(HandleRequest))]
  [XmlIncludeAttribute(typeof(GrantAccessRequest))]
  [XmlIncludeAttribute(typeof(GetTrackingTokenEmailRequest))]
  [XmlIncludeAttribute(typeof(GetTimeZoneCodeByLocalizedNameRequest))]
  [XmlIncludeAttribute(typeof(GetSalesOrderProductsFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(GetReportHistoryLimitRequest))]
  [XmlIncludeAttribute(typeof(GetQuoteProductsFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(GetQuantityDecimalRequest))]
  [XmlIncludeAttribute(typeof(GetInvoiceProductsFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(GetHeaderColumnsImportFileRequest))]
  [XmlIncludeAttribute(typeof(GetDistinctValuesImportFileRequest))]
  [XmlIncludeAttribute(typeof(GetDecryptionKeyRequest))]
  [XmlIncludeAttribute(typeof(GetAllTimeZonesWithDisplayNameRequest))]
  [XmlIncludeAttribute(typeof(GenerateSalesOrderFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(GenerateQuoteFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(GenerateInvoiceFromOpportunityRequest))]
  [XmlIncludeAttribute(typeof(FulfillSalesOrderRequest))]
  [XmlIncludeAttribute(typeof(FindParentResourceGroupRequest))]
  [XmlIncludeAttribute(typeof(FetchXmlToQueryExpressionRequest))]
  [XmlIncludeAttribute(typeof(ExportXmlRequest))]
  [XmlIncludeAttribute(typeof(ExportTranslationsXmlRequest))]
  [XmlIncludeAttribute(typeof(ExportCompressedXmlRequest))]
  [XmlIncludeAttribute(typeof(ExportCompressedTranslationsXmlRequest))]
  [XmlIncludeAttribute(typeof(ExportCompressedAllXmlRequest))]
  [XmlIncludeAttribute(typeof(ExportAllXmlRequest))]
  [XmlIncludeAttribute(typeof(ExpandCalendarRequest))]
  [XmlIncludeAttribute(typeof(ExecuteWorkflowRequest))]
  [XmlIncludeAttribute(typeof(ExecuteFetchRequest))]
  [XmlIncludeAttribute(typeof(ExecuteCampaignActivityRequest))]
  [XmlIncludeAttribute(typeof(ExecuteByIdUserQueryRequest))]
  [XmlIncludeAttribute(typeof(ExecuteByIdSavedQueryRequest))]
  [XmlIncludeAttribute(typeof(DownloadReportDefinitionRequest))]
  [XmlIncludeAttribute(typeof(DistributeCampaignActivityRequest))]
  [XmlIncludeAttribute(typeof(DisassociateEntitiesRequest))]
  [XmlIncludeAttribute(typeof(DetachFromQueueEmailRequest))]
  [XmlIncludeAttribute(typeof(DeliverPromoteEmailRequest))]
  [XmlIncludeAttribute(typeof(DeliverIncomingEmailRequest))]
  [XmlIncludeAttribute(typeof(DeleteRequest))]
  [XmlIncludeAttribute(typeof(CreateWorkflowFromTemplateRequest))]
  [XmlIncludeAttribute(typeof(CreateRequest))]
  [XmlIncludeAttribute(typeof(CreateActivitiesListRequest))]
  [XmlIncludeAttribute(typeof(CopyMembersListRequest))]
  [XmlIncludeAttribute(typeof(CopyCampaignRequest))]
  [XmlIncludeAttribute(typeof(ConvertSalesOrderToInvoiceRequest))]
  [XmlIncludeAttribute(typeof(ConvertQuoteToSalesOrderRequest))]
  [XmlIncludeAttribute(typeof(ConvertProductToKitRequest))]
  [XmlIncludeAttribute(typeof(ConvertKitToProductRequest))]
  [XmlIncludeAttribute(typeof(CompoundUpdateRequest))]
  [XmlIncludeAttribute(typeof(CompoundUpdateDuplicateDetectionRuleRequest))]
  [XmlIncludeAttribute(typeof(CompoundCreateRequest))]
  [XmlIncludeAttribute(typeof(CloseQuoteRequest))]
  [XmlIncludeAttribute(typeof(CloseIncidentRequest))]
  [XmlIncludeAttribute(typeof(CloneContractRequest))]
  [XmlIncludeAttribute(typeof(CleanUpBulkOperationRequest))]
  [XmlIncludeAttribute(typeof(CheckPromoteEmailRequest))]
  [XmlIncludeAttribute(typeof(CheckIncomingEmailRequest))]
  [XmlIncludeAttribute(typeof(CancelSalesOrderRequest))]
  [XmlIncludeAttribute(typeof(CancelContractRequest))]
  [XmlIncludeAttribute(typeof(CalculateTotalTimeIncidentRequest))]
  [XmlIncludeAttribute(typeof(CalculateActualValueOpportunityRequest))]
  [XmlIncludeAttribute(typeof(BulkOperationStatusCloseRequest))]
  [XmlIncludeAttribute(typeof(BulkDetectDuplicatesRequest))]
  [XmlIncludeAttribute(typeof(BulkDeleteRequest))]
  [XmlIncludeAttribute(typeof(BookRequest))]
  [XmlIncludeAttribute(typeof(BackgroundSendEmailRequest))]
  [XmlIncludeAttribute(typeof(AutoMapEntityRequest))]
  [XmlIncludeAttribute(typeof(AssociateEntitiesRequest))]
  [XmlIncludeAttribute(typeof(AssignUserRolesRoleRequest))]
  [XmlIncludeAttribute(typeof(AssignRequest))]
  [XmlIncludeAttribute(typeof(AddSubstituteProductRequest))]
  [XmlIncludeAttribute(typeof(AddProductToKitRequest))]
  [XmlIncludeAttribute(typeof(AddPrivilegesRoleRequest))]
  [XmlIncludeAttribute(typeof(AddMembersTeamRequest))]
  [XmlIncludeAttribute(typeof(AddMemberListRequest))]
  [XmlIncludeAttribute(typeof(AddItemCampaignRequest))]
  [XmlIncludeAttribute(typeof(AddItemCampaignActivityRequest))]
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public abstract partial class Request
  {

    private OptionalParameter[] optionalParametersField;

    /// <remarks/>
    public OptionalParameter[] OptionalParameters
    {
      get
      {
        return this.optionalParametersField;
      }
      set
      {
        this.optionalParametersField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WinQuoteRequest : Request
  {

    private BusinessEntity quoteCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity QuoteClose
    {
      get
      {
        return this.quoteCloseField;
      }
      set
      {
        this.quoteCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WinOpportunityRequest : Request
  {

    private BusinessEntity opportunityCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity OpportunityClose
    {
      get
      {
        return this.opportunityCloseField;
      }
      set
      {
        this.opportunityCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class WhoAmIRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ValidateSavedQueryRequest : Request
  {

    private string fetchXmlField;

    private int queryTypeField;

    /// <remarks/>
    public string FetchXml
    {
      get
      {
        return this.fetchXmlField;
      }
      set
      {
        this.fetchXmlField = value;
      }
    }

    /// <remarks/>
    public int QueryType
    {
      get
      {
        return this.queryTypeField;
      }
      set
      {
        this.queryTypeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ValidateRequest : Request
  {

    private BusinessEntityCollection activitiesField;

    /// <remarks/>
    public BusinessEntityCollection Activities
    {
      get
      {
        return this.activitiesField;
      }
      set
      {
        this.activitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UtcTimeFromLocalTimeRequest : Request
  {

    private int timeZoneCodeField;

    private CrmDateTime localTimeField;

    /// <remarks/>
    public int TimeZoneCode
    {
      get
      {
        return this.timeZoneCodeField;
      }
      set
      {
        this.timeZoneCodeField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime LocalTime
    {
      get
      {
        return this.localTimeField;
      }
      set
      {
        this.localTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UpdateUserSettingsSystemUserRequest : Request
  {

    private Guid userIdField;

    private BusinessEntity settingsField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Settings
    {
      get
      {
        return this.settingsField;
      }
      set
      {
        this.settingsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UpdateRequest : Request
  {

    private TargetUpdate targetField;

    /// <remarks/>
    public TargetUpdate Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnregisterSolutionRequest : Request
  {

    private Guid pluginAssemblyIdField;

    /// <remarks/>
    public Guid PluginAssemblyId
    {
      get
      {
        return this.pluginAssemblyIdField;
      }
      set
      {
        this.pluginAssemblyIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnpublishDuplicateRuleRequest : Request
  {

    private Guid duplicateRuleIdField;

    /// <remarks/>
    public Guid DuplicateRuleId
    {
      get
      {
        return this.duplicateRuleIdField;
      }
      set
      {
        this.duplicateRuleIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnlockSalesOrderPricingRequest : Request
  {

    private Guid salesOrderIdField;

    /// <remarks/>
    public Guid SalesOrderId
    {
      get
      {
        return this.salesOrderIdField;
      }
      set
      {
        this.salesOrderIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class UnlockInvoicePricingRequest : Request
  {

    private Guid invoiceIdField;

    /// <remarks/>
    public Guid InvoiceId
    {
      get
      {
        return this.invoiceIdField;
      }
      set
      {
        this.invoiceIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class TransformImportRequest : Request
  {

    private Guid importIdField;

    /// <remarks/>
    public Guid ImportId
    {
      get
      {
        return this.importIdField;
      }
      set
      {
        this.importIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class StatusUpdateBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private int failureCountField;

    private int successCountField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public int FailureCount
    {
      get
      {
        return this.failureCountField;
      }
      set
      {
        this.failureCountField = value;
      }
    }

    /// <remarks/>
    public int SuccessCount
    {
      get
      {
        return this.successCountField;
      }
      set
      {
        this.successCountField = value;
      }
    }
  }



  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetStateSystemUserRequest : Request
  {

    private Guid entityIdField;

    private SystemUserState systemUserStateField;

    private int systemUserStatusField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public SystemUserState SystemUserState
    {
      get
      {
        return this.systemUserStateField;
      }
      set
      {
        this.systemUserStateField = value;
      }
    }

    /// <remarks/>
    public int SystemUserStatus
    {
      get
      {
        return this.systemUserStatusField;
      }
      set
      {
        this.systemUserStatusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  public enum SystemUserState
  {

    /// <remarks/>
    Active,

    /// <remarks/>
    Inactive,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetStateDynamicEntityRequest : Request
  {

    private Moniker entityField;

    private string stateField;

    private int statusField;

    /// <remarks/>
    public Moniker Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }

    /// <remarks/>
    public string State
    {
      get
      {
        return this.stateField;
      }
      set
      {
        this.stateField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetReportRelatedRequest : Request
  {

    private Guid reportIdField;

    private int[] entitiesField;

    private int[] categoriesField;

    private int[] visibilityField;

    /// <remarks/>
    public Guid ReportId
    {
      get
      {
        return this.reportIdField;
      }
      set
      {
        this.reportIdField = value;
      }
    }

    /// <remarks/>
    public int[] Entities
    {
      get
      {
        return this.entitiesField;
      }
      set
      {
        this.entitiesField = value;
      }
    }

    /// <remarks/>
    public int[] Categories
    {
      get
      {
        return this.categoriesField;
      }
      set
      {
        this.categoriesField = value;
      }
    }

    /// <remarks/>
    public int[] Visibility
    {
      get
      {
        return this.visibilityField;
      }
      set
      {
        this.visibilityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetRelatedRequest : Request
  {

    private TargetRelated targetField;

    /// <remarks/>
    public TargetRelated Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentTeamRequest : Request
  {

    private Guid teamIdField;

    private Guid businessIdField;

    /// <remarks/>
    public Guid TeamId
    {
      get
      {
        return this.teamIdField;
      }
      set
      {
        this.teamIdField = value;
      }
    }

    /// <remarks/>
    public Guid BusinessId
    {
      get
      {
        return this.businessIdField;
      }
      set
      {
        this.businessIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentSystemUserRequest : Request
  {

    private Guid userIdField;

    private Guid parentIdField;

    private bool keepChildUsersField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public Guid ParentId
    {
      get
      {
        return this.parentIdField;
      }
      set
      {
        this.parentIdField = value;
      }
    }

    /// <remarks/>
    public bool KeepChildUsers
    {
      get
      {
        return this.keepChildUsersField;
      }
      set
      {
        this.keepChildUsersField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetParentBusinessUnitRequest : Request
  {

    private Guid businessUnitIdField;

    private Guid parentIdField;

    /// <remarks/>
    public Guid BusinessUnitId
    {
      get
      {
        return this.businessUnitIdField;
      }
      set
      {
        this.businessUnitIdField = value;
      }
    }

    /// <remarks/>
    public Guid ParentId
    {
      get
      {
        return this.parentIdField;
      }
      set
      {
        this.parentIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetLocLabelsRequest : Request
  {

    private Moniker entityMonikerField;

    private string attributeNameField;

    private LocLabel[] labelsField;

    /// <remarks/>
    public Moniker EntityMoniker
    {
      get
      {
        return this.entityMonikerField;
      }
      set
      {
        this.entityMonikerField = value;
      }
    }

    /// <remarks/>
    public string AttributeName
    {
      get
      {
        return this.attributeNameField;
      }
      set
      {
        this.attributeNameField = value;
      }
    }

    /// <remarks/>
    public LocLabel[] Labels
    {
      get
      {
        return this.labelsField;
      }
      set
      {
        this.labelsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetBusinessSystemUserRequest : Request
  {

    private Guid userIdField;

    private Guid businessIdField;

    private SecurityPrincipal reassignPrincipalField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public Guid BusinessId
    {
      get
      {
        return this.businessIdField;
      }
      set
      {
        this.businessIdField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipal ReassignPrincipal
    {
      get
      {
        return this.reassignPrincipalField;
      }
      set
      {
        this.reassignPrincipalField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SetBusinessEquipmentRequest : Request
  {

    private Guid equipmentIdField;

    private Guid businessUnitIdField;

    /// <remarks/>
    public Guid EquipmentId
    {
      get
      {
        return this.equipmentIdField;
      }
      set
      {
        this.equipmentIdField = value;
      }
    }

    /// <remarks/>
    public Guid BusinessUnitId
    {
      get
      {
        return this.businessUnitIdField;
      }
      set
      {
        this.businessUnitIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendTemplateRequest : Request
  {

    private Guid templateIdField;

    private Moniker senderField;

    private string recipientTypeField;

    private Guid[] recipientIdsField;

    private string regardingTypeField;

    private Guid regardingIdField;

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public Moniker Sender
    {
      get
      {
        return this.senderField;
      }
      set
      {
        this.senderField = value;
      }
    }

    /// <remarks/>
    public string RecipientType
    {
      get
      {
        return this.recipientTypeField;
      }
      set
      {
        this.recipientTypeField = value;
      }
    }

    /// <remarks/>
    public Guid[] RecipientIds
    {
      get
      {
        return this.recipientIdsField;
      }
      set
      {
        this.recipientIdsField = value;
      }
    }

    /// <remarks/>
    public string RegardingType
    {
      get
      {
        return this.regardingTypeField;
      }
      set
      {
        this.regardingTypeField = value;
      }
    }

    /// <remarks/>
    public Guid RegardingId
    {
      get
      {
        return this.regardingIdField;
      }
      set
      {
        this.regardingIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendFaxRequest : Request
  {

    private Guid faxIdField;

    private bool issueSendField;

    /// <remarks/>
    public Guid FaxId
    {
      get
      {
        return this.faxIdField;
      }
      set
      {
        this.faxIdField = value;
      }
    }

    /// <remarks/>
    public bool IssueSend
    {
      get
      {
        return this.issueSendField;
      }
      set
      {
        this.issueSendField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendEmailRequest : Request
  {

    private Guid emailIdField;

    private bool issueSendField;

    private string trackingTokenField;

    /// <remarks/>
    public Guid EmailId
    {
      get
      {
        return this.emailIdField;
      }
      set
      {
        this.emailIdField = value;
      }
    }

    /// <remarks/>
    public bool IssueSend
    {
      get
      {
        return this.issueSendField;
      }
      set
      {
        this.issueSendField = value;
      }
    }

    /// <remarks/>
    public string TrackingToken
    {
      get
      {
        return this.trackingTokenField;
      }
      set
      {
        this.trackingTokenField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SendBulkMailRequest : Request
  {

    private Moniker senderField;

    private Guid templateIdField;

    private string regardingTypeField;

    private Guid regardingIdField;

    private QueryBase queryField;

    /// <remarks/>
    public Moniker Sender
    {
      get
      {
        return this.senderField;
      }
      set
      {
        this.senderField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public string RegardingType
    {
      get
      {
        return this.regardingTypeField;
      }
      set
      {
        this.regardingTypeField = value;
      }
    }

    /// <remarks/>
    public Guid RegardingId
    {
      get
      {
        return this.regardingIdField;
      }
      set
      {
        this.regardingIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class AppointmentsToIgnore
  {

    private Guid[] appointmentsField;

    private Guid resourceIdField;

    /// <remarks/>
    public Guid[] Appointments
    {
      get
      {
        return this.appointmentsField;
      }
      set
      {
        this.appointmentsField = value;
      }
    }

    /// <remarks/>
    public Guid ResourceId
    {
      get
      {
        return this.resourceIdField;
      }
      set
      {
        this.resourceIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/Scheduling")]
  [DebuggerNonUserCode]
  public partial class AppointmentRequest
  {

    private System.Guid serviceIdField;

    private int anchorOffsetField;

    private int userTimeZoneCodeField;

    private int recurrenceDurationField;

    private int recurrenceTimeZoneCodeField;

    private AppointmentsToIgnore[] appointmentsToIgnoreField;

    private RequiredResource[] requiredResourcesField;

    private CrmDateTime searchWindowStartField;

    private CrmDateTime searchWindowEndField;

    private CrmDateTime searchRecurrenceStartField;

    private string searchRecurrenceRuleField;

    private int durationField;

    private ConstraintRelation[] constraintsField;

    private ObjectiveRelation[] objectivesField;

    private SearchDirection directionField;

    private int numberOfResultsField;

    private System.Guid[] sitesField;

    /// <remarks/>
    public System.Guid ServiceId
    {
      get
      {
        return this.serviceIdField;
      }
      set
      {
        this.serviceIdField = value;
      }
    }

    /// <remarks/>
    public int AnchorOffset
    {
      get
      {
        return this.anchorOffsetField;
      }
      set
      {
        this.anchorOffsetField = value;
      }
    }

    /// <remarks/>
    public int UserTimeZoneCode
    {
      get
      {
        return this.userTimeZoneCodeField;
      }
      set
      {
        this.userTimeZoneCodeField = value;
      }
    }

    /// <remarks/>
    public int RecurrenceDuration
    {
      get
      {
        return this.recurrenceDurationField;
      }
      set
      {
        this.recurrenceDurationField = value;
      }
    }

    /// <remarks/>
    public int RecurrenceTimeZoneCode
    {
      get
      {
        return this.recurrenceTimeZoneCodeField;
      }
      set
      {
        this.recurrenceTimeZoneCodeField = value;
      }
    }

    /// <remarks/>
    public AppointmentsToIgnore[] AppointmentsToIgnore
    {
      get
      {
        return this.appointmentsToIgnoreField;
      }
      set
      {
        this.appointmentsToIgnoreField = value;
      }
    }

    /// <remarks/>
    public RequiredResource[] RequiredResources
    {
      get
      {
        return this.requiredResourcesField;
      }
      set
      {
        this.requiredResourcesField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime SearchWindowStart
    {
      get
      {
        return this.searchWindowStartField;
      }
      set
      {
        this.searchWindowStartField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime SearchWindowEnd
    {
      get
      {
        return this.searchWindowEndField;
      }
      set
      {
        this.searchWindowEndField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime SearchRecurrenceStart
    {
      get
      {
        return this.searchRecurrenceStartField;
      }
      set
      {
        this.searchRecurrenceStartField = value;
      }
    }

    /// <remarks/>
    public string SearchRecurrenceRule
    {
      get
      {
        return this.searchRecurrenceRuleField;
      }
      set
      {
        this.searchRecurrenceRuleField = value;
      }
    }

    /// <remarks/>
    public int Duration
    {
      get
      {
        return this.durationField;
      }
      set
      {
        this.durationField = value;
      }
    }

    /// <remarks/>
    public ConstraintRelation[] Constraints
    {
      get
      {
        return this.constraintsField;
      }
      set
      {
        this.constraintsField = value;
      }
    }

    /// <remarks/>
    public ObjectiveRelation[] Objectives
    {
      get
      {
        return this.objectivesField;
      }
      set
      {
        this.objectivesField = value;
      }
    }

    /// <remarks/>
    public SearchDirection Direction
    {
      get
      {
        return this.directionField;
      }
      set
      {
        this.directionField = value;
      }
    }

    /// <remarks/>
    public int NumberOfResults
    {
      get
      {
        return this.numberOfResultsField;
      }
      set
      {
        this.numberOfResultsField = value;
      }
    }

    /// <remarks/>
    public System.Guid[] Sites
    {
      get
      {
        return this.sitesField;
      }
      set
      {
        this.sitesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchRequest : Request
  {

    private AppointmentRequest appointmentRequestField;

    /// <remarks/>
    public AppointmentRequest AppointmentRequest
    {
      get
      {
        return this.appointmentRequestField;
      }
      set
      {
        this.appointmentRequestField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByTitleKbArticleRequest : Request
  {

    private string searchTextField;

    private Guid subjectIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public string SearchText
    {
      get
      {
        return this.searchTextField;
      }
      set
      {
        this.searchTextField = value;
      }
    }

    /// <remarks/>
    public Guid SubjectId
    {
      get
      {
        return this.subjectIdField;
      }
      set
      {
        this.subjectIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByKeywordsKbArticleRequest : Request
  {

    private string searchTextField;

    private Guid subjectIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public string SearchText
    {
      get
      {
        return this.searchTextField;
      }
      set
      {
        this.searchTextField = value;
      }
    }

    /// <remarks/>
    public Guid SubjectId
    {
      get
      {
        return this.subjectIdField;
      }
      set
      {
        this.subjectIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class SearchByBodyKbArticleRequest : Request
  {

    private string searchTextField;

    private Guid subjectIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public string SearchText
    {
      get
      {
        return this.searchTextField;
      }
      set
      {
        this.searchTextField = value;
      }
    }

    /// <remarks/>
    public Guid SubjectId
    {
      get
      {
        return this.subjectIdField;
      }
      set
      {
        this.subjectIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RouteRequest : Request
  {

    private TargetQueued targetField;

    private Guid sourceQueueIdField;

    private RouteType routeTypeField;

    private Guid endpointIdField;

    /// <remarks/>
    public TargetQueued Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public Guid SourceQueueId
    {
      get
      {
        return this.sourceQueueIdField;
      }
      set
      {
        this.sourceQueueIdField = value;
      }
    }

    /// <remarks/>
    public RouteType RouteType
    {
      get
      {
        return this.routeTypeField;
      }
      set
      {
        this.routeTypeField = value;
      }
    }

    /// <remarks/>
    public Guid EndpointId
    {
      get
      {
        return this.endpointIdField;
      }
      set
      {
        this.endpointIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum RouteType
  {

    /// <remarks/>
    Auto,

    /// <remarks/>
    User,

    /// <remarks/>
    Queue,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RollupRequest : Request
  {

    private TargetRollup targetField;

    private RollupType rollupTypeField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public TargetRollup Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public RollupType RollupType
    {
      get
      {
        return this.rollupTypeField;
      }
      set
      {
        this.rollupTypeField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum RollupType
  {

    /// <remarks/>
    None,

    /// <remarks/>
    Related,

    /// <remarks/>
    Extended,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RevokeAccessRequest : Request
  {

    private TargetOwned targetField;

    private SecurityPrincipal revokeeField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipal Revokee
    {
      get
      {
        return this.revokeeField;
      }
      set
      {
        this.revokeeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReviseQuoteRequest : Request
  {

    private Guid quoteIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid QuoteId
    {
      get
      {
        return this.quoteIdField;
      }
      set
      {
        this.quoteIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveVersionRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveUserSettingsSystemUserRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveUserPrivilegesRequest : Request
  {

    private Guid userIdField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveTeamsSystemUserRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubsidiaryUsersBusinessUnitRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubsidiaryTeamsBusinessUnitRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSubGroupsResourceGroupRequest : Request
  {

    private Guid resourceGroupIdField;

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ResourceGroupId
    {
      get
      {
        return this.resourceGroupIdField;
      }
      set
      {
        this.resourceGroupIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveSharedPrincipalsAndAccessRequest : Request
  {

    private TargetOwned targetField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveRolePrivilegesRoleRequest : Request
  {

    private Guid roleIdField;

    /// <remarks/>
    public Guid RoleId
    {
      get
      {
        return this.roleIdField;
      }
      set
      {
        this.roleIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveRequest : Request
  {

    private TargetRetrieve targetField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public TargetRetrieve Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveProvisionedLanguagesRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrievePrivilegeSetRequest : Request
  {

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrievePrincipalAccessRequest : Request
  {

    private TargetOwned targetField;

    private SecurityPrincipal principalField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipal Principal
    {
      get
      {
        return this.principalField;
      }
      set
      {
        this.principalField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveParsedDataImportFileRequest : Request
  {

    private Guid importFileIdField;

    private PagingInfo pagingInfoField;

    /// <remarks/>
    public Guid ImportFileId
    {
      get
      {
        return this.importFileIdField;
      }
      set
      {
        this.importFileIdField = value;
      }
    }

    /// <remarks/>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.pagingInfoField;
      }
      set
      {
        this.pagingInfoField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveParentGroupsResourceGroupRequest : Request
  {

    private Guid resourceGroupIdField;

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ResourceGroupId
    {
      get
      {
        return this.resourceGroupIdField;
      }
      set
      {
        this.resourceGroupIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMultipleRequest : Request
  {

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMembersTeamRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase memberColumnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase MemberColumnSet
    {
      get
      {
        return this.memberColumnSetField;
      }
      set
      {
        this.memberColumnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveMembersBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private BulkOperationSource bulkOperationSourceField;

    private EntitySource entitySourceField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public BulkOperationSource BulkOperationSource
    {
      get
      {
        return this.bulkOperationSourceField;
      }
      set
      {
        this.bulkOperationSourceField = value;
      }
    }

    /// <remarks/>
    public EntitySource EntitySource
    {
      get
      {
        return this.entitySourceField;
      }
      set
      {
        this.entitySourceField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  public enum BulkOperationSource
  {

    /// <remarks/>
    QuickCampaign,

    /// <remarks/>
    CampaignActivity,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  public enum EntitySource
  {

    /// <remarks/>
    Account,

    /// <remarks/>
    Contact,

    /// <remarks/>
    Lead,

    /// <remarks/>
    All,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveLocLabelsRequest : Request
  {

    private Moniker entityMonikerField;

    private string attributeNameField;

    private bool includeUnpublishedField;

    /// <remarks/>
    public Moniker EntityMoniker
    {
      get
      {
        return this.entityMonikerField;
      }
      set
      {
        this.entityMonikerField = value;
      }
    }

    /// <remarks/>
    public string AttributeName
    {
      get
      {
        return this.attributeNameField;
      }
      set
      {
        this.attributeNameField = value;
      }
    }

    /// <remarks/>
    public bool IncludeUnpublished
    {
      get
      {
        return this.includeUnpublishedField;
      }
      set
      {
        this.includeUnpublishedField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveLicenseInfoRequest : Request
  {

    private int accessModeField;

    /// <remarks/>
    public int AccessMode
    {
      get
      {
        return this.accessModeField;
      }
      set
      {
        this.accessModeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveInstalledLanguagePacksRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveFormXmlRequest : Request
  {

    private string entityNameField;

    /// <remarks/>
    public string EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveExchangeRateRequest : Request
  {

    private Guid transactionCurrencyIdField;

    /// <remarks/>
    public Guid TransactionCurrencyId
    {
      get
      {
        return this.transactionCurrencyIdField;
      }
      set
      {
        this.transactionCurrencyIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDuplicatesRequest : Request
  {

    private BusinessEntity businessEntityField;

    private string matchingEntityNameField;

    private PagingInfo pagingInfoField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public BusinessEntity BusinessEntity
    {
      get
      {
        return this.businessEntityField;
      }
      set
      {
        this.businessEntityField = value;
      }
    }

    /// <remarks/>
    public string MatchingEntityName
    {
      get
      {
        return this.matchingEntityNameField;
      }
      set
      {
        this.matchingEntityNameField = value;
      }
    }

    /// <remarks/>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.pagingInfoField;
      }
      set
      {
        this.pagingInfoField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDeprovisionedLanguagesRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveDeploymentLicenseTypeRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByTopIncidentSubjectKbArticleRequest : Request
  {

    private Guid subjectIdField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid SubjectId
    {
      get
      {
        return this.subjectIdField;
      }
      set
      {
        this.subjectIdField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByTopIncidentProductKbArticleRequest : Request
  {

    private Guid productIdField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByResourcesServiceRequest : Request
  {

    private Guid[] resourceIdsField;

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid[] ResourceIds
    {
      get
      {
        return this.resourceIdsField;
      }
      set
      {
        this.resourceIdsField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByResourceResourceGroupRequest : Request
  {

    private Guid resourceIdField;

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ResourceId
    {
      get
      {
        return this.resourceIdField;
      }
      set
      {
        this.resourceIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveByGroupResourceRequest : Request
  {

    private Guid resourceGroupIdField;

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ResourceGroupId
    {
      get
      {
        return this.resourceGroupIdField;
      }
      set
      {
        this.resourceGroupIdField = value;
      }
    }

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveBusinessHierarchyBusinessUnitRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveAvailableLanguagesRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RetrieveAllChildUsersSystemUserRequest : Request
  {

    private Guid entityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ResetDataFiltersRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RescheduleRequest : Request
  {

    private TargetSchedule targetField;

    /// <remarks/>
    public TargetSchedule Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReplacePrivilegesRoleRequest : Request
  {

    private Guid roleIdField;

    private RolePrivilege[] privilegesField;

    /// <remarks/>
    public Guid RoleId
    {
      get
      {
        return this.roleIdField;
      }
      set
      {
        this.roleIdField = value;
      }
    }

    /// <remarks/>
    public RolePrivilege[] Privileges
    {
      get
      {
        return this.privilegesField;
      }
      set
      {
        this.privilegesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RenewContractRequest : Request
  {

    private Guid contractIdField;

    private int statusField;

    private bool includeCanceledLinesField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ContractId
    {
      get
      {
        return this.contractIdField;
      }
      set
      {
        this.contractIdField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }

    /// <remarks/>
    public bool IncludeCanceledLines
    {
      get
      {
        return this.includeCanceledLinesField;
      }
      set
      {
        this.includeCanceledLinesField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveUserRolesRoleRequest : Request
  {

    private Guid userIdField;

    private Guid[] roleIdsField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public Guid[] RoleIds
    {
      get
      {
        return this.roleIdsField;
      }
      set
      {
        this.roleIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveSubstituteProductRequest : Request
  {

    private Guid productIdField;

    private Guid substituteIdField;

    /// <remarks/>
    public Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }

    /// <remarks/>
    public Guid SubstituteId
    {
      get
      {
        return this.substituteIdField;
      }
      set
      {
        this.substituteIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveRelatedRequest : Request
  {

    private TargetRelated targetField;

    /// <remarks/>
    public TargetRelated Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveProductFromKitRequest : Request
  {

    private Guid kitIdField;

    private Guid productIdField;

    /// <remarks/>
    public Guid KitId
    {
      get
      {
        return this.kitIdField;
      }
      set
      {
        this.kitIdField = value;
      }
    }

    /// <remarks/>
    public Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemovePrivilegeRoleRequest : Request
  {

    private Guid roleIdField;

    private Guid privilegeIdField;

    /// <remarks/>
    public Guid RoleId
    {
      get
      {
        return this.roleIdField;
      }
      set
      {
        this.roleIdField = value;
      }
    }

    /// <remarks/>
    public Guid PrivilegeId
    {
      get
      {
        return this.privilegeIdField;
      }
      set
      {
        this.privilegeIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveParentRequest : Request
  {

    private TargetRemoveParent targetField;

    /// <remarks/>
    public TargetRemoveParent Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveMembersTeamRequest : Request
  {

    private Guid teamIdField;

    private Guid[] memberIdsField;

    /// <remarks/>
    public Guid TeamId
    {
      get
      {
        return this.teamIdField;
      }
      set
      {
        this.teamIdField = value;
      }
    }

    /// <remarks/>
    public Guid[] MemberIds
    {
      get
      {
        return this.memberIdsField;
      }
      set
      {
        this.memberIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveMemberListRequest : Request
  {

    private Guid listIdField;

    private Guid entityIdField;

    /// <remarks/>
    public Guid ListId
    {
      get
      {
        return this.listIdField;
      }
      set
      {
        this.listIdField = value;
      }
    }

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveItemCampaignRequest : Request
  {

    private Guid campaignIdField;

    private Guid entityIdField;

    /// <remarks/>
    public Guid CampaignId
    {
      get
      {
        return this.campaignIdField;
      }
      set
      {
        this.campaignIdField = value;
      }
    }

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RemoveItemCampaignActivityRequest : Request
  {

    private Guid campaignActivityIdField;

    private Guid itemIdField;

    /// <remarks/>
    public Guid CampaignActivityId
    {
      get
      {
        return this.campaignActivityIdField;
      }
      set
      {
        this.campaignActivityIdField = value;
      }
    }

    /// <remarks/>
    public Guid ItemId
    {
      get
      {
        return this.itemIdField;
      }
      set
      {
        this.itemIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class RegisterSolutionRequest : Request
  {

    private BusinessEntity pluginAssemblyField;

    private SdkMessageProcessingStepRegistration[] stepsField;

    /// <remarks/>
    public BusinessEntity PluginAssembly
    {
      get
      {
        return this.pluginAssemblyField;
      }
      set
      {
        this.pluginAssemblyField = value;
      }
    }

    /// <remarks/>
    public SdkMessageProcessingStepRegistration[] Steps
    {
      get
      {
        return this.stepsField;
      }
      set
      {
        this.stepsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ReassignObjectsSystemUserRequest : Request
  {

    private Guid userIdField;

    private SecurityPrincipal reassignPrincipalField;

    /// <remarks/>
    public Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipal ReassignPrincipal
    {
      get
      {
        return this.reassignPrincipalField;
      }
      set
      {
        this.reassignPrincipalField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryScheduleRequest : Request
  {

    private Guid resourceIdField;

    private CrmDateTime startField;

    private CrmDateTime endField;

    private TimeCode[] timeCodesField;

    /// <remarks/>
    public Guid ResourceId
    {
      get
      {
        return this.resourceIdField;
      }
      set
      {
        this.resourceIdField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime Start
    {
      get
      {
        return this.startField;
      }
      set
      {
        this.startField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime End
    {
      get
      {
        return this.endField;
      }
      set
      {
        this.endField = value;
      }
    }

    /// <remarks/>
    public TimeCode[] TimeCodes
    {
      get
      {
        return this.timeCodesField;
      }
      set
      {
        this.timeCodesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryMultipleSchedulesRequest : Request
  {

    private Guid[] resourceIdsField;

    private CrmDateTime startField;

    private CrmDateTime endField;

    private TimeCode[] timeCodesField;

    /// <remarks/>
    public Guid[] ResourceIds
    {
      get
      {
        return this.resourceIdsField;
      }
      set
      {
        this.resourceIdsField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime Start
    {
      get
      {
        return this.startField;
      }
      set
      {
        this.startField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime End
    {
      get
      {
        return this.endField;
      }
      set
      {
        this.endField = value;
      }
    }

    /// <remarks/>
    public TimeCode[] TimeCodes
    {
      get
      {
        return this.timeCodesField;
      }
      set
      {
        this.timeCodesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QueryExpressionToFetchXmlRequest : Request
  {

    private QueryBase queryField;

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class QualifyMemberListRequest : Request
  {

    private Guid listIdField;

    private Guid[] membersIdField;

    private bool overrideorRemoveField;

    /// <remarks/>
    public Guid ListId
    {
      get
      {
        return this.listIdField;
      }
      set
      {
        this.listIdField = value;
      }
    }

    /// <remarks/>
    public Guid[] MembersId
    {
      get
      {
        return this.membersIdField;
      }
      set
      {
        this.membersIdField = value;
      }
    }

    /// <remarks/>
    public bool OverrideorRemove
    {
      get
      {
        return this.overrideorRemoveField;
      }
      set
      {
        this.overrideorRemoveField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishXmlRequest : Request
  {

    private string parameterXmlField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishDuplicateRuleRequest : Request
  {

    private Guid duplicateRuleIdField;

    /// <remarks/>
    public Guid DuplicateRuleId
    {
      get
      {
        return this.duplicateRuleIdField;
      }
      set
      {
        this.duplicateRuleIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PublishAllXmlRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class PropagateByExpressionRequest : Request
  {

    private QueryBase queryExpressionField;

    private string friendlyNameField;

    private bool executeImmediatelyField;

    private BusinessEntity activityField;

    private Guid templateIdField;

    private PropagationOwnershipOptions ownershipOptionsField;

    private bool postWorkflowEventField;

    private Moniker ownerField;

    private bool sendEmailField;

    /// <remarks/>
    public QueryBase QueryExpression
    {
      get
      {
        return this.queryExpressionField;
      }
      set
      {
        this.queryExpressionField = value;
      }
    }

    /// <remarks/>
    public string FriendlyName
    {
      get
      {
        return this.friendlyNameField;
      }
      set
      {
        this.friendlyNameField = value;
      }
    }

    /// <remarks/>
    public bool ExecuteImmediately
    {
      get
      {
        return this.executeImmediatelyField;
      }
      set
      {
        this.executeImmediatelyField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Activity
    {
      get
      {
        return this.activityField;
      }
      set
      {
        this.activityField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public PropagationOwnershipOptions OwnershipOptions
    {
      get
      {
        return this.ownershipOptionsField;
      }
      set
      {
        this.ownershipOptionsField = value;
      }
    }

    /// <remarks/>
    public bool PostWorkflowEvent
    {
      get
      {
        return this.postWorkflowEventField;
      }
      set
      {
        this.postWorkflowEventField = value;
      }
    }

    /// <remarks/>
    public Moniker Owner
    {
      get
      {
        return this.ownerField;
      }
      set
      {
        this.ownerField = value;
      }
    }

    /// <remarks/>
    public bool SendEmail
    {
      get
      {
        return this.sendEmailField;
      }
      set
      {
        this.sendEmailField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
  public enum PropagationOwnershipOptions
  {

    /// <remarks/>
    None,

    /// <remarks/>
    Caller,

    /// <remarks/>
    ListMemberOwner,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ProcessOneMemberBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private BusinessEntity entityField;

    private BulkOperationSource bulkOperationSourceField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }

    /// <remarks/>
    public BulkOperationSource BulkOperationSource
    {
      get
      {
        return this.bulkOperationSourceField;
      }
      set
      {
        this.bulkOperationSourceField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ProcessInboundEmailRequest : Request
  {

    private Guid inboundEmailActivityField;

    /// <remarks/>
    public Guid InboundEmailActivity
    {
      get
      {
        return this.inboundEmailActivityField;
      }
      set
      {
        this.inboundEmailActivityField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ParseImportRequest : Request
  {

    private Guid importIdField;

    /// <remarks/>
    public Guid ImportId
    {
      get
      {
        return this.importIdField;
      }
      set
      {
        this.importIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ModifyAccessRequest : Request
  {

    private TargetOwned targetField;

    private PrincipalAccess principalAccessField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public PrincipalAccess PrincipalAccess
    {
      get
      {
        return this.principalAccessField;
      }
      set
      {
        this.principalAccessField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MergeRequest : Request
  {

    private TargetMerge targetField;

    private Guid subordinateIdField;

    private BusinessEntity updateContentField;

    private bool performParentingChecksField;

    /// <remarks/>
    public TargetMerge Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public Guid SubordinateId
    {
      get
      {
        return this.subordinateIdField;
      }
      set
      {
        this.subordinateIdField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity UpdateContent
    {
      get
      {
        return this.updateContentField;
      }
      set
      {
        this.updateContentField = value;
      }
    }

    /// <remarks/>
    public bool PerformParentingChecks
    {
      get
      {
        return this.performParentingChecksField;
      }
      set
      {
        this.performParentingChecksField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeUnavailableToOrganizationTemplateRequest : Request
  {

    private Guid templateIdField;

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeUnavailableToOrganizationReportRequest : Request
  {

    private Guid reportIdField;

    /// <remarks/>
    public Guid ReportId
    {
      get
      {
        return this.reportIdField;
      }
      set
      {
        this.reportIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeAvailableToOrganizationTemplateRequest : Request
  {

    private Guid templateIdField;

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class MakeAvailableToOrganizationReportRequest : Request
  {

    private Guid reportIdField;

    /// <remarks/>
    public Guid ReportId
    {
      get
      {
        return this.reportIdField;
      }
      set
      {
        this.reportIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LoseOpportunityRequest : Request
  {

    private BusinessEntity opportunityCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity OpportunityClose
    {
      get
      {
        return this.opportunityCloseField;
      }
      set
      {
        this.opportunityCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LogSuccessBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private Guid regardingObjectIdField;

    private int regardingObjectTypeCodeField;

    private Guid createdObjectIdField;

    private int createdObjectTypeCodeField;

    private string additionalInfoField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public Guid RegardingObjectId
    {
      get
      {
        return this.regardingObjectIdField;
      }
      set
      {
        this.regardingObjectIdField = value;
      }
    }

    /// <remarks/>
    public int RegardingObjectTypeCode
    {
      get
      {
        return this.regardingObjectTypeCodeField;
      }
      set
      {
        this.regardingObjectTypeCodeField = value;
      }
    }

    /// <remarks/>
    public Guid CreatedObjectId
    {
      get
      {
        return this.createdObjectIdField;
      }
      set
      {
        this.createdObjectIdField = value;
      }
    }

    /// <remarks/>
    public int CreatedObjectTypeCode
    {
      get
      {
        return this.createdObjectTypeCodeField;
      }
      set
      {
        this.createdObjectTypeCodeField = value;
      }
    }

    /// <remarks/>
    public string AdditionalInfo
    {
      get
      {
        return this.additionalInfoField;
      }
      set
      {
        this.additionalInfoField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LogFailureBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private Guid regardingObjectIdField;

    private int regardingObjectTypeCodeField;

    private int errorCodeField;

    private string messageField;

    private string additionalInfoField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public Guid RegardingObjectId
    {
      get
      {
        return this.regardingObjectIdField;
      }
      set
      {
        this.regardingObjectIdField = value;
      }
    }

    /// <remarks/>
    public int RegardingObjectTypeCode
    {
      get
      {
        return this.regardingObjectTypeCodeField;
      }
      set
      {
        this.regardingObjectTypeCodeField = value;
      }
    }

    /// <remarks/>
    public int ErrorCode
    {
      get
      {
        return this.errorCodeField;
      }
      set
      {
        this.errorCodeField = value;
      }
    }

    /// <remarks/>
    public string Message
    {
      get
      {
        return this.messageField;
      }
      set
      {
        this.messageField = value;
      }
    }

    /// <remarks/>
    public string AdditionalInfo
    {
      get
      {
        return this.additionalInfoField;
      }
      set
      {
        this.additionalInfoField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LockSalesOrderPricingRequest : Request
  {

    private Guid salesOrderIdField;

    /// <remarks/>
    public Guid SalesOrderId
    {
      get
      {
        return this.salesOrderIdField;
      }
      set
      {
        this.salesOrderIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LockInvoicePricingRequest : Request
  {

    private Guid invoiceIdField;

    /// <remarks/>
    public Guid InvoiceId
    {
      get
      {
        return this.invoiceIdField;
      }
      set
      {
        this.invoiceIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class LocalTimeFromUtcTimeRequest : Request
  {

    private int timeZoneCodeField;

    private CrmDateTime utcTimeField;

    /// <remarks/>
    public int TimeZoneCode
    {
      get
      {
        return this.timeZoneCodeField;
      }
      set
      {
        this.timeZoneCodeField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime UtcTime
    {
      get
      {
        return this.utcTimeField;
      }
      set
      {
        this.utcTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class IsValidStateTransitionRequest : Request
  {

    private Moniker entityField;

    private string newStateField;

    private int newStatusField;

    /// <remarks/>
    public Moniker Entity
    {
      get
      {
        return this.entityField;
      }
      set
      {
        this.entityField = value;
      }
    }

    /// <remarks/>
    public string NewState
    {
      get
      {
        return this.newStateField;
      }
      set
      {
        this.newStateField = value;
      }
    }

    /// <remarks/>
    public int NewStatus
    {
      get
      {
        return this.newStatusField;
      }
      set
      {
        this.newStatusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class IsBackOfficeInstalledRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class InstantiateTemplateRequest : Request
  {

    private Guid templateIdField;

    private string objectTypeField;

    private Guid objectIdField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public string ObjectType
    {
      get
      {
        return this.objectTypeField;
      }
      set
      {
        this.objectTypeField = value;
      }
    }

    /// <remarks/>
    public Guid ObjectId
    {
      get
      {
        return this.objectIdField;
      }
      set
      {
        this.objectIdField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class InitializeFromRequest : Request
  {

    private Moniker entityMonikerField;

    private string targetEntityNameField;

    private TargetFieldType targetFieldTypeField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Moniker EntityMoniker
    {
      get
      {
        return this.entityMonikerField;
      }
      set
      {
        this.entityMonikerField = value;
      }
    }

    /// <remarks/>
    public string TargetEntityName
    {
      get
      {
        return this.targetEntityNameField;
      }
      set
      {
        this.targetEntityNameField = value;
      }
    }

    /// <remarks/>
    public TargetFieldType TargetFieldType
    {
      get
      {
        return this.targetFieldTypeField;
      }
      set
      {
        this.targetFieldTypeField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
  public enum TargetFieldType
  {

    /// <remarks/>
    All,

    /// <remarks/>
    ValidForCreate,

    /// <remarks/>
    ValidForUpdate,

    /// <remarks/>
    ValidForRead,
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportXmlWithProgressRequest : Request
  {

    private string parameterXmlField;

    private string customizationXmlField;

    private Guid importJobIdField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }

    /// <remarks/>
    public string CustomizationXml
    {
      get
      {
        return this.customizationXmlField;
      }
      set
      {
        this.customizationXmlField = value;
      }
    }

    /// <remarks/>
    public Guid ImportJobId
    {
      get
      {
        return this.importJobIdField;
      }
      set
      {
        this.importJobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportXmlRequest : Request
  {

    private string parameterXmlField;

    private string customizationXmlField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }

    /// <remarks/>
    public string CustomizationXml
    {
      get
      {
        return this.customizationXmlField;
      }
      set
      {
        this.customizationXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportTranslationsXmlWithProgressRequest : Request
  {

    private string importXmlField;

    private Guid importJobIdField;

    /// <remarks/>
    public string ImportXml
    {
      get
      {
        return this.importXmlField;
      }
      set
      {
        this.importXmlField = value;
      }
    }

    /// <remarks/>
    public Guid ImportJobId
    {
      get
      {
        return this.importJobIdField;
      }
      set
      {
        this.importJobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportRecordsImportRequest : Request
  {

    private Guid importIdField;

    /// <remarks/>
    public Guid ImportId
    {
      get
      {
        return this.importIdField;
      }
      set
      {
        this.importIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedXmlWithProgressRequest : Request
  {

    private string parameterXmlField;

    private byte[] compressedCustomizationXmlField;

    private Guid importJobIdField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] CompressedCustomizationXml
    {
      get
      {
        return this.compressedCustomizationXmlField;
      }
      set
      {
        this.compressedCustomizationXmlField = value;
      }
    }

    /// <remarks/>
    public Guid ImportJobId
    {
      get
      {
        return this.importJobIdField;
      }
      set
      {
        this.importJobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedTranslationsXmlWithProgressRequest : Request
  {

    private byte[] compressedTranslationsXmlField;

    private Guid importJobIdField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] CompressedTranslationsXml
    {
      get
      {
        return this.compressedTranslationsXmlField;
      }
      set
      {
        this.compressedTranslationsXmlField = value;
      }
    }

    /// <remarks/>
    public Guid ImportJobId
    {
      get
      {
        return this.importJobIdField;
      }
      set
      {
        this.importJobIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportCompressedAllXmlRequest : Request
  {

    private byte[] compressedCustomizationXmlField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] CompressedCustomizationXml
    {
      get
      {
        return this.compressedCustomizationXmlField;
      }
      set
      {
        this.compressedCustomizationXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ImportAllXmlRequest : Request
  {

    private string customizationXmlField;

    /// <remarks/>
    public string CustomizationXml
    {
      get
      {
        return this.customizationXmlField;
      }
      set
      {
        this.customizationXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class HandleRequest : Request
  {

    private TargetQueued targetField;

    private Guid sourceQueueIdField;

    /// <remarks/>
    public TargetQueued Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public Guid SourceQueueId
    {
      get
      {
        return this.sourceQueueIdField;
      }
      set
      {
        this.sourceQueueIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GrantAccessRequest : Request
  {

    private TargetOwned targetField;

    private PrincipalAccess principalAccessField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public PrincipalAccess PrincipalAccess
    {
      get
      {
        return this.principalAccessField;
      }
      set
      {
        this.principalAccessField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetTrackingTokenEmailRequest : Request
  {

    private string subjectField;

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetTimeZoneCodeByLocalizedNameRequest : Request
  {

    private string localizedStandardNameField;

    private int localeIdField;

    /// <remarks/>
    public string LocalizedStandardName
    {
      get
      {
        return this.localizedStandardNameField;
      }
      set
      {
        this.localizedStandardNameField = value;
      }
    }

    /// <remarks/>
    public int LocaleId
    {
      get
      {
        return this.localeIdField;
      }
      set
      {
        this.localeIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetSalesOrderProductsFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private Guid salesOrderIdField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public Guid SalesOrderId
    {
      get
      {
        return this.salesOrderIdField;
      }
      set
      {
        this.salesOrderIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetReportHistoryLimitRequest : Request
  {

    private Guid reportIdField;

    /// <remarks/>
    public Guid ReportId
    {
      get
      {
        return this.reportIdField;
      }
      set
      {
        this.reportIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetQuoteProductsFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private Guid quoteIdField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public Guid QuoteId
    {
      get
      {
        return this.quoteIdField;
      }
      set
      {
        this.quoteIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetQuantityDecimalRequest : Request
  {

    private TargetQuantify targetField;

    private Guid productIdField;

    private Guid uoMIdField;

    /// <remarks/>
    public TargetQuantify Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }

    /// <remarks/>
    public Guid UoMId
    {
      get
      {
        return this.uoMIdField;
      }
      set
      {
        this.uoMIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetInvoiceProductsFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private Guid invoiceIdField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public Guid InvoiceId
    {
      get
      {
        return this.invoiceIdField;
      }
      set
      {
        this.invoiceIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetHeaderColumnsImportFileRequest : Request
  {

    private Guid importFileIdField;

    /// <remarks/>
    public Guid ImportFileId
    {
      get
      {
        return this.importFileIdField;
      }
      set
      {
        this.importFileIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetDistinctValuesImportFileRequest : Request
  {

    private Guid importFileIdField;

    private int columnNumberField;

    private int pageNumberField;

    private int recordsPerPageField;

    /// <remarks/>
    public Guid ImportFileId
    {
      get
      {
        return this.importFileIdField;
      }
      set
      {
        this.importFileIdField = value;
      }
    }

    /// <remarks/>
    public int columnNumber
    {
      get
      {
        return this.columnNumberField;
      }
      set
      {
        this.columnNumberField = value;
      }
    }

    /// <remarks/>
    public int pageNumber
    {
      get
      {
        return this.pageNumberField;
      }
      set
      {
        this.pageNumberField = value;
      }
    }

    /// <remarks/>
    public int recordsPerPage
    {
      get
      {
        return this.recordsPerPageField;
      }
      set
      {
        this.recordsPerPageField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetDecryptionKeyRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GetAllTimeZonesWithDisplayNameRequest : Request
  {

    private int localeIdField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public int LocaleId
    {
      get
      {
        return this.localeIdField;
      }
      set
      {
        this.localeIdField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateSalesOrderFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateQuoteFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class GenerateInvoiceFromOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FulfillSalesOrderRequest : Request
  {

    private BusinessEntity orderCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity OrderClose
    {
      get
      {
        return this.orderCloseField;
      }
      set
      {
        this.orderCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FindParentResourceGroupRequest : Request
  {

    private Guid parentIdField;

    private Guid[] childrenIdsField;

    /// <remarks/>
    public Guid ParentId
    {
      get
      {
        return this.parentIdField;
      }
      set
      {
        this.parentIdField = value;
      }
    }

    /// <remarks/>
    public Guid[] ChildrenIds
    {
      get
      {
        return this.childrenIdsField;
      }
      set
      {
        this.childrenIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class FetchXmlToQueryExpressionRequest : Request
  {

    private string fetchXmlField;

    /// <remarks/>
    public string FetchXml
    {
      get
      {
        return this.fetchXmlField;
      }
      set
      {
        this.fetchXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportXmlRequest : Request
  {

    private string parameterXmlField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportTranslationsXmlRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedXmlRequest : Request
  {

    private string parameterXmlField;

    private string embeddedFileNameField;

    /// <remarks/>
    public string ParameterXml
    {
      get
      {
        return this.parameterXmlField;
      }
      set
      {
        this.parameterXmlField = value;
      }
    }

    /// <remarks/>
    public string EmbeddedFileName
    {
      get
      {
        return this.embeddedFileNameField;
      }
      set
      {
        this.embeddedFileNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedTranslationsXmlRequest : Request
  {

    private string embeddedFileNameField;

    /// <remarks/>
    public string EmbeddedFileName
    {
      get
      {
        return this.embeddedFileNameField;
      }
      set
      {
        this.embeddedFileNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportCompressedAllXmlRequest : Request
  {

    private string embeddedFileNameField;

    /// <remarks/>
    public string EmbeddedFileName
    {
      get
      {
        return this.embeddedFileNameField;
      }
      set
      {
        this.embeddedFileNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExportAllXmlRequest : Request
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExpandCalendarRequest : Request
  {

    private Guid calendarIdField;

    private CrmDateTime startField;

    private CrmDateTime endField;

    /// <remarks/>
    public Guid CalendarId
    {
      get
      {
        return this.calendarIdField;
      }
      set
      {
        this.calendarIdField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime Start
    {
      get
      {
        return this.startField;
      }
      set
      {
        this.startField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime End
    {
      get
      {
        return this.endField;
      }
      set
      {
        this.endField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteWorkflowRequest : Request
  {

    private Guid entityIdField;

    private Guid workflowIdField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public Guid WorkflowId
    {
      get
      {
        return this.workflowIdField;
      }
      set
      {
        this.workflowIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteFetchRequest : Request
  {

    private string fetchXmlField;

    /// <remarks/>
    public string FetchXml
    {
      get
      {
        return this.fetchXmlField;
      }
      set
      {
        this.fetchXmlField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteCampaignActivityRequest : Request
  {

    private Guid campaignActivityIdField;

    private bool propagateField;

    private BusinessEntity activityField;

    private Guid templateIdField;

    private PropagationOwnershipOptions ownershipOptionsField;

    /// <remarks/>
    public Guid CampaignActivityId
    {
      get
      {
        return this.campaignActivityIdField;
      }
      set
      {
        this.campaignActivityIdField = value;
      }
    }

    /// <remarks/>
    public bool Propagate
    {
      get
      {
        return this.propagateField;
      }
      set
      {
        this.propagateField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Activity
    {
      get
      {
        return this.activityField;
      }
      set
      {
        this.activityField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public PropagationOwnershipOptions OwnershipOptions
    {
      get
      {
        return this.ownershipOptionsField;
      }
      set
      {
        this.ownershipOptionsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteByIdUserQueryRequest : Request
  {

    private Guid entityIdField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ExecuteByIdSavedQueryRequest : Request
  {

    private Guid entityIdField;

    /// <remarks/>
    public Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DownloadReportDefinitionRequest : Request
  {

    private Guid reportIdField;

    /// <remarks/>
    public Guid ReportId
    {
      get
      {
        return this.reportIdField;
      }
      set
      {
        this.reportIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DistributeCampaignActivityRequest : Request
  {

    private Guid campaignActivityIdField;

    private bool propagateField;

    private BusinessEntity activityField;

    private Guid templateIdField;

    private PropagationOwnershipOptions ownershipOptionsField;

    private Moniker ownerField;

    private bool sendEmailField;

    /// <remarks/>
    public Guid CampaignActivityId
    {
      get
      {
        return this.campaignActivityIdField;
      }
      set
      {
        this.campaignActivityIdField = value;
      }
    }

    /// <remarks/>
    public bool Propagate
    {
      get
      {
        return this.propagateField;
      }
      set
      {
        this.propagateField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Activity
    {
      get
      {
        return this.activityField;
      }
      set
      {
        this.activityField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public PropagationOwnershipOptions OwnershipOptions
    {
      get
      {
        return this.ownershipOptionsField;
      }
      set
      {
        this.ownershipOptionsField = value;
      }
    }

    /// <remarks/>
    public Moniker Owner
    {
      get
      {
        return this.ownerField;
      }
      set
      {
        this.ownerField = value;
      }
    }

    /// <remarks/>
    public bool SendEmail
    {
      get
      {
        return this.sendEmailField;
      }
      set
      {
        this.sendEmailField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DisassociateEntitiesRequest : Request
  {

    private Moniker moniker1Field;

    private Moniker moniker2Field;

    private string relationshipNameField;

    /// <remarks/>
    public Moniker Moniker1
    {
      get
      {
        return this.moniker1Field;
      }
      set
      {
        this.moniker1Field = value;
      }
    }

    /// <remarks/>
    public Moniker Moniker2
    {
      get
      {
        return this.moniker2Field;
      }
      set
      {
        this.moniker2Field = value;
      }
    }

    /// <remarks/>
    public string RelationshipName
    {
      get
      {
        return this.relationshipNameField;
      }
      set
      {
        this.relationshipNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DetachFromQueueEmailRequest : Request
  {

    private Guid emailIdField;

    private Guid queueIdField;

    /// <remarks/>
    public Guid EmailId
    {
      get
      {
        return this.emailIdField;
      }
      set
      {
        this.emailIdField = value;
      }
    }

    /// <remarks/>
    public Guid QueueId
    {
      get
      {
        return this.queueIdField;
      }
      set
      {
        this.queueIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeliverPromoteEmailRequest : Request
  {

    private Guid emailIdField;

    private string messageIdField;

    private string subjectField;

    private string fromField;

    private string toField;

    private string ccField;

    private string bccField;

    private CrmDateTime receivedOnField;

    private string submittedByField;

    private string importanceField;

    private string bodyField;

    private BusinessEntityCollection attachmentsField;

    /// <remarks/>
    public Guid EmailId
    {
      get
      {
        return this.emailIdField;
      }
      set
      {
        this.emailIdField = value;
      }
    }

    /// <remarks/>
    public string MessageId
    {
      get
      {
        return this.messageIdField;
      }
      set
      {
        this.messageIdField = value;
      }
    }

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }

    /// <remarks/>
    public string From
    {
      get
      {
        return this.fromField;
      }
      set
      {
        this.fromField = value;
      }
    }

    /// <remarks/>
    public string To
    {
      get
      {
        return this.toField;
      }
      set
      {
        this.toField = value;
      }
    }

    /// <remarks/>
    public string Cc
    {
      get
      {
        return this.ccField;
      }
      set
      {
        this.ccField = value;
      }
    }

    /// <remarks/>
    public string Bcc
    {
      get
      {
        return this.bccField;
      }
      set
      {
        this.bccField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime ReceivedOn
    {
      get
      {
        return this.receivedOnField;
      }
      set
      {
        this.receivedOnField = value;
      }
    }

    /// <remarks/>
    public string SubmittedBy
    {
      get
      {
        return this.submittedByField;
      }
      set
      {
        this.submittedByField = value;
      }
    }

    /// <remarks/>
    public string Importance
    {
      get
      {
        return this.importanceField;
      }
      set
      {
        this.importanceField = value;
      }
    }

    /// <remarks/>
    public string Body
    {
      get
      {
        return this.bodyField;
      }
      set
      {
        this.bodyField = value;
      }
    }

    /// <remarks/>
    public BusinessEntityCollection Attachments
    {
      get
      {
        return this.attachmentsField;
      }
      set
      {
        this.attachmentsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeliverIncomingEmailRequest : Request
  {

    private string messageIdField;

    private string subjectField;

    private string fromField;

    private string toField;

    private string ccField;

    private string bccField;

    private CrmDateTime receivedOnField;

    private string submittedByField;

    private string importanceField;

    private string bodyField;

    private BusinessEntityCollection attachmentsField;

    /// <remarks/>
    public string MessageId
    {
      get
      {
        return this.messageIdField;
      }
      set
      {
        this.messageIdField = value;
      }
    }

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }

    /// <remarks/>
    public string From
    {
      get
      {
        return this.fromField;
      }
      set
      {
        this.fromField = value;
      }
    }

    /// <remarks/>
    public string To
    {
      get
      {
        return this.toField;
      }
      set
      {
        this.toField = value;
      }
    }

    /// <remarks/>
    public string Cc
    {
      get
      {
        return this.ccField;
      }
      set
      {
        this.ccField = value;
      }
    }

    /// <remarks/>
    public string Bcc
    {
      get
      {
        return this.bccField;
      }
      set
      {
        this.bccField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime ReceivedOn
    {
      get
      {
        return this.receivedOnField;
      }
      set
      {
        this.receivedOnField = value;
      }
    }

    /// <remarks/>
    public string SubmittedBy
    {
      get
      {
        return this.submittedByField;
      }
      set
      {
        this.submittedByField = value;
      }
    }

    /// <remarks/>
    public string Importance
    {
      get
      {
        return this.importanceField;
      }
      set
      {
        this.importanceField = value;
      }
    }

    /// <remarks/>
    public string Body
    {
      get
      {
        return this.bodyField;
      }
      set
      {
        this.bodyField = value;
      }
    }

    /// <remarks/>
    public BusinessEntityCollection Attachments
    {
      get
      {
        return this.attachmentsField;
      }
      set
      {
        this.attachmentsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class DeleteRequest : Request
  {

    private TargetDelete targetField;

    /// <remarks/>
    public TargetDelete Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateWorkflowFromTemplateRequest : Request
  {

    private string workflowNameField;

    private Guid workflowTemplateIdField;

    /// <remarks/>
    public string WorkflowName
    {
      get
      {
        return this.workflowNameField;
      }
      set
      {
        this.workflowNameField = value;
      }
    }

    /// <remarks/>
    public Guid WorkflowTemplateId
    {
      get
      {
        return this.workflowTemplateIdField;
      }
      set
      {
        this.workflowTemplateIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateRequest : Request
  {

    private TargetCreate targetField;

    /// <remarks/>
    public TargetCreate Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CreateActivitiesListRequest : Request
  {

    private Guid listIdField;

    private string friendlyNameField;

    private BusinessEntity activityField;

    private Guid templateIdField;

    private bool propagateField;

    private PropagationOwnershipOptions ownershipOptionsField;

    private Moniker ownerField;

    private bool sendEmailField;

    /// <remarks/>
    public Guid ListId
    {
      get
      {
        return this.listIdField;
      }
      set
      {
        this.listIdField = value;
      }
    }

    /// <remarks/>
    public string FriendlyName
    {
      get
      {
        return this.friendlyNameField;
      }
      set
      {
        this.friendlyNameField = value;
      }
    }

    /// <remarks/>
    public BusinessEntity Activity
    {
      get
      {
        return this.activityField;
      }
      set
      {
        this.activityField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public bool Propagate
    {
      get
      {
        return this.propagateField;
      }
      set
      {
        this.propagateField = value;
      }
    }

    /// <remarks/>
    public PropagationOwnershipOptions OwnershipOptions
    {
      get
      {
        return this.ownershipOptionsField;
      }
      set
      {
        this.ownershipOptionsField = value;
      }
    }

    /// <remarks/>
    public Moniker Owner
    {
      get
      {
        return this.ownerField;
      }
      set
      {
        this.ownerField = value;
      }
    }

    /// <remarks/>
    public bool sendEmail
    {
      get
      {
        return this.sendEmailField;
      }
      set
      {
        this.sendEmailField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CopyMembersListRequest : Request
  {

    private Guid sourceListIdField;

    private Guid targetListIdField;

    /// <remarks/>
    public Guid SourceListId
    {
      get
      {
        return this.sourceListIdField;
      }
      set
      {
        this.sourceListIdField = value;
      }
    }

    /// <remarks/>
    public Guid TargetListId
    {
      get
      {
        return this.targetListIdField;
      }
      set
      {
        this.targetListIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CopyCampaignRequest : Request
  {

    private Guid baseCampaignField;

    private bool saveAsTemplateField;

    /// <remarks/>
    public Guid BaseCampaign
    {
      get
      {
        return this.baseCampaignField;
      }
      set
      {
        this.baseCampaignField = value;
      }
    }

    /// <remarks/>
    public bool SaveAsTemplate
    {
      get
      {
        return this.saveAsTemplateField;
      }
      set
      {
        this.saveAsTemplateField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertSalesOrderToInvoiceRequest : Request
  {

    private Guid salesOrderIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid SalesOrderId
    {
      get
      {
        return this.salesOrderIdField;
      }
      set
      {
        this.salesOrderIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertQuoteToSalesOrderRequest : Request
  {

    private Guid quoteIdField;

    private ColumnSetBase columnSetField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid QuoteId
    {
      get
      {
        return this.quoteIdField;
      }
      set
      {
        this.quoteIdField = value;
      }
    }

    /// <remarks/>
    public ColumnSetBase ColumnSet
    {
      get
      {
        return this.columnSetField;
      }
      set
      {
        this.columnSetField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertProductToKitRequest : Request
  {

    private Guid productIdField;

    /// <remarks/>
    public Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class ConvertKitToProductRequest : Request
  {

    private Guid kitIdField;

    /// <remarks/>
    public Guid KitId
    {
      get
      {
        return this.kitIdField;
      }
      set
      {
        this.kitIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundUpdateRequest : Request
  {

    private TargetCompound targetField;

    /// <remarks/>
    public TargetCompound Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundUpdateDuplicateDetectionRuleRequest : Request
  {

    private TargetCompound targetField;

    /// <remarks/>
    public TargetCompound Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CompoundCreateRequest : Request
  {

    private TargetCompound targetField;

    /// <remarks/>
    public TargetCompound Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloseQuoteRequest : Request
  {

    private BusinessEntity quoteCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity QuoteClose
    {
      get
      {
        return this.quoteCloseField;
      }
      set
      {
        this.quoteCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloseIncidentRequest : Request
  {

    private BusinessEntity incidentResolutionField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity IncidentResolution
    {
      get
      {
        return this.incidentResolutionField;
      }
      set
      {
        this.incidentResolutionField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CloneContractRequest : Request
  {

    private Guid contractIdField;

    private bool includeCanceledLinesField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public Guid ContractId
    {
      get
      {
        return this.contractIdField;
      }
      set
      {
        this.contractIdField = value;
      }
    }

    /// <remarks/>
    public bool IncludeCanceledLines
    {
      get
      {
        return this.includeCanceledLinesField;
      }
      set
      {
        this.includeCanceledLinesField = value;
      }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CleanUpBulkOperationRequest : Request
  {

    private Guid bulkOperationIdField;

    private BulkOperationSource bulkOperationSourceField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public BulkOperationSource BulkOperationSource
    {
      get
      {
        return this.bulkOperationSourceField;
      }
      set
      {
        this.bulkOperationSourceField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CheckPromoteEmailRequest : Request
  {

    private string messageIdField;

    private string subjectField;

    /// <remarks/>
    public string MessageId
    {
      get
      {
        return this.messageIdField;
      }
      set
      {
        this.messageIdField = value;
      }
    }

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CheckIncomingEmailRequest : Request
  {

    private string messageIdField;

    private string subjectField;

    private string fromField;

    private string toField;

    private string ccField;

    private string bccField;

    /// <remarks/>
    public string MessageId
    {
      get
      {
        return this.messageIdField;
      }
      set
      {
        this.messageIdField = value;
      }
    }

    /// <remarks/>
    public string Subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }

    /// <remarks/>
    public string From
    {
      get
      {
        return this.fromField;
      }
      set
      {
        this.fromField = value;
      }
    }

    /// <remarks/>
    public string To
    {
      get
      {
        return this.toField;
      }
      set
      {
        this.toField = value;
      }
    }

    /// <remarks/>
    public string Cc
    {
      get
      {
        return this.ccField;
      }
      set
      {
        this.ccField = value;
      }
    }

    /// <remarks/>
    public string Bcc
    {
      get
      {
        return this.bccField;
      }
      set
      {
        this.bccField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CancelSalesOrderRequest : Request
  {

    private BusinessEntity orderCloseField;

    private int statusField;

    /// <remarks/>
    public BusinessEntity OrderClose
    {
      get
      {
        return this.orderCloseField;
      }
      set
      {
        this.orderCloseField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CancelContractRequest : Request
  {

    private Guid contractIdField;

    private CrmDateTime cancelDateField;

    private int statusField;

    /// <remarks/>
    public Guid ContractId
    {
      get
      {
        return this.contractIdField;
      }
      set
      {
        this.contractIdField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime CancelDate
    {
      get
      {
        return this.cancelDateField;
      }
      set
      {
        this.cancelDateField = value;
      }
    }

    /// <remarks/>
    public int Status
    {
      get
      {
        return this.statusField;
      }
      set
      {
        this.statusField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CalculateTotalTimeIncidentRequest : Request
  {

    private Guid incidentIdField;

    /// <remarks/>
    public Guid IncidentId
    {
      get
      {
        return this.incidentIdField;
      }
      set
      {
        this.incidentIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class CalculateActualValueOpportunityRequest : Request
  {

    private Guid opportunityIdField;

    /// <remarks/>
    public Guid OpportunityId
    {
      get
      {
        return this.opportunityIdField;
      }
      set
      {
        this.opportunityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkOperationStatusCloseRequest : Request
  {

    private Guid bulkOperationIdField;

    private int failureCountField;

    private int successCountField;

    private int statusReasonField;

    private int errorCodeField;

    /// <remarks/>
    public Guid BulkOperationId
    {
      get
      {
        return this.bulkOperationIdField;
      }
      set
      {
        this.bulkOperationIdField = value;
      }
    }

    /// <remarks/>
    public int FailureCount
    {
      get
      {
        return this.failureCountField;
      }
      set
      {
        this.failureCountField = value;
      }
    }

    /// <remarks/>
    public int SuccessCount
    {
      get
      {
        return this.successCountField;
      }
      set
      {
        this.successCountField = value;
      }
    }

    /// <remarks/>
    public int StatusReason
    {
      get
      {
        return this.statusReasonField;
      }
      set
      {
        this.statusReasonField = value;
      }
    }

    /// <remarks/>
    public int ErrorCode
    {
      get
      {
        return this.errorCodeField;
      }
      set
      {
        this.errorCodeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkDetectDuplicatesRequest : Request
  {

    private QueryBase queryField;

    private string jobNameField;

    private bool sendEmailNotificationField;

    private Guid templateIdField;

    private Guid[] toRecipientsField;

    private Guid[] cCRecipientsField;

    private string recurrencePatternField;

    private CrmDateTime recurrenceStartTimeField;

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    public string JobName
    {
      get
      {
        return this.jobNameField;
      }
      set
      {
        this.jobNameField = value;
      }
    }

    /// <remarks/>
    public bool SendEmailNotification
    {
      get
      {
        return this.sendEmailNotificationField;
      }
      set
      {
        this.sendEmailNotificationField = value;
      }
    }

    /// <remarks/>
    public Guid TemplateId
    {
      get
      {
        return this.templateIdField;
      }
      set
      {
        this.templateIdField = value;
      }
    }

    /// <remarks/>
    public Guid[] ToRecipients
    {
      get
      {
        return this.toRecipientsField;
      }
      set
      {
        this.toRecipientsField = value;
      }
    }

    /// <remarks/>
    public Guid[] CCRecipients
    {
      get
      {
        return this.cCRecipientsField;
      }
      set
      {
        this.cCRecipientsField = value;
      }
    }

    /// <remarks/>
    public string RecurrencePattern
    {
      get
      {
        return this.recurrencePatternField;
      }
      set
      {
        this.recurrencePatternField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime RecurrenceStartTime
    {
      get
      {
        return this.recurrenceStartTimeField;
      }
      set
      {
        this.recurrenceStartTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BulkDeleteRequest : Request
  {

    private QueryBase[] querySetField;

    private string jobNameField;

    private bool sendEmailNotificationField;

    private Guid[] toRecipientsField;

    private Guid[] cCRecipientsField;

    private string recurrencePatternField;

    private CrmDateTime startDateTimeField;

    /// <remarks/>
    public QueryBase[] QuerySet
    {
      get
      {
        return this.querySetField;
      }
      set
      {
        this.querySetField = value;
      }
    }

    /// <remarks/>
    public string JobName
    {
      get
      {
        return this.jobNameField;
      }
      set
      {
        this.jobNameField = value;
      }
    }

    /// <remarks/>
    public bool SendEmailNotification
    {
      get
      {
        return this.sendEmailNotificationField;
      }
      set
      {
        this.sendEmailNotificationField = value;
      }
    }

    /// <remarks/>
    public Guid[] ToRecipients
    {
      get
      {
        return this.toRecipientsField;
      }
      set
      {
        this.toRecipientsField = value;
      }
    }

    /// <remarks/>
    public Guid[] CCRecipients
    {
      get
      {
        return this.cCRecipientsField;
      }
      set
      {
        this.cCRecipientsField = value;
      }
    }

    /// <remarks/>
    public string RecurrencePattern
    {
      get
      {
        return this.recurrencePatternField;
      }
      set
      {
        this.recurrencePatternField = value;
      }
    }

    /// <remarks/>
    public CrmDateTime StartDateTime
    {
      get
      {
        return this.startDateTimeField;
      }
      set
      {
        this.startDateTimeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BookRequest : Request
  {

    private TargetSchedule targetField;

    /// <remarks/>
    public TargetSchedule Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class BackgroundSendEmailRequest : Request
  {

    private QueryBase queryField;

    private bool returnDynamicEntitiesField;

    /// <remarks/>
    public QueryBase Query
    {
      get
      {
        return this.queryField;
      }
      set
      {
        this.queryField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ReturnDynamicEntities
    {
      get
      {
        return this.returnDynamicEntitiesField;
      }
      set
      {
        this.returnDynamicEntitiesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AutoMapEntityRequest : Request
  {

    private System.Guid entityMapIdField;

    /// <remarks/>
    public System.Guid EntityMapId
    {
      get
      {
        return this.entityMapIdField;
      }
      set
      {
        this.entityMapIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssociateEntitiesRequest : Request
  {

    private Moniker moniker1Field;

    private Moniker moniker2Field;

    private string relationshipNameField;

    /// <remarks/>
    public Moniker Moniker1
    {
      get
      {
        return this.moniker1Field;
      }
      set
      {
        this.moniker1Field = value;
      }
    }

    /// <remarks/>
    public Moniker Moniker2
    {
      get
      {
        return this.moniker2Field;
      }
      set
      {
        this.moniker2Field = value;
      }
    }

    /// <remarks/>
    public string RelationshipName
    {
      get
      {
        return this.relationshipNameField;
      }
      set
      {
        this.relationshipNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssignUserRolesRoleRequest : Request
  {

    private System.Guid userIdField;

    private System.Guid[] roleIdsField;

    /// <remarks/>
    public System.Guid UserId
    {
      get
      {
        return this.userIdField;
      }
      set
      {
        this.userIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid[] RoleIds
    {
      get
      {
        return this.roleIdsField;
      }
      set
      {
        this.roleIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AssignRequest : Request
  {

    private TargetOwned targetField;

    private SecurityPrincipal assigneeField;

    /// <remarks/>
    public TargetOwned Target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public SecurityPrincipal Assignee
    {
      get
      {
        return this.assigneeField;
      }
      set
      {
        this.assigneeField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddSubstituteProductRequest : Request
  {

    private System.Guid productIdField;

    private System.Guid substituteIdField;

    /// <remarks/>
    public System.Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid SubstituteId
    {
      get
      {
        return this.substituteIdField;
      }
      set
      {
        this.substituteIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddProductToKitRequest : Request
  {

    private System.Guid kitIdField;

    private System.Guid productIdField;

    /// <remarks/>
    public System.Guid KitId
    {
      get
      {
        return this.kitIdField;
      }
      set
      {
        this.kitIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid ProductId
    {
      get
      {
        return this.productIdField;
      }
      set
      {
        this.productIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddPrivilegesRoleRequest : Request
  {

    private System.Guid roleIdField;

    private RolePrivilege[] privilegesField;

    /// <remarks/>
    public System.Guid RoleId
    {
      get
      {
        return this.roleIdField;
      }
      set
      {
        this.roleIdField = value;
      }
    }

    /// <remarks/>
    public RolePrivilege[] Privileges
    {
      get
      {
        return this.privilegesField;
      }
      set
      {
        this.privilegesField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddMembersTeamRequest : Request
  {

    private System.Guid teamIdField;

    private System.Guid[] memberIdsField;

    /// <remarks/>
    public System.Guid TeamId
    {
      get
      {
        return this.teamIdField;
      }
      set
      {
        this.teamIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid[] MemberIds
    {
      get
      {
        return this.memberIdsField;
      }
      set
      {
        this.memberIdsField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddMemberListRequest : Request
  {

    private System.Guid listIdField;

    private System.Guid entityIdField;

    /// <remarks/>
    public System.Guid ListId
    {
      get
      {
        return this.listIdField;
      }
      set
      {
        this.listIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddItemCampaignRequest : Request
  {

    private System.Guid campaignIdField;

    private System.Guid entityIdField;

    private EntityName entityNameField;

    /// <remarks/>
    public System.Guid CampaignId
    {
      get
      {
        return this.campaignIdField;
      }
      set
      {
        this.campaignIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid EntityId
    {
      get
      {
        return this.entityIdField;
      }
      set
      {
        this.entityIdField = value;
      }
    }

    /// <remarks/>
    public EntityName EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  [DebuggerNonUserCode]
  public partial class AddItemCampaignActivityRequest : Request
  {

    private System.Guid campaignActivityIdField;

    private System.Guid itemIdField;

    private EntityName entityNameField;

    /// <remarks/>
    public System.Guid CampaignActivityId
    {
      get
      {
        return this.campaignActivityIdField;
      }
      set
      {
        this.campaignActivityIdField = value;
      }
    }

    /// <remarks/>
    public System.Guid ItemId
    {
      get
      {
        return this.itemIdField;
      }
      set
      {
        this.itemIdField = value;
      }
    }

    /// <remarks/>
    public EntityName EntityName
    {
      get
      {
        return this.entityNameField;
      }
      set
      {
        this.entityNameField = value;
      }
    }
  }


  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices")]
  public enum EntityName
  {

    /// <remarks/>
    none,

    /// <remarks/>
    account,

    /// <remarks/>
    activitymimeattachment,

    /// <remarks/>
    activityparty,

    /// <remarks/>
    activitypointer,

    /// <remarks/>
    annotation,

    /// <remarks/>
    annualfiscalcalendar,

    /// <remarks/>
    appointment,

    /// <remarks/>
    asyncoperation,

    /// <remarks/>
    attributemap,

    /// <remarks/>
    bulkdeletefailure,

    /// <remarks/>
    bulkdeleteoperation,

    /// <remarks/>
    bulkoperation,

    /// <remarks/>
    bulkoperationlog,

    /// <remarks/>
    businesstask,

    /// <remarks/>
    businessunit,

    /// <remarks/>
    businessunitnewsarticle,

    /// <remarks/>
    calendar,

    /// <remarks/>
    calendarrule,

    /// <remarks/>
    campaign,

    /// <remarks/>
    campaignactivity,

    /// <remarks/>
    campaignactivityitem,

    /// <remarks/>
    campaignitem,

    /// <remarks/>
    campaignresponse,

    /// <remarks/>
    columnmapping,

    /// <remarks/>
    competitor,

    /// <remarks/>
    constraintbasedgroup,

    /// <remarks/>
    contact,

    /// <remarks/>
    contract,

    /// <remarks/>
    contractdetail,

    /// <remarks/>
    contracttemplate,

    /// <remarks/>
    customeraddress,

    /// <remarks/>
    customeropportunityrole,

    /// <remarks/>
    customerrelationship,

    /// <remarks/>
    discount,

    /// <remarks/>
    discounttype,

    /// <remarks/>
    displaystring,

    /// <remarks/>
    duplicaterecord,

    /// <remarks/>
    duplicaterule,

    /// <remarks/>
    duplicaterulecondition,

    /// <remarks/>
    email,

    /// <remarks/>
    entitymap,

    /// <remarks/>
    equipment,

    /// <remarks/>
    fax,

    /// <remarks/>
    fixedmonthlyfiscalcalendar,

    /// <remarks/>
    import,

    /// <remarks/>
    importdata,

    /// <remarks/>
    importfile,

    /// <remarks/>
    importjob,

    /// <remarks/>
    importlog,

    /// <remarks/>
    importmap,

    /// <remarks/>
    incident,

    /// <remarks/>
    incidentresolution,

    /// <remarks/>
    invoice,

    /// <remarks/>
    invoicedetail,

    /// <remarks/>
    isvconfig,

    /// <remarks/>
    kbarticle,

    /// <remarks/>
    kbarticlecomment,

    /// <remarks/>
    kbarticletemplate,

    /// <remarks/>
    lead,

    /// <remarks/>
    letter,

    /// <remarks/>
    license,

    /// <remarks/>
    list,

    /// <remarks/>
    listmember,

    /// <remarks/>
    lookupmapping,

    /// <remarks/>
    mailmergetemplate,

    /// <remarks/>
    monthlyfiscalcalendar,

    /// <remarks/>
    notification,

    /// <remarks/>
    opportunity,

    /// <remarks/>
    opportunityclose,

    /// <remarks/>
    opportunityproduct,

    /// <remarks/>
    orderclose,

    /// <remarks/>
    organization,

    /// <remarks/>
    organizationui,

    /// <remarks/>
    ownermapping,

    /// <remarks/>
    phonecall,

    /// <remarks/>
    picklistmapping,

    /// <remarks/>
    pluginassembly,

    /// <remarks/>
    plugintype,

    /// <remarks/>
    pricelevel,

    /// <remarks/>
    privilege,

    /// <remarks/>
    product,

    /// <remarks/>
    productpricelevel,

    /// <remarks/>
    quarterlyfiscalcalendar,

    /// <remarks/>
    queue,

    /// <remarks/>
    queueitem,

    /// <remarks/>
    quote,

    /// <remarks/>
    quoteclose,

    /// <remarks/>
    quotedetail,

    /// <remarks/>
    relationshiprole,

    /// <remarks/>
    relationshiprolemap,

    /// <remarks/>
    report,

    /// <remarks/>
    reportcategory,

    /// <remarks/>
    reportentity,

    /// <remarks/>
    reportlink,

    /// <remarks/>
    reportvisibility,

    /// <remarks/>
    resource,

    /// <remarks/>
    resourcegroup,

    /// <remarks/>
    resourcespec,

    /// <remarks/>
    role,

    /// <remarks/>
    salesliterature,

    /// <remarks/>
    salesliteratureitem,

    /// <remarks/>
    salesorder,

    /// <remarks/>
    salesorderdetail,

    /// <remarks/>
    savedquery,

    /// <remarks/>
    sdkmessage,

    /// <remarks/>
    sdkmessagefilter,

    /// <remarks/>
    sdkmessageprocessingstep,

    /// <remarks/>
    sdkmessageprocessingstepimage,

    /// <remarks/>
    sdkmessageprocessingstepsecureconfig,

    /// <remarks/>
    semiannualfiscalcalendar,

    /// <remarks/>
    service,

    /// <remarks/>
    serviceappointment,

    /// <remarks/>
    site,

    /// <remarks/>
    subject,

    /// <remarks/>
    subscription,

    /// <remarks/>
    subscriptionclients,

    /// <remarks/>
    subscriptionsyncinfo,

    /// <remarks/>
    systemuser,

    /// <remarks/>
    task,

    /// <remarks/>
    team,

    /// <remarks/>
    template,

    /// <remarks/>
    territory,

    /// <remarks/>
    timezonedefinition,

    /// <remarks/>
    timezonelocalizedname,

    /// <remarks/>
    timezonerule,

    /// <remarks/>
    transactioncurrency,

    /// <remarks/>
    transformationmapping,

    /// <remarks/>
    transformationparametermapping,

    /// <remarks/>
    uom,

    /// <remarks/>
    uomschedule,

    /// <remarks/>
    userquery,

    /// <remarks/>
    usersettings,

    /// <remarks/>
    webwizard,

    /// <remarks/>
    wfprocess,

    /// <remarks/>
    wfprocessinstance,

    /// <remarks/>
    wizardaccessprivilege,

    /// <remarks/>
    wizardpage,

    /// <remarks/>
    workflow,

    /// <remarks/>
    workflowdependency,

    /// <remarks/>
    workflowlog,
  }


  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class WebServiceApiOrigin : CallerOrigin
  {
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [DebuggerNonUserCode]
  public partial class OfflineOrigin : CallerOrigin
  {

    private CrmDateTime offlineTimestampField;

    /// <remarks/>
    public CrmDateTime OfflineTimestamp
    {
      get
      {
        return this.offlineTimestampField;
      }
      set
      {
        this.offlineTimestampField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [SerializableAttribute()]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/CoreTypes")]
  [XmlRootAttribute(Namespace = "http://schemas.microsoft.com/crm/2007/WebServices", IsNullable = true)]
  [DebuggerNonUserCode]
  public partial class CrmAuthenticationToken : SoapHeader
  {

    private int authenticationTypeField;

    private string crmTicketField;

    private string organizationNameField;

    private System.Guid callerIdField;

    /// <remarks/>
    public int AuthenticationType
    {
      get
      {
        return this.authenticationTypeField;
      }
      set
      {
        this.authenticationTypeField = value;
      }
    }

    /// <remarks/>
    public string CrmTicket
    {
      get
      {
        return this.crmTicketField;
      }
      set
      {
        this.crmTicketField = value;
      }
    }

    /// <remarks/>
    public string OrganizationName
    {
      get
      {
        return this.organizationNameField;
      }
      set
      {
        this.organizationNameField = value;
      }
    }

    /// <remarks/>
    public System.Guid CallerId
    {
      get
      {
        return this.callerIdField;
      }
      set
      {
        this.callerIdField = value;
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void ExecuteCompletedEventHandler(object sender, ExecuteCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [DebuggerNonUserCode]
  public partial class ExecuteCompletedEventArgs : AsyncCompletedEventArgs
  {

    private object[] results;

    internal ExecuteCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) :
      base(exception, cancelled, userState)
    {
      this.results = results;
    }

    /// <remarks/>
    public Response Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return ((Response)(this.results[0]));
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void FetchCompletedEventHandler(object sender, FetchCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [DebuggerNonUserCode]
  public partial class FetchCompletedEventArgs : AsyncCompletedEventArgs
  {

    private object[] results;

    internal FetchCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) :
      base(exception, cancelled, userState)
    {
      this.results = results;
    }

    /// <remarks/>
    public string Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return ((string)(this.results[0]));
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void CreateCompletedEventHandler(object sender, CreateCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [DebuggerNonUserCode]
  public partial class CreateCompletedEventArgs : AsyncCompletedEventArgs
  {

    private object[] results;

    internal CreateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) :
      base(exception, cancelled, userState)
    {
      this.results = results;
    }

    /// <remarks/>
    public Guid Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return ((System.Guid)(this.results[0]));
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void DeleteCompletedEventHandler(object sender, AsyncCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void RetrieveCompletedEventHandler(object sender, RetrieveCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [DebuggerNonUserCode]
  public partial class RetrieveCompletedEventArgs : AsyncCompletedEventArgs
  {

    private object[] results;

    internal RetrieveCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) :
      base(exception, cancelled, userState)
    {
      this.results = results;
    }

    /// <remarks/>
    public BusinessEntity Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return ((BusinessEntity)(this.results[0]));
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void RetrieveMultipleCompletedEventHandler(object sender, RetrieveMultipleCompletedEventArgs e);

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  [DebuggerStepThroughAttribute()]
  [DesignerCategoryAttribute("code")]
  [DebuggerNonUserCode]
  public partial class RetrieveMultipleCompletedEventArgs : AsyncCompletedEventArgs
  {

    private object[] results;

    internal RetrieveMultipleCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) :
      base(exception, cancelled, userState)
    {
      this.results = results;
    }

    /// <remarks/>
    public BusinessEntityCollection Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return ((BusinessEntityCollection)(this.results[0]));
      }
    }
  }

  /// <remarks/>
  [GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
  public delegate void UpdateCompletedEventHandler(object sender, AsyncCompletedEventArgs e);
}
