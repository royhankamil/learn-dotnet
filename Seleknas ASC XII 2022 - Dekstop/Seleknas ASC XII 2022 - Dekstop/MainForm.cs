using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seleknas_ASC_XII_2022___Dekstop
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void iCD11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterInternational master = new MasterInternational();
            master.Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masterdoctor master = new Masterdoctor();
            master.Show();
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterPatient patient = new MasterPatient();
            patient.Show();
        }

        private void newMeetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMeetin newMeet = new NewMeetin();
            newMeet.Show();
        }

        private void meetingNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMeeting meet = new FormMeeting();
            meet.Show();
        }
    }
}
