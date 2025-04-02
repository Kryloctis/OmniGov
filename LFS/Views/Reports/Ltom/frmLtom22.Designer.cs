namespace LFS.Views.Reports.Ltom
{
    partial class frmLtom22
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
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            btnRunReport = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            pbReport = new System.Windows.Forms.ProgressBar();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 0;
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
            splitContainer1.Panel1.Controls.Add(dateTimePicker1);
            splitContainer1.Panel1.Controls.Add(btnRunReport);
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
            splitContainer1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMM dd, yyyy";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new System.Drawing.Point(12, 27);
            dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            dateTimePicker1.TabIndex = 20;
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(12, 63);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 19;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(12, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 15);
            label3.TabIndex = 17;
            label3.Text = "Date:";
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(splitContainer2);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 9);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(602, 393);
            panel3.TabIndex = 12;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Size = new System.Drawing.Size(602, 393);
            splitContainer2.SplitterDistance = 203;
            splitContainer2.TabIndex = 0;
            // 
            // pbReport
            // 
            pbReport.Dock = System.Windows.Forms.DockStyle.Top;
            pbReport.Location = new System.Drawing.Point(4, 4);
            pbReport.Name = "pbReport";
            pbReport.Size = new System.Drawing.Size(602, 5);
            pbReport.TabIndex = 11;
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
            // reportViewer2
            // 
            reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportViewer2.Location = new System.Drawing.Point(0, 0);
            reportViewer2.Name = "ReportViewer";
            reportViewer2.ServerReport.BearerToken = null;
            reportViewer2.Size = new System.Drawing.Size(396, 246);
            reportViewer2.TabIndex = 0;
            // 
            // frmLtom22
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmLtom22";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > LTOM Form No. 22 - Report of Levy (Sanggunian)";
            Load += frmLtom22_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar pbReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}