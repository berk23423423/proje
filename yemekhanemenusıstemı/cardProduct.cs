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
    public partial class cardProduct : UserControl
    {
        public cardProduct()
        {
            InitializeComponent();
        }

        public int id { set; get; }
        public string productId { set; get; }
        public string productName
        {

            get
            { return productname.Text; }
            set
            { productname.Text = value; }
        }
        public string productStock
        {
            get { return stock.Text; }
            set { stock.Text = value; }
        }

        public string productPrice

        {
            get
            { return price.Text; }

            set { price.Text = value; }

        }
        public Image productImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value;
            }
        }
        public String productQuantity
        {
            get
            {
                return qunatity.Text;
            }

            set
            {
                 qunatity.Text = value;
            }
        }

       

        public string category { set; get; }

        public event EventHandler selectCard = null;

        private void add_btn_Click(object sender, EventArgs e)
        {
            selectCard?.Invoke(this, EventArgs.Empty);
        }

        private void qunatity_TextChanged(object sender, EventArgs e)
        {
            // Quantity TextBox değiştiğinde property güncelleniyor
            // Property zaten qunatity.Text'i okuyor, burada ekstra bir şey yapmaya gerek yok
        }
    }
}
