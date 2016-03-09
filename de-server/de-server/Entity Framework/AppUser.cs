//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de_server.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppUser
    {
        public AppUser()
        {
            this.AppUserRights = new HashSet<AppUserRight>();
            this.BusinessPartner_Contacts = new HashSet<BusinessPartner_Contacts>();
            this.BusinessPartner_Contacts1 = new HashSet<BusinessPartner_Contacts>();
            this.BusinessPartner_ContactNumbers = new HashSet<BusinessPartner_ContactNumbers>();
            this.BusinessPartner_ContactNumbers1 = new HashSet<BusinessPartner_ContactNumbers>();
            this.Products = new HashSet<Product>();
            this.Products1 = new HashSet<Product>();
            this.TransactionsSecondaries = new HashSet<TransactionsSecondary>();
            this.TransactionsSecondaries1 = new HashSet<TransactionsSecondary>();
            this.TransactionFiles = new HashSet<TransactionFile>();
            this.TransactionFiles1 = new HashSet<TransactionFile>();
            this.TransactionFiles2 = new HashSet<TransactionFile>();
            this.TransactionsShipments = new HashSet<TransactionsShipment>();
            this.TransactionsCommissions = new HashSet<TransactionsCommission>();
            this.TransactionsStatus = new HashSet<TransactionsStatu>();
            this.TransactionsStatus1 = new HashSet<TransactionsStatu>();
            this.TransactionsNotes = new HashSet<TransactionsNote>();
            this.TransactionsContracts = new HashSet<TransactionsContract>();
            this.Transactions = new HashSet<Transaction>();
            this.TransactionsShipments1 = new HashSet<TransactionsShipment>();
            this.TransactionsCommissions1 = new HashSet<TransactionsCommission>();
            this.TransactionsStatus2 = new HashSet<TransactionsStatu>();
            this.TransactionsStatus3 = new HashSet<TransactionsStatu>();
            this.TransactionsContracts1 = new HashSet<TransactionsContract>();
            this.Transactions1 = new HashSet<Transaction>();
            this.transactionVieweds = new HashSet<transactionViewed>();
            this.UserEvents = new HashSet<UserEvent>();
            this.dailyProductPrices = new HashSet<dailyProductPrice>();
            this.dailyProductPrices1 = new HashSet<dailyProductPrice>();
        }
    
        public int UserID { get; set; }
        public string UserPass { get; set; }
        public string UserEmail { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid UserGuid { get; set; }
        public string UserDesignation { get; set; }
        public bool IsSuperUser { get; set; }
        public string initials { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    
        public virtual ICollection<AppUserRight> AppUserRights { get; set; }
        public virtual AppUsersImage AppUsersImage { get; set; }
        public virtual ICollection<BusinessPartner_Contacts> BusinessPartner_Contacts { get; set; }
        public virtual ICollection<BusinessPartner_Contacts> BusinessPartner_Contacts1 { get; set; }
        public virtual ICollection<BusinessPartner_ContactNumbers> BusinessPartner_ContactNumbers { get; set; }
        public virtual ICollection<BusinessPartner_ContactNumbers> BusinessPartner_ContactNumbers1 { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> Products1 { get; set; }
        public virtual ICollection<TransactionsSecondary> TransactionsSecondaries { get; set; }
        public virtual ICollection<TransactionsSecondary> TransactionsSecondaries1 { get; set; }
        public virtual ICollection<TransactionFile> TransactionFiles { get; set; }
        public virtual ICollection<TransactionFile> TransactionFiles1 { get; set; }
        public virtual ICollection<TransactionFile> TransactionFiles2 { get; set; }
        public virtual ICollection<TransactionsShipment> TransactionsShipments { get; set; }
        public virtual ICollection<TransactionsCommission> TransactionsCommissions { get; set; }
        public virtual ICollection<TransactionsStatu> TransactionsStatus { get; set; }
        public virtual ICollection<TransactionsStatu> TransactionsStatus1 { get; set; }
        public virtual ICollection<TransactionsNote> TransactionsNotes { get; set; }
        public virtual ICollection<TransactionsContract> TransactionsContracts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<TransactionsShipment> TransactionsShipments1 { get; set; }
        public virtual ICollection<TransactionsCommission> TransactionsCommissions1 { get; set; }
        public virtual ICollection<TransactionsStatu> TransactionsStatus2 { get; set; }
        public virtual ICollection<TransactionsStatu> TransactionsStatus3 { get; set; }
        public virtual ICollection<TransactionsContract> TransactionsContracts1 { get; set; }
        public virtual ICollection<Transaction> Transactions1 { get; set; }
        public virtual ICollection<transactionViewed> transactionVieweds { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
        public virtual ICollection<dailyProductPrice> dailyProductPrices { get; set; }
        public virtual ICollection<dailyProductPrice> dailyProductPrices1 { get; set; }
    }
}
