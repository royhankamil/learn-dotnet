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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Desktop_FoodXYZ
{
    public partial class Form_Barang : Form
    {
        FoodXYZEntities1 db = new FoodXYZEntities1();
        tbl_barang selectedBarang;
        int user_id;
        public Form_Barang(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;
            if (!(db.tbl_user.Find(user_id).tipe_user.ToLower().Contains("gudang")))
                this.Close();

            var data = db.tbl_barang.ToList();

            dataGridView1.DataSource = data.Select(u => new
            {
                ID_Barang = u.id_barang,
                Kode_Barang = u.kode_barang,
                Nama_Barang = u.nama_barang,
                Expired_Date = u.expired_date,
                Jumlah_Barang = u.jumlah_barang,
                Satuan = u.satuan,
                Harga_Satuan = "Rp." + u.harga_satuan.ToString("N0", new CultureInfo("id-ID"))
            }).ToList();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (CheckData() && result == DialogResult.Yes)
            {
                tbl_barang barang = new tbl_barang()
                {
                    kode_barang = KodeBarang.Text,
                    jumlah_barang = long.Parse(JumlahBarang.Text),
                    nama_barang = NamaBarang.Text,
                    satuan = Satuan.Text,
                    expired_date = Expired.Value,
                    harga_satuan = long.Parse(HargaPerSatuan.Text)
                };

                db.tbl_barang.Add(barang);
                db.SaveChanges();
                ManageData();

            }
        }

        private void ManageData()
        {

            if (textBox6.Text != "" && textBox6.Text != "Cari Nama Barang")
            {
                var data = db.tbl_barang.Where(u => u.nama_barang.ToLower().Trim().Substring(0, textBox6.Text.Trim().Length) == textBox6.Text.ToLower().Trim())
                .ToList();

                dataGridView1.DataSource = data.Select(u => new
                {
                    ID_Barang = u.id_barang,
                    Kode_Barang = u.kode_barang,
                    Nama_Barang = u.nama_barang,
                    Expired_Date = u.expired_date,
                    Jumlah_Barang = u.jumlah_barang,
                    Satuan = u.satuan,
                    Harga_Satuan = "Rp." + u.harga_satuan.ToString("N0", new CultureInfo("id-ID"))
                }).ToList();
            }
            else
            {
                var data = db.tbl_barang.ToList();

                dataGridView1.DataSource = data.Select(u => new
                {
                    ID_Barang = u.id_barang,
                    Kode_Barang = u.kode_barang,
                    Nama_Barang = u.nama_barang,
                    Expired_Date = u.expired_date,
                    Jumlah_Barang = u.jumlah_barang,
                    Satuan = u.satuan,
                    Harga_Satuan = "Rp." + u.harga_satuan.ToString("N0", new CultureInfo("id-ID"))
                }).ToList();
            }

        }

        private bool CheckData()
        {
            if (KodeBarang.Text == "" || JumlahBarang.Text == ""
                 && NamaBarang.Text == "" || Satuan.Text == ""
                 || Expired.Text == "" || HargaPerSatuan.Text == "")
            {
                MessageBox.Show("Data Harus terisi", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            else if (!JumlahBarang.Text.All(char.IsDigit))
                MessageBox.Show("Data Jumlah Barang Harus Berupa Angka", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (!HargaPerSatuan.Text.All(char.IsDigit))
                MessageBox.Show("Data Harga Per Satuan Harus Berupa Angka", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ManageData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes && selectedBarang != null)
            {
                selectedBarang.kode_barang = KodeBarang.Text;
                selectedBarang.jumlah_barang = long.Parse(JumlahBarang.Text);
                selectedBarang.nama_barang = NamaBarang.Text;
                selectedBarang.satuan = Satuan.Text;
                selectedBarang.expired_date = Expired.Value;
                selectedBarang.harga_satuan = long.Parse(HargaPerSatuan.Text);

                db.SaveChanges();
                ManageData();
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Add this data", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes && selectedBarang != null)
            {
                db.tbl_barang.Remove(selectedBarang);
                db.SaveChanges();
                ManageData();
            }
        }

        private void Form_Barang_Load(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells["ID_Barang"].Value.ToString());
                selectedBarang = db.tbl_barang.FirstOrDefault(u => u.id_barang == id);

                KodeBarang.Text = selectedBarang.kode_barang;
                JumlahBarang.Text = selectedBarang.jumlah_barang.ToString();
                NamaBarang.Text = selectedBarang.nama_barang;
                Satuan.Text = selectedBarang.satuan;
                Expired.Text = selectedBarang.expired_date.ToString();
                HargaPerSatuan.Text = selectedBarang.harga_satuan.ToString();
            }
        }

        private void Satuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Satuan_Enter(object sender, EventArgs e)
        {
            foreach (var data in db.tbl_barang.Select(u => u.satuan).ToList())
            {
                if (!Satuan.Items.Contains(data))
                    Satuan.Items.
                        
                        
                        
                        
                        
                        (data);
            }
        }
    }
}
