using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Nasional_2024
{
    public partial class TransactionVend: Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        transaction selectedTransaction;
        List<transaction> historyTransactions;
        List<transaction> pendingTransactions;
        user userr;

        public TransactionVend(int user_id)
        {
            InitializeComponent();
            userr = db.users.Find(user_id);
            ResetShowData();
            historyTransactions = db.transactions.Where(t => t.vendor_id == user_id && t.status != "pending").ToList();

            dataGridView1.DataSource = historyTransactions.Select(t => new {
                t.product.product_name,
                t.user.vendor_name,
                t.quantity,
                t.product.price_per_unit,
                t.total_price,
                t.delivery_cost,
                t.status
            }).ToList();

            pendingTransactions = db.transactions.Where(t => t.vendor_id == user_id && t.status == "pending").ToList();

            dataGridView2.DataSource = pendingTransactions
                .Select(t => new {
                    t.product.product_name,
                    t.user.vendor_name,
                    t.quantity,
                    t.product.price_per_unit,
                    t.total_price,
                    t.delivery_cost,
                    t.status
                }).ToList();

            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void TransactionVend_Load(object sender, EventArgs e)
        {

        }

        private void ResetShowData()
        {
            label9.Text = "-";
            label8.Text = "-";
            label7.Text = "-";
            label6.Text = "-";
            label11.Text = "-";
            label10.Text = "-";
        }

        private void transactionCust_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                selectedTransaction = pendingTransactions[dataGridView2.CurrentRow.Index];

                label9.Text = selectedTransaction.product.product_name;
                label8.Text = selectedTransaction.user.vendor_name;
                label7.Text = selectedTransaction.quantity.ToString();
                label6.Text = selectedTransaction.product.price_per_unit.ToString();
                label11.Text = selectedTransaction.total_price.ToString();
                label10.Text = selectedTransaction.delivery_cost.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedTransaction.status = "abort";

            product prod = selectedTransaction.product;
            prod.unit_stock += selectedTransaction.quantity;

            db.SaveChanges();


                ResetShowData();
                historyTransactions = db.transactions.Where(t => t.vendor_id == userr.id && t.status != "pending").ToList();

                dataGridView1.DataSource = historyTransactions.Select(t => new {
                    t.product.product_name,
                    t.user.vendor_name,
                    t.quantity,
                    t.product.price_per_unit,
                    t.total_price,
                    t.delivery_cost,
                    t.status
                }).ToList();

                pendingTransactions = db.transactions.Where(t => t.vendor_id == userr.id && t.status == "pending").ToList();

                dataGridView2.DataSource = pendingTransactions
                    .Select(t => new {
                        t.product.product_name,
                        t.user.vendor_name,
                        t.quantity,
                        t.product.price_per_unit,
                        t.total_price,
                        t.delivery_cost,
                        t.status
                    }).ToList();

                button1.Enabled = false;
                button2.Enabled = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                selectedTransaction = historyTransactions[dataGridView1.CurrentRow.Index];

                label9.Text = selectedTransaction.product.product_name;
                label8.Text = selectedTransaction.user.vendor_name;
                label7.Text = selectedTransaction.quantity.ToString();
                label6.Text = selectedTransaction.product.price_per_unit.ToString();
                label11.Text = selectedTransaction.total_price.ToString();
                label10.Text = selectedTransaction.delivery_cost.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedTransaction.status = "success";
            db.SaveChanges();


            ResetShowData();
            historyTransactions = db.transactions.Where(t => t.vendor_id == userr.id && t.status != "pending").ToList();

            dataGridView1.DataSource = historyTransactions.Select(t => new {
                t.product.product_name,
                t.user.vendor_name,
                t.quantity,
                t.product.price_per_unit,
                t.total_price,
                t.delivery_cost,
                t.status
            }).ToList();

            pendingTransactions = db.transactions.Where(t => t.vendor_id == userr.id && t.status == "pending").ToList();

            dataGridView2.DataSource = pendingTransactions
                .Select(t => new {
                    t.product.product_name,
                    t.user.vendor_name,
                    t.quantity,
                    t.product.price_per_unit,
                    t.total_price,
                    t.delivery_cost,
                    t.status
                }).ToList();

            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
}
