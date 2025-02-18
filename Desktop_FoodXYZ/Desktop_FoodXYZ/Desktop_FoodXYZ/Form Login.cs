using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_FoodXYZ
{
    public partial class Form1 : Form
    {
        FoodXYZEntities1 db = new FoodXYZEntities1();
        public Form1()
        {
            InitializeComponent();

        }

        private void UsernameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameInput_Enter(object sender, EventArgs e)
        {
            //UsernameInput.Text = string.Empty;
        }

        private void PasswordInput_Enter(object sender, EventArgs e)
        {
            PasswordInput.Text = string.Empty;
            PasswordInput.UseSystemPasswordChar = true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            tbl_user user = db.tbl_user.FirstOrDefault(u => u.username.TrimEnd() == UsernameInput.Text);

            if (user != default && user.password.TrimEnd() == PasswordInput.Text && UsernameInput.Text != "" && PasswordInput.Text != "")
            {
                MessageBox.Show("Login Berhasil");
                if (user.tipe_user == "Admin")
                {
                    tbl_log log = new tbl_log() { aktivitas = "Login", id_user = user.id_user, waktu=DateTime.Now};
                    db.tbl_log.Add(log);
                    db.SaveChanges();


                    Form_admin admin = new Form_admin(user.id_user);
                    admin.Show();
                    this.Hide();
                }
                else if (user.tipe_user.ToLower().Contains("gudang"))
                {
                    Form_Barang barang = new Form_Barang(user.id_user);
                    barang.Show();
                    this.Hide();
                }
                else if (user.tipe_user.ToLower().Contains("kasir"))
                {
                    FormTransaksi transaksi = new FormTransaksi(user.id_user);
                    transaksi.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("username atau password yang anda masukkan tidak sesuai !", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UsernameInput.Text = string.Empty;
            PasswordInput.Text = string.Empty;
        }
    }
}
