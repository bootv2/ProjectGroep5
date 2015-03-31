using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using WebWinkelGroep5.Models;

namespace WebWinkelGroep5.Controllers
{
    public class WinkelmandController : Controller
    {

        public static Dictionary<int, String> productDictionary;

        //
        // GET: /Winkelmand/

        public ActionResult Index()
        {
            //ArrayList mandList = (ArrayList) Session["Winkelmand"];
            ViewBag.Message = "test";
            return View();
        }

        public ActionResult WinkelmandLeeg()
        {
            ViewBag.Message = "De winkelwagen is op het moment leeg! Klik de + bij een product om dit product aan de winkelwagen toe te voegen!";
            return View();
        }

        public ActionResult Winkelmand()
        {
            ViewBag.Message = "De volgende producten zitten in de winkelmand";
            return View();
        }

        public ActionResult AddToWinkelmand(int productId, int amount)
        {
            WinkelmandItemModel item = new WinkelmandItemModel();
            item.amount = amount;
            item.productId = productId;
            bool addItem = false;
            if(Session["Winkelmand"] == null)
            {
                Session["Winkelmand"] = new WinkelmandModel();
            }
            WinkelmandModel mand = (WinkelmandModel)Session["Winkelmand"];
            if (mand.items.Count > 0)
            {
                foreach (WinkelmandItemModel mandItem in mand.items)
                {
                    if (mandItem.productId == item.productId)
                    {
                        mandItem.amount += item.amount;
                    }
                    else addItem = true;
                }
            }
            else addItem = true;
            if(addItem) mand.items.Add(item);
            Session["Winkelmand"] = mand;
            ViewBag.Message = DatabaseController.getProductName(item.productId) + " is toegevoegd aan uw winkelmand!";
            return View();
        }

        public ActionResult ViewMand()
        {
            String message = "";
            

            if(Session["Winkelmand"] == null)
            {
                message = "Je winkelmand is nog leeg!";
            }
            else
            {
                WinkelmandModel model = (WinkelmandModel)Session["Winkelmand"];
                List<WinkelmandItemModel> items = model.items;
                foreach(WinkelmandItemModel item in items)
                {
                    message += item.amount + "x " + DatabaseController.getProductName(item.productId) + " a " + DatabaseController.getProductPrice(item.productId) * item.amount + "<br>";
                }
                message += "<br><br><a href='../Bestelling/MaakBestelling'>Plaats Bestelling</a>";
            }
            

            ViewBag.Message = message;
            return View();
        }

        public ActionResult Winkelwagen()
        {
            try
            {
                BestellingModel bestelling = new BestellingModel();
                /*List<Bestelling> bestellingen = DatabaseController.GetWinkelwagen(userId);
                bestelling.lijst = bestellingen;*/
                return View(bestelling);
            }
            catch (Exception e)
            {
                ViewBag.Message = "Er is een fout opgetreden: " + e;
                return View();
            }

        }

    }
}
