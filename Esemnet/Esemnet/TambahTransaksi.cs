using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemnet
{
    public partial class TambahTransaksi : Form
    {
        EsemNetEntities db = new EsemNetEntities();
        public TambahTransaksi()
        {
            InitializeComponent();

            foreach (string p in db.Pakets.Select(i=>i.Nama).ToList())
            {
                paket.Items.Add(p);
            }
            //paket.SelectedIndex = 0;

            //foreach (string p in db.Komputers.Select(i=>i.Merek).ToList())
            //{
            //    komputer.Items.Add(p);
            //}
            //komputer.SelectedIndex = 0;


            potonganharga.Text = "-Rp.0";
            potonganmember.Text = "-Rp.0";
            totalTxt.Text = "Rp.0";
            subtotal.Text = "Rp.0";
        }

        private void TambahTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void paket_SelectedIndexChanged(object sender, EventArgs e)
        {
            Paket paketDB = db.Pakets.FirstOrDefault(u => u.Nama == paket.Text);
            if (paketDB.IDJenis != null)
            {
                foreach (var komp in db.Komputers.Where(k=>k.IDJenis == paketDB.IDJenis).Select(k=>k.Merek).ToList())
                {
                    komputer.Items.Add(komp);
                }
            }
            else
            {
                foreach (var komp in db.Komputers.Select(k=>k.Merek).ToList())
                {
                    komputer.Items.Add(komp);
                }
                
            }

            komputer.SelectedIndex = 0;

            HargaInput.Text = paketDB.HargaPerJam.ToString();

            update_total_harga();
            
        }

        private void update_total_harga()
        {
            if (DurasiInput.Text != "" && DurasiInput.Text.All(char.IsNumber))
            {
                subtotal.Text = 
            }
            else
            {
                potonganharga.Text = "-Rp.0";
                potonganmember.Text = "-Rp.0";
                totalTxt.Text = "Rp.0";
                subtotal.Text = "Rp.0";
            }
        }

        private void komputer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DurasiInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
