using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(Manager.ContactManager.GetAll());
        }

        public ActionResult Reply(int ID)
        {
            return View(Manager.ContactManager.GetByID(ID));
        }

        [HttpPost]
        public ActionResult Reply(Message _message)
        {

            Manager.ContactManager.Edit(_message);
            #region Mail Gönderme İşlemi
            //var currentUser = "mail adresi";

            //string mailParolası = "Parola";


            //if (_message != null)
            //{
            //    MailMessage mail = new MailMessage();
            //    mail.From = new MailAddress(currentUser);

            //    mail.To.Add(_message.ContactEMail);
            //    mail.Subject = _message.ReplyTitle;
            //    mail.Body = _message.ReplyContent;

            //    SmtpClient smtp = new SmtpClient();

            //    smtp.Credentials = new NetworkCredential(currentUser, mailParolası);

            //    //Google dan mail smtp açıklamalarına bakınız
            //    smtp.Port = 465;
            //    smtp.Host = "smtp@gmail.com";
            //    smtp.EnableSsl = true;

            //    mail.IsBodyHtml = true;

            //    try
            //    {
            //        smtp.Send(mail);
            //    }
            //    catch (SmtpException ex)
            //    {

            //        ViewBag.MessageError = "EMail could not be sent";

            //    }
            //}
            #endregion


            return RedirectToAction("Index");
        }
        public ActionResult Status(int ID)
        {
            return Json(Manager.ContactManager.Status(ID));
        }
    }
}