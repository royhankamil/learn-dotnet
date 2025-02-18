using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Desktop_FoodXYZ
{
    public partial class Kelola_User : Form
    {
        int user_id;
        FoodXYZEntities1 db = new FoodXYZEntities1();
        tbl_user userSelected;
        public Kelola_User(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;
            if (db.tbl_user.Find(user_id).tipe_user != "Admin")
                this.Close();

            dataGridView1.DataSource = db.tbl_user.Select(u => new
            {
                Id_user = u.id_user,
                Tipe_user = u.tipe_user,
                Nama_user = u.username,
                Alamat = u.alamat,
                Telepon = u.telpon
            }).ToList();
        }

        private void Kelola_User_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Kelola_User_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ManageData();
        }
        private void ManageData()
        {

            if (textBox6.Text != "" && textBox6.Text != "Cari User")
            {
                dataGridView1.DataSource = db.tbl_user.Select(u => new
                {
                    Id_user = u.id_user,
                    Tipe_user = u.tipe_user,
                    Nama_user = u.username,
                    Alamat = u.alamat,
                    Telepon = u.telpon
                }).Where(u=> u.Nama_user.ToLower().Trim().Substring(0, textBox6.Text.Trim().Length) == textBox6.Text.ToLower().Trim())
                .ToList();
            }
            else
            {
                dataGridView1.DataSource = db.tbl_user.Select(u => new
                {
                    Id_user = u.id_user,
                    Tipe_user = u.tipe_user,
                    Nama_user = u.username,
                    Alamat = u.alamat,
                    Telepon = u.telpon
                }).ToList();
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (CheckData() && result == DialogResult.Yes)
            {
                tbl_user user = new tbl_user()
                {
                    nama = Nama.Text,
                    tipe_user = TipeUser.Text,
                    alamat = Alamat.Text,
                    username = Username.Text,
                    telpon = Telepon.Text,
                    password = Password.Text
                };

                db.tbl_user.Add(user);
                db.SaveChanges();
                ManageData();

            }
        }

        private void TipeUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private bool CheckData()
        {
           if (TipeUser.Text == "" || Alamat.Text == ""
                && Nama.Text == "" || Username.Text == ""
                || Telepon.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Data Harus terisi", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }       

           return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes && userSelected != null)
            {
                userSelected.nama = Nama.Text;
                userSelected.tipe_user = TipeUser.Text;
                userSelected.alamat = Alamat.Text;
                userSelected.username = Username.Text;
                userSelected.telpon = Telepon.Text;
                userSelected.password = Password.Text;

                db.SaveChanges();
                ManageData();
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes && userSelected != null)
            {
                db.tbl_user.Remove(userSelected);
                db.SaveChanges();
                ManageData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 )
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells["Id_user"].Value.ToString());
                userSelected = db.tbl_user.FirstOrDefault(u => u.id_user == id);

                Nama.Text = userSelected.nama;
                TipeUser.Text = userSelected.tipe_user;
                Alamat.Text = userSelected.alamat;
                Username.Text = userSelected.username;
                Telepon.Text = userSelected.telpon;
                Password.Text = userSelected.password;
            }

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

            tbl_log log = new tbl_log() { aktivitas = "Logout", id_user = user_id, waktu = DateTime.Now };
            db.tbl_log.Add(log);
            db.SaveChanges();
        }

        private void laporanButton_Click(object sender, EventArgs e)
        {
            Kelola_laporan laporan = new Kelola_laporan(user_id);
            laporan.Show();
            this.Hide();
        }
    }
}
