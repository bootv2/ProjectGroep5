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
            AccountModel model = new AccountModel();
            model.lastUrl = redirect;
            if(DatabaseController.login(username, password))
                {
                    model.loginMessage = username + " Logged In!";

                    Session["Username"] = username;
                    Session["isAdmin"] = DatabaseController.isAdmin(username);
                }

            else
                {
                    model.loginMessage = "Username or password wrong!";
                }
            
            return View(model);
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        public ActionResult Register(String username, String password, String email)
        {
            AccountModel model = new AccountModel();
            if (DatabaseController.register(username, password, email))
            {
                model.loginMessage = username + " successfully registered";
            }
            else
            {
                model.loginMessage = "Username or email already in use.";
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
