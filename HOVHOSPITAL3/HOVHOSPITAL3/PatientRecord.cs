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
    public partial class PatientRecord: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public PatientRecord(patient pat)
        {
            InitializeComponent();

            label1.Text = $"Patient Record of {pat.name}";

            foreach (var item in db.patient_record.Where(r=>r.patient_id == pat.id))
            {
                dataGridView1.Rows.Add(
                    item.date.ToString("d"),
                    item.meeting.doctor.doctor_category.category,
                    item.meeting.doctor.name,
                    item.notes);
            }
        }

        private void PatientRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
