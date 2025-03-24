using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hov_hospital_2
{
    public partial class MasterPatient: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public MasterPatient(string nameOf="")
        {
            InitializeComponent();
            textBox1.Text = nameOf;

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
                    d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())
                    ).ToList();
            }

        }

        private void Masterpatient_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                patient pat = db.patients.Find(int.Parse(id));

                textBox1.Text = pat.name;
                textBox2.Text = pat.phone_number;
                textBox3.Text = pat.email;
                textBox4.Text = pat.date_of_birth.ToString();
                textBox9.Text = pat.address;
                textBox8.Text = pat.gender;
                textBox7.Text = pat.blood_type;

                label12.Text = $"Last Updated at {pat.last_updated_at}";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MasterPatient_Load_1(object sender, EventArgs e)
        {

        }
    }
}
