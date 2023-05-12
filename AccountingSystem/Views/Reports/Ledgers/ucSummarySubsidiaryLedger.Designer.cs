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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxAccount = new System.Windows.Forms.ComboBox();
            cmbSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(cmbxFunds);
            flowLayoutPanel1.Controls.Add(cmbxAccount);
            flowLayoutPanel1.Controls.Add(cmbSubsidiaryLedger);
            flowLayoutPanel1.Controls.Add(nudYear);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1140, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(3, 3);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(150, 23);
            cmbxFunds.TabIndex = 0;
            // 
            // cmbxAccount
            // 
            cmbxAccount.FormattingEnabled = true;
            cmbxAccount.Location = new System.Drawing.Point(159, 3);
            cmbxAccount.Name = "cmbxAccount";
            cmbxAccount.Size = new System.Drawing.Size(370, 23);
            cmbxAccount.TabIndex = 1;
            // 
            // cmbSubsidiaryLedger
            // 
            cmbSubsidiaryLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSubsidiaryLedger.FormattingEnabled = true;
            cmbSubsidiaryLedger.Location = new System.Drawing.Point(535, 3);
            cmbSubsidiaryLedger.Name = "cmbSubsidiaryLedger";
            cmbSubsidiaryLedger.Size = new System.Drawing.Size(283, 23);
            cmbSubsidiaryLedger.TabIndex = 24;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(824, 3);
            nudYear.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(97, 23);
            nudYear.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 29);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1140, 5);
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 34);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1140, 537);
            panel1.TabIndex = 2;
            // 
            // ucSummarySubsidiaryLedger
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "ucSummarySubsidiaryLedger";
            Size = new System.Drawing.Size(1140, 571);
            Load += ucSummarySubsidiaryLedger_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
