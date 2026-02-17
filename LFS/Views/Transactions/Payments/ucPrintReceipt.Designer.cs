namespace LFS.Views.Transactions.Payments.BurialPermit
{
    partial class ucPrintReceipt
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
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            lnkLblRefresh = new System.Windows.Forms.LinkLabel();
            btnPrintReceipt = new System.Windows.Forms.Button();
            cmbxPrinter = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            reportViewerPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(607, 436);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.Controls.Add(lnkLblRefresh);
            panel2.Controls.Add(btnPrintReceipt);
            panel2.Controls.Add(cmbxPrinter);
            panel2.Controls.Add(label1);
            panel2.Location = new System.Drawing.Point(3, 257);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(601, 179);
            panel2.TabIndex = 7;
            // 
            // lnkLblRefresh
            // 
            lnkLblRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lnkLblRefresh.AutoSize = true;
            lnkLblRefresh.Location = new System.Drawing.Point(351, 20);
            lnkLblRefresh.Name = "lnkLblRefresh";
            lnkLblRefresh.Size = new System.Drawing.Size(46, 15);
            lnkLblRefresh.TabIndex = 3;
            lnkLblRefresh.TabStop = true;
            lnkLblRefresh.Text = "Refresh";
            lnkLblRefresh.LinkClicked += lnkLblRefresh_LinkClicked;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnPrintReceipt.Location = new System.Drawing.Point(212, 74);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new System.Drawing.Size(185, 23);
            btnPrintReceipt.TabIndex = 2;
            btnPrintReceipt.Text = "Print Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            btnPrintReceipt.Click += btnPrint_Click;
            // 
            // cmbxPrinter
            // 
            cmbxPrinter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            cmbxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxPrinter.FormattingEnabled = true;
            cmbxPrinter.Location = new System.Drawing.Point(212, 38);
            cmbxPrinter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxPrinter.Name = "cmbxPrinter";
            cmbxPrinter.Size = new System.Drawing.Size(185, 23);
            cmbxPrinter.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(212, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Printer:";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatus.Location = new System.Drawing.Point(3, 179);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(601, 75);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "label2";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.ForestGreen;
            label2.Location = new System.Drawing.Point(3, 154);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(601, 25);
            label2.TabIndex = 8;
            label2.Text = "Transaction Saved!";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.button_ok_80px;
            pictureBox1.Location = new System.Drawing.Point(3, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(601, 87);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // reportViewerPrint
            // 
            reportViewerPrint.Location = new System.Drawing.Point(0, 0);
            reportViewerPrint.Name = "ReportViewer";
            reportViewerPrint.ServerReport.BearerToken = null;
            reportViewerPrint.Size = new System.Drawing.Size(396, 246);
            reportViewerPrint.TabIndex = 0;
            // 
            // ucBurialPermitReceipt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ucBurialPermitReceipt";
            Size = new System.Drawing.Size(607, 436);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPrint;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxPrinter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkLblRefresh;
    }
}
