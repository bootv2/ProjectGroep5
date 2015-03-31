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
            bestelling.fromWinkelmandModel((WinkelmandModel)Session["Winkelmand"]);


            return View();
        }

    }
}
