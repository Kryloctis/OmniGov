
namespace LFS.Budget.Views.Reports
{
    partial class frmSAAOB
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
            panel3 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            chkbxSpecialAccounts = new System.Windows.Forms.CheckBox();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbxFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panelReport = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            lblProgress = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(chkbxSpecialAccounts);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(225, 535);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label3);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(4, 4);
            panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(217, 40);
            panel3.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.filter_20px;
            pictureBox1.Location = new System.Drawing.Point(8, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(23, 24);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label3.Location = new System.Drawing.Point(37, 13);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(40, 15);
            label3.TabIndex = 11;
            label3.Text = "FILTER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 137);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 15);
            label2.TabIndex = 8;
            label2.Text = "As of:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 86);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 8;
            label1.Text = "Fund Type:";
            // 
            // chkbxSpecialAccounts
            // 
            chkbxSpecialAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkbxSpecialAccounts.AutoSize = true;
            chkbxSpecialAccounts.Location = new System.Drawing.Point(93, 57);
            chkbxSpecialAccounts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            chkbxSpecialAccounts.Name = "chkbxSpecialAccounts";
            chkbxSpecialAccounts.Size = new System.Drawing.Size(119, 19);
            chkbxSpecialAccounts.TabIndex = 7;
            chkbxSpecialAccounts.Text = "Special Accounts ";
            chkbxSpecialAccounts.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            dtAsOf.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(12, 155);
            dtAsOf.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(200, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(12, 104);
            cmbxFund.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(200, 23);
            cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(12, 198);
            btnRetrieve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(200, 27);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panelReport
            // 
            panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReport.Location = new System.Drawing.Point(4, 24);
            panelReport.Name = "panelReport";
            panelReport.Size = new System.Drawing.Size(580, 507);
            panelReport.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 535);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(813, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // panel2
            // 
            panel2.Controls.Add(panelReport);
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(lblProgress);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(225, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(588, 535);
            panel2.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 19);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(580, 5);
            progressBar1.TabIndex = 6;
            // 
            // lblProgress
            // 
            lblProgress.Dock = System.Windows.Forms.DockStyle.Top;
            lblProgress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblProgress.Location = new System.Drawing.Point(4, 4);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(580, 15);
            lblProgress.TabIndex = 7;
            lblProgress.Text = "0%";
            lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSaaobb
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(813, 557);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(829, 596);
            Name = "frmSaaobb";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Statement of Appropriations, Allotments, Obligations and Balances (SAAOBB)";
            Load += frmSAAOBB_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.Button btnRetrieve;
        internal System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.CheckBox chkbxSpecialAccounts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}
