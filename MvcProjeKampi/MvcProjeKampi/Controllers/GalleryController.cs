using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = "/images/" + fileName;
                ım.Add(ımageFile);
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}