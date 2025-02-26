namespace EemkaCorporation
{
    partial class MainForm
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
            this.Welcome = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.profile_button = new System.Windows.Forms.Button();
            this.job_mutation_button = new System.Windows.Forms.Button();
            this.job_promotion_button = new System.Windows.Forms.Button();
            this.logout_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome.Location = new System.Drawing.Point(24, 27);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(292, 25);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Welcome, [Emploeyer Name]";
            this.Welcome.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // profile_button
            // 
            this.profile_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.profile_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_button.Location = new System.Drawing.Point(38, 89);
            this.profile_button.Name = "profile_button";
            this.profile_button.Size = new System.Drawing.Size(347, 49);
            this.profile_button.TabIndex = 2;
            this.profile_button.Text = "Profile";
            this.profile_button.UseVisualStyleBackColor = true;
            this.profile_button.Click += new System.EventHandler(this.profile_button_Click);
            // 
            // job_mutation_button
            // 
            this.job_mutation_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.job_mutation_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job_mutation_button.Location = new System.Drawing.Point(38, 154);
            this.job_mutation_button.Name = "job_mutation_button";
            this.job_mutation_button.Size = new System.Drawing.Size(347, 49);
            this.job_mutation_button.TabIndex = 3;
            this.job_mutation_button.Text = "Apply for Job Mutation";
            this.job_mutation_button.UseVisualStyleBackColor = true;
            this.job_mutation_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // job_promotion_button
            // 
            this.job_promotion_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.job_promotion_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job_promotion_button.Location = new System.Drawing.Point(38, 221);
            this.job_promotion_button.Name = "job_promotion_button";
            this.job_promotion_button.Size = new System.Drawing.Size(347, 49);
            this.job_promotion_button.TabIndex = 4;
            this.job_promotion_button.Text = "Apply for Job Promotion";
            this.job_promotion_button.UseVisualStyleBackColor = true;
            this.job_promotion_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // logout_button
            // 
            this.logout_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.logout_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_button.Location = new System.Drawing.Point(38, 340);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(347, 36);
            this.logout_button.TabIndex = 5;
            this.logout_button.Text = "Logout";
            this.logout_button.UseVisualStyleBackColor = true;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 408);
            this.Controls.Add(this.logout_button);
            this.Controls.Add(this.job_promotion_button);
            this.Controls.Add(this.job_mutation_button);
            this.Controls.Add(this.profile_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Welcome);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button profile_button;
        private System.Windows.Forms.Button job_mutation_button;
        private System.Windows.Forms.Button job_promotion_button;
        private System.Windows.Forms.Button logout_button;
    }
}