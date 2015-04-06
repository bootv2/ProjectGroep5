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

            return View();
        }

        public ActionResult Werknemers()
        {
            return View();
        }

        public ActionResult About()
        {

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
