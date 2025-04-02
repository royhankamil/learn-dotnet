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
    public partial class Form1 : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text.Length < 10 || textBox1.Text.Length > 15)
            {
                ErrorHandle("Phone Number should between 10-15 digit");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                ErrorHandle("Please select the category");
                return;
            }
            user userr = db.users.FirstOrDefault(u => u.phone_number == textBox1.Text);

            if (userr == default)
            {
                ErrorHandle("Cannot found account by given phone number and");
            }
            else
            {
                if (userr.password != textBox2.Text)
                {
                    ErrorHandle("Password is wrong, please try again!");
                    return;
                }
                if (comboBox1.SelectedIndex == 0 && userr.cust_active == 0)
                {
                    ErrorHandle("Customer role is inactive, please activate to accesss this role");
                    return;
                }
                if (comboBox1.SelectedIndex == 1 && userr.vendor_active == 0)
                {
                    ErrorHandle("Vendor role is inactive, please activate to accesss this role");
                    return;
                }

                DataManager.asCust = comboBox1.SelectedIndex == 0;
                DataManager.userr = userr;
                new MainMenu().Show();
                Hide();
            }

        }

        private void ErrorHandle(string message)
        {
            label5.Text = message;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Register().Show();
            Hide();
        }
    }
}
