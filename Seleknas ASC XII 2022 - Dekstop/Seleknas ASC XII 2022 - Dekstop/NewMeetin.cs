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
    public partial class NewMeetin: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        doctor doc;
        patient pat;
        public NewMeetin()
        {
            InitializeComponent();

            foreach(var item in db.doctor_category.ToList())
            {
                categoryCB.Items.Add(item.category);
            }

            foreach(var item in db.doctors.ToList())
            {
                NameCB.Items.Add(item.name);
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pat = db.patients.FirstOrDefault(p => p.name == NameInput.Text);
            if (NameInput.Text == "")
            {
                //MessageBox.Show("Please Fill the name patient");

                MasterPatient patientForm = new MasterPatient(pat.id);
                patientForm.Show();
                return;
            }

            if (!db.patients.Any(p => p.name == NameInput.Text))
            {
                //MessageBox.Show("Cannot found the patient by given name");

                MasterPatient patientForm = new MasterPatient();
                patientForm.Show();
                return;
            }


            MasterPatient patientform = new MasterPatient(pat.id);
            patientform.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NameInput.Text == "")
            {
                MessageBox.Show("Please Fill the name patient");
                return;
            }

            if (!db.patients.Any(p => p.name == NameInput.Text))
            {
                MessageBox.Show("Cannot found the patient by given name");
                return;
            }

            pat = db.patients.FirstOrDefault(p => p.name == NameInput.Text);
            PatientRecord record = new PatientRecord(pat.id);
            record.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            doc = db.doctors.FirstOrDefault(d => d.name == NameCB.Text);
            Masterdoctor docForm = new Masterdoctor(categoryCB.Text, NameCB.Text);
            docForm.Show();

        }

        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameCB.SelectedIndex = -1;
            foreach (var item in db.doctors.Where(d=>d.doctor_category.category == categoryCB.Text).ToList())
            {
                NameCB.Items.Add(item.name);
            }
        }

        private void NewMeetin_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string queue = ""; 
            int length = db.meetings
                    .AsEnumerable()
                    .Where(u => u.date == dateTimePicker1.Value)
                    .Select(u => u.queue_number)
                    .DefaultIfEmpty(0)  
                    .Max();

            for (int i = 0; i < length; i++)
            {
                queue += "X";
            }
            label7.Text = queue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to add this data?", "Confirm to Add", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                pat = db.patients.FirstOrDefault(p => p.name == NameInput.Text);
                doc = db.doctors.FirstOrDefault(d => d.name == NameCB.Text);
                int queue = db.meetings
                    .AsEnumerable()
                    .Where(u => u.date == dateTimePicker1.Value)
                    .Select(u => u.queue_number)
                    .DefaultIfEmpty(0)
                    .Max() + 1;

                meeting newmeet = new meeting()
                {
                    patient = pat,
                    doctor = doc,
                    room = doc.assigned_room,
                    date = DateTime.Now,
                    queue_number = queue,
                    created_at = DateTime.Now
                };

                db.meetings.Add(newmeet);
                db.SaveChanges();
                MessageBox.Show("Submitting Successsfully");
            }
        }

        private void NameCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
