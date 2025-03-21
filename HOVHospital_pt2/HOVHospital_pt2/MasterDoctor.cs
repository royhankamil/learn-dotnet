using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHospital_pt2
{
    public partial class MasterDoctor: Form
    {

        HOV_HospitalEntities db = new HOV_HospitalEntities();

        public MasterDoctor(string name="", string cat="")
        {
            InitializeComponent();
            textBox1.Text = name;
            comboBox1.Text = cat;

            foreach (var item in db.doctor_category.ToList())
            {
                comboBox1.Items.Add(item.category);
            }

            update_datagrid();
        }
        private void update_datagrid()
        {
            if (comboBox1.SelectedIndex == -1 && textBox1.Text == "")
            {
                dataGridView1.DataSource = db.doctors.ToList();
            }
            else if (comboBox1.SelectedIndex != -1 && textBox1.Text != "")
            {
                doctor_category cat = db.doctor_category.First(c => c.category == comboBox1.Text);
                dataGridView1.DataSource = db.doctors.Where(d=>
                                d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())
                                && d.doctor_category_id == cat.id).ToList();
            }
            else if (comboBox1.SelectedIndex != -1)
            {
                doctor_category cat = db.doctor_category.First(c => c.category == comboBox1.Text);
                dataGridView1.DataSource = db.doctors.Where(d =>
                                d.doctor_category_id == cat.id).ToList();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                doctor doc = db.doctors.AsEnumerable().First(d => d.id == int.Parse(row.Cells["id"].Value.ToString()));

                textBox2.Text = doc.name;
                textBox3.Text = doc.phone_number;
                textBox4.Text = doc.email;
                textBox5.Text = doc.city_of_birth;
                textBox6.Text = doc.doctor_category.category;
                textBox7.Text = doc.address;
                textBox8.Text = doc.gender;
                textBox9.Text = doc.assigned_room;

                label12.Text = $"Last Update {doc.last_updated_at}";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }
    }
}
