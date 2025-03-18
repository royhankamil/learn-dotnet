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
    public partial class PatientRecord: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public PatientRecord(int id)
        {
            InitializeComponent();

            patient pat = db.patients.Find(id);
            label1.Text = $"Medical Record of {pat.name}";

            foreach (var dat in db.patient_record.Where(p=>p.patient_id == pat.id).ToList())
            {
                dataGridView1.Rows.Add(
                    dat.date, 
                    dat.meeting.doctor.doctor_category.category,
                    dat.meeting.doctor.name,
                    dat.notes);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PatientRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
