using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UbigPost
{
    public partial class MenuBarang: Form
    {
        Item selectedItem;
        public enum inputCondition {none=0, insert, update, delete}

        MiniKasirEntities db = new MiniKasirEntities();
        inputCondition cond = inputCondition.none;
        //int userId;
        public MenuBarang(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            mainMenuCon1.userId = this.userId;

            //categoryInput.ite
            foreach (string cat in db.Categories.Select(c => c.Name).ToList())
            {
                categoryInput.Items.Add(cat);
            }
            categoryInput.SelectedIndex = 0;

            update_datasource();
            activate_button(false);
            this.userId = userId;
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
        private void activate_button(bool condition)
        {
            InsertBtn.Enabled = !condition;
            UpdateBtn.Enabled = !condition;
            deleteBtn.Enabled = !condition;

            saveBtn.Enabled = condition;
            cancelBtn.Enabled = condition;

            nameInput.Enabled = condition;
            priceInput.Enabled = condition;
            itemCountInput.Enabled = condition;
            categoryInput.Enabled = condition;
        }

        private void clear_input()
        {
            nameInput.Text = "";
            itemCountInput.Text = "";
            priceInput.Text = "";
            categoryInput.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                DialogResult result = MessageBox.Show("Want to delete this data ?", "delete data confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    db.Items.Remove(selectedItem);
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
                Category category = db.Categories.FirstOrDefault(u => u.Name == categoryInput.Text);

                if (cond == inputCondition.insert)
                {
                    DialogResult result = MessageBox.Show("Want to add this data ?", "Add data confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        Item newItem = new Item()
                        {
                            Name = nameInput.Text,
                            Price = double.Parse(priceInput.Text),
                            ItemCount = int.Parse(itemCountInput.Text),
                            Category = category
                        };

                        db.Items.Add(newItem);
                        db.SaveChanges();
                    }

                
                }
                else if (cond == inputCondition.update)
                {
                    DialogResult result = MessageBox.Show("Want to changes this data ?", "Add data confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        
                        selectedItem.Name = nameInput.Text;
                        selectedItem.Price = double.Parse(priceInput.Text);
                        selectedItem.ItemCount = int.Parse(itemCountInput.Text);
                        selectedItem.Category = category;
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

            else if (priceInput.Text == "")
                MessageBox.Show("Please fill the price", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (!priceInput.Text.ToString().All(char.IsNumber))
                MessageBox.Show("Please fill the price with the number", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (!itemCountInput.Text.ToString().All(char.IsNumber) && 
                    !itemCountInput.Text.Contains(".") && !itemCountInput.Text.Contains(","))
                MessageBox.Show("Please fill the itemcount with the integer number", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (categoryInput.SelectedIndex == -1)
                MessageBox.Show("Please select the category input", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                Category categ = db.Categories.AsEnumerable().First(u => u.Name == rowindex.Cells["Category"].Value.ToString());
                selectedItem = db.Items.AsEnumerable().FirstOrDefault(i =>
                i.Name == rowindex.Cells["Name"].Value.ToString() &&
                i.Price == int.Parse(rowindex.Cells["Price"].Value.ToString()) &&
                i.ItemCount == double.Parse(rowindex.Cells["ItemCount"].Value.ToString()) &&
                i.Category == categ);

                nameInput.Text = selectedItem.Name;
                itemCountInput.Text = selectedItem.ItemCount.ToString();
                priceInput.Text = selectedItem.Price.ToString();
                categoryInput.SelectedIndex = categoryInput.Items.IndexOf(selectedItem.Category.Name);

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
