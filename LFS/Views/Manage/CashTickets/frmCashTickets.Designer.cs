namespace OmniGov.App.Views.Manage.CashTickets
{
    partial class frmCashTickets
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
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            bgwLoadCashTickets = new System.ComponentModel.BackgroundWorker();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            dgCashTickets = new System.Windows.Forms.DataGridView();
            dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            panel2 = new System.Windows.Forms.Panel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCashTickets).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(120, 23);
            cmbxRowFilter.TabIndex = 14;
            // 
            // bgwLoadCashTickets
            // 
            bgwLoadCashTickets.WorkerReportsProgress = true;
            bgwLoadCashTickets.WorkerSupportsCancellation = true;
            bgwLoadCashTickets.DoWork += bgwLoadCashTickets_DoWork;
            bgwLoadCashTickets.ProgressChanged += bgwLoadCashTickets_ProgressChanged;
            bgwLoadCashTickets.RunWorkerCompleted += bgwLoadCashTickets_RunWorkerCompleted;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(832, 5);
            pbLoadRecords.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgCashTickets);
            panel1.Controls.Add(pbLoadRecords);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(840, 341);
            panel1.TabIndex = 27;
            // 
            // dgCashTickets
            // 
            dgCashTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCashTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            dgCashTickets.Location = new System.Drawing.Point(4, 9);
            dgCashTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgCashTickets.Name = "dgCashTickets";
            dgCashTickets.RowHeadersWidth = 51;
            dgCashTickets.RowTemplate.Height = 29;
            dgCashTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgCashTickets.Size = new System.Drawing.Size(832, 328);
            dgCashTickets.TabIndex = 7;
            // 
            // dtpReceivedDate
            // 
            dtpReceivedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtpReceivedDate.CustomFormat = "MMM dd, yyyy";
            dtpReceivedDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpReceivedDate.Location = new System.Drawing.Point(715, 3);
            dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpReceivedDate.Name = "dtpReceivedDate";
            dtpReceivedDate.Size = new System.Drawing.Size(120, 23);
            dtpReceivedDate.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(1239, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 15);
            label1.TabIndex = 13;
            label1.Text = "Date Received";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(762, 17);
            toolStripStatusLabel3.Spring = true;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel3 });
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 26;
            statusStrip1.Text = "statusStrip1";
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 24);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowFilter);
            panel2.Controls.Add(dtpReceivedDate);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(840, 30);
            panel2.TabIndex = 28;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(840, 35);
            toolStrip1.TabIndex = 25;
            toolStrip1.Text = "toolStrip1";
            // 
            // frmCashTickets
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmCashTickets";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Treasury > Manage > Cash Tickets > Inventory";
            Load += frmCashTickets_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgCashTickets).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxRowFilter;
        internal System.ComponentModel.BackgroundWorker bgwLoadCashTickets;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgCashTickets;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}
