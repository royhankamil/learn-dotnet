using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UbigPost
{
    public partial class HistorySalesForm: Form
    {
        int userId;
        MiniKasirEntities db = new MiniKasirEntities();
        public HistorySalesForm(int userId)
        {

            InitializeComponent();
            this.userId = userId;
            mainMenuCon1.userId = userId;

            fromDate.Value = DateTime.Now.AddMonths(-7);
            toDate.Value = DateTime.Now;

            update_datasource();

        }

        private void update_datasource()
        {
            if (toDate.Value > fromDate.Value)
            {
                MessageBox.Show("Error rule is violed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fromDate.Value = DateTime.Now.AddMonths(-7);
                toDate.Value = DateTime.Now;
                return;
            }
            dataGridView1.DataSource = db.DetailTransactions.AsEnumerable()
                                       .Where(t => t.Transaction.Date >= fromDate.Value && t.Transaction.Date <= toDate.Value)
                                       .Select(u => new
                                       {
                                           u.Item.Name,
                                           u.CountItem,
                                           u.SubTotal,
                                           u.Transaction.TotalPrice,
                                           u.Transaction.Date
                                       }).ToList();

            dataGridView1.Columns["SubTotal"].HeaderText = "Sub Total";
            dataGridView1.Columns["TotalPrice"].HeaderText = "Total Price";
        }

        private void HidePanel()
        {
            this.Hide();
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            update_datasource();

        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void fromDate_ValueChanged_1(object sender, EventArgs e)
        {
            update_datasource();
        }
    }
}
