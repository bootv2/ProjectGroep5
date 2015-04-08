

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
using WebWinkelGroep5.Models;

namespace WebWinkelGroep5.Controllers
{
    public static class DatabaseController
    {
        //TODO: get array of all products

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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw (ex);
            }
        }

        public static List<ProductModel> findProducts(String searchString)
        {
            List<ProductModel> result = new List<ProductModel>();
            List<ProductModel> allNames = new List<ProductModel>();
            String query = "SELECT * FROM products";

            String name;
            String details;
            String imageURL;
            int price;
            ProductModel filler = new ProductModel();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = null;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                //throw new Exception();
            }
            while (dataReader.Read())
            {
                filler = new ProductModel();
                name = dataReader.GetString("name");
                details = dataReader.GetString("details");
                imageURL = dataReader.GetString("imageURL");
                price = dataReader.GetInt32("price");

                filler.productId = dataReader.GetInt32("productId");
                filler.name = name;
                filler.details = details;
                filler.imageURL = imageURL;
                filler.price = price;

                allNames.Add(filler);
            }
            dataReader.Close();

            //check if the searchString is present anywhere

            foreach(ProductModel p in allNames)
            {
                if (p.name.Contains(searchString))
                    result.Add(p);
            }

            return result;
        }

        public static List<WinkelmandItemModel> getBestelling(int bestellingId)
        {
            List<WinkelmandItemModel> result = new List<WinkelmandItemModel>();
            WinkelmandItemModel dummy;
            String query = "SELECT * FROM bestelling WHERE bestellingId=" + bestellingId;
            int productId = -1;
            int amount = -1;

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }
            while (dataReader.Read())
            {
                dummy = new WinkelmandItemModel();
                productId = dataReader.GetInt32("productId");
                amount = dataReader.GetInt32("amount");
                dummy.amount = amount;
                dummy.productId = productId;
                result.Add(dummy);
            }
            dataReader.Close();

            return result;
        }

        public static List<ProductModel> getProductList()
        {
            List<ProductModel> result = new List<ProductModel>();
            String query = "SELECT * FROM products";
            String name;
            String details;
            String imageURL;
            int price;
            ProductModel filler = new ProductModel();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }
            while (dataReader.Read())
            {
                filler = new ProductModel();
                name = dataReader.GetString("name");
                details = dataReader.GetString("details");
                imageURL = dataReader.GetString("imageURL");
                price = dataReader.GetInt32("price");

                filler.productId = dataReader.GetInt32("productId");
                filler.name = name;
                filler.details = details;
                filler.imageURL = imageURL;
                filler.price = price;

                result.Add(filler);
            }
            dataReader.Close();

            return result;
        }

        public static bool login(String username, String password)
        {
            String pw;
            String query = "SELECT password FROM users WHERE username='" + username + "';";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                pw = dataReader.GetString("password");
                dataReader.Close();
            }
            else
            {
                dataReader.Close();
                return false;
            }

            if (pw.CompareTo(password) == 0)
                return true;
            else
                return false;
        }

        public static void addBestellingLine(int bestellingId, int productId, int amount, int userId)
        {
            String query = "INSERT INTO bestelling(bestellingId, productId, amount, userId) VALUES(" + bestellingId + ", " + productId + ", " + amount + ", " + userId + ");";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public static int getUserId(String username)
        {
            int result = -1;
            String query = "SELECT userId FROM users WHERE username='" + username + "'";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                result = dataReader.GetInt32("userId");
                dataReader.Close();
            }
            else dataReader.Close();

            return result;
        }

        public static int getNextBestellingId()
        {
            int result = -1;
            String query = "SELECT MAX(bestellingId) AS biggestid FROM bestelling";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                try
                {
                    result = dataReader.GetInt32("biggestid");

                }
                catch (System.Data.SqlTypes.SqlNullValueException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                dataReader.Close();
                result++;
            }

            return result;
        }

        public static int getHighestBestellingId()
        {
            int result = -1;
            String query = "SELECT MAX(bestellingId) AS biggestid FROM bestelling";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                try
                {
                    result = dataReader.GetInt32("biggestid");

                }
                catch (System.Data.SqlTypes.SqlNullValueException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                dataReader.Close();
            }

            return result;
        }

        public static void setUserDetails(String fullname, String address, String city, String zip, String tel, String username)
        {
            String query = "UPDATE users SET address='" + address + "', city='" + city + "', zip='" + zip + "', phoneNumber='" + tel + "', fullname='" + fullname + "' WHERE username='" + username + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        public static bool isAdmin(String username)
        {
            int status;
            String query = "SELECT adminStatus FROM users WHERE username='" + username + "';";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                status = dataReader.GetInt32("adminStatus");
                dataReader.Close();
            }
            else
            {
                dataReader.Close();
                return false;
            }

            if (status > 0)
                return true;
            else
                return false;
        }

        public static void editAdminStatus(int status, String username)
        {
            String query = "UPDATE users SET adminStatus=" + status + " WHERE username='" + username + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        public static bool register(String username, String password, String email)
        {
            String query = "INSERT INTO users(username, password, email) VALUES('" + username + "', '" + password + "', '" + email + "');";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public static void addProduct(String name, int price, String details, String imageURL)
        {
            String query = "INSERT INTO products(name, price, details, imageURL) VALUES('" + name + "', " + price + ", '" + details + "', '" + imageURL + "');";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //resetAutoIncrement();
        }

        private static void resetAutoIncrement()
        {//deprecated
            int count = countProducts();//bad practice, delete this
            String query = "ALTER TABLE Persons AUTO_INCREMENT=" + count;
        }

        public static String getProductName(int productId)
        {//deprecated and buggy
            String name = "";
            String query = "SELECT name FROM products WHERE productId=" + productId + ";";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                name = dataReader.GetString("name");
                dataReader.Close();
            }
            else dataReader.Close();

            return name;
        }

        public static String getProductDetails(int productId)
        {//deprecated and buggy
            String details = "";
            String query = "SELECT details FROM products WHERE productId=" + productId + ";";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                details = dataReader.GetString("details");
                dataReader.Close();
            }
            else dataReader.Close();

            return details;
        }

        public static String getProductImageURL(int productId)
        {//deprecated and buggy
            String Image = "";
            String query = "SELECT imageURL FROM products WHERE productId=" + productId + ";";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                Image = dataReader.GetString("imageURL");
                dataReader.Close();
            }
            else dataReader.Close();

            return Image;
        }

        public static int getProductPrice(int productId)
        {//deprecated and buggy
            int price = -1;
            String query = "SELECT price FROM products WHERE productId=" + productId + ";";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                price = dataReader.GetInt32("price");
                dataReader.Close();
            }
            else dataReader.Close();

            return price;
        }

        public static int countProducts()
        {//deprecated and buggy
            String query = "SELECT COUNT(*) FROM products;";
            int count = -1;

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader;

            try
            {
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw new Exception();
            }

            if (dataReader.Read())
            {
                count = dataReader.GetInt32("COUNT(*)");
                dataReader.Close();
            }
            else dataReader.Close();

            return count;
        }

        public static void changeProduct(int productId, String name, int price, String details, String imageURL)
        {
            String query = "UPDATE products SET ";
            if (name.CompareTo("") == 0 && price == -1 && details.CompareTo("") == 0)//change image
            {
                query += "imageURL='" + imageURL + "' WHERE productId=" + productId;
            }
            else if (name.CompareTo("") == 0 && price == -1 && imageURL.CompareTo("") == 0)//change details
            {
                query += "details='" + details + "' WHERE productId=" + productId;
            }
            else if (name.CompareTo("") == 0 && imageURL.CompareTo("") == 0 && details.CompareTo("") == 0)//change price
            {
                query += "price=" + price + " WHERE productId=" + productId;
            }
            else if (imageURL.CompareTo("") == 0 && price == -1 && details.CompareTo("") == 0)//change name
            {
                query += "name='" + name + "' WHERE productId=" + productId;
            }
            else
                System.Diagnostics.Debug.WriteLine("DO NOT PASS MULTIPLE FILLED VARIABLES! you can only change one at a time!");


            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

    }
}

