using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Esemnet.MasterPaket;

namespace Esemnet
{
    public partial class MasterKomputer : Form
    {
        int user_id;
        EsemNetEntities db = new EsemNetEntities();
        Condition condition = Condition.none;
        Komputer selectedKomputer = null;

        public MasterKomputer(int user_id)
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

            NomorInput.Enabled = wantChange;
            jenisInput.Enabled = wantChange;
            MerkInput.Enabled = wantChange;
        }

        private void update_datagrid()
        {
            dataGridView1.DataSource = db.Komputers.Select(p => new
            {
                p.Nomor,
                p.Merek,
                Jenis = p.Jeni == null ? "" : p.Jeni.Jenis
            }).ToList();
        }

        private bool check_data(bool isUpdate)
        {
            if (NomorInput.Text.Trim() == "")
            {
                ErrorText.Text = "Nama tidak boleh kosong";
                return false;
            }

            if (MerkInput.Text.Trim() == "")
            {
                ErrorText.Text = "Merek tidak boleh kosong";
                return false;
            }
            
            if (jenisInput.Text == "")
            {
                ErrorText.Text = "Jenis tidak boleh kosong";
                return false;
            }

            if (!NomorInput.Text.All(char.IsNumber))
            {
                ErrorText.Text = "Masukkan angka untuk Nomor";
                return false;
            }

            var nomor = int.Parse(NomorInput.Text);
            var komp = db.Komputers.FirstOrDefault(k => k.Nomor == nomor);

            if (!isUpdate && komp != default)
            {
                ErrorText.Text = "Angka yang anda inputkan telah terdaftar";
                return false;
            }
            else if (isUpdate && komp != default && komp.ID != selectedKomputer.ID)
            {
                ErrorText.Text = "Angka yang anda inputkan telah terdaftar";
                return false;
            }

            return true;
        }
        private void clear_input()
        {
            NomorInput.Text = string.Empty;
            jenisInput.Text = string.Empty;
            MerkInput.Text = string.Empty;
        }

        private void MasterKomputer_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            condition = Condition.add;
            set_button(true);
            clear_input();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedKomputer != null)
            {
                condition = Condition.update;
                set_button(true);
            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedKomputer != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.Komputers.Remove(selectedKomputer);
                    db.SaveChanges();

                    selectedKomputer = null;
                    clear_input();
                    update_datagrid();
                }
                else
                {
                    selectedKomputer = null;
                    clear_input();
                }

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

                    Jeni jenis = db.Jenis.FirstOrDefault(u => u.Jenis == jenisInput.Text);
                    Komputer komputer = new Komputer
                    {
                        Nomor = int.Parse(NomorInput.Text),
                        IDJenis = jenis.ID,
                        Jeni = jenis,
                        Merek = MerkInput.Text
                    };

                    db.Komputers.Add(komputer);
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

                    selectedKomputer.Nomor = int.Parse(NomorInput.Text);
                    selectedKomputer.Merek = MerkInput.Text;
                    selectedKomputer.IDJenis = db.Jenis.FirstOrDefault(u => u.Jenis == jenisInput.Text).ID;

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
            selectedKomputer = null;
            set_button(false);
            clear_input();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && condition == Condition.none)
            {
                ErrorText.Text = string.Empty;
                selectedKomputer = db.Komputers.ToList()[dataGridView1.CurrentRow.Index];

                NomorInput.Text = selectedKomputer.Nomor.ToString();
                jenisInput.Text = selectedKomputer.Jeni == null ? "" : selectedKomputer.Jeni.Jenis;
                MerkInput.Text = selectedKomputer.Merek;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
