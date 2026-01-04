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
    public partial class warehouseEntryForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public warehouseEntryForm()
        {
            InitializeComponent();
            displayEntries();
            loadWarehouses();
            loadSuppliers();
            loadProducts();
        }

        public void RefreshData()
        {
            displayEntries();
        }

        private void displayEntries()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectData = @"SELECT we.id, we.entry_code, w.warehouse_name, s.supplier_name, 
                                         p.productname, we.quantity, we.unit_price, we.total_price, we.entry_date
                                         FROM warehouse_entries we
                                         LEFT JOIN warehouses w ON we.warehouse_id = w.id
                                         LEFT JOIN suppliers s ON we.supplier_id = s.id
                                         LEFT JOIN products p ON we.product_id = p.id
                                         ORDER BY we.entry_date DESC";

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
                                dataGridView1.Columns[1].HeaderText = "Giriş Kodu";
                            if (dataGridView1.Columns.Count > 2)
                                dataGridView1.Columns[2].HeaderText = "Depo";
                            if (dataGridView1.Columns.Count > 3)
                                dataGridView1.Columns[3].HeaderText = "Tedarikçi";
                            if (dataGridView1.Columns.Count > 4)
                                dataGridView1.Columns[4].HeaderText = "Ürün";
                            if (dataGridView1.Columns.Count > 5)
                                dataGridView1.Columns[5].HeaderText = "Miktar";
                            if (dataGridView1.Columns.Count > 6)
                            {
                                dataGridView1.Columns[6].HeaderText = "Birim Fiyat";
                                dataGridView1.Columns[6].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 7)
                            {
                                dataGridView1.Columns[7].HeaderText = "Toplam Fiyat";
                                dataGridView1.Columns[7].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 8)
                            {
                                dataGridView1.Columns[8].HeaderText = "Tarih";
                                dataGridView1.Columns[8].DefaultCellStyle.Format = "g";
                            }
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
                entry_warehouse.Items.Clear();
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectWarehouses = "SELECT id, warehouse_name FROM warehouses WHERE status = 'Active' ORDER BY warehouse_name";
                    using (SqlCommand cmd = new SqlCommand(selectWarehouses, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            entry_warehouse.Items.Add(new ComboBoxItem(reader["warehouse_name"].ToString(), Convert.ToInt32(reader["id"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSuppliers()
        {
            try
            {
                entry_supplier.Items.Clear();
                entry_supplier.Items.Add("Seçiniz");
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectSuppliers = "SELECT id, supplier_name FROM suppliers WHERE status = 'Active' ORDER BY supplier_name";
                    using (SqlCommand cmd = new SqlCommand(selectSuppliers, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            entry_supplier.Items.Add(new ComboBoxItem(reader["supplier_name"].ToString(), Convert.ToInt32(reader["id"])));
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
                entry_product.Items.Clear();
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectProducts = "SELECT id, productname FROM products WHERE status = 'Available' ORDER BY productname";
                    using (SqlCommand cmd = new SqlCommand(selectProducts, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            entry_product.Items.Add(new ComboBoxItem(reader["productname"].ToString(), Convert.ToInt32(reader["id"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void entry_addBtn_Click(object sender, EventArgs e)
        {
            if (entry_code.Text == "" || entry_warehouse.SelectedIndex == -1 || 
                entry_product.SelectedIndex == -1 || entry_quantity.Text == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string checkCode = "SELECT * FROM warehouse_entries WHERE entry_code = @code";
                    using (SqlCommand checkCmd = new SqlCommand(checkCode, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@code", entry_code.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Bu giriş kodu zaten mevcut", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int warehouseId = ((ComboBoxItem)entry_warehouse.SelectedItem).Value;
                    int productId = ((ComboBoxItem)entry_product.SelectedItem).Value;
                    int? supplierId = null;
                    if (entry_supplier.SelectedIndex > 0)
                    {
                        supplierId = ((ComboBoxItem)entry_supplier.SelectedItem).Value;
                    }

                    int quantity = Convert.ToInt32(entry_quantity.Text.Trim());
                    decimal? unitPrice = null;
                    decimal? totalPrice = null;

                    if (entry_unitPrice.Text != "")
                    {
                        unitPrice = Convert.ToDecimal(entry_unitPrice.Text.Trim());
                        totalPrice = unitPrice * quantity;
                    }

                    string insertData = @"INSERT INTO warehouse_entries 
                                        (entry_code, warehouse_id, supplier_id, product_id, quantity, unit_price, total_price, entry_date, notes) 
                                        VALUES(@code, @warehouse, @supplier, @product, @quantity, @unitprice, @totalprice, @date, @notes)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@code", entry_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@warehouse", warehouseId);
                        if (supplierId.HasValue)
                            cmd.Parameters.AddWithValue("@supplier", supplierId.Value);
                        else
                            cmd.Parameters.AddWithValue("@supplier", DBNull.Value);
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
                        cmd.Parameters.AddWithValue("@notes", entry_notes.Text.Trim());

                        cmd.ExecuteNonQuery();

                        string updateStock = "UPDATE products SET stock = stock + @qty WHERE id = @productid";
                        using (SqlCommand updateCmd = new SqlCommand(updateStock, connect))
                        {
                            updateCmd.Parameters.AddWithValue("@qty", quantity);
                            updateCmd.Parameters.AddWithValue("@productid", productId);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Depo girişi başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            displayEntries();
        }

        private void entry_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        void clearFields()
        {
            entry_code.Clear();
            entry_warehouse.SelectedIndex = -1;
            entry_supplier.SelectedIndex = 0;
            entry_product.SelectedIndex = -1;
            entry_quantity.Clear();
            entry_unitPrice.Clear();
            entry_notes.Clear();
        }

        private void entry_unitPrice_TextChanged(object sender, EventArgs e)
        {
            if (entry_quantity.Text != "" && entry_unitPrice.Text != "")
            {
                try
                {
                    int qty = Convert.ToInt32(entry_quantity.Text);
                    decimal price = Convert.ToDecimal(entry_unitPrice.Text);
                    entry_totalPrice.Text = (qty * price).ToString("F2");
                }
                catch { }
            }
            else
            {
                entry_totalPrice.Text = "";
            }
        }

        private void entry_quantity_TextChanged(object sender, EventArgs e)
        {
            entry_unitPrice_TextChanged(sender, e);
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}

