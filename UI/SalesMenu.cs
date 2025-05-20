using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class SalesMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public SalesMenu()
        {
            InitializeComponent();
            this.Load += SalesMenu_Load;
        }
        private void SalesMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSalesList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המבצע: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {

        }

        private void category_Click(object sender, EventArgs e)
        {

        }

        private void addCustomer_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchSaleBtn_Click(object sender, EventArgs e)
        {
            int saleId = int.Parse(idSaleInput.Text);
            try
            {
                Sale p = _bl.Sale.Read(saleId);
                idSalePInput.Text = Convert.ToString(p.ProductId);
                minAmountSaleInputUpdate.Text = Convert.ToString(p.MinAmount);
                isOnlyClubInputUpdate.Checked = Convert.ToBoolean(p.ClubSale);
                fainalPriceInputUpdate.Text = Convert.ToString(p.SalePrice);
                startSaleDateInputUpdate.Value = Convert.ToDateTime(p.StartSale);
                lastSaleDateInputUpdate.Value = Convert.ToDateTime(p.FinishSale);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addSaleBtn_Click(object sender, EventArgs e)
        {
            Sale s = new Sale(
            int.Parse(idSaleProductInput.Text),
            int.Parse( idSalePInput.Text),
            int.Parse(minAmountSaleInput.Text),
            double.Parse(fainalPriceInput.Text),
            isOnlyClubInput.Checked,           
            startSaleDateInput.Value,
            lastSaleDateInput.Value
            );
            _bl.Sale.Create(s);

            MessageBox.Show("המבצע נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshSalesList();

            // איפוס הטופס
            idSaleInput.Text = "";
            idSaleProductInput.Text = "";
            minAmountSaleInput.Text = "";
            isOnlyClubInput.Checked = false;
            fainalPriceInput.Text = "";
            startSaleDateInput.Value = DateTime.Now;
            lastSaleDateInput.Value = DateTime.Now;

        }

        private void RefreshSalesList()
        {
            try
            {
                List<Sale?> sales = _bl.Sale.ReadAll();
                salesListBox.Items.Clear();

                foreach (var sale in sales)
                {
                    if (sale != null)
                    {
                        var saleDetails = sale.ToString() + "\n----------------------------";

                        var saleLines = saleDetails.Split("\n");
                        foreach (var line in saleLines)
                        {
                            salesListBox.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המבצעים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveUpdatedBtn_Click(object sender, EventArgs e)
        {

            int saleId = int.Parse(idSaleInput.Text);

            if (saleId == null)
            {
                MessageBox.Show("לא נמצא מבצע עם הקוד שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Sale updatedSale = new Sale(
                saleId,
                int.Parse(idSalePInput.Text),
                (int)minAmountSaleInputUpdate.Value,
                (int)fainalPriceInputUpdate.Value,
                isOnlyClubInputUpdate.Checked,
                startSaleDateInputUpdate.Value,
                 lastSaleDateInputUpdate.Value
            );


            try
            {
                _bl.Sale.Update(updatedSale);
                RefreshSalesList();
                MessageBox.Show("המבצע עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // איפוס הטופס
                idSaleInput.Text = "";
                idSalePInput.Text = "";
                minAmountSaleInputUpdate.Value = minAmountSaleInputUpdate.Minimum;
                fainalPriceInputUpdate.Value = fainalPriceInputUpdate.Minimum;
                isOnlyClubInputUpdate.Checked = false;
                startSaleDateInputUpdate.Value = DateTime.Now;
                lastSaleDateInputUpdate.Value = DateTime.Now;


            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון המבצע: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

            int codeSale;
            if (int.TryParse(codeSaleInputToDelete.Text, out codeSale))
            {
                // כאן תוכל להוסיף את הקוד למחיקת המבצע מה-BL
                _bl.Sale.Delete(codeSale);
                RefreshSalesList();
                // הצגת הודעה שהמבצע נמחק בהצלחה
                MessageBox.Show("המבצע נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeSaleInputToDelete.Text = "";
            }
            else
            {
                // הצגת הודעה אם הקלט לא תקין
                MessageBox.Show("אנא הכנס קוד מבצע תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void showDetailsSale_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int idSale = int.Parse(codeSaleInputSearch.Text);

            //    detailsSale.Items.Clear();

            //    var sale = _bl.ISale.Read(idSale);


            //    if (sale != null)
            //    {
            //        var saleDetails = sale.ToString();
            //        var saleLines = saleDetails.Split("\n");
            //        foreach (var line in saleLines)
            //        {
            //            detailsSale.Items.Add(line);
            //        }
            //    }
            //    codeSaleInputSearch.Text = "";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("אירעה שגיאה בעת שליפת המבצע: " + ex.Message,
            //                    "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {
                int idCustomer;
                if (!int.TryParse(codeSaleInputSearch.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailsSale.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.Sale.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailsSale.Items.Add(line);
                    }
                    codeSaleInputSearch.Text = "";
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
            //פעם ראשונה להצגה עובד פעם שניה לא
        }
    }
}
