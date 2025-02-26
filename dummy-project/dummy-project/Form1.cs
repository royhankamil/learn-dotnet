using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace dummy_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] perusahaan = {"Monopoli", "Banyumas", "Air Tawar", "Bukan Aqua"};
            int[] penjualan = {8000, 1200, 1300, 3000};
            chart1.Series.Clear();
            chart1.Series.Add("Penjualan");
            for (int i=0; i< perusahaan.Length; i++)
            {
                chart1.Series["Penjualan"].Points.AddXY(perusahaan[i], penjualan[i]);
            }


            chart1.ChartAreas[0].AxisY.LabelStyle.Format = new CultureInfo("id-ID").NumberFormat.CurrencySymbol + "#, ##0";

            chart2.Series.Clear();
            chart2.Series.Add("Persentase");
            chart2.Series["Persentase"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < perusahaan.Length; i++)
            {
                chart2.Series["Persentase"].Points.AddXY(perusahaan[i], penjualan[i]);

            }

            //chart2.Series["Persentase"].IsValueShownAsLabel = true;
            //chart2.Series["Persentase"].LabelFormat = "{0}%";\
            

            chart3.Series.Clear();
            chart3.Series.Add("Tren Penjualan");

            chart3.Series["Tren Penjualan"].ChartType = SeriesChartType.Line;
            for (int i = 0; i < perusahaan.Length; i++)
            {
                chart3.Series["Tren Penjualan"].Points.Add(penjualan[i]);
            }

            chart3.Series["Tren Penjualan"].MarkerStyle = MarkerStyle.Circle;

            chart4.Series.Clear();
            chart4.Series.Add("Penjualan");
            chart4.Series["Penjualan"].ChartType = SeriesChartType.Point;
            for(int i = 0; i < perusahaan.Length; i++)
            {
                chart4.Series["Penjualan"].Points.Add(penjualan[i]);
                dataGridView1.Rows.Add(perusahaan[i], penjualan[i]);
            }

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Name = "Action";
            button.HeaderText = "Action";
            button.Text = "Add";

            button.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(button);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart4.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Nama : Royhan", new Font("Arial", 20), Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString("Kelas : XII RPL C", new Font("Arial", 20), Brushes.Black, new Point(100, 200));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                Nothing.Text = dataGridView1.CurrentRow.Cells["Perusahaan"].Value.ToString();
            }
        }
    }
}
