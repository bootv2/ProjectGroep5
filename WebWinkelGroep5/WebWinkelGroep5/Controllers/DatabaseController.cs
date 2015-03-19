using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using WebWinkelGroep5.Filters;
using WebWinkelGroep5.Models;
using MySql.Data.MySqlClient;

namespace WebWinkelGroep5.Controllers
{
    public abstract class DatabaseController : Controller
    {
        protected MySqlConnection conn;

        public DatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("Server=127.0.0.1:3307;Database=webwinkel;Uid=bootv2;Pwd=33662648;");
        }
    }
}
