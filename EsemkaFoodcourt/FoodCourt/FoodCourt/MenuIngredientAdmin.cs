using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;

namespace FoodCourt
{
    public partial class MenuIngredientAdmin : Form
    {
        FoodcourtEntities db = new FoodcourtEntities();


        public MenuIngredientAdmin()
        {
            InitializeComponent();

            ChooseIngredient.DataSource = db.Ingredients.Select(u=>u.Name).ToList();
            unitInput.DataSource = db.Units.Select(u=>u.Name).ToList();
            dataGridView1.DataSource = db.Menus.Select(x=> new { Menu = x.Name }).ToList();

            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.HeaderText = "Action";
            link.Text = "Edit Ingredients";
            link.Name = "Action";
            link.UseColumnTextForLinkValue = true;
            dataGridView1.Columns.Add(link);

            errorText.Text = "";

            groupBox1.Enabled = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuIngredientAdmin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = textBox1.Text.Trim().ToLower();
            //if (query != "")
                dataGridView1.DataSource = db.Menus.Where(u=>u.Name.ToLower().Contains(query)).Select(x => new { Menu = x.Name }).ToList();

            //else
            //    Refresh();
        }

        private void Refresh()
        {
            dataGridView1.DataSource = db.Menus.Select(x => new { x.Name }).ToList();

            //dataGridView1.column
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                string name = dataGridView1.Rows[e.RowIndex].Cells["Menu"].Value.ToString();
                Menus menu = db.Menus.First(x => x.Name == name);
                dataGridView2.DataSource = (from m in db.Menus
                                            join mi in db.MenuIngredients on m.ID equals mi.MenuID
                                            join i in db.Ingredients on mi.IngredientID equals i.ID
                                            join u in db.Units on mi.UnitID equals u.ID
                                            where m.ID == menu.ID
                                            select new
                                            {
                                                IngredientName = i.Name,
                                                mi.Qty,
                                                Unit = u.Name
                                            }).ToList();
                if (!dataGridView2.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
                    removeButton.Text = "Remove";
                    removeButton.HeaderText = "Action";
                    removeButton.Name = "removeBUtton";
                    removeButton.UseColumnTextForButtonValue = true;
                    dataGridView2.Columns.Add(removeButton);

                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Action")
                {
                    groupBox1.Enabled = true;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            ChooseIngredient.SelectedIndex = 0;
            unitInput.SelectedIndex = 0;
            qtyInput.Value = 0;
            errorText.Text = "";
            dataGridView2.DataSource = null;
        }
    }
}
