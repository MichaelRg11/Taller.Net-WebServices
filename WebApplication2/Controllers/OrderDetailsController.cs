using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderDetailsController
    {
        public static string SQL;

       
        public static List<OrderDetails> Buscar(int Number)
        {
            List<OrderDetails> cl = null;
            OrderDetails ob;
            SQL = $"SELECT * FROM `orderdetails` WHERE orderNumber={Number}";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            cl = new List<OrderDetails>();
            while (rg.Read())
            {
                ob = new OrderDetails();
                ob.OrderNumber = rg.GetInt32("orderNumber");//campo en DB
                ob.ProductCode = rg.GetString("productCode");
                ob.QuantityOrdered = rg.GetInt32("quantityOrdered");
                ob.PriceEach = rg.GetDouble("PriceEach");
                ob.OrderLineNumber = rg.GetString("orderLineNumber");
                cl.Add(ob);
            }
            rg.Close();
            return cl;
        }//end Buscar

        public static List<Products> BuscarProducto(int number)
        {
            List<Products> pr = null;
            Products ob;
            SQL = "SELECT products.productName,products.productCode,products.quantityInStock,products.buyPrice FROM products " +
                  "INNER join orderdetails ON products.productCode=orderdetails.productCode " +
                  "INNER JOIN orders ON orderdetails.orderNumber=orders.orderNumber WHERE orders.orderNumber=" + number;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            pr = new List<Products>();
            while (rg.Read())
            {
                ob = new Products();
                ob.ProductName = rg.GetString("productName");
                ob.ProductCode = rg.GetString("productCode");
                ob.Quantity = rg.GetInt32("quantityInStock");
                ob.Price = rg.GetDouble("buyPrice");
                pr.Add(ob);
            }
            rg.Close();
            return pr;
        }
    }
}