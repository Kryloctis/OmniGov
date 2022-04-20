
namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    partial class ucTreasuryDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnReportCollections = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnIssueReceipt = new System.Windows.Forms.Button();
            this.btnPaymentCollection = new System.Windows.Forms.Button();
            this.btnIssueCheck = new System.Windows.Forms.Button();
            this.btnBankDeposit = new System.Windows.Forms.Button();
            this.btnReportOfCollections = new System.Windows.Forms.Button();
            this.btnRCD = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 361);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // btnReportCollections
            // 
            this.btnReportCollections.Enabled = false;
            this.btnReportCollections.Image = global::AccountingSystem.Properties.Resources.money_banknotes_document_text_28px;
            this.btnReportCollections.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportCollections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportCollections.Name = "btnReportCollections";
            this.btnReportCollections.Size = new System.Drawing.Size(150, 32);
            this.btnReportCollections.Text = "Report of Collections";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnIssueReceipt);
            this.flowLayoutPanel1.Controls.Add(this.btnPaymentCollection);
            this.flowLayoutPanel1.Controls.Add(this.btnIssueCheck);
            this.flowLayoutPanel1.Controls.Add(this.btnBankDeposit);
            this.flowLayoutPanel1.Controls.Add(this.btnReportOfCollections);
            this.flowLayoutPanel1.Controls.Add(this.btnRCD);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1074, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnIssueReceipt
            // 
            this.btnIssueReceipt.AutoSize = true;
            this.btnIssueReceipt.Image = global::AccountingSystem.Properties.Resources.document_delivery_receipt_user_filled_20px;
            this.btnIssueReceipt.Location = new System.Drawing.Point(0, 0);
            this.btnIssueReceipt.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnIssueReceipt.Name = "btnIssueReceipt";
            this.btnIssueReceipt.Size = new System.Drawing.Size(110, 30);
            this.btnIssueReceipt.TabIndex = 0;
            this.btnIssueReceipt.Text = "Issue Receipts";
            this.btnIssueReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssueReceipt.UseVisualStyleBackColor = true;
            this.btnIssueReceipt.Click += new System.EventHandler(this.btnIssueReceipt_Click);
            // 
            // btnPaymentCollection
            // 
            this.btnPaymentCollection.AutoSize = true;
            this.btnPaymentCollection.Image = global::AccountingSystem.Properties.Resources.money_banknote_filled_archive_20px;
            this.btnPaymentCollection.Location = new System.Drawing.Point(113, 0);
            this.btnPaymentCollection.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnPaymentCollection.Name = "btnPaymentCollection";
            this.btnPaymentCollection.Size = new System.Drawing.Size(146, 30);
            this.btnPaymentCollection.TabIndex = 0;
            this.btnPaymentCollection.Text = "Payment Collections";
            this.btnPaymentCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaymentCollection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaymentCollection.UseVisualStyleBackColor = true;
            this.btnPaymentCollection.Click += new System.EventHandler(this.btnPaymentCollection_Click);
            // 
            // btnIssueCheck
            // 
            this.btnIssueCheck.AutoSize = true;
            this.btnIssueCheck.Image = global::AccountingSystem.Properties.Resources.check_20px;
            this.btnIssueCheck.Location = new System.Drawing.Point(262, 0);
            this.btnIssueCheck.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnIssueCheck.Name = "btnIssueCheck";
            this.btnIssueCheck.Size = new System.Drawing.Size(118, 30);
            this.btnIssueCheck.TabIndex = 0;
            this.btnIssueCheck.Text = "Check Issuance";
            this.btnIssueCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssueCheck.UseVisualStyleBackColor = true;
            this.btnIssueCheck.Click += new System.EventHandler(this.BtnRCI_Click);
            // 
            // btnBankDeposit
            // 
            this.btnBankDeposit.AutoSize = true;
            this.btnBankDeposit.Image = global::AccountingSystem.Properties.Resources.bank_deposit_filled_20px;
            this.btnBankDeposit.Location = new System.Drawing.Point(383, 0);
            this.btnBankDeposit.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnBankDeposit.Name = "btnBankDeposit";
            this.btnBankDeposit.Size = new System.Drawing.Size(106, 30);
            this.btnBankDeposit.TabIndex = 0;
            this.btnBankDeposit.Text = "Bank Deposit";
            this.btnBankDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBankDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBankDeposit.UseVisualStyleBackColor = true;
            this.btnBankDeposit.Click += new System.EventHandler(this.btnBankDeposit_Click);
            // 
            // btnReportOfCollections
            // 
            this.btnReportOfCollections.AutoSize = true;
            this.btnReportOfCollections.Image = global::AccountingSystem.Properties.Resources.money_banknotes_2_document_text_20px;
            this.btnReportOfCollections.Location = new System.Drawing.Point(492, 0);
            this.btnReportOfCollections.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnReportOfCollections.Name = "btnReportOfCollections";
            this.btnReportOfCollections.Size = new System.Drawing.Size(119, 30);
            this.btnReportOfCollections.TabIndex = 0;
            this.btnReportOfCollections.Text = "Collector\'s RCD";
            this.btnReportOfCollections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportOfCollections.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportOfCollections.UseVisualStyleBackColor = true;
            this.btnReportOfCollections.Click += new System.EventHandler(this.btnReportOfCollections_Click);
            // 
            // btnRCD
            // 
            this.btnRCD.AutoSize = true;
            this.btnRCD.Image = global::AccountingSystem.Properties.Resources.report_document_text_20px;
            this.btnRCD.Location = new System.Drawing.Point(614, 0);
            this.btnRCD.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnRCD.Name = "btnRCD";
            this.btnRCD.Size = new System.Drawing.Size(134, 30);
            this.btnRCD.TabIndex = 0;
            this.btnRCD.Text = "Liquidator\'s RCD";
            this.btnRCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRCD.UseVisualStyleBackColor = true;
            this.btnRCD.Click += new System.EventHandler(this.btnGenerateRCD_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Image = global::AccountingSystem.Properties.Resources.building_1_filled_browse_small_1x;
            this.button1.Location = new System.Drawing.Point(751, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Real Property";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucTreasuryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucTreasuryDashboard";
            this.Size = new System.Drawing.Size(1074, 391);
            this.Load += new System.EventHandler(this.ucTreasuryDashboard_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.ToolStripButton btnReportCollections;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnIssueReceipt;
        internal System.Windows.Forms.Button btnPaymentCollection;
        internal System.Windows.Forms.Button btnIssueCheck;
        internal System.Windows.Forms.Button btnBankDeposit;
        internal System.Windows.Forms.Button btnReportOfCollections;
        internal System.Windows.Forms.Button btnRCD;
        internal System.Windows.Forms.Button button1;
    }
}
