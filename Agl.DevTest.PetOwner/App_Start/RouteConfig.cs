using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Agl.DevTest.PetOwner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{pet}",
                defaults: new { controller = "Owner", action = "AllOwners", pet = UrlParameter.Optional }
            );

            routes.MapMvcAttributeRoutes();
        }
    }
}
