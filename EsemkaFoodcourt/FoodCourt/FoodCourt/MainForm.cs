using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;

namespace FoodCourt
{
    public partial class MainForm : Form
    {
        public MainForm(int user_id)
        {
            InitializeComponent();

            using (FoodcourtEntities db = new FoodcourtEntities())
            {
                Users user = db.Users.First(u => u.ID == user_id);
                label1.Text = $"Welcome, {user.FirstName} {user.LastName}";


            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void mMembersButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.Show();
            this.Hide();
        }
    }
}
