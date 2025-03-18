using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seleknas_ASC_XII_2022___Dekstop
{
    public partial class MasterPatient: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public MasterPatient(int patient_id=-1)
        {
            InitializeComponent();

            update_datagrid();

            if (patient_id != -1)
            {
                patient selectedPatient = db.patients.Find(patient_id);

                NameInput.Text = selectedPatient.name;
                textBox1.Text = selectedPatient.phone_number;
                textBox2.Text = selectedPatient.email;
                textBox3.Text = selectedPatient.city_of_birth;
                //textBox4.Text = selectedPatient.doctor_category.category;
                textBox5.Text = selectedPatient.address;
                textBox6.Text = selectedPatient.gender;
                textBox7.Text = selectedPatient.blood_type;

                Lastupdate.Text = $"Last Update at {selectedPatient.last_updated_at?.ToString("d")}";
            }
        }

        private void update_datagrid()
        {
            if (SearchInput.Text == "")
            {
                dataGridView1.DataSource = db.patients.ToList();
            }
            else
            {
                dataGridView1.DataSource = db.patients.Where(d => d.name.ToLower().TrimEnd().Contains(SearchInput.Text.ToLower().Trim()))
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
                patient selectedPatient = db.patients.Find(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString()));

                NameInput.Text = selectedPatient.name;
                textBox1.Text = selectedPatient.phone_number;
                textBox2.Text = selectedPatient.email;
                textBox3.Text = selectedPatient.city_of_birth;
                //textBox4.Text = selectedPatient.doctor_category.category;
                textBox5.Text = selectedPatient.address;
                textBox6.Text = selectedPatient.gender;
                textBox7.Text = selectedPatient.blood_type;

                Lastupdate.Text = $"Last Update at {selectedPatient.last_updated_at?.ToString("d")}";

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
