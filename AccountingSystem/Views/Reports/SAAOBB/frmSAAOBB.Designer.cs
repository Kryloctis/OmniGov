
namespace AccountingSystem.Views.Reports.SAAOBB
{
    partial class frmSAAOBB
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkbxSpecialAccounts = new System.Windows.Forms.CheckBox();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.cmbxFund = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelReport = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkbxSpecialAccounts);
            this.panel1.Controls.Add(this.dtAsOf);
            this.panel1.Controls.Add(this.cmbxFund);
            this.panel1.Controls.Add(this.btnRetrieve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 41);
            this.panel1.TabIndex = 1;
            // 
            // chkbxSpecialAccounts
            // 
            this.chkbxSpecialAccounts.AutoSize = true;
            this.chkbxSpecialAccounts.Location = new System.Drawing.Point(565, 14);
            this.chkbxSpecialAccounts.Name = "chkbxSpecialAccounts";
            this.chkbxSpecialAccounts.Size = new System.Drawing.Size(116, 19);
            this.chkbxSpecialAccounts.TabIndex = 7;
            this.chkbxSpecialAccounts.Text = "Special Accounts";
            this.chkbxSpecialAccounts.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            this.dtAsOf.Location = new System.Drawing.Point(331, 11);
            this.dtAsOf.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(211, 23);
            this.dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            this.cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFund.FormattingEnabled = true;
            this.cmbxFund.Location = new System.Drawing.Point(50, 12);
            this.cmbxFund.Name = "cmbxFund";
            this.cmbxFund.Size = new System.Drawing.Size(218, 23);
            this.cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(704, 11);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(92, 23);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "As of";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // panelReport
            // 
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 41);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(915, 644);
            this.panelReport.TabIndex = 2;
            // 
            // frmSAAOBB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(915, 685);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(931, 718);
            this.Name = "frmSAAOBB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statement of Appropriations, Allotments, Obligations and Balances (SAAOBB)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSAAOBB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.CheckBox chkbxSpecialAccounts;
    }
}