namespace HOVHospital_pt2
{
    partial class viewPatientRecord
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
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocCatCOl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDOcCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient Record of [name]";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateCol,
            this.DocCatCOl,
            this.NameDOcCol,
            this.RecordCol});
            this.dataGridView1.Location = new System.Drawing.Point(49, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(515, 257);
            this.dataGridView1.TabIndex = 2;
            // 
            // DateCol
            // 
            this.DateCol.HeaderText = "Date";
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            // 
            // DocCatCOl
            // 
            this.DocCatCOl.HeaderText = "Doctor Category";
            this.DocCatCOl.Name = "DocCatCOl";
            this.DocCatCOl.ReadOnly = true;
            // 
            // NameDOcCol
            // 
            this.NameDOcCol.HeaderText = "Doctor Name";
            this.NameDOcCol.Name = "NameDOcCol";
            this.NameDOcCol.ReadOnly = true;
            // 
            // RecordCol
            // 
            this.RecordCol.HeaderText = "Record";
            this.RecordCol.Name = "RecordCol";
            this.RecordCol.ReadOnly = true;
            // 
            // viewPatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "viewPatientRecord";
            this.Text = "viewPatientRecord";
            this.Load += new System.EventHandler(this.viewPatientRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocCatCOl;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDOcCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordCol;
    }
}