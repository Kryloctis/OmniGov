
namespace AccountingSystem.Views.Reports.RCD
{
    partial class frmRCD
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
            btnSave = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            btnCancelPrint = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnDeposit = new System.Windows.Forms.ToolStripButton();
            btnPrint = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            btnRemove = new System.Windows.Forms.Button();
            btnadd = new System.Windows.Forms.Button();
            panelRCD = new System.Windows.Forms.Panel();
            txtTotal = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            dgListOfApprovedReport = new System.Windows.Forms.DataGridView();
            reportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            collecting_officer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            report_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel1 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            cmbfunds = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtRCDNo = new System.Windows.Forms.TextBox();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            panel2 = new System.Windows.Forms.Panel();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            toolStrip1.SuspendLayout();
            panelRCD.SuspendLayout();
            statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgListOfApprovedReport).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSave, btnDelete, toolStripSeparator2, btnCancelPrint, toolStripSeparator1, btnDeposit, btnPrint, btnSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(916, 50);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save_filled_20px;
            btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(35, 39);
            btnSave.Text = "Save";
            btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "&Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // btnCancelPrint
            // 
            btnCancelPrint.Enabled = false;
            btnCancelPrint.Image = Properties.Resources.symbol_cancel_20px;
            btnCancelPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnCancelPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnCancelPrint.Name = "btnCancelPrint";
            btnCancelPrint.Size = new System.Drawing.Size(47, 39);
            btnCancelPrint.Text = "Cancel";
            btnCancelPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnCancelPrint.Click += btnCancelPrint_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // btnDeposit
            // 
            btnDeposit.Enabled = false;
            btnDeposit.Image = Properties.Resources.mailbox_in_filled_20px;
            btnDeposit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDeposit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new System.Drawing.Size(51, 39);
            btnDeposit.Text = "Deposit";
            btnDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDeposit.ToolTipText = "Deposit";
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnPrint
            // 
            btnPrint.Enabled = false;
            btnPrint.Image = Properties.Resources.printer_filled_20px;
            btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(45, 39);
            btnPrint.Text = "Print...";
            btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(55, 39);
            btnSearch.Text = "Search...";
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRemove.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRemove.Location = new System.Drawing.Point(838, 7);
            btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(74, 23);
            btnRemove.TabIndex = 28;
            btnRemove.Text = "Remove";
            btnRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnadd
            // 
            btnadd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            btnadd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnadd.Location = new System.Drawing.Point(762, 7);
            btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnadd.Name = "btnadd";
            btnadd.Size = new System.Drawing.Size(70, 23);
            btnadd.TabIndex = 26;
            btnadd.Text = "Add...";
            btnadd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // panelRCD
            // 
            panelRCD.BackColor = System.Drawing.Color.Transparent;
            panelRCD.Controls.Add(txtTotal);
            panelRCD.Controls.Add(label4);
            panelRCD.Controls.Add(btnRemove);
            panelRCD.Controls.Add(btnadd);
            panelRCD.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelRCD.Location = new System.Drawing.Point(0, 540);
            panelRCD.Name = "panelRCD";
            panelRCD.Size = new System.Drawing.Size(916, 36);
            panelRCD.TabIndex = 34;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Location = new System.Drawing.Point(42, 7);
            txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new System.Drawing.Size(229, 23);
            txtTotal.TabIndex = 30;
            txtTotal.Text = "0.00";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(2, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 15);
            label4.TabIndex = 29;
            label4.Text = "Total";
            // 
            // statusStrip2
            // 
            statusStrip2.BackColor = System.Drawing.Color.White;
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount });
            statusStrip2.Location = new System.Drawing.Point(0, 576);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(916, 22);
            statusStrip2.SizingGrip = false;
            statusStrip2.TabIndex = 35;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            toolStripStatusLabel1.Text = "Records : ";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // dgListOfApprovedReport
            // 
            dgListOfApprovedReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgListOfApprovedReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { reportId, collecting_officer, report_no, amount });
            dgListOfApprovedReport.Dock = System.Windows.Forms.DockStyle.Fill;
            dgListOfApprovedReport.Location = new System.Drawing.Point(4, 4);
            dgListOfApprovedReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgListOfApprovedReport.Name = "dgListOfApprovedReport";
            dgListOfApprovedReport.RowHeadersWidth = 51;
            dgListOfApprovedReport.RowTemplate.Height = 29;
            dgListOfApprovedReport.Size = new System.Drawing.Size(908, 445);
            dgListOfApprovedReport.TabIndex = 23;
            dgListOfApprovedReport.RowsAdded += dgListOfApprovedReport_RowsAdded;
            dgListOfApprovedReport.RowsRemoved += dgListOfApprovedReport_RowsRemoved;
            dgListOfApprovedReport.SelectionChanged += dgListOfApprovedReport_SelectionChanged;
            dgListOfApprovedReport.Validating += dgListOfApprovedReport_Validating;
            dgListOfApprovedReport.Validated += dgListOfApprovedReport_Validated;
            // 
            // reportId
            // 
            reportId.HeaderText = "Report Id";
            reportId.Name = "reportId";
            reportId.Visible = false;
            // 
            // collecting_officer
            // 
            collecting_officer.HeaderText = "Collecting Officer";
            collecting_officer.Name = "collecting_officer";
            collecting_officer.Width = 500;
            // 
            // report_no
            // 
            report_no.HeaderText = "Report No.";
            report_no.Name = "report_no";
            report_no.Width = 250;
            // 
            // amount
            // 
            amount.HeaderText = "Amount";
            amount.Name = "amount";
            amount.Width = 250;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbfunds);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtRCDNo);
            panel1.Controls.Add(dtpDate);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(916, 37);
            panel1.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(224, 7);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(4);
            label3.Size = new System.Drawing.Size(47, 23);
            label3.TabIndex = 38;
            label3.Text = "Funds";
            // 
            // cmbfunds
            // 
            cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbfunds.FormattingEnabled = true;
            cmbfunds.Location = new System.Drawing.Point(277, 7);
            cmbfunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbfunds.Name = "cmbfunds";
            cmbfunds.Size = new System.Drawing.Size(173, 23);
            cmbfunds.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 36;
            label2.Text = "RCD No.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(472, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 37;
            label1.Text = "Date";
            // 
            // txtRCDNo
            // 
            txtRCDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRCDNo.Location = new System.Drawing.Point(67, 7);
            txtRCDNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtRCDNo.MaxLength = 20;
            txtRCDNo.Name = "txtRCDNo";
            txtRCDNo.Size = new System.Drawing.Size(137, 23);
            txtRCDNo.TabIndex = 33;
            txtRCDNo.Validating += txtRCDNo_Validating;
            txtRCDNo.Validated += txtRCDNo_Validated;
            // 
            // dtpDate
            // 
            dtpDate.Location = new System.Drawing.Point(506, 7);
            dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(211, 23);
            dtpDate.TabIndex = 35;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgListOfApprovedReport);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 87);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(916, 453);
            panel2.TabIndex = 37;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmRCD
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(916, 598);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelRCD);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip2);
            MinimizeBox = false;
            Name = "frmRCD";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Liquidator's Report of Collections and Deposits (RCD)";
            Load += frmRCD_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelRCD.ResumeLayout(false);
            panelRCD.PerformLayout();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgListOfApprovedReport).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripButton btnSearch;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.Panel panelRCD;
        internal System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        internal System.Windows.Forms.ToolStripButton btnCancelPrint;
        internal System.Windows.Forms.ToolStripButton btnDeposit;
        internal System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbfunds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtRCDNo;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgListOfApprovedReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn collecting_officer;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}