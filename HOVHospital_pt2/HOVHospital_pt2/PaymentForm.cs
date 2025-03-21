using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHospital_pt2
{
    public partial class PaymentForm: Form
    {
        int metid;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        bool donePay = false;
        public PaymentForm(int metId)
        {
            this.metid = metId;


            if (db.payments.Any(p=>p.meeting_id == metid))
            {
                donePay = true;
                payment pay = db.payments.First(p => p.meeting_id == metid);
                textBox2.Text = pay.card_holder_name;
                textBox3.Text = pay.primary_account_number;
                textBox5.Text = pay.service_code.ToString();
                textBox1.Text = pay.total_payment.ToString();

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox5.Enabled = false;
                textBox1.Enabled = false;
            }

            InitializeComponent();

            foreach (var item in db.payment_detail.Where(p=>p.payment.meeting_id == metId).ToList())
            {
                dataGridView1.Rows.Add(item.item, item.nominal, item.notes, " ");
            }
        }
        

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index  != -1 && !donePay)
            {
                DialogResult result = MessageBox.Show("Are You sure want to delete this data", "confim", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string nameItem = dataGridView1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    payment_detail det = db.payment_detail.First(p => p.payment.meeting_id == metid &&
                                       p.item == nameItem);

                    db.payment_detail.Remove(det);
                    db.SaveChanges(); 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!donePay)
            {
                payment pay = db.payments.First(p => p.meeting_id == metid);
                NewItemPayment newitem = new NewItemPayment(pay.id);
                newitem.ShowDialog();
                newitem.act += onupdate;
            }
        }
        private void onupdate()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in db.payment_detail.Where(p => p.payment.meeting_id == metid).ToList())
            {
                dataGridView1.Rows.Add(item.item, item.nominal, item.notes, " ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!donePay)
            {
                if (textBox5.Text.Length != 3 || !textBox5.Text.All(char.IsNumber))
                {
                    MessageBox.Show("Service code should be three digit numeric");
                    return;
                }
                if (!checkLuhn(textBox3.Text))
                {
                    MessageBox.Show("INvalid card holder name");
                    return;
                }

                meeting met = db.meetings.Find(metid);

                payment newpay = new payment()
                {
                    meeting = met,
                    card_holder_name = textBox2.Text,
                    primary_account_number = textBox3.Text,
                    expiration_date = DateTime.Now.AddYears(5),
                    service_code = int.Parse(textBox5.Text),
                    total_payment =int.Parse(textBox1.Text),
                    created_at = DateTime.Now
                };

                db.payments.Add(newpay);
                db.SaveChanges();


            }
        }

        static bool checkLuhn(String cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }

    }
}
