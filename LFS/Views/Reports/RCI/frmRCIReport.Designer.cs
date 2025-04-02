
namespace LFS.Views.Reports.RCI
{
    partial class frmRciReport
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
            panel2 = new System.Windows.Forms.Panel();
            cmbxBank = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cmbxBankAccounts = new System.Windows.Forms.ComboBox();
            dtpPeriodCover = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxBank);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cmbxBankAccounts);
            panel2.Controls.Add(dtpPeriodCover);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnRunReport);
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(4, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(230, 435);
            panel2.TabIndex = 13;
            // 
            // cmbxBank
            // 
            cmbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBank.FormattingEnabled = true;
            cmbxBank.Location = new System.Drawing.Point(12, 26);
            cmbxBank.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxBank.Name = "cmbxBank";
            cmbxBank.Size = new System.Drawing.Size(200, 23);
            cmbxBank.TabIndex = 24;
            cmbxBank.SelectionChangeCommitted += cmbxBank_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 15);
            label2.TabIndex = 22;
            label2.Text = "Bank Account:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 23;
            label3.Text = "Bank:";
            // 
            // cmbxBankAccounts
            // 
            cmbxBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBankAccounts.FormattingEnabled = true;
            cmbxBankAccounts.Location = new System.Drawing.Point(12, 80);
            cmbxBankAccounts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxBankAccounts.Name = "cmbxBankAccounts";
            cmbxBankAccounts.Size = new System.Drawing.Size(200, 23);
            cmbxBankAccounts.TabIndex = 0;
            cmbxBankAccounts.Validating += cmbxBanks_Validating;
            cmbxBankAccounts.Validated += cmbxBanks_Validated;
            // 
            // dtpPeriodCover
            // 
            dtpPeriodCover.CustomFormat = "MMMM - yyyy";
            dtpPeriodCover.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpPeriodCover.Location = new System.Drawing.Point(12, 131);
            dtpPeriodCover.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtpPeriodCover.Name = "dtpPeriodCover";
            dtpPeriodCover.Size = new System.Drawing.Size(200, 23);
            dtpPeriodCover.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 113);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 19;
            label1.Text = "Month:";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(12, 167);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 443);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(861, 22);
            statusStrip1.TabIndex = 14;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(234, 9);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(623, 430);
            panel1.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(progressBar1);
            panel3.Controls.Add(panel2);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(861, 443);
            panel3.TabIndex = 16;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(234, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(623, 5);
            progressBar1.TabIndex = 16;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmRCIReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(861, 465);
            Controls.Add(panel3);
            Controls.Add(statusStrip1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmRCIReport";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > Report of Checks Issued";
            Load += frmRCIReport_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxBankAccounts;
        private System.Windows.Forms.DateTimePicker dtpPeriodCover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.ComboBox cmbxBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}