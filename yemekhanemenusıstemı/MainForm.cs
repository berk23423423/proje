using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemekhanemenusıstemı
{
    public partial class MainForm :Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void button6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want logout",
                "Confirmation Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = true;
            shopForm1.Visible = false;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = false;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = false;
            dashboardForm1.loadDashboardData();
        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = true;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = false;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = false;
            shopForm1.RefreshData();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = false;
            inventoryForm1.Visible = true;
            categoriesForm1.Visible = false;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = false;
            inventoryForm1.RefreshData();
        }

        private void categories_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = false;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = true;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = false;
            categoriesForm1.RefreshData();
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = false;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = false;
            customersForm1.Visible = true;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = false;
            customersForm1.RefreshData();
        }

        private void warehouseEntry_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = false;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = false;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = true;
            warehouseExitForm1.Visible = false;
            warehouseEntryForm1.RefreshData();
        }

        private void warehouseExit_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            shopForm1.Visible = false;
            inventoryForm1.Visible = false;
            categoriesForm1.Visible = false;
            customersForm1.Visible = false;
            warehouseEntryForm1.Visible = false;
            warehouseExitForm1.Visible = true;
            warehouseExitForm1.RefreshData();
        }
    }
}
