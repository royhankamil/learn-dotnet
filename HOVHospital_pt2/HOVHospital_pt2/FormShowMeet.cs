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
    public partial class FormShowMeet: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();

        public FormShowMeet()
        {
            InitializeComponent();

            foreach (var item in db.meetings.ToList())
            {
                dataGridView1.Rows.Add(item.date.ToString("d"), item.patient.name, item.doctor.doctor_category.category,
                    item.doctor.name, item.queue_number, " ");

            }
        }
        patient selectedPat;
        private void FormShowMeet_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                selectedPat = db.patients.AsEnumerable().First(p => p.name ==
                                                dataGridView1.Rows[e.RowIndex].Cells["PatNameCOl"].Value.ToString());

                met = db.meetings.AsEnumerable().First(m => m.patient_id == selectedPat.id && m.date.ToString("d") == dataGridView1.Rows[e.RowIndex].Cells["DateCol"].Value.ToString());
                if (dataGridView1.Columns[e.ColumnIndex].Name == "PaymentCol")
                {

                }
                else
                {
                    dataGridView2.Rows.Clear();

                    foreach (var item in db.patient_record.Where(r=>r.patient_id == selectedPat.id).ToList())
                    {
                        dataGridView2.Rows.Add(item.notes, " ", " ");
                    }
                }
            }
        }
        meeting met;

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditRecordcs form = new AddEditRecordcs(selectedPat.id, met.id);
            form.ShowDialog();
            form.afterApplying += onchange;

        }

        private void onchange()
        {
            dataGridView2.Rows.Clear();

            foreach (var item in db.patient_record.Where(r => r.patient_id == selectedPat.id).ToList())
            {
                dataGridView2.Rows.Add(item.notes, " ", " ");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "Edit")
                {
                    patient_record rec = db.patient_record.AsEnumerable().First(u => u.meeting_id == met.id
                                            && u.patient_id == selectedPat.id &&
                                            u.notes == dataGridView2.Rows[e.RowIndex].Cells["RecCol"].Value.ToString());

                    AddEditRecordcs form = new AddEditRecordcs(selectedPat.id, met.id, rec.id);
                    form.ShowDialog();
                    form.afterApplying += onchange;
                }
                else if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "delete")
                {
                    DialogResult result = MessageBox.Show("Are You sure want to delete this data", "confim", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string nameItem = dataGridView1.Rows[e.RowIndex].Cells["RecCol"].Value.ToString();
                        patient_record det = db.patient_record.First(r => r.patient_id == selectedPat.id && r.meeting_id == met.id &&
                                                        r.notes == nameItem);

                        db.patient_record.Remove(det);
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
