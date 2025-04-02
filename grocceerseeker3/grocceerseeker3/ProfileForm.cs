using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocceerseeker3
{
    public partial class ProfileForm : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            label18.Text = "";

            user userr = DataManager.userr;
            textBox1.Text = userr.phone_number;
            textBox2.Text = userr.email;

            checkBox1.Checked = userr.cust_active == 1;
            checkBox2.Checked = userr.vendor_active == 1;

            groupBox1.Enabled = checkBox1.Checked;
            groupBox2.Enabled = checkBox2.Checked;

            textBox6.Text = userr.cust_name;
            textBox7.Text = userr.cust_address;
            textBox8.Text = userr.cust_latitude.ToString();
            textBox9.Text = userr.cust_longitude.ToString();

            textBox13.Text = userr.vendor_name;
            textBox12.Text = userr.vendor_address;
            textBox11.Text = userr.vendor_latitude.ToString();
            textBox10.Text = userr.vendor_longitude.ToString();
        }

        private bool checkdata()
        {
            label18.Text = "";
            if (textBox1.Text == "")
            {
                label18.Text = "phone number fields are required";
                return false;
            }
            if (textBox2.Text == "")
            {
                label18.Text = "email fields are required";
                return false;
            }

            if (textBox1.Text.Length < 10 || textBox1.Text.Length > 15)
            {
                label18.Text = "Phone Number required 10-15 digit";
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

                if (!double.TryParse(textBox8.Text, out _))
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
            if (!checkBox1.Checked)
            {
                checkBox1.Checked = MessageBox.Show("Are You Sure want to deactive this role? it will be effect active product", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes;
            }
            groupBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                checkBox2.Checked = MessageBox.Show("Are You Sure want to deactive this role? it will be effect active product", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes;
            }
            groupBox2.Enabled = checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                user userr = DataManager.userr;
                if (userr.cust_active == 1 && !checkBox1.Checked)
                {
                    foreach (transaction item in db.transactions.Where(u=>u.customer_id == userr.id && u.status == "pending").ToList())
                    {
                        item.status = "abort";
                    }

                }

                if (userr.vendor_active == 1 && !checkBox2.Checked)
                {
                    foreach (transaction item in db.transactions.Where(u => u.vendor_id == userr.id && u.status == "pending").ToList())
                    {
                        item.status = "abort";
                    }

                    foreach (var item in db.products.Where(p=>p.vendor_id == userr.id).ToList())
                    {
                        item.is_active = 0;
                    }
                }
                userr.phone_number = textBox1.Text;
                userr.email = textBox2.Text;
                userr.cust_active = checkBox1.Checked ? (short)1 : (short)0;
                userr.vendor_active = checkBox2.Checked ? (short)1 : (short)0;
                userr.cust_name = textBox6.Text;
                userr.cust_address = textBox7.Text;
                userr.cust_latitude = double.Parse(textBox8.Text== ""?"0": textBox8.Text);
                userr.cust_longitude = double.Parse(textBox9.Text==""?"0":textBox9.Text);
                userr.vendor_name = textBox13.Text;
                userr.vendor_address = textBox12.Text;
                userr.vendor_latitude = double.Parse(textBox11.Text==""?"0":textBox11.Text);
                userr.vendor_longitude = double.Parse(textBox10.Text==""?"0":textBox10.Text);
                userr.updated_at = DateTime.Now;

                db.SaveChanges();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register_Load(sender, e);
        }
    }
}
