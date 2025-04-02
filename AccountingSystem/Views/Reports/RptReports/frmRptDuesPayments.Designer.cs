
namespace LFS.Views.Reports.RptReports
{
    partial class frmRptDuesPayments
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
            label1 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1 = new System.Windows.Forms.Panel();
            dtFrom = new System.Windows.Forms.DateTimePicker();
            dtTo = new System.Windows.Forms.DateTimePicker();
            cmbxOwners = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel2 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(186, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Owner";
            // 
            // btnRunReport
            // 
            btnRunReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRunReport.Location = new System.Drawing.Point(770, 7);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(113, 23);
            btnRunReport.TabIndex = 0;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtFrom);
            panel1.Controls.Add(dtTo);
            panel1.Controls.Add(cmbxOwners);
            panel1.Controls.Add(btnRunReport);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(895, 38);
            panel1.TabIndex = 4;
            // 
            // dtFrom
            // 
            dtFrom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtFrom.CustomFormat = "MMM dd, yyyy";
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.Location = new System.Drawing.Point(494, 7);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new System.Drawing.Size(118, 23);
            dtFrom.TabIndex = 4;
            // 
            // dtTo
            // 
            dtTo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtTo.CustomFormat = "MMM dd, yyyy";
            dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTo.Location = new System.Drawing.Point(639, 7);
            dtTo.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            dtTo.Name = "dtTo";
            dtTo.Size = new System.Drawing.Size(118, 23);
            dtTo.TabIndex = 4;
            // 
            // cmbxOwners
            // 
            cmbxOwners.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxOwners.FormattingEnabled = true;
            cmbxOwners.Location = new System.Drawing.Point(234, 7);
            cmbxOwners.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            cmbxOwners.Name = "cmbxOwners";
            cmbxOwners.Size = new System.Drawing.Size(200, 23);
            cmbxOwners.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(618, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(15, 15);
            label2.TabIndex = 3;
            label2.Text = ">";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(447, 11);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 15);
            label3.TabIndex = 3;
            label3.Text = "Period";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(895, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 43);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(895, 436);
            panel2.TabIndex = 6;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 38);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(895, 5);
            progressBar1.TabIndex = 7;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmRptDuesPayments
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(895, 501);
            Controls.Add(panel2);
            Controls.Add(progressBar1);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            MinimizeBox = false;
            Name = "frmRptDuesPayments";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Properties > Real Property  Tax Dues and  Payments";
            Load += frmRealPropertyTaxAccountRegisterReport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnRunReport;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbxOwners;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
    }
}
