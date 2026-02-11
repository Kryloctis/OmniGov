
namespace LFS.Views.Reports.JEV
{
    partial class frmJEVReport
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.Panel();
            pnlRprt = new System.Windows.Forms.Panel();
            pbJevRprt = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxJev = new System.Windows.Forms.ComboBox();
            btnRunRprt = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 495);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(743, 22);
            statusStrip1.TabIndex = 2;
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
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 44);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new System.Drawing.Size(743, 451);
            splitContainer1.SplitterDistance = 494;
            splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlRprt);
            panel1.Controls.Add(pbJevRprt);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(494, 451);
            panel1.TabIndex = 3;
            // 
            // pnlRprt
            // 
            pnlRprt.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlRprt.Location = new System.Drawing.Point(4, 9);
            pnlRprt.Name = "pnlRprt";
            pnlRprt.Size = new System.Drawing.Size(486, 438);
            pnlRprt.TabIndex = 1;
            // 
            // pbJevRprt
            // 
            pbJevRprt.Dock = System.Windows.Forms.DockStyle.Top;
            pbJevRprt.Location = new System.Drawing.Point(4, 4);
            pbJevRprt.Name = "pbJevRprt";
            pbJevRprt.Size = new System.Drawing.Size(486, 5);
            pbJevRprt.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxJev);
            panel2.Controls.Add(btnRunRprt);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(20);
            panel2.Size = new System.Drawing.Size(245, 451);
            panel2.TabIndex = 1;
            // 
            // cmbxJev
            // 
            cmbxJev.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbxJev.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbxJev.FormattingEnabled = true;
            cmbxJev.Location = new System.Drawing.Point(23, 38);
            cmbxJev.Name = "cmbxJev";
            cmbxJev.Size = new System.Drawing.Size(199, 23);
            cmbxJev.TabIndex = 6;
            // 
            // btnRunRprt
            // 
            btnRunRprt.Location = new System.Drawing.Point(23, 110);
            btnRunRprt.Name = "btnRunRprt";
            btnRunRprt.Size = new System.Drawing.Size(199, 23);
            btnRunRprt.TabIndex = 0;
            btnRunRprt.Text = "Run Report";
            btnRunRprt.UseVisualStyleBackColor = true;
            btnRunRprt.Click += btnRunRprt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(53, 64);
            label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(169, 13);
            label2.TabIndex = 5;
            label2.Text = "(ex. last digit of JEV No. ....0232)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 5;
            label1.Text = "JEV No.";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel2 });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4, 10, 20, 10);
            toolStrip1.Size = new System.Drawing.Size(743, 44);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(223, 21);
            toolStripLabel2.Text = "Journal Entry Voucher Report";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmJEVReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(743, 517);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            Name = "frmJEVReport";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Journal Entry Voucher (JEV)";
            Load += frmJEVReport_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlRprt;
        private System.Windows.Forms.ProgressBar pbJevRprt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRunRprt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbxJev;
    }
}