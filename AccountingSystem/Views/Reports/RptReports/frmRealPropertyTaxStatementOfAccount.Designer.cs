
namespace LFS.Views.Reports.RptReports
{
    partial class frmRealPropertyTaxStatementOfAccount
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2 = new System.Windows.Forms.Panel();
            dtPeriodTo = new System.Windows.Forms.DateTimePicker();
            dtPeriodFrom = new System.Windows.Forms.DateTimePicker();
            btnRunReport = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cmbxProperty = new System.Windows.Forms.ComboBox();
            cmbxOwner = new System.Windows.Forms.ComboBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 42);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1070, 437);
            panel1.TabIndex = 5;
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
            panel2.Controls.Add(dtPeriodTo);
            panel2.Controls.Add(dtPeriodFrom);
            panel2.Controls.Add(btnRunReport);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbxProperty);
            panel2.Controls.Add(cmbxOwner);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1070, 37);
            panel2.TabIndex = 3;
            // 
            // dtPeriodTo
            // 
            dtPeriodTo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtPeriodTo.CustomFormat = "MMM dd, yyyy";
            dtPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPeriodTo.Location = new System.Drawing.Point(844, 7);
            dtPeriodTo.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            dtPeriodTo.Name = "dtPeriodTo";
            dtPeriodTo.Size = new System.Drawing.Size(106, 23);
            dtPeriodTo.TabIndex = 3;
            // 
            // dtPeriodFrom
            // 
            dtPeriodFrom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtPeriodFrom.CustomFormat = "MMM dd, yyyy";
            dtPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPeriodFrom.Location = new System.Drawing.Point(711, 7);
            dtPeriodFrom.Name = "dtPeriodFrom";
            dtPeriodFrom.Size = new System.Drawing.Size(106, 23);
            dtPeriodFrom.TabIndex = 2;
            // 
            // btnRunReport
            // 
            btnRunReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRunReport.Location = new System.Drawing.Point(963, 7);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(100, 23);
            btnRunReport.TabIndex = 4;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(823, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 15);
            label4.TabIndex = 1;
            label4.Text = ">";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(666, 11);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 15);
            label3.TabIndex = 1;
            label3.Text = "Period";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(395, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Property";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(134, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Owner";
            // 
            // cmbxProperty
            // 
            cmbxProperty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxProperty.FormattingEnabled = true;
            cmbxProperty.Location = new System.Drawing.Point(453, 7);
            cmbxProperty.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            cmbxProperty.Name = "cmbxProperty";
            cmbxProperty.Size = new System.Drawing.Size(200, 23);
            cmbxProperty.TabIndex = 1;
            // 
            // cmbxOwner
            // 
            cmbxOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxOwner.FormattingEnabled = true;
            cmbxOwner.Location = new System.Drawing.Point(182, 8);
            cmbxOwner.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            cmbxOwner.Name = "cmbxOwner";
            cmbxOwner.Size = new System.Drawing.Size(200, 23);
            cmbxOwner.TabIndex = 0;
            cmbxOwner.SelectedValueChanged += cmbxOwner_SelectedValueChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 37);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1070, 5);
            progressBar1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1070, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmRealPropertyTaxStatementOfAccount
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1070, 501);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(progressBar1);
            Controls.Add(panel2);
            KeyPreview = true;
            MinimizeBox = false;
            Name = "frmRealPropertyTaxStatementOfAccount";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Properties > Real Property Tax Statement of Account";
            Load += frmRealPropertyTaxStatementOfAccount_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxOwner;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxProperty;
        private System.Windows.Forms.DateTimePicker dtPeriodFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPeriodTo;
        private System.Windows.Forms.Label label4;
    }
}
