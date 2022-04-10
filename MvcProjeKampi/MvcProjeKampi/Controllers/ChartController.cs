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
            ct.Add(new CategoryClass()
            {

                CategoryName = "Yazılım", CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {

                CategoryName = "Sanat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {

                CategoryName = "Tiyatro",
                CategoryCount = 3
            });
            ct.Add(new CategoryClass()
            {

                CategoryName = "Müzik",
                CategoryCount = 6
            });
            return ct;
        }
    }
}