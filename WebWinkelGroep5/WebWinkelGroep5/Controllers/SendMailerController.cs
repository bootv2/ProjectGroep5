using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebWinkelGroep5.Controllers
{
    public class SendMailerController : Controller
    {
        //
        // GET: /SendMail/

        public ActionResult mailtest()
        {
            return View();
        }
        [HttpPost]
        public ViewResult mailtest(WebWinkelGroep5.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                //SmtpClient smtpClient = new SmtpClient("smtp.googlemail.com", 465);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.googlemail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("wooods-info@compuboot.in", "Wooods123");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("wooods-info@compuboot.in", "Wooods BV.");
                mail.To.Add(_objModelMail.To);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;


                /*smtpClient.Send(mail);
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                //mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("wooods@compuboot.in", "Wooods1234");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("mailtest   ", _objModelMail);
                ("wooods@gmail.com", "Wooods1234");// Enter seders User name and password
                smtp.EnableSsl = true;*/
                smtpClient.Send(mail);
                return View("mailtest", _objModelMail);

            }
            else
            {
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }
        [HttpPost]
        public ViewResult Contact(WebWinkelGroep5.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.googlemail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("wooods-info@compuboot.in", "Wooods123");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress(_objModelMail.From);
                mail.To.Add("wooods-info@compuboot.in");
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = mail.From + "<br><br>" + Body;
                mail.IsBodyHtml = true;

                smtpClient.Send(mail);
                return View("Contact", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}