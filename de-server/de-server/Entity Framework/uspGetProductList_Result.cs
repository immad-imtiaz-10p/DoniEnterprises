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
    
    public partial class uspGetProductList_Result
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string quality { get; set; }
        public string origin { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<long> tr_transactionID { get; set; }
    }
}
