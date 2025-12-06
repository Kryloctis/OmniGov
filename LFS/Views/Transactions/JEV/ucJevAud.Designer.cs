namespace LFS.Views.Transactions.JEV
{
    partial class ucJevAud
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
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            panel3 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            pnlRprt = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(pnlRprt);
            splitContainer2.Panel2.Controls.Add(progressBar1);
            splitContainer2.Size = new System.Drawing.Size(375, 329);
            splitContainer2.SplitterDistance = 82;
            splitContainer2.TabIndex = 24;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(textBox1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(20);
            panel3.Size = new System.Drawing.Size(375, 82);
            panel3.TabIndex = 0;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label7.Location = new System.Drawing.Point(177, 20);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(175, 15);
            label7.TabIndex = 2;
            label7.Text = "Provide feedback for the action.";
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Location = new System.Drawing.Point(23, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(329, 23);
            textBox1.TabIndex = 1;
            // 
            // pnlRprt
            // 
            pnlRprt.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlRprt.Location = new System.Drawing.Point(0, 5);
            pnlRprt.Name = "pnlRprt";
            pnlRprt.Padding = new System.Windows.Forms.Padding(4);
            pnlRprt.Size = new System.Drawing.Size(375, 238);
            pnlRprt.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(375, 5);
            progressBar1.TabIndex = 1;
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
            // ucJevAud
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(splitContainer2);
            Name = "ucJevAud";
            Size = new System.Drawing.Size(375, 329);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlRprt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
