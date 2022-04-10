﻿using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {//SİTE ANSAYFA
     // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager CM = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = CM.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}