using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace de_server.Filters
{
    public class DoniApiExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                if(context.Exception.InnerException == null){
                    context.Response = new HttpResponseMessage { Content = new StringContent(context.Exception.Message, System.Text.Encoding.UTF8, "text/plain"), StatusCode = HttpStatusCode.InternalServerError };
                }
                else{
                    context.Response = new HttpResponseMessage { Content = new StringContent(context.Exception.InnerException.Message, System.Text.Encoding.UTF8, "text/plain"), StatusCode = HttpStatusCode.InternalServerError };
                }
                
            }
        }
    }
}