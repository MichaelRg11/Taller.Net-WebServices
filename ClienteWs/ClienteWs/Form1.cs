using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            localhost.WSCustumers ws = new localhost.WSCustumers();
            if (txtOrden != null)
            {
                int orden = Convert.ToInt32(txtOrden.Text);
                var ob = ws.BuscarOrden(orden);
                txtOrderDate.Text = Convert.ToString(ob.OrderDate);                             
                txtidC.Text = Convert.ToString(ob.CustomerNumber);
                var cob = ws.BuscarCustumers(Convert.ToInt32(txtidC.Text));
                if (cob != null)
                {
                    txtidEmp.Text = Convert.ToString(cob.SalesRepEmployeeNumber);                   
                    txtName.Text = Convert.ToString(cob.Name);
                    txtPhone.Text = cob.Phone;
                    txtAdress.Text = cob.AddressLine1;
                    var emp =  ws.BuscarEmployees(Convert.ToInt32(txtidEmp.Text));
                    txtEmployee.Text = emp.LastName;
                    var pr = ws.BuscarProducto(orden);
                    dtgProducts.DataSource = null;
                    dtgProducts.DataSource = pr;
                    double total = 0;
                    foreach(var i in pr)
                    {
                        total = total + (i.Quantity * i.Price);
                    }
                    txtTotal.Text = "$ " + total;
                    dtgProducts.Columns[2].Visible = false;
                    dtgProducts.Columns[3].Visible = false;
                    dtgProducts.Columns[4].Visible = false;
                    dtgProducts.Columns[5].Visible = false;
                    dtgProducts.Columns[8].Visible = false;
                }
                else
                {
                    MessageBox.Show("Vacio");
                }

            }
            else
            {
                MessageBox.Show("Digite orden");
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
