using MySql.Data.MySqlClient;
using System;
namespace WebApplication2.Controllers
{
    public class Mysqlcon
    {
        public static MySqlConnection conn;
        public static String host;
        public static String database;
        public static String user;
        public static String passwd;

        public static void Open()
        {
            host = "127.0.0.1";
            database = "classicmodels";
            user = "root";
            passwd = "";
            conn = new MySqlConnection("server=" + host + "; database=" + database + ";Uid=" + user + "; pwd=" + passwd + ";SslMode=none");
            conn.Open();
            Console.WriteLine("Conectado a MySQL...");
        }//end
        //----- Insert, Update, Delete-----------------
        public static Boolean Execute(String SQL)
        {
            Boolean estado = true;
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta " + e.Message);
                estado = false;
            }
            return estado;
        }
        //----- Select-------------------- 
        public static MySqlDataReader Query(String sql)
        {
            MySqlDataReader query=null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                query = cmd.ExecuteReader();
            }
             
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta "+ex.Message);
            }
            return query;
        }

    }
}
