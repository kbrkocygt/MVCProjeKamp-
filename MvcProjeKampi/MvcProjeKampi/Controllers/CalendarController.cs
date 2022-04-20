using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        [HttpGet]
        public ActionResult AdminCalendar()
        {
            return View(new Calendar());
        }
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calendar();
            var events = new List<Calendar>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in hm.GetList())
            {
                events.Add(new Calendar()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}