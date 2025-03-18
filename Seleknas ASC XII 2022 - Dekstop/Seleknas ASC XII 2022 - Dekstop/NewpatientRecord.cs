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
    public partial class NewpatientRecord: Form
    {
        public Action onChange;
        int patient_id;
        int meet_id;
        int record_id;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewpatientRecord(int patient_id, int meet_id, int record_id=-1)
        {
            InitializeComponent();
            this.patient_id = patient_id;
            this.meet_id = meet_id;
            this.record_id = record_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (record_id != -1)
            {
                patient_record rec = db.patient_record.Find(record_id);
                rec.notes = textBox1.Text;
                rec.last_updated_at = DateTime.Now;
            }
            else
            {
                patient pat = db.patients.Find(patient_id);
                meeting met = db.meetings.Find(meet_id);
                patient_record record = new patient_record()
                {
                    patient = pat,
                    meeting = met,
                    notes = textBox1.Text,
                    date = DateTime.Now,
                    created_at = DateTime.Now
                };

                db.patient_record.Add(record);

            }
            db.SaveChanges();
            MessageBox.Show("Submitting proccess successfully");

            onChange?.Invoke();
            this.Hide();
        }

        private void NewpatientRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
