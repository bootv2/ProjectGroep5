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

        public ActionResult Winkelwagen()
        {
            try
            {
                Bestelling bestelling = new Bestelling();
                /*List<Bestelling> bestellingen = DatabaseController.GetWinkelwagen(userId);
                bestelling.lijst = bestellingen;*/
                return View(bestelling);
            }
            catch (Exception e)
            {
                ViewBag.Message = "Er is een fout opgetreden" + e;
                return View();
            }

        }

    }
}
