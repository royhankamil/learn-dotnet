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
    public partial class transactionCust: Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        transaction selectedTransaction;
        List<transaction> historyTransactions;
        List<transaction> pendingTransactions;
        public transactionCust(int user_id)
        {
            InitializeComponent();

            ResetShowData();
            historyTransactions = db.transactions.Where(t => t.customer_id == user_id && t.status != "pending").ToList();

            dataGridView1.DataSource = historyTransactions.Select(t => new {
                    t.product.product_name,
                    t.user.vendor_name,
                    t.quantity,
                    t.product.price_per_unit,
                    t.total_price,
                    t.delivery_cost
                });

            pendingTransactions = db.transactions.Where(t => t.customer_id == user_id && t.status == "pending").ToList();

            dataGridView2.DataSource = pendingTransactions
                .Select(t => new {
                t.product.product_name,
                t.user.vendor_name,
                t.quantity,
                t.product.price_per_unit,
                t.total_price,
                t.delivery_cost
            });

            button1.Enabled = false;
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
            if (dataGridView1.CurrentRow.Index != -1)
            {
                selectedTransaction = historyTransactions[dataGridView1.CurrentRow.Index];
            }
        }
    }
}
