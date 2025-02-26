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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            nameErrorTxt.Text = "";
            emailErrorTxt.Text = "";
            PNumErrorTxt.Text = "";
            passwordErrorTxt.Text = "";
            confirmPassErrorTxt.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            using (FoodcourtEntities db = new FoodcourtEntities())
            {
                if (fNameInput.Text == "" || lNameInput.Text == "")
                    nameErrorTxt.Text = "please fill with your first name and last name!";

                if (emailInput.Text == "")
                    emailErrorTxt.Text = "please fill with your email!";

                if (pNumberInput.Text == "")
                    PNumErrorTxt.Text = "please fill with your phone number!";

                if (passwordInput.Text == "")
                    passwordErrorTxt.Text = "please fill with your password!";

                if (confirmPassInput.Text == "")
                    confirmPassErrorTxt.Text = "please fill with your confirm password!";

                if (confirmPassInput.Text != passwordInput.Text)
                {
                    confirmPassErrorTxt.Text = "Confirm Password is different with password";
                }

                if (pNumberInput.Text.Length < 10 || pNumberInput.Text.Length > 15 || !pNumberInput.Text.All(char.IsDigit))
                    PNumErrorTxt.Text = "Phone number should be a digit (between 10 15 digits)";

                if (passwordInput.Text.Length < 8)
                    passwordErrorTxt.Text = "Password length must be at least 8 characters";

                if (emailInput.Text.Contains("@") && emailInput.Text.Contains("."))
                {
                    if (nameErrorTxt.Text != "" && emailErrorTxt.Text != "" && PNumErrorTxt.Text != ""
                    && passwordErrorTxt.Text != "" && confirmPassErrorTxt.Text != "")
                    {
                        Users user = new Users();
                        user.FirstName = fNameInput.Text;
                        user.LastName = lNameInput.Text;
                        user.Email = emailInput.Text;
                        user.PhoneNumber = pNumberInput.Text;
                        user.Password = passwordInput.Text;
                        user.RoleID = 2;
                        user.DateJoined = DateTime.Now;

                        if (db.Users.FirstOrDefault(u=>u.Email == user.Email) == null)
                        {
                            // data aman
                            Console.WriteLine("data aman");
                            db.Users.Add(user);
                            db.SaveChanges();

                            memberMainForm admin = new memberMainForm(db.Users.FirstOrDefault(u=>u.Email == user.Email).ID);
                            admin.Show();
                            this.Hide();
                        }
                        else
                        {
                            emailErrorTxt.Text = "This Email has registered before";
                        }
                    }    
                }
                else
                {
                    emailErrorTxt.Text = "Please input email correctly!";
                }

            }
        }

        private void fNameInput_TextChanged(object sender, EventArgs e)
        {
            if (fNameInput.Text != "" && lNameInput.Text != "")
                nameErrorTxt.Text = "";
        }

        private void lNameInput_TextChanged(object sender, EventArgs e)
        {
            if (fNameInput.Text != "" && lNameInput.Text != "")
                nameErrorTxt.Text = "";
        }

        private void emailInput_TextChanged(object sender, EventArgs e)
        {
            if (emailInput.Text != "")
                emailErrorTxt.Text = "";
        }

        private void pNumberInput_TextChanged(object sender, EventArgs e)
        {
            if (pNumberInput.Text != "")
                PNumErrorTxt.Text = "";
        }


        private void passwordInput_TextChanged(object sender, EventArgs e)
        {
            if (passwordInput.Text != "")
                passwordErrorTxt.Text = "";
        }

        private void confirmPassInput_TextChanged(object sender, EventArgs e)
        {
            if (confirmPassInput.Text != "")
                confirmPassErrorTxt.Text = "";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
