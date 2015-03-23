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
using MySql.Data.MySqlClient;

namespace WebWinkelGroep5.Controllers
{
    public static class DatabaseController
    {

        private static MySqlConnection conn;

        public static void initDatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("server=127.0.0.1; database=webwinkel; user id=root; password=33662648; pooling = false;");
            
                try
                {
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    throw (ex);
                }
        }

        public static bool login(String username, String password)
        {
            //conn.
            return true;
        }

    }
}
