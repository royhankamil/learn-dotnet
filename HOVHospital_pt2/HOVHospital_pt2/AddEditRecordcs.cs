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
    public partial class AddEditRecordcs: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public Action afterApplying;
        int rec_id, pat_id, metid;
        public AddEditRecordcs(int pat_id, int metid, int rec_id=-1)
        {
            InitializeComponent();
            this.pat_id = pat_id;
            this.metid = metid;
            this.rec_id = rec_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rec_id != -1)
            {
                patient_record rec = db.patient_record.Find(rec_id);
                rec.notes = textBox1.Text;
            }

            else
            {
                patient pat = db.patients.Find(pat_id);
                meeting met = db.meetings.Find(metid);
                patient_record rec = new patient_record()
                {
                    meeting = met,
                    patient = pat,
                    notes = textBox1.Text,
                    date = DateTime.Now,
                    created_at = DateTime.Now
                };
                db.patient_record.Add(rec);
            }

            db.SaveChanges();
            afterApplying?.Invoke();
            Hide();
        }
    }
}
