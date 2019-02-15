using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{pname}",
                defaults: new { controller = "Home", action = "Index", pname = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Greeting", // Route name
                 url: "Go/Hi/{greetDate}", // greetDate=paramter-name
                 defaults: new { controller = "Hello", action = "Greet", greetDate = UrlParameter.Optional }
             );

            
        }
    }
}
