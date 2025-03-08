using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbigPost
{
    public partial class RegisterForm : Form
    {
        MiniKasirEntities db = new MiniKasirEntities();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void submit_Click(object sender, EventArgs e)
        {

            if (FNameInput.Text == "" || lNameInput.Text == "" || passwordInput.Text == "" || emailInput.Text == "")
            {
                MessageBox.Show("Please fill all information", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passwordInput.Text.Length < 4)
            {
                MessageBox.Show("Password Should have minimal four characters");
                return;
            }

            User userCheck = db.Users.FirstOrDefault(u => u.FirstName + u.LastName == FNameInput.Text + lNameInput.Text
                                    || u.Email == emailInput.Text);

            if (userCheck != default)
                MessageBox.Show("User Already exist by given email or Username", "User Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            User user = new User()
            {
                FirstName = FNameInput.Text,
                LastName = lNameInput.Text,
                Password = passwordInput.Text,
                Email  = emailInput.Text
            };

            db.Users.Add(user);
            db.SaveChanges();

            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
