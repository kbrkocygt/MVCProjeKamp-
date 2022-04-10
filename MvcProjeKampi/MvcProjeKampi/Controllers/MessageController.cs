using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
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
    public class MessageController : Controller
    {
        Context c = new Context();
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();

        // GET: Message
        [Authorize]
        public ActionResult Inbox(string p ,string aranacak)
        {
            //string adminUserName = (string)Session["AdminUserName"];
            //ViewBag.unRead = mm.GetCountUnreadMessage(adminUserName);
            //var mesage = mm.GetListInbox(p);

            if (aranacak== null)
            {
                var value = mm.GetInbox(aranacak);
                return View(value);
            }
            else
            {
                string adminUserName = (string)Session["AdminUserName"];
                ViewBag.unRead = mm.GetCountUnreadMessage(adminUserName);
                var mesage = mm.GetListInbox(p);
                return View(mesage);
            }


          
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            if (values.isRead!=true)
            {
                values.isRead = true;
                mm.MessageUpdate(values);
            }
            return View(values);
        }
        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
      
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = mv.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
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
        public ActionResult Draft(string p)
        {
            var sendList = mm.GetListSendbox(p);
            var draftList = sendList.FindAll(x => x.isDraft == true);
            return View(draftList);
        }
        public PartialViewResult MessageListPartial(string p)
        {
            //iLETİŞİM kısmındaki Toplam mesaj sayısı
            var messageCount = c.Contacts.Count();
            ViewBag.messageCountView = messageCount;


            //alıcısı admın olan mesaj sayısı
            var messageByReceiverCount = c.Messages.Count(x => x.RecevierMail == p);
            ViewBag.messageCountReceiver = messageByReceiverCount;

            //göndereni admin olan mesajsayısı
            var messageBySender = c.Messages.Count(x => x.SenderMail == p);
            ViewBag.messageCountSender = messageBySender;
            return PartialView();
        }
       
        public ActionResult DeleteMessage(int id)
        {
          id = 1013;
            var messageyvalue = mm.GetByID(id);
            mm.MessageDelete(messageyvalue);
            return RedirectToAction("Inbox");

           
        }
      
    }
}