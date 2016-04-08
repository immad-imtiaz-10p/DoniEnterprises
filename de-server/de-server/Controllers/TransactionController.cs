using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using de_server.App_Config;
using de_server.Entity_Framework;
using de_server.Security;
using de_server.App_Constants;
using Newtonsoft.Json.Linq;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using de_server.Filters;

namespace de_server.Controllers
{
    [DoniApiExceptionFilter]
    [Authorize]
    public class TransactionController : ApiController
    {

        #region tradebook

        [Route("getTransactionTable")]
        [HttpGet]
        public IHttpActionResult getTransactionTable()
        {
            
                DataTable transactions = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    transactions = DataTableSerializer.LINQToDataTable(context.uspTransactionList());
                    return Ok(new
                    {
                        success = true,
                        transactions = transactions
                    });
                }
         
        }

        [Route("getTransactionTableOnDateRange")]
        [HttpGet]
        public IHttpActionResult GetTransactionTableOnDateRange(DateTime startDate, DateTime endDate)
        {

            using(var context = new DhoniEnterprisesEntities())
            {
                DataTable transactions = new DataTable();
                transactions = DataTableSerializer.LINQToDataTable(context.uspTransactionListByDateRange(startDate,endDate));
                return Ok(new
                {
                    success = true,
                    transactions = transactions
                });
                
            }
        }

        #endregion

        #region transactionBasic

