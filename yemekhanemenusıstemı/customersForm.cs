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
using System.Configuration;

namespace yemekhanemenusıstemı
{
    public partial class customersForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public customersForm()
        {
            InitializeComponent();
        }

        private void customersForm_Load(object sender, EventArgs e)
        {
            displayOrders();
        }

        public void RefreshData()
        {
            displayOrders();
        }

        public void displayOrders()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();

                    string selectData = "SELECT customerId, productids, quantities, prices, total, date_order FROM orders ORDER BY date_order DESC";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridView1.DataSource = table;
                        dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
                        
                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].HeaderText = "Customer ID";
                            if (dataGridView1.Columns.Count > 1)
                                dataGridView1.Columns[1].HeaderText = "Products";
                            if (dataGridView1.Columns.Count > 2)
                                dataGridView1.Columns[2].HeaderText = "Quantities";
                            if (dataGridView1.Columns.Count > 3)
                                dataGridView1.Columns[3].HeaderText = "Prices";
                            if (dataGridView1.Columns.Count > 4)
                            {
                                dataGridView1.Columns[4].HeaderText = "Total";
                                dataGridView1.Columns[4].DefaultCellStyle.Format = "C2";
                            }
                            if (dataGridView1.Columns.Count > 5)
                            {
                                dataGridView1.Columns[5].HeaderText = "Date";
                                dataGridView1.Columns[5].DefaultCellStyle.Format = "g";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string customerId = row.Cells[0].Value?.ToString() ?? "";
                string productIds = row.Cells[1].Value?.ToString() ?? "";
                string quantities = row.Cells[2].Value?.ToString() ?? "";
                string prices = row.Cells[3].Value?.ToString() ?? "";
                string total = row.Cells[4].Value?.ToString() ?? "";
                string date = row.Cells[5].Value?.ToString() ?? "";

                string[] productIdArray = productIds.Split(',');
                string[] quantityArray = quantities.Split(',');
                string[] priceArray = prices.Split(',');

                StringBuilder details = new StringBuilder();
                details.AppendLine($"Customer ID: {customerId}");
                details.AppendLine($"Date: {date}");
                details.AppendLine($"Total: {total}");
                details.AppendLine("\nOrder Details:");
                details.AppendLine("-----------------------------------");

                for (int i = 0; i < productIdArray.Length && i < quantityArray.Length && i < priceArray.Length; i++)
                {
                    string productName = GetProductName(productIdArray[i]);
                    details.AppendLine($"{i + 1}. {productName}");
                    details.AppendLine($"   Quantity: {quantityArray[i]}");
                    details.AppendLine($"   Price: ${priceArray[i]}");
                    details.AppendLine();
                }

                MessageBox.Show(details.ToString(), "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetProductName(string productId)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string selectName = "SELECT productname FROM products WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(selectName, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", productId.Trim());
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch { }
            return $"Product ID: {productId}";
        }
    }
}
