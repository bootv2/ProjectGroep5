using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace WebWinkelGroep5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "De beste keuze voor natuurlijke producten!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Over ons";

            return View();
        }

        public ActionResult TOS()
        {
            return View();
        }

        public ActionResult Disclaimer()
        {
            return View();
        }
    }
}
