
namespace AccountingSystem.Views.Reports.RptReports
{
    partial class frmCertifiedListOfTaxDelinquences
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
            panel2 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            btnRunReport = new System.Windows.Forms.Button();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 42);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1141, 597);
            panel2.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 37);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(1141, 5);
            pbLoadRecords.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRunReport);
            panel1.Controls.Add(cmbxBarangays);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1141, 37);
            panel1.TabIndex = 23;
            // 
            // btnRunReport
            // 
            btnRunReport.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRunReport.Location = new System.Drawing.Point(1052, 7);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(82, 23);
            btnRunReport.TabIndex = 10;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(694, 7);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(165, 23);
            cmbxBarangays.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(632, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Barangay";
            // 
            // dtAsOf
            // 
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(915, 7);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(120, 23);
            dtAsOf.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(875, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 8;
            label1.Text = "As of";
            // 
            // frmCertifiedListOfTaxDelinquences
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1141, 639);
            Controls.Add(panel2);
            Controls.Add(pbLoadRecords);
            Controls.Add(panel1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1157, 678);
            Name = "frmCertifiedListOfTaxDelinquences";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Collection/Payment > Certified List of Real Property Tax Delinquencies";
            Load += frmCertifiedListOfTaxDelinquences_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ComboBox cmbxBarangays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.Label label1;
    }
}
