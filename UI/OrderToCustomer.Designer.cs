namespace UI
{
    partial class OrderToCustomer
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
            label1 = new Label();
            customerId = new Label();
            inputId = new TextBox();
            orderBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 54);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "הזמנת מוצרים ללקוח";
            // 
            // customerId
            // 
            customerId.AutoSize = true;
            customerId.Location = new Point(363, 108);
            customerId.Name = "customerId";
            customerId.Size = new Size(97, 15);
            customerId.TabIndex = 1;
            customerId.Text = "תעודת זהות לקוח";
            // 
            // inputId
            // 
            inputId.Location = new Point(211, 108);
            inputId.Margin = new Padding(3, 2, 3, 2);
            inputId.Name = "inputId";
            inputId.Size = new Size(110, 23);
            inputId.TabIndex = 2;
            // 
            // orderBtn
            // 
            orderBtn.Location = new Point(257, 156);
            orderBtn.Margin = new Padding(3, 2, 3, 2);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(129, 44);
            orderBtn.TabIndex = 3;
            orderBtn.Text = "התחל הזמנה";
            orderBtn.UseVisualStyleBackColor = true;
            orderBtn.Click += orderBtn_Click;
            // 
            // OrderToCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(orderBtn);
            Controls.Add(inputId);
            Controls.Add(customerId);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderToCustomer";
            Text = "OrderToCustomer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label customerId;
        private TextBox inputId;
        private Button orderBtn;
    }
}