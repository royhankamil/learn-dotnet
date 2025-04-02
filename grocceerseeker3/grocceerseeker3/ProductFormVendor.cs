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
    public partial class ProductFormVendor : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public ProductFormVendor()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            productBindingSource.Clear();
            productBindingSource.AddNew();
            label18.Text = "";
            productBindingSource.DataSource = db.products.Where(p => p.vendor_id == DataManager.userr.id).ToList();

            categoryBindingSource.DataSource = db.categories.Where(c=>c.is_active == 1).ToList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is product p)
            {
                if (e.ColumnIndex == StatusCol.Index)
                    e.Value = p.is_active == 1;

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

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void EnableInput(bool condition)
        {
            textBox6.Enabled = condition;
            comboBox1.Enabled = condition;
            comboBox2.Enabled = condition;
            radioButton1.Enabled = condition;
            radioButton2.Enabled = condition;
            numericUpDown1.Enabled = condition;
            numericUpDown2.Enabled = condition;
            groupBox2.Enabled = condition;

            button1.Enabled = !condition;
            button2.Enabled = !condition;
            button5.Enabled = !condition;
        }

        private void ResetInput()
        {
            textBox6.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            numericUpDown1.Value = 0;   
            numericUpDown2.Value = 0;  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableInput(true);
            button1.Enabled = true;
            ResetInput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (productBindingSource.Current is product p)
            {
                EnableInput(true);
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {

                if (button1.Enabled)
                {
                    product newProduct = new product()
                    {
                        vendor_id = DataManager.userr.id,
                        product_name = textBox6.Text,
                        category_id = (int)comboBox1.SelectedValue,
                        unit_type = radioButton1.Checked ? "countable" : "measurable",
                        price_per_unit = numericUpDown1.Value,
                        unit_stock = (double)numericUpDown2.Value,
                        is_active = (short)comboBox2.SelectedIndex,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    db.products.Add(newProduct);    
                    db.SaveChanges();
                }
                if (button2.Enabled)
                {
                    if (productBindingSource.Current is product p)
                    {

                        p.product_name = textBox6.Text;
                        p.category_id = (int)comboBox1.SelectedValue;
                        p.unit_type = radioButton1.Checked ? "countable" : "measurable";
                        p.price_per_unit = numericUpDown1.Value;
                        p.unit_stock = (double)numericUpDown2.Value;
                        p.is_active = (short)comboBox2.SelectedIndex;
                        p.updated_at = DateTime.Now;

                        db.SaveChanges();
                    }
                }

                ProductForm_Load(sender, e);
                ResetInput();
                EnableInput(false);
            }
        }
        private bool checkdata()
        {
            if (textBox6.Text == "")
            {
                label18.Text = "Product Name fields are required";
                return false;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                label18.Text = "Category fields are required";
                return false;
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                label18.Text = "Unit Type fields are required";
                return false;
            }
            if (numericUpDown2.Value == 0 || numericUpDown1.Value == 0)
            {
                label18.Text = "Price should be more than 0 and stock should be more than 0";
                return false;
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductForm_Load(sender, e);
            ResetInput();
            EnableInput(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (productBindingSource.Current is product p)
            {
                if (MessageBox.Show("Are You sure want to delete this data?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.products.Remove(p);
                    db.SaveChanges();

                    ProductForm_Load(sender, e);
                    ResetInput();
                    EnableInput(false);
                }
            }

        }
    }
}
