using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EemkaCorporation.Properties;

namespace EemkaCorporation
{
    public partial class MainForm : Form
    {
        employee employer;
        public MainForm(int user_id=0)
        {
            InitializeComponent();

            Init(user_id);
        }

        private void Init(int user_id)
        {
            using (EsemkaCorporationEntities esemka = new EsemkaCorporationEntities())
            {
                employer = esemka.employee.FirstOrDefault(i => i.id == user_id);
                if (employer == null)
                {
                    MessageBox.Show("Cannot find id");
                    return;
                }

                Welcome.Text = $"Welcome, {employer.name}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PromotionForm promotionForm = new PromotionForm(employer.id);
            promotionForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MutationFormcs mutation = new MutationFormcs(employer.id);

            mutation.Show();
            this.Hide();
        }

        private void profile_button_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(employer.id);
            profileForm.Show();
            this.Hide();
        }

        private void Welcome_Click(object sender, EventArgs e)
        {

        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            employer = null;
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
