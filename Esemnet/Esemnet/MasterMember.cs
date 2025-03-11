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
    public partial class MasterMember : Form
    {
        int user_id;
        EsemNetEntities db = new EsemNetEntities();
        Condition condition = Condition.none;
        Member selectedMember = null;

        public MasterMember(int user_id)
        {
            InitializeComponent();

            this.user_id = user_id;

            update_datagrid();
            set_button(false);
            ErrorText.Text = string.Empty;
        }

        private void MasterMember_Load(object sender, EventArgs e)
        {

        }


        private void set_button(bool wantChange)
        {
            addBtn.Enabled = !wantChange;
            updateBtn.Enabled = !wantChange;
            delBtn.Enabled = !wantChange;

            saveBtn.Enabled = wantChange;
            cancelBtn.Enabled = wantChange;

            NamaInput.Enabled = wantChange;
            AlamatInput.Enabled = wantChange;
            TeleponInput.Enabled = wantChange;
        }

        private void update_datagrid()
        {
            dataGridView1.DataSource = db.Members.Select(p => new
            {
                p.Nama,
                p.Telepon,
                p.Alamat,
                Status = p.MasihAktif ? "Aktif" : "Nonaktif"
            }).ToList();
        }

        private bool check_data(bool isUpdate)
        {
            if (NamaInput.Text.Trim() == "")
            {
                ErrorText.Text = "Nama tidak boleh kosong";
                return false;
            }

            if (TeleponInput.Text.Trim() == "")
            {
                ErrorText.Text = "Telepon tidak boleh kosong";
                return false;
            }

            if (!TeleponInput.Text.All(char.IsNumber))
            {
                ErrorText.Text = "Masukkan Telepon dengan menggunakan nomor";
                return false;
            }

            return true;
        }
        private void clear_input()
        {
            NamaInput.Text = string.Empty;
            AlamatInput.Text = string.Empty;
            TeleponInput.Text = string.Empty;
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click_2(object sender, EventArgs e)
        {
            condition = Condition.add;
            set_button(true);
            clear_input();
        }

        private void updateBtn_Click_1(object sender, EventArgs e)
        {
            if (selectedMember != null)
            {
                condition = Condition.update;
                set_button(true);
            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && condition == Condition.none)
            {
                ErrorText.Text = string.Empty;
                selectedMember = db.Members.ToList()[dataGridView1.CurrentRow.Index];

                NamaInput.Text = selectedMember.Nama;
                AlamatInput.Text = selectedMember.Alamat;
                TeleponInput.Text = selectedMember.Telepon;
            }
        }

        private void delBtn_Click_1(object sender, EventArgs e)
        {
            if (selectedMember != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.Members.Remove(selectedMember);
                    db.SaveChanges();

                    selectedMember = null;
                    clear_input();
                    update_datagrid();
                }
                else
                {
                    selectedMember = null;
                    clear_input();
                }

            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";
            }
        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            if (condition == Condition.add)
            {
                if (check_data(false))
                {
                    ErrorText.Text = "";

                    Member member = new Member
                    {
                        Nama = NamaInput.Text,
                        Telepon = TeleponInput.Text,
                        Alamat = AlamatInput.Text,
                        MasihAktif = true
                    };

                    db.Members.Add(member);
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

                    selectedMember.Nama = NamaInput.Text;
                    selectedMember.Telepon = TeleponInput.Text;
                    selectedMember.Alamat = AlamatInput.Text;

                    db.SaveChanges();
                    update_datagrid();

                    condition = Condition.none;
                    set_button(false);
                    clear_input();

                }
            }
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            condition = Condition.none;
            selectedMember = null;
            set_button(false);
            clear_input();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(user_id);
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            MasterData masterData = new MasterData(user_id);
            masterData.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedMember != null)
            {
                if (!selectedMember.MasihAktif)
                {
                    DialogResult result = MessageBox.Show("Are you sure to 'Active' this data?", "Activation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        selectedMember.MasihAktif = true;
                        db.SaveChanges();

                        selectedMember = null;
                        clear_input();
                        update_datagrid();
                    }
                    else
                    {
                        selectedMember = null;
                        clear_input();
                    }
                }

            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedMember != null)
            {
                if (selectedMember.MasihAktif)
                {
                    DialogResult result = MessageBox.Show("Are you sure to 'Nomnactive' this data?", "Activation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        selectedMember.MasihAktif = false;
                        db.SaveChanges();

                        selectedMember = null;
                        clear_input();
                        update_datagrid();
                    }
                    else
                    {
                        selectedMember = null;
                        clear_input();
                    }
                }

            }
            else
            {
                ErrorText.Text = "Please Select the Data to change";

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            HalamanTransaksi transaksi = new HalamanTransaksi(user_id);
            transaksi.Show();
            this.Hide();
        }
    }
}
