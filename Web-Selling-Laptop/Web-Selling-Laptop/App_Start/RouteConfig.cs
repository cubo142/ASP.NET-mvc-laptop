using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Selling_Laptop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Trang chủ",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Laptop", action = "Home", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Giỏ hàng",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Laptop", action = "Cart", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );
        }
    }
}
