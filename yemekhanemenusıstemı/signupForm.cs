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
    public partial class signupForm : Form
    {
        string connection;

        public signupForm()
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

        private void signupForm_Load(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to close this app?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void signup_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPassword.Checked ? '\0' : '*';
            signup_confirmPassword.PasswordChar = signup_showPassword.Checked ? '\0' : '*';

        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connection))
            {
                MessageBox.Show("Database connection is not configured!", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(signup_username.Text))
            {
                MessageBox.Show("Please enter a username!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(signup_password.Text))
            {
                MessageBox.Show("Please enter a password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();

                    string checkUsername = "SELECT * FROM users WHERE username = @usern";

                    using (SqlCommand checkUsern = new SqlCommand(checkUsername, connect))
                    {
                        checkUsern.Parameters.AddWithValue("@usern", signup_username.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        if (table.Rows.Count != 0)
                        {
                            MessageBox.Show($"{signup_username.Text.Trim()} was taken already",
                                            "Error Message",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        else if (signup_password.Text.Trim().Length < 8)
                        {
                            MessageBox.Show("Invalid Password, at least 8 characters required",
                                            "Error Message",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        else if (signup_password.Text.Trim() != signup_confirmPassword.Text.Trim())
                        {
                            MessageBox.Show("Password does not match",
                                            "Error Message",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData =
                                "INSERT INTO users (username, password, status, date_created) " +
                                "VALUES(@usern, @pass, @status, @date)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", signup_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", "Active");

                                DateTime today = DateTime.Now;
                                cmd.Parameters.AddWithValue("@date", today);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Registered successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form1 loginForm = new Form1();
                                    loginForm.Show();

                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Registration failed! Please try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\n\nPlease check your SQL Server connection.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}  
    

           
