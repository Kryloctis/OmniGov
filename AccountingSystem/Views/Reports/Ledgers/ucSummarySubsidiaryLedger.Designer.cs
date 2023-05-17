namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class ucSummarySubsidiaryLedger
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.cmbSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cmbxFunds);
            this.flowLayoutPanel1.Controls.Add(this.cmbxAccount);
            this.flowLayoutPanel1.Controls.Add(this.cmbSubsidiaryLedger);
            this.flowLayoutPanel1.Controls.Add(this.nudYear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1140, 37);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(7, 7);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(150, 23);
            this.cmbxFunds.TabIndex = 0;
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(163, 7);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbxAccount.TabIndex = 1;
            // 
            // cmbSubsidiaryLedger
            // 
            this.cmbSubsidiaryLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubsidiaryLedger.FormattingEnabled = true;
            this.cmbSubsidiaryLedger.Location = new System.Drawing.Point(539, 7);
            this.cmbSubsidiaryLedger.Name = "cmbSubsidiaryLedger";
            this.cmbSubsidiaryLedger.Size = new System.Drawing.Size(283, 23);
            this.cmbSubsidiaryLedger.TabIndex = 24;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(828, 7);
            this.nudYear.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.ReadOnly = true;
            this.nudYear.Size = new System.Drawing.Size(97, 23);
            this.nudYear.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1140, 5);
            this.progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 529);
            this.panel1.TabIndex = 2;
            // 
            // ucSummarySubsidiaryLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucSummarySubsidiaryLedger";
            this.Size = new System.Drawing.Size(1140, 571);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSubsidiaryLedger;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
