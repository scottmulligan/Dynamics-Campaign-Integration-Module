// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Translate.cs" company="Sitecore A/S">
//   Copyright (C) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   The translate text helper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.CrmCampaignIntegration.Core.Configuration
{
  using System.Linq;
  using Sitecore.Diagnostics;

  /// <summary>
  /// The translate text helper
  /// </summary>
  public class Translate
  {
    #region Methods

    /// <summary>
    /// Texts the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>
    /// The string.
    /// </returns>
    public static string Text(string key, params string[] parameters)
    {
      Assert.ArgumentNotNull(key, "key");
      Assert.ArgumentNotNull(parameters, "parameters");
      string format = Text(key);
      if (parameters.Length > 0)
      {
        return string.Format(format, parameters);
      }

      return format;
    }

    /// <summary>
    /// Texts the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>
    /// The string.
    /// </returns>
    public static string Text(string key)
    {
      return Globalization.Translate.TextByLanguage(key, Context.Language, key);
    }

    /// <summary>
    /// Systems the text.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>
    /// The text.
    /// </returns>
    internal static string SystemText(string key)
    {
      return Globalization.Translate.Text(key);
    }
 

    #endregion
  }
}