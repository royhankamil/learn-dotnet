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
    public partial class CreateAccount: Form
    {

        grocerseekerEntities db = new grocerseekerEntities();
        public CreateAccount()
        {
            InitializeComponent();

            errorTxt.Text = "";
            groupBox1.Enabled = isCust.Checked;
            groupBox2.Enabled = isVend.Checked;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void REGISTER_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {

                user newuser = new user()
                {
                    phone_number = PhoneInput.Text,
                    email = EmailInput.Text,
                    password = PassInput.Text,
                    cust_active = (short)(isCust.Checked? 1: 0),
                    vendor_active = (short)(isVend.Checked?1: 0),
                    cust_name = NameCustInput.Text,
                    cust_address = AddressCusstInput.Text,
                    cust_latitude = double.Parse(lattitudeCusstInput.Text == ""?"0": lattitudeCusstInput.Text),
                    cust_longitude = double.Parse(LogitudeCustInput.Text == ""? "0": LogitudeCustInput.Text),
                    vendor_name = NameVendInput.Text,
                    vendor_address = AddressCusstInput.Text,
                    vendor_latitude = double.Parse(LattitudeVendInput.Text == "" ? "0" : LattitudeVendInput.Text),
                    vendor_longitude = double.Parse(LogiudeVendInput.Text == "" ? "0" : LogiudeVendInput.Text),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                db.users.Add(newuser);
                db.SaveChanges();


                MessageBox.Show("Register valid and successfully");

            }
        }

        private bool CheckData()
        {
            errorTxt.Text = "";
            if (PhoneInput.Text == "")
            {
                errorTxt.Text = "Please input the phone";
                return false;
            }
            if (!PhoneInput.Text.All(char.IsDigit))
            {
                errorTxt.Text = "Please Input the phone number with digit value";
                return false;
            }

            if (PhoneInput.Text.Length < 10 && PhoneInput.Text.Length > 15)
            {
                errorTxt.Text = "Please input the phone number with 10-15 legth digit";
                return false;
            }

            user checkPhone = db.users.FirstOrDefault(u => u.phone_number == PhoneInput.Text);
            if (checkPhone != default)
            {
                errorTxt.Text = "The phone number is already registered, please input anoher phone number or login insead";
                return false;
            }

            if (PassInput.Text == "")
            {
                errorTxt.Text = "Please input the password";
                return false;
            }

            if (!PassInput.Text.Any(char.IsUpper))
            {
                errorTxt.Text = "Password should contains upper letter";
                return false;
            }

            if (!PassInput.Text.Any(char.IsLower))
            {
                errorTxt.Text = "Password should contains lower letter";
                return false;
            }

            if (!PassInput.Text.Any(char.IsNumber))
            {
                errorTxt.Text = "Password should contains number";
                return false;
            }

            if (PassInput.Text.Length < 8)
            {
                errorTxt.Text = "Password should have minimal 8 characters";
                return false;
            }

            if (ConfirmPassInput.Text == "")
            {
                errorTxt.Text = "Please input the confirm password";
                return false;
            }

            if (ConfirmPassInput.Text != PassInput.Text)
            {
                errorTxt.Text = "Must matched with given inputted password";
                return false;
            }

            if (EmailInput.Text =="")
            {
                errorTxt.Text = "Please fill the email input";
                return false;
            }


            if (!EmailInput.Text.Contains("@"))
            {
                errorTxt.Text = "Invalid email input";
                return false;
            }
            else
            {
                try
                {
                    if (!EmailInput.Text.Split('@')[1].Contains("."))
                    {
                        errorTxt.Text = "Invalid email input";
                        return false;
                    }
                }
                catch
                {
                    errorTxt.Text = "Invalid email";
                    return false;
                }
            }

            if (!isCust.Checked && !isVend.Checked)
            {
                errorTxt.Text = "fill at least 1 role";
                return false;
            }

            if (isCust.Checked)
            {
                if (NameCustInput.Text == "")
                {
                    errorTxt.Text = "Please input the name customer";
                    return false;
                }

                if (AddressCusstInput.Text == "")
                {
                    errorTxt.Text = "Please input the address customer";
                    return false;
                }

                if (lattitudeCusstInput.Text == "" || LogitudeCustInput.Text == "")
                {
                    errorTxt.Text = "Please input the langitude dan longitude customer";
                    return false;
                }

                if (!Decimal.TryParse(lattitudeCusstInput.Text, out _) || !Decimal.TryParse(lattitudeCusstInput.Text, out _))
                {
                    errorTxt.Text = "Please input with number for the langitude dan longitude customer";
                    return false;   
                }
            }

            if (isVend.Checked)
            {
                if (NameVendInput.Text == "")
                {
                    errorTxt.Text = "Please input the name Vendor";
                    return false;
                }

                if (AddressVendInput.Text == "")
                {
                    errorTxt.Text = "Please input the address vendor";
                    return false;
                }

                if (LattitudeVendInput.Text == "" || LogiudeVendInput.Text == "")
                {
                    errorTxt.Text = "Please input the langitude dan longitude Vendor";
                    return false;
                }

                if (!Decimal.TryParse(LattitudeVendInput.Text, out _) || !Decimal.TryParse(LogiudeVendInput.Text, out _))
                {
                    errorTxt.Text = "Please fill the number for latitude and longitude";
                    return false;
                }
            }

            return true;

        }

        private void isCust_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = isCust.Checked;
        }

        private void isVend_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = isVend.Checked;
        }
    }
}
