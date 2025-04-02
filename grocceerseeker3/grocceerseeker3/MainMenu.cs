using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocceerseeker3
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (DataManager.asCust)
            {
                label4.Text = DataManager.userr.cust_name;
                label3.Text = "Customer";
            }
            else
            {
                label4.Text = DataManager.userr.vendor_name;
                label3.Text = "Vendor";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProfileForm().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataManager.asCust )
            {
                new ProductForm().Show();
                Hide();
            }
            else
            {
                new ProductFormVendor().Show();
                Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataManager.asCust)
            {
                new TransactionCust().Show();
                Hide();
            }
            else
            {
                new TransactionVend().Show();
                Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Hide();
        }
    }
}
