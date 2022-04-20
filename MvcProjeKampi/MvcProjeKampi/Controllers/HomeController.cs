using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using MvcProjeKampi.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        Context c = new Context();
        ViewModel viewModel = new ViewModel();
        // GET: Home
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        public PartialViewResult HomeNotification(string p)
        {
           viewModel.Messages= mm.GetMessagesInbox(p);
         
            return PartialView(viewModel);
        }
        public ActionResult MyBlog()
        {

            viewModel.Contents = contentManager.GetList();
            viewModel.Categories = cm.GetList();
            return PartialView(viewModel);


        }

        public ActionResult ContentDetails(int id)
        {
            viewModel.Contents = contentManager.GetListByHeadingID(id);

            return View(viewModel);

            //return View();
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
        public PartialViewResult Content()
        {
            return PartialView();
        }
        public PartialViewResult SideBar()
        {

            return PartialView();
        }
        public PartialViewResult CategoryList(string p)
        {
           
            viewModel.Categories = cm.GetList();

            return PartialView(viewModel);
        }
        public PartialViewResult RecentPost()
        {
            List<Content> content = c.Contents.OrderByDescending(m => m.ContentID).Take(5).ToList();
            return PartialView(content);
        }


    }
}