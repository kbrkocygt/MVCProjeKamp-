using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(int p=1)
        {
            var headingValues = hm.GetList().ToPagedList(p,4);
            return View(headingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName, //displeymember
                                                      Value = x.CategoryID.ToString() //valuemember

                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + "" + x.WriterSurname,
                                                    Value = x.WriterID.ToString()

                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }


        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName, //displeymember
                                                      Value = x.CategoryID.ToString() //valuemember

                                                  }).ToList();


            ViewBag.vlc = valuecategory;
            var hedaingValue = hm.GetByID(id);
            return View(hedaingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading  p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
                
            }
            else if (headingValue.HeadingStatus == false)
            {
                headingValue.HeadingStatus = true;
                
            }
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}