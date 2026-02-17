namespace LFS.Views.Reports.Ltoms
{
    partial class frmLtom17to19
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            cmbxDelinquentNoticeRecord = new System.Windows.Forms.ComboBox();
            flwLayoutType = new System.Windows.Forms.FlowLayoutPanel();
            rad1stNotice = new System.Windows.Forms.RadioButton();
            rad2ndNotice = new System.Windows.Forms.RadioButton();
            rad3rdNotice = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            txtRpt = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            pbReport = new System.Windows.Forms.ProgressBar();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flwLayoutType.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 1;
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
            splitContainer1.Panel1.Controls.Add(cmbxDelinquentNoticeRecord);
            splitContainer1.Panel1.Controls.Add(flwLayoutType);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(btnRunReport);
            splitContainer1.Panel1.Controls.Add(txtRpt);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Controls.Add(pbReport);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(840, 406);
            splitContainer1.SplitterDistance = 226;
            splitContainer1.TabIndex = 2;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // cmbxDelinquentNoticeRecord
            // 
            cmbxDelinquentNoticeRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxDelinquentNoticeRecord.FormattingEnabled = true;
            cmbxDelinquentNoticeRecord.Location = new System.Drawing.Point(12, 164);
            cmbxDelinquentNoticeRecord.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxDelinquentNoticeRecord.Name = "cmbxDelinquentNoticeRecord";
            cmbxDelinquentNoticeRecord.Size = new System.Drawing.Size(200, 23);
            cmbxDelinquentNoticeRecord.TabIndex = 16;
            // 
            // flwLayoutType
            // 
            flwLayoutType.Controls.Add(rad1stNotice);
            flwLayoutType.Controls.Add(rad2ndNotice);
            flwLayoutType.Controls.Add(rad3rdNotice);
            flwLayoutType.Location = new System.Drawing.Point(12, 29);
            flwLayoutType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            flwLayoutType.Name = "flwLayoutType";
            flwLayoutType.Size = new System.Drawing.Size(200, 56);
            flwLayoutType.TabIndex = 15;
            // 
            // rad1stNotice
            // 
            rad1stNotice.AutoSize = true;
            rad1stNotice.Checked = true;
            rad1stNotice.Location = new System.Drawing.Point(3, 3);
            rad1stNotice.Name = "rad1stNotice";
            rad1stNotice.Size = new System.Drawing.Size(78, 19);
            rad1stNotice.TabIndex = 11;
            rad1stNotice.TabStop = true;
            rad1stNotice.Text = "1st Notice";
            rad1stNotice.UseVisualStyleBackColor = true;
            rad1stNotice.CheckedChanged += rad1stNotice_CheckedChanged;
            // 
            // rad2ndNotice
            // 
            rad2ndNotice.AutoSize = true;
            rad2ndNotice.Location = new System.Drawing.Point(87, 3);
            rad2ndNotice.Name = "rad2ndNotice";
            rad2ndNotice.Size = new System.Drawing.Size(83, 19);
            rad2ndNotice.TabIndex = 9;
            rad2ndNotice.Text = "2nd Notice";
            rad2ndNotice.UseVisualStyleBackColor = true;
            rad2ndNotice.CheckedChanged += rad2ndNotice_CheckedChanged;
            // 
            // rad3rdNotice
            // 
            rad3rdNotice.AutoSize = true;
            rad3rdNotice.Location = new System.Drawing.Point(3, 28);
            rad3rdNotice.Name = "rad3rdNotice";
            rad3rdNotice.Size = new System.Drawing.Size(80, 19);
            rad3rdNotice.TabIndex = 10;
            rad3rdNotice.Text = "3rd Notice";
            rad3rdNotice.UseVisualStyleBackColor = true;
            rad3rdNotice.CheckedChanged += rad3rdNotice_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 9);
            label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 15);
            label4.TabIndex = 13;
            label4.Text = "Type :";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(12, 200);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 12;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // txtRpt
            // 
            txtRpt.Location = new System.Drawing.Point(12, 113);
            txtRpt.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtRpt.Name = "txtRpt";
            txtRpt.Size = new System.Drawing.Size(200, 23);
            txtRpt.TabIndex = 5;
            txtRpt.TextChanged += txtRpt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(12, 95);
            label1.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 7;
            label1.Text = "ARP No. : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(12, 146);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(157, 15);
            label3.TabIndex = 7;
            label3.Text = "Delinquency Notice Record :";
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 9);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(602, 393);
            panel3.TabIndex = 10;
            // 
            // pbReport
            // 
            pbReport.Dock = System.Windows.Forms.DockStyle.Top;
            pbReport.Location = new System.Drawing.Point(4, 4);
            pbReport.Name = "pbReport";
            pbReport.Size = new System.Drawing.Size(602, 5);
            pbReport.TabIndex = 9;
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
            // frmLtom17to19
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmLtom17to19";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > LTOM Form No. (17-19) - Notice of Real Property Tax Delinquency";
            Load += frmLtom17to19_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flwLayoutType.ResumeLayout(false);
            flwLayoutType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rad2ndNotice;
        private System.Windows.Forms.TextBox txtRpt;
        private System.Windows.Forms.RadioButton rad3rdNotice;
        private System.Windows.Forms.RadioButton rad1stNotice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar pbReport;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.FlowLayoutPanel flwLayoutType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxDelinquentNoticeRecord;
    }
}
