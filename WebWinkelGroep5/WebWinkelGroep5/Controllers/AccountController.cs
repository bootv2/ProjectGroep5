using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebWinkelGroep5.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginPage(String thisurl)
        {
            ViewBag.url = thisurl;
            return View();
        }
        //
        // GET: /Account/

        public ActionResult Login(String username, String password)
        {
            if(DatabaseController.login(username, password))
                {
                    ViewBag.message = username + " Logged In!";

                    Session["Username"] = username;
                    Session["isAdmin"] = DatabaseController.isAdmin(username);
                }

            else
                { 
                    ViewBag.message = "Username or password wrong!";
                }
            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        public ActionResult Register(String username, String password, String email)
        {
            if (DatabaseController.register(username, password, email))
            {
                ViewBag.Head = "Success!";
                ViewBag.message = username + " successfully registered";
            }
            else
            {
                ViewBag.Head = "Error!";
                ViewBag.message = "Username or email already in use.";
            }
            return View();
        }

        public ActionResult Logoff()
        {
            Session["Username"] = null;
            Session["isAdmin"] = null;
            return View();
        }

    }
}
