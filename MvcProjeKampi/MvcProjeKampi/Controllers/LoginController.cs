using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntittyLayer.Concrete;
using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous] //login sayfası outurum engelinden  muaf olsun
    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        AdminValidator av = new AdminValidator();
        WriterValidator wv = new WriterValidator();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
           
            var adminUserInfo = am.GetAdmin(admin.AdminUserName, admin.AdminPassword);
          
            if (adminUserInfo != null)
            {
                //login işlemleri
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");

            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {  
            
            // recaptcha
            var encodedResponse = Request.Form["g-Recaptcha-Response"];
            var isCaptchaValid = ReCaptcha.Validate(encodedResponse);

            var writerInfo = wm.GetWriter(writer.WriterMail, writer.WriterPassword);

            if (writerInfo != null && isCaptchaValid)
            {
                //login işlemleri

                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");

            }
            else
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return RedirectToAction("WriterLogin");

            }



        }

        public class ReCaptcha
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
          
            public static bool Validate(string encodedResponse)
            {
                if (string.IsNullOrEmpty(encodedResponse)) return false;

                var client = new System.Net.WebClient();
                var secret = "6LfOMUQfAAAAAJjGNBl_Ga0p59oUYzs2rJnNFFHU";

                if (string.IsNullOrEmpty(secret)) return false;

                var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse));

                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                var reCaptcha = serializer.Deserialize<ReCaptcha>(googleReply);

                return reCaptcha.Success;
               
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}