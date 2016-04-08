using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Pkcs;
using System.Web.Http;
using de_server.App_Config;
using de_server.Entity_Framework;
using de_server.Models;
using de_server.Security;
using Newtonsoft.Json.Linq;
using de_server.Filters;

namespace de_server.Controllers
{

    [DoniApiExceptionFilter]
    [Authorize]
    public class BusinessPartnerController : ApiController
    {
        #region BusinessPartner

        [Route("addBusinessPartner")]
        [HttpPost]
        public IHttpActionResult PostaddBusinessPartner([FromBody] JObject businessPartner)
        {

            var generalDetails = businessPartner["businessPartner"];

            using (var context = new DhoniEnterprisesEntities())
            {
                int userID = BasicAuthHttpModule.getCurrentUserId();
                if (userID != -1)
                {
                    DataTable dt = new DataTable();
                    var bpId = context.uspAddBusinessPartner(Convert.ToBoolean(generalDetails["bp_isSeller"]),
                        Convert.ToBoolean(generalDetails["bp_isBroker"]),
                        Convert.ToBoolean(generalDetails["bp_isShipper"]),
                        Convert.ToBoolean(generalDetails["bp_isBuyer"]),
                        Convert.ToBoolean(generalDetails["bp_onDoniContract"]), userID,
                        Convert.ToInt32(generalDetails["bp_credibilityIndex"]),
                        generalDetails["bp_Name"].ToString(), generalDetails["bp_website"].ToString(),
                        generalDetails["bp_address"].ToString(), generalDetails["bp_country"].ToString());

                    return Ok(new { success = true, message = "Business Partner Added!", data = bpId.FirstOrDefault() });
                }
                else
                {
                    return Ok(new { success = false, message = "No User Logged In!" });
                }
            }
        }

        [Route("deleteBusinessPartner/{id:long}")]
        [HttpGet]
        public IHttpActionResult DeleteBusinessPartner(long id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                context.uspDeleteBusinessPartner(id);
                return Ok(new { success = true, message = "Business Partner Successfully deleted!" });

            }
        }

        [Route("updateBusinessPartner")]
        [HttpPost]
        public IHttpActionResult UpdateBusinessPartner([FromBody] JObject businessPartner)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                int userID = BasicAuthHttpModule.getCurrentUserId();
                if (userID != -1)
                {
                    var generalDetails = businessPartner["businessPartner"];
                    var bpId = (long?)generalDetails["bp_ID"];
                    DataTable dt = new DataTable();
                    context.uspUpdateBusinessPartner(
                        bpId,
                        Convert.ToBoolean(generalDetails["bp_isSeller"]),
                        Convert.ToBoolean(generalDetails["bp_isBroker"]),
                        Convert.ToBoolean(generalDetails["bp_isShipper"]),
                        Convert.ToBoolean(generalDetails["bp_isBuyer"]),
                        Convert.ToBoolean(generalDetails["bp_onDoniContract"]), userID,
                        Convert.ToInt32(generalDetails["bp_credibilityIndex"]),
                        generalDetails["bp_Name"].ToString(), generalDetails["bp_website"].ToString(),
                        generalDetails["bp_address"].ToString(), generalDetails["bp_country"].ToString());

                    return Ok(new { success = true, message = "Business Partner Updated!" });
                }
                else
                {
                    return Ok(new { success = false, message = "No User Logged In!" });
                }
            }
        }


        [Route("getBusinessPartnerList")]
        [HttpGet]
        public IHttpActionResult GetBusinessPartnerList()
        {
            try
            {
                DataTable dt = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    dt = DataTableSerializer.LINQToDataTable(context.uspGetBusinessPartnerForTable());
                    return Ok(new { success = true, data = dt });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }

        [Route("getBusinessPartnerFull/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetBusinessPartnerFull(long id)
        {

            DataTable general = new DataTable();
            DataTable bankInfo = new DataTable();
            DataTable contactNumbers = new DataTable();
            DataTable contactPerson = new DataTable();
            DataTable emails = new DataTable();
            DataTable products = new DataTable();
            using (var context = new DhoniEnterprisesEntities())
            {
                general = DataTableSerializer.LINQToDataTable(context.uspGetBPGeneral(id));
                bankInfo = DataTableSerializer.LINQToDataTable(context.uspGetBPBank(id));
                contactNumbers = DataTableSerializer.LINQToDataTable(context.uspGetBPContactNumber(id));
                contactPerson = DataTableSerializer.LINQToDataTable(context.uspGetBPContact(id));
                emails = DataTableSerializer.LINQToDataTable(context.uspGetBPEmails(id));
                products = DataTableSerializer.LINQToDataTable(context.uspGetBPProducts(id));
                return Ok(new
                {
                    success = true,
                    gen = general,
                    bank = bankInfo,
                    contNum = contactNumbers,
                    contPers = contactPerson,
                    emails = emails,
                    products = products
                });
            }

        }


        #endregion

        #region BankDetails

        [Route("deleteBusinessPartnerBank/{id:long}")]
        [HttpGet]
        public IHttpActionResult deleteBusinessPartnerBank(long id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                context.uspDeleteBusinessPartnerBankDetails(id);
                return Ok(new { success = true, message = "Business Partner Bank Details Successfully Deleted!" });

            }
        }

        [Route("addBusinessPartnerBankDetails")]
        [HttpPost]
        public IHttpActionResult addBusinessPartnerBankDetails([FromBody] JObject bankDetails)
        {
            var ba = bankDetails["bankDetails"];

            using (var context = new DhoniEnterprisesEntities())
            {
                int userID = BasicAuthHttpModule.getCurrentUserId();
                if (userID != -1)
                {
                    var res = context.uspAddBusinessPartnerBankDetails(Convert.ToInt64(ba["bp_ID"]), Convert.ToString(ba["branchAddress"]), Convert.ToString(ba["bankName"]), Convert.ToString(ba["accountTitle"]), Convert.ToString(ba["accountNumber"]), Convert.ToString(ba["accountCountry"])).FirstOrDefault();
                    return Ok(new { success = true, message = "Business Partner Bank Account added!", bankId = res });
                }
                else
                {
                    return Ok(new { success = false, message = "No User Logged In!" });
                }
            }

        }

        #endregion

        #region ContactNumbers

        [Route("deleteBusinessPartnerContactNumber/{id:long}")]
        [HttpGet]
        public IHttpActionResult deleteBusinessPartnerContactNumber(long id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                context.uspDeleteBusinessPartnerContactNumber(id);
                return Ok(new { success = true, message = "Contact Number Successfully Deleted!" });

            }
        }

        [Route("addBusinessPartnerContact")]
        [HttpPost]
        public IHttpActionResult addBusinessPartnerContact([FromBody] JObject contact)
        {
            var cn = contact["contact"];

            if (Convert.ToString(cn["contactType"]) == "")
            {
                return Ok(new { success = false, message = "No contact type entered!" });
            }

            if (Convert.ToString(cn["contactNumber"]) == "")
            {
                return Ok(new { success = false, message = "No Contact Number entered!" });
            }



            using (var context = new DhoniEnterprisesEntities())
            {
                int userID = BasicAuthHttpModule.getCurrentUserId();
                if (userID != -1)
                {
                    var res = context.uspAddBusinessPartnerContactNumber(Convert.ToInt64(cn["bp_ID"]), Convert.ToString(cn["contactType"]), Convert.ToString(cn["contactNumber"]), userID).FirstOrDefault();
                    return Ok(new { success = true, message = "Business Partner contact number added!", conNumID = res });
                }
                else
                {
                    return Ok(new { success = false, message = "No User Logged In!" });
                }
            }

        }



        #endregion

        #region ContactPerson


        [Route("deleteBusinessPartnerContact/{id:long}")]
        [HttpGet]
        public IHttpActionResult deleteBusinessPartnerContact(long id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                context.uspDeleteBusinessPartnerContact(id);
                return Ok(new { success = true, message = "Contact Person Successfully Deleted!" });

            }
        }





        [Route("addBusinessPartnerContactPerson")]
        [HttpPost]
        public IHttpActionResult addBusinessPartnerContactPerson([FromBody] JObject contactPerson)
        {

            var cp = contactPerson["contactPerson"];

            using (var context = new DhoniEnterprisesEntities())
            {
                int userID = BasicAuthHttpModule.getCurrentUserId();
                if (userID != -1)
                {
                    int alreadyPrimary = Convert.ToInt32(context.uspCheckBPPrimaryContactExist(Convert.ToInt32(cp["bp_ID"])).FirstOrDefault());
                    if (alreadyPrimary <= 0 || !(Convert.ToBoolean(cp["bp_Cont_IsPrimary"])))
                    {
                        DataTable dt = new DataTable();
                        var res = context.uspAddBusinessPartnerContact(Convert.ToInt32(cp["bp_ID"]),
                            Convert.ToBoolean(cp["bp_Cont_IsPrimary"]), cp["bp_Cont_fullName"].ToString(),
                            cp["bp_Cont_Designation"].ToString(), cp["bp_Cont_Email"].ToString(),
                            cp["bp_Cont_PrimaryNumber"].ToString(), cp["bp_Cont_SecondaryNumber"].ToString(), userID).FirstOrDefault();
                        return Ok(new { success = true, message = "Business Partner Contact Added!", conPerId = res });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "This Business Partner already has one primary contact!" });
                    }

                }
                else
                {
                    return Ok(new { success = false, message = "No User Logged In!" });
                }
            }
        }



        #endregion

        #region BP_Product

        [Route("addBusinessPartnerProduct")]
        [HttpPost]
        public IHttpActionResult addBusinessPartnerProduct([FromBody] JObject Product)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                var bpProd = Product["bpProduct"];
                var bpId = Convert.ToInt64(bpProd["bpId"]);
                var pId = Convert.ToInt32(bpProd["product"]);
                context.uspAddBusinessPartnerProducts(bpId, pId);
                return Ok(new { success = true, message = "Business Partner product added successfully !" });


            }
        }

        [Route("deleteBusinessPartnerProduct")]
        [HttpPost]
        public IHttpActionResult deleteBusinessPartnerProduct([FromBody] JObject Product)
        {
            using (var context = new DhoniEnterprisesEntities())
            {

                var bpProd = Product["bpProduct"];
                var bpId = Convert.ToInt64(bpProd["bpId"]);
                var pId = Convert.ToInt32(bpProd["product"]);
                context.uspDeleteBusinessPartnerProducts(bpId, pId);
                return Ok(new { success = true, message = "Business Partner product successfully deleted!" });


            }

        }

        #endregion BP_Product
    }
}
