using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hovlibrary
{
    public partial class MasterMember: Form
    {
        Member selectedMember;

        HovLibraryEntities db = new HovLibraryEntities();
        public MasterMember()
        {
            InitializeComponent();

            foreach (var item in db.Members.ToList())
            {
                dataGridView1.Rows.Add(item.id, item.name, item.phone_number,
                                    item.email, item.city_of_birth, item.date_of_birth,
                                    item.address, item.gender, "Edit");
            }

            SetEnableInput(false);
        }

        private void MasterMember_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SetEnableInput(bool condition)
        {
            textBox1.Enabled = condition;
            textBox2.Enabled = condition;
            textBox3.Enabled = condition;
            textBox4.Enabled = condition;
            textBox5.Enabled = condition;
            dateTimePicker1.Enabled = condition;
            radioButton1.Enabled = condition;
            radioButton2.Enabled = condition;
            button1.Enabled = condition;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                if (button1.Enabled)
                {
                    DialogResult result = MessageBox.Show("Are you sure to discard changes?", "", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)
                        return;
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "EditCol")
                {
                    SetEnableInput(true);
                }


                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selectedMember = db.Members.Find(id);

                textBox1.Text = selectedMember.name;
                textBox2.Text = selectedMember.phone_number;
                textBox3.Text = selectedMember.email;
                textBox4.Text = selectedMember.address;
                textBox5.Text = selectedMember.city_of_birth;
                dateTimePicker1.Value = selectedMember.date_of_birth;

                if (selectedMember.gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
