using System.Web;
using System.Web.Mvc;

namespace de_server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Enforce HTTPS protocol
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
