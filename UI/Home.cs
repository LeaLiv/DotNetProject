namespace UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void manager_Click(object sender, EventArgs e)
        {
            ManagerMenu formManager = new ManagerMenu();
            formManager.Show();
        }

        private void seller_Click(object sender, EventArgs e)
        {
            OrderToCustomer orderToCustomer = new OrderToCustomer();
            orderToCustomer.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
