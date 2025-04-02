using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocceerseeker3
{
    public partial class ProductForm : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        double distance;
        int delCost;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            label18.Text = "";
            productBindingSource.DataSource = db.products.Where(p => p.is_active == 1 && p.user.vendor_active == 1 
                                                && p.unit_stock > 0 && p.vendor_id != DataManager.userr.id).ToList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is product p)
            {
                if (e.ColumnIndex == vendoridDataGridViewTextBoxColumn.Index)
                    e.Value = p.user.vendor_name;

                if (e.ColumnIndex == categoryidDataGridViewTextBoxColumn.Index)
                    e.Value = p.category.name;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (productBindingSource.Current is product p)
            {
                textBox6.Text = p.product_name;
                comboBox1.Text = p.category.name;
                radioButton1.Checked = p.unit_type == "countable";
                radioButton2.Checked = p.unit_type != "countable";
                numericUpDown1.Value = (decimal)p.price_per_unit;
                numericUpDown2.Value = (decimal)p.unit_stock;

                label5.Text = p.price_per_unit.ToString();

                float dlat = (float)(DataManager.userr.cust_latitude - p.user.vendor_latitude) / 2;
                float dlong = (float)(DataManager.userr.cust_longitude - p.user.vendor_longitude) / 2;

                double a = Math.Pow(Math.Sin(dlat), 2) + Math.Cos(DataManager.userr.cust_latitude.GetValueOrDefault()) * Math.Cos(p.user.vendor_latitude.GetValueOrDefault()) * Math.Pow(Math.Sin(dlong), 2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                distance = 6371 * c;
                delCost = ((int)distance / 100) *15000;
                label10.Text = delCost.ToString();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (productBindingSource.Current is product p)
            {
                label5.Text = (p.price_per_unit.GetValueOrDefault() * numericUpDown4.Value).ToString();
                label10.Text = (p.price_per_unit.GetValueOrDefault() * numericUpDown4.Value).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

            label5.Text = "0";
            label10.Text = "0";
            numericUpDown4.Value = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            if (db.transactions.Where(u => u.customer_id == DataManager.userr.id).ToList().Count >=10)
            {
                label18.Text = "Cannot save data with more than 10 pending transaction";
                return;
            }

            if (productBindingSource.Current is product p)
            {
                if ((decimal)p.unit_stock < numericUpDown4.Value)
                {
                    label18.Text = "Stock is not enough";
                    return;
                }

                decimal total = p.price_per_unit.GetValueOrDefault() * numericUpDown4.Value;
                product prod = p;
                transaction tr = new transaction()
                {
                    vendor_id = p.user.id,
                    customer_id = DataManager.userr.id,
                    product = p,
                    quantity = (double)numericUpDown4.Value,
                    total_price = total,
                    delivery_cost = delCost,
                    status = "pending",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                prod.unit_stock -= (double)numericUpDown4.Value;
                db.transactions.Add(tr);
                db.SaveChanges();
            }
        }
    }
}
