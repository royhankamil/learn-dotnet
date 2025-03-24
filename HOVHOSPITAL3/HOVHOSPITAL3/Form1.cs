using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHOSPITAL3
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void patietnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterPatient().ShowDialog();
        }

        private void iCD11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new icd11form().ShowDialog();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterDoctor().ShowDialog();
        }

        private void newMeetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewMeetingForm().ShowDialog();
        }

        private void meetingNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMeetin().ShowDialog();
        }
    }
}
