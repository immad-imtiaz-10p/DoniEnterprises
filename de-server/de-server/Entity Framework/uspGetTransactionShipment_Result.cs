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
    
    public partial class uspGetTransactionShipment_Result
    {
        public long tr_transactionID { get; set; }
        public Nullable<bool> tr_ship_notShipped { get; set; }
        public string tr_ship_notShipped_reason { get; set; }
        public string tr_ship_extension { get; set; }
        public Nullable<bool> tr_ship_appReceived { get; set; }
        public Nullable<System.DateTime> tr_expectedShipment { get; set; }
        public Nullable<System.DateTime> tr_inTransit { get; set; }
        public Nullable<bool> tr_shipped { get; set; }
        public Nullable<System.DateTime> tr_dateShipped { get; set; }
        public Nullable<System.DateTime> tr_expectedArrival { get; set; }
        public string tr_transitPort { get; set; }
        public Nullable<bool> tr_ship_arrivedAtPort { get; set; }
        public Nullable<System.DateTime> tr_dateArrived { get; set; }
        public Nullable<System.DateTime> tr_actualArrived { get; set; }
        public string tr_ship_BlNo { get; set; }
        public string tr_ship_invoiceNo { get; set; }
        public Nullable<decimal> tr_ship_invoiceAmt { get; set; }
        public Nullable<decimal> tr_ship_quantity { get; set; }
        public string tr_ship_vesselNo { get; set; }
        public Nullable<long> tr_ship_primaryShipperId { get; set; }
        public string tr_ship_portLoad { get; set; }
        public string tr_ship_portDest { get; set; }
        public string tr_ship_shipLineCont { get; set; }
        public int tr_createdBy { get; set; }
        public Nullable<System.DateTime> tr_createdOn { get; set; }
        public Nullable<int> tr_editedBy { get; set; }
        public Nullable<System.DateTime> tr_editedOn { get; set; }
        public Nullable<bool> tr_ship_chk_reason { get; set; }
        public Nullable<bool> tr_ship_chk_shpExt { get; set; }
        public Nullable<bool> tr_ship_chk_expShp { get; set; }
        public Nullable<bool> tr_ship_chk_inTransit { get; set; }
        public Nullable<bool> tr_ship_chk_dateShipped { get; set; }
        public Nullable<bool> tr_ship_chk_expArrival { get; set; }
        public Nullable<bool> tr_ship_chk_transitPort { get; set; }
        public Nullable<bool> tr_ship_chk_dateArrived { get; set; }
        public Nullable<bool> tr_ship_chk_actualArrived { get; set; }
    }
}
