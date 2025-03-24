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
    public partial class MasterDoctor: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public MasterDoctor(string nameof="", string cat="")
        {
            InitializeComponent();

            comboBox1.Text = cat;
            textBox1.Text = nameof;

            foreach (var item in db.doctor_category.ToList())
            {
                comboBox1.Items.Add(item.category);
            }

            //if ()

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
                dataGridView1.DataSource = db.doctors.Where( d =>
                    d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())
                    && d.doctor_category.category == comboBox1.Text
                    ).ToList();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = db.doctors.Where(d =>
                    d.doctor_category.category == comboBox1.Text
                    ).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.doctors.Where(d =>
                    d.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())
                    ).ToList();
            }
            
        }

        private void MasterDoctor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                doctor doc = db.doctors.Find(int.Parse(id));
                
                textBox1.Text = doc.name;
                textBox2.Text = doc.phone_number;
                textBox3.Text = doc.email;
                textBox4.Text = doc.date_of_birth.ToString();
                textBox5.Text = doc.doctor_category.category;
                textBox9.Text = doc.address;
                textBox8.Text = doc.gender;
                textBox7.Text = doc.assigned_room;

                label12.Text = $"Last Updated at {doc.last_updated_at}";
            }
        }
    }
}
