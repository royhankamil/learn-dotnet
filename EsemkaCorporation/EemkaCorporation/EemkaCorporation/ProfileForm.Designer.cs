namespace EemkaCorporation
{
    partial class ProfileForm
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
            this.components = new System.ComponentModel.Container();
            this.MainButton = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.number_label = new System.Windows.Forms.Label();
            this.hire_label = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.JobHistory = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorksWith = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberBox = new System.Windows.Forms.TextBox();
            this.HireDateBox = new System.Windows.Forms.TextBox();
            this.PositionBox = new System.Windows.Forms.TextBox();
            this.JobLevelBox = new System.Windows.Forms.TextBox();
            this.DepatmentBox = new System.Windows.Forms.TextBox();
            this.DirectSupervisor = new System.Windows.Forms.LinkLabel();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Subordinate = new System.Windows.Forms.GroupBox();
            this.promotionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JobHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.WorksWith.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.Subordinate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.promotionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainButton
            // 
            this.MainButton.Location = new System.Drawing.Point(16, 12);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(100, 28);
            this.MainButton.TabIndex = 0;
            this.MainButton.Text = "Main";
            this.MainButton.UseVisualStyleBackColor = true;
            this.MainButton.Click += new System.EventHandler(this.MainButton_Click);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(332, 42);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(73, 25);
            this.Label.TabIndex = 1;
            this.Label.Text = "Profile";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(29, 95);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(48, 18);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Name";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_label.Location = new System.Drawing.Point(29, 122);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(45, 18);
            this.email_label.TabIndex = 3;
            this.email_label.Text = "Email";
            // 
            // number_label
            // 
            this.number_label.AutoSize = true;
            this.number_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_label.Location = new System.Drawing.Point(29, 150);
            this.number_label.Name = "number_label";
            this.number_label.Size = new System.Drawing.Size(108, 18);
            this.number_label.TabIndex = 4;
            this.number_label.Text = "Phone Number";
            // 
            // hire_label
            // 
            this.hire_label.AutoSize = true;
            this.hire_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hire_label.Location = new System.Drawing.Point(29, 180);
            this.hire_label.Name = "hire_label";
            this.hire_label.Size = new System.Drawing.Size(70, 18);
            this.hire_label.TabIndex = 5;
            this.hire_label.Text = "Hire Date";
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.Location = new System.Drawing.Point(29, 210);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(62, 18);
            this.position.TabIndex = 6;
            this.position.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Job level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Direct Supervisor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // JobHistory
            // 
            this.JobHistory.Controls.Add(this.dataGridView1);
            this.JobHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobHistory.Location = new System.Drawing.Point(32, 338);
            this.JobHistory.Name = "JobHistory";
            this.JobHistory.Size = new System.Drawing.Size(358, 150);
            this.JobHistory.TabIndex = 10;
            this.JobHistory.TabStop = false;
            this.JobHistory.Text = "Job History";
            this.JobHistory.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.department,
            this.dataGridViewTextBoxColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(21, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(331, 121);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // department
            // 
            this.department.DataPropertyName = "department";
            this.department.HeaderText = "department";
            this.department.Name = "department";
            this.department.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "position";
            this.dataGridViewTextBoxColumn1.HeaderText = "position";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // WorksWith
            // 
            this.WorksWith.Controls.Add(this.dataGridView3);
            this.WorksWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorksWith.Location = new System.Drawing.Point(434, 338);
            this.WorksWith.Name = "WorksWith";
            this.WorksWith.Size = new System.Drawing.Size(354, 150);
            this.WorksWith.TabIndex = 11;
            this.WorksWith.TabStop = false;
            this.WorksWith.Text = "Works With";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(28, 23);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView3.Size = new System.Drawing.Size(320, 121);
            this.dataGridView3.TabIndex = 2;
            // 
            // NameBox
            // 
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.Location = new System.Drawing.Point(173, 95);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(251, 21);
            this.NameBox.TabIndex = 12;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // EmailBox
            // 
            this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailBox.Location = new System.Drawing.Point(173, 122);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.ReadOnly = true;
            this.EmailBox.Size = new System.Drawing.Size(251, 21);
            this.EmailBox.TabIndex = 13;
            // 
            // PhoneNumberBox
            // 
            this.PhoneNumberBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberBox.Location = new System.Drawing.Point(173, 150);
            this.PhoneNumberBox.Name = "PhoneNumberBox";
            this.PhoneNumberBox.ReadOnly = true;
            this.PhoneNumberBox.Size = new System.Drawing.Size(251, 21);
            this.PhoneNumberBox.TabIndex = 14;
            // 
            // HireDateBox
            // 
            this.HireDateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HireDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HireDateBox.Location = new System.Drawing.Point(173, 180);
            this.HireDateBox.Name = "HireDateBox";
            this.HireDateBox.ReadOnly = true;
            this.HireDateBox.Size = new System.Drawing.Size(251, 21);
            this.HireDateBox.TabIndex = 15;
            // 
            // PositionBox
            // 
            this.PositionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionBox.Location = new System.Drawing.Point(173, 210);
            this.PositionBox.Name = "PositionBox";
            this.PositionBox.ReadOnly = true;
            this.PositionBox.Size = new System.Drawing.Size(251, 21);
            this.PositionBox.TabIndex = 16;
            // 
            // JobLevelBox
            // 
            this.JobLevelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobLevelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobLevelBox.Location = new System.Drawing.Point(173, 240);
            this.JobLevelBox.Name = "JobLevelBox";
            this.JobLevelBox.ReadOnly = true;
            this.JobLevelBox.Size = new System.Drawing.Size(251, 21);
            this.JobLevelBox.TabIndex = 17;
            // 
            // DepatmentBox
            // 
            this.DepatmentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DepatmentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepatmentBox.Location = new System.Drawing.Point(173, 270);
            this.DepatmentBox.Name = "DepatmentBox";
            this.DepatmentBox.ReadOnly = true;
            this.DepatmentBox.Size = new System.Drawing.Size(251, 21);
            this.DepatmentBox.TabIndex = 18;
            this.DepatmentBox.TextChanged += new System.EventHandler(this.DepatmentBox_TextChanged);
            // 
            // DirectSupervisor
            // 
            this.DirectSupervisor.AutoSize = true;
            this.DirectSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectSupervisor.Location = new System.Drawing.Point(170, 305);
            this.DirectSupervisor.Name = "DirectSupervisor";
            this.DirectSupervisor.Size = new System.Drawing.Size(166, 17);
            this.DirectSupervisor.TabIndex = 19;
            this.DirectSupervisor.TabStop = true;
            this.DirectSupervisor.Text = "Direct Supervisore Name";
            this.DirectSupervisor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DirectSupervisor_LinkClicked);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "department";
            this.dataGridViewTextBoxColumn2.HeaderText = "department";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 144;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "department";
            this.dataGridViewTextBoxColumn3.HeaderText = "department";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 144;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.Size = new System.Drawing.Size(260, 163);
            this.dataGridView2.TabIndex = 1;
            // 
            // Subordinate
            // 
            this.Subordinate.Controls.Add(this.dataGridView2);
            this.Subordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subordinate.Location = new System.Drawing.Point(462, 97);
            this.Subordinate.Name = "Subordinate";
            this.Subordinate.Size = new System.Drawing.Size(297, 194);
            this.Subordinate.TabIndex = 12;
            this.Subordinate.TabStop = false;
            this.Subordinate.Text = "Subordinate";
            // 
            // promotionBindingSource
            // 
            this.promotionBindingSource.DataSource = typeof(EemkaCorporation.promotion);
            // 
            // positionBindingSource
            // 
            this.positionBindingSource.DataSource = typeof(EemkaCorporation.position);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.Subordinate);
            this.Controls.Add(this.DirectSupervisor);
            this.Controls.Add(this.DepatmentBox);
            this.Controls.Add(this.JobLevelBox);
            this.Controls.Add(this.PositionBox);
            this.Controls.Add(this.HireDateBox);
            this.Controls.Add(this.PhoneNumberBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.WorksWith);
            this.Controls.Add(this.JobHistory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.position);
            this.Controls.Add(this.hire_label);
            this.Controls.Add(this.number_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.MainButton);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.JobHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.WorksWith.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.Subordinate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.promotionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainButton;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label number_label;
        private System.Windows.Forms.Label hire_label;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox JobHistory;
        private System.Windows.Forms.GroupBox WorksWith;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox PhoneNumberBox;
        private System.Windows.Forms.TextBox HireDateBox;
        private System.Windows.Forms.TextBox PositionBox;
        private System.Windows.Forms.TextBox JobLevelBox;
        private System.Windows.Forms.TextBox DepatmentBox;
        private System.Windows.Forms.LinkLabel DirectSupervisor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox Subordinate;
        private System.Windows.Forms.BindingSource promotionBindingSource;
        private System.Windows.Forms.BindingSource positionBindingSource;
    }
}