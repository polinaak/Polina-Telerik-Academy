using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Places.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PlaceByTown",
                routeTemplate: "api/places/town/{townId}",
                defaults: new { controller = "places", action = "town" });

            config.Routes.MapHttpRoute(
                name: "PlacesApi",
                routeTemplate: "api/places/{placeId}/{action}",
                defaults: new { controller = "places", placeId = RouteParameter.Optional, action = RouteParameter.Optional });
            
            config.Routes.MapHttpRoute(
                name: "TownsApi",
                routeTemplate: "api/towns/{townId}/",
                defaults: new { controller = "towns"});

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "users", action = RouteParameter.Optional });
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
