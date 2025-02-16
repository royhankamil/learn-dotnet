using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodXYZ
{
    public partial class Form1 : Form
    {
        FoodXYZEntities db = new FoodXYZEntities();
        
        public Form1()
        {
            InitializeComponent();

            ErrorText.Text = "";
        }

        private void LoginForm_Click(object sender, EventArgs e)
        {
            ErrorText.Text = "";

            tbl_user user = db.tbl_user.FirstOrDefault(u => u.username.TrimEnd() == UsernameInput.Text);

            if (user != default && user.password.TrimEnd() == PasswordInput.Text)
            {

            }
            else
            {
                MessageBox.Show("username atau password yang anda masukkan tidak sesuai !", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorText.Text = "username atau password yang anda masukkan tidak sesuai !";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UsernameInput_TextChanged(object sender, EventArgs e)
        {
            //UsernameInput.Text = (UsernameInput.Text == "") ? "User Name": "";
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {

            //PasswordInput.Text = (PasswordInput.Text == "") ? "Password": "";
            //PasswordInput.UseSystemPasswordChar = (PasswordInput.Text != "");
        }
    }
}
