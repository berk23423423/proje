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
    public partial class categoriesForm : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public categoriesForm()
        {
            InitializeComponent();
            displayCategories();

        }

        private void categories_addBtn_Click(object sender, EventArgs e)
        {
            if (categories_category.Text == "" || categories_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();

                    string selectCategory = "SELECT * FROM categories WHERE category = @cat";

                    using (SqlCommand checkCat = new SqlCommand(selectCategory, connect))
                    {
                        checkCat.Parameters.AddWithValue("@cat", categories_category.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(checkCat);
                        DataTable table = new DataTable();

                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show(categories_category.Text.Trim() + " is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO categories (category, status, date_insert) VALUES(@cat, @status, @date)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@cat", categories_category.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", categories_status.SelectedItem.ToString());

                                DateTime today = DateTime.Now;
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Added succesfully!", "Infarmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();

                               
                            }
                        }
                    }
                }
            }
            displayCategories();
        }

        void clearFields()
        {
            categories_category.Clear();
            categories_status.SelectedIndex = -1;
            getID = 0;
        }
        private void categories_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        public void RefreshData()
        {
            displayCategories();
        }

        public void displayCategories()
        {
            categoriesList cData = new categoriesList();
            List<categoriesList> listData = cData.categoriesListData();

            dataGridView1.DataSource = listData;
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                categories_category.Text = row.Cells[1].Value.ToString();
                categories_status.Text = row.Cells[2].Value.ToString();
            }
        }

        private void categories_updateBtn_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to update this ID: {getID}?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(connection))
                    {
                        connect.Open();

                        string updateData = "UPDATE categories SET category = @cat, status = @status WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.Parameters.AddWithValue("@cat", categories_category.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", categories_status.SelectedItem.ToString());

                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        connect.Close();
                    }

                    displayCategories();
                }
            }
        }

        private void categories_deleteBtn_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to delete this ID: {getID}?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(connection))
                    {
                        connect.Open();

                        string updateData = "DELETE FROM categories WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            
                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        connect.Close();
                    }

                    displayCategories();
                }

            }
        }
    }

}
 