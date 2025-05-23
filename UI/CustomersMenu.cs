using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;


namespace UI
{
    public partial class CustomersMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();

        public CustomersMenu()
        {
            InitializeComponent();
            this.Load += CustomersMenu_Load;
        }

        private void CustomersMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshCustomerList()
        {
            try
            {
                List<Customer?> customers = _bl.Customer.ReadAll();
                customersList.Items.Clear();

                foreach (var customer in customers)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            customersList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void detailsCustomer_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer c = new Customer(
                    int.Parse(CustomerIdInput.Text),
                    CustomerNameInput.Text,
                    CustomerAddressInput.Text,
                    CustomerTelInput.Text);

            _bl.Customer.Create(c);

            RefreshCustomerList();
            MessageBox.Show("הלקוח נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // איפוס הטופס
            CustomerNameInput.Text = "";
            CustomerIdInput.Text = "";
            CustomerAddressInput.Text = "";
            CustomerTelInput.Text = "";
        }

        private void searchBtnCustomerUpdate_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(codeCustomerInput.Text);
            try
            {
                Customer c = _bl.Customer.Read(customerId);
                nameCustomerUpdate.Text = c.Name;
                idCustomerUpdate.Text = Convert.ToString(c.Id);
                addressCustomerUpdate.Text = c.Address;
                phoneCustomerUpdate.Text = c.PhoneNumber;


                codeCustomerInput.ReadOnly = true;
                //idCustomerUpdate.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateBtnCustomer_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(codeCustomerInput.Text);

            if (customerId == null)
            {
                MessageBox.Show("לא נמצא לקוח עם התעודת זהות שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer updatedCustomer = new Customer(
                customerId,
               nameCustomerUpdate.Text,
                 addressCustomerUpdate.Text,
                phoneCustomerUpdate.Text)
            {
            };


            try
            {
                _bl.Customer.Update(updatedCustomer);
                RefreshCustomerList();
                MessageBox.Show("הלקוח עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeCustomerInput.ReadOnly = false;
                idCustomerUpdate.ReadOnly = false;

                // איפוס הטופס
                nameCustomerUpdate.Text = "";
                codeCustomerInput.Text = "";
                idCustomerUpdate.Text = "";
                addressCustomerUpdate.Text = "";
                phoneCustomerUpdate.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון הלקוח: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtnCustomer_Click(object sender, EventArgs e)
        {
            int codeCustomer;
            if (int.TryParse(codeCustomerInputToDelete.Text, out codeCustomer))
            {

                _bl.Customer.Delete(codeCustomer);

                RefreshCustomerList();
                MessageBox.Show("הלקוח נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                codeCustomerInputToDelete.Text = "";
            }
            else
            {
                MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void showDetailsCustomer_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        int idCustomer = int.Parse(idCustomerDisplay.Text);
        //        detailCustomer.Items.Clear();

        //        var customer = _bl.ICustomer.Read(idCustomer);


        //        if (customer != null)
        //        {
        //            var customerDetails = customer.ToString();
        //            var customerLines = customerDetails.Split("\n");
        //            foreach (var line in customerLines)
        //            {
        //                detailCustomer.Items.Add(line);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("אירעה שגיאה בעת שליפת הלקוח: " + ex.Message,
        //                        "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void showDetailsCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer;
                if (!int.TryParse(idCustomerDisplay.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailCustomer.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.Customer.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailCustomer.Items.Add(line);
                    }
                    idCustomerDisplay.Text = "";
                }
                else
                {
                    MessageBox.Show("לא נמצא לקוח עם הקוד הזה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוח: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterByPhone_TextChanged(object sender, EventArgs e)
        {
            string phoneToSearch = filterByPhone.Text.Trim();
            try
            {
                List<Customer> customers = _bl.Customer.ReadAll();
                var filtered=customers.Where(c=>c.PhoneNumber.Contains(phoneToSearch)).ToList();
                customersList.Items.Clear();
                if(filtered.Count==0&& !string.IsNullOrEmpty(phoneToSearch))
                    customersList.Items.Add("לא נמצאו לקוחות.");
                else
                {
                    foreach (var customer in customers)
                    {
                        if (customer != null)
                        {
                            var customerDetails = customer.ToString() + "\n----------------------------";
                            // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                            var customerLines = customerDetails.Split("\n");
                            foreach (var line in customerLines)
                            {
                                customersList.Items.Add(line);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            ManagerMenu managerMenu = new ManagerMenu();
            managerMenu.Show();
            this.Close(); // סוגר את הטופס הנוכחי
        }
    }
}