        [Route("getSingleTransaction")]
        [HttpGet]
        public IHttpActionResult getSingleTransaction(long id)
        {
            
                DataTable transaction = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    //transaction = DataTableSerializer.LINQToDataTable(context.uspGetTransaction(id));
                    var basic = context.uspGetTransaction(id);
                    var comm = basic.GetNextResult<DataTable>();
                    var contract = basic.GetNextResult<DataTable>();
                    var sec = basic.GetNextResult<DataTable>();
                    var ship = basic.GetNextResult<DataTable>();
                    var status = basic.GetNextResult<DataTable>();
                    var notes = basic.GetNextResult<DataTable>();
                    return Ok(new
                    {
                        success = true,
                        message = "Transaction read successfully!",
                        basic = DataTableSerializer.LINQToDataTable(basic),
                        comm = DataTableSerializer.LINQToDataTable(comm),
                        contract = DataTableSerializer.LINQToDataTable(contract),
                        sec = DataTableSerializer.LINQToDataTable(sec),
                        ship = DataTableSerializer.LINQToDataTable(ship),
                        status = DataTableSerializer.LINQToDataTable(status),
                        notes = DataTableSerializer.LINQToDataTable(notes)
                    });
                }
          
        }

        [Route("addNewTransaction/basic")]
        [HttpPost]
        public IHttpActionResult PostaddNewTransactionBasic([FromBody] JObject transaction)
        {
            var trade = transaction["newTransaction"];
           
                using (var context = new DhoniEnterprisesEntities())
                {
                    var id = context.uspAddTransactionBasic(
                        Convert.ToDateTime(trade["tr_date"]),
                        Convert.ToInt32(trade["tr_bpBuyerID"]),
                        Convert.ToInt32(trade["tr_bpSellerID"]),
                        Convert.ToInt32(trade["tr_productID"]),
                        Convert.ToString(trade["tr_origin"]),
                        Convert.ToInt32(trade["tr_quantity"]),
                        Convert.ToInt32(trade["tr_price"]),
                        Convert.ToString(trade["tr_packing"]),
                        Convert.ToDateTime(trade["tr_shipment_start"]),
                        Convert.ToDateTime(trade["tr_shipment_end"]),
                        Convert.ToString(trade["tr_fileID"]),
                        Convert.ToString(trade["tr_contractID"]),
                        Convert.ToString(trade["tr_other_info"]),
                        BasicAuthHttpModule.getCurrentUserId(),
                        null,
                        null,
                        null
                        );
                    return Ok(new { success = true, message = "Transaction added successfully!", transactionId = id.FirstOrDefault() });
                }
         
        }

        [Route("TransactionBasicCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionBasicCRUD([FromBody] JObject transaction)
        {
           
                var trade = transaction["data"];
                var tr_transactionID = (long?)(trade["tr_transactionID"]);
                var tr_date = (DateTime?)(trade["tr_date"]);
                var tr_bpBuyerID = (long?)(trade["tr_bpBuyerID"]);
                var tr_bpSellerID = (long?)(trade["tr_bpSellerID"]);
                var tr_productID = (int?)(trade["tr_productID"]);
                var tr_origin = Convert.ToString(trade["tr_origin"]);
                var tr_quantity = (int?)(trade["tr_quantity"]);
                var tr_price = (int?)(trade["tr_price"]);
                var tr_packing = Convert.ToString(trade["tr_packing"]);
                var tr_shipment_start = (DateTime?)(trade["tr_shipment_start"]);
                var tr_shipment_end = (DateTime?)(trade["tr_shipment_end"]);
                var tr_fileID = Convert.ToString(trade["tr_fileID"]);
                var tr_contractID = Convert.ToString(trade["tr_contractID"]);
                var tr_other_info = Convert.ToString(trade["tr_other_info"]);
                var userID = BasicAuthHttpModule.getCurrentUserId();
                var operation = Convert.ToString(trade["operation"]);

                



                if (operation == CRUD.CREATE || operation == CRUD.UPDATE)
                {
                    if (tr_date == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Date" });
                    }
                    else if (tr_price == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction price" });
                    }
                    else if (tr_bpBuyerID == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Buyer" });
                    }
                    else if (tr_bpSellerID == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Seller" });
                    }
                    else if (tr_productID == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction product" });
                    }
                    else if (tr_quantity == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction product quantity in MT" });
                    }
                    else if (tr_bpBuyerID == tr_bpSellerID)
                    {
                        return Ok(new { success = false, message = "Buyer and Seller for a Transaction can not be same" });
                    }
                    else if (tr_fileID == "")
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction File No." });
                    }
                    else if (tr_bpBuyerID == tr_bpSellerID)
                    {
                        return Ok(new { success = false, message = "Buyer and Seller can not be same." });
                    }

                }

                using (var context = new DhoniEnterprisesEntities())
                {
                    int file_count = (from tran in context.Transactions where tran.tr_fileID.ToLower() == tr_fileID.ToLower() select tran).Count();
                    int contract_count = (from tran in context.Transactions where tran.tr_contractID.ToLower() == tr_contractID.ToLower() select tran).Count();

                    if (file_count > 0 && operation == CRUD.CREATE)
                    {
                        return Ok(new { success = false, message = "A trasaction with the same File Id already exist in the system." });
                    }

                    if (contract_count > 0 && operation == CRUD.CREATE)
                    {
                        return Ok(new { success = false, message = "A trasaction with the same Contract Id already exist in the system." });
                    }

                    if (operation == CRUD.CREATE || operation == CRUD.UPDATE || operation == CRUD.DELETE)
                    {
                        var result = context.uspTransactionBasicCRUD(
                            operation, tr_transactionID,
                            tr_date, tr_bpBuyerID,
                            tr_bpSellerID,
                            tr_productID,
                            tr_origin,
                            tr_quantity,
                            tr_price,
                            tr_packing,
                            tr_shipment_start,
                            tr_shipment_end,
                            tr_fileID,
                            tr_contractID,
                            tr_other_info,
                            userID,
                            userID
                        );
                        if (operation == CRUD.CREATE)
                        {
                            return Ok(new { success = true, message = "Transaction added successfully!", transactionId = result.FirstOrDefault() });
                        }
                        else if (operation == CRUD.UPDATE)
                        {
                            return Ok(new { success = true, message = "Transaction updated successfully!" });
                        }
                        else if (operation == CRUD.DELETE)
                        {
                            return Ok(new { success = true, message = "Transaction deleted successfully!" });
                        }


                    }
                    if (operation == CRUD.READ)
                    {
                        var basic = context.uspGetTransaction(tr_transactionID);
                        var comm = basic.GetNextResult<DataTable>();
                        var contract = basic.GetNextResult<DataTable>();
                        var sec = basic.GetNextResult<DataTable>();
                        var ship = basic.GetNextResult<DataTable>();
                        var status = basic.GetNextResult<DataTable>();
                        var notes = basic.GetNextResult<DataTable>();
                        return Ok(new { success = true, message = "Transaction read successfully!", basic = basic, comm = comm, contract = contract, sec = sec, ship = ship, status = status, notes = notes });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }


        }
        #endregion

        #region transactionCommission

        [Route("TransactionCommissionCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionCommissionCrud([FromBody] JObject commission)
        {
            
                var tr_commission = commission["data"];
                var tr_transactionID = (long?)(tr_commission["tr_transactionID"]);
                var tr_brokerInvolved = Convert.ToBoolean(tr_commission["tr_brokerInvolved"]);
                var tr_buyerBroker = Convert.ToBoolean(tr_commission["tr_buyerBroker"]);
                var tr_buyerBrokerID = (long?)(tr_commission["tr_buyerBrokerID"]);
                var tr_buyerBroker_comm_type =  Convert.ToString(tr_commission["tr_buyerBroker_comm_type"]);
                var tr_buyerBroker_comm = (int?)tr_commission["tr_buyerBroker_comm"];
                var tr_sellerBroker = Convert.ToBoolean(tr_commission["tr_sellerBroker"]);
                var tr_sellerBrokerID = (long?)(tr_commission["tr_sellerBrokerID"]);
                var tr_own_Commission = (int?)(tr_commission["tr_own_Commission"]);
                var tr_ownCommissionType = Convert.ToString(tr_commission["tr_ownCommissionType"]);
                var tr_difference = (int?)tr_commission["tr_difference"];
                var tr_discount = (int?)tr_commission["tr_discount"];
                var tr_netCommission = (int?)tr_commission["tr_netCommission"];

                var userID = BasicAuthHttpModule.getCurrentUserId();
                var operation = Convert.ToString(tr_commission["operation"]);

                using (var context = new DhoniEnterprisesEntities())
                {
                    if (operation == CRUD.CREATE || operation == CRUD.UPDATE || operation == CRUD.DELETE)
                    {
                        var result = context.uspTransactionCommissionCRUD(
                                 operation
                                , tr_transactionID
                                , tr_brokerInvolved
                                , tr_sellerBroker
                                , tr_sellerBrokerID
                                , null
                                , null
                                , tr_buyerBroker
                                , tr_buyerBrokerID
                                , tr_buyerBroker_comm_type
                                , tr_buyerBroker_comm
                                , tr_own_Commission
                                , tr_ownCommissionType
                                , tr_difference
                                , tr_discount
                                , tr_netCommission
                                , userID
                                , null
                                , userID
                                , null
                        );
                        if (operation == CRUD.CREATE)
                        {
                            return Ok(new { success = true, message = "Transaction Commission added successfully!" });
                        }
                        else if (operation == CRUD.UPDATE)
                        {
                            return Ok(new { success = true, message = "Transaction Commission updated successfully!" });
                        }
                        else if (operation == CRUD.DELETE)
                        {
                            return Ok(new { success = true, message = "Transaction Commission deleted successfully!" });
                        }
                        else if (operation == CRUD.READ)
                        {
                            return Ok(new { success = true, message = "Transaction Commission read successfully!" });
                        }
                        else
                        {
                            return Ok(new { success = false, message = "Unsupported Operation " + operation });
                        }
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }

          
        }

        [Route("getCommissionTransaction")]
        [HttpGet]
        public IHttpActionResult getCommissionTransaction(long id)
        {
            try
            {
                DataTable transaction = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    //transaction = DataTableSerializer.LINQToDataTable(context.uspGetTransaction(id));
                    var commission = context.uspGetCommissionTransaction(id);
                    return Ok(new
                    {
                        success = true,
                        commission = DataTableSerializer.LINQToDataTable(commission)
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }

        #endregion

        #region transactionNotes

        [Route("TransactionNotesList")]
        [HttpGet]
        public IHttpActionResult getTransactionNotesList(long transactionId)
        {
            
                using (var context = new DhoniEnterprisesEntities())
                {
                    
                    var Notes = DataTableSerializer.LINQToDataTable(context.uspGetTransactionNotes(transactionId));
                    return Ok(new
                    {
                        success = true,
                        notes = Notes
                    });
                }
           
        }
        
        [Route("TransactionNotesCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionNotesCrud([FromBody] JObject note)
        {
            try
            {
                var tr_note = note["data"];
                var tr_transactionID = (long?)(tr_note["tr_transactionID"]);
                var tr_tranNoteID = (long?)(tr_note["tr_tranNoteID"]);
                var tr_transactionNotes = Convert.ToString(tr_note["tr_transactionNotes"]);
                var userID = BasicAuthHttpModule.getCurrentUserId();
                var operation = Convert.ToString(tr_note["operation"]);

                using (var context = new DhoniEnterprisesEntities())
                {
                    var res = context.uspTransactionNotesCRUD(operation, tr_transactionID, tr_tranNoteID,
                        tr_transactionNotes, userID);
                    if (operation == CRUD.CREATE)
                    {
                        return Ok(new { success = true, message = "Transaction Note added successfully!", noteId = res.FirstOrDefault() });
                    }
                    else if (operation == CRUD.UPDATE)
                    {
                        return Ok(new { success = true, message = "Transaction Note updated successfully!" });
                    }
                    else if (operation == CRUD.DELETE)
                    {
                        return Ok(new { success = true, message = "Transaction Note deleted successfully!" });
                    }
                    else if (operation == CRUD.READ)
                    {
                        return Ok(new { success = true, message = "Transaction Note read successfully!" });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
        }


        #endregion

        #region transactionShipment
        [Route("getTransactionShipment")]
        [HttpGet]
        public IHttpActionResult GetTransactionShipment(long transactionId)
        {
            
                using (var context = new DhoniEnterprisesEntities())
                {

                    var shipment = DataTableSerializer.LINQToDataTable(context.uspGetTransactionShipment(transactionId));
                    return Ok(new
                    {
                        success = true,
                        shipment = shipment
                    });
                }
           
                    
        }

        [Route("TransactionShipmentCRUD")]
        [HttpPost]
        public IHttpActionResult TransactionShipmentCrud([FromBody] JObject shipment)
        {
            try
            {
                using (var context = new DhoniEnterprisesEntities())
                {
                    var tr_ship = shipment["data"];
                    var operation = Convert.ToString(tr_ship["operation"]);
                    var userID = BasicAuthHttpModule.getCurrentUserId();
                    var tr_transactionID = (long?)(tr_ship["tr_transactionID"]);
                    var tr_ship_notShipped = Convert.ToBoolean(tr_ship["tr_ship_notShipped"]);
                    var tr_ship_notShipped_reason = Convert.ToString(tr_ship["tr_ship_notShipped_reason"]);
                    var tr_ship_extension = Convert.ToString(tr_ship["tr_ship_extension"]);
                    var tr_ship_appReceived = Convert.ToBoolean(tr_ship["tr_ship_appReceived"]);
                    var tr_expectedShipment = (DateTime?)(tr_ship["tr_expectedShipment"]);
                    var tr_inTransit = (DateTime?)(tr_ship["tr_inTransit"]);
                    var tr_shipped = Convert.ToBoolean(tr_ship["tr_shipped"]);
                    var tr_dateShipped = (DateTime?)(tr_ship["tr_dateShipped"]);
                    var tr_expectedArrival = (DateTime?)(tr_ship["tr_expectedArrival"]);
                    var tr_transitPort = Convert.ToString(tr_ship["tr_transitPort"]);
                    var tr_ship_arrivedAtPort = Convert.ToBoolean(tr_ship["tr_ship_arrivedAtPort"]);
                    var tr_dateArrived = (DateTime?)(tr_ship["tr_dateArrived"]);
                    var tr_actualArrived = (DateTime?)(tr_ship["tr_actualArrived"]);
                    var tr_ship_BlNo =  Convert.ToString(tr_ship["tr_ship_BlNo"]);
                    var tr_ship_invoiceNo =  Convert.ToString(tr_ship["tr_ship_invoiceNo"]);
                    var tr_ship_invoiceAmt = (int?)(tr_ship["tr_ship_invoiceAmt"]);
                    var tr_ship_quantity = (int?)(tr_ship["tr_ship_quantity"]);
                    var tr_ship_vesselNo =  Convert.ToString(tr_ship["tr_ship_vesselNo"]);
                    var tr_ship_primaryShipperId = (long?)(tr_ship["tr_ship_primaryShipperId"]);
                    var tr_ship_portLoad =  Convert.ToString(tr_ship["tr_ship_portLoad"]);
                    var tr_ship_portDest =  Convert.ToString(tr_ship["tr_ship_portDest"]);
                    var tr_ship_shipLineCont = Convert.ToString(tr_ship["tr_ship_shipLineCont"]);
                    var tr_ship_chk_reason =  Convert.ToBoolean(tr_ship["tr_ship_chk_reason"]);
                    var tr_ship_chk_shpExt = Convert.ToBoolean(tr_ship["tr_ship_chk_shpExt"]);
                    var tr_ship_chk_expShp = Convert.ToBoolean(tr_ship["tr_ship_chk_expShp"]);
                    var tr_ship_chk_inTransit = Convert.ToBoolean(tr_ship["tr_ship_chk_inTransit"]);
                    var tr_ship_chk_dateShipped = Convert.ToBoolean(tr_ship["tr_ship_chk_dateShipped"]);
                    var tr_ship_chk_expArrival = Convert.ToBoolean(tr_ship["tr_ship_chk_expArrival"]);
                    var tr_ship_chk_transitPort = Convert.ToBoolean(tr_ship["tr_ship_chk_transitPort"]);
                    var tr_ship_chk_dateArrived = Convert.ToBoolean(tr_ship["tr_ship_chk_dateArrived"]);
                    var tr_ship_chk_actualArrived = Convert.ToBoolean(tr_ship["tr_ship_chk_actualArrived"]);
                


                    var res = context.uspTransactionShipmentCRUD(
                                        operation,
                                        tr_transactionID,                                        
                                        tr_ship_notShipped,
                                        tr_ship_notShipped_reason,
                                        tr_ship_extension,
                                        tr_ship_appReceived,
                                        tr_expectedShipment,
                                        tr_inTransit,
                                        tr_shipped,
                                        tr_dateShipped,
                                        tr_expectedArrival,
                                        tr_transitPort,
                                        tr_ship_arrivedAtPort,
                                        tr_dateArrived,
                                        tr_actualArrived,
                                        tr_ship_BlNo,
                                        tr_ship_invoiceNo,
                                        tr_ship_invoiceAmt,
                                        tr_ship_quantity,
                                        tr_ship_vesselNo,
                                        tr_ship_primaryShipperId,
                                        tr_ship_portLoad,
                                        tr_ship_portDest,
                                        tr_ship_shipLineCont,
                                        userID,    
                                        userID,
	                                    tr_ship_chk_reason,
                                        tr_ship_chk_shpExt,
                                        tr_ship_chk_expShp,
                                        tr_ship_chk_inTransit,
                                        tr_ship_chk_dateShipped,
                                        tr_ship_chk_expArrival,
                                        tr_ship_chk_transitPort,
                                        tr_ship_chk_dateArrived,
                                        tr_ship_chk_actualArrived
                    );

                    if (operation == CRUD.CREATE)
                    {
                        return Ok(new { success = true, message = "Transaction shipement details added successfully!"});
                    
                    }
                    else if (operation == CRUD.DELETE)
                    {
                        return Ok(new { success = true, message = "Transaction shipment deleted successfully!" });
                    
                    }
                    else if (operation == CRUD.UPDATE)
                    {
                        return Ok(new { success = true, message = "Transaction shipment updated successfully!" });
                    
                    }

                    return Ok(new
                    {
                        success = true, 
                        message = "Transaction Shipment Operation Executed"
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
                    
        }
        #endregion

        #region secondaryTransaction

        [Route("getSecondaryTransaction")]
        [HttpGet]
        public IHttpActionResult getSecondaryTransaction(long id)
        {
            
                DataTable transaction = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    //transaction = DataTableSerializer.LINQToDataTable(context.uspGetTransaction(id));
                    var sec = context.uspGetSecondaryTransaction(id);
                    return Ok(new
                    {
                        success = true,
                        sec = DataTableSerializer.LINQToDataTable(sec)
                    });
                }
           
        }

        [Route("TransactionSecondaryCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionSecondaryCrud([FromBody] JObject secTransaction)
        {
            try
            {
                var tr_sec = secTransaction["data"];
                var tr_transactionID = (long?)(tr_sec["tr_transactionID"]);
                var tr_sec_tranID = (long?)(tr_sec["tr_sec_tranID"]);
                var tr_sec_bpBuyerID = (long?)(tr_sec["tr_sec_bpBuyerID"]);
                var tr_sec_bpSellerID = (long?)(tr_sec["tr_sec_bpSellerID"]);
                var tr_sec_date = (DateTime?)(tr_sec["tr_sec_date"]);
                var tr_sec_buyerPrice = (int?)(tr_sec["tr_sec_buyerPrice"]);
                var tr_sec_sellerPrice = (int?)(tr_sec["tr_sec_sellerPrice"]);
                var tr_sec_otherInfo = Convert.ToString(tr_sec["tr_sec_otherInfo"]);
                var userID = BasicAuthHttpModule.getCurrentUserId();
                var operation = Convert.ToString(tr_sec["operation"]);

                if (operation == CRUD.CREATE || operation == CRUD.UPDATE)
                {
                    if (tr_sec_date == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Date" });
                    }
                    else if (tr_sec_buyerPrice == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction price" });
                    }
                    else if (tr_sec_sellerPrice == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction price" });
                    }
                    else if (tr_sec_bpBuyerID == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Buyer" });
                    }
                    else if (tr_sec_bpSellerID == null)
                    {
                        return Ok(new { success = false, message = "Please Enter Transaction Seller" });
                    }
                }


                using (var context = new DhoniEnterprisesEntities())
                {
                    var result = context.uspTransactionSecondaryCRUD(
                            operation,
                            tr_transactionID,
                            tr_sec_bpBuyerID,
                            tr_sec_bpSellerID,
                            tr_sec_date,
                            tr_sec_buyerPrice,
                            tr_sec_sellerPrice,
                            tr_sec_otherInfo,
                            userID,
                            userID,
                            tr_sec_tranID
                        );
                    if (operation == CRUD.CREATE)
                    {

                        return Ok(new { success = true, message = "Secondary Transaction added successfully!", sec_id = result.FirstOrDefault() });
                    }
                    else if (operation == CRUD.UPDATE)
                    {
                        return Ok(new { success = true, message = "Secondary Transaction updated successfully!" });
                    }
                    else if (operation == CRUD.DELETE)
                    {
                        return Ok(new { success = true, message = "Secondary Transaction deleted successfully!" });
                    }
                    else if (operation == CRUD.READ)
                    {
                        return Ok(new { success = true, message = "Secondary Transaction read successfully!" });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
        }
        #endregion

        #region transactionContract

        [Route("getTransactionContract")]
        [HttpGet]
        public IHttpActionResult GetTransactionContract(long transactionId)
        {
                using (var context = new DhoniEnterprisesEntities())
                {
                    var contract = DataTableSerializer.LINQToDataTable(context.uspGetTransactionContract(transactionId));
                    return Ok(new
                    {
                        success = true,
                        contract = contract
                    });
                }
          
        }

        [Route("TransactionContractCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionContractCrud([FromBody] JObject contract)
        {
            try
            {
                var tr_contract = contract["data"];
                var tr_transactionID = (long?)(tr_contract["tr_transactionID"]);
                var tr_ownContract = Convert.ToBoolean(tr_contract["tr_ownContract"]);
                var tr_doniContract = Convert.ToBoolean(tr_contract["tr_doniContract"]);
                var userID = BasicAuthHttpModule.getCurrentUserId();
                var tr_ContractualBuyer = (long?)(tr_contract["tr_ContractualBuyer"]);
                var operation = Convert.ToString(tr_contract["operation"]);

                using (var context = new DhoniEnterprisesEntities())
                {
                    context.uspTransactionContractCRUD(
                        operation,
                        tr_transactionID,
                        tr_doniContract,
                        tr_ownContract,
                        tr_ContractualBuyer,
                        userID,
                        userID);

                    if (operation == CRUD.CREATE)
                    {
                        return Ok(new { success = true, message = "Transaction contract added successfully!" });
                    }
                    else if (operation == CRUD.UPDATE)
                    {
                        return Ok(new { success = true, message = "Transaction contract updated successfully!" });
                    }
                    else if (operation == CRUD.DELETE)
                    {
                        return Ok(new { success = true, message = "Transaction contract deleted successfully!" });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
        }
        
        #endregion

        #region transactionStatus

        [Route("getTransactionStatus")]
        [HttpGet]
        public IHttpActionResult GetTransactionStatus(long transactionId)
        {
           
                using (var context = new DhoniEnterprisesEntities())
                {
                    var status = DataTableSerializer.LINQToDataTable(context.uspGetTransactionStatus(transactionId));
                    return Ok(new
                    {
                        success = true,
                        status = status
                    });
                }
           
        }

        [Route("TransactionStatusCrud")]
        [HttpPost]
        public IHttpActionResult PostTransactionStatusCrud([FromBody] JObject status)
        {
            try
            {
                var tr_status = status["data"];
                var tr_transactionID = (long?)(tr_status["tr_transactionID"]);
                var tr_transactionStatus = Convert.ToString(tr_status["tr_transactionStatus"]);
                var tr_washoutValueAtPar = (int?)(tr_status["tr_washoutValueAtPar"]);
                var userID = BasicAuthHttpModule.getCurrentUserId();
                var operation = Convert.ToString(tr_status["operation"]);

                using (var context = new DhoniEnterprisesEntities())
                {
                    context.uspTransactionStatusCRUD(
                        operation,
                        tr_transactionID,
                        tr_transactionStatus,
                        tr_washoutValueAtPar,
                        userID,
                        userID
                    );
                    if (operation == CRUD.CREATE)
                    {
                        return Ok(new { success = true, message = "Transaction status added successfully!" });
                    }
                    else if (operation == CRUD.UPDATE)
                    {
                        return Ok(new { success = true, message = "Transaction status updated successfully!" });
                    }
                    else if (operation == CRUD.DELETE)
                    {
                        return Ok(new { success = true, message = "Transaction status deleted successfully!" });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Unsupported Operation " + operation });
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
        }

        #endregion

        #region transaction_Files
        [HttpGet]
        [Route("getTransactionFiles")]
        public IHttpActionResult getTransactionFiles(long transactionId)
        {
           
                using (var context = new DhoniEnterprisesEntities())
                {
                    var files = context.uspTransactionFileGetAll(transactionId);
                    return Ok(new
                    {
                        success = true,
                        files = DataTableSerializer.LINQToDataTable(files)
                    });

                }
          
        }

        [HttpGet]
        [Route("deleteTransactionFile")]
        public IHttpActionResult deleteTransactionFile(long fileId)
        {
           
                using (var context = new DhoniEnterprisesEntities())
                {
                    context.uspTransactionFileDelete(fileId);
                    return Ok(new
                    {
                        success = true,
                        fileId = fileId,

                    });
                }
         
        }

        [HttpGet]
        [Route("downloadTransactionFile")]
        public HttpResponseMessage downloadTransactionFile(long fileID)
        {
            HttpResponseMessage response;

                using (var content = new DhoniEnterprisesEntities())
                {
                    var result = content.uspTransactionFileGetSingle(fileID).FirstOrDefault();
                    byte[] bytes = result.tf_file;
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(bytes);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(result.tf_fileType);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = result.tf_fileName;

                    return response;

                }
         
        }



        [HttpPost]
        [Route("uploadTransactionDocument")]
        public IHttpActionResult uploadTransactionDocument(string fileName, long transactionId)
        {
            
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files[0];
                    var userID = BasicAuthHttpModule.getCurrentUserId();
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(httpPostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(httpPostedFile.ContentLength);
                    }



                    if (httpPostedFile != null)
                    {
                        using (var context = new DhoniEnterprisesEntities())
                        {
                            var fileId = context.uspTransactionFileAdd(transactionId, fileData, Convert.ToString(httpPostedFile.ContentType), fileName, userID);
                            return Ok(new { success = true, message = "Transaction file added successfully!", fileId = fileId.FirstOrDefault() });

                        }

                    }

                }

                return Ok(new { success = false, message = "File was not uploaded due to some error" });
        


        }
       
        #endregion

        #region transactionGetParameter

        [Route("TransactionGetByParameter")]
        [HttpGet]
        public IHttpActionResult GetTransactionByParameter(string parameter, string textInput, DateTime? dateInput)
        {
            
                using (var context = new DhoniEnterprisesEntities())
                {
                    var transactions = DataTableSerializer.LINQToDataTable(context.uspGetTransactionByParameter(parameter, textInput, (DateTime?)(dateInput)));
                    return Ok(new
                    {
                        success = true,
                        transactions = transactions
                    });
                }
           
        }

        #endregion




    }
}
