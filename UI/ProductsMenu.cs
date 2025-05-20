using BlApi;
using BO;
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
    public partial class ProductsMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public ProductsMenu()
        {
            InitializeComponent();
            this.Load += ProductsMenu_Load;
        }

        private void ProductsMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshProductList();
                // עדכון קטגוריות
                categoryUpdate.DataSource = Enum.GetValues(typeof(Category));
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void addProduct_Click(object sender, EventArgs e)
        {
            Product p = new Product(0,
            nameProductInput.Text,
            (Category)Enum.Parse(typeof(Category), categoryInput.SelectedItem.ToString()),
            (double)priceInput.Value,
             (int)amountInput.Value);

            _bl.Product.Create(p);
            RefreshProductList();
            MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // איפוס הטופס
            nameProductInput.Text = "";
            categoryInput.SelectedIndex = -1;
            priceInput.Value = 0;
            amountInput.Value = 0;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int codeProduct;
            if (int.TryParse(codeInputToDelete.Text, out codeProduct))
            {
                // כאן תוכל להוסיף את הקוד למחיקת המוצר מה-BL
                _bl.Product.Delete(codeProduct);

                // הצגת הודעה שהמוצר נמחק בהצלחה
                MessageBox.Show("המוצר נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductList();
                codeInputToDelete.Text = "";
            }
            else
            {
                // הצגת הודעה אם הקלט לא תקין
                MessageBox.Show("אנא הכנס קוד מוצר תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            int productId = int.Parse(codeProductInput.Text);

            if (productId == null)
            {
                MessageBox.Show("לא נמצא מוצר עם השם שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product updatedProduct = new Product(
 productId,
                 string.IsNullOrEmpty(nameProduct.Text) ? "שם מוצר ברירת מחדל" : nameProduct.Text,
                categoryUpdate.SelectedItem == null ? Category.אקססוריז : (Category)Enum.Parse(typeof(Category), categoryUpdate.SelectedItem.ToString()),
                price.Value == 0 ? 0 : (double)price.Value,
               amount.Value == 0 ? 0 : (int)amount.Value
            );


            try
            {
                _bl.Product.Update(updatedProduct);
                RefreshProductList();
                MessageBox.Show("המוצר עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeProductInput.ReadOnly = false;

                // איפוס הטופס
                codeProductInput.Text = "";
                nameProduct.Text = "";
                categoryUpdate.SelectedIndex = -1;
                price.Value = 0;
                amount.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון המוצר: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void displayProducts_Click(object sender, EventArgs e)
        {
            try
            {
                // שליפת כל המוצרים מהמלאי
                List<Product> products = _bl.Product.ReadAll();

                // ניקוי הרשימה לפני שמכניסים את החדשים
                productsList.Items.Clear();

                // הוספת המוצרים לתצוגה (אפשר לעצב איך שרוצים)
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        productsList.Items.Add(
                            $"שם: {product.ProductName}, קטגוריה: {product.category}, מחיר: {product.Price} ₪, כמות: {product.QuantityInStock}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void ProductsMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(codeProductInput.Text);
            try
            {
                Product p = _bl.Product.Read(productId);
                nameProduct.Text = p.ProductName;
                categoryUpdate.SelectedItem = p.category;
                price.Value = (int)p.Price;
                amount.Value = (int)p.QuantityInStock;

                codeProductInput.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void RefreshProductList()
        {
            
                List<Product?> products = _bl.Product.ReadAll();
            try
            {
                productsList.Items.Clear();

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer;
                if (!int.TryParse(idProductSearch.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailProductOne.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.Product.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailProductOne.Items.Add(line);
                    }
                    idProductSearch.Text = "";
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
            //לבדוק שעובד בטוח
        }
    }
}
