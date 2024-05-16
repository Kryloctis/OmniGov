
namespace AccountingSystem.Views.Reports.Saaobb
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
            chkbxSpecialAccounts = new System.Windows.Forms.CheckBox();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbxFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panelReport = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(chkbxSpecialAccounts);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(886, 37);
            panel1.TabIndex = 1;
            // 
            // chkbxSpecialAccounts
            // 
            chkbxSpecialAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkbxSpecialAccounts.AutoSize = true;
            chkbxSpecialAccounts.Location = new System.Drawing.Point(607, 9);
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
            dtAsOf.Location = new System.Drawing.Point(471, 7);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(130, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(265, 7);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(200, 23);
            cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Location = new System.Drawing.Point(729, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(150, 23);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panelReport
            // 
            panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReport.Location = new System.Drawing.Point(0, 37);
            panelReport.Name = "panelReport";
            panelReport.Size = new System.Drawing.Size(886, 417);
            panelReport.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(886, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmSaaobb
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(886, 476);
            Controls.Add(panelReport);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(902, 515);
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
    }
}
