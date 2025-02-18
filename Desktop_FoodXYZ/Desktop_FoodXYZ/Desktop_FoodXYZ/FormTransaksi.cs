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
    public partial class FormTransaksi : Form
    {
        public class Keranjang
        {
            public string ID_Transaksi;
            public string Kode_Barang;
            public int ID_Barang;
            public string Nama_Barang;
            public int Harga_Satuan;
            public int Quantitas_Column;
            public long Subtotal;
        }

        int user_id;
        FoodXYZEntities1 db = new FoodXYZEntities1();
        List<Keranjang> keranjang = new List<Keranjang>();

        //var namaKolom;
        public FormTransaksi(int user_id)
        {
            InitializeComponent();

            //namaKolom = dataGridView1.Columns.;
            this.user_id = user_id;
            Username.Text = db.tbl_user.Find(user_id).nama;
            HargaBarang.Text = "0";
            Quantitas.Text = "0";
            foreach (var barang in  db.tbl_barang.ToList())
            {
                KodeBarang.Items.Add(barang.kode_barang + "-" + barang.nama_barang);
            }
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string id = "TR" + (dataGridView1.Rows.Count + 1).ToString("000");

            var kodebarang = KodeBarang.Text.Split('-');
            string kode = kodebarang[0];
            string namabarang = kodebarang[1];

            HargaBarang.Text = db.tbl_barang.FirstOrDefault(b => b.kode_barang == kode).harga_satuan.ToString();
            int idbarang = db.tbl_barang.First(u => u.kode_barang == kode).id_barang;
            keranjang.Add(new Keranjang
            {
                ID_Transaksi = id,
                ID_Barang = idbarang,
                Kode_Barang = kode,
                Nama_Barang = namabarang,
                Harga_Satuan = int.Parse(HargaBarang.Text),
                Quantitas_Column = int.Parse(Quantitas.Text),
                Subtotal = long.Parse(TotHarga.Text)
            });

            dataGridView1.Rows.Add(
                id,
                kode,
                namabarang,
                int.Parse(HargaBarang.Text),
                int.Parse(Quantitas.Text),
                long.Parse(TotHarga.Text)
            );

            labelBayar.Text = keranjang.Select(u=>u.Subtotal).Sum().ToString();

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            keranjang.Clear();
            dataGridView1.Rows.Clear();
            labelBayar.Text = "0";
        }

        private void HargaBarang_TextChanged(object sender, EventArgs e)
        {
            //TotHarga.Text = (int.Parse(HargaBarang.Text) * int.Parse(Quantitas.Text)).ToString();
        }

        private void KodeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kodebarang = KodeBarang.Text.Split('-');
            string kode = kodebarang[0];
            HargaBarang.Text = db.tbl_barang.FirstOrDefault(b => b.kode_barang == kode).harga_satuan.ToString();
            Console.WriteLine(int.Parse(HargaBarang.Text) * int.Parse(Quantitas.Text));
            TotHarga.Text = (int.Parse(HargaBarang.Text) * int.Parse(Quantitas.Text)).ToString();
        }

        private void Quantitas_TextChanged(object sender, EventArgs e)
        {
            if (Quantitas.Text.All(char.IsDigit) && Quantitas.Text != "")
            {
                if (int.Parse(Quantitas.Text) > 0)
                {
                    var kodebarang = KodeBarang.Text.Split('-');
                    string kode = kodebarang[0];
                    HargaBarang.Text = db.tbl_barang.FirstOrDefault(b => b.kode_barang == kode).harga_satuan.ToString();
                    TotHarga.Text = (int.Parse(HargaBarang.Text) * int.Parse(Quantitas.Text)).ToString();
                }

            }
        }

        private void InputBayar_TextChanged(object sender, EventArgs e)
        {
            if (InputBayar.Text != "" && int.Parse(labelBayar.Text) > 0)
            {
                labelKembalian.Text = (int.Parse(InputBayar.Text) - int.Parse(labelBayar.Text)).ToString();
            }
            else
            {
                labelKembalian.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (keranjang.Count > 0)
            {
                foreach (var barang in keranjang)
                {
                    db.tbl_transaksi.Add(new tbl_transaksi
                    {
                        no_transaksi = barang.ID_Transaksi,
                        tgl_transaksi = DateTime.Now,
                        total_bayar = barang.Subtotal,
                        id_user = user_id,
                        id_barang = barang.ID_Barang
                    });

                    db.SaveChanges();

                }
            }
        }
    }
}
