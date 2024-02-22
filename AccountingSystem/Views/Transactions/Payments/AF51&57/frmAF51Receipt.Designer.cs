namespace AccountingSystem.Views.Transactions.Payments.AF51_57
{
    partial class frmAF51Receipt
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnPrint = new System.Windows.Forms.ToolStripButton();
            reportViewerPreview = new Microsoft.Reporting.WinForms.ReportViewer();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(534, 554);
            panel1.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 589);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(534, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
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
            toolStrip1.Size = new System.Drawing.Size(534, 35);
            toolStrip1.TabIndex = 6;
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
            // reportViewer1
            // 
            reportViewerPreview.Location = new System.Drawing.Point(0, 0);
            reportViewerPreview.Name = "ReportViewer";
            reportViewerPreview.ServerReport.BearerToken = null;
            reportViewerPreview.Size = new System.Drawing.Size(396, 246);
            reportViewerPreview.TabIndex = 0;
            // 
            // frmAF51Receipt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(534, 611);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAF51Receipt";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Print Receipt";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPreview;
    }
}