using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkilController : Controller
    {
        SkilManager sm = new SkilManager(new EfSkilDal());
        // GET: Skil
        public ActionResult Index()
        {
            var values = sm.GetSkils();
            return View(values);
        }
    }
}