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
    public partial class ItemPayment: Form
    {

        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public Action onDone;
        payment pay;
        public ItemPayment(payment pay)
        {
            InitializeComponent();
        }

        private void ItemPayment_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.All(char.IsNumber))
            {
                if (int.Parse(textBox6.Text) <=0)
                {
                    MessageBox.Show("Nominal Should be positive number");
                    return;
                }
            }
            if (!textBox6.Text.All(char.IsNumber))
            {
                MessageBox.Show("Nominal Should be positive number");
                return;
            }


            payment_detail detail = new payment_detail()
            {
                payment = pay,
                item = textBox2.Text,
                nominal = int.Parse(textBox6.Text),
                notes = textBox1.Text,
                created_at = DateTime.Now
            };

            db.payment_detail.Add(detail);
            db.SaveChanges();
            onDone?.Invoke();
            Hide();
        }
    }
}
