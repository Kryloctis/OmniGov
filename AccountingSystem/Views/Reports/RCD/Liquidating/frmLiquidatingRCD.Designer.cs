
namespace AccountingSystem.Views.Reports.RCD.Liquidating
{
    partial class frmLiquidatingRCD
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
            this.panelReport = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelReport
            // 
            this.panelReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReport.Location = new System.Drawing.Point(11, 10);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(1135, 527);
            this.panelReport.TabIndex = 21;
            // 
            // frmLiquidatingRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 547);
            this.Controls.Add(this.panelReport);
            this.Name = "frmLiquidatingRCD";
            this.ShowInTaskbar = false;
            this.Text = "Reports > Liquidating Reports of Collections and Deposits  ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLiquidatingRCD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReport;
    }
}