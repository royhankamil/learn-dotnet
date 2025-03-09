using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbigPost
{
    public partial class MainMenuCon: UserControl
    {
        public Action HideMainForm;
        public int userId { get; set; }

        public MainMenuCon()
        {
            InitializeComponent();

        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuCategory menuCategory = new MenuCategory(userId);
            menuCategory.Show();
            HideMainForm?.Invoke();
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            HideMainForm?.Invoke();
        }

        private void MainMenuCon_Load(object sender, EventArgs e)
        {

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(userId);
            menu.Show();
            HideMainForm?.Invoke();
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuBarang barang = new MenuBarang(userId);
            barang.Show();
            HideMainForm?.Invoke();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorySalesForm history = new HistorySalesForm(userId);
            history.Show();
            HideMainForm?.Invoke();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashier cashier = new Cashier(userId);
            cashier.Show();
            HideMainForm?.Invoke();
        }

        private void cuponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CouponForm coupon = new CouponForm(userId);
            coupon.Show();
            HideMainForm?.Invoke();
        }
    }
}
