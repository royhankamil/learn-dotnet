using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemnet
{
    public partial class DialogTransaksi : Form
    {
        EsemNetEntities db = new EsemNetEntities();

        public DialogTransaksi(int transaksiId)
        {
            InitializeComponent();

            Transaksi transaksi = db.Transaksis.Find(transaksiId);

            paket.Items.Add(transaksi.Paket.Nama);
            paket.SelectedIndex = 0;

            komputer.Items.Add(transaksi.Komputer.Merek);
            komputer.SelectedIndex = 0;

            HargaInput.Text = transaksi.Paket.HargaPerJam.ToString();
            DurasiInput.Text = transaksi.Durasi.ToString();

            NamaInput.Text = transaksi.Member.Nama.ToString();
            TeleponInput.Text = transaksi.Member.Telepon.ToString();
            AlamatInput.Text = transaksi.Member.Alamat;

            int total = (int)transaksi.Paket.HargaPerJam * transaksi.Durasi;
            subtotal.Text = total.ToString("C", new CultureInfo("id-ID"));

            int potongan;
            if (transaksi.KodePotonganHarga != null)
                potongan = transaksi.KodePotonganHarga.Presentase * total / 100;
            else

                potongan = 0;
            
            potonganharga.Text = "- " + potongan.ToString("C", new CultureInfo("id-ID"));

            potonganmember.Text = "-Rp.0";
            totalTxt.Text = (total - potongan).ToString("C", new CultureInfo("id-ID"));


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DialogTransaksi_Load(object sender, EventArgs e)
        {

        }
    }
}
