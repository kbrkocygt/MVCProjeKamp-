using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();

            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            am.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public  PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}