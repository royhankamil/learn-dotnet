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
    public partial class PaymentForm: Form
    {
        meeting met;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        payment pay;
        public PaymentForm(meeting met, bool alreadyPaid)
        {
            InitializeComponent();
            this.met = met;

            pay = db.payments.FirstOrDefault(p=>p.meeting_id == met.id);

            foreach (var item in db.payment_detail.Where(p=>p.payment_id == pay.id))
            {
                dataGridView1.Rows.Add(item.item,
                    item.nominal, item.notes, " ");
            }

            button1.Enabled = !alreadyPaid;
            button2.Enabled = !alreadyPaid;

            textBox1.Enabled = !alreadyPaid;
            textBox2.Enabled = !alreadyPaid;
            dateTimePicker1.Enabled = !alreadyPaid;
            textBox6.Enabled = !alreadyPaid;
            textBox4.Enabled = !alreadyPaid;

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pay != null)
            {
                ItemPayment payitem = new ItemPayment(pay);
                payitem.ShowDialog();
                payitem.onDone += onChange;

            }
        }

        private void onChange()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in db.payment_detail.Where(p => p.payment_id == pay.id))
            {
                dataGridView1.Rows.Add(item.item,
                    item.nominal, item.notes, " ");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete" && pay!= null)
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to delete this data?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    payment_detail det = db.payment_detail.AsEnumerable().First(d => d.payment_id == pay.id
                                        && d.item == dataGridView1.Rows[e.RowIndex].Cells["ItemCol"].Value.ToString());
                    db.payment_detail.Remove(det);
                    db.SaveChanges();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkLuhn(textBox6.Text))
            {
                MessageBox.Show("Invalid Card Number");
            }

            if (textBox4.Text.Length != 3 || !textBox4.Text.All(char.IsNumber))
            {
                MessageBox.Show("Invalid Service Code");
            }

            payment newpay = new payment()
            {
                meeting = met,
                card_holder_name = textBox2.Text,
                primary_account_number = textBox6.Text,
                expiration_date = dateTimePicker1.Value,
                service_code = int.Parse(textBox4.Text),
                total_payment = int.Parse(textBox1.Text),
                created_at =DateTime.Now
            };

            db.payments.Add(newpay);
            db.SaveChanges();

        }
        bool checkLuhn(String cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits 
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    }
}
