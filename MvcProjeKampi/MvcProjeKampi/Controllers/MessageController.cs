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
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {

            var MessageList = messageManager.GetMessagesInbox();
            return View(MessageList);
        }

        public ActionResult SendBox()
        {

            var result = messageManager.GetMessageSendBox();
            return View(result);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult validationResult = messageValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Insert(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "draft")
            {
                if (validationResult.IsValid)
                {

                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Insert(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("NewMessage");
            }

            return View();
        }

        public ActionResult DeleteMessage(int id)
        {
            var result = messageManager.GetById(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            messageManager.Delete(result);
            return RedirectToAction("Inbox");

        }

        public ActionResult Draft()
        {
            var result = messageManager.IsDraft();
            return View(result);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result = messageManager.GetById(id);
            if (result.isRead == false)
            {
                result.isRead = true;
            }
            else
            {
                result.isRead = false;
            }
            messageManager.Update(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageRead()
        {
            var result = messageManager.GetMessagesInbox().Where(m => m.isRead == true).ToList();
            return View(result);
        }

        public ActionResult MessageUnRead()
        {
            var result = messageManager.GetAllRead();
            return View(result);
        }
        public PartialViewResult MessageListPartial()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetMessageSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetMessagesInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetMessageSendBox().Where(m => m.isDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = messageManager.GetMessagesInbox().Where(m => m.isRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }

}
