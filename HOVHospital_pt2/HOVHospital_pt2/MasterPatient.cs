using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHospital_pt2
{
    public partial class MasterPatient: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();

        public MasterPatient(string name="")
        {
            InitializeComponent();

            textBox1.Text = db.patients.Find(name).name;

            update_datagrid();
        }

        private void update_datagrid()
        {
            if (textBox1.Text == "")
            {
                dataGridView1.DataSource = db.patients.ToList();
            }
            else
            {
                dataGridView1.DataSource = db.patients.Where(d =>
                                d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
            }
        }

        private void Masterpatient_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                patient doc = db.patients.AsEnumerable().First(d => d.id == int.Parse(row.Cells["id"].Value.ToString()));

                textBox2.Text = doc.name;
                textBox3.Text = doc.phone_number;
                textBox4.Text = doc.email;
                textBox5.Text = doc.city_of_birth;
                textBox7.Text = doc.address;
                textBox8.Text = doc.gender;

                label12.Text = $"Last Update {doc.last_updated_at}";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void MasterPatient_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }

}
