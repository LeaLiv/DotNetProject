using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;


namespace UI
{
    public partial class OrderForm : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public int CustomerId { get; set; } // מאפיין לתעודת זהות

        Order Order;
        public OrderForm()
        {
            InitializeComponent();
            Order = new Order(false,new List<ProductInOrder>(),0);
            this.Load += OrderForm_Load;
        }


        private void OrderForm_Load(object sender, EventArgs e)
        {

            try
            {
                RefreshProductList();
                //Customer customer = _bl.ICustomer.Read(CustomerId);
                //if (customer != null)
                //{
                //    helloName.Text = Convert.ToString(customer.NameCustomer);
                //}
                //else
                //{
                //    label4.Visible = false;
                //    helloName.Visible = false;
                //    //לסדר אם אין שם
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצר: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(codeProductInputTםDelete.Text, out int productId))
                {
                    ProductInOrder productInOrder = new ProductInOrder
                    {
                        QuantityInOrder = (int)amountToOrderProduct.Value,
                        ProductId = productId
                    };

                    _bl.Order.AddProductToOrder(Order, productInOrder.ProductId, productInOrder.QuantityInOrder );
                    myOrder.DataSource = Order.ProductsInOrder.SelectMany(p => (p.ToString() + "\n----------------------------").Split("\n")).ToList();
                }
                else
                {
                    MessageBox.Show("נא להזין קוד מוצר תקין וכמות חיובית.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספה המוצר: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void endOrder_Click(object sender, EventArgs e)
        {
            _bl.Order.DoOrder(Order);
            this.Close();
        }


        private void addProductToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(codeProductToAdd.Text);
                int amount = (int)amountToOrderProduct.Value; // המרה מ-decimal ל-int
                                                              // כאן נוודא שהפרמטרים מתאימים למה שהמתודה מצפה
                _bl.Order.AddProductToOrder(Order, productId, amount);
                MessageBox.Show(Order.ProductsInOrder.Count.ToString());
                RefreshProductsInOrderList();
                MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספת המוצר: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void RefreshProductsInOrderList()
        {
            try
            {
                List<ProductInOrder?> productsInOrderList = Order.ProductsInOrder;
                myOrder.Items.Clear();

                foreach (var product in productsInOrderList)
                {
                    if (product != null)
                    {
                        //נופל בשורה הזו!
                        var productDetails = product.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            myOrder.Items.Add(line);
                        }
                    }
                }
                sumOrder.Text = Order.Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshProductList()
        {
            try
            {
                List<Product?> products = _bl.Product.ReadAll();
                listProduct.Items.Clear();

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            listProduct.Items.Add(line);
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

        private void deleteFromOrder_Click(object sender, EventArgs e)
        {

            //if (int.TryParse(codeProductInputTםDelete.Text, out int productId))
            //{
            //    // חפש את המוצר ברשימת המוצרים בהזמנה
            //    var productToRemove = Order.ListProductInOrder.FirstOrDefault(p => p.IdProductInOrder == productId);

            //    if (productToRemove != null)
            //    {
            //        // הסר את המוצר מהרשימה
            //        Order.ListProductInOrder.Remove(productToRemove);
            //        //מעדכן את המחיר הכללי
            //        _bl.IOrder.CalcTotalPrice(Order);
            //        RefreshProductsInOrderList();
            //        MessageBox.Show("המוצר הוסר מההזמנה.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("המוצר לא נמצא בהזמנה.");
            //    }
            //}
            //else
            //{!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!למחוקקקקקקקקקקקק
            //    MessageBox.Show("נא להזין קוד מוצר תקין.");
            //}
        }

        private void deleteFromOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(codeProductInputTםDelete.Text, out int productId))
                {
                    // חפש את המוצר ברשימת המוצרים בהזמנה
                    var productToRemove = Order.ProductsInOrder.FirstOrDefault(p => p.ProductId == productId);

                    if (productToRemove != null)
                    {
                        // הסר את המוצר מהרשימה
                        Order.ProductsInOrder.Remove(productToRemove);
                        RefreshProductsInOrderList();
                        MessageBox.Show("המוצר הוסר מההזמנה.");
                    }
                    else
                    {
                        MessageBox.Show("המוצר לא נמצא בהזמנה.");
                    }
                }
                else
                {
                    MessageBox.Show("נא להזין קוד מוצר תקין.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת המוצר: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void endOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                _bl.Order.DoOrder(Order);
                MessageBox.Show("ההזמנה הושלמה בהצלחה");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סיום הזמנה: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //בדיקת לקוח מועדון
        private bool isPreferred()
        {
            Customer customer =  _bl.Customer.Read(CustomerId);
            return customer != null;
            //האם לא צריך להשתמש בREAD שיחזיר BOOL???לשאול
        }


    }
}
