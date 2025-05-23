namespace UI
{
    partial class ManagerMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customers = new Button();
            products = new Button();
            sales = new Button();
            SuspendLayout();
            // 
            // customers
            // 
            customers.Location = new Point(597, 200);
            customers.Margin = new Padding(3, 4, 3, 4);
            customers.Name = "customers";
            customers.Size = new Size(200, 67);
            customers.TabIndex = 0;
            customers.Text = "לקוחות";
            customers.UseVisualStyleBackColor = true;
            customers.Click += customers_Click;
            // 
            // products
            // 
            products.Location = new Point(347, 200);
            products.Margin = new Padding(3, 4, 3, 4);
            products.Name = "products";
            products.Size = new Size(200, 67);
            products.TabIndex = 1;
            products.Text = "מוצרים";
            products.UseVisualStyleBackColor = true;
            products.Click += products_Click;
            // 
            // sales
            // 
            sales.Location = new Point(86, 200);
            sales.Margin = new Padding(3, 4, 3, 4);
            sales.Name = "sales";
            sales.Size = new Size(200, 67);
            sales.TabIndex = 2;
            sales.Text = "מבצעים";
            sales.UseVisualStyleBackColor = true;
            sales.Click += sales_Click;
            // 
            // ManagerMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(sales);
            Controls.Add(products);
            Controls.Add(customers);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ManagerMenu";
            Text = "ManagerMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button customers;
        private Button products;
        private Button sales;
    }
}