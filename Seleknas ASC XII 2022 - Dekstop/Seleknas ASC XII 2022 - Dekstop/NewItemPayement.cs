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
    public partial class NewItemPayement: Form
    {
        public Action ondone;
        int id;
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public NewItemPayement(int id)
        {
            InitializeComponent();
            this.id = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.All(char.IsNumber) && int.Parse(textBox1.Text) >0)
            {

                payment_detail detail = new payment_detail()
                {
                    payment_id = id,
                    item = NameInput.Text,
                    nominal = decimal.Parse(textBox1.Text),
                    notes = textBox2.Text
                };

                db.payment_detail.Add(detail);
                db.SaveChanges();
                ondone?.Invoke();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill the Nominal with positive numbers");
            }
        }
    }
}
