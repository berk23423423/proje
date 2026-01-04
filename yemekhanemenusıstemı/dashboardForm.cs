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
    public partial class dashboardForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public dashboardForm()
        {
            InitializeComponent();
        }

        private void dashboardForm_Load(object sender, EventArgs e)
        {
            loadDashboardData();
        }

        public void loadDashboardData()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();

                    // Total Users
                    string countUsers = "SELECT COUNT(*) FROM users";
                    using (SqlCommand cmd = new SqlCommand(countUsers, connect))
                    {
                        int totalUsers = Convert.ToInt32(cmd.ExecuteScalar());
                        label2.Text = totalUsers.ToString();
                    }

                    // Total Products
                    string countProducts = "SELECT COUNT(*) FROM products";
                    using (SqlCommand cmd = new SqlCommand(countProducts, connect))
                    {
                        int totalProducts = Convert.ToInt32(cmd.ExecuteScalar());
                        label3.Text = totalProducts.ToString();
                    }

                    // Today's Revenue
                    string todayRevenue = @"SELECT ISNULL(SUM(total), 0) FROM orders 
                                          WHERE CAST(date_order AS DATE) = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(todayRevenue, connect))
                    {
                        decimal todayRev = Convert.ToDecimal(cmd.ExecuteScalar());
                        label5.Text = $"${todayRev:F2}";
                    }

                    // Total Revenue
                    string totalRevenue = "SELECT ISNULL(SUM(total), 0) FROM orders";
                    using (SqlCommand cmd = new SqlCommand(totalRevenue, connect))
                    {
                        decimal totalRev = Convert.ToDecimal(cmd.ExecuteScalar());
                        label7.Text = $"${totalRev:F2}";
                    }

                    // Today's Sales
                    loadTodaySales(connect);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTodaySales(SqlConnection connect)
        {
            try
            {
                string selectData = @"SELECT customerId, total, date_order 
                                     FROM orders 
                                     WHERE CAST(date_order AS DATE) = CAST(GETDATE() AS DATE)
                                     ORDER BY date_order DESC";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Customer ID";
                    dataGridView1.Columns[1].HeaderText = "Total";
                    dataGridView1.Columns[2].HeaderText = "Date";
                    
                    if (dataGridView1.Columns.Count > 1)
                    {
                        dataGridView1.Columns[1].DefaultCellStyle.Format = "C2";
                    }
                    if (dataGridView1.Columns.Count > 2)
                    {
                        dataGridView1.Columns[2].DefaultCellStyle.Format = "g";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading today's sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
