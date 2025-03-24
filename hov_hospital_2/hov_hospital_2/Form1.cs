using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hov_hospital_2
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newMeetinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewMeeting().Show();
        }

        private void iCD11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ICD11().Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterDoctor().Show();
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterPatient().Show();
        }

        private void meetingNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMeeting().Show();
        }
    }
}
