using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ım = new ImageFileManager(new EfImageFileDal());
        // GET: Galery
        public ActionResult Index()
        {
            var galeryValues = ım.GetList();
            return View(galeryValues);
        }
    }
}