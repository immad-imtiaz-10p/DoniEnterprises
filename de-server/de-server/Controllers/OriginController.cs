using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using de_server.App_Config;
using de_server.Entity_Framework;
using de_server.App_Constants;

namespace de_server.Controllers
{
    [Authorize]
    public class OriginController : ApiController
    {
        [Route("originCRUD")]
        [HttpPost]
        public IHttpActionResult OriginCrud([FromBody] JObject origin)
        {
          
                var operation = Convert.ToString(origin["operation"]);
                var origin_id = (long?)(origin["origin_id"]);
                var origin_name = Convert.ToString(origin["origin_name"]);
                using (var context = new DhoniEnterprisesEntities())
                {
                    if (operation == CRUD.CREATE)
                    {
                        int origin_count = (from orig in context.Origins where orig.origin_name.ToLower() == origin_name.ToLower() select orig).Count();
                        if (origin_count > 0)
                        {
                            return Ok(new { success = false, message = "This origin is already present in the system" });
                        }
                    }

                    if (operation == CRUD.DELETE)
                    {
                        int prod_count = (from prod in context.Products where prod.origin == origin_name select prod).Count();
                        if(prod_count > 0)
                        {
                            return Ok(new { success = false, message = "This origin is used by a product and can not be deleted" });
                        }
                        int tran_count = (from tran in context.Transactions where tran.tr_origin == origin_name select tran).Count();
                        if (tran_count > 0)
                        {
                            return Ok(new { success = false, message = "This origin is used by a transaction and can not be deleted" });
                        }
                        int bp_count = (from bp in context.BusinessPartners where bp.bp_country == origin_name select bp).Count();
                        if (bp_count > 0)
                        {
                            return Ok(new { success = false, message = "This origin is used by a business partner and can not be deleted" });
                        }
 
                    }
                    
                   
                    var res = context.uspOriginCRUD(operation, origin_id, origin_name).FirstOrDefault();
                    
                    return Ok(new
                    {
                        success = true,
                        message = "Origin has been " + operation.ToLower() + "d.",
                        origin_id = res
                    });
                }

           
        }

        [Route("getAllOrigin")]
        [HttpGet]
        public IHttpActionResult GetAllOrigin()
        {
            try
            {
                using (var context = new DhoniEnterprisesEntities())
                {

                    var origins = DataTableSerializer.LINQToDataTable(context.uspGetOriginList());
                    return Ok(new
                    {
                        success = true,
                        origins = origins
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message.ToString() });
            }
        }

    }
}
