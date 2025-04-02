namespace LFS.Views.Reports.ReleasedAndUnreleasedCheques
{
    partial class frmReleasedUnreleasedChecksReport
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
            panel1 = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            radUnreleased = new System.Windows.Forms.RadioButton();
            radReleased = new System.Windows.Forms.RadioButton();
            dtpPeriodCovered = new System.Windows.Forms.DateTimePicker();
            cmbBank = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cmbBankAccounts = new System.Windows.Forms.ComboBox();
            btnRunReport = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(4, 9);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(602, 393);
            panel1.TabIndex = 13;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 16;
            statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(progressBar1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(840, 406);
            splitContainer1.SplitterDistance = 226;
            splitContainer1.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dtpPeriodCovered);
            panel2.Controls.Add(cmbBank);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cmbBankAccounts);
            panel2.Controls.Add(btnRunReport);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(226, 406);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.Controls.Add(radUnreleased);
            panel3.Controls.Add(radReleased);
            panel3.Location = new System.Drawing.Point(12, 27);
            panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(200, 23);
            panel3.TabIndex = 25;
            // 
            // radUnreleased
            // 
            radUnreleased.AutoSize = true;
            radUnreleased.Location = new System.Drawing.Point(80, 3);
            radUnreleased.Name = "radUnreleased";
            radUnreleased.Size = new System.Drawing.Size(83, 19);
            radUnreleased.TabIndex = 0;
            radUnreleased.Text = "Unreleased";
            radUnreleased.UseVisualStyleBackColor = true;
            // 
            // radReleased
            // 
            radReleased.AutoSize = true;
            radReleased.Checked = true;
            radReleased.Location = new System.Drawing.Point(3, 3);
            radReleased.Name = "radReleased";
            radReleased.Size = new System.Drawing.Size(71, 19);
            radReleased.TabIndex = 0;
            radReleased.TabStop = true;
            radReleased.Text = "Released";
            radReleased.UseVisualStyleBackColor = true;
            // 
            // dtpPeriodCovered
            // 
            dtpPeriodCovered.CustomFormat = "MMMM dd, yyyy";
            dtpPeriodCovered.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpPeriodCovered.Location = new System.Drawing.Point(12, 179);
            dtpPeriodCovered.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtpPeriodCovered.Name = "dtpPeriodCovered";
            dtpPeriodCovered.Size = new System.Drawing.Size(200, 23);
            dtpPeriodCovered.TabIndex = 23;
            // 
            // cmbBank
            // 
            cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new System.Drawing.Point(12, 77);
            cmbBank.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new System.Drawing.Size(200, 23);
            cmbBank.TabIndex = 24;
            cmbBank.SelectionChangeCommitted += cmbBank_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 161);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 15);
            label1.TabIndex = 22;
            label1.Text = "Period Covered:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 110);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 15);
            label2.TabIndex = 22;
            label2.Text = "Bank Account:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 23;
            label4.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 23;
            label3.Text = "Bank:";
            // 
            // cmbBankAccounts
            // 
            cmbBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBankAccounts.FormattingEnabled = true;
            cmbBankAccounts.Location = new System.Drawing.Point(12, 128);
            cmbBankAccounts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbBankAccounts.Name = "cmbBankAccounts";
            cmbBankAccounts.Size = new System.Drawing.Size(200, 23);
            cmbBankAccounts.TabIndex = 0;
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(12, 215);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(602, 5);
            progressBar1.TabIndex = 14;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmReleasedUnreleasedChecksReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmReleasedUnreleasedChecksReport";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Schedule of Released  and Unreleased Cheques";
            Load += frmReleasedChequesReport_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpPeriodCovered;
        internal System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBankAccounts;
        private System.Windows.Forms.Button btnRunReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radUnreleased;
        private System.Windows.Forms.RadioButton radReleased;
        private System.Windows.Forms.Label label4;
    }
}