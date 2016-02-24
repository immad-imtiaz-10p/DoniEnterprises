using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using de_server.Providers;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(de_server.Startup))]

namespace de_server
{
    [assembly: OwinStartup(typeof(de_server.Startup))]
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureOAuth(app);
            //HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
            
            //From the tutotial
            HttpConfiguration config = new HttpConfiguration();
            app.MapSignalR();
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            //app.UseWebApi(config);

        }

        
    }
}
