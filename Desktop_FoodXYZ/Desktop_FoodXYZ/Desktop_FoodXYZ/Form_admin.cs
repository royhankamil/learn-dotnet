using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_FoodXYZ
{
    public partial class Form_admin : Form
    {
        FoodXYZEntities1 db = new FoodXYZEntities1();
        int user_id;
        public Form_admin(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            if (db.tbl_user.Find(user_id).tipe_user != "Admin")
                this.Close();

            dataGridView1.DataSource = db.tbl_log.Select(u => new
            {
                ID_Log = u.id_log,
                Username = u.tbl_user.username,
                Waktu = u.waktu,
                Aktivitas = u.aktivitas
            }).ToList();
        }

        private void Form_admin_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.tbl_log.Where(u=> DbFunctions.TruncateTime(u.waktu) == DbFunctions.TruncateTime(dateInput.Value)).Select(u => new
            {
                ID_Log = u.id_log,
                Username = u.tbl_user.username,
                Waktu = u.waktu,
                Aktivitas = u.aktivitas
            }).ToList();
        }

        private void olahUserButton_Click(object sender, EventArgs e)
        {
            Kelola_User kelola_User = new Kelola_User(user_id);
            kelola_User.Show();
            this.Hide();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void laporanButton_Click(object sender, EventArgs e)
        {
            Kelola_laporan laporan = new Kelola_laporan(user_id);
            laporan.Show();
            this.Hide();
        }
    }
}
