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
    public partial class NewMeeting: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewMeeting()
        {
            InitializeComponent();

            foreach (var item in db.doctor_category.ToList())
            {
                comboBox1.Items.Add(item.category);                
            }

            string tex = "";
            var element = db.meetings.AsEnumerable().Where(m => m.date.ToString("d") == dateTimePicker1.Value.ToString()).Select(m => m.queue_number).ToList();
            queueNumber = element.Count > 0 ? element.Max() : 0;

            for (int i = 0; i < queueNumber; i++)
            {
                tex += "X";
            }
        }

        private void NewMeeting_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new MasterPatient(textBox1.Text).ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (db.patients.Any(p => p.name == textBox1.Text))
            {

                new PatientRecord(db.patients.First(p => p.name == textBox1.Text)).ShowDialog();
            }

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new MasterDoctor(comboBox2.Text, comboBox1.Text).ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            foreach (var item in db.doctors.Where(d=>d.doctor_category.category == comboBox1.Text).ToList())
            {
                comboBox2.Items.Add(item.name);
            }
        }
        int queueNumber;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string tex = "";
            var element = db.meetings.AsEnumerable().Where(m => m.date.ToString("d") == dateTimePicker1.Value.ToString()).Select(m => m.queue_number).ToList();
            queueNumber = element.Count > 0 ? element.Max() : 0;

            for (int i = 0; i < queueNumber; i++)
            {
                tex += "X";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient pat = db.patients.FirstOrDefault(p => p.name == textBox1.Text);
            doctor doc = db.doctors.FirstOrDefault(d => d.name == comboBox2.Text);

            db.meetings.Add(new meeting
            {
                patient = pat,
                doctor = doc,
                room = doc.assigned_room,
                date = dateTimePicker1.Value,
                queue_number = queueNumber,
                created_at = DateTime.Now
            });

            db.SaveChanges();
        }
    }
}
