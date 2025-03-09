using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UbigPost.MenuBarang;

namespace UbigPost
{
    public partial class MenuCategory: Form
    {
        Category selectedItem;
        public enum inputCondition { none = 0, insert, update, delete }

        MiniKasirEntities db = new MiniKasirEntities();
        inputCondition cond = inputCondition.none;
        //int userId;
        public MenuCategory(int userId)
        {
            //InitializeComponent();

            this.userId = userId;
            InitializeComponent();
            mainMenuCon1.userId = this.userId;

            //categoryInput.ite

            update_datasource();
            activate_button(false);
            this.userId = userId;
        }

        private void MenuCategory_Load(object sender, EventArgs e)
        {

        }

        private void update_datasource()
        {
            if (SearchInput.Text == "")
            {
                dataGridView1.DataSource = db.Categories.Select(u=> new {u.ID, u.Name}).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Categories.Where(i => i.Name.ToLower().TrimEnd()
                    .Contains(SearchInput.Text.ToLower().Trim()))
                    .Select(u => new { u.ID, u.Name }).ToList();
            }
        }
        private void activate_button(bool condition)
        {
            InsertBtn.Enabled = !condition;
            UpdateBtn.Enabled = !condition;
            deleteBtn.Enabled = !condition;

            saveBtn.Enabled = condition;
            cancelBtn.Enabled = condition;

            nameInput.Enabled = condition;
        }

        private void clear_input()
        {
            nameInput.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                DialogResult result = MessageBox.Show("Want to delete this data ?", "delete data confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    db.Categories.Remove(selectedItem);
                    db.SaveChanges();

                    update_datasource();
                    clear_input();
                    activate_button(false);
                    selectedItem = null;
                }
            }
            else
                MessageBox.Show("Please select the data to delete", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void MenuBarang_Load(object sender, EventArgs e)
        {

        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            clear_input();
            activate_button(true);

            cond = inputCondition.insert;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                activate_button(true);

                cond = inputCondition.update;
            }
            else
                MessageBox.Show("Please select the data to update", "invalid update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                if (cond == inputCondition.insert)
                {
                    DialogResult result = MessageBox.Show("Want to add this data ?", "Add data confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        Category newCategory = new Category()
                        {
                            Name = nameInput.Text
                        };

                        db.Categories.Add(newCategory);
                        db.SaveChanges();
                    }


                }
                else if (cond == inputCondition.update)
                {
                    DialogResult result = MessageBox.Show("Want to changes this data ?", "Add data confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        selectedItem.Name = nameInput.Text;
                        db.SaveChanges();
                    }


                }

                update_datasource();
                clear_input();
                activate_button(false);
                selectedItem = null;
            }
        }

        private bool checkData()
        {
            if (nameInput.Text == "")
                MessageBox.Show("Please fill the name", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                return true;
            }

            return false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            clear_input();
            cond = inputCondition.none;
            selectedItem = null;
            activate_button(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DataGridViewRow rowindex = dataGridView1.Rows[e.RowIndex];
                selectedItem = db.Categories.AsEnumerable().First(u => u.ID == int.Parse(rowindex.Cells["ID"].Value.ToString()));
                
                nameInput.Text = selectedItem.Name;

            }
        }

        private void Panel_HideMainForm()
        {
            this.Hide();
        }

        private void SearchInput_TextChanged(object sender, EventArgs e)
        {
            update_datasource();
        }
    }
}
