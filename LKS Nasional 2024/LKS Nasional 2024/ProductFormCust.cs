using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Nasional_2024
{
    public partial class ProductFormCust: Form
    {
        product selectedProduct;
        grocerseekerEntities db = new grocerseekerEntities();
        int user_id;
        decimal total_transaction, delivery_cost;
        user userr;
        public ProductFormCust(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;
            userr = db.users.Find(user_id);
            errorTxt.Text = "";

            label11.Text = "0";
            label12.Text = "0";

            var data = db.products.Where(p =>
                        p.user.vendor_active == 1 &&
                        p.is_active == 1 &&
                        p.unit_stock >= 0 &&
                        p.vendor_id != user_id).ToList();

            foreach (var dt in data)
            {
                dataGridView1.Rows.Add(dt.user.vendor_name, dt.product_name, dt.category.name,
                                        dt.unit_type, dt.price_per_unit,
                                        dt.unit_stock);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CountData();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ProductFormCust_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private bool IsValidData()
        {
            if (selectedProduct == null)
            {
                errorTxt.Text = "You must select the item to buy first to continue";
                return false;
            }

            if  (numericUpDown4.Value > (decimal)selectedProduct.unit_stock.GetValueOrDefault())
            {
                errorTxt.Text = "Cannot calculate total when quantity higher than stock ";
                return false;
            }


            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedProduct = db.products.AsEnumerable().FirstOrDefault(p => p.product_name == row.Cells["product_name"].Value.ToString()
                                            && p.user.vendor_name == row.Cells["vendor_name"].Value.ToString());

                textBox1.Text = selectedProduct.product_name;
                comboBox1.Text = selectedProduct.category.name;
                if (selectedProduct.unit_type == "countable")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = false;
                }
                numericUpDown1.Value = selectedProduct.price_per_unit.GetValueOrDefault();
                numericUpDown2.Value = (decimal)selectedProduct.unit_stock;
                numericUpDown4.Value = 1;

                CountData();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (db.transactions.Where(t=>t.customer_id == userr.id && t.status == "pending").ToList().Count()>=10)
                {
                    MessageBox.Show("can only have 10 pending transactions");
                    return;
                }

                user vend = db.users.Find(selectedProduct.vendor_id);
                user cust = db.users.Find(user_id);
                product prod = db.products.Find(selectedProduct.id);

                transaction tr = new transaction()
                {
                    user = vend,
                    user1 = cust,
                    product = prod,
                    quantity = (int)numericUpDown4.Value,
                    total_price = total_transaction,
                    delivery_cost = delivery_cost,
                    status = "pending" ,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                prod.unit_stock -= (int)numericUpDown4.Value;

                db.transactions.Add(tr);
                db.SaveChanges();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown4.Value = 1;
            label11.Text = "0";
            label12.Text = "0";

        }

        private void CountData()
        {
            total_transaction = numericUpDown4.Value * selectedProduct.price_per_unit.GetValueOrDefault();
            label11.Text = total_transaction.ToString();

            float a = (float)(Math.Exp(Math.Sin((Math.PI /180)*(userr.cust_latitude.GetValueOrDefault() - selectedProduct.user.vendor_latitude.GetValueOrDefault()))) +
                        + Math.Cos(userr.cust_latitude.GetValueOrDefault()) + Math.Cos(selectedProduct.user.vendor_latitude.GetValueOrDefault()) +
                        Math.Exp(Math.Sin((Math.PI / 180) * (userr.cust_longitude.GetValueOrDefault() - selectedProduct.user.vendor_latitude.GetValueOrDefault()))));
            float c = (float)(2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));

            // R = 6371 => earth's radius
            float d = 6371 * c;

            delivery_cost = 15000 * ((int)d / 100);
            label12.Text = delivery_cost.ToString();
        }
    }
}
