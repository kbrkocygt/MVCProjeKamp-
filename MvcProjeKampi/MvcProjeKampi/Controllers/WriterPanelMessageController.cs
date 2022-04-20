﻿using BusinessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context context = new Context();
        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriterInbox()
        {
            string receiver = (string)Session["WriterMail"];
            var MessageList = messageManager.GetMessagesInbox(receiver);
            return View(MessageList);
        }

        public ActionResult WriterSendBox()
        {
            string sender = (string)Session["WriterMail"];
            var result = messageManager.GetMessageSendBox(sender);
            return View(result);
        }

        public PartialViewResult MessagePartial()
        {

            var sendMail = messageManager.GetMessagesInbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetMessageSendBox().Count();
            ViewBag.receiverMail = receiverMail;



            var draftMail = messageManager.GetMessageSendBox().Where(m => m.isDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = messageManager.GetMessagesInbox().Where(m => m.isRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }

        public ActionResult GetWriterMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message, string button)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult validationResult = messageValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.SenderMail = sender;
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Insert(message);
                    return RedirectToAction("WriterSendbox");
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

                    message.SenderMail = sender;
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
                return RedirectToAction("AddMessage");
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
    }
}
