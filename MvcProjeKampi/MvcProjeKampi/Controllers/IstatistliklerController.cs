using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistliklerController : Controller
    {
        Context c = new Context();
        // GET: Istatistlikler
        public ActionResult Index()
        {
            var totalCategoryNumber = c.Categories.Count();
            ViewBag.totalCategory = totalCategoryNumber;



            var totalSoftwareCategory = c.Headings.Count(x => x.CategoryID == 7);
            ViewBag.totalSoftware = totalSoftwareCategory;


            var writerNameCharacter = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.totalCharacter = writerNameCharacter;


            var maxTitle = c.Categories.Max(x => x.CategoryName);
            ViewBag.maxCategoryTitle = maxTitle;


            var statusTrueCategory = c.Categories.Count(x => x.CategoryStatus==true);
            ViewBag.statusTrueCategoryNumber = statusTrueCategory;
            return View();

        }
    }
}