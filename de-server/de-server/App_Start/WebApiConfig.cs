using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;

namespace de_server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //Enabling Cors for angular
            config.EnableCors(); 
            
            //Enabling Authorization Filter on all actions and controller
            //config.Filters.Add(new AuthorizeAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Enforce HTTPS protocol
            config.Filters.Add(new de_server.Filters.RequireHttpsAttribute());
            

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
           // config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

            //From the tutorial
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
