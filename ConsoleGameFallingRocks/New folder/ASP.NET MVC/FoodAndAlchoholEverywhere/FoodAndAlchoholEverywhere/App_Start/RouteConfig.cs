using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodAndAlchoholEverywhere
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Food",
                url: "Food/{action}/{id}",
                defaults: new { controller = "Food", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Drinks",
                url: "Drinks/{action}/{id}",
                defaults: new { controller = "Drinks", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
