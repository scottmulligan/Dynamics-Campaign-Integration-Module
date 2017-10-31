#region

using System;
using System.Globalization;
using System.Threading;

using Sitecore.Diagnostics;
using Sitecore.Forms.Core.Crm;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core.Utility
{
  using Sitecore.CrmCampaignIntegration.Metadata;

  public class DateUtil
   {
      public static CrmDateTime ToCrmDateTime(string serializedDateTime)
      {
         Assert.ArgumentNotNullOrEmpty(serializedDateTime, "dateTime");

         bool isParsed = false;
         DateTime dateTime;
         if (Sitecore.Form.Core.Utility.DateUtil.IsIsoDateTime(serializedDateTime))
         {
           dateTime = Sitecore.Form.Core.Utility.DateUtil.IsoDateTimeToDateTime(serializedDateTime);
            isParsed = true;
         }
         else 
         {
            if (serializedDateTime.EndsWith("Z"))
            {
               if (DateTime.TryParse(serializedDateTime, Thread.CurrentThread.CurrentCulture, DateTimeStyles.AssumeUniversal, out dateTime))
               {
                  isParsed = true;
               }
            }
            else if (DateTime.TryParse(serializedDateTime, out dateTime))
            {
               isParsed = true;
            }
         }

         if (isParsed)
         {
            return ToCrmDateTime(dateTime.ToUniversalTime());
         }

         return null;
      }

      /// <summary>
      /// Converts to the specified <see cref="DateTime"/> to the <see cref="CrmDateTime"/>.
      /// </summary>
      /// <param name="dateTime">The date time.</param>
      /// <returns></returns>
      public static CrmDateTime ToCrmDateTime(DateTime dateTime)
      {
         Assert.ArgumentNotNull(dateTime, "dateTime");
         var crmDateTime = new CrmDateTime();
         crmDateTime.Value = string.Format(CultureInfo.InvariantCulture,
                                           "{0:s}Z",
                                           new object[] {dateTime.ToUniversalTime()});
         return crmDateTime;
      }
   }
}