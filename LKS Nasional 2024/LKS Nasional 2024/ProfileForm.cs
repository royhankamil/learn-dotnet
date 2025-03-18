using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Nasional_2024
{
    public partial class ProfileForm: Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        int user_id;

        user userr;

        public ProfileForm(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;
            userr = db.users.Find(user_id);

            PhoneInput.Text = userr.phone_number;

            SetEdit(false);
            initData();
            errorTxt.Text = "";
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

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


            if (EmailInput.Text == "")
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

                if (!Decimal.TryParse(lattitudeCusstInput.Text, out _) || !Decimal.TryParse(LogitudeCustInput.Text, out _))
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

        private void button1_Click(object sender, EventArgs e)
        {
            SetEdit(!EmailInput.Enabled);
        }

        private void initData()
        {
            EmailInput.Text = userr.email;
            isCust.Checked = userr.cust_active == 1 ? true : false;
            isVend.Checked = userr.vendor_active == 1 ? true : false;

            NameCustInput.Text = userr.cust_name;
            AddressCusstInput.Text = userr.cust_address;
            lattitudeCusstInput.Text = userr.cust_latitude.ToString();
            LogitudeCustInput.Text = userr.cust_longitude.ToString();

            NameVendInput.Text = userr.vendor_name;
            AddressVendInput.Text = userr.vendor_address;
            LattitudeVendInput.Text = userr.vendor_latitude.ToString();
            LogiudeVendInput.Text = userr.vendor_longitude.ToString();

        }

        private void SetEdit(bool condition)
        {
            if (condition)
                initData();

            EmailInput.Enabled = condition;
            isCust.Enabled = condition;
            isVend.Enabled = condition;

            if (isCust.Checked)
            {
                groupBox1.Enabled = condition;
            }
            else
            {
                groupBox1.Enabled = false;
            }

            if (isVend.Checked)
            {
                groupBox2.Enabled = condition;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initData();
        }

        private void REGISTER_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                userr.email = EmailInput.Text;
                userr.cust_active = (short)(isCust.Checked ? 1 : 0);
                userr.vendor_active = (short)(isVend.Checked ? 1 : 0);

                if (isCust.Checked)
                {
                    userr.cust_name = NameCustInput.Text;
                    userr.cust_address = AddressCusstInput.Text;
                    userr.cust_latitude = double.Parse(lattitudeCusstInput.Text);
                    userr.cust_longitude = double.Parse(LogitudeCustInput.Text);
                }

                if (isVend.Checked)
                {
                    userr.vendor_name = NameVendInput.Text;
                    userr.vendor_address = AddressVendInput.Text;
                    userr.vendor_latitude = double.Parse(LattitudeVendInput.Text);
                    userr.vendor_longitude = double.Parse(LogiudeVendInput.Text);
                }

                db.SaveChanges();
            }
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
