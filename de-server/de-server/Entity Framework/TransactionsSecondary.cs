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
    
    public partial class TransactionsSecondary
    {
        public Nullable<long> tr_transactionID { get; set; }
        public long tr_sec_tranID { get; set; }
        public Nullable<long> tr_sec_bpBuyerID { get; set; }
        public Nullable<long> tr_sec_bpSellerID { get; set; }
        public System.DateTime tr_sec_date { get; set; }
        public Nullable<int> tr_sec_buyerPrice { get; set; }
        public Nullable<int> tr_sec_sellerPrice { get; set; }
        public string tr_sec_otherInfo { get; set; }
        public int tr_createdBy { get; set; }
        public Nullable<System.DateTime> tr_createdOn { get; set; }
        public Nullable<int> tr_editedBy { get; set; }
        public Nullable<System.DateTime> tr_editedOn { get; set; }
    
        public virtual AppUser AppUser { get; set; }
        public virtual AppUser AppUser1 { get; set; }
        public virtual BusinessPartner BusinessPartner { get; set; }
        public virtual BusinessPartner BusinessPartner1 { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}