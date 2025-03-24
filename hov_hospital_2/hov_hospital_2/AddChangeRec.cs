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
    public partial class AddChangeRec: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        meeting met;
        public Action onDone;
        int record_id;
        public AddChangeRec(meeting met, int record_id=-1)
        {
            InitializeComponent();

            this.record_id = record_id;
            this.met = met;
            if (record_id != -1)
            {
                textBox1.Text = db.patient_record.Find(record_id).notes;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (record_id != -1)
            {
                patient_record rec = db.patient_record.Find(record_id);

                rec.notes = textBox1.Text;
            }

            else
            {
                patient_record patrec = new patient_record()
                {
                    patient = met.patient,
                    meeting = met,
                    notes = textBox1.Text,
                    date = met.date,
                    created_at = DateTime.Now
                };
            }

            db.SaveChanges();
            onDone?.Invoke();
            this.Hide();
        }
    }
}
