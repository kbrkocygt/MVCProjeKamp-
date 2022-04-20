using DataAccesLayer.Concrete;
using EntittyLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            Context c = new Context();
            ct = c.Categories.Select(x => new CategoryClass
            {

                CategoryName = x.CategoryName,
                CategoryCount = x.Headings.Count
                
          
            }).ToList();

            return ct;
           
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterChart> WriterList()
        {
            List<WriterChart> cc = new List<WriterChart>();
            Context c = new Context();
            cc= c.Writers.Select(x => new WriterChart
            {

                WriterName = x.WriterName,
                WriterCount = x.Headings.Count


            }).ToList();
            return cc;

        }



        public ActionResult Chart3()
        {
            return View();
        }
        public ActionResult SkilChart()
        {
            return Json(SkilList(), JsonRequestBehavior.AllowGet);
        }
        public List<SkilChart> SkilList()
        {
            List<SkilChart> cc = new List<SkilChart>();
            Context c = new Context();
            cc = c.skils.Select(x => new SkilChart
            {

                SkilName = x.Yetenek,
                SkilCount = x.SkilID


            }).ToList();
            return cc;

        }
    }
}