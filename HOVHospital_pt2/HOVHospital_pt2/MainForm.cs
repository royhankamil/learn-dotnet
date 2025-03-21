using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOVHospital_pt2
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void iCD11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Icd11 icd = new Icd11();
            icd.Show();
            Hide();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterDoctor doc = new MasterDoctor();
            doc.Show();
            Hide();
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterPatient pat = new MasterPatient();
            pat.Show();
            Hide();
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newMeetingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMeeting meet = new FormMeeting();
            meet.Show();
        }

        private void meetingNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowMeet met = new FormShowMeet();
            met.Show();
        }
    }
}
