using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocceerseeker3
{
    public partial class Register : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            label18.Text = "";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private bool checkdata()
        {
            label18.Text = "";
            if (textBox1.Text == "")
            {
                label18.Text = "phone number fields are required";
                return false;
            }
            if (db.users.Any(u=>u.phone_number == textBox1.Text))
            {
                label18.Text = "account with this account already exist";
                return false;
            }

            if (textBox2.Text == "")
            {
                label18.Text = "email fields are required";
                return false;
            }
            if (textBox4.Text == "")
            {
                label18.Text = "password fields are required";
                return false;
            }

            if (textBox5.Text == "")
            {
                label18.Text = "confirm password fields are required";
                return false;
            }

            if (textBox1.Text.Length < 10 || textBox1.Text.Length > 15)
            {
                label18.Text = "Phone Number required 10-15 digit";
                return false;
            }

            if (!(textBox4.Text.Any(char.IsLower) && textBox4.Text.Any(char.IsUpper) && textBox4.Text.Any(char.IsDigit) && textBox4.Text.Length > 8) )
            {
                label18.Text = "Password Must be a combination of uppercase, lowercase characters , and numbers with length minimum 8 characters.";
                return false;
            }
            if (textBox4.Text != textBox5.Text)
            {
                label18.Text = "Password and confirm password are not same";
                return false;
            }

            if (!textBox2.Text.Contains('@'))
            {
                label18.Text = "Email are invalid";
                return false;
            }

            if (!textBox2.Text.Split('@')[1].Contains("."))
            {
                label18.Text = "Email are invalid";
                return false;
            }

            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                label18.Text = "Please Select at least one role";
                return false;
            }

            if (checkBox1.Checked)
            {
                if (textBox6.Text == "")
                {
                    label18.Text = "Name Customer fields are required";
                    return false;
                }
                if (textBox7.Text == "")
                {
                    label18.Text = "Address Customer fields are required";
                    return false;
                }

                if (textBox8.Text == "")
                {
                    label18.Text = "Latitude Customer fields are required";
                    return false;
                }

                if (textBox9.Text == "")
                {
                    label18.Text = "Longitude Customer fields are required";
                    return false;
                }

                if (!double.TryParse( textBox8.Text, out _))
                {
                    label18.Text = "Latitude Customer should be decimal";
                    return false;
                }

                if (!double.TryParse(textBox8.Text, out _))
                {
                    label18.Text = "Longitude Customer should be decimal";
                    return false;
                }
            }

            if (checkBox2.Checked)
            {
                if (textBox13.Text == "")
                {
                    label18.Text = "Name Vendor fields are required";
                    return false;
                }
                if (textBox12.Text == "")
                {
                    label18.Text = "Address Vendor fields are required";
                    return false;
                }

                if (textBox11.Text == "")
                {
                    label18.Text = "Latitude Vendor fields are required";
                    return false;
                }

                if (textBox10.Text == "")
                {
                    label18.Text = "Longitude Vendor fields are required";
                    return false;
                }

                if (!double.TryParse(textBox11.Text, out _))
                {
                    label18.Text = "Latitude Vendor should be decimal";
                    return false;
                }

                if (!double.TryParse(textBox10.Text, out _))
                {
                    label18.Text = "Longitude Vendor should be decimal";
                    return false;
                }
            }
            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                user newuserr = new user()
                {
                    phone_number = textBox1.Text,
                    email = textBox2.Text,
                    password = textBox4.Text,
                    cust_active = checkBox1.Checked ? (short)1 : (short)0,
                    vendor_active = checkBox2.Checked ? (short)1 : (short)0,
                    cust_name = textBox6.Text,
                    cust_address = textBox7.Text,
                    cust_latitude = string.IsNullOrWhiteSpace(textBox8.Text) ? 0:double.Parse(textBox8.Text),
                    cust_longitude = string.IsNullOrWhiteSpace(textBox9.Text)?0:double.Parse(textBox9.Text),
                    vendor_name = textBox13.Text,
                    vendor_address = textBox12.Text,
                    vendor_latitude = string.IsNullOrWhiteSpace(textBox11.Text)?0:double.Parse(textBox11.Text),
                    vendor_longitude = string.IsNullOrWhiteSpace(textBox10.Text) ? 0 : double.Parse(textBox10.Text),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                db.users.Add(newuserr);
                db.SaveChanges();

                new Form1().Show();
                Hide();
            }
        }
    }
}
