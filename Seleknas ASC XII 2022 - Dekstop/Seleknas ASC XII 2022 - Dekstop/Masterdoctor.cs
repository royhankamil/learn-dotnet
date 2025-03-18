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

namespace Seleknas_ASC_XII_2022___Dekstop
{
    public partial class Masterdoctor: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public Masterdoctor(string categoryParams = "", string namParams = "")
        {
            InitializeComponent();

            foreach (var data in db.doctor_category.Select(c => c.category).ToList())
            {
                comboBox1.Items.Add(data);
            }

            if (namParams != "")
            {
                NameInput.Text = namParams;
            }

            if (categoryParams != "")
            {
                comboBox1.Text = categoryParams;
            }

            update_datagrid();
        }

        private void update_datagrid()
        {
            if (comboBox1.SelectedIndex == -1 && SearchInput.Text == "")
            {
                dataGridView1.DataSource = db.doctors.ToList();
            }
            else if (comboBox1.SelectedIndex != -1 && SearchInput.Text != "")
            {
                dataGridView1.DataSource = db.doctors.Where(d => d.name.ToLower().TrimEnd().Contains(SearchInput.Text.ToLower().Trim())
                    && d.doctor_category.category == comboBox1.Text).ToList();
            }
            else if (SearchInput.Text != "")
            {
                dataGridView1.DataSource = db.doctors.Where(d => d.name.ToLower().TrimEnd().Contains(SearchInput.Text.ToLower().Trim()))
                    .ToList();
            }
            else
            {
                dataGridView1.DataSource = db.doctors.Where(d => d.doctor_category.category == comboBox1.Text)
                    .ToList();
            }
        }

        private void Masterdoctor_Load(object sender, EventArgs e)
        {

        }

        private void NameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                doctor selectedDoctor = db.doctors.Find(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString()));

                NameInput.Text = selectedDoctor.name;
                textBox1.Text = selectedDoctor.phone_number;
                textBox2.Text = selectedDoctor.email;
                textBox3.Text = selectedDoctor.city_of_birth;
                textBox4.Text = selectedDoctor.doctor_category.category;
                textBox5.Text = selectedDoctor.address;
                textBox6.Text = selectedDoctor.gender;
                textBox7.Text = selectedDoctor.assigned_room;

                Lastupdate.Text = $"Last Update at {selectedDoctor.last_updated_at?.ToString("d")}";

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void SearchInput_TextChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }
    }
}
