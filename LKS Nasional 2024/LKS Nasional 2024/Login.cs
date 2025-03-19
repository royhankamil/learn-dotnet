using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Nasional_2024
{
    public partial class Login: Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public Login()
        {
            InitializeComponent();

            errorTxt.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user userr = checkData();

            if (userr != null && userr.password == PassInput.Text)
            {
                MainForm main = new MainForm(userr.id, LoginAsCB.Text == "customer");
                main.Show();
                this.Hide();
            }
            else
            {
                errorTxt.Text = "Phone number or password is wrong, try again later!";
            }
        }
        
        private user checkData()
        {
            errorTxt.Text = "";
            if (!PhoneInput.Text.All(char.IsDigit))
            {
                errorTxt.Text = "Sorry we could not find you credential";
                return null;
            }

            if (PhoneInput.Text.Length < 10 || PhoneInput.Text.Length > 15)
            {
                errorTxt.Text = "Please input the phone number with 10-15 legth digit";
                return null; 
            }

            user userr = db.users.FirstOrDefault(u=> u.phone_number == PhoneInput.Text);

            if (userr == default)
            {
                errorTxt.Text = "Cannot found user with given phone number";
                return null;
            }

            if (LoginAsCB.Text == "customer" && userr.cust_active == 0)
            {
                errorTxt.Text = "the role is inactive by given user";
                return null;
            }

            if (LoginAsCB.Text == "vendor" && userr.vendor_active == 0)
            {
                errorTxt.Text = "the role is inactive by given user";
                return null;
            }

            if (LoginAsCB.SelectedIndex == -1)
            {
                errorTxt.Text = "Please input te as role to login";
                return null;
            }

            return userr;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount regisPage = new CreateAccount();
            regisPage.Show();
            this.Hide();
        }
    }
}
