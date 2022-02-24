
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancelPrint = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeposit = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtRCDNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgListOfApprovedReport = new System.Windows.Forms.DataGridView();
            this.reportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collecting_officer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.panelRCD = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbfunds = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.epRCDNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDgCollectorRepor = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListOfApprovedReport)).BeginInit();
            this.panelRCD.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRCDNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDgCollectorRepor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancelPrint,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnDeposit,
            this.btnPrint,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 50);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AccountingSystem.Properties.Resources.save28px;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 47);
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelPrint
            // 
            this.btnCancelPrint.Enabled = false;
            this.btnCancelPrint.Image = global::AccountingSystem.Properties.Resources.symbol_cancel_28px;
            this.btnCancelPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelPrint.Name = "btnCancelPrint";
            this.btnCancelPrint.Size = new System.Drawing.Size(47, 47);
            this.btnCancelPrint.Text = "Cancel";
            this.btnCancelPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelPrint.Click += new System.EventHandler(this.btnCancelPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Enabled = false;
            this.btnDeposit.Image = global::AccountingSystem.Properties.Resources.mailbox_in_filled_28px;
            this.btnDeposit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeposit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(51, 47);
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeposit.ToolTipText = "Deposit";
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::AccountingSystem.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(36, 47);
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Image = global::AccountingSystem.Properties.Resources.find_doc;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 47);
            this.btnSearch.Text = "S&earch...";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtRCDNo
            // 
            this.txtRCDNo.Location = new System.Drawing.Point(70, 12);
            this.txtRCDNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRCDNo.MaxLength = 20;
            this.txtRCDNo.Name = "txtRCDNo";
            this.txtRCDNo.Size = new System.Drawing.Size(137, 23);
            this.txtRCDNo.TabIndex = 0;
            this.txtRCDNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtRCDNo_Validating);
            this.txtRCDNo.Validated += new System.EventHandler(this.txtRCDNo_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "RCD No.";
            // 
            // dtpdate
            // 
            this.dtpdate.Location = new System.Drawing.Point(509, 12);
            this.dtpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(211, 23);
            this.dtpdate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Date";
            // 
            // dgListOfApprovedReport
            // 
            this.dgListOfApprovedReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgListOfApprovedReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListOfApprovedReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reportId,
            this.collecting_officer,
            this.report_no,
            this.amount});
            this.epDgCollectorRepor.SetIconAlignment(this.dgListOfApprovedReport, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.dgListOfApprovedReport.Location = new System.Drawing.Point(17, 42);
            this.dgListOfApprovedReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgListOfApprovedReport.Name = "dgListOfApprovedReport";
            this.dgListOfApprovedReport.RowHeadersWidth = 51;
            this.dgListOfApprovedReport.RowTemplate.Height = 29;
            this.dgListOfApprovedReport.Size = new System.Drawing.Size(880, 437);
            this.dgListOfApprovedReport.TabIndex = 22;
            this.dgListOfApprovedReport.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgListOfApprovedReport_RowsAdded);
            this.dgListOfApprovedReport.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgListOfApprovedReport_RowsRemoved);
            this.dgListOfApprovedReport.SelectionChanged += new System.EventHandler(this.dgListOfApprovedReport_SelectionChanged);
            this.dgListOfApprovedReport.Validating += new System.ComponentModel.CancelEventHandler(this.dgListOfApprovedReport_Validating);
            this.dgListOfApprovedReport.Validated += new System.EventHandler(this.dgListOfApprovedReport_Validated);
            // 
            // reportId
            // 
            this.reportId.HeaderText = "Report Id";
            this.reportId.Name = "reportId";
            this.reportId.Visible = false;
            // 
            // collecting_officer
            // 
            this.collecting_officer.HeaderText = "Collecting Officer";
            this.collecting_officer.Name = "collecting_officer";
            this.collecting_officer.Width = 500;
            // 
            // report_no
            // 
            this.report_no.HeaderText = "Report No.";
            this.report_no.Name = "report_no";
            this.report_no.Width = 250;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 250;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemove.Location = new System.Drawing.Point(821, 487);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(74, 23);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Remove";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnadd.Location = new System.Drawing.Point(745, 487);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(70, 23);
            this.btnadd.TabIndex = 26;
            this.btnadd.Text = "Add...";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // panelRCD
            // 
            this.panelRCD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRCD.BackColor = System.Drawing.Color.White;
            this.panelRCD.Controls.Add(this.label3);
            this.panelRCD.Controls.Add(this.cmbfunds);
            this.panelRCD.Controls.Add(this.txtTotal);
            this.panelRCD.Controls.Add(this.label4);
            this.panelRCD.Controls.Add(this.btnRemove);
            this.panelRCD.Controls.Add(this.btnadd);
            this.panelRCD.Controls.Add(this.label2);
            this.panelRCD.Controls.Add(this.label1);
            this.panelRCD.Controls.Add(this.txtRCDNo);
            this.panelRCD.Controls.Add(this.dtpdate);
            this.panelRCD.Controls.Add(this.dgListOfApprovedReport);
            this.panelRCD.Location = new System.Drawing.Point(0, 53);
            this.panelRCD.Name = "panelRCD";
            this.panelRCD.Size = new System.Drawing.Size(916, 520);
            this.panelRCD.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 12);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4);
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Funds";
            // 
            // cmbfunds
            // 
            this.cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfunds.FormattingEnabled = true;
            this.cmbfunds.Location = new System.Drawing.Point(280, 12);
            this.cmbfunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfunds.Name = "cmbfunds";
            this.cmbfunds.Size = new System.Drawing.Size(173, 23);
            this.cmbfunds.TabIndex = 1;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.Location = new System.Drawing.Point(55, 487);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(229, 23);
            this.txtTotal.TabIndex = 30;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Total";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.White;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCount});
            this.statusStrip2.Location = new System.Drawing.Point(0, 576);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(916, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 35;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Records : ";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 17);
            this.lblRecordCount.Text = "0";
            // 
            // epRCDNo
            // 
            this.epRCDNo.ContainerControl = this;
            // 
            // epDgCollectorRepor
            // 
            this.epDgCollectorRepor.ContainerControl = this;
            // 
            // frmRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(916, 598);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panelRCD);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "frmRCD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidator\'s Report of Collections and Deposits (RCD)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRCD_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListOfApprovedReport)).EndInit();
            this.panelRCD.ResumeLayout(false);
            this.panelRCD.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRCDNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDgCollectorRepor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripButton btnSearch;
        internal System.Windows.Forms.TextBox txtRCDNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.Panel panelRCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn collecting_officer;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.DataGridView dgListOfApprovedReport;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        internal System.Windows.Forms.ToolStripButton btnCancelPrint;
        private System.Windows.Forms.ErrorProvider epRCDNo;
        private System.Windows.Forms.ErrorProvider epDgCollectorRepor;
        internal System.Windows.Forms.ToolStripButton btnDeposit;
        internal System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbfunds;
    }
}