using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FoodCourt
{
    public partial class ManageMenu : Form
    {
        public enum InputConditon { None=default, Insert, Update, Delete}
        FoodcourtEntities db = new FoodcourtEntities();
        InputConditon inputConditon;
        Menus selectedMenu = new Menus();
        public ManageMenu()
        {
            InitializeComponent();

            errorText.Text = "";
            var menus = db.Menus.ToList();
            foreach (var menu in menus)
            {
                if (!categoryInput.Items.Contains(menu.Categories.Name))
                {
                    categoryInput.Items.Add(menu.Categories.Name);
                }
            }

            Refresh();

            Clear();

            EnabledInput(false);

        }

        private void EnabledInput(bool condition)
        {
            menuNameInput.Enabled = condition;
            categoryInput.Enabled = condition;
            descriptionInput.Enabled = condition;
            priceInput.Enabled = condition;

            insertButton.Enabled = !condition;
            updateButton.Enabled = !condition;
            deleteButton.Enabled = !condition;
            saveButton.Enabled = condition;
            cancelButton.Enabled = condition;

        }



        private void ManageMenu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManageMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            string query = searchInput.Text.Trim().ToLower();

            if (searchInput.Text != "")
            {
                dataGridView1.DataSource = db.Menus.Where(m => m.Name.ToLower().Contains(searchInput.Text)|| m.Categories.Name.ToLower().Contains(searchInput.Text))
                    .AsEnumerable().Select(u=> new
                    {
                        Menu = u.Name,
                        Category = u.Categories.Name,
                        u.Description,
                        Price = u.Price.ToString("C").Replace("$", "Rp ")
                    }).ToList();
            }
            else
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            dataGridView1.DataSource = db.Menus.AsEnumerable().Select(u => new
            {
                Menu = u.Name,
                Category = u.Categories.Name,
                u.Description,
                Price = u.Price.ToString("C").Replace("$", "Rp ")
            }).ToList();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            inputConditon = InputConditon.Insert;
            EnabledInput(true);

            Clear();
        }

        private void Clear()
        {
            menuNameInput.Text = "";
            categoryInput.Text = "Breakfast";
            descriptionInput.Text = "";
            priceInput.Value = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Clear();
            EnabledInput(false);
            inputConditon = InputConditon.None;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            errorText.Text = ""; 
            if (menuNameInput.Text == "")
            {
                errorText.Text = "Please fill the menu name";
                return;
            }

            if (descriptionInput.Text == "")
            {
                errorText.Text = "Please fill the description of the menu";
                return;
            }

            if (priceInput.Value <= 0)
            {
                errorText.Text = "Please set value price minimal 1";
                return;
            }

            if (inputConditon == InputConditon.Insert)
            {
                Menus menu = new Menus();

                menu.Name = menuNameInput.Text;
                Categories category = db.Categories.First(x => x.Name == categoryInput.Text);
                menu.Categories = category;
                menu.Description = descriptionInput.Text;
                menu.Price = Convert.ToDouble(priceInput.Value);

                db.Menus.Add(menu);
                db.SaveChanges();
                Clear();
                EnabledInput(false);
                inputConditon = InputConditon.None;
                Refresh();
            }
            else if (inputConditon == InputConditon.Update)
            {
                selectedMenu.Name = menuNameInput.Text;
                Categories category = db.Categories.First(x => x.Name == categoryInput.Text);
                selectedMenu.Categories = category;
                selectedMenu.Description = descriptionInput.Text;
                selectedMenu.Price = Convert.ToDouble(priceInput.Value);

                db.SaveChanges();
                Clear();
                EnabledInput(false);
                inputConditon = InputConditon.None;
                Refresh();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedMenu != null)
            {

                inputConditon = InputConditon.Update;
                EnabledInput(true);
                errorText.Text = "";
            }
            else
            {
                errorText.Text = "Please Select the data";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && inputConditon != InputConditon.Insert)
            {
                string menuName = dataGridView1.CurrentRow.Cells["Menu"].Value.ToString(), desc = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
                selectedMenu = db.Menus.First(u=> u.Name == menuName);

                menuNameInput.Text = selectedMenu.Name;
                categoryInput.Text = selectedMenu.Categories.Name;
                descriptionInput.Text = selectedMenu.Description;
                priceInput.Value = Convert.ToDecimal(selectedMenu.Price);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedMenu != null)
            {
                inputConditon = InputConditon.Delete;
                errorText.Text = "";

                DialogResult result =  MessageBox.Show("Confirm To Delete This Data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.Menus.Remove(selectedMenu);
                    db.SaveChanges();

                    Clear();
                    inputConditon = InputConditon.None;
                    Refresh();
                }

            }
            else
            {
                errorText.Text = "Please Select the data";
            }
        }
    }
}
