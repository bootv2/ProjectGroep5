using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public enum MaandenInJaar { januari = 1, februari = 2, maart = 3, april = 4, mei = 5, juni = 6, juli = 7, augustus = 8, september = 9, october = 10, november = 11, december = 12 };

        public ActionResult Index()
        {
            return View();
        }

        public String benoemMaand(int dag, MaandenInJaar maand, int jaar)
        {
			bool kwartaal2 = false;
			if ((maand == MaandenInJaar.april) ||
			    (maand == MaandenInJaar.mei) ||
				(maand == MaandenInJaar.juni)) {
			}
			DateTime datum = new DateTime(jaar, (int)maand, dag);

            return datum.ToString();
        }

		
    }
}
