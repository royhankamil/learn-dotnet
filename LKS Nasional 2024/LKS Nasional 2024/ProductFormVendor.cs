using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LKS_Nasional_2024
{
    public partial class ProductForm: Form
    {
        public enum Mode { none, add, edit }

        grocerseekerEntities db = new grocerseekerEntities();

        product selectedProduct;
        Mode mode;
        int user_id;
        public ProductForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;

            foreach (var data in db.products.Where(p => p.vendor_id == user_id))
            {
                dataGridView1.Rows.Add(data.product_name,
                                    data.category.name,
                                    data.unit_type,
                                    data.price_per_unit,
                                    data.unit_stock,
                                    data.is_active == 1);

            }

            foreach (var item in db.categories.Where(c=>c.is_active == 1).Select(u=>u.name).ToList())
            {
                comboBox1.Items.Add(item);
            }


            button2.Enabled = false;
            button3.Enabled = false;
            enable_input(false);
            errorTxt.Text = "";
           
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void enable_input(bool condition)
        {
            textBox1.Enabled = condition;
            comboBox1.Enabled = condition;
            radioButton1.Enabled = condition;
            radioButton2.Enabled = condition;
            comboBox2.Enabled = condition;
            numericUpDown1.Enabled = condition;
            numericUpDown2.Enabled = condition;
            button4.Enabled = condition;
            button5.Enabled = condition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enable_input(true);
            clear_input();
            mode = Mode.add;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                mode = Mode.edit;
                enable_input(true);
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please select the data first to edit the data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                DialogResult result =  MessageBox.Show("Are you sure want to delete the selected data?", "Confirmation Deleting", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    db.products.Remove(selectedProduct);
                    db.SaveChanges();
                    mode = Mode.none;
                    selectedProduct = null;
                    refresh_datagridview();
                }
            }
            else
            {
                MessageBox.Show("Please select the data first to delete the daa");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if( checkData() )
            {
                category cat = db.categories.FirstOrDefault(c => c.name == comboBox1.Text);
                if (mode == Mode.add)
                {
                    //user userr = db.users.Find(user_id);

                    product newproduct = new product()
                    {
                        vendor_id = user_id,
                        product_name = textBox1.Text,
                        category = cat,
                        unit_type = radioButton1.Checked ? "countable" : "measurable",
                        price_per_unit = numericUpDown1.Value,
                        unit_stock = (double)numericUpDown2.Value,
                        is_active = (short)(comboBox2.SelectedIndex == 0 ? 1 : 0),
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };

                    db.products.Add(newproduct);
                }
                else if (mode == Mode.edit)
                {
                    selectedProduct.product_name = textBox1.Text;
                    selectedProduct.category = cat;
                    selectedProduct.unit_type = radioButton1.Checked ? "countable" : "measurable";
                    selectedProduct.price_per_unit = numericUpDown1.Value;
                    selectedProduct.unit_stock = (double)numericUpDown2.Value;
                    selectedProduct.is_active = (short)(comboBox2.SelectedIndex == 0 ? 1 : 0);
                    selectedProduct.updated_at = DateTime.Now;

                }

                db.SaveChanges();

                refresh_datagridview();
                clear_input();

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                enable_input(false);
                selectedProduct = null;
                mode = Mode.none;

            }
        }
        
        private bool checkData()
        {
            errorTxt.Text = "";
            if (textBox1.Text == "")
            {
                errorTxt.Text = "Product name should be fill";
                return false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                errorTxt.Text = "Category Required to choose";
                return false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                errorTxt.Text = "Status required to choose";
                return false;
            }

            if (numericUpDown2.Value <= 0)
            {
                errorTxt.Text = "Stock should higher than 0";
                return false;
            }


            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear_input();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;

            enable_input(false);
            selectedProduct = null;
            mode = Mode.none;
        }

        private void clear_input()
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && mode == Mode.none)
            {
                string productname = dataGridView1.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                selectedProduct = db.products.FirstOrDefault(p => p.product_name == productname);

                textBox1.Text = selectedProduct.product_name;
                comboBox1.Text = selectedProduct.category.name;
                if (selectedProduct.unit_type == "measurable")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton2.Checked = false;
                }

                comboBox2.Text = selectedProduct.is_active == 1 ? "active" : "inactive";
                numericUpDown1.Value = selectedProduct.price_per_unit.GetValueOrDefault();
                numericUpDown2.Value = (decimal) selectedProduct.unit_stock;

            }
        }

        private void refresh_datagridview()
        {
            dataGridView1.Rows.Clear();
            foreach (var data in db.products.Where(p => p.vendor_id == user_id))
            {
                dataGridView1.Rows.Add(data.product_name,
                                    data.category.name,
                                    data.unit_type,
                                    data.price_per_unit,
                                    data.unit_stock,
                                    data.is_active == 1);

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
