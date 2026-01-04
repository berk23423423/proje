namespace yemekhanemenusıstemı
{
    partial class productsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.products_clearBtn = new System.Windows.Forms.Button();
            this.products_deleteBtn = new System.Windows.Forms.Button();
            this.products_updateBtn = new System.Windows.Forms.Button();
            this.products_addBtn = new System.Windows.Forms.Button();
            this.products_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.products_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.products_stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.products_category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.products_productName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.products_productID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(24, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 381);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1015, 322);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(11, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tüm Ürünler";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.products_clearBtn);
            this.panel2.Controls.Add(this.products_deleteBtn);
            this.panel2.Controls.Add(this.products_updateBtn);
            this.panel2.Controls.Add(this.products_addBtn);
            this.panel2.Controls.Add(this.products_status);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.products_price);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.products_stock);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.products_category);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.products_productName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.products_productID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.Location = new System.Drawing.Point(24, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 279);
            this.panel2.TabIndex = 1;
            // 
            // products_clearBtn
            // 
            this.products_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.products_clearBtn.FlatAppearance.BorderSize = 0;
            this.products_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_clearBtn.ForeColor = System.Drawing.Color.White;
            this.products_clearBtn.Location = new System.Drawing.Point(608, 206);
            this.products_clearBtn.Name = "products_clearBtn";
            this.products_clearBtn.Size = new System.Drawing.Size(122, 30);
            this.products_clearBtn.TabIndex = 17;
            this.products_clearBtn.Text = "TEMİZLE";
            this.products_clearBtn.UseVisualStyleBackColor = false;
            this.products_clearBtn.Click += new System.EventHandler(this.products_clearBtn_Click);
            // 
            // products_deleteBtn
            // 
            this.products_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.products_deleteBtn.FlatAppearance.BorderSize = 0;
            this.products_deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.products_deleteBtn.Location = new System.Drawing.Point(458, 206);
            this.products_deleteBtn.Name = "products_deleteBtn";
            this.products_deleteBtn.Size = new System.Drawing.Size(122, 30);
            this.products_deleteBtn.TabIndex = 16;
            this.products_deleteBtn.Text = "SİL";
            this.products_deleteBtn.UseVisualStyleBackColor = false;
            this.products_deleteBtn.Click += new System.EventHandler(this.products_deleteBtn_Click);
            // 
            // products_updateBtn
            // 
            this.products_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.products_updateBtn.FlatAppearance.BorderSize = 0;
            this.products_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_updateBtn.ForeColor = System.Drawing.Color.White;
            this.products_updateBtn.Location = new System.Drawing.Point(241, 206);
            this.products_updateBtn.Name = "products_updateBtn";
            this.products_updateBtn.Size = new System.Drawing.Size(122, 30);
            this.products_updateBtn.TabIndex = 15;
            this.products_updateBtn.Text = "GÜNCELLE";
            this.products_updateBtn.UseVisualStyleBackColor = false;
            this.products_updateBtn.Click += new System.EventHandler(this.products_updateBtn_Click);
            // 
            // products_addBtn
            // 
            this.products_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.products_addBtn.FlatAppearance.BorderSize = 0;
            this.products_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.products_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_addBtn.ForeColor = System.Drawing.Color.White;
            this.products_addBtn.Location = new System.Drawing.Point(89, 206);
            this.products_addBtn.Name = "products_addBtn";
            this.products_addBtn.Size = new System.Drawing.Size(122, 30);
            this.products_addBtn.TabIndex = 14;
            this.products_addBtn.Text = "EKLE";
            this.products_addBtn.UseVisualStyleBackColor = false;
            this.products_addBtn.Click += new System.EventHandler(this.products_addBtn_Click);
            // 
            // products_status
            // 
            this.products_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_status.FormattingEnabled = true;
            this.products_status.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.products_status.Location = new System.Drawing.Point(526, 126);
            this.products_status.Name = "products_status";
            this.products_status.Size = new System.Drawing.Size(184, 26);
            this.products_status.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Durum:";
            // 
            // products_price
            // 
            this.products_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_price.Location = new System.Drawing.Point(526, 82);
            this.products_price.Name = "products_price";
            this.products_price.Size = new System.Drawing.Size(184, 24);
            this.products_price.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fiyat($):";
            // 
            // products_stock
            // 
            this.products_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_stock.Location = new System.Drawing.Point(526, 37);
            this.products_stock.Name = "products_stock";
            this.products_stock.Size = new System.Drawing.Size(184, 24);
            this.products_stock.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Stok:";
            // 
            // products_category
            // 
            this.products_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_category.FormattingEnabled = true;
            this.products_category.Location = new System.Drawing.Point(147, 123);
            this.products_category.Name = "products_category";
            this.products_category.Size = new System.Drawing.Size(184, 26);
            this.products_category.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kategori:";
            // 
            // products_productName
            // 
            this.products_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_productName.Location = new System.Drawing.Point(147, 79);
            this.products_productName.Name = "products_productName";
            this.products_productName.Size = new System.Drawing.Size(184, 24);
            this.products_productName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Adı:";
            // 
            // products_productID
            // 
            this.products_productID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.products_productID.Location = new System.Drawing.Point(147, 34);
            this.products_productID.Name = "products_productID";
            this.products_productID.Size = new System.Drawing.Size(184, 24);
            this.products_productID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Kodu:";
            // 
            // productsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "productsForm";
            this.Size = new System.Drawing.Size(1100, 713);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox products_productName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox products_productID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox products_category;
        private System.Windows.Forms.ComboBox products_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox products_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox products_stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button products_clearBtn;
        private System.Windows.Forms.Button products_deleteBtn;
        private System.Windows.Forms.Button products_updateBtn;
        private System.Windows.Forms.Button products_addBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

