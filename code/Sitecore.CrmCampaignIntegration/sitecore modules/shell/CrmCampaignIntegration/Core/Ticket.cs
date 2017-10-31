#region

using System;

#endregion

namespace Sitecore.CrmCampaignIntegrations.Core
{
  using Sitecore.CrmCampaignIntegration.Core;

  /// <summary>
   /// Ticket implementation
   /// </summary>
   public class Ticket
   {
      #region Methods

      /// <summary>
      /// Initializes a new instance of the <see cref="Ticket"/> class.
      /// </summary>
      /// <param name="value">The value.</param>
      /// <param name="expirationDate">The expiration date.</param>
      public Ticket(string value, DateTime expirationDate)
      {
         Value = value;
         ExpirationDate = expirationDate;
      }

      public Ticket(string value, string organizationName, AuthenticationType authenticationType, DateTime expirationDate)
      {
        this.Value = value;
        this.OrganizationName = organizationName;
        this.AuthenticationType = authenticationType;
        this.ExpirationDate = expirationDate;
      }

     protected AuthenticationType AuthenticationType
     {
       get; private set;
     }

     public string OrganizationName
     {
       get; private set;
     }

     #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the ticket value.
      /// </summary>
      /// <value>The value.</value>
      public string Value { get; private set; }

      /// <summary>
      /// Gets or sets the expiration date.
      /// </summary>
      /// <value>The expiration date.</value>
      public DateTime ExpirationDate { get; private set; }

      #endregion
   }
}