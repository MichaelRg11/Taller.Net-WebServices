using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustumersController
    {
        public static string SQL;

        public static List<Custumers> Listado()
        {
            List<Custumers> cl = null;
            Custumers ob;
            SQL = "SELECT * from customers";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            cl = new List<Custumers>();
            while (rg.Read())
            {
                ob = new Custumers();
                ob.Number = rg.GetInt32("customerNumber");//campo en DB
                ob.Name = rg.GetString("customerName");
                ob.ConstactFirstName = rg.GetString("contactFirstName");
                ob.ContactLastName = rg.GetString("contactLastName");
                ob.Phone = rg.GetString("phone");
                ob.AddressLine1 = rg.GetString("addressLine1");
                ob.City = rg.GetString("city");
                ob.Country = rg.GetString("country");
                ob.CreditLimit = rg.GetDouble("creditLimit");
               cl.Add(ob);
            }
            rg.Close();
            return cl;
        }//end Listado

 
        public static Custumers Buscar(int Number)
        {
            Custumers ob=null;
            SQL = $"SELECT * FROM customers WHERE customerNumber = { Number}";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            if (rg.Read())
            {
                ob = new Custumers();
                ob.Number = rg.GetInt32("customerNumber");//campo en DB
                ob.Name = rg.GetString("customerName");
                String date = rg.GetString("addressLine2");
                String adress = (date != "") ? " " + rg.GetString("addressLine2") : "";
                ob.AddressLine1 = rg.GetString("addressLine1") + " - " + adress;                        
                ob.Phone = rg.GetString("phone");
                ob.SalesRepEmployeeNumber = rg.GetInt32("salesRepEmployeeNumber");            
            }
            rg.Close();
            return ob;
        }//end Buscar

        public static Employees BuscarEmployees(int number)
        {
            Employees ob = null;
            SQL = $"Select * from employees where employeeNumber={number}";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Console.WriteLine(SQL);
            if (rg.Read())
            {
                ob = new Employees();
                ob.EmployeeNumber = rg.GetInt32("employeeNumber");
                ob.LastName = rg.GetString("lastName") + " " + rg.GetString("firstName");
            }
            rg.Close();
            return ob;
        }//end buscar empleado-Cliente

    }
}
