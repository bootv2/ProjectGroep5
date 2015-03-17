using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WorkshopCSharp_II_Start.DatabaseControllers
{
    public abstract class DatabaseController
    {
        protected MySqlConnection conn;

        public DatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("Server=timanity.com:3307;Database=webwinkel;Uid=bootv2;Pwd=33662648;");
        }
    }
}
