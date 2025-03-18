namespace Seleknas_ASC_XII_2022___Dekstop
{
    partial class FormMeeting
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorCatCall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentColl = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.RecordsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.patientNameCol,
            this.DoctorCatCall,
            this.DoctorNameCol,
            this.QueueCol,
            this.PaymentColl});
            this.dataGridView1.Location = new System.Drawing.Point(29, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(510, 161);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // patientNameCol
            // 
            this.patientNameCol.HeaderText = "Patient Name";
            this.patientNameCol.Name = "patientNameCol";
            this.patientNameCol.ReadOnly = true;
            // 
            // DoctorCatCall
            // 
            this.DoctorCatCall.HeaderText = "Doctor Category";
            this.DoctorCatCall.Name = "DoctorCatCall";
            this.DoctorCatCall.ReadOnly = true;
            // 
            // DoctorNameCol
            // 
            this.DoctorNameCol.HeaderText = "Doctor Name";
            this.DoctorNameCol.Name = "DoctorNameCol";
            this.DoctorNameCol.ReadOnly = true;
            // 
            // QueueCol
            // 
            this.QueueCol.HeaderText = "Queue";
            this.QueueCol.Name = "QueueCol";
            this.QueueCol.ReadOnly = true;
            // 
            // PaymentColl
            // 
            this.PaymentColl.HeaderText = "Payment";
            this.PaymentColl.Name = "PaymentColl";
            this.PaymentColl.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Form Meeting";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(40, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 176);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Records";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add New Patient Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordsCol,
            this.EditCol,
            this.DeleteCol});
            this.dataGridView2.Location = new System.Drawing.Point(6, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(475, 106);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // RecordsCol
            // 
            this.RecordsCol.HeaderText = "Record";
            this.RecordsCol.Name = "RecordsCol";
            this.RecordsCol.ReadOnly = true;
            // 
            // EditCol
            // 
            this.EditCol.HeaderText = "Edit";
            this.EditCol.Name = "EditCol";
            this.EditCol.ReadOnly = true;
            // 
            // DeleteCol
            // 
            this.DeleteCol.HeaderText = "Delete";
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.ReadOnly = true;
            // 
            // FormMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormMeeting";
            this.Text = "FormMeeting";
            this.Load += new System.EventHandler(this.FormMeeting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorCatCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueueCol;
        private System.Windows.Forms.DataGridViewButtonColumn PaymentColl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordsCol;
        private System.Windows.Forms.DataGridViewButtonColumn EditCol;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteCol;
    }
}