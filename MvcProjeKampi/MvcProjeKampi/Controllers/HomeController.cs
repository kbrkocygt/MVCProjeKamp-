using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}