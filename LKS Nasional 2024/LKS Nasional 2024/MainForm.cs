using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Nasional_2024
{
    public partial class MainForm: Form
    {
        int user_id;
        grocerseekerEntities db = new grocerseekerEntities();
        public MainForm(int user_id, bool asCust)
        {
            InitializeComponent();

            this.user_id = user_id;
            user userr = db.users.Find(user_id);
            if (asCust)
            {
                NamePlace.Text = userr.cust_name;
                RolePlace.Text = "customer";
            }
            else
            {
                NamePlace.Text = userr.vendor_name;
                RolePlace.Text = "vendor";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfileForm profile = new ProfileForm(user_id);
            profile.Show();
            this.Hide();
        }
    }
}
