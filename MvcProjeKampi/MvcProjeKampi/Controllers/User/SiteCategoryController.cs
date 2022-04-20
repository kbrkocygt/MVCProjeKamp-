using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.User
{
    public class SiteCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
     
      
        public ActionResult Index()
        {
            
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
    }
}