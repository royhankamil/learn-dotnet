using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbigPost
{
    public partial class FormTransaction: Form
    {
        public Action pilih;
        public static int itemId { get; private set; }
        MiniKasirEntities db = new MiniKasirEntities();

        public FormTransaction()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Items.Select(i => new
            {
                i.Name,
                i.Price,
                i.ItemCount,
                Category = i.Category.Name,
            }).ToList();

            DataGridViewButtonColumn action = new DataGridViewButtonColumn();
            action.HeaderText = "Action";
            action.Name = "Action";
            action.Text = "Pilih";
            action.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(action);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {

        }

        private void SearchInput_TextChanged(object sender, EventArgs e)
        {
            if (SearchInput.Text != "")
            {
                dataGridView1.DataSource = db.Items.Where(i=>i.Name.TrimEnd().ToLower().Contains(SearchInput.Text.ToLower()))
                    .Select(i => new
                {
                    i.Name,
                    i.Price,
                    i.ItemCount,
                    Category = i.Category.Name,
                }).ToList();

            }
            else
            {
                dataGridView1.DataSource = db.Items
                    .Select(i => new
                    {
                        i.Name,
                        i.Price,
                        i.ItemCount,
                        Category = i.Category.Name,
                    }).ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                
                Item item = db.Items.AsEnumerable()
                    .FirstOrDefault(u => u.Name == dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString());
                if (item.ItemCount > 0)
                {
                    itemId = item.ID;
                    item.ItemCount -= 1;
                    db.SaveChanges();
                    pilih?.Invoke();
                }
                else
                {
                    MessageBox.Show("This item is empty", "Error item", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
