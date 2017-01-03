using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Agl.DevTest.PetOwner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();

            //Log exception

            HttpException httpEx = exception as HttpException;
            if (httpEx != null && httpEx.GetHttpCode() == 404)
            {
                //Handle Page not found
                Response.Redirect("/Home/NotFound");
            }
            else
            {
                Response.Redirect("/Home/Error");
            }
        }
    }
}
