using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWinkelGroep5.Models;

namespace WebWinkelGroep5.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginPage(String thisurl)
        {
            AccountModel model = new AccountModel();
            model.lastUrl = thisurl;
            return View(model);
        }
        //
        // GET: /Account/

        public ActionResult Login(String username, String password, String redirect)
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
            AccountModel model = new AccountModel();
            model.lastUrl = redirect;
            return View(model);
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
