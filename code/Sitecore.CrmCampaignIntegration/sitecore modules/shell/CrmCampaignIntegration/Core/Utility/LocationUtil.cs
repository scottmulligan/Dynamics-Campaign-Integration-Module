using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

using Sitecore.Text;
using Sitecore.Web;

namespace Sitecore.CrmCampaignIntegration.Core.DataViewer
{
   public class LocationUtil
   {
      #region Methods

      [Obsolete("Use the GetUpdatedUrl method")]
      public static string GetDataViewerLocation(NameValueCollection parameters)
      {
         return GetUpdatedUrl(parameters);
      }

      [Obsolete("Use the GetUpdatedUrl method")]
      public static string GetDataViewerLocation(string urlString, NameValueCollection parameters)
      {
         return GetUpdatedUrl(urlString, parameters);
      }

      public static string GetUpdatedUrl(NameValueCollection parameters)
      {
         return GetUpdatedUrl(WebUtil.GetRawUrl(), parameters);
      }

      public static string GetUpdatedUrl(string urlString, NameValueCollection collection)
      {
         var url = new UrlString(urlString);

         foreach (string param in collection.Keys)
         {
            url[param] = collection[param];
         }
         return url.ToString();
      }

      #endregion

   }
}
