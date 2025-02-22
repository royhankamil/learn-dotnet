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
    public enum Condition { none, add, update};
    public partial class MasterPaket : Form
    {
        public Condition condition = Condition.none;
        EsemNetEntities db = new EsemNetEntities();
        Paket selectedPaket;
        int user_id;
        public MasterPaket(int user_id)
        {
            InitializeComponent();

            set_button(false);

            ErrorText.Text = "";

            this.user_id = user_id;

            dataGridView1.DataSource = db.Pakets.Select(p => new
            {
                p.Nama,
                Jenis = p.Jeni == null ?  "" : p.Jeni.Jenis,
                p.HargaPerJam
            }).ToList();
        }

        private void MasterPaket_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            condition = Condition.add;
            set_button(true);
            clear_input();
        }

        private void set_button(bool wantChange)
        {
            addBtn.Enabled = !wantChange;
            updateBtn.Enabled = !wantChange;
            delBtn.Enabled = !wantChange;

            saveBtn.Enabled = wantChange;
            cancelBtn.Enabled = wantChange;

            NamaInput.Enabled = wantChange;
            jenisInput.Enabled = wantChange;
            HargaInput.Enabled = wantChange;
        }

        private void update_datagrid()
        {
            dataGridView1.DataSource = db.Pakets.Select(p => new
            {
                p.Nama,
                Jenis = p.Jeni == null ? "" : p.Jeni.Jenis,
                p.HargaPerJam
            }).ToList();
        }

        private bool check_data()
        {
            if (NamaInput.Text.Trim() == "")
            {
                ErrorText.Text = "Nama tidak boleh kosong";
                return false;
            }

            if (HargaInput.Text.Trim() == "")
            {
                ErrorText.Text = "Harga Per Jam tidak boleh kosong";
                return false;
            }

            if (!HargaInput.Text.All(char.IsNumber))
            {
                ErrorText.Text = "Masukkan angka untuk Harga Per Jam";
                return false;
            }

            if (int.Parse(HargaInput.Text) < 5000)
            {
                ErrorText.Text = "Harga Per Jam minimal 5000";
                return false;
            }

            return true;
        }
        private void clear_input()
        {
            NamaInput.Text = string.Empty;
            jenisInput.Text = string.Empty;
            HargaInput.Text = string.Empty;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedPaket != null)
            {
                condition = Condition.update;
                set_button(true);
            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && condition == Condition.none)
            {
                ErrorText.Text = string.Empty;
                selectedPaket = db.Pakets.ToList()[dataGridView1.CurrentRow.Index];

                NamaInput.Text = selectedPaket.Nama;
                jenisInput.Text = selectedPaket.Jeni == null ? "" : selectedPaket.Jeni.Jenis;
                HargaInput.Text = selectedPaket.HargaPerJam.ToString();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (condition == Condition.add)
            {
                if (check_data())
                {
                    ErrorText.Text = "";

                    Jeni jenis = db.Jenis.FirstOrDefault(u => u.Jenis == jenisInput.Text);
                    Paket paket = new Paket
                    {
                        Nama = NamaInput.Text,
                        IDJenis = jenis.ID,
                        Jeni = jenis,
                        HargaPerJam = double.Parse(HargaInput.Text)
                    };

                    db.Pakets.Add(paket);
                    db.SaveChanges();
                    update_datagrid();

                    condition = Condition.none;
                    set_button(false);
                    clear_input();
                }
            }
            else if (condition == Condition.update)
            {
                if (check_data())
                {
                    ErrorText.Text = "";

                    selectedPaket.Nama = NamaInput.Text;
                    selectedPaket.HargaPerJam = double.Parse(HargaInput.Text);
                    selectedPaket.IDJenis = db.Jenis.FirstOrDefault(u => u.Jenis == jenisInput.Text).ID;

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
            selectedPaket = null;
            set_button(false);
            clear_input();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedPaket != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.Pakets.Remove(selectedPaket);
                    db.SaveChanges();

                    selectedPaket = null;
                    clear_input();
                    update_datagrid();
                }
                else
                {
                    selectedPaket = null;
                    clear_input();
                }

            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
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
    }
}
