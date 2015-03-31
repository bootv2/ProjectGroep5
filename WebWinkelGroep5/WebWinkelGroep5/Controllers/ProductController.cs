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
            List<ProductModel> productList = DatabaseController.getProductList();
            ProductListModel model = new ProductListModel();
            model.productList = productList;
            return View(model);
        }

        public ActionResult Details(int productId)
        {
            ProductModel model = new ProductModel();
            model.productId = productId;
            model.imageURL = DatabaseController.getProductImageURL(productId);
            model.details = DatabaseController.getProductDetails(productId);
            model.name = DatabaseController.getProductName(productId);
            return View(model);
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
            ProductModel model = new ProductModel();
            model.productId = productId;
            WebImage photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);

                photo.Save(@"~/Images/" + newFileName);
                ViewBag.Image = newFileName;

                DatabaseController.changeProduct(productId, "", -1, "", "/Images/" + newFileName);
            }
            return View(model);
        }

        public ActionResult changeName(String name, int productId)
        {
            ProductModel model = new ProductModel();
            model.productId = productId;
            DatabaseController.changeProduct(productId, name, -1, "", "");
            return View(model);
        }

        public ActionResult changeDetails(String details, int productId)
        {
            ProductModel model = new ProductModel();
            model.productId = productId;
            DatabaseController.changeProduct(productId, "", -1, details, "");
            return View(model);
        }

        public ActionResult changePrice(int price, int productId)
        {
            ProductModel model = new ProductModel();
            model.productId = productId;
            DatabaseController.changeProduct(productId, "", price, "", "");
            return View(model);
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
