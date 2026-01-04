using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace yemekhanemenusıstemı
{
    public partial class productsForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public productsForm()
        {
            InitializeComponent();
            displayProducts();
            loadCategories();
        }

        private void displayProducts()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectData = @"SELECT p.id, p.productid, p.productname, p.category, 
                                         p.stock, p.price, p.status 
                                         FROM products p 
                                         ORDER BY p.id DESC";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridView1.DataSource = table;

                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].HeaderText = "ID";
                            if (dataGridView1.Columns.Count > 1)
                                dataGridView1.Columns[1].HeaderText = "Ürün Kodu";
                            if (dataGridView1.Columns.Count > 2)
                                dataGridView1.Columns[2].HeaderText = "Ürün Adı";
                            if (dataGridView1.Columns.Count > 3)
                                dataGridView1.Columns[3].HeaderText = "Kategori";
                            if (dataGridView1.Columns.Count > 4)
                                dataGridView1.Columns[4].HeaderText = "Stok";
                            if (dataGridView1.Columns.Count > 5)
                            {
                                dataGridView1.Columns[5].HeaderText = "Fiyat";
                                dataGridView1.Columns[5].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 6)
                                dataGridView1.Columns[6].HeaderText = "Durum";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCategories()
        {
            try
            {
                products_category.Items.Clear();
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectCat = "SELECT category FROM categories WHERE status = 'Active' ORDER BY category";
                    using (SqlCommand cmd = new SqlCommand(selectCat, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            products_category.Items.Add(reader["category"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void products_addBtn_Click(object sender, EventArgs e)
        {
            if (products_productID.Text == "" || products_productName.Text == "" || 
                products_category.SelectedIndex == -1 || products_stock.Text == "" || 
                products_price.Text == "" || products_status.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string checkProduct = "SELECT * FROM products WHERE productid = @prodid";
                    using (SqlCommand checkCmd = new SqlCommand(checkProduct, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@prodid", products_productID.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Bu ürün kodu zaten mevcut", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertData = @"INSERT INTO products (productid, productname, category, stock, price, status, date_insert) 
                                        VALUES(@productid, @productname, @category, @stock, @price, @status, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@productid", products_productID.Text.Trim());
                        cmd.Parameters.AddWithValue("@productname", products_productName.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", products_category.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(products_stock.Text.Trim()));
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(products_price.Text.Trim()));
                        cmd.Parameters.AddWithValue("@status", products_status.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            displayProducts();
        }

        private void products_updateBtn_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir ürün seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"ID {getID} numaralı ürünü güncellemek istediğinize emin misiniz?", 
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(connection))
                    {
                        connect.Open();
                        string updateData = @"UPDATE products SET productid = @prodid, productname = @prodname, 
                                            category = @cat, stock = @stock, price = @price, status = @status, 
                                            date_update = @date WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodid", products_productID.Text.Trim());
                            cmd.Parameters.AddWithValue("@prodname", products_productName.Text.Trim());
                            cmd.Parameters.AddWithValue("@cat", products_category.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(products_stock.Text.Trim()));
                            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(products_price.Text.Trim()));
                            cmd.Parameters.AddWithValue("@status", products_status.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@id", getID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                displayProducts();
            }
        }

        private void products_deleteBtn_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"ID {getID} numaralı ürünü silmek istediğinize emin misiniz?", 
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(connection))
                    {
                        connect.Open();
                        string deleteData = "DELETE FROM products WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                displayProducts();
            }
        }

        private void products_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                getID = Convert.ToInt32(row.Cells[0].Value);
                products_productID.Text = row.Cells[1].Value.ToString();
                products_productName.Text = row.Cells[2].Value.ToString();
                products_category.Text = row.Cells[3].Value.ToString();
                products_stock.Text = row.Cells[4].Value.ToString();
                products_price.Text = row.Cells[5].Value.ToString();
                products_status.Text = row.Cells[6].Value.ToString();
            }
        }

        void clearFields()
        {
            products_productID.Clear();
            products_productName.Clear();
            products_category.SelectedIndex = -1;
            products_stock.Clear();
            products_price.Clear();
            products_status.SelectedIndex = -1;
            getID = 0;
        }
    }
}

