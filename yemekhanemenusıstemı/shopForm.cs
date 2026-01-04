using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace yemekhanemenusıstemı
{
    public partial class shopForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private List<string> allCategories = new List<string>();

        public shopForm()
        {
            InitializeComponent();
            loadCategories();
            loadProducts();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            
            if (comboBoxCategory != null && allCategories.Count > 0)
            {
                comboBoxCategory.DataSource = allCategories;
                comboBoxCategory.SelectedIndex = 0;
            }
        }

        public void RefreshData()
        {
            loadCategories();
            loadProducts();
        }

        public void carditems(int id, string productname, string stock, string price, Image image, string productid, string category, string quantity)
        {
            var card = new cardProduct()
            {
                id = id,
                productName = productname,
                productStock = stock,
                productPrice = price,
                productImage = image,
                productId = productid,
                category = category,
                productQuantity = !string.IsNullOrWhiteSpace(quantity) ? quantity : "1",
            };

            flowLayoutPanel1.Controls.Add(card);

            card.selectCard += (q, w) =>
            {
                try
                {
                    var selectedCard = (cardProduct)q;
                    bool flag = false;

                    if (selectedCard == null || selectedCard.id == 0)
                        return;

                    string priceStr = selectedCard.productPrice ?? "0";
                    priceStr = priceStr.Replace("$", "").Replace("₺", "").Trim();
                    
                    if (string.IsNullOrWhiteSpace(priceStr))
                        priceStr = "0";

                    string quantityStr = selectedCard.productQuantity ?? "1";
                    if (string.IsNullOrWhiteSpace(quantityStr))
                        quantityStr = "1";

                    decimal getPrice = 0;
                    int getQuantity = 1;

                    if (!decimal.TryParse(priceStr, out getPrice))
                        getPrice = 0;

                    if (!int.TryParse(quantityStr, out getQuantity) || getQuantity <= 0)
                        getQuantity = 1;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["id"].Value != null && (int)row.Cells["id"].Value == selectedCard.id)
                        {
                            row.Cells["Price"].Value = getPrice * getQuantity;
                            row.Cells["QTY"].Value = getQuantity;
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        dataGridView1.Rows.Add(selectedCard.id, selectedCard.productName, getQuantity, getPrice * getQuantity);
                    }
                    updateTotalprice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding product to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private void updateTotalprice()
        {
            decimal totalprice = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["id"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                    totalprice += price;
                }
            }

            shop_total.Text = $"${totalprice:F2}";
        }
        private void loadCategories()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectCat = "SELECT DISTINCT category FROM products WHERE status = 'Available' ORDER BY category";
                    using (SqlCommand cmd = new SqlCommand(selectCat, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        allCategories.Clear();
                        allCategories.Add("All Categories");
                        while (reader.Read())
                        {
                            allCategories.Add(reader["category"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadProducts()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectData = "SELECT * FROM products WHERE status = 'Available'";
                    string categoryFilter = "";
                    string searchFilter = "";

                    if (comboBoxCategory != null && comboBoxCategory.SelectedItem != null && comboBoxCategory.SelectedItem.ToString() != "All Categories")
                    {
                        categoryFilter = $" AND category = '{comboBoxCategory.SelectedItem.ToString().Replace("'", "''")}'";
                    }

                    if (textBoxSearch != null && !string.IsNullOrWhiteSpace(textBoxSearch.Text))
                    {
                        searchFilter = $" AND productname LIKE '%{textBoxSearch.Text.Replace("'", "''")}%'";
                    }

                    selectData += categoryFilter + searchFilter;

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        flowLayoutPanel1.Controls.Clear();

                        foreach (DataRow row in table.Rows)
                        {
                            int id = row["id"] != DBNull.Value ? (int)row["id"] : 0;
                            string productname = row["productname"]?.ToString() ?? "N/A";
                            string stock = row["stock"]?.ToString() ?? "0";
                            
                            string price = "0.00";
                            if (row["price"] != DBNull.Value && row["price"] != null)
                            {
                                decimal priceValue = 0;
                                if (decimal.TryParse(row["price"].ToString(), out priceValue))
                                {
                                    price = priceValue.ToString("F2");
                                }
                            }
                            
                            string productid = row["productid"]?.ToString() ?? "N/A";
                            string category = row["category"]?.ToString() ?? "N/A";

                            Image image = null;
                            if (row["image"] != DBNull.Value && row["image"] != null)
                            {
                                string imagePath = row["image"].ToString();
                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                {
                                    try { image = Image.FromFile(imagePath); }
                                    catch { image = null; }
                                }
                            }

                            carditems(id, productname, stock, price, image, productid, category, "1");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shop_change_Enter(object sender, EventArgs e)
        {
        }

        bool check = false;

        private void shop_change_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        decimal getTotal = Convert.ToDecimal(shop_total.Text.ToString().Replace("$", ""));
                        decimal getChange = Convert.ToDecimal(shop_change.Text);

                        if (getTotal > getChange)
                        {
                            MessageBox.Show("Invalid: Insufficient Amount", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            check = true;
                            shop_amount.Text = $"${(getChange - getTotal):0.00}";
                        }
                        e.SuppressKeyPress = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void shop_placeOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();

                    string countData = "SELECT COUNT(*) FROM orders";
                    int count = 1;

                    using (SqlCommand cData = new SqlCommand(countData, connect))
                    {
                        count = Convert.ToInt32(cData.ExecuteScalar()) + 1;
                    }

                    List<string> productIds = new List<string>();
                    List<string> quantities = new List<string>();
                    List<string> prices = new List<string>();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["id"].Value != null && row.Cells["QTY"].Value != null && row.Cells["Price"].Value != null)
                        {
                            productIds.Add(row.Cells["id"].Value.ToString());
                            quantities.Add(row.Cells["QTY"].Value.ToString());
                            prices.Add(row.Cells["Price"].Value.ToString());
                        }
                    }

                    for (int i = 0; i < productIds.Count; i++)
                    {
                        string checkStock = "SELECT stock, productname FROM products WHERE id = @id";
                        using (SqlCommand stockCmd = new SqlCommand(checkStock, connect))
                        {
                            stockCmd.Parameters.AddWithValue("@id", productIds[i]);
                            using (SqlDataReader reader = stockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = Convert.ToInt32(reader["stock"]);
                                    int requestedQty = Convert.ToInt32(quantities[i]);
                                    string productName = reader["productname"].ToString();

                                    if (currentStock < requestedQty)
                                    {
                                        reader.Close();
                                        MessageBox.Show($"Insufficient stock for {productName}!\nAvailable: {currentStock}, Requested: {requestedQty}", 
                                            "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                reader.Close();
                            }
                        }
                    }

                    string productIdsStr = string.Join(",", productIds);
                    string quantitiesStr = string.Join(",", quantities);
                    string pricesStr = string.Join(",", prices);

                    decimal totalAmount = Convert.ToDecimal(shop_total.Text.Replace("$", ""));

                    string insertData = "INSERT INTO orders (customerId, productids, quantities, prices, total, date_order) " +
                                        "VALUES(@cid, @pid, @qty, @price, @total, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@cid", $"CID-{count}");
                        cmd.Parameters.AddWithValue("@pid", productIdsStr);
                        cmd.Parameters.AddWithValue("@qty", quantitiesStr);
                        cmd.Parameters.AddWithValue("@price", pricesStr);
                        cmd.Parameters.AddWithValue("@total", totalAmount);

                        DateTime today = DateTime.Now;
                        cmd.Parameters.AddWithValue("@date", today);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            for (int q = 0; q < productIds.Count; q++)
                            {
                                string updateData = "UPDATE products SET stock = stock - @qty WHERE id = @id";

                                using (SqlCommand updateCmd = new SqlCommand(updateData, connect))
                                {
                                    updateCmd.Parameters.AddWithValue("@qty", quantities[q]);
                                    updateCmd.Parameters.AddWithValue("@id", productIds[q]);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearCart();
                            loadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Order placement failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void clearCart()
        {
            dataGridView1.Rows.Clear();
            shop_total.Text = "$0.00";
            shop_change.Text = "";
            shop_amount.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cart is already empty!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Clear cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clearCart();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["id"].Value != null && row.Cells["QTY"].Value != null)
                {
                    try
                    {
                        int qty = Convert.ToInt32(row.Cells["QTY"].Value);
                        if (qty <= 0)
                        {
                            MessageBox.Show("Quantity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.Cells["QTY"].Value = 1;
                            qty = 1;
                        }

                        int productId = Convert.ToInt32(row.Cells["id"].Value);
                        decimal unitPrice = GetProductPrice(productId);
                        decimal totalPrice = unitPrice * qty;

                        row.Cells["Price"].Value = totalPrice;
                        updateTotalprice();
                    }
                    catch
                    {
                        row.Cells["QTY"].Value = 1;
                        MessageBox.Show("Invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["QTY"].Value == null || string.IsNullOrWhiteSpace(row.Cells["QTY"].Value.ToString()))
                {
                    row.Cells["QTY"].Value = 1;
                }
            }
        }

        private decimal GetProductPrice(int productId)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectPrice = "SELECT price FROM products WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(selectPrice, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch { }
            return 0;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                updateTotalprice();
            }
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
                updateTotalprice();
            }
            else
            {
                MessageBox.Show("Please select an item to remove", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

    









