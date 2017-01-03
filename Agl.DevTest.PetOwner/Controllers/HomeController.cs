using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agl.DevTest.PetOwner.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Error()
        {            
            return View();
        }
    }
}