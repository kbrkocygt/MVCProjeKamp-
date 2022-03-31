using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        Context c= new Context();
        MessageManager cm = new MessageManager(new EfMessageDal());
      
        // GET: Message
        public ActionResult Inbox()
        {
            var mesage = cm.GetListInbox();
            return View(mesage);
        }
        public ActionResult Sendbox()
        {
           


            var messagelist = cm.GetListSendbox();
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
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
           
            return View();
        }

        public PartialViewResult MessageListPartial()
        {
            //iLETİŞİM kısmındaki Toplam mesaj sayısı
            var messageCount = c.Contacts.Count();
            ViewBag.messageCountView = messageCount;


            //alıcısı admın olan mesaj sayısı
            var messageByReceiverCount = c.Messages.Count(x=>x.RecevierMail=="admin@gmail.com");
            ViewBag.messageCountReceiver = messageByReceiverCount;

            //göndereni admin olan mesajsayısı
            var messageBySender = c.Messages.Count(x => x.SenderMail == "admin@gmail.com");
            ViewBag.messageCountSender = messageBySender;
            return PartialView();
        }

    }
}