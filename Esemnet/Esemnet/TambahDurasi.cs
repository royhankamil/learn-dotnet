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
    public partial class TambahDurasi: Form
    {
        public Action onSuccessResult;
        EsemNetEntities db = new EsemNetEntities();
        Member member = null;
        Paket paketDB = null;
        KodePotonganHarga potongan = null;
        Komputer pilihKomp = null;
        public TambahDurasi()
        {
            InitializeComponent();

            foreach (string p in db.Pakets.Select(i => i.Nama).ToList())
            {
                paket.Items.Add(p);
            }
            //paket.SelectedIndex = 0;

            //foreach (string p in db.Komputers.Select(i=>i.Merek).ToList())
            //{
            //    komputer.Items.Add(p);
            //}
            //komputer.SelectedIndex = 0;


            potonganharga.Text = "-Rp.0";
            potonganmember.Text = "-Rp.0";
            totalTxt.Text = "Rp.0";
            subtotal.Text = "Rp.0";
        }

        private void TambahTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void paket_SelectedIndexChanged(object sender, EventArgs e)
        {
            paketDB = db.Pakets.FirstOrDefault(u => u.Nama == paket.Text);
            if (paketDB.IDJenis != null)
            {
                foreach (var komp in db.Komputers.Where(k => k.IDJenis == paketDB.IDJenis).Select(k => k.Merek).ToList())
                {
                    komputer.Items.Add(komp);
                }
            }
            else
            {
                foreach (var komp in db.Komputers.Select(k => k.Merek).ToList())
                {
                    komputer.Items.Add(komp);
                }

            }

            komputer.SelectedIndex = 0;

            HargaInput.Text = paketDB.HargaPerJam.ToString();

            update_total_harga();

        }

        private void update_total_harga()
        {
            if (DurasiInput.Text != "" && DurasiInput.Text.All(char.IsNumber))
            {
                int sbtotal = int.Parse(HargaInput.Text) * int.Parse(DurasiInput.Text);
                subtotal.Text = sbtotal.ToString("C", new CultureInfo("id-ID"));

                int dipotong = 0;
                if (potongan != null)
                {
                    if (DateTime.Now < potongan.BerlakuSampai && potongan.Maksimal > sbtotal)
                    {
                        dipotong = (potongan.Presentase * sbtotal / 100);
                        potonganharga.Text = "-" + dipotong.ToString("C", new CultureInfo("id-ID"));
                    }
                }

                totalTxt.Text = (sbtotal - dipotong).ToString("C", new CultureInfo("id-ID"));

            }
            else
            {
                potonganharga.Text = "-Rp.0";
                potonganmember.Text = "-Rp.0";
                totalTxt.Text = "Rp.0";
                subtotal.Text = "Rp.0";
            }
        }

        private void komputer_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_total_harga();

            pilihKomp = db.Komputers.FirstOrDefault(k => k.Merek == komputer.Text);
        }

        private void DurasiInput_TextChanged(object sender, EventArgs e)
        {
            update_total_harga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                dialogpilihmember pilihmember = new dialogpilihmember();
                pilihmember.selectAction += onSelect;
                pilihmember.Show();
            }
        }

        private void onSelect()
        {
            member = db.Members.Find(dialogpilihmember.memberid);
            NamaInput.Text = member.Nama;
            AlamatInput.Text = member.Alamat;
            TeleponInput.Text = member.Telepon;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            NamaInput.Enabled = checkBox1.Checked;
            AlamatInput.Enabled = checkBox1.Checked;
            TeleponInput.Enabled = checkBox1.Checked;

            NamaInput.Text = "";
            AlamatInput.Text = "";
            TeleponInput.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KodeInput.Text != "" && potongan == null)
            {
                MessageBox.Show("Kode Potongan Harga yang anda masukkan salah, Silahkan coba lagi", "Input Invalid", MessageBoxButtons.OK);
                return;
            }

            else if (KodeInput.Text != "")
            {
                if (potongan.BerlakuSampai < DateTime.Now)
                {
                    MessageBox.Show("Kode Potongan Harga yang anda masukkan telah kadaluarsa", "Input Invalid", MessageBoxButtons.OK);
                    return;
                }
                else if (potongan.Maksimal < int.Parse(subtotal.Text))
                {
                    MessageBox.Show($"Kode Potongan tidak bekerja karena anda maksimal total maksimal {potongan.Maksimal} ", "Input Invalid", MessageBoxButtons.OK);
                }
            }


            if (checkBox1.Checked)
            {
                if (NamaInput.Text == "")
                {
                    MessageBox.Show("Nama member harus diisi untuk mendaftarkan member", "Input Invalid", MessageBoxButtons.OK);
                    return;
                }

                if (!TeleponInput.Text.All(char.IsNumber) || TeleponInput.Text.Length < 10 || TeleponInput.Text.Length > 15)
                {
                    MessageBox.Show(" Telepon harus diisi dan hanya berupa karakter angka dengan minimal 10 karakter serta maksimal 15", "Input Invalid", MessageBoxButtons.OK);
                    return;
                }

                Member newMember = new Member()
                {
                    Nama = NamaInput.Text,
                    Alamat = AlamatInput.Text,
                    Telepon = TeleponInput.Text,
                    MasihAktif = true
                };

                member = newMember;
                db.Members.Add(newMember);

            }

            Transaksi anyComputer = db.Transaksis.AsEnumerable().FirstOrDefault(t => t.Komputer.Merek == komputer.Text
                                    && DateTime.Now < t.Tanggal.AddHours(t.Durasi));

            DateTime playComp = DateTime.Now;
            if (anyComputer != default)
            {
                if (!checkBox2.Checked)
                {
                    MessageBox.Show("Komputer ini dalam pemakaian, centang antrian untuk mengantri", "Input Invalid", MessageBoxButtons.OK);
                    return;
                }
                playComp = anyComputer.Tanggal.AddHours(anyComputer.Durasi);

            }

            Transaksi newTransaksi = new Transaksi()
            {
                Komputer = pilihKomp,
                Member = member,
                Paket = paketDB,
                KodePotonganHarga = potongan,
                Tanggal = playComp,
                Waktu = playComp.TimeOfDay,
                DibuatOleh = 1,
                Durasi = int.Parse(DurasiInput.Text)
            };

            DialogResult result = MessageBox.Show("Apakah anda yakin penambahan transaksi?", "Konfirmasi transaksi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.Transaksis.Add(newTransaksi);
                db.SaveChanges();
                onSuccessResult?.Invoke();
            }
        }

        private void KodeInput_TextChanged(object sender, EventArgs e)
        {
            potongan = db.KodePotonganHargas.FirstOrDefault(d => d.Kode == KodeInput.Text);

            int dipotong = 0;
            int sbtotal = int.Parse(HargaInput.Text) * int.Parse(DurasiInput.Text);
            if (potongan != null)
            {
                if (DateTime.Now < potongan.BerlakuSampai && potongan.Maksimal > sbtotal)
                {
                    dipotong = (potongan.Presentase * sbtotal / 100);
                    potonganharga.Text = "-" + dipotong.ToString("C", new CultureInfo("id-ID"));
                }
            }

            totalTxt.Text = (sbtotal - dipotong).ToString("C", new CultureInfo("id-ID"));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
