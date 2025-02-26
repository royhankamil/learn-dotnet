namespace Esemnet
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WelcomeTxt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TambahTransaksi = new System.Windows.Forms.Button();
            this.Terpakai = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ImageTemplate = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KomputerNameTemp = new System.Windows.Forms.Label();
            this.DurationTemp = new System.Windows.Forms.Label();
            this.CountDownTemp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 453);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(14, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Logout";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(14, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Transaksi";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Master Data";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // WelcomeTxt
            // 
            this.WelcomeTxt.AutoSize = true;
            this.WelcomeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeTxt.Location = new System.Drawing.Point(251, 24);
            this.WelcomeTxt.Name = "WelcomeTxt";
            this.WelcomeTxt.Size = new System.Drawing.Size(239, 25);
            this.WelcomeTxt.TabIndex = 1;
            this.WelcomeTxt.Text = "Selamat Datang [nama]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.TambahTransaksi);
            this.groupBox1.Controls.Add(this.Terpakai);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(238, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 349);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaksi Hari Ini";
            // 
            // TambahTransaksi
            // 
            this.TambahTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TambahTransaksi.Location = new System.Drawing.Point(345, 36);
            this.TambahTransaksi.Name = "TambahTransaksi";
            this.TambahTransaksi.Size = new System.Drawing.Size(160, 38);
            this.TambahTransaksi.TabIndex = 5;
            this.TambahTransaksi.Text = "Tambah Transaksi";
            this.TambahTransaksi.UseVisualStyleBackColor = true;
            this.TambahTransaksi.Click += new System.EventHandler(this.TambahTransaksi_Click);
            // 
            // Terpakai
            // 
            this.Terpakai.AutoSize = true;
            this.Terpakai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terpakai.Location = new System.Drawing.Point(29, 45);
            this.Terpakai.Name = "Terpakai";
            this.Terpakai.Size = new System.Drawing.Size(161, 20);
            this.Terpakai.TabIndex = 4;
            this.Terpakai.Text = "12 Komputer terpakai";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time
            // 
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.Location = new System.Drawing.Point(580, 30);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(195, 23);
            this.Time.TabIndex = 3;
            this.Time.Text = "20 Desember 2025   20:03";
            this.Time.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CountDownTemp);
            this.panel2.Controls.Add(this.DurationTemp);
            this.panel2.Controls.Add(this.KomputerNameTemp);
            this.panel2.Controls.Add(this.ImageTemplate);
            this.panel2.Location = new System.Drawing.Point(22, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 132);
            this.panel2.TabIndex = 6;
            // 
            // ImageTemplate
            // 
            this.ImageTemplate.Image = global::Esemnet.Properties.Resources.online_test;
            this.ImageTemplate.Location = new System.Drawing.Point(-6, 18);
            this.ImageTemplate.Name = "ImageTemplate";
            this.ImageTemplate.Size = new System.Drawing.Size(119, 87);
            this.ImageTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageTemplate.TabIndex = 0;
            this.ImageTemplate.TabStop = false;
            this.ImageTemplate.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(580, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "20 Desember 2025   20:03";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // KomputerNameTemp
            // 
            this.KomputerNameTemp.AutoSize = true;
            this.KomputerNameTemp.Location = new System.Drawing.Point(128, 27);
            this.KomputerNameTemp.Name = "KomputerNameTemp";
            this.KomputerNameTemp.Size = new System.Drawing.Size(85, 18);
            this.KomputerNameTemp.TabIndex = 1;
            this.KomputerNameTemp.Text = "Komputer 1";
            // 
            // DurationTemp
            // 
            this.DurationTemp.AutoSize = true;
            this.DurationTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurationTemp.Location = new System.Drawing.Point(128, 54);
            this.DurationTemp.Name = "DurationTemp";
            this.DurationTemp.Size = new System.Drawing.Size(35, 13);
            this.DurationTemp.TabIndex = 2;
            this.DurationTemp.Text = "2 Jam";
            // 
            // CountDownTemp
            // 
            this.CountDownTemp.AutoSize = true;
            this.CountDownTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDownTemp.Location = new System.Drawing.Point(128, 77);
            this.CountDownTemp.Name = "CountDownTemp";
            this.CountDownTemp.Size = new System.Drawing.Size(72, 18);
            this.CountDownTemp.TabIndex = 3;
            this.CountDownTemp.Text = "00:54:38";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WelcomeTxt);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WelcomeTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Button TambahTransaksi;
        private System.Windows.Forms.Label Terpakai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ImageTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CountDownTemp;
        private System.Windows.Forms.Label DurationTemp;
        private System.Windows.Forms.Label KomputerNameTemp;
    }
}