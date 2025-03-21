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
    public partial class FormMeeting: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public FormMeeting()
        {
            InitializeComponent();

            foreach (var item in db.doctor_category.ToList())
            {
                comboBox1.Items.Add(item.category);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FormMeeting_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (var doc in db.doctors.Where(d => d.doctor_category.category == comboBox1.Text).ToList())
            {
                comboBox2.Items.Add(doc.name);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                MasterPatient pat = new MasterPatient(textBox1.Text);
                pat.ShowDialog();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                MasterDoctor doc = new MasterDoctor(comboBox2.Text, comboBox1.Text);
                doc.ShowDialog();
            }
        }
        int max;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string queueNum = "";
            max = db.meetings.Where(m=>m.date.ToString("d") == dateTimePicker1.Value.ToString("d")).Select(m=>m.queue_number).ToList().Max();
            for (int i =0; i < max;i++)
            {
                queueNum += "X";
            }
            label7.Text = queueNum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient pat = db.patients.FirstOrDefault(u => u.name == textBox1.Text);
            doctor doc = db.doctors.FirstOrDefault(u => u.name == comboBox2.Text);
            meeting newmet = new meeting()
            {
                patient = pat,
                doctor = doc,
                room = doc.assigned_room,
                date = DateTime.Now,
                queue_number = max+1,
                created_at = DateTime.Now
            };

            db.meetings.Add(newmet);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            patient pat = db.patients.First(p => p.name == textBox1.Text);
            viewPatientRecord patre = new viewPatientRecord(pat.id);
            patre.ShowDialog();
        }
    }
}
