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
    public partial class ICD11: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        public ICD11()
        {
            InitializeComponent();

            foreach (var item in db.icd_11.ToList())
            {
                comboBox1.Items.Add(item.name);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            icd_11 icd = db.icd_11.ToList()[comboBox1.SelectedIndex];

            textBox1.Text = icd.description;


            listBox1.Items.Clear();
            foreach (var item in db.icd_11_exclusion.Where(eb=>eb.icd_11_id == icd.id).ToList())
            {
                listBox1.Items.Add(item.exclusion);
            }


            foreach (var item in db.icd_11_doctor_recommendation.Where(r=>r.icd_11_id == icd.id).ToList())
            {

                flowLayoutPanel1.Controls.Clear(); 
                Panel panel = new Panel()
                {
                    Size = new Size(304, 26),
                    Location = new Point(3, 3),
                };

                flowLayoutPanel1.Controls.Add(panel);

                Label label = new Label()
                {
                    Text = item.doctor_category.category,
                    Location = new Point(3, 0),
                    Size = new Size(140, 26),
                    AutoSize = false
                };
                
                LinkLabel linklabel = new LinkLabel()
                {
                    Text = item.doctor_category.category,
                    Location = new Point(149, 0),
                    Size = new Size(152, 26),
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopRight
                };


                linklabel.Click += OnClick;
                panel.Controls.Add(label);
                panel.Controls.Add(linklabel);
            }


        }

        private void OnClick(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
