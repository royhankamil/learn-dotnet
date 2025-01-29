using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;

namespace FoodCourt
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            errorText.Text = "";

            DummyLogin("lschwant0@europa.eu", "uM1%g)Aq0");
        }

        private void DummyLogin(string email, string password)
        {
            emailInput.Text = email;
            PasswordInput.Text = password;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (emailInput.Text != "" && PasswordInput.Text != "")
            {
                using (FoodcourtEntities db = new FoodcourtEntities())
                {
                    Users user = db.Users.FirstOrDefault(u => u.Email == emailInput.Text);

                    //emailInput.BackColor = Color.White;
                    //PasswordInput.BackColor = Color.White;

                    if (user != null)
                    {
                        if (PasswordInput.Text == user.Password)
                        {
                            //berhasil
                            Console.WriteLine("Berhasil Login");
                            errorText.Text = "";
                            MainForm mainForm = new MainForm(user.ID);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            //PasswordInput.BackColor = Color.LightGray;
                            errorText.Text = "Wrong password, please try again!";
                        }
                    }
                    else
                    {
                        //emailInput.BackColor = Color.LightGray;
                        errorText.Text = "Cannot find user with given email";
                    }
                }
            }
            else
            {
                //if (emailInput.Text == null)
                //{
                //    emailInput.BackColor = Color.LightGray;
                //}
                //if (PasswordInput.Text == null)
                //{
                //    PasswordInput.BackColor = Color.LightGray;
                //}
                errorText.Text = "Please fill Email anad Password to Login!";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
