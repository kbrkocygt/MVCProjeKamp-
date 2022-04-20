using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.User
{
    public class SiteAboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        ViewModel viewModel = new ViewModel();
        // GET: SiteAbout
        public ActionResult Index()
        {


            viewModel.Abouts = am.GetList();

            return View(viewModel);
        }
    }
}