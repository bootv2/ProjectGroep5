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


        protected void Upload(object sender, EventArgs e)
        {
            /*if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);
            }*/
        }

        public ActionResult ImageUpload()
        {
            
            return View();
        }


    }
}
