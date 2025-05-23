using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class OrderToCustomer : Form
    {
        private static IBl _bl = BlApi.Factory.Get();

        public OrderToCustomer()
        {
            InitializeComponent();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.CustomerId = int.Parse(inputId.Text); // העברת תעודת הזהות
            orderForm.Show();
            this.Close();
        }
    }
}
