
namespace LFS.Views.Reports.Saaobb
{
    partial class frmSaaobb
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
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            chkbxSpecialAccounts = new System.Windows.Forms.CheckBox();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbxFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panelReport = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(chkbxSpecialAccounts);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(588, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(225, 535);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 15);
            label2.TabIndex = 8;
            label2.Text = "As of:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 8;
            label1.Text = "Fund Type:";
            // 
            // chkbxSpecialAccounts
            // 
            chkbxSpecialAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkbxSpecialAccounts.AutoSize = true;
            chkbxSpecialAccounts.Location = new System.Drawing.Point(97, 12);
            chkbxSpecialAccounts.Name = "chkbxSpecialAccounts";
            chkbxSpecialAccounts.Size = new System.Drawing.Size(116, 19);
            chkbxSpecialAccounts.TabIndex = 7;
            chkbxSpecialAccounts.Text = "Special Accounts";
            chkbxSpecialAccounts.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            dtAsOf.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(13, 109);
            dtAsOf.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(200, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(13, 58);
            cmbxFund.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(200, 23);
            cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Location = new System.Drawing.Point(13, 145);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(200, 27);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panelReport
            // 
            panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReport.Location = new System.Drawing.Point(0, 0);
            panelReport.Name = "panelReport";
            panelReport.Padding = new System.Windows.Forms.Padding(4);
            panelReport.Size = new System.Drawing.Size(588, 535);
            panelReport.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 535);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(813, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
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
            // frmSaaobb
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(813, 557);
            Controls.Add(panelReport);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(829, 596);
            Name = "frmSaaobb";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Statement of Appropriations, Allotments, Obligations and Balances (SAAOBB)";
            Load += frmSAAOBB_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.Button btnRetrieve;
        internal System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.CheckBox chkbxSpecialAccounts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
