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
    
    public partial class transactionViewed
    {
        public long tr_visitedID { get; set; }
        public System.DateTime tr_visitedOn { get; set; }
        public string tr_pageVisitedState { get; set; }
        public string tr_pageVisitedParams { get; set; }
        public string tr_pageTitle { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual AppUser AppUser { get; set; }
    }
}
