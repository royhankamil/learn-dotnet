using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Esemnet
{

    public partial class Dashboard : Form
    {
        class transaksiHariIni
        {
            public string Nama;
            public string Jam;
            public DateTime hariini;
        }

        int user_id;
        EsemNetEntities db = new EsemNetEntities();
        DateTime timercount = new DateTime(0);

        List<transaksiHariIni> trans = new List<transaksiHariIni>();

        public Dashboard(int user_id)
        {
            trans.Add(new transaksiHariIni{Nama = "zBudi", Jam = "3", hariini = DateTime.Now});
            trans.Add(new transaksiHariIni{Nama = "zBaddi", Jam = "1", hariini = DateTime.Now});
            trans.Add(new transaksiHariIni{Nama = "zBwedi", Jam = "2", hariini = DateTime.Now});

            InitializeComponent();

            this.user_id = user_id;
            timer1.Start();


            WelcomeTxt.Text = db.Penggunas.Find(user_id).NamaPengguna;


            //KomputerNameTemp.Text = trans[0].Nama;
            //DurationTemp.Text = trans[0].Jam;
            //CountDownTemp.Text = trans[0].hariini.ToString();

            //for (int i = 1; i < trans.Count; i++)
            //{
            //    new Label = KomputerNameTemp.get
            //}

            Label labelo = KomputerNameTemp.;
            labelo.Name = "e";
            labelo.Location = new Point(labelo.Location.X, labelo.Location.Y + 30);
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timercount = timercount.AddSeconds(1);
            Time.Text = DateTime.Now.ToString("dd MMMM yyyy   HH:mm:ss");
            label5.Text = timercount.ToString("HH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MasterData masterData = new MasterData(user_id);
            masterData.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void TambahTransaksi_Click(object sender, EventArgs e)
        {
            //Terpakai
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
