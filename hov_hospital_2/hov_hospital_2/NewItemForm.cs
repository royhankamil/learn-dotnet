using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hov_hospital_2
{
    public partial class NewItemForm: Form
    {
        payment pay;
        public Action afterDone;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewItemForm(payment pay)
        {
            InitializeComponent();

            this.pay = pay;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.All(char.IsNumber))
            {
                MessageBox.Show("Nominal must be number");
            }

            payment_detail paymen = new payment_detail()
            {
                payment = pay,
                item = textBox2.Text,
                nominal = int.Parse(textBox3.Text),
                notes = textBox4.Text,
                created_at = DateTime.Now
            };

            db.payment_detail.Add(paymen);
            db.SaveChanges();
            afterDone?.Invoke();
        }
    }
}
