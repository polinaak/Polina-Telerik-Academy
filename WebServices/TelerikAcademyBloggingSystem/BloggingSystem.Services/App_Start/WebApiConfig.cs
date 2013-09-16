﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BloggingSystem.Services
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "TagsApi",
                routeTemplate: "api/tags/{tagId}/posts",
                defaults: new
                {
                    controller = "tags",
                    action = "posts"
                });

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                });

            //config.Routes.MapHttpRoute(
            //     name: "TagsApi",
            //     routeTemplate: "api/tags/{action}",
            //     defaults: new
            //     {
            //         controller = "tags"
            //     }
            // );

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

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
