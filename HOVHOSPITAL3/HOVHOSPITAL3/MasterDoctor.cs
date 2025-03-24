using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHOSPITAL3
{
    public partial class MasterDoctor: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public MasterDoctor(string docName="", string docCat="")
        {
            InitializeComponent();
            comboBox1.Text = docCat;
            textBox1.Text = docName;

            update_datagrid();

        }
        private void update_datagrid()
        {
            if (textBox1.Text == "" && comboBox1.SelectedIndex == -1)
            {
                dataGridView1.DataSource = db.doctors.ToList();
            }
            else if (textBox1.Text != "" && comboBox1.SelectedIndex != -1 )
            {
                dataGridView1.DataSource = db.doctors.Where(d=>
                                            d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())
                                            && d.doctor_category.category == comboBox1.Text).ToList();
            }
            else if (comboBox1.SelectedIndex != -1)
            {

                dataGridView1.DataSource = db.doctors.Where(d => d.doctor_category.category == comboBox1.Text).ToList();
            }
            else
            {

                dataGridView1.DataSource = db.doctors.Where(d =>
                                            d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
            }

        }

        private void MasterDoctor_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                doctor doc = db.doctors.First(d => d.id == id);

                textBox2.Text = doc.name;
                textBox3.Text = doc.phone_number;
                textBox4.Text = doc.email;
                textBox5.Text = doc.date_of_birth.ToString("d");
                textBox6.Text = doc.doctor_category.category;
                textBox8.Text = doc.address;
                textBox7.Text = doc.gender;
                textBox9.Text = doc.assigned_room;
                label12.Text = $"Last Update at {doc.last_updated_at}";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }
    }
}
