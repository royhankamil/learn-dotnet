using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace hov_hospital_2
{
    public partial class FormMeeting: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        meeting selectedMeet;
        bool selectedAlreadyPay = false;
        public FormMeeting()
        {
            InitializeComponent();

            foreach (var item in db.meetings.ToList())
            {
                dataGridView1.Rows.Add(
                    item.date.ToString("d"),
                    item.patient.name,
                    item.doctor.doctor_category.category,
                    item.doctor.name,
                    item.queue_number,
                    " "
                    );
            }

            button1.Enabled = false;
        }

        private void FormMeeting_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                button1.Enabled = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedMeet = db.meetings.AsEnumerable().First(
                    m => m.date.ToString("d") == row.Cells["DateCOl"].Value.ToString()
                    && m.patient.name == row.Cells["PatientNameCOl"].Value.ToString() && m.doctor.name == row.Cells["DOcnameCol"].Value.ToString());
                dataGridView2.Rows.Clear();

                selectedAlreadyPay = db.payments.Any(p => p.meeting_id == selectedMeet.id);

                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Payment")
                {
                    new paymentForm(selectedMeet, selectedAlreadyPay).ShowDialog();
                }

                foreach (var item in db.patient_record.Where(p => p.meeting_id == selectedMeet.id).ToList()) 
                {
                    dataGridView2.Rows.Add(item.notes, " ", " ");
                }
            }
        }

        private void OndoneChange()
        {
            dataGridView2.Rows.Clear();

            foreach (var item in db.patient_record.Where(p => p.meeting_id == selectedMeet.id).ToList())
            {
                dataGridView2.Rows.Add(item.notes, " ", " ");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChangeRec rec = new AddChangeRec(selectedMeet);
            rec.onDone += OndoneChange;
            rec.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                patient_record pat_rec = db.patient_record.First(r => r.notes == 
                    dataGridView2.Rows[e.RowIndex].Cells["RecordCol"].Value.ToString()
                    );
                if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "Edit")
                {
                    AddChangeRec rec = new AddChangeRec(selectedMeet, pat_rec.id);
                    rec.onDone += OndoneChange;
                    rec.ShowDialog();
                }
                else if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult res = MessageBox.Show("Are You Sure Want to delete this data", "Confirmation", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        db.patient_record.Remove(pat_rec);
                        db.SaveChanges();
                        OndoneChange();
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
