using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using WebWinkelGroep5.Models;

namespace WebWinkelGroep5.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            String message = "";
            List<ProductModel> productList = DatabaseController.getProductList();
            foreach (ProductModel model in productList)
            {
                message += "<th><a href=\"../Product/details?productId=" + model.productId + "\"><img src=\"" + model.imageURL;

                message += "\" title=\"" + model.name + "\" alt=\"Sorry voor de ongemak\" style=\"width:304px;height:228px\"></th>";

            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Details(int productId)
        {
            ViewBag.Message = "<img src=\"" + DatabaseController.getProductImageURL(productId) + "\" alt=\"Sorry voor het ongemak!\" style=\"width:304px;height:228px\"><br />";
            ViewBag.AddToCartURL = "<a href='../Winkelmand/AddToWinkelmand?productId=" + productId + "&amount=1' >Stop in winkelmand</a>";
            ViewBag.Details = DatabaseController.getProductDetails(productId);
            ViewBag.EditUrl = "../product/changeproduct?productId=" + productId;
            return View();
        }

        public ActionResult NewProduct()
        {
            
            return View();
        }

        public ActionResult changeProduct(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        public ActionResult changeImage(int productId)
        {
            String newFileName = "";

            WebImage photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);

                photo.Save(@"~/Images/" + newFileName);
                ViewBag.Image = newFileName;

                DatabaseController.changeProduct(productId, "", -1, "", "/Images/" + newFileName);
            }
            return View();
        }

        public ActionResult changeName(String name, int productId)
        {
            DatabaseController.changeProduct(productId, name, -1, "", "");
            return View();
        }

        public ActionResult changeDetails(String details, int productId)
        {
            DatabaseController.changeProduct(productId, "", -1, details, "");
            return View();
        }

        public ActionResult changePrice(int price, int productId)
        {
            DatabaseController.changeProduct(productId, "", price, "", "");
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
                    "img.png";

                photo.Save(@"~/Images/" + newFileName);
                ViewBag.Image = newFileName;

                DatabaseController.addProduct(name, price, details, "/Images/" + newFileName);
            }

            

            return View();
        }


    }
}
