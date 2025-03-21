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
    public partial class viewPatientRecord: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public viewPatientRecord(int id)
        {
            InitializeComponent();

            patient pat = db.patients.Find(id);
            foreach (var item in db.patient_record.Where(p=>p.patient_id == id).ToList())
            {
                dataGridView1.Rows.Add(item.date,
                    item.meeting.doctor.doctor_category.category,
                    item.meeting.doctor.name,
                    item.notes);
            }
            label1.Text = $"Patient Record of {pat.name}";
        }

        private void viewPatientRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
