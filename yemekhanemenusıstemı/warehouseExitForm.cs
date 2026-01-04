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
    public partial class warehouseExitForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public warehouseExitForm()
        {
            InitializeComponent();
            displayExits();
            loadWarehouses();
            loadProducts();
        }

        public void RefreshData()
        {
            displayExits();
        }

        private void displayExits()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectData = @"SELECT we.id, we.exit_code, w.warehouse_name, 
                                         p.productname, we.quantity, we.unit_price, we.total_price, 
                                         we.exit_date, we.reason
                                         FROM warehouse_exits we
                                         LEFT JOIN warehouses w ON we.warehouse_id = w.id
                                         LEFT JOIN products p ON we.product_id = p.id
                                         ORDER BY we.exit_date DESC";

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
                                dataGridView1.Columns[1].HeaderText = "Çıkış Kodu";
                            if (dataGridView1.Columns.Count > 2)
                                dataGridView1.Columns[2].HeaderText = "Depo";
                            if (dataGridView1.Columns.Count > 3)
                                dataGridView1.Columns[3].HeaderText = "Ürün";
                            if (dataGridView1.Columns.Count > 4)
                                dataGridView1.Columns[4].HeaderText = "Miktar";
                            if (dataGridView1.Columns.Count > 5)
                            {
                                dataGridView1.Columns[5].HeaderText = "Birim Fiyat";
                                dataGridView1.Columns[5].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 6)
                            {
                                dataGridView1.Columns[6].HeaderText = "Toplam Fiyat";
                                dataGridView1.Columns[6].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 7)
                            {
                                dataGridView1.Columns[7].HeaderText = "Tarih";
                                dataGridView1.Columns[7].DefaultCellStyle.Format = "g";
                            }
                            if (dataGridView1.Columns.Count > 8)
                                dataGridView1.Columns[8].HeaderText = "Sebep";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadWarehouses()
        {
            try
            {
                exit_warehouse.Items.Clear();
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectWarehouses = "SELECT id, warehouse_name FROM warehouses WHERE status = 'Active' ORDER BY warehouse_name";
                    using (SqlCommand cmd = new SqlCommand(selectWarehouses, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            exit_warehouse.Items.Add(new ComboBoxItem(reader["warehouse_name"].ToString(), Convert.ToInt32(reader["id"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadProducts()
        {
            try
            {
                exit_product.Items.Clear();
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectProducts = "SELECT id, productname FROM products WHERE status = 'Available' ORDER BY productname";
                    using (SqlCommand cmd = new SqlCommand(selectProducts, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            exit_product.Items.Add(new ComboBoxItem(reader["productname"].ToString(), Convert.ToInt32(reader["id"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_addBtn_Click(object sender, EventArgs e)
        {
            if (exit_code.Text == "" || exit_warehouse.SelectedIndex == -1 || 
                exit_product.SelectedIndex == -1 || exit_quantity.Text == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string checkCode = "SELECT * FROM warehouse_exits WHERE exit_code = @code";
                    using (SqlCommand checkCmd = new SqlCommand(checkCode, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@code", exit_code.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Bu çıkış kodu zaten mevcut", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int warehouseId = ((ComboBoxItem)exit_warehouse.SelectedItem).Value;
                    int productId = ((ComboBoxItem)exit_product.SelectedItem).Value;
                    int quantity = Convert.ToInt32(exit_quantity.Text.Trim());

                    string checkStock = "SELECT stock FROM products WHERE id = @productid";
                    int currentStock = 0;
                    using (SqlCommand stockCmd = new SqlCommand(checkStock, connect))
                    {
                        stockCmd.Parameters.AddWithValue("@productid", productId);
                        object result = stockCmd.ExecuteScalar();
                        if (result != null)
                        {
                            currentStock = Convert.ToInt32(result);
                        }
                    }

                    if (quantity > currentStock)
                    {
                        MessageBox.Show($"Yetersiz stok! Mevcut stok: {currentStock}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal? unitPrice = null;
                    decimal? totalPrice = null;

                    if (exit_unitPrice.Text != "")
                    {
                        unitPrice = Convert.ToDecimal(exit_unitPrice.Text.Trim());
                        totalPrice = unitPrice * quantity;
                    }

                    string insertData = @"INSERT INTO warehouse_exits 
                                        (exit_code, warehouse_id, product_id, quantity, unit_price, total_price, exit_date, reason, notes) 
                                        VALUES(@code, @warehouse, @product, @quantity, @unitprice, @totalprice, @date, @reason, @notes)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@code", exit_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@warehouse", warehouseId);
                        cmd.Parameters.AddWithValue("@product", productId);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        if (unitPrice.HasValue)
                            cmd.Parameters.AddWithValue("@unitprice", unitPrice.Value);
                        else
                            cmd.Parameters.AddWithValue("@unitprice", DBNull.Value);
                        if (totalPrice.HasValue)
                            cmd.Parameters.AddWithValue("@totalprice", totalPrice.Value);
                        else
                            cmd.Parameters.AddWithValue("@totalprice", DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@reason", exit_reason.Text.Trim());
                        cmd.Parameters.AddWithValue("@notes", exit_notes.Text.Trim());

                        cmd.ExecuteNonQuery();

                        string updateStock = "UPDATE products SET stock = stock - @qty WHERE id = @productid";
                        using (SqlCommand updateCmd = new SqlCommand(updateStock, connect))
                        {
                            updateCmd.Parameters.AddWithValue("@qty", quantity);
                            updateCmd.Parameters.AddWithValue("@productid", productId);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Depo çıkışı başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            displayExits();
        }

        private void exit_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        void clearFields()
        {
            exit_code.Clear();
            exit_warehouse.SelectedIndex = -1;
            exit_product.SelectedIndex = -1;
            exit_quantity.Clear();
            exit_unitPrice.Clear();
            exit_reason.Clear();
            exit_notes.Clear();
        }

        private void exit_unitPrice_TextChanged(object sender, EventArgs e)
        {
            if (exit_quantity.Text != "" && exit_unitPrice.Text != "")
            {
                try
                {
                    int qty = Convert.ToInt32(exit_quantity.Text);
                    decimal price = Convert.ToDecimal(exit_unitPrice.Text);
                    exit_totalPrice.Text = (qty * price).ToString("F2");
                }
                catch { }
            }
            else
            {
                exit_totalPrice.Text = "";
            }
        }

        private void exit_quantity_TextChanged(object sender, EventArgs e)
        {
            exit_unitPrice_TextChanged(sender, e);
        }
    }
}

