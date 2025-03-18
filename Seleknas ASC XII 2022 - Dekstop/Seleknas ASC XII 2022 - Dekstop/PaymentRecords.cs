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
    public partial class PaymentRecords: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        int id;
        payment pay;
        public PaymentRecords(int id )
        {
            InitializeComponent();

            this.id = id;
            dateTimePicker1.Value = DateTime.Now.AddYears(5);

            pay = db.payments.FirstOrDefault(p => p.meeting_id == id);
            if (pay != null)
            {
                foreach (var item in db.payment_detail.Where(p=>p.payment_id == pay.id).ToList())
                {
                    if (alreadyPaid())
                    {
                        dataGridView1.Rows.Add(item.item,
                            item.nominal,
                            item.notes,
                            "");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(item.item,
                            item.nominal,
                            item.notes,
                            " ");
                    }    
                }

            }

            if (alreadyPaid())
            {
                button1.Enabled = false;
                NameInput.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button2.Enabled = false;
                dateTimePicker1.Enabled = false;

            }
        }

        private void PaymentRecords_Load(object sender, EventArgs e)
        {

        }
        private bool alreadyPaid()
        {
            if (pay == null)
                return false;

            decimal total = db.payment_detail.Where(p=>p.payment_id == pay.id).Select(u => u.nominal).ToList().Sum();
            return pay.total_payment >= total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!alreadyPaid())
            {
                if (pay != null) 
                {
                    NewItemPayement detail = new NewItemPayement(pay.id);
                    detail.Show();
                }
                else
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check_data())
            {
                meeting met = db.meetings.Find(id);
                payment pay = new payment()
                {
                    meeting = met,
                    card_holder_name = NameInput.Text,
                    primary_account_number = textBox1.Text,
                    expiration_date = dateTimePicker1.Value,
                    service_code = int.Parse(textBox2.Text),
                    total_payment = decimal.Parse(textBox3.Text),
                    created_at = DateTime.Now
                };

                db.payments.Add(pay);
                db.SaveChanges();

                MessageBox.Show("Submitting proccesss successfully");
            }
        }

        private bool check_data()
        {
            decimal total = db.payment_detail.Select(u => u.nominal).ToList().Sum();

            if (textBox2.Text.Length != 3 || !textBox2.Text.All(char.IsNumber))
            {
                MessageBox.Show("Service code should be three digit numeric.");
                return false;
            }

            if (!checkLuhn(NameInput.Text))
            {
                MessageBox.Show("Card Holder Name is invalid");
                return false;
            }

            //if (decimal.Parse(textBox3.Text) > total)
            //{

            //}

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Confirmation delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string item = dataGridView1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    payment_detail detail = db.payment_detail.FirstOrDefault(d => d.payment_id == pay.id &&
                                                d.item == item);

                    db.payment_detail.Remove(detail);
                    db.SaveChanges();
                }
            }
        }

        private bool checkLuhn(String cardNo)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
