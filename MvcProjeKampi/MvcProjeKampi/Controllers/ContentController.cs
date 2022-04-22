using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p,int page=1)
        {
            if(p==null)
            {
                var value = cm.GetList().ToPagedList(page,6);
                return View(value);
            }
            else
            {
                var valuess = cm.GetList(p);
                return View(valuess.ToPagedList(page, 6));
            }
                
        }
        public ActionResult ContentByHeading(int id)
        {

            var contentValues = cm.GetListByHeadingID(id);
            return View(contentValues);
        }

    }
}