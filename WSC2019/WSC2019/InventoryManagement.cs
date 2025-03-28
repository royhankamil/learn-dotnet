using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019
{
    public partial class InventoryManagement : Form
    {
        Session4Entities db = new Session4Entities();

        public InventoryManagement()
        {
            InitializeComponent();
            foreach (var item in db.OrderItems.ToList())
            {
                dataGridView1.Rows.Add(item.Part.Name, item.Order.TransactionType.Name, 
                            item.Order.Date, item.Amount, item.Order.Warehouse?.Name, 
                            item.Order.Warehouse1?.Name, "Edit Remove");
            }
        }

        private void InventoryManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
