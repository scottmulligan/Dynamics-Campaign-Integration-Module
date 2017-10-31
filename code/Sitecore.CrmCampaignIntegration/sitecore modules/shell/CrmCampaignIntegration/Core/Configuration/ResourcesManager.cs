namespace Sitecore.CrmCampaignIntegration.Core.Configuration
{
  using System.IO;
  using System.Reflection;
  using Sitecore.Diagnostics;
  using Sitecore.Forms.Core.Data;
  using Sitecore.IO;

  /// <summary>
  /// Defines the resource manager class.
  /// </summary>
  public class ResourceManager
  {
    #region Constants and Fields

    /// <summary>
    /// The resource name
    /// </summary>
    internal static readonly string ResourceName = "Sitecore.CrmCampaignIntegration.Properties.Resource";

    /// <summary>
    /// The resource manager
    /// </summary>
    private static readonly System.Resources.ResourceManager _rm =
      new System.Resources.ResourceManager(ResourceName, Assembly.GetExecutingAssembly());

    #endregion

    #region Methods

    /// <summary>
    /// Gets the object.
    /// </summary>
    /// <param name="resIdentifier">The res identifier.</param>
    /// <returns>
    /// The object.
    /// </returns>
    public static UnmanagedMemoryStream GetObject(string resIdentifier)
    {
      Assert.ArgumentNotNullOrEmpty(resIdentifier, "resIdentifier");
      return _rm.GetStream(resIdentifier);
    }

    /// <summary>
    /// Gets the string.
    /// </summary>
    /// <param name="resIdentifier">The res identifier.</param>
    /// <returns>
    /// The string.
    /// </returns>
    public static string GetString(string resIdentifier)
    {
      return _rm.GetString(resIdentifier);
    }

    /// <summary>
    /// Localize String
    /// </summary>
    /// <param name="resIdentifier">The res identifier.</param>
    /// <returns>
    /// The string.
    /// </returns>
    public static string Localize(string resIdentifier)
    {
      return Translate.Text(GetString(resIdentifier) ?? string.Empty);
    }

    /// <summary>
    /// Localize String
    /// </summary>
    /// <param name="resIdentifier">The res identifier.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>
    /// The string.
    /// </returns>
    public static string Localize(string resIdentifier, params string[] parameters)
    {
      return Translate.Text(GetString(resIdentifier), parameters);
    }

    /// <summary>
    /// Uploads the resource file.
    /// </summary>
    /// <param name="resIdentifier">The res identifier.</param>
    /// <param name="folder">The folder.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>
    /// The resource file.
    /// </returns>
    public static string UploadResourceFile(string resIdentifier, string folder, string fileName)
    {
      Assert.ArgumentNotNullOrEmpty(resIdentifier, "resIdentifier");
      Assert.ArgumentNotNullOrEmpty(folder, "folder");
      Assert.ArgumentNotNullOrEmpty(fileName, "fileName");

      string path = System.IO.Path.Combine(folder, fileName);
      string directoryName = System.IO.Path.GetDirectoryName(path);

      if (!Directory.Exists(directoryName))
      {
        Directory.CreateDirectory(directoryName);
      }

      FileUtil.CreateFile(path, GetObject(resIdentifier), true);

      return path;
    }

    #endregion
  }
}