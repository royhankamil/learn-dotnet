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
    public partial class MasterData : Form
    {
        int user_id;
        public MasterData(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(user_id); 
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterPaket masterPaket = new MasterPaket(user_id);
            masterPaket.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MasterKomputer masterKomputer = new MasterKomputer(user_id);
            masterKomputer.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MasterPotonganHarga master = new MasterPotonganHarga(user_id);
            master.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MasterMember member = new MasterMember(user_id);
            member.Show();  
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            HalamanTransaksi transaksi = new HalamanTransaksi(user_id);
            transaksi.Show();
            this.Hide();
        }
    }
}
