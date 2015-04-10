using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWinkelGroep5.Models;
using System.Net.Mail;

namespace WebWinkelGroep5.Controllers
{
    public class BestellingController : Controller
    {
        BestellingModel bestelling;
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View();
        }

         public ActionResult BestellingenOverzicht()
        {
            List<BestellingStatus> bestelling = DatabaseController.GetBestellingen();
            return View();
        }
        
        public ActionResult WijzigBestellingStatus(int bestellingId)
        {
            try
            {
                BestellingStatus bestelling = DatabaseController.GetBestelling(bestellingId);
                return View();
            }
            catch (Exception e)
            {
                ViewBag.FoutMelding("Er is iets fout gegaan: " + e);
                return View();
            }
        }

        [HttpPost]
        public ActionResult WijzigBestellingStatus(BestellingStatus bestelling)
        {
            try
            {
                DatabaseController.WijzigBestelling(bestelling);
                return RedirectToAction("BestellingenOverzicht", "Product");
            }
            catch (Exception e)
            {
                ViewBag.FoutMelding("Er is iets fout gegaan: " + e);
                return View();
            }
        }

    

        [HttpPost]
        private void SendMail(WebWinkelGroep5.Models.MailModel _objModelMail)
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
                mail.To.Add(_objModelMail.To);
                //mail.From = new MailAddress("wooods-info@compuboot.in");
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = mail.From + "<br><br>" + Body;
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);
        }


        public ActionResult MaakBestelling()
        {
            bestelling = new BestellingModel();
            bestelling.userId = DatabaseController.getUserId((String)Session["Username"]);
            bestelling.fromWinkelmandModel((WinkelmandModel)Session["Winkelmand"]);
            int bestellingId = DatabaseController.getNextBestellingId();
            bestelling.bestellingId = bestellingId;
            Session["BestellingId"] = bestellingId;
            foreach(WinkelmandItemModel m in bestelling.items)
            {
                DatabaseController.addBestellingLine(bestellingId, m.productId, m.amount, bestelling.userId);
            }
            return View(bestelling);
        }

        public ActionResult setGegevens(String bedrijfsnaam, String voornaam, String naam, String adres, String postcode, String land, String stad, String tel)
        {
            bestelling = new BestellingModel();
            DatabaseController.setUserDetails(voornaam + " " + naam, adres, stad, postcode, tel, (String)Session["Username"]);

            bestelling.items = DatabaseController.getBestelling((int)Session["BestellingId"]);

            return View(bestelling);
        }


    }
}
