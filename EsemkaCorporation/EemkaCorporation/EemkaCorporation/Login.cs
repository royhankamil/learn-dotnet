using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EemkaCorporation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            Email_input.Text = "ahopewell0@people.com.cn";
            Password_input.Text = "vakWN5f3cajz";
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            using (EsemkaCorporationEntities esemka = new EsemkaCorporationEntities())
            {
                if (Email_input.Text != "" && Password_input.Text != "")
                {
                    employee employer = esemka.employee.FirstOrDefault(user => user.email == Email_input.Text); 
                    if (employer != null)
                    {
                        if (Password_input.Text == employer.password)
                        {
                            Console.WriteLine("Login Successfully");
                            error_text.Text = "";
                            MainForm mainForm = new MainForm(employer.id);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            error_text.Text = "Wrong password, please try again!";
                        }
                    }
                    else
                    {
                        error_text.Text = "Cannot found user with given email";
                    }
                }
                else
                {
                    error_text.Text = "Please fill the email and password!";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            error_text.Text = "";

        }

        private void error_text_Click(object sender, EventArgs e)
        {

        }
    }
}
