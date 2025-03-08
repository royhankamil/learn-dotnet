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
    public partial class MenuBarang: Form
    {
        MiniKasirEntities db = new MiniKasirEntities();
        public MenuBarang()
        {
            InitializeComponent();

            update_datasource();
        }

        private void update_datasource()
        {
            if (SearchInput.Text == "")
            {
                dataGridView1.DataSource = db.Items.Select(u => new
                            {
                                u.Name,
                                u.Price,
                                u.ItemCount,
                                Category = u.Category.Name
                            }).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Items.Where(i => i.Name.ToLower().TrimEnd()
                    .Contains(SearchInput.Text.ToLower().Trim())).Select(u => new
                        {
                            u.Name,
                            u.Price,
                            u.ItemCount,
                            Category = u.Category.Name
                        }).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void MenuBarang_Load(object sender, EventArgs e)
        {

        }
    }
}
