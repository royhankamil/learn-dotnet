namespace EemkaCorporation
{
    partial class Login
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
            this.label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.Email_input = new System.Windows.Forms.TextBox();
            this.Password_input = new System.Windows.Forms.TextBox();
            this.error_text = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(142, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(123, 39);
            this.label.TabIndex = 0;
            this.label.Text = "LOGIN";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_label.Location = new System.Drawing.Point(60, 129);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(54, 22);
            this.email_label.TabIndex = 1;
            this.email_label.Text = "Email";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(60, 216);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(89, 22);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password";
            this.password_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // Email_input
            // 
            this.Email_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_input.Location = new System.Drawing.Point(64, 154);
            this.Email_input.Name = "Email_input";
            this.Email_input.Size = new System.Drawing.Size(300, 27);
            this.Email_input.TabIndex = 3;
            // 
            // Password_input
            // 
            this.Password_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_input.Location = new System.Drawing.Point(64, 250);
            this.Password_input.Name = "Password_input";
            this.Password_input.Size = new System.Drawing.Size(300, 27);
            this.Password_input.TabIndex = 4;
            this.Password_input.UseSystemPasswordChar = true;
            // 
            // error_text
            // 
            this.error_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_text.ForeColor = System.Drawing.Color.Red;
            this.error_text.Location = new System.Drawing.Point(25, 303);
            this.error_text.Name = "error_text";
            this.error_text.Size = new System.Drawing.Size(382, 23);
            this.error_text.TabIndex = 5;
            this.error_text.Text = "[Error Message]";
            this.error_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error_text.Click += new System.EventHandler(this.error_text_Click);
            // 
            // Login_button
            // 
            this.Login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_button.Location = new System.Drawing.Point(134, 346);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(131, 28);
            this.Login_button.TabIndex = 6;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 408);
            this.Controls.Add(this.error_text);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.Password_input);
            this.Controls.Add(this.Email_input);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.label);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox Email_input;
        private System.Windows.Forms.TextBox Password_input;
        private System.Windows.Forms.Label error_text;
        private System.Windows.Forms.Button Login_button;
    }
}

