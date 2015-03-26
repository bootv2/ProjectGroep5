using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace WebWinkelGroep5.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult NewProduct()
        {
            
            return View();
        }

        public ActionResult changeProduct()
        {
            return View();
        }

        public ActionResult changeImage()
        {
            String newFileName = "";

            WebImage photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);

                photo.Save(@"~/Images/" + newFileName);
                ViewBag.Image = newFileName;

                DatabaseController.changeProduct((int)Session["productId"], "", -1, "", "~/Images/" + newFileName);
            }
            return View();
        }

        public ActionResult changeName(String name)
        {
            DatabaseController.changeProduct((int)Session["productId"], name, -1, "", "");
            return View();
        }

        public ActionResult changeDetails(String details)
        {
            DatabaseController.changeProduct((int)Session["productId"], "", -1, details, "");
            return View();
        }

        public ActionResult changePrice(int price)
        {
            DatabaseController.changeProduct((int)Session["productId"], "", price, "", "");
            return View();
        }

        [HttpPost]
        public ActionResult Upload(String name, int price, String details)
        {
            String newFileName = "";
            
            WebImage photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);

                photo.Save(@"~/Images/" + newFileName);
                ViewBag.Image = newFileName;

                DatabaseController.addProduct(name, price, details, "~/Images/" + newFileName);
            }

            

            return View();
        }


    }
}
