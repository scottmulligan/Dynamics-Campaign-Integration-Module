namespace Sitecore.CrmCampaignIntegrations.Core
{
   /// <summary>
   /// Ticket provider interface
   /// </summary>
   public interface ITicketProvider
   {
      /// <summary>
      /// Gets the ticket.
      /// </summary>
      /// <param name="url">The URL.</param>
      /// <param name="login">The login.</param>
      /// <param name="password">The password.</param>
      /// <param name="organizationName">Name of the organization.</param>
      /// <returns></returns>
      Ticket GetTicket(string url, string login, string password, string organizationName, string partner, string environment, int authType);
   }
}