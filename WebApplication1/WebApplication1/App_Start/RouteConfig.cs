using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //路由參數
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //若有設DEFAULT值, 即便網址列不打也會ROUTE
            );
        }
    }
}
