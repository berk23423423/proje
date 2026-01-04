namespace yemekhanemenusıstemı
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.customers_btn = new System.Windows.Forms.Button();
            this.categories_btn = new System.Windows.Forms.Button();
            this.inventory_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.warehouseExitForm1 = new yemekhanemenusıstemı.warehouseExitForm();
            this.warehouseEntryForm1 = new yemekhanemenusıstemı.warehouseEntryForm();
            this.categoriesForm1 = new yemekhanemenusıstemı.categoriesForm();
            this.inventoryForm1 = new yemekhanemenusıstemı.inventoryForm();
            this.shopForm1 = new yemekhanemenusıstemı.shopForm();
            this.dashboardForm1 = new yemekhanemenusıstemı.dashboardForm();
            this.customersForm1 = new yemekhanemenusıstemı.customersForm();
            this.warehouseEntry_btn = new System.Windows.Forms.Button();
            this.warehouseExit_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 41);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Yemekhane Menu Sistemı";
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Firebrick;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(1273, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(54, 23);
            this.close.TabIndex = 0;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.warehouseExit_btn);
            this.panel2.Controls.Add(this.warehouseEntry_btn);
            this.panel2.Controls.Add(this.customers_btn);
            this.panel2.Controls.Add(this.categories_btn);
            this.panel2.Controls.Add(this.inventory_btn);
            this.panel2.Controls.Add(this.shop_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 713);
            this.panel2.TabIndex = 12;
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Location = new System.Drawing.Point(12, 670);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(211, 31);
            this.logout_btn.TabIndex = 10;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.button6_Click);
            // 
            // warehouseExit_btn
            // 
            this.warehouseExit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.warehouseExit_btn.FlatAppearance.BorderSize = 0;
            this.warehouseExit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.warehouseExit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.warehouseExit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseExit_btn.ForeColor = System.Drawing.Color.White;
            this.warehouseExit_btn.Location = new System.Drawing.Point(12, 589);
            this.warehouseExit_btn.Name = "warehouseExit_btn";
            this.warehouseExit_btn.Size = new System.Drawing.Size(211, 41);
            this.warehouseExit_btn.TabIndex = 9;
            this.warehouseExit_btn.Text = "Depo Çıkış";
            this.warehouseExit_btn.UseVisualStyleBackColor = false;
            this.warehouseExit_btn.Click += new System.EventHandler(this.warehouseExit_btn_Click);
            // 
            // warehouseEntry_btn
            // 
            this.warehouseEntry_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.warehouseEntry_btn.FlatAppearance.BorderSize = 0;
            this.warehouseEntry_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.warehouseEntry_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.warehouseEntry_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseEntry_btn.ForeColor = System.Drawing.Color.White;
            this.warehouseEntry_btn.Location = new System.Drawing.Point(12, 525);
            this.warehouseEntry_btn.Name = "warehouseEntry_btn";
            this.warehouseEntry_btn.Size = new System.Drawing.Size(211, 41);
            this.warehouseEntry_btn.TabIndex = 8;
            this.warehouseEntry_btn.Text = "Depo Giriş";
            this.warehouseEntry_btn.UseVisualStyleBackColor = false;
            this.warehouseEntry_btn.Click += new System.EventHandler(this.warehouseEntry_btn_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.customers_btn.FlatAppearance.BorderSize = 0;
            this.customers_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.customers_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customers_btn.ForeColor = System.Drawing.Color.White;
            this.customers_btn.Location = new System.Drawing.Point(12, 461);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(211, 41);
            this.customers_btn.TabIndex = 6;
            this.customers_btn.Text = "Customers";
            this.customers_btn.UseVisualStyleBackColor = false;
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // categories_btn
            // 
            this.categories_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.categories_btn.FlatAppearance.BorderSize = 0;
            this.categories_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.categories_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.categories_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categories_btn.ForeColor = System.Drawing.Color.White;
            this.categories_btn.Location = new System.Drawing.Point(12, 365);
            this.categories_btn.Name = "categories_btn";
            this.categories_btn.Size = new System.Drawing.Size(211, 41);
            this.categories_btn.TabIndex = 5;
            this.categories_btn.Text = "Categories";
            this.categories_btn.UseVisualStyleBackColor = false;
            this.categories_btn.Click += new System.EventHandler(this.categories_btn_Click);
            // 
            // inventory_btn
            // 
            this.inventory_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_btn.FlatAppearance.BorderSize = 0;
            this.inventory_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.inventory_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.inventory_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_btn.ForeColor = System.Drawing.Color.White;
            this.inventory_btn.Location = new System.Drawing.Point(12, 333);
            this.inventory_btn.Name = "inventory_btn";
            this.inventory_btn.Size = new System.Drawing.Size(211, 41);
            this.inventory_btn.TabIndex = 4;
            this.inventory_btn.Text = "Inventory";
            this.inventory_btn.UseVisualStyleBackColor = false;
            this.inventory_btn.Click += new System.EventHandler(this.inventory_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.shop_btn.FlatAppearance.BorderSize = 0;
            this.shop_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.shop_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.shop_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shop_btn.ForeColor = System.Drawing.Color.White;
            this.shop_btn.Location = new System.Drawing.Point(12, 270);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(211, 41);
            this.shop_btn.TabIndex = 3;
            this.shop_btn.Text = "Shop";
            this.shop_btn.UseVisualStyleBackColor = false;
            this.shop_btn.Click += new System.EventHandler(this.shop_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.dashboard_btn.FlatAppearance.BorderSize = 0;
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(130)))), ((int)(((byte)(98)))));
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Location = new System.Drawing.Point(12, 205);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(211, 41);
            this.dashboard_btn.TabIndex = 2;
            this.dashboard_btn.Text = "Dashbord";
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome Admin ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::yemekhanemenusıstemı.Properties.Resources.User_icon_2_svg;
            this.pictureBox1.Location = new System.Drawing.Point(64, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.warehouseExitForm1);
            this.panel3.Controls.Add(this.warehouseEntryForm1);
            this.panel3.Controls.Add(this.customersForm1);
            this.panel3.Controls.Add(this.categoriesForm1);
            this.panel3.Controls.Add(this.inventoryForm1);
            this.panel3.Controls.Add(this.shopForm1);
            this.panel3.Controls.Add(this.dashboardForm1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(239, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 713);
            this.panel3.TabIndex = 13;
            // 
            // categoriesForm1
            // 
            this.categoriesForm1.BackColor = System.Drawing.Color.White;
            this.categoriesForm1.Location = new System.Drawing.Point(0, 0);
            this.categoriesForm1.Name = "categoriesForm1";
            this.categoriesForm1.Size = new System.Drawing.Size(1100, 713);
            this.categoriesForm1.TabIndex = 3;
            // 
            // inventoryForm1
            // 
            this.inventoryForm1.Location = new System.Drawing.Point(0, 0);
            this.inventoryForm1.Name = "inventoryForm1";
            this.inventoryForm1.Size = new System.Drawing.Size(1097, 713);
            this.inventoryForm1.TabIndex = 2;
            // 
            // shopForm1
            // 
            this.shopForm1.Location = new System.Drawing.Point(0, 0);
            this.shopForm1.Name = "shopForm1";
            this.shopForm1.Size = new System.Drawing.Size(1100, 727);
            this.shopForm1.TabIndex = 1;
            // 
            // dashboardForm1
            // 
            this.dashboardForm1.Location = new System.Drawing.Point(6, 0);
            this.dashboardForm1.Name = "dashboardForm1";
            this.dashboardForm1.Size = new System.Drawing.Size(1084, 710);
            this.dashboardForm1.TabIndex = 0;
            // 
            // customersForm1
            // 
            this.customersForm1.Location = new System.Drawing.Point(0, 0);
            this.customersForm1.Name = "customersForm1";
            this.customersForm1.Size = new System.Drawing.Size(1100, 713);
            this.customersForm1.TabIndex = 4;
            // 
            // warehouseEntryForm1
            // 
            this.warehouseEntryForm1.Location = new System.Drawing.Point(0, 0);
            this.warehouseEntryForm1.Name = "warehouseEntryForm1";
            this.warehouseEntryForm1.Size = new System.Drawing.Size(1100, 713);
            this.warehouseEntryForm1.TabIndex = 6;
            // 
            // warehouseExitForm1
            // 
            this.warehouseExitForm1.Location = new System.Drawing.Point(0, 0);
            this.warehouseExitForm1.Name = "warehouseExitForm1";
            this.warehouseExitForm1.Size = new System.Drawing.Size(1100, 713);
            this.warehouseExitForm1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 754);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button customers_btn;
        private System.Windows.Forms.Button categories_btn;
        private System.Windows.Forms.Button inventory_btn;
        private System.Windows.Forms.Button shop_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private dashboardForm dashboardForm1;
        private shopForm shopForm1;
        private inventoryForm inventoryForm1;
        private categoriesForm categoriesForm1;
        private customersForm customersForm1;
        private warehouseEntryForm warehouseEntryForm1;
        private warehouseExitForm warehouseExitForm1;
        private System.Windows.Forms.Button warehouseEntry_btn;
        private System.Windows.Forms.Button warehouseExit_btn;
    }
}