namespace FoodCourt
{
    partial class Register
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confirmPassErrorTxt = new System.Windows.Forms.Label();
            this.passwordErrorTxt = new System.Windows.Forms.Label();
            this.PNumErrorTxt = new System.Windows.Forms.Label();
            this.emailErrorTxt = new System.Windows.Forms.Label();
            this.nameErrorTxt = new System.Windows.Forms.Label();
            this.confirmPassInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pNumberInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lNameInput = new System.Windows.Forms.TextBox();
            this.fNameInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FoodCourt.Properties.Resources.Icon_Small;
            this.pictureBox1.Location = new System.Drawing.Point(341, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Member Registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Register to Esemka Foodcourt and enjoy the previllege";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.confirmPassErrorTxt);
            this.groupBox1.Controls.Add(this.passwordErrorTxt);
            this.groupBox1.Controls.Add(this.PNumErrorTxt);
            this.groupBox1.Controls.Add(this.emailErrorTxt);
            this.groupBox1.Controls.Add(this.nameErrorTxt);
            this.groupBox1.Controls.Add(this.confirmPassInput);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.passwordInput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pNumberInput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.emailInput);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lNameInput);
            this.groupBox1.Controls.Add(this.fNameInput);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(39, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 381);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // confirmPassErrorTxt
            // 
            this.confirmPassErrorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmPassErrorTxt.ForeColor = System.Drawing.Color.Red;
            this.confirmPassErrorTxt.Location = new System.Drawing.Point(34, 336);
            this.confirmPassErrorTxt.Name = "confirmPassErrorTxt";
            this.confirmPassErrorTxt.Size = new System.Drawing.Size(250, 24);
            this.confirmPassErrorTxt.TabIndex = 16;
            this.confirmPassErrorTxt.Text = "[Error Message]";
            this.confirmPassErrorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordErrorTxt
            // 
            this.passwordErrorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordErrorTxt.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorTxt.Location = new System.Drawing.Point(34, 268);
            this.passwordErrorTxt.Name = "passwordErrorTxt";
            this.passwordErrorTxt.Size = new System.Drawing.Size(250, 29);
            this.passwordErrorTxt.TabIndex = 15;
            this.passwordErrorTxt.Text = "[Error Message]";
            this.passwordErrorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PNumErrorTxt
            // 
            this.PNumErrorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PNumErrorTxt.ForeColor = System.Drawing.Color.Red;
            this.PNumErrorTxt.Location = new System.Drawing.Point(34, 201);
            this.PNumErrorTxt.Name = "PNumErrorTxt";
            this.PNumErrorTxt.Size = new System.Drawing.Size(250, 19);
            this.PNumErrorTxt.TabIndex = 14;
            this.PNumErrorTxt.Text = "[Error Message]";
            this.PNumErrorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailErrorTxt
            // 
            this.emailErrorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailErrorTxt.ForeColor = System.Drawing.Color.Red;
            this.emailErrorTxt.Location = new System.Drawing.Point(34, 141);
            this.emailErrorTxt.Name = "emailErrorTxt";
            this.emailErrorTxt.Size = new System.Drawing.Size(250, 21);
            this.emailErrorTxt.TabIndex = 13;
            this.emailErrorTxt.Text = "[Error Message]";
            this.emailErrorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameErrorTxt
            // 
            this.nameErrorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameErrorTxt.ForeColor = System.Drawing.Color.Red;
            this.nameErrorTxt.Location = new System.Drawing.Point(34, 83);
            this.nameErrorTxt.Name = "nameErrorTxt";
            this.nameErrorTxt.Size = new System.Drawing.Size(250, 21);
            this.nameErrorTxt.TabIndex = 12;
            this.nameErrorTxt.Text = "[Error Message]";
            this.nameErrorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmPassInput
            // 
            this.confirmPassInput.Location = new System.Drawing.Point(32, 313);
            this.confirmPassInput.Name = "confirmPassInput";
            this.confirmPassInput.Size = new System.Drawing.Size(268, 20);
            this.confirmPassInput.TabIndex = 11;
            this.confirmPassInput.UseSystemPasswordChar = true;
            this.confirmPassInput.TextChanged += new System.EventHandler(this.confirmPassInput_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Confirm Password";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(33, 245);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(268, 20);
            this.passwordInput.TabIndex = 9;
            this.passwordInput.UseSystemPasswordChar = true;
            this.passwordInput.TextChanged += new System.EventHandler(this.passwordInput_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Password";
            // 
            // pNumberInput
            // 
            this.pNumberInput.Location = new System.Drawing.Point(36, 178);
            this.pNumberInput.Name = "pNumberInput";
            this.pNumberInput.Size = new System.Drawing.Size(268, 20);
            this.pNumberInput.TabIndex = 7;
            this.pNumberInput.TextChanged += new System.EventHandler(this.pNumberInput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Phone Number";
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(34, 120);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(268, 20);
            this.emailInput.TabIndex = 5;
            this.emailInput.TextChanged += new System.EventHandler(this.emailInput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // lNameInput
            // 
            this.lNameInput.Location = new System.Drawing.Point(182, 62);
            this.lNameInput.Name = "lNameInput";
            this.lNameInput.Size = new System.Drawing.Size(120, 20);
            this.lNameInput.TabIndex = 3;
            this.lNameInput.TextChanged += new System.EventHandler(this.lNameInput_TextChanged);
            // 
            // fNameInput
            // 
            this.fNameInput.Location = new System.Drawing.Point(34, 60);
            this.fNameInput.Name = "fNameInput";
            this.fNameInput.Size = new System.Drawing.Size(128, 20);
            this.fNameInput.TabIndex = 2;
            this.fNameInput.TextChanged += new System.EventHandler(this.fNameInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(29, 494);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(99, 32);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(240, 494);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(133, 32);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Register & Login";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 551);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lNameInput;
        private System.Windows.Forms.TextBox fNameInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirmPassInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label confirmPassErrorTxt;
        private System.Windows.Forms.Label passwordErrorTxt;
        private System.Windows.Forms.Label PNumErrorTxt;
        private System.Windows.Forms.Label emailErrorTxt;
        private System.Windows.Forms.Label nameErrorTxt;
        public System.Windows.Forms.TextBox pNumberInput;
    }
}