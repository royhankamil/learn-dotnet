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
    public partial class CouponForm: Form
    {
        Coupon selectedItem;
        public enum inputCondition { none = 0, insert, update, delete }

        MiniKasirEntities db = new MiniKasirEntities();
        inputCondition cond = inputCondition.none;
        //int userId;
        public CouponForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            mainMenuCon1.userId = this.userId;
            mainMenuCon1.HideMainForm += Panel_HideMainForm;

            update_datasource();
            activate_button(false);
            this.userId = userId;
        }

        private void update_datasource()
        {
            if (SearchInput.Text == "")
            {
                dataGridView1.DataSource = db.Coupons.AsEnumerable().Select(u => new
                {
                    u.Code,
                    u.DiscountPercentase,
                    StartDate = u.StartDate.ToString("dd MMM yyyy"),
                    EndDate = u.EndDate.ToString("dd MMM yyyy")
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Coupons.Where(i => i.Code.ToLower().TrimEnd()
                    .Contains(SearchInput.Text.ToLower().Trim())).AsEnumerable().Select(u => new
                    {
                        u.Code,
                        u.DiscountPercentase,
                        StartDate = u.StartDate.ToString("dd MMM yyyy"),
                        EndDate = u.EndDate.ToString("dd MMM yyyy")
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

            CodeInput.Enabled = condition;
            DiscountInput.Enabled = condition;
            StartDateInput.Enabled = condition;
            endDateInput.Enabled = condition;
        }

        private void clear_input()
        {
            CodeInput.Text = "";
            DiscountInput.Value = 0;
            StartDateInput.Value = DateTime.Now;
            endDateInput.Value = DateTime.Now.AddMonths(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                DialogResult result = MessageBox.Show("Want to delete this data ?", "delete data confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    db.Coupons.Remove(selectedItem);
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

                        Coupon newCoupon = new Coupon()
                        {
                            Code = CodeInput.Text,
                            DiscountPercentase = (int)DiscountInput.Value,
                            StartDate = StartDateInput.Value,
                            EndDate = endDateInput.Value
                        };

                        db.Coupons.Add(newCoupon);
                        db.SaveChanges();
                    }


                }
                else if (cond == inputCondition.update)
                {
                    DialogResult result = MessageBox.Show("Want to changes this data ?", "Add data confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        selectedItem.Code = CodeInput.Text;
                        selectedItem.DiscountPercentase = (int)DiscountInput.Value;
                        selectedItem.StartDate = StartDateInput.Value;
                        selectedItem.EndDate = endDateInput.Value;
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
            if (CodeInput.Text == "")
                MessageBox.Show("Please fill the Code", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (CodeInput.Text.Any(char.IsLower) || !CodeInput.Text.All(char.IsLetterOrDigit))
                MessageBox.Show("Please fill the Code with Uppercase", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (DiscountInput.Value < 0 || DiscountInput.Value > 100)
                MessageBox.Show("The Discount (%) input only accepts positive numbers in the range 0–100", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (StartDateInput.Value > endDateInput.Value)
                MessageBox.Show("End Date being greater than the Start Date.", "invalid insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                selectedItem = db.Coupons.AsEnumerable().FirstOrDefault(i =>
                i.Code == rowindex.Cells["Code"].Value.ToString());

                CodeInput.Text = selectedItem.Code;
                DiscountInput.Value = selectedItem.DiscountPercentase;
                StartDateInput.Value = selectedItem.StartDate;
                endDateInput.Value = selectedItem.EndDate;

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
