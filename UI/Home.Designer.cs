namespace UI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            manager = new Button();
            seller = new Button();
            SuspendLayout();
            // 
            // manager
            // 
            manager.Location = new Point(881, 238);
            manager.Margin = new Padding(5, 6, 5, 6);
            manager.Name = "manager";
            manager.Size = new Size(385, 98);
            manager.TabIndex = 0;
            manager.Text = "מנהל";
            manager.UseVisualStyleBackColor = true;
            manager.Click += manager_Click;
            // 
            // seller
            // 
            seller.Location = new Point(242, 238);
            seller.Margin = new Padding(5, 6, 5, 6);
            seller.Name = "seller";
            seller.Size = new Size(377, 98);
            seller.TabIndex = 0;
            seller.Text = "קופאי";
            seller.UseVisualStyleBackColor = true;
            seller.Click += seller_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 960);
            Controls.Add(manager);
            Controls.Add(seller);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button manager;
        private Button seller;
    }
}
