namespace hov_hospital_2
{
    partial class PatientRecord
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorCategoryCOl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOcname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Medical Records of [name]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.DoctorCategoryCOl,
            this.DOcname,
            this.Record});
            this.dataGridView1.Location = new System.Drawing.Point(24, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(491, 248);
            this.dataGridView1.TabIndex = 4;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // DoctorCategoryCOl
            // 
            this.DoctorCategoryCOl.HeaderText = "Doctor Category";
            this.DoctorCategoryCOl.Name = "DoctorCategoryCOl";
            this.DoctorCategoryCOl.ReadOnly = true;
            // 
            // DOcname
            // 
            this.DOcname.HeaderText = "Doctor Name";
            this.DOcname.Name = "DOcname";
            this.DOcname.ReadOnly = true;
            // 
            // Record
            // 
            this.Record.HeaderText = "Record";
            this.Record.Name = "Record";
            this.Record.ReadOnly = true;
            // 
            // PatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 358);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "PatientRecord";
            this.Text = "PatientRecord";
            this.Load += new System.EventHandler(this.PatientRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorCategoryCOl;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOcname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Record;
    }
}