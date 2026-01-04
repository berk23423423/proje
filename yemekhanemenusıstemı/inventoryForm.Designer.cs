namespace yemekhanemenusıstemı
{
    partial class inventoryForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inventory_clearBtn = new System.Windows.Forms.Button();
            this.inventory_deleteBtn = new System.Windows.Forms.Button();
            this.inventory_updateBtn = new System.Windows.Forms.Button();
            this.inventory_addBtn = new System.Windows.Forms.Button();
            this.inventory_importBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inventory_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inventory_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inventory_stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inventory_category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inventory_productName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inventory_productID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "All Products";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.inventory_clearBtn);
            this.panel2.Controls.Add(this.inventory_deleteBtn);
            this.panel2.Controls.Add(this.inventory_updateBtn);
            this.panel2.Controls.Add(this.inventory_addBtn);
            this.panel2.Controls.Add(this.inventory_importBtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.inventory_status);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.inventory_price);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.inventory_stock);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.inventory_category);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.inventory_productName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.inventory_productID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.Location = new System.Drawing.Point(24, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 279);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // inventory_clearBtn
            // 
            this.inventory_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_clearBtn.FlatAppearance.BorderSize = 0;
            this.inventory_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_clearBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_clearBtn.Location = new System.Drawing.Point(608, 206);
            this.inventory_clearBtn.Name = "inventory_clearBtn";
            this.inventory_clearBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_clearBtn.TabIndex = 17;
            this.inventory_clearBtn.Text = "CLEAR";
            this.inventory_clearBtn.UseVisualStyleBackColor = false;
            this.inventory_clearBtn.Click += new System.EventHandler(this.inventory_clearBtn_Click);
            // 
            // inventory_deleteBtn
            // 
            this.inventory_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_deleteBtn.FlatAppearance.BorderSize = 0;
            this.inventory_deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_deleteBtn.Location = new System.Drawing.Point(458, 206);
            this.inventory_deleteBtn.Name = "inventory_deleteBtn";
            this.inventory_deleteBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_deleteBtn.TabIndex = 16;
            this.inventory_deleteBtn.Text = "DELETE";
            this.inventory_deleteBtn.UseVisualStyleBackColor = false;
            this.inventory_deleteBtn.Click += new System.EventHandler(this.inventory_deleteBtn_Click);
            // 
            // inventory_updateBtn
            // 
            this.inventory_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_updateBtn.FlatAppearance.BorderSize = 0;
            this.inventory_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_updateBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_updateBtn.Location = new System.Drawing.Point(241, 206);
            this.inventory_updateBtn.Name = "inventory_updateBtn";
            this.inventory_updateBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_updateBtn.TabIndex = 15;
            this.inventory_updateBtn.Text = "UPDATE";
            this.inventory_updateBtn.UseVisualStyleBackColor = false;
            this.inventory_updateBtn.Click += new System.EventHandler(this.inventory_updateBtn_Click);
            // 
            // inventory_addBtn
            // 
            this.inventory_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_addBtn.FlatAppearance.BorderSize = 0;
            this.inventory_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_addBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_addBtn.Location = new System.Drawing.Point(89, 206);
            this.inventory_addBtn.Name = "inventory_addBtn";
            this.inventory_addBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_addBtn.TabIndex = 14;
            this.inventory_addBtn.Text = "ADD";
            this.inventory_addBtn.UseVisualStyleBackColor = false;
            this.inventory_addBtn.Click += new System.EventHandler(this.inventory_addBtn_Click);
            // 
            // inventory_importBtn
            // 
            this.inventory_importBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_importBtn.FlatAppearance.BorderSize = 0;
            this.inventory_importBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_importBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_importBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_importBtn.Location = new System.Drawing.Point(876, 173);
            this.inventory_importBtn.Name = "inventory_importBtn";
            this.inventory_importBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_importBtn.TabIndex = 13;
            this.inventory_importBtn.Text = "IMPORT";
            this.inventory_importBtn.UseVisualStyleBackColor = false;
            this.inventory_importBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(876, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(122, 129);
            this.panel3.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // inventory_status
            // 
            this.inventory_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_status.FormattingEnabled = true;
            this.inventory_status.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.inventory_status.Location = new System.Drawing.Point(526, 126);
            this.inventory_status.Name = "inventory_status";
            this.inventory_status.Size = new System.Drawing.Size(184, 26);
            this.inventory_status.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // inventory_price
            // 
            this.inventory_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_price.Location = new System.Drawing.Point(526, 82);
            this.inventory_price.Name = "inventory_price";
            this.inventory_price.Size = new System.Drawing.Size(184, 24);
            this.inventory_price.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price($):";
            // 
            // inventory_stock
            // 
            this.inventory_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_stock.Location = new System.Drawing.Point(526, 37);
            this.inventory_stock.Name = "inventory_stock";
            this.inventory_stock.Size = new System.Drawing.Size(184, 24);
            this.inventory_stock.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Stock:";
            // 
            // inventory_category
            // 
            this.inventory_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_category.FormattingEnabled = true;
            this.inventory_category.Location = new System.Drawing.Point(147, 123);
            this.inventory_category.Name = "inventory_category";
            this.inventory_category.Size = new System.Drawing.Size(184, 26);
            this.inventory_category.TabIndex = 5;
            this.inventory_category.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category:";
            // 
            // inventory_productName
            // 
            this.inventory_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_productName.Location = new System.Drawing.Point(147, 79);
            this.inventory_productName.Name = "inventory_productName";
            this.inventory_productName.Size = new System.Drawing.Size(184, 24);
            this.inventory_productName.TabIndex = 3;
            this.inventory_productName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Products Name:";
            // 
            // inventory_productID
            // 
            this.inventory_productID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inventory_productID.Location = new System.Drawing.Point(147, 34);
            this.inventory_productID.Name = "inventory_productID";
            this.inventory_productID.Size = new System.Drawing.Size(184, 24);
            this.inventory_productID.TabIndex = 1;
            this.inventory_productID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products ID:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // inventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "inventoryForm";
            this.Size = new System.Drawing.Size(1084, 727);
            this.Load += new System.EventHandler(this.inventoryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox inventory_productName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inventory_productID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox inventory_category;
        private System.Windows.Forms.ComboBox inventory_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inventory_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inventory_stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button inventory_importBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button inventory_clearBtn;
        private System.Windows.Forms.Button inventory_deleteBtn;
        private System.Windows.Forms.Button inventory_updateBtn;
        private System.Windows.Forms.Button inventory_addBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
