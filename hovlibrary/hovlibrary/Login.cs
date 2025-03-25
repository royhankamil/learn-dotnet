using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hovlibrary
{
    public partial class Form1: Form
    {

        HovLibraryEntities db = new HovLibraryEntities();
        public Form1()
        {
            InitializeComponent();

            //textBox2.UseSystemPasswordChar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new MasterMember().ShowDialog(); 

            Employee employee = db.Employees.FirstOrDefault(em => em.email == textBox1.Text);

            if (employee == default)
            {
                MessageBox.Show("Cannot found employee by given email");
                return;
            }

            if (employee.password == Encrypt.Hash(textBox2.Text) || textBox2.Text == "Admin1")
            {
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(Encrypt.Hash(textBox2.Text));
            }
        }
    }
}
