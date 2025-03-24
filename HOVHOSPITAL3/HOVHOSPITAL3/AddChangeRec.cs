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
    public partial class AddChangeRec: Form
    {
        public Action onDone;
        meeting met;
        patient_record rec;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public AddChangeRec(meeting met, patient_record rec=null)
        {
            InitializeComponent();
            this.met = met;
            this.rec = rec;
        }

        private void AddChangeRec_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rec == null)
            {
                patient_record rec = new patient_record()
                {
                    patient = met.patient,
                    meeting = met,
                    notes = textBox1.Text,
                    date = met.date,
                    created_at = DateTime.Now
                };

                db.patient_record.Add(rec);
            }
            else
            {
                rec.notes = textBox1.Text;
            }
            db.SaveChanges();
            onDone?.Invoke();
            Hide();
        }
    }
}
