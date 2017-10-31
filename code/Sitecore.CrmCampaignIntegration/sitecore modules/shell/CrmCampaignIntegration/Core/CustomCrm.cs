// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomCrm.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;
  using CRMSecurityProvider.Sources.PagingInfo;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.CrmCampaignIntegration.Core.Extension;
  using Sitecore.CrmCampaignIntegration.Metadata;
  using Sitecore.CrmCampaignIntegration.Services;
  using Sitecore.Diagnostics;
  using Sitecore.StringExtensions;

  /// <summary>
  /// The custom crm implementation
  /// </summary>
  [Obsolete]
  public class CustomCrm : CrmBase
  {

    /// <summary>
    /// Gets the entities count.
    /// </summary>
    /// <param name="entityName">The entity name.</param>
    /// <param name="primaryKey">The primary key.</param>
    /// <param name="expression">The filter expression.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"><c>InvalidOperationException</c>.</exception>
    public override int GetEntitiesCount(string entityName, string primaryKey, FilterExpression expression)
    {
      Assert.ArgumentNotNullOrEmpty(entityName, "entityName");
      Assert.ArgumentNotNullOrEmpty(primaryKey, "primaryKey");

      string xml =
         CrmRemoteSettings.CrmService.Fetch(CountQuery.FormatWith(entityName, primaryKey,
                                                               expression != null
                                                                  ? expression.ToFetchXml()
                                                                  : string.Empty));

      var resultXml = XElement.Parse(xml);
      var resultNode = resultXml.Element("result");
      if (resultNode == null)
      {
        throw new InvalidOperationException(ResourceManager.Localize("CRM_AGR_QUERY_ERROR"));
      }
      var node = resultNode.Element("count");
      try
      {
        return int.Parse(node.Value);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException(ResourceManager.Localize("CRM_AGR_QUERY_ERROR"), ex);
      }
    }

    /// <summary>
    /// Gets the entities.
    /// </summary>
    /// <param name="entityName">The type.</param>
    /// <param name="pageInfo">The page info.</param>
    /// <param name="expression">The filter expression.</param>
    /// <param name="sortCriteria">The sort criteria.</param>
    /// <returns></returns>
    public override IEnumerable<BusinessEntity> GetEntities(string entityName,
                                                   CrmPagingInfo pageInfo,
                                                   FilterExpression expression,
                                                   CrmOrderExpression[] sortCriteria)
    {
      Assert.ArgumentNotNullOrEmpty(entityName, "entityName");

      var retrieveMultipleReq = new RetrieveMultipleRequest
                                   {
                                     Query =
                                        new QueryExpression
                                           {
                                             ColumnSet = new AllColumns(),
                                             EntityName = entityName,
                                             PageInfo = pageInfo,
                                             Criteria = expression,
                                             Orders = sortCriteria
                                           },
                                     ReturnDynamicEntities = true
                                   };

      var retrieveMultipleRes = (RetrieveMultipleResponse)CrmRemoteSettings.CrmService.Execute(retrieveMultipleReq);

      return retrieveMultipleRes.BusinessEntityCollection.BusinessEntities;
    }

    public override void Delete(string entityName, Guid guid)
    {
      CrmRemoteSettings.CrmService.Delete(entityName, guid);
    }

    /// <summary>
    /// Gets the entity.
    /// </summary>
    /// <param name="entityName">The type.</param>
    /// <param name="fieldName">Name of the field.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public override BusinessEntity GetEntity(string entityName, string fieldName, string value, bool onlyActive, string[] columns)
    {
      Assert.ArgumentNotNullOrEmpty(entityName, "entityName");

      var filters = Filter.And(Expression.Equals(fieldName, value));
      if (onlyActive)
      {
        filters = Filter.And(Expression.Equals(fieldName, value), StatusFilter());
      }


      var retrieveMultipleReq = new RetrieveMultipleRequest
                                   {
                                     Query =
                                        new QueryExpression
                                           {
                                             ColumnSet = (columns == null ? (ColumnSetBase)new AllColumns() : new ColumnSet { Attributes = columns }),
                                             EntityName = entityName,
                                             PageInfo = new CrmPagingInfo { Count = 1, PageNumber = 1 },
                                             Criteria = filters
                                           },
                                     ReturnDynamicEntities = true
                                   };

      var retrieveMultipleRes = (RetrieveMultipleResponse)CrmRemoteSettings.CrmService.Execute(retrieveMultipleReq);

      return retrieveMultipleRes.First();
    }

    /// <summary>
    /// Gets the meta data.
    /// </summary>
    /// <param name="entityName">The name.</param>
    /// <returns></returns>
    public override EntityMetadata GetMetaData(string entityName)
    {
      Assert.ArgumentNotNullOrEmpty(entityName, "entityName");

      var response =
         (RetrieveEntityResponse)
         CrmRemoteSettings.CrmMetadataService.Execute(new RetrieveEntityRequest
                                                      {
                                                        EntityItems = EntityItems.IncludeAttributes,
                                                        LogicalName = entityName,
                                                      });

      return response.EntityMetadata;
    }

    public override IEnumerable<EntityMetadata> GetAllEntitiesMetadata()
    {
      var response =
         (RetrieveAllEntitiesResponse)
         CrmRemoteSettings.CrmMetadataService.Execute(new RetrieveAllEntitiesRequest
         {
           MetadataItems = MetadataItems.EntitiesOnly
         });

      return response.CrmMetadata.Where(m => m is EntityMetadata).Cast<EntityMetadata>();
    }

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public override Guid Create(BusinessEntity entity)
    {
      Assert.ArgumentNotNull(entity, "entity");
      return CrmRemoteSettings.CrmService.Create(entity);
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public override void Update(BusinessEntity entity)
    {
      Assert.ArgumentNotNull(entity, "entity");
      CrmRemoteSettings.CrmService.Update(entity);
    }

    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    public override Response Execute(Request request)
    {
      return CrmRemoteSettings.CrmService.Execute(request);
    }


    /// <summary>
    /// Active filters.
    /// </summary>
    /// <returns></returns>
    protected virtual ConditionExpression StatusFilter()
    {
      return Expression.Equals("statecode", 0);
    }

    /// <summary>
    /// Gets the count query.
    /// </summary>
    /// <value>The count query.</value>
    protected virtual string CountQuery
    {
      get
      {
        return "<fetch mapping='logical' aggregate='true'><entity name='{0}'><attribute name='{1}' aggregate='count' alias='count' />{2}</entity></fetch>";
      }
    }

  }
}