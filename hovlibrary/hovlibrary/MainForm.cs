using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hovlibrary
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterMember().ShowDialog();
        }

        private void booToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterBook().ShowDialog();
        }

        private void newBorrowinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewBorrowing().ShowDialog();
        }

        private void allBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AllBorrowing().ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }
    }
}
