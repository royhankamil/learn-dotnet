using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        HovRailKioskEntities db = new HovRailKioskEntities();
        public Form1()
        {
            InitializeComponent();

            foreach (var item in db.Routes.ToList())
            {
                comboBox1.Items.Add(item.Station.stationName);
                comboBox2.Items.Add(item.Station1.stationName);
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == comboBox1.SelectedIndex)
            {
                int temp = comboBox1.SelectedIndex;

                comboBox1.SelectedIndex = comboBox2.SelectedIndex;
                comboBox2.SelectedIndex = temp;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == comboBox1.SelectedIndex)
            {
                int temp = comboBox1.SelectedIndex;

                comboBox1.SelectedIndex = comboBox2.SelectedIndex;
                comboBox2.SelectedIndex = temp;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Station departure = db.Stations.ToList()[comboBox1.SelectedIndex];
            Station arrival = db.Stations.ToList()[comboBox2.SelectedIndex];


            foreach (var item in db.Schedules.Where(r => r.departureTime == dateTimePicker1.Value && r.Route.RouteDetails.Any(rd=>rd.Station.stationID == departure.stationID) && ).ToList())
            {
                
            }
        }
    }
}
