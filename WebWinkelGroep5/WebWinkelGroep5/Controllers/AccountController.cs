﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebWinkelGroep5.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginPage()
        {

            return View();
        }
        //
        // GET: /Account/

        public ActionResult Login(String username, String password)
        {
            if(DatabaseController.login(username, password))
                ViewBag.message = username + " Logged In!";
            else ViewBag.message = "Username or password wrong!";

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
            return View();
        }

    }
}
