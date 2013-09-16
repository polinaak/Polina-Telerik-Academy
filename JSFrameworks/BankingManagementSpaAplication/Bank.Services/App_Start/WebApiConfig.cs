using System;
using System.Linq;
using System.Web.Http;

namespace Bank.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                 name: "TransactionsApi",
                 routeTemplate: "api/transactions/{action}",
                 defaults: new
                 {
                     controller = "transactions"
                 }
             );

            config.Routes.MapHttpRoute(
                 name: "AccountsApi",
                 routeTemplate: "api/accounts/{action}",
                 defaults: new
                 {
                     controller = "accounts",
                     action = "create"
                 }
             );

            config.Routes.MapHttpRoute(
                 name: "UsersApi",
                 routeTemplate: "api/users/{action}",
                 defaults: new
                 {
                     controller = "users"
                 }
             );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
