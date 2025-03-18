using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public enum Mode { add, edit, delete }

        grocerseekerEntities db = new grocerseekerEntities();
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
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enable_input(true);
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enable_input(true);
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if( checkData() )
            {

            }
        }
        
        private bool checkData()
        {
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
            enable_input(false);    
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
    }
}
