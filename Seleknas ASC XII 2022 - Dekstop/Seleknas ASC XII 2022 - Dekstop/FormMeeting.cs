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
    public partial class FormMeeting: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        meeting met;
        public FormMeeting()
        {
            InitializeComponent();

            foreach(var data in db.meetings.ToList())
            {
                dataGridView1.Rows.Add(
                    data.date,
                    data.patient.name,
                    data.doctor.doctor_category.category,
                    data.doctor.name,
                    data.queue_number,
                    ""
                    );

            }

        }

        private void FormMeeting_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow cell = dataGridView1.Rows[e.RowIndex];
                met = db.meetings.ToList()[e.RowIndex];
                if (dataGridView1.Columns[e.ColumnIndex].Name == "PaymentColl")
                {
                    PaymentRecords payment = new PaymentRecords(met.id);
                    payment.Show();
                }
                else
                {
                    dataGridView2.Rows.Clear();
                    payment pay = db.payments.FirstOrDefault(p => p.meeting_id == met.id);
                    decimal total = 0;
                    if (pay != null)
                        total = db.payment_detail.Where(p => p.payment_id == pay.id).Select(p=>p.nominal).ToList().Sum();

                    button1.Enabled = true;
                    if (pay != null)
                    {
                        if (pay.total_payment >= total)
                            button1.Enabled = false;

                    }


                            foreach (var item in db.patient_record.AsEnumerable().Where(r => 
                            r.patient.name == dataGridView1.Rows[e.RowIndex].Cells["patientNameCol"].Value.ToString()))
                    {
                        if (pay != null)
                        {
                            if (pay.total_payment >= total)
                                dataGridView2.Rows.Add(item.notes, "", "");

                            dataGridView2.Rows.Add(item.notes, " ", " ");
                        }
                        dataGridView2.Rows.Add(item.notes, " ", " ");
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (met != null)
            {
                NewpatientRecord record = new NewpatientRecord(met.patient_id, met.id);
                record.onChange += ondone;
                record.Show();
            }
        }

        private void ondone()
        {
            dataGridView2.Rows.Clear();
            payment pay = db.payments.FirstOrDefault(p => p.meeting_id == met.id);
            decimal total = 0;
            if (pay != null)
                total = db.payment_detail.Where(p => p.payment_id == pay.id).Select(p => p.nominal).ToList().Sum();

            button1.Enabled = true;
            if (pay != null)
            {
                if (pay.total_payment >= total)
                    button1.Enabled = false;

            }


            foreach (var item in db.patient_record.AsEnumerable().Where(r =>
            r.patient.name == met.patient.name))
            {
                if (pay != null)
                {
                    if (pay.total_payment >= total)
                        dataGridView2.Rows.Add(item.notes, "", "");

                    dataGridView2.Rows.Add(item.notes, " ", " ");
                }
                dataGridView2.Rows.Add(item.notes, " ", " ");
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                patient_record pat_rec = db.patient_record.AsEnumerable().FirstOrDefault(r => r.notes == dataGridView2.Rows[e.RowIndex].Cells["RecordsCol"].Value.ToString());
                if (dataGridView2.Columns[e.ColumnIndex].Name == "EditCol")
                {
                    NewpatientRecord rec = new NewpatientRecord(0, 0, pat_rec.id);
                    rec.onChange += ondone;
                    rec.Show();
                }

                else if (dataGridView2.Columns[e.ColumnIndex].Name == "DeleteCol")
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Confirmation delete", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        db.patient_record.Remove(pat_rec);
                        db.SaveChanges(); 
                    }
                }
            }
        }
    }
}
