using System.Collections.Generic;
using System.Web.Services;
using WebApplication2.Controllers;
using WebApplication2.Models;

namespace WebApplication2
{
    /// <summary>
    /// Descripción breve de WSCustumers
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSCustumers : System.Web.Services.WebService
    {
        public WSCustumers() {
            Mysqlcon.Open();
        }   
        
        [WebMethod]
        public Custumers BuscarCustumers(int NumberOrder)
        {
            Custumers ob;
            ob = CustumersController.Buscar(NumberOrder);
            return ob;
        }

        [WebMethod]
        public Ordes BuscarOrden(int NumberOrder)
        {
            Ordes ob;
            ob = OrdesController.Buscar(NumberOrder);
            return ob;
        }
        
        
        [WebMethod]
        public Employees BuscarEmployees(int OrderNumber)
        {
            Employees ob;
            ob = CustumersController.BuscarEmployees(OrderNumber);
            return ob;
        }

        [WebMethod]
        public List<Products> BuscarProducto(int OrderNumber)
        {
            List<Products> ob = null;
            ob = OrderDetailsController.BuscarProducto(OrderNumber);
            return ob;
        }


    }
}
