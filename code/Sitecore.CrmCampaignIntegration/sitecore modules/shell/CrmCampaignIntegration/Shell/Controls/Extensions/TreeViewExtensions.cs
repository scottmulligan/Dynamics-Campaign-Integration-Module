// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeViewExtensions.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Defines the TreeViewExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Shell.UI.Controls
{
  using System.Linq;
  using CRMSecurityProvider.Sources.Attribute.Metadata;
  using ComponentArt.Web.UI;
  using Sitecore.CrmCampaignIntegration.Core.Configuration;
  using Sitecore.CrmCampaignIntegration.Core.Crm;
  using Sitecore.Resources;
  using Sitecore.Web.UI;

  /// <summary>
  /// The tree view extensions.
  /// </summary>
  public static class TreeViewExtensions
  {
    /// <summary>
    /// Loads from CRM entry.
    /// </summary>
    /// <param name="treeview">The treeview.</param>
    /// <param name="entry">The entry.</param>
    internal static void LoadFromCrmEntry(this TreeView treeview, XCrmEntry entry)
    {
      treeview.Nodes.Clear();

      var root = treeview.GetRequiredRootNode();
      treeview.Nodes.Add(root);

      root.AddNodes(entry.RequiredFields);
      root.Nodes.Sort("Text", false);

      var entries = entry.AdditionalFields;

      if (entries.Count() > 0)
      {
        root = treeview.GetAdditionalRootNode();
        treeview.Nodes.Add(root);
        root.AddNodes(entries);
      }
    }

    /// <summary>
    /// Determines whether [is already in tree] [the specified treeview].
    /// </summary>
    /// <param name="treeview">The treeview.</param>
    /// <param name="attribute">The attribute.</param>
    /// <returns>
    ///   <c>true</c> if [is already in tree] [the specified treeview]; otherwise, <c>false</c>.
    /// </returns>
    internal static bool IsAlreadyInTree(this TreeView treeview, ICrmAttributeMetadata attribute)
    {
      return treeview.Nodes.Count < 2 || treeview.Nodes[1].Nodes.Contains(attribute.LogicalName);
    }

    /// <summary>
    /// Gets the required root node.
    /// </summary>
    /// <param name="root">The root.</param>
    private static TreeViewNode GetRequiredRootNode(this TreeView root)
    {
      return new TreeViewNode
      {
        Text = ResourceManager.Localize("REQUIRED_FIELDS"),
        Expanded = true,
        ImageUrl = "~/sitecore/shell/Applications/Modules/Web Forms for Marketers/images/crm16x16.png",
        Selectable = false
      };
    }

    /// <summary>
    /// Gets the additional root node.
    /// </summary>
    /// <param name="treeView">The tree view.</param>
    private static TreeViewNode GetAdditionalRootNode(this TreeView treeView)
    {
      return new TreeViewNode
      {
        Text = ResourceManager.Localize("ADDITIONAL_FIELDS"),
        Expanded = true,
        ImageUrl =
           Images.GetThemedImageSource("Applications/32x32/document_add.png", ImageDimension.id16x16),
        Selectable = false
      };
    }

    public static void Select(this TreeView tree, string nodeValue)
    {
      TreeViewNode nodeById = tree.FindNodeById(string.Join("", new string[1]
      {
        tree.ID + nodeValue
      }));
      tree.SelectedNode = nodeById;
    }
  }
}