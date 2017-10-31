// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeViewNodeExtensions.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   <see cref="TreeViewNode" /> extensions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Shell.UI.Controls
{
  using System.Collections.Generic;
  using System.Linq;

  using ComponentArt.Web.UI;
  using Sitecore.CrmCampaignIntegration.Core.Crm;

  /// <summary>
  /// <see cref="TreeViewNode"/> extensions
  /// </summary>
  public static class TreeViewNodeExtensions
  {
    /// <summary>
    /// Adds the node.
    /// </summary>
    /// <param name="root">The root.</param>
    /// <param name="field">The field.</param>
    internal static void AddNode(this TreeViewNode root, XCrmField field)
    {
      var rootNode = new TreeViewNode
      {
        Text = field.Title,
        Expanded = false,
        Value = field.Name,
        ToolTip = field.Title,
        ID = string.Join(string.Empty, new[] { root.ParentTreeView.ID + field.Name })
      };
      root.Nodes.Add(rootNode);
    }

    /// <summary>
    /// Adds the nodes.
    /// </summary>
    /// <param name="root">The root.</param>
    /// <param name="fields">The fields.</param>
    internal static void AddNodes(this TreeViewNode root, IEnumerable<XCrmField> fields)
    {
      foreach (var field in fields.Where(field => !field.Disabled))
      {
        root.AddNode(field);
      }
    }
  }
}