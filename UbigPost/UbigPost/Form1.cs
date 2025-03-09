using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbigPost
{
    public partial class Login: Form
    {

        MiniKasirEntities db = new MiniKasirEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == String.Empty || passwordInput.Text == string.Empty)
                MessageBox.Show("Email and Password cannot be null", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            User user = db.Users.FirstOrDefault(u => u.Email == emailInput.Text);
            if (user != default && user.Password == passwordInput.Text)
            {
                MainMenu menu = new MainMenu(user.ID);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email or Password is wrong, please try again!", "User Cannot be Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void passwordInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            passwordInput.UseSystemPasswordChar = !showPass.Checked;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regis = new RegisterForm();
            regis.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
