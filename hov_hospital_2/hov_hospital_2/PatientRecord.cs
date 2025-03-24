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
    public partial class PatientRecord: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public PatientRecord(patient pat)
        {
            InitializeComponent();


            foreach (var item in db.patient_record.Where(r=>r.patient_id == pat.id).ToList())
            {
                dataGridView1.Rows.Add(item.date, item.meeting.doctor.doctor_category.category, item.meeting.doctor.name, item.notes);
            }

        }

        private void PatientRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
