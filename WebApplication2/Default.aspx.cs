using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        private WSCustumers ws = new WSCustumers();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void cargar(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = Convert.ToInt32(txtId.Text);
                var ob = ws.BuscarOrden(id);
                txtDate.Text = Convert.ToString(ob.OrderDate);
                int idCustomer = ob.CustomerNumber;
                var ct = ws.BuscarCustumers(idCustomer);
                txtName.Text = ct.Name;
                txtAdress.Text = ct.AddressLine1;
                txtPhone.Text = ct.Phone;
                int idEmployee = ct.SalesRepEmployeeNumber;
                var obEmp = ws.BuscarEmployees(idEmployee);
                txtEmploye.Text = obEmp.LastName;
                var obProduct = ws.BuscarProducto(id);
                gvDetalle.DataSource = null;
                gvDetalle.DataSource = obProduct;
                double Total = 0;
                foreach (var i in obProduct)
                {
                    Total = Total + i.Quantity * i.Price;
                }
                gvDetalle.DataBind();
                txtTotal.Text = "$ " + Total;
            }
        }
    }
}