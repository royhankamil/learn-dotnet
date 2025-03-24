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
    public partial class NewMeetingForm: Form
    {
        int queueNum=0;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewMeetingForm()
        {
            InitializeComponent();

            foreach (var item in db.doctor_category.ToList())
            {
                comboBox1.Items.Add(item.category);
            }
            


        }



        private void NewMeetingForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new MasterPatient(textBox1.Text).ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox2.Text != "")
            {
                new MasterDoctor(comboBox2.Text, comboBox1.Text);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string qeuestr = "";
            var items = db.meetings.Where(p => p.date.ToString("d") == dateTimePicker1.Value.ToString("d")).Select(p=>p.queue_number).ToList();
            queueNum = items == null ? 0 : items.Max();

            for (int i = 0; i < queueNum; i++)
            {
                qeuestr += "X";
            }

            label7.Text = qeuestr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient pat = db.patients.First(p => p.name == textBox1.Text);
            doctor doc = db.doctors.First(p => p.name == comboBox2.Text);


            meeting newmet = new meeting()
            {
                patient = pat,
                doctor = doc,
                room = doc.assigned_room,
                date = dateTimePicker1.Value,
                queue_number = queueNum++,
                created_at = DateTime.Now
            };

            db.meetings.Add(newmet);
            db.SaveChanges();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            foreach (var item in db.doctors.Where(d=>d.doctor_category.category == comboBox1.Text))
            {
                comboBox2.Items.Add(item.name);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            patient pat = db.patients.First(p => p.name == textBox1.Text);

            new PatientRecord(pat).ShowDialog();
        }
    }
}
