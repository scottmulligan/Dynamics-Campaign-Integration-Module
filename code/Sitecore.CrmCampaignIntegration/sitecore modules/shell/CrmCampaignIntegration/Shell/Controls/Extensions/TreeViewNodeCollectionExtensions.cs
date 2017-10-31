#region

using ComponentArt.Web.UI;

#endregion

namespace Sitecore.CrmCampaignIntegration.Shell.UI.Controls
{
  ///<summary>
  /// Extensions for <see cref="TreeViewNodeCollection"/>
  ///</summary>
  public static class TreeViewNodeCollectionExtensions
  {
    public static bool Contains(this TreeViewNodeCollection collection, string value)
    {
      foreach (TreeViewNode node in collection)
      {
        if (node.Value == value)
        {
          return true;
        }
      }
      return false;
    }
  }
}