using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocceerseeker3
{
    public partial class TransactionCust : Form
    {
        grocerseekerEntities db = new grocerseekerEntities();
        public TransactionCust()
        {
            InitializeComponent();
        }

        private void TransactionCust_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            transactionBindingSource.Clear();
            transactionBindingSource.AddNew();

            transactionBindingSource1.Clear();
            transactionBindingSource1.AddNew();

            transactionBindingSource.DataSource = db.transactions.Where(t => t.customer_id == DataManager.userr.id && t.status != "pending").ToList();
            transactionBindingSource1.DataSource = db.transactions.Where(t => t.customer_id == DataManager.userr.id && t.status == "pending").ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (transactionBindingSource.Current is transaction t)
            {
                label5.Text = t.product.product_name;
                label10.Text = t.user1.cust_name;
                label2.Text = t.quantity.ToString();
                label4.Text = t.product.price_per_unit.ToString();
                label12.Text = t.total_price.ToString();
                label8.Text = t.delivery_cost.ToString();

                button1.Enabled = false;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (transactionBindingSource1.Current is transaction t)
            {
                label5.Text = t.product.product_name;
                label10.Text = t.user1.cust_name;
                label2.Text = t.quantity.ToString();
                label4.Text = t.product.price_per_unit.ToString();
                label12.Text = t.total_price.ToString();
                label8.Text = t.delivery_cost.ToString();

                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (transactionBindingSource1.Current is transaction t)
            {
                t.updated_at = DateTime.Now;
                t.status = "abort";
                db.SaveChanges();

                TransactionCust_Load(sender, e);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is transaction t)
            {
                if (e.ColumnIndex == productDataGridViewTextBoxColumn.Index) e.Value = t.product.price_per_unit;
                if (e.ColumnIndex == VendorNameCol.Index) e.Value = t.user.vendor_name;
                if (e.ColumnIndex == productNameCol.Index) e.Value = t.product.product_name;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is transaction t)
            {
                if (e.ColumnIndex == productDataGridViewTextBoxColumn1.Index) e.Value = t.product.price_per_unit;
                if (e.ColumnIndex == VendorNameCol1.Index) e.Value = t.user.vendor_name;
                if (e.ColumnIndex == ProductNameCol1.Index) e.Value = t.product.product_name;
            }
        }
    }
}
