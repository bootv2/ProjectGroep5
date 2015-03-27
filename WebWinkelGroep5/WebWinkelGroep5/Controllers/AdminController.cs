using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebWinkelGroep5.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageUser()
        {
            return View();
        }

        public ActionResult ChangeUserStatus(int status, String name)
        {
            DatabaseController.editAdminStatus(status, name);
            return View();
        }

    }
}
