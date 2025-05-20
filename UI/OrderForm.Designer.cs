namespace UI
{
    partial class OrderForm
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
            myOrder = new ListBox();
            add = new TabControl();
            addProduct = new TabPage();
            addProductToOrder = new Button();
            amountToOrderProduct = new NumericUpDown();
            label1 = new Label();
            codeProductToAdd = new TextBox();
            label2 = new Label();
            deleteProduct = new TabPage();
            deleteFromOrder = new Button();
            codeProductInputTםDelete = new TextBox();
            nameProductLable = new Label();
            endOrder = new Button();
            sumOrder = new TextBox();
            label3 = new Label();
            listProduct = new ListBox();
            helloName = new TextBox();
            label4 = new Label();
            add.SuspendLayout();
            addProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountToOrderProduct).BeginInit();
            deleteProduct.SuspendLayout();
            SuspendLayout();
            // 
            // myOrder
            // 
            myOrder.FormattingEnabled = true;
            myOrder.ItemHeight = 15;
            myOrder.Location = new Point(12, 46);
            myOrder.Margin = new Padding(3, 2, 3, 2);
            myOrder.Name = "myOrder";
            myOrder.Size = new Size(294, 259);
            myOrder.TabIndex = 8;
            // 
            // add
            // 
            add.Controls.Add(addProduct);
            add.Controls.Add(deleteProduct);
            add.Location = new Point(312, 63);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.RightToLeft = RightToLeft.Yes;
            add.RightToLeftLayout = true;
            add.SelectedIndex = 0;
            add.Size = new Size(405, 242);
            add.TabIndex = 10;
            // 
            // addProduct
            // 
            addProduct.Controls.Add(addProductToOrder);
            addProduct.Controls.Add(amountToOrderProduct);
            addProduct.Controls.Add(label1);
            addProduct.Controls.Add(codeProductToAdd);
            addProduct.Controls.Add(label2);
            addProduct.Location = new Point(4, 24);
            addProduct.Margin = new Padding(3, 2, 3, 2);
            addProduct.Name = "addProduct";
            addProduct.Padding = new Padding(3, 2, 3, 2);
            addProduct.Size = new Size(397, 214);
            addProduct.TabIndex = 2;
            addProduct.Text = "הוספת מוצר";
            addProduct.UseVisualStyleBackColor = true;
            // 
            // addProductToOrder
            // 
            addProductToOrder.Location = new Point(86, 119);
            addProductToOrder.Margin = new Padding(3, 2, 3, 2);
            addProductToOrder.Name = "addProductToOrder";
            addProductToOrder.Size = new Size(224, 38);
            addProductToOrder.TabIndex = 19;
            addProductToOrder.Text = "הוסף להזמנה";
            addProductToOrder.UseVisualStyleBackColor = true;
            addProductToOrder.Click += addProductToOrder_Click;
            // 
            // amountToOrderProduct
            // 
            amountToOrderProduct.Location = new Point(86, 65);
            amountToOrderProduct.Margin = new Padding(3, 2, 3, 2);
            amountToOrderProduct.Name = "amountToOrderProduct";
            amountToOrderProduct.Size = new Size(131, 23);
            amountToOrderProduct.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 67);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 17;
            label1.Text = "כמות להזמנה";
            // 
            // codeProductToAdd
            // 
            codeProductToAdd.Location = new Point(107, 22);
            codeProductToAdd.Margin = new Padding(3, 2, 3, 2);
            codeProductToAdd.Name = "codeProductToAdd";
            codeProductToAdd.Size = new Size(110, 23);
            codeProductToAdd.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(249, 25);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 15;
            label2.Text = "קוד מוצר";
            // 
            // deleteProduct
            // 
            deleteProduct.Controls.Add(deleteFromOrder);
            deleteProduct.Controls.Add(codeProductInputTםDelete);
            deleteProduct.Controls.Add(nameProductLable);
            deleteProduct.Location = new Point(4, 24);
            deleteProduct.Name = "deleteProduct";
            deleteProduct.Size = new Size(397, 214);
            deleteProduct.TabIndex = 3;
            deleteProduct.Text = "מחיקת מוצר";
            deleteProduct.UseVisualStyleBackColor = true;
            // 
            // deleteFromOrder
            // 
            deleteFromOrder.Location = new Point(108, 97);
            deleteFromOrder.Margin = new Padding(3, 2, 3, 2);
            deleteFromOrder.Name = "deleteFromOrder";
            deleteFromOrder.Size = new Size(205, 38);
            deleteFromOrder.TabIndex = 14;
            deleteFromOrder.Text = "מחק מההזמנה";
            deleteFromOrder.UseVisualStyleBackColor = true;
            deleteFromOrder.Click += deleteFromOrder_Click_1;
            // 
            // codeProductInputTםDelete
            // 
            codeProductInputTםDelete.Location = new Point(108, 49);
            codeProductInputTםDelete.Margin = new Padding(3, 2, 3, 2);
            codeProductInputTםDelete.Name = "codeProductInputTםDelete";
            codeProductInputTםDelete.Size = new Size(110, 23);
            codeProductInputTםDelete.TabIndex = 11;
            // 
            // nameProductLable
            // 
            nameProductLable.AutoSize = true;
            nameProductLable.Location = new Point(250, 52);
            nameProductLable.Name = "nameProductLable";
            nameProductLable.Size = new Size(52, 15);
            nameProductLable.TabIndex = 10;
            nameProductLable.Text = "קוד מוצר";
            // 
            // endOrder
            // 
            endOrder.Location = new Point(12, 356);
            endOrder.Margin = new Padding(3, 2, 3, 2);
            endOrder.Name = "endOrder";
            endOrder.Size = new Size(259, 40);
            endOrder.TabIndex = 15;
            endOrder.Text = "סיום הזמנה";
            endOrder.UseVisualStyleBackColor = true;
            endOrder.Click += endOrder_Click_1;
            // 
            // sumOrder
            // 
            sumOrder.Location = new Point(66, 317);
            sumOrder.Margin = new Padding(3, 2, 3, 2);
            sumOrder.Name = "sumOrder";
            sumOrder.Size = new Size(106, 23);
            sumOrder.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 320);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 17;
            label3.Text = "סכום לתשלום";
            // 
            // listProduct
            // 
            listProduct.FormattingEnabled = true;
            listProduct.ItemHeight = 15;
            listProduct.Location = new Point(723, 63);
            listProduct.Margin = new Padding(3, 2, 3, 2);
            listProduct.Name = "listProduct";
            listProduct.Size = new Size(213, 319);
            listProduct.TabIndex = 19;
            // 
            // helloName
            // 
            helloName.Location = new Point(402, 22);
            helloName.Margin = new Padding(3, 2, 3, 2);
            helloName.Name = "helloName";
            helloName.RightToLeft = RightToLeft.Yes;
            helloName.Size = new Size(110, 23);
            helloName.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(518, 25);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 20;
            label4.Text = "שלום ל";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 476);
            Controls.Add(helloName);
            Controls.Add(label4);
            Controls.Add(listProduct);
            Controls.Add(sumOrder);
            Controls.Add(label3);
            Controls.Add(endOrder);
            Controls.Add(add);
            Controls.Add(myOrder);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            add.ResumeLayout(false);
            addProduct.ResumeLayout(false);
            addProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountToOrderProduct).EndInit();
            deleteProduct.ResumeLayout(false);
            deleteProduct.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox myOrder;
        private TabControl add;
        private TabPage addProduct;
        private TabPage deleteProduct;
        private Button addProductToOrder;
        private NumericUpDown amountToOrderProduct;
        private Label label1;
        private TextBox codeProductToAdd;
        private Label label2;
        private Button deleteFromOrder;
        private TextBox codeProductInputTםDelete;
        private Label nameProductLable;
        private Button endOrder;
        private TextBox sumOrder;
        private Label label3;
        private ListBox listProduct;
        private TextBox helloName;
        private Label label4;
    }
}