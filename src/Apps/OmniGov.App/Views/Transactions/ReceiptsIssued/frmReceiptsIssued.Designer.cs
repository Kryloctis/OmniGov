
namespace OmniGov.App.Views.Transactions.ReceiptsIssued
{
    partial class frmReceiptsIssued
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnReturn = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            dgReceiptIssued = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1 = new System.Windows.Forms.Panel();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            tsJOCount = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            bgwLoadIssuedReceipts = new System.ComponentModel.BackgroundWorker();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgReceiptIssued).BeginInit();
            panel1.SuspendLayout();
            statusStrip2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, btnReturn, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Margin = new System.Windows.Forms.Padding(4);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(840, 35);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnReturn
            // 
            btnReturn.Enabled = false;
            btnReturn.Image = Properties.Resources.account_book_20px;
            btnReturn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new System.Drawing.Size(66, 24);
            btnReturn.Text = "Return";
            btnReturn.Click += btnReturn_Click;
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
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // dgReceiptIssued
            // 
            dgReceiptIssued.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceiptIssued.Dock = System.Windows.Forms.DockStyle.Fill;
            dgReceiptIssued.Location = new System.Drawing.Point(4, 9);
            dgReceiptIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgReceiptIssued.Name = "dgReceiptIssued";
            dgReceiptIssued.RowHeadersWidth = 51;
            dgReceiptIssued.RowTemplate.Height = 29;
            dgReceiptIssued.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgReceiptIssued.Size = new System.Drawing.Size(832, 328);
            dgReceiptIssued.TabIndex = 8;
            dgReceiptIssued.SelectionChanged += dgissue_SelectionChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(616, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 31;
            label2.Text = "Date Issued";
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtpDateIssued.CustomFormat = "MMM dd, yyyy";
            dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateIssued.Location = new System.Drawing.Point(689, 3);
            dtpDateIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new System.Drawing.Size(148, 23);
            dtpDateIssued.TabIndex = 30;
            dtpDateIssued.ValueChanged += dtpDateIssued_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgReceiptIssued);
            panel1.Controls.Add(pbLoadRecords);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(840, 341);
            panel1.TabIndex = 33;
            // 
            // statusStrip2
            // 
            statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel2, lblRecordCount, tsJOCount, lblCreatedAt, lblUpdatedAt });
            statusStrip2.Location = new System.Drawing.Point(0, 406);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip2.Size = new System.Drawing.Size(840, 22);
            statusStrip2.Stretch = false;
            statusStrip2.TabIndex = 35;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel2.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // tsJOCount
            // 
            tsJOCount.Name = "tsJOCount";
            tsJOCount.Size = new System.Drawing.Size(762, 17);
            tsJOCount.Spring = true;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // bgwLoadIssuedReceipts
            // 
            bgwLoadIssuedReceipts.WorkerReportsProgress = true;
            bgwLoadIssuedReceipts.WorkerSupportsCancellation = true;
            bgwLoadIssuedReceipts.DoWork += bgwLoadIssuedReceipts_DoWork;
            bgwLoadIssuedReceipts.ProgressChanged += bgwLoadIssuedReceipts_ProgressChanged;
            bgwLoadIssuedReceipts.RunWorkerCompleted += bgwLoadIssuedReceipts_RunWorkerCompleted;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowFilter);
            panel2.Controls.Add(dtpDateIssued);
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(840, 30);
            panel2.TabIndex = 37;
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(120, 23);
            cmbxRowFilter.TabIndex = 32;
            cmbxRowFilter.SelectionChangeCommitted += cmbxRowFilter_SelectionChangeCommitted;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(832, 5);
            pbLoadRecords.TabIndex = 22;
            // 
            // frmReceiptsIssued
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(statusStrip2);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmReceiptsIssued";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Treasury > Manage > Receipts > Issuance";
            Load += frmReceiptsIssued_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgReceiptIssued).EndInit();
            panel1.ResumeLayout(false);
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnReturn;
        private System.Windows.Forms.DataGridView dgReceiptIssued;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateIssued;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel tsJOCount;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        internal System.ComponentModel.BackgroundWorker bgwLoadIssuedReceipts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        internal System.Windows.Forms.ProgressBar pbLoadRecords;
    }
}
