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
    public partial class paymentForm: Form
    {
        bool arePaid;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        meeting met;
        payment pay;
        public paymentForm(meeting met,  bool areDonePay)
        {
            InitializeComponent();

            arePaid = areDonePay;
            pay = db.payments.FirstOrDefault(p => p.meeting_id == met.id);
            this.met = met;

            textBox2.Enabled = !arePaid;
            textBox3.Enabled = !arePaid;
            dateTimePicker1.Enabled = !arePaid;
            textBox4.Enabled = !arePaid;
            textBox5.Enabled = !arePaid;
            button1.Enabled = !arePaid;
            button2.Enabled = !arePaid;

            foreach (var item in db.payment_detail.Where(pd=>pd.payment_id == pay.id).ToList())
            {
                dataGridView1.Rows.Add(item.item, item.nominal, item.notes, " ");
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void paymentForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkLuhn(textBox3.Text))
            {
                MessageBox.Show("Invalid Card Number");
                return;
            }

            if (!textBox4.Text.All(char.IsNumber) || textBox4.Text.Length != 3)
            {
                MessageBox.Show("Invalid Service code");
                return;
            }

            payment paying = new payment()
            {
                meeting = met,
                card_holder_name = textBox2.Text,
                primary_account_number = textBox3.Text,
                expiration_date = DateTime.Now.AddYears(7),
                service_code = int.Parse(textBox4.Text),
                total_payment = decimal.Parse(textBox5.Text)
            };


            db.payments.Add(paying);
            db.SaveChanges();
            pay = paying;

        }

       private  bool checkLuhn(String cardNo)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (pay != default)
            {
                NewItemForm newitem = new NewItemForm(pay);
                newitem.afterDone += onchanged;
                newitem.ShowDialog();
            }
        }
        private void onchanged()
        {
            foreach (var item in db.payment_detail.Where(pd => pd.payment_id == pay.id).ToList())
            {
                dataGridView1.Rows.Add(item.item, item.nominal, item.notes, " ");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                payment_detail det = db.payment_detail.AsEnumerable().First(u => u.payment_id == pay.id
                                && u.item == dataGridView1.Rows[e.RowIndex].Cells["ItemCOl"].Value.ToString());
                DialogResult res = MessageBox.Show("Are You Sure Want to delete this data", "Confirmation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    db.payment_detail.Remove(det);
                    db.SaveChanges();
                    onchanged();
                }
            }
        }
    }
}
