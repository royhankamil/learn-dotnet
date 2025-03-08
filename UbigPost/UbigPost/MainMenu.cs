using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UbigPost
{
    public partial class MainMenu: Form
    {
        MiniKasirEntities db = new MiniKasirEntities();
        int userId;
        public MainMenu(int userId)
        {
            InitializeComponent();

            this.userId = userId;
            User user = db.Users.Find(userId);

            Welcome.Text = $"Welcome {user.FirstName} {user.LastName}";

            TotalItem.Text = db.Items.ToList().Count().ToString();

            SalesToday.Text = db.Coupons.AsEnumerable().Where(s => s.StartDate > DateTime.Now
                                && s.EndDate < DateTime.Now).ToList().Count().ToString();

            var AllIncome = db.Transactions.AsEnumerable().Where(t => t.Date.Date == DateTime.Now.Date)
                            .Select(t => t.TotalPrice).ToList();
            Income.Text = "Rp. " + AllIncome.Sum().ToString("C");

            chart1.Series.Clear();
            Series series = new Series("TOP 5 ITEMS")
            {
                ChartType = SeriesChartType.Pie
            };

            var itemsTMonth = db.DetailTransactions.AsEnumerable()
                .Where(t => t.Transaction.Date.Month == DateTime.Now.Month 
                && t.Transaction.Date.Year == DateTime.Now.Year).ToList();
            var uniqueItem = itemsTMonth.Select(u => u.Item.Name).Distinct();

            Dictionary<string, int> itemsCount = new Dictionary<string, int>();
            foreach(var i in uniqueItem)
            {
                itemsCount[i] = itemsTMonth.Where(u => u.Item.Name == i).Select(u=>u.CountItem).Sum();
            }

            int counter = 0;

            foreach (var i in itemsCount.Keys)
            {
                if (counter >= 5)
                    break;

                series.Points.AddXY(i, itemsCount[i]);

                counter++;
            }

            chart1.Series.Add(series);

            chart2.Series.Clear();
            Series series2 = new Series();

            for (short i = 6; i >= 0; i--)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-i);
                double totalPrice = db.Transactions.AsEnumerable().Where(t => t.Date.Month == lastMonth.Date.Month
                                    && t.Date.Year == lastMonth.Year).Select(t => t.TotalPrice).Sum();

                series2.Points.AddXY(lastMonth.ToString("MMMM"), totalPrice);
            }

            chart2.Series.Add(series2);

            

            //contextMenuStrip1.Show(panel1, new Point(2, 2));
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
