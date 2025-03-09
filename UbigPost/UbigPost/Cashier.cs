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
    public partial class Cashier: Form
    {
        class ItemDetail
        {
            public string Name;
            public double Price;
            public int CountItem;
            public double subtotal;
        }

        MiniKasirEntities db = new MiniKasirEntities();
        List<ItemDetail> Items = new List<ItemDetail>();

        int userId;
        public Cashier(int userId)
        {
            InitializeComponent();
            mainMenuCon1.userId = userId;
            mainMenuCon1.HideMainForm += PanelHide;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTransaction form = new FormTransaction();
            form.pilih += MemilihItem;
            form.Show();

        }

            private void MemilihItem()
            {
                Item item = db.Items.Find(FormTransaction.itemId);
                ItemDetail addedItem = Items.FirstOrDefault(u => u.Name == item.Name);
                //MessageBox.Show(FormTransaction.itemId.ToString(), item.Name);

                if (addedItem != default)
                {
                    //addedItem.CountItem += 1;
                    int countitem = addedItem.CountItem + 1;
                    double subtotal = countitem * addedItem.Price;
                    ItemDetail newItem = new ItemDetail()
                    {
                        Name = addedItem.Name,
                        Price = addedItem.Price,
                        CountItem = countitem,
                        subtotal = subtotal
                    };
                    Items.Remove(addedItem);
                    Items.Add(newItem);
                }

                else
                {
                    ItemDetail newItem = new ItemDetail()
                    {
                        Name = item.Name,
                        Price = item.Price,
                        CountItem = 1,
                        subtotal = item.Price
                    };
                    Items.Add(newItem);
                }

                dataGridView1.Rows.Clear();
                foreach(var dat in Items)
                {
                    dataGridView1.Rows.Add(dat.Name, dat.Price, dat.CountItem, dat.subtotal, "delete");
                }

                priceInput.Text = Items.Select(i => i.subtotal).Sum().ToString();
            //dataGridView1.Columns["Name"].
        }

        private void PanelHide()
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                ItemDetail addedItem = Items.FirstOrDefault(u => u.Name == dataGridView1.Rows[e.RowIndex].Cells["Namem"].Value.ToString());
                DialogResult result = MessageBox.Show("Are you sure want to delete this?", "deleteConfirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Items.Remove(addedItem);
                }
                Item item = db.Items.FirstOrDefault(i => i.Name == addedItem.Name);
                item.ItemCount += 1;
                db.SaveChanges();

                dataGridView1.Rows.Clear();
                foreach (var dat in Items)
                {
                    dataGridView1.Rows.Add(dat.Name, dat.Price, dat.CountItem, dat.subtotal, "delete");
                }

                priceInput.Text = Items.Select(i => i.subtotal).Sum().ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Items.Count <= 0)
            {
                MessageBox.Show("Basket cannot be empty, item quantity matches stock.", "Error item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Coupon cupon = null;
            if (CuponInput.Text != "")
            {
                cupon = db.Coupons.FirstOrDefault(c => c.Code == CuponInput.Text);
                if (cupon == default)
                {
                    MessageBox.Show("Cannot Find Coupon with given code", "Coupon not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DateTime.Now < cupon.StartDate || DateTime.Now > cupon.EndDate) 
                {
                    MessageBox.Show("This Coupon is Expired or not started yet", "Coupon expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            double totalPrice = Items.Select(i => i.subtotal).Sum();

            if (cupon != null)
            {
                totalPrice -= totalPrice * cupon.DiscountPercentase / 100;
            }

            Transaction transaction = new Transaction()
            {
                Date = DateTime.Now,
                Coupon = cupon,
                TotalPrice = totalPrice
            };

            db.Transactions.Add(transaction);

            foreach (var itemo in Items)
            {
                Item item = db.Items.FirstOrDefault(i => i.Name == itemo.Name);
                DetailTransaction detail = new DetailTransaction()
                {
                    Item = item,
                    CountItem = itemo.CountItem,
                    SubTotal = itemo.subtotal,
                    Transaction = transaction
                };
                db.DetailTransactions.Add(detail);
            }

            db.SaveChanges();

        }

    }
}
