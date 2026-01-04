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
    public partial class Form1 : Form
    {
        string connection;

        public Form1()
        {
            InitializeComponent();
            
            var connString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (connString == null)
            {
                MessageBox.Show("Connection string not found in App.config!", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection = string.Empty;
            }
            else
            {
                connection = connString.ConnectionString;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this app?",
                "Confirmation Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            signupForm signupForm = new signupForm();
            signupForm.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connection))
            {
                MessageBox.Show("Database connection is not configured!", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(login_username.Text))
            {
                MessageBox.Show("Please enter a username!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(login_password.Text))
            {
                MessageBox.Show("Please enter a password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connect;

                        cmd.CommandText = @"
                            SELECT 1 
                            FROM users
                            WHERE username = @username
                            AND password = @password";

                        cmd.Parameters.Add("@username", SqlDbType.VarChar)
                                      .Value = login_username.Text.Trim();

                        cmd.Parameters.Add("@password", SqlDbType.VarChar)
                                      .Value = login_password.Text.Trim();

                        connect.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            MessageBox.Show("Login successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\n\nPlease check your SQL Server connection.\n\nServer: Check if SQL Server is running and the instance name is correct.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPassword.Checked ? '\0' : '*';

        }
    }
}
