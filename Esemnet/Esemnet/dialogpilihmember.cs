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
    public partial class dialogpilihmember: Form
    {
        public Action selectAction;
        public static int memberid=0;
        EsemNetEntities db = new EsemNetEntities();
        Member selectedMember;
        public dialogpilihmember()
        {
            InitializeComponent();

            update_datasource();
        }

        private void update_datasource()
        {
            if (textBox1.Text == "")
            {
                dataGridView1.DataSource = db.Members.Select( u => new 
                                        {
                                            u.Nama,
                                            u.Telepon,
                                            u.Alamat
                                        }).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Members.Where(m=>m.Nama.ToLower().TrimEnd()
                                        .Contains(textBox1.Text.ToLower().TrimEnd())).Select( u => new 
                                        {
                                            u.Nama,
                                            u.Telepon,
                                            u.Alamat
                                        }).ToList();
            }
        }

        private void dialogpilihmember_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedMember = db.Members.AsEnumerable().FirstOrDefault(m =>
                            m.Nama == row.Cells["Nama"].Value.ToString() &&
                            m.Alamat == row.Cells["Alamat"].Value.ToString() &&
                            m.Telepon.ToString() == row.Cells["Telepon"].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedMember == null)
            {
                MessageBox.Show("Please select the data to continue");
                return;
            }
            memberid = selectedMember.ID;
            selectAction?.Invoke();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            update_datasource();
        }
    }
}
