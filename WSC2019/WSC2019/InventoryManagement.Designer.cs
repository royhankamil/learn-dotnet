namespace WSC2019
{
    partial class InventoryManagement
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
            this.PartNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionsCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNameCol,
            this.TransactionTypeCol,
            this.DateCol,
            this.AmountCol,
            this.SourceCol,
            this.DestinationCol,
            this.ActionsCol});
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 396);
            this.dataGridView1.TabIndex = 1;
            // 
            // PartNameCol
            // 
            this.PartNameCol.HeaderText = "Part Name";
            this.PartNameCol.MinimumWidth = 6;
            this.PartNameCol.Name = "PartNameCol";
            this.PartNameCol.ReadOnly = true;
            // 
            // TransactionTypeCol
            // 
            this.TransactionTypeCol.HeaderText = "Transaction Type";
            this.TransactionTypeCol.MinimumWidth = 6;
            this.TransactionTypeCol.Name = "TransactionTypeCol";
            this.TransactionTypeCol.ReadOnly = true;
            // 
            // DateCol
            // 
            this.DateCol.HeaderText = "Date";
            this.DateCol.MinimumWidth = 6;
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            // 
            // AmountCol
            // 
            this.AmountCol.HeaderText = "Amount";
            this.AmountCol.MinimumWidth = 6;
            this.AmountCol.Name = "AmountCol";
            this.AmountCol.ReadOnly = true;
            // 
            // SourceCol
            // 
            this.SourceCol.HeaderText = "Source";
            this.SourceCol.MinimumWidth = 6;
            this.SourceCol.Name = "SourceCol";
            this.SourceCol.ReadOnly = true;
            // 
            // DestinationCol
            // 
            this.DestinationCol.HeaderText = "Destination";
            this.DestinationCol.MinimumWidth = 6;
            this.DestinationCol.Name = "DestinationCol";
            this.DestinationCol.ReadOnly = true;
            // 
            // ActionsCol
            // 
            this.ActionsCol.HeaderText = "Actions";
            this.ActionsCol.MinimumWidth = 6;
            this.ActionsCol.Name = "ActionsCol";
            this.ActionsCol.ReadOnly = true;
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.purchaseToolStripMenuItem.Text = "Purchase Order  Management";
            // 
            // warehouseManagementToolStripMenuItem
            // 
            this.warehouseManagementToolStripMenuItem.Name = "warehouseManagementToolStripMenuItem";
            this.warehouseManagementToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.warehouseManagementToolStripMenuItem.Text = "Warehouse Management";
            // 
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.warehouseManagementToolStripMenuItem,
            this.inventoryReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InventoryManagement";
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.InventoryManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationCol;
        private System.Windows.Forms.DataGridViewLinkColumn ActionsCol;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

