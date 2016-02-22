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
    
    public partial class BusinessPartner
    {
        public BusinessPartner()
        {
            this.BusinessPartner_Emails = new HashSet<BusinessPartner_Emails>();
            this.BusinessPartner_ContactNumbers = new HashSet<BusinessPartner_ContactNumbers>();
            this.BusinessPartner_BankDetails = new HashSet<BusinessPartner_BankDetails>();
            this.BusinessPartner_Contacts = new HashSet<BusinessPartner_Contacts>();
            this.TransactionsSecondaries = new HashSet<TransactionsSecondary>();
            this.TransactionsSecondaries1 = new HashSet<TransactionsSecondary>();
            this.Transactions = new HashSet<Transaction>();
            this.Transactions1 = new HashSet<Transaction>();
            this.TransactionsCommissions = new HashSet<TransactionsCommission>();
            this.TransactionsContracts = new HashSet<TransactionsContract>();
            this.TransactionsCommissions1 = new HashSet<TransactionsCommission>();
            this.TransactionsShipments = new HashSet<TransactionsShipment>();
            this.Products = new HashSet<Product>();
        }
    
        public long bp_ID { get; set; }
        public string bp_Name { get; set; }
        public string bp_website { get; set; }
        public int bp_credibilityIndex { get; set; }
        public Nullable<bool> bp_onDoniContract { get; set; }
        public Nullable<bool> bp_isBuyer { get; set; }
        public Nullable<bool> bp_isSeller { get; set; }
        public Nullable<bool> bp_isShipper { get; set; }
        public Nullable<bool> bp_isBroker { get; set; }
        public string bp_country { get; set; }
        public string bp_address { get; set; }
    
        public virtual ICollection<BusinessPartner_Emails> BusinessPartner_Emails { get; set; }
        public virtual ICollection<BusinessPartner_ContactNumbers> BusinessPartner_ContactNumbers { get; set; }
        public virtual ICollection<BusinessPartner_BankDetails> BusinessPartner_BankDetails { get; set; }
        public virtual ICollection<BusinessPartner_Contacts> BusinessPartner_Contacts { get; set; }
        public virtual ICollection<TransactionsSecondary> TransactionsSecondaries { get; set; }
        public virtual ICollection<TransactionsSecondary> TransactionsSecondaries1 { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Transaction> Transactions1 { get; set; }
        public virtual ICollection<TransactionsCommission> TransactionsCommissions { get; set; }
        public virtual ICollection<TransactionsContract> TransactionsContracts { get; set; }
        public virtual ICollection<TransactionsCommission> TransactionsCommissions1 { get; set; }
        public virtual ICollection<TransactionsShipment> TransactionsShipments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}