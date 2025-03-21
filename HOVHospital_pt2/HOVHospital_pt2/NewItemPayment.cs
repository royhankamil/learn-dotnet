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
    public partial class NewItemPayment: Form
    {
        payment pay;
        public Action act;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewItemPayment(int id)
        {
            InitializeComponent();

            pay = db.payments.Find(id);
        }

        private void NewItemPayment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment_detail detail = new payment_detail()
            {
                payment = pay,
                item = textBox1.Text,
                nominal = int.Parse(textBox2.Text),
                notes = textBox3.Text,
                created_at = DateTime.Now
            };

            db.payment_detail.Add(detail);
            db.SaveChanges();
            act?.Invoke();
            Hide();
        }
    }
}
