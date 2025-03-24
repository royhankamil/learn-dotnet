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
    public partial class FormMeetin: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();

        meeting selectedMet;
        public FormMeetin()
        {
            InitializeComponent();
            foreach (var item in db.meetings.ToList())
            {
                dataGridView1.Rows.Add(item.date.ToString("d"),
                    item.patient.name, item.doctor.doctor_category.category,
                    item.doctor.name, item.queue_number, " ");
            }

            button1.Enabled = false;
        }

        private void FormMeetin_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Payment")
                {

                }
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedMet = db.meetings.AsEnumerable().First(m =>
                                m.date.ToString("d") == row.Cells["DateCol"].Value.ToString() &&
                                m.patient.name == row.Cells["PatientNameCol"].Value.ToString() &&
                                m.doctor.name == row.Cells["DocNameCol"].Value.ToString()
                                );

                button1.Enabled = true;

                bool alreadyPay = db.payments.Any(p => p.meeting_id == selectedMet.id);

                dataGridView2.Rows.Clear();
                foreach (var item in db.patient_record.Where(pd=>pd.meeting_id == selectedMet.id).ToList())
                {
                    dataGridView2.Rows.Add(item.notes, " ", " ");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChangeRec recCha = new AddChangeRec(selectedMet);
            recCha.onDone += onChange;
        }

        private void onChange()
        {
            dataGridView2.Rows.Clear();
            foreach (var item in db.patient_record.Where(pd => pd.meeting_id == selectedMet.id).ToList())
            {
                dataGridView2.Rows.Add(item.notes, " ", " ");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                patient_record rec = db.patient_record.AsEnumerable().First(r => r.notes ==
                                        dataGridView2.Rows[e.RowIndex].Cells["RecordCol"].Value.ToString());
                if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "Edit")
                {
                    AddChangeRec recCha = new AddChangeRec(selectedMet, rec);
                    recCha.onDone += onChange;
                }
                else if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are You Sure Want to delete this data?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        db.patient_record.Remove(rec);
                        db.SaveChanges();
                    }

                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
