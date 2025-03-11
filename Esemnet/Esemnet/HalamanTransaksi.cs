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
    public partial class HalamanTransaksi : Form
    {
        public Condition condition = Condition.none;
        EsemNetEntities db = new EsemNetEntities();
        Transaksi selectedTransaksi;
        bool alreadyChangedTanggal = false;
        int user_id;
        public HalamanTransaksi(int user_id)
        {
            InitializeComponent();

            //set_button(false);


            this.user_id = user_id;

            dataGridView1.DataSource = db.Transaksis.Select(p => new
            {
                Komputer = p.Komputer.Merek,
                Paket = p.Paket.Nama,
                p.Durasi,
                p.Tanggal,
                p.Waktu,
                Operator = p.DibuatOleh
            }).ToList();

            foreach (var data in db.Komputers.Select(k=>k.Merek).ToList())
            {
                comboBox1.Items.Add(data);
            }
        }

        private void MasterPaket_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (selectedTransaksi == null)
            {
                MessageBox.Show("Please select the data to continue", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
            


        private void update_datagrid()
        {
                var tableData = db.Transaksis.Select(p => new
                {
                    Komputer = p.Komputer.Merek,
                    Paket = p.Paket.Nama,
                    p.Durasi,
                    p.Tanggal,
                    p.Waktu,
                    Operator = p.DibuatOleh
                }).ToList();
            if (alreadyChangedTanggal && comboBox1.SelectedIndex == -1)
            {
                tableData = tableData.Where(t => t.Tanggal.ToString("d") == dateTimePicker1.Value.ToString("d")).ToList();
            }
            else if (alreadyChangedTanggal)
            {
                tableData = tableData.Where(t => t.Tanggal.ToString("d") == dateTimePicker1.Value.ToString("d") && t.Komputer == comboBox1.Text).ToList();
            }
            else
            {
                tableData = tableData.Where(t => t.Komputer == comboBox1.Text).ToList();
            }

            dataGridView1.DataSource = tableData;
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedTransaksi == null)
            {
                MessageBox.Show("Please select the data to continue", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && condition == Condition.none)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedTransaksi = db.Transaksis.AsEnumerable().FirstOrDefault(t=>
                                t.Komputer.Merek == row.Cells["Komputer"].Value.ToString() &&
                                t.Paket.Nama == row.Cells["Paket"].Value.ToString() &&
                                t.Waktu.ToString() == row.Cells["Waktu"].Value.ToString() && 
                                t.Durasi.ToString() == row.Cells["Durasi"].Value.ToString());


            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedTransaksi == null)
            {
                MessageBox.Show("Please select the data to continue", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogTransaksi dialog = new DialogTransaksi(selectedTransaksi.ID);
            dialog.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(user_id);
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MasterData masterData = new MasterData(user_id);
            masterData.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            alreadyChangedTanggal = true;
            update_datagrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagrid();
        }
    }
}
