using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrdesController
    {
        public static string SQL;

        public static List<Ordes> Listado()
        {
            List<Ordes> cl = null;
            Ordes ob;
            SQL = "SELECT * FROM orders";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            cl = new List<Ordes>();
            while (rg.Read())
            {
                ob = new Ordes();
                ob.OrderNumber = rg.GetInt32("orderNumber");//campo en DB
                ob.OrderDate = rg.GetDateTime("orderDate");
                ob.RequiredDate = rg.GetDateTime("requiredDate");
                ob.Status = rg.GetString("status");
                ob.CustomerNumber = rg.GetInt32("customerNumber");
                cl.Add(ob);
            }
            rg.Close();
            return cl;
        }//end Listado

        public static Ordes Buscar(int Number)
        {
            Ordes ob = null;
            SQL = $"SELECT * FROM `orders` WHERE orderNumber={Number}";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            if (rg.Read())
            {
                ob = new Ordes();
                ob.OrderNumber = rg.GetInt32("orderNumber");//campo en DB
                ob.OrderDate = rg.GetDateTime("orderDate");
                ob.RequiredDate = rg.GetDateTime("requiredDate");
                ob.Status = rg.GetString("status");
                ob.CustomerNumber = rg.GetInt32("customerNumber");
            }
            rg.Close();
            return ob;
        }//end Buscar

    }
}