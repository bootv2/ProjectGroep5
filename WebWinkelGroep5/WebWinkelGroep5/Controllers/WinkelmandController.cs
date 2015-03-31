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
            WinkelmandModel model = null;

            if (Session["Winkelmand"] != null)
            {
                model = (WinkelmandModel)Session["Winkelmand"];
            }
            return View(model);
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
            WinkelmandModel model = null;

            if(Session["Winkelmand"] != null)
            {
                model = (WinkelmandModel)Session["Winkelmand"];
            }
            return View(model);
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
