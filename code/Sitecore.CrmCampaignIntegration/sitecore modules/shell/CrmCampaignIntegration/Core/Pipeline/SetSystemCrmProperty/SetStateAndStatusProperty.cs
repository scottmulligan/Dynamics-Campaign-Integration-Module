// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetStateAndStatusProperty.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.CrmCampaignIntegration.Pipelines
{
  using System;
  using CRMSecurityProvider.Sources.Attribute;
  using CRMSecurityProvider.Sources.Repository.Factory;
  using Sitecore.CrmCampaignIntegration.Core;
  using Sitecore.CrmCampaignIntegration.Services;

  [Obsolete("Similar request is performed in SecurityProvider within Create/Update queries")]
  public class SetStateAndStatusProperty
  {
    public void Process(SetSystemCrmPropertyArgs args)
    {
      var stateProperty = GetStateProperty(args);
      if (stateProperty != null)
      {
        var statuscode = args["statuscode"];

        var request = new SetStateDynamicEntityRequest
                         {
                           Entity = new Moniker { Id = args.EntityId, Name = args.EntityName },
                           Status = GetStatusValue((StatusProperty)statuscode),
                           State = ((StateProperty)stateProperty).Value,
                         };
        CrmGate.Instance.Execute(request);
      }
    }

    public ICrmAttribute GetStateProperty(SetSystemCrmPropertyArgs args)
    {
      return args["statecode"] ?? args.Entity.Attributes["statecode"];
    }

    public int GetStatusValue(StatusProperty statuscode)
    {
      if (statuscode != null)
      {
        return statuscode.Value.Value;
      }
      return -1;
    }

  }
}

