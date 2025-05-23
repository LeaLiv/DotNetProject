using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ManagerMenu : Form
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            CustomersMenu formCustomers = new CustomersMenu();
            formCustomers.Show();
        }

        private void products_Click(object sender, EventArgs e)
        {
            ProductsMenu formProducts = new ProductsMenu();
            formProducts.Show();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            SalesMenu formSales = new SalesMenu();
            formSales.Show();
        }
    }
}
