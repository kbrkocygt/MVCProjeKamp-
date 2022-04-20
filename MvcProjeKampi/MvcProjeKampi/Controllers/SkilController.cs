using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using FluentValidation.Results;
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
        public  ActionResult SkilTable()
        {
            var values = sm.GetSkils();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkil(Skil p)
        {
            SkilValidator SkilvalidationRules = new SkilValidator();
            ValidationResult results = SkilvalidationRules.Validate(p);

            if (results.IsValid)
            {
                sm.SkilAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteSkil(int id)
        {
            var skilvalues = sm.GetByID(id);
            sm.SkilDelete(skilvalues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkil(int id)
        {
            var skilvalue = sm.GetByID(id);
            return View(skilvalue);
        }

        [HttpPost]
        public ActionResult EditSkil(Skil p)
        {
            sm.SkilUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}