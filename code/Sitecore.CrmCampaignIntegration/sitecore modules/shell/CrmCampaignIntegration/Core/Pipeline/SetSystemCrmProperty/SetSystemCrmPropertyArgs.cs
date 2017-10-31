// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetSystemCrmPropertyArgs.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Pipelines
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Entity;
  using Sitecore.Diagnostics;
  using Sitecore.Web.UI.Sheer;

  [Obsolete]
  public class SetSystemCrmPropertyArgs : ClientPipelineArgs
   {

      public SetSystemCrmPropertyArgs(ICrmEntity entity, IEnumerable<ICrmAttribute> systemProperties, Guid entityID)
      {
         Assert.ArgumentNotNull(entity, "entity");
         Assert.ArgumentNotNullOrEmpty(entity.LogicalName, "entity.LogicalName");
         Assert.ArgumentNotNull(systemProperties, "systemProperties");
         Assert.ArgumentNotNull(entityID, "entityID");

         Entity = entity;
         SystemProperties = systemProperties;
         EntityId = entityID;
      }

      public string EntityName
      {
         get
         {
            return Entity.LogicalName;
         }
      }

      public IEnumerable<ICrmAttribute> SystemProperties { get; private set; }

      public Guid EntityId { get; private set; }

      public ICrmEntity Entity { get; private set; }

      public ICrmAttribute this[string propertyName]
      {
         get
         {
            return SystemProperties.FirstOrDefault(p => p.Name == propertyName);
         }
      }

   }
}