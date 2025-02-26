using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemnet
{
    public partial class Login : Form
    {
        EsemNetEntities db = new EsemNetEntities();


        public Login()
        {
            InitializeComponent();

            ErrorText.Text = "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (NameInput.Text == "" || PasswordInput.Text == "")
                ErrorText.Text = "Tolong masukkan Nama Pengguna dan Kata Sandi anda";


            Pengguna pengguna = db.Penggunas.FirstOrDefault(u => u.NamaPengguna == NameInput.Text);

            if (pengguna != null)
            {
                if (pengguna.KataSandi == PasswordInput.Text)
                {
                    //MessageBox.Show("Login berhasil");
                    ErrorText.Text = "";

                    Dashboard dashboard = new Dashboard(pengguna.ID);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    ErrorText.Text = "Password anda masih salah, Silakan coba lagi";
                }
            }
            else
            {
                ErrorText.Text = "Nama pengguna masih belum terdaftar";
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
