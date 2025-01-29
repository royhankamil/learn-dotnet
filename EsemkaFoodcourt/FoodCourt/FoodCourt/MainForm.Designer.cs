namespace FoodCourt
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
            this.label1 = new System.Windows.Forms.Label();
            this.mMembersButton = new System.Windows.Forms.Button();
            this.mMenuButton = new System.Windows.Forms.Button();
            this.mMenuIngredientButton = new System.Windows.Forms.Button();
            this.reservationButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome, [Name]";
            // 
            // mMembersButton
            // 
            this.mMembersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMembersButton.Location = new System.Drawing.Point(78, 80);
            this.mMembersButton.Name = "mMembersButton";
            this.mMembersButton.Size = new System.Drawing.Size(267, 41);
            this.mMembersButton.TabIndex = 1;
            this.mMembersButton.Text = "Manage Members";
            this.mMembersButton.UseVisualStyleBackColor = true;
            // 
            // mMenuButton
            // 
            this.mMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMenuButton.Location = new System.Drawing.Point(78, 136);
            this.mMenuButton.Name = "mMenuButton";
            this.mMenuButton.Size = new System.Drawing.Size(267, 41);
            this.mMenuButton.TabIndex = 2;
            this.mMenuButton.Text = "Manage Menu";
            this.mMenuButton.UseVisualStyleBackColor = true;
            // 
            // mMenuIngredientButton
            // 
            this.mMenuIngredientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMenuIngredientButton.Location = new System.Drawing.Point(78, 196);
            this.mMenuIngredientButton.Name = "mMenuIngredientButton";
            this.mMenuIngredientButton.Size = new System.Drawing.Size(267, 41);
            this.mMenuIngredientButton.TabIndex = 3;
            this.mMenuIngredientButton.Text = "Manage Menu Ingredients";
            this.mMenuIngredientButton.UseVisualStyleBackColor = true;
            // 
            // reservationButton
            // 
            this.reservationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationButton.Location = new System.Drawing.Point(78, 256);
            this.reservationButton.Name = "reservationButton";
            this.reservationButton.Size = new System.Drawing.Size(267, 41);
            this.reservationButton.TabIndex = 4;
            this.reservationButton.Text = "View Reservations";
            this.reservationButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(78, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(267, 41);
            this.button3.TabIndex = 5;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 413);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.reservationButton);
            this.Controls.Add(this.mMenuIngredientButton);
            this.Controls.Add(this.mMenuButton);
            this.Controls.Add(this.mMembersButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "AdminFormcs";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mMembersButton;
        private System.Windows.Forms.Button mMenuButton;
        private System.Windows.Forms.Button mMenuIngredientButton;
        private System.Windows.Forms.Button reservationButton;
        private System.Windows.Forms.Button button3;
    }
}