namespace Desktop_FoodXYZ
{
    partial class FormTransaksi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Transaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode_Barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama_Barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Harga_Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantitas_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Quantitas = new System.Windows.Forms.TextBox();
            this.HargaBarang = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelBayar = new System.Windows.Forms.Label();
            this.InputBayar = new System.Windows.Forms.TextBox();
            this.labelKembalian = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.KodeBarang = new System.Windows.Forms.ComboBox();
            this.TotHarga = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-3, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 463);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 78);
            this.label9.TabIndex = 5;
            this.label9.Text = "KELOLA TRANSAKSI";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(38, 385);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(167, 40);
            this.LogoutButton.TabIndex = 4;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Desktop_FoodXYZ.Properties.Resources.Screenshot_2025_02_18_081105;
            this.pictureBox1.Location = new System.Drawing.Point(38, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "KASIR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(315, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Form Transaksi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Transaksi,
            this.Kode_Barang,
            this.Nama_Barang,
            this.Harga_Satuan,
            this.Quantitas_column,
            this.Subtotal});
            this.dataGridView1.Location = new System.Drawing.Point(311, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(442, 81);
            this.dataGridView1.TabIndex = 8;
            // 
            // ID_Transaksi
            // 
            this.ID_Transaksi.HeaderText = "ID Transaksi";
            this.ID_Transaksi.Name = "ID_Transaksi";
            this.ID_Transaksi.ReadOnly = true;
            // 
            // Kode_Barang
            // 
            this.Kode_Barang.HeaderText = "Kode Barang";
            this.Kode_Barang.Name = "Kode_Barang";
            this.Kode_Barang.ReadOnly = true;
            // 
            // Nama_Barang
            // 
            this.Nama_Barang.HeaderText = "Nama Barang";
            this.Nama_Barang.Name = "Nama_Barang";
            this.Nama_Barang.ReadOnly = true;
            // 
            // Harga_Satuan
            // 
            this.Harga_Satuan.HeaderText = "Harga Satuan";
            this.Harga_Satuan.Name = "Harga_Satuan";
            this.Harga_Satuan.ReadOnly = true;
            // 
            // Quantitas_column
            // 
            this.Quantitas_column.HeaderText = "Quantitas";
            this.Quantitas_column.Name = "Quantitas_column";
            this.Quantitas_column.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kode Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(569, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quntitas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(321, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Harga Barang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(569, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Harga";
            // 
            // Quantitas
            // 
            this.Quantitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantitas.Location = new System.Drawing.Point(573, 83);
            this.Quantitas.Name = "Quantitas";
            this.Quantitas.Size = new System.Drawing.Size(184, 24);
            this.Quantitas.TabIndex = 15;
            this.Quantitas.TextChanged += new System.EventHandler(this.Quantitas_TextChanged);
            // 
            // HargaBarang
            // 
            this.HargaBarang.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HargaBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HargaBarang.Location = new System.Drawing.Point(325, 143);
            this.HargaBarang.Name = "HargaBarang";
            this.HargaBarang.ReadOnly = true;
            this.HargaBarang.Size = new System.Drawing.Size(184, 24);
            this.HargaBarang.TabIndex = 16;
            this.HargaBarang.TextChanged += new System.EventHandler(this.HargaBarang_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(573, 185);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 27);
            this.AddButton.TabIndex = 20;
            this.AddButton.Text = "Tambah";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(671, 185);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 27);
            this.ResetButton.TabIndex = 21;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(325, 386);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(199, 27);
            this.DelButton.TabIndex = 22;
            this.DelButton.Text = "Bayar";
            this.DelButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(317, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Keranjang";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Total Harga";
            // 
            // labelBayar
            // 
            this.labelBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBayar.Location = new System.Drawing.Point(435, 333);
            this.labelBayar.Name = "labelBayar";
            this.labelBayar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBayar.Size = new System.Drawing.Size(92, 20);
            this.labelBayar.TabIndex = 29;
            this.labelBayar.Text = "Rp. 0";
            // 
            // InputBayar
            // 
            this.InputBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBayar.Location = new System.Drawing.Point(329, 351);
            this.InputBayar.Name = "InputBayar";
            this.InputBayar.Size = new System.Drawing.Size(195, 27);
            this.InputBayar.TabIndex = 30;
            this.InputBayar.TextChanged += new System.EventHandler(this.InputBayar_TextChanged);
            // 
            // labelKembalian
            // 
            this.labelKembalian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKembalian.Location = new System.Drawing.Point(435, 419);
            this.labelKembalian.Name = "labelKembalian";
            this.labelKembalian.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelKembalian.Size = new System.Drawing.Size(92, 20);
            this.labelKembalian.TabIndex = 32;
            this.labelKembalian.Text = "Rp. 0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(327, 419);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Kembalian";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(684, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 27);
            this.button1.TabIndex = 34;
            this.button1.Text = "Simpan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 27);
            this.button2.TabIndex = 33;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Username.Location = new System.Drawing.Point(625, 21);
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Size = new System.Drawing.Size(76, 20);
            this.Username.TabIndex = 35;
            this.Username.Text = "Admin";
            this.Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KodeBarang
            // 
            this.KodeBarang.BackColor = System.Drawing.SystemColors.MenuBar;
            this.KodeBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KodeBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KodeBarang.FormattingEnabled = true;
            this.KodeBarang.Location = new System.Drawing.Point(325, 86);
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.Size = new System.Drawing.Size(184, 28);
            this.KodeBarang.TabIndex = 36;
            this.KodeBarang.SelectedIndexChanged += new System.EventHandler(this.KodeBarang_SelectedIndexChanged);
            // 
            // TotHarga
            // 
            this.TotHarga.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TotHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotHarga.Location = new System.Drawing.Point(569, 143);
            this.TotHarga.Name = "TotHarga";
            this.TotHarga.ReadOnly = true;
            this.TotHarga.Size = new System.Drawing.Size(184, 24);
            this.TotHarga.TabIndex = 37;
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TotHarga);
            this.Controls.Add(this.KodeBarang);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelKembalian);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.InputBayar);
            this.Controls.Add(this.labelBayar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.HargaBarang);
            this.Controls.Add(this.Quantitas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormTransaksi";
            this.Text = "Form_Transaksi";
            this.Load += new System.EventHandler(this.FormTransaksi_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Quantitas;
        private System.Windows.Forms.TextBox HargaBarang;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelBayar;
        private System.Windows.Forms.TextBox InputBayar;
        private System.Windows.Forms.Label labelKembalian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.ComboBox KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Transaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode_Barang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama_Barang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Harga_Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantitas_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.TextBox TotHarga;
    }
}