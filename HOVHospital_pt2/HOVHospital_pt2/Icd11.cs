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
    public partial class Icd11: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        icd_11 selectedICD;
        public Icd11()
        {
            InitializeComponent();

            foreach (var item in db.icd_11.ToList())
            {
                comboBox1.Items.Add(item.name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedICD = db.icd_11.First(i => i.name == comboBox1.Text);
            textBox1.Text = selectedICD.description;

            listBox1.Items.Clear();
            foreach (var exc in db.icd_11_exclusion.Where(ei=>ei.icd_11_id == selectedICD.id).ToList())
            {
                listBox1.Items.Add(exc.exclusion);
            }
            var doctorCat = db.icd_11_doctor_recommendation.FirstOrDefault(d => d.icd_11_id == selectedICD.id).doctor_category;

            foreach (var item in db.doctors.Where(d=>d.doctor_category_id == doctorCat.id))
            {

                Panel panel = new Panel()
                {
                    Size = new Size(339, 30),
                    Location = new Point(3, 3),
                };

                Label label = new Label()
                {
                    Size = new Size(154, 18),
                    Location = new Point(9, 5),
                    Text = doctorCat.category,
                    AutoSize = false
                };
                LinkLabel link = new LinkLabel()
                {
                    Size = new Size(133, 25),
                    Location = new Point(193, 5),
                    AutoSize = false,
                    Text = item.name
                };




                flowLayoutPanel1.Controls.Add(panel);
                panel.Controls.Add(label);
                panel.Controls.Add(link);

            }
        }
    }
}
