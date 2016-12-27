using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agl.DevTest.PetOwner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Error()
        {
            //HandleErrorInfo = new HandleErrorInfo();
            //if (Response.StatusCode == 404)
            //{
            //    ex = new Exception("Page requested is not found.");
            //}
            //else
            //{
            //    ex = new Exception("Unknown error occured.");
            //}
            return View();
        }
    }
}