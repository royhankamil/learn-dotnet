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
    public partial class MasterPatient: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public MasterPatient(string patName="")
        {
            InitializeComponent();

            textBox1.Text = patName;
            update_datagrid();

        }
        private void update_datagrid()
        {
            if (textBox1.Text == "" )
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                patient doc = db.patients.First(d => d.id == id);

                textBox2.Text = doc.name;

                textBox4.Text = doc.email;
                textBox5.Text = doc.date_of_birth.ToString("d");
                textBox6.Text = doc.phone_number.ToString();
                textBox8.Text = doc.address;
                textBox7.Text = doc.gender;
                textBox3.Text = doc.blood_type;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
