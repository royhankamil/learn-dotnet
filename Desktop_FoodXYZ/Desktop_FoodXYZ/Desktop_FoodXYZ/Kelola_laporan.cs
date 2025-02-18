using System;
using System.Globalization;
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
    public partial class Kelola_laporan : Form
    {
        FoodXYZEntities1 db = new FoodXYZEntities1();
        int user_id;
        public Kelola_laporan(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            if (db.tbl_user.Find(user_id).tipe_user != "Admin")
                this.Close();

            chart1.Series.Clear();
        }

        private void Kelola_laporan_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void load_chart()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = db.tbl_transaksi.Where(u=> DbFunctions.TruncateTime(u.tgl_transaksi) >= DbFunctions.TruncateTime(tanggalawal.Value)
            && DbFunctions.TruncateTime(u.tgl_transaksi) <= DbFunctions.TruncateTime(tanggalakhir.Value))
            .ToList();

            dataGridView1.DataSource = data.Select(u => new
            {
                ID_Transaksi = u.id_transaksi,
                Tanggal_Transaksi = u.tgl_transaksi,
                Total_Pembayaran = "Rp. " + u.total_bayar.ToString("N0", new CultureInfo("id-ID")),
                Nama_Kasir = u.tbl_user.nama
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Kelola_laporan_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("Omset");

            var dateUnique = db.tbl_transaksi.Select(t => t.tgl_transaksi).ToList().Distinct().ToList() ;

            dateUnique.Sort();

            foreach ( var t in dateUnique )
            {
                var pendapatan = db.tbl_transaksi.Where(u => u.tgl_transaksi == t)
                    .Select(u => u.total_bayar).ToList().Sum();

                chart1.Series["Omset"].Points.AddXY(t.Date.ToShortDateString(), pendapatan);
            }

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = new CultureInfo("id-ID").NumberFormat.CurrencySymbol + " #, ##0";
        }
    }
}
