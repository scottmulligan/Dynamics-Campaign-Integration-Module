using Sitecore.Diagnostics;

namespace Sitecore.CrmCampaignIntegration.DataViewer
{
   /// <summary>
   /// Page parameters
   /// </summary>
   public class PageCriteria
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="PageCriteria"/> class.
      /// </summary>
      /// <param name="pageIndex">Index of the page.</param>
      /// <param name="pageSize">Size of the page.</param>
      public PageCriteria(int pageIndex, int pageSize)
      {
         Assert.IsFalse(PageIndex < 0, "page index is less than 0");
         Assert.IsFalse(PageSize < 0, "page size is less than 0");
         PageIndex = pageIndex;
         PageSize = pageSize;
      }

      /// <summary>
      /// Gets or sets the page cookie.
      /// </summary>
      /// <value>The page cookie.</value>
      public string PageCookie { get; set; }

      /// <summary>
      /// Gets or sets the index of the page.
      /// </summary>
      /// <value>The index of the page.</value>
      public int PageIndex { get; private set; }

      /// <summary>
      /// Gets or sets the size of the page.
      /// </summary>
      /// <value>The size of the page.</value>
      public int PageSize { get; private set; }
   }
}