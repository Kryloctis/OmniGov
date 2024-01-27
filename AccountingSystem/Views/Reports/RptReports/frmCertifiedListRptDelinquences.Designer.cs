
namespace AccountingSystem.Views.Reports.RptReports
{
    partial class frmCertifiedListRptDelinquences
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
            dtTo = new System.Windows.Forms.DateTimePicker();
            dtFrom = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 42);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(895, 437);
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
            pbLoadRecords.Size = new System.Drawing.Size(895, 5);
            pbLoadRecords.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtTo);
            panel1.Controls.Add(dtFrom);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnRunReport);
            panel1.Controls.Add(cmbxBarangays);
            panel1.Controls.Add(label2);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(895, 37);
            panel1.TabIndex = 23;
            // 
            // dtTo
            // 
            dtTo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtTo.CustomFormat = "MMM dd, yyyy";
            dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTo.Location = new System.Drawing.Point(655, 7);
            dtTo.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            dtTo.Name = "dtTo";
            dtTo.Size = new System.Drawing.Size(120, 23);
            dtTo.TabIndex = 11;
            // 
            // dtFrom
            // 
            dtFrom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtFrom.CustomFormat = "MMM dd, yyyy";
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.Location = new System.Drawing.Point(508, 7);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new System.Drawing.Size(120, 23);
            dtFrom.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(634, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 15);
            label1.TabIndex = 13;
            label1.Text = ">";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(461, 11);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 15);
            label5.TabIndex = 14;
            label5.Text = "Period";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRunReport
            // 
            btnRunReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRunReport.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRunReport.Location = new System.Drawing.Point(788, 7);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(100, 23);
            btnRunReport.TabIndex = 10;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(283, 7);
            cmbxBarangays.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(165, 23);
            cmbxBarangays.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(221, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Barangay";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(895, 22);
            statusStrip1.TabIndex = 24;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmCertifiedListOfTaxDelinquences
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(895, 501);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(pbLoadRecords);
            Controls.Add(panel1);
            MinimizeBox = false;
            Name = "frmCertifiedListOfTaxDelinquences";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Properties > Certified List of Real Property Tax Delinquencies";
            Load += frmCertifiedListOfTaxDelinquences_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ComboBox cmbxBarangays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
