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
            String pw;
            String query = "SELECT password FROM users WHERE userId='" + username + "';";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if(dataReader.Read())
                pw = dataReader.GetString("password");
            else return false;

            if (pw.CompareTo(password) == 0)
                return true;
            else
                return false;
        }

        public static void register(String username, String password, String email)
        {
            String query = "INSERT INTO users(username, password, email) VALUES('" + username +"', '" + password +"', '" + email +"');";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.ExecuteNonQuery();
        }

    }
}
