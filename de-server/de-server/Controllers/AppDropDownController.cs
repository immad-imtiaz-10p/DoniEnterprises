using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using de_server.App_Config;
using de_server.Entity_Framework;
using de_server.Models;
using Newtonsoft.Json.Linq;
using de_server.Filters;

namespace de_server.Controllers
{
    [DoniApiExceptionFilter]
    [Authorize]
    public class AppDropDownController : ApiController
    {
        [Route("getBPDropDown")]
        [HttpPost]
        public IHttpActionResult getBPDropDown([FromBody] JObject bpType)
        {
           
                var BPType = Convert.ToString(bpType["type"]);
                DataTable data = new DataTable();
                using (var context = new DhoniEnterprisesEntities())
                {
                    if (BPType == "Buyer")
                    {
                        data = DataTableSerializer.LINQToDataTable(context.uspGetDropDownBuyer());
                    }
                    else if (BPType == "Seller")
                    {
                        data = DataTableSerializer.LINQToDataTable(context.uspGetDropDownSeller());
                    }
                    else if (BPType == "Shipper")
                    {
                        data = DataTableSerializer.LINQToDataTable(context.uspGetDropDownShipper());
                    }
                    else if (BPType == "Broker")
                    {
                        data = DataTableSerializer.LINQToDataTable(context.uspGetDropDownBroker());
                    }
                    
                    return Ok(new
                    {
                        success = true,
                        data = data,
                        type = BPType
                    });
                }
            
        }
    }
}
