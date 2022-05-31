using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DDTBaiTapLon486
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SanPham",
                url: "san-pham",
                defaults: new { controller = "SanPhams", action = "Index", id = UrlParameter.Optional }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Themmoi",
                url: "san-pham/them-moi",
                defaults: new { controller = "SanPhams", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Chinhsua",
                url: "san-pham/chinh-sua",
                defaults: new { controller = "SanPhams", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Xoa",
                url: "san-pham/xoa-san-pham",
                defaults: new { controller = "SanPhams", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Xemchitiet",
                url: "san-pham/chi-tiet-san-pham",
                defaults: new { controller = "SanPhams", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
