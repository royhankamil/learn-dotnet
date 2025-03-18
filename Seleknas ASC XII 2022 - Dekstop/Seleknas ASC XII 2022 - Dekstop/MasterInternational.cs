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
    public partial class MasterInternational: Form
    {
        HOV_HospitalEntities db = new HOV_HospitalEntities();
        int selected_icd_id;
        icd_11 icd;

        public MasterInternational()
        {
            InitializeComponent();

            foreach (var item in db.icd_11.ToList())
            {
                comboBox1.Items.Add($"{item.id}) {item.name}");
            }

        }

        private void MasterInternational_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            icd = db.icd_11.ToList()[comboBox1.SelectedIndex];
            DescriptionText.Text = icd.description.ToString();
            ExclusionsList.Items.Clear();

            string exclusion = "";
            foreach(var item in db.icd_11_exclusion.Where(ic => ic.icd_11_id == icd.id).ToList())
            {
                ExclusionsList.Items.Add(item.exclusion);

            }

            flowLayoutPanel1.Controls.Clear();
            int category = db.icd_11_doctor_recommendation.FirstOrDefault(d => d.icd_11_id == icd.id).doctor_category_id;
            foreach(var doctor in db.doctors.Where(d=>d.doctor_category_id == category))
            {
                Panel newPanel = new Panel();
                newPanel.Size = new Size(280, 33);
                newPanel.Location = new Point(3, 3);


                Label doctorSpecialist = new Label();
                doctorSpecialist.AutoSize = false;
                doctorSpecialist.Size = new Size(112, 18);
                doctorSpecialist.Location = new Point(6, 7);
                doctorSpecialist.Text = doctor.doctor_category.category;
                newPanel.Controls.Add(doctorSpecialist);

                LinkLabel doctorName = new LinkLabel();
                doctorName.AutoSize = false;
                doctorName.Size = new Size(97, 33);
                doctorName.Location = new Point(183, 0);
                doctorName.TextAlign = ContentAlignment.MiddleRight;
                doctorName.Text = doctor.name;
                doctorName.Click += new EventHandler(this.onClickDoctor);
                newPanel.Controls.Add(doctorName);

                flowLayoutPanel1.Controls.Add(newPanel);
            }

        }

        private void onClickDoctor(object sender, EventArgs e)
        {
            Masterdoctor doc = new Masterdoctor();
            doc.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DescriptionText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}







