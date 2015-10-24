using System.Web.Mvc;
using System.Web.Routing;

namespace RollYourOwnAuth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                }
            );

            routes.MapRoute(
                name: "Product",
                url: "p/{brandname}/{productname}/{id}",
                defaults: new
                {
                    controller = "Product",
                    action = "Index",
                }
            );

            routes.MapRoute(
                name: "Brand",
                url: "b/{brandname}/",
                defaults: new
                {
                    controller = "Brand",
                    action = "Index",
                }
            );

            routes.MapRoute(
                name: "Basket",
                url: "basket/",
                defaults: new
                {
                    controller = "Basket",
                    action = "Index",
                }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
