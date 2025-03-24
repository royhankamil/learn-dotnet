namespace HOVHOSPITAL3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCD11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patietnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMeetingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.meetingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iCD11ToolStripMenuItem,
            this.doctorToolStripMenuItem,
            this.patietnToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // iCD11ToolStripMenuItem
            // 
            this.iCD11ToolStripMenuItem.Name = "iCD11ToolStripMenuItem";
            this.iCD11ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iCD11ToolStripMenuItem.Text = "ICD - 11";
            this.iCD11ToolStripMenuItem.Click += new System.EventHandler(this.iCD11ToolStripMenuItem_Click);
            // 
            // doctorToolStripMenuItem
            // 
            this.doctorToolStripMenuItem.Name = "doctorToolStripMenuItem";
            this.doctorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.doctorToolStripMenuItem.Text = "Doctor";
            this.doctorToolStripMenuItem.Click += new System.EventHandler(this.doctorToolStripMenuItem_Click);
            // 
            // patietnToolStripMenuItem
            // 
            this.patietnToolStripMenuItem.Name = "patietnToolStripMenuItem";
            this.patietnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patietnToolStripMenuItem.Text = "Patient";
            this.patietnToolStripMenuItem.Click += new System.EventHandler(this.patietnToolStripMenuItem_Click);
            // 
            // meetingToolStripMenuItem
            // 
            this.meetingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMeetingToolStripMenuItem,
            this.meetingNotesToolStripMenuItem});
            this.meetingToolStripMenuItem.Name = "meetingToolStripMenuItem";
            this.meetingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.meetingToolStripMenuItem.Text = "Meeting";
            // 
            // newMeetingToolStripMenuItem
            // 
            this.newMeetingToolStripMenuItem.Name = "newMeetingToolStripMenuItem";
            this.newMeetingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newMeetingToolStripMenuItem.Text = "New Meeting";
            this.newMeetingToolStripMenuItem.Click += new System.EventHandler(this.newMeetingToolStripMenuItem_Click);
            // 
            // meetingNotesToolStripMenuItem
            // 
            this.meetingNotesToolStripMenuItem.Name = "meetingNotesToolStripMenuItem";
            this.meetingNotesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.meetingNotesToolStripMenuItem.Text = "Meeting Notes";
            this.meetingNotesToolStripMenuItem.Click += new System.EventHandler(this.meetingNotesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCD11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patietnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMeetingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingNotesToolStripMenuItem;
    }
}

