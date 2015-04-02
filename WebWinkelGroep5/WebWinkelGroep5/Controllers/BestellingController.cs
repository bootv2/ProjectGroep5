using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWinkelGroep5.Models;

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

        public ActionResult MaakBestelling()
        {
            bestelling = new BestellingModel();
            bestelling.userId = DatabaseController.getUserId((String)Session["Username"]);
            bestelling.fromWinkelmandModel((WinkelmandModel)Session["Winkelmand"]);
            int bestellingId = DatabaseController.getNextBestellingId();
            foreach(WinkelmandItemModel m in bestelling.items)
            {
                DatabaseController.addBestellingLine(bestellingId, m.productId, m.amount, bestelling.userId);
            }

            return View(bestelling);
        }

        public ActionResult setGegevens(String bedrijfsnaam, String voornaam, String naam, String adres, String postcode, String land, String stad, String tel)
        {

            DatabaseController.setUserDetails(voornaam + " " + naam, adres, stad, postcode, tel, (String)Session["Username"]);

            
            return View();
        }


    }
}
