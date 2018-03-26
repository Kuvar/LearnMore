using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearnMore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Tag",
               url: "{controller}/{action}/{id}/{p}",
               defaults: new { controller = "Blog", action = "Tag" }
           );

            routes.MapRoute(
               name: "Category",
               url: "{controller}/{action}/{id}/{p}",
               defaults: new { controller = "Blog", action = "Category" }
           );

            routes.MapRoute(
              name: "LatestPost",
              url: "Blog/Post/{year}/{month}/{title}",
              defaults: new { controller = "Blog", action = "Post", year = "", month = "", title = "" }
          );

            routes.MapRoute(
              name: "Post",
              url: "Blog/Post/{year}/{month}/{day}/{title}",
              defaults: new { controller = "Blog", action = "ReadMore", year = "", month = "", day = "", title = "" }
          );

            routes.MapRoute(
               name: "Contact",
               url: "Contact",
               defaults: new { controller = "Home", action = "Contact" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}