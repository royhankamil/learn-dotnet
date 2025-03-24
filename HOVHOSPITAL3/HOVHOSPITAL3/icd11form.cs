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
    public partial class icd11form: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public icd11form()
        {
            InitializeComponent();
            foreach (var item in db.icd_11.ToList())
            {
                comboBox1.Items.Add(item.name);
            }

            comboBox1.SelectedIndex = 0;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            icd_11 icd11 = db.icd_11.First(icd => icd.name == comboBox1.Text);

            textBox1.Text = icd11.description;


            listBox1.Items.Clear();
            foreach (var item in db.icd_11_exclusion.Where(ex=>ex.icd_11_id == icd11.id).ToList())
            {
                listBox1.Items.Add(item.exclusion);
            }

            flowLayoutPanel1.Controls.Clear();

            int cate = db.icd_11_doctor_recommendation.FirstOrDefault(dr => dr.icd_11_id == icd11.id).doctor_category.id;

            foreach (var item in db.doctors.Where(dr=>dr.doctor_category_id == cate).ToList())
            {
                Panel panel = new Panel()
                {
                    Size = new Size(321, 24),
                    Location = new Point(3, 3)
                };

                flowLayoutPanel1.Controls.Add(panel);

                Label lab = new Label()
                {
                    Size = new Size(156, 16),
                    Text = item.doctor_category.category,
                    Location = new Point(0, 0),
                    AutoSize = false
                };
                panel.Controls.Add(lab);

                LinkLabel linklab = new LinkLabel()
                {
                    Size = new Size(156, 24),
                    Text = item.name,
                    Location = new Point(0, 162),
                    TextAlign = ContentAlignment.TopRight,
                    AutoSize = false
                };
                panel.Controls.Add(linklab);

            }



        }
    }
}
