using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

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

    }
}
