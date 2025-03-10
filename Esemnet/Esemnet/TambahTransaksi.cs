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
            
            foreach (string p in db.Komputers.Select(i=>i.Merek).ToList())
            {
                komputer.Items.Add(p);
            }
            //komputer.SelectedIndex = 0;



        }

        private void TambahTransaksi_Load(object sender, EventArgs e)
        {

        }
    }
}
