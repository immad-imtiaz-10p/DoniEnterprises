using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using de_server.App_Config;
using de_server.Filters;
using de_server.Entity_Framework;
using Newtonsoft.Json.Linq;

namespace de_server.Controllers
{
    [DoniApiExceptionFilter]
    [Authorize]
    public class ReportsController : ApiController
    {
        [Route("getArrivedAtPortReport")]
        [HttpGet]
        public IHttpActionResult GetArrivedAtPortReport(DateTime startDate, DateTime endDate)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                DataTable report = new DataTable();
                report = DataTableSerializer.LINQToDataTable(context.uspGetArrivedAtPortByDateRange(startDate, endDate));
                return Ok(new
                {
                    success = true,
                    report = report
                });
            }
        }

        [Route("getExpectedArrivalReport")]
        [HttpGet]
        public IHttpActionResult GetExpectedArrivalReport(DateTime startDate, DateTime endDate)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                DataTable report = new DataTable();
                report = DataTableSerializer.LINQToDataTable(context.uspGetExpextedArrivalAtPortByDateRange(startDate, endDate));
                return Ok(new
                {
                    success = true,
                    report = report
                });
            }
        }

        [Route("getShipmentExpirationReport")]
        [HttpGet]
        public IHttpActionResult GetShipmentExpirationReport(DateTime startDate, DateTime endDate)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                DataTable report = new DataTable();
                report = DataTableSerializer.LINQToDataTable(context.uspGetShipmentExpirationByDateRange(startDate, endDate));
                return Ok(new
                {
                    success = true,
                    report = report
                });
            }
        }
    }
}
