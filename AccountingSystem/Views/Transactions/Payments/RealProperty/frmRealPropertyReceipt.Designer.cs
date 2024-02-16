using AccountingSystem.Views.Transactions.Payments;
namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    partial class frmRealPropertyReceipt
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnPrint = new System.Windows.Forms.ToolStripButton();
            panel1 = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            bgwAf56 = new System.ComponentModel.BackgroundWorker();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.ShowExportButton = false;
            reportViewer1.ShowFindControls = false;
            reportViewer1.ShowPrintButton = false;
            reportViewer1.ShowStopButton = false;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnPrint });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(887, 35);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            btnPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnPrint.Image = Properties.Resources.printer_filled_20px;
            btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(56, 24);
            btnPrint.Text = "Print";
            btnPrint.Click += btnPrint_Click;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 40);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(887, 488);
            panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 528);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(887, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 35);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(887, 5);
            progressBar1.TabIndex = 0;
            // 
            // bgwAf56
            // 
            bgwAf56.WorkerReportsProgress = true;
            bgwAf56.WorkerSupportsCancellation = true;
            bgwAf56.DoWork += bgwAf56_DoWork;
            bgwAf56.ProgressChanged += bgwAf56_ProgressChanged;
            bgwAf56.RunWorkerCompleted += bgwAf56_RunWorkerCompleted;
            // 
            // frmRealPropertyReceipt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(887, 550);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "frmRealPropertyReceipt";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Print Receipt";
            Load += frmPreviewReceipt_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwAf56;
    }
}
