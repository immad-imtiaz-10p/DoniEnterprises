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
    
    public partial class uspGetBPContactNumber_Result
    {
        public long ph_ID { get; set; }
        public long bp_ID { get; set; }
        public string contactNumber { get; set; }
        public string contactType { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> editedOn { get; set; }
        public Nullable<int> editedBy { get; set; }
    }
}