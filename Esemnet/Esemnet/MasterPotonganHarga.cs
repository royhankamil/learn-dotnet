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
    public partial class MasterPotonganHarga : Form
    {
        EsemNetEntities db = new EsemNetEntities();
        KodePotonganHarga selectedPotonganHarga = null;
        int user_id;
        Condition condition = Condition.none;
        public MasterPotonganHarga(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;

            update_datagrid();
            set_button(false);
            ErrorText.Text = string.Empty;
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

        private void set_button(bool wantChange)
        {
            addBtn.Enabled = !wantChange;
            updateBtn.Enabled = !wantChange;
            delBtn.Enabled = !wantChange;

            saveBtn.Enabled = wantChange;
            cancelBtn.Enabled = wantChange;

            NamaInput.Enabled = wantChange;
            KodeInput.Enabled = wantChange;
            PersentaseInput.Enabled = wantChange;
            MaksimalInput.Enabled = wantChange;
            BerlakuInput.Enabled = wantChange;
        }

        private void update_datagrid()
        {
            dataGridView1.DataSource = db.KodePotonganHargas.Select(p => new
            {
                p.Nama,
                p.Kode,
                p.Presentase,
                p.Maksimal,
                p.BerlakuSampai
            }).ToList();
        }

        private bool check_data(bool isUpdate)
        {
            if (NamaInput.Text.Trim() == "")
            {
                ErrorText.Text = "Nama tidak boleh kosong";
                return false;
            }

            if (KodeInput.Text == "")
            {
                ErrorText.Text = "Kode tidak boleh kosong";
                return false;
            }

            if (PersentaseInput.Text == "" || !PersentaseInput.Text.All(char.IsNumber))
            {
                ErrorText.Text = "Presentase tidak boleh kosong dan harus berupa angka";
                return false;
            }

            if (!MaksimalInput.Text.All(char.IsNumber))
            {
                ErrorText.Text = "Masukkan angka untuk Maksimal";
                return false;
            }

            if (!KodeInput.Text.All(char.IsLetterOrDigit))
            {
                ErrorText.Text = "Masukkan bentuk alphanumeric untuk kode input";
                return false;
            }

            if (int.Parse(PersentaseInput.Text) <= 0 || int.Parse(PersentaseInput.Text) > 100)
            {
                ErrorText.Text = "Presentase harus berupa angka dari 1-100";
                return false;
            }
            if (MaksimalInput.Text != "")
            {
                if (double.Parse(MaksimalInput.Text) <= 0)
                {
                    ErrorText.Text = "Maksimal minimal angka nya 1";
                    return false;
                }
            }

            if (!(BerlakuInput.Value >= DateTime.Now.AddDays(1)))
            {
                ErrorText.Text = "Berlaku Sampai minimal 1 hari setelah tanggal\r\npembuatan.";
                return false;
            }

            var kode = NamaInput.Text;
            var potongan = db.KodePotonganHargas.FirstOrDefault(k => k.Kode == kode);

            if (!isUpdate && potongan != default)
            {
                ErrorText.Text = "Kode yang anda inputkan telah terdaftar";
                return false;
            }
            else if (isUpdate && potongan != default && potongan.ID != selectedPotonganHarga.ID)
            {
                ErrorText.Text = "Kode yang anda inputkan telah terdaftar";
                return false;
            }

            return true;
        }
        private void clear_input()
        {
            NamaInput.Text = string.Empty;
            KodeInput.Text = string.Empty;
            PersentaseInput.Text = string.Empty;
            MaksimalInput.Text = string.Empty;
            BerlakuInput.Value = DateTime.Now;
        }

        private void MasterPotonganHarga_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            condition = Condition.add;
            set_button(true);
            clear_input();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedPotonganHarga != null)
            {
                condition = Condition.update;
                set_button(true);
            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (condition == Condition.add)
            {
                if (check_data(false))
                {
                    ErrorText.Text = "";

                    KodePotonganHarga kodePotonganHarga = new KodePotonganHarga
                    {
                        Nama = NamaInput.Text,
                        Kode = KodeInput.Text,
                        Presentase = int.Parse(PersentaseInput.Text),
                        Maksimal = double.Parse(MaksimalInput.Text),
                        BerlakuSampai = BerlakuInput.Value
                    };

                    db.KodePotonganHargas.Add(kodePotonganHarga);
                    db.SaveChanges();
                    update_datagrid();

                    condition = Condition.none;
                    set_button(false);
                    clear_input();
                }
            }
            else if (condition == Condition.update)
            {
                if (check_data(true))
                {
                    ErrorText.Text = "";

                    selectedPotonganHarga.Nama = NamaInput.Text;
                    selectedPotonganHarga.Kode = KodeInput.Text;
                    selectedPotonganHarga.Presentase = int.Parse(PersentaseInput.Text);
                    selectedPotonganHarga.Maksimal = double.Parse(MaksimalInput.Text);
                    selectedPotonganHarga.BerlakuSampai = BerlakuInput.Value;

                    db.SaveChanges();
                    update_datagrid();

                    condition = Condition.none;
                    set_button(false);
                    clear_input();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            condition = Condition.none;
            selectedPotonganHarga = null;
            set_button(false);
            clear_input();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && condition == Condition.none)
            {
                ErrorText.Text = string.Empty;
                selectedPotonganHarga = db.KodePotonganHargas.ToList()[dataGridView1.CurrentRow.Index];

                NamaInput.Text = selectedPotonganHarga.Nama.ToString();
                KodeInput.Text = selectedPotonganHarga.Kode;
                PersentaseInput.Text = selectedPotonganHarga.Presentase.ToString();
                MaksimalInput.Text = selectedPotonganHarga.Maksimal.ToString();
                BerlakuInput.Value = selectedPotonganHarga.BerlakuSampai.Value;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedPotonganHarga != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.KodePotonganHargas.Remove(selectedPotonganHarga);
                    db.SaveChanges();

                    selectedPotonganHarga = null;
                    clear_input();
                    update_datagrid();
                }
                else
                {
                    selectedPotonganHarga = null;
                    clear_input();
                }

            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }
    }
}
