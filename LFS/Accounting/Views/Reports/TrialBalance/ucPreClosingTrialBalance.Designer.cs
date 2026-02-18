
namespace OmniGov.App.Accounting.Views.Reports.TrialBalance
{
    partial class ucPreClosingTrialBalance
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
            panelReport = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            cbHideZeroBalance = new System.Windows.Forms.CheckBox();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelReport
            // 
            panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReport.Location = new System.Drawing.Point(0, 38);
            panelReport.Name = "panelReport";
            panelReport.Size = new System.Drawing.Size(749, 402);
            panelReport.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(cbHideZeroBalance);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(749, 38);
            panel1.TabIndex = 4;
            // 
            // cbHideZeroBalance
            // 
            cbHideZeroBalance.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbHideZeroBalance.AutoSize = true;
            cbHideZeroBalance.Enabled = false;
            cbHideZeroBalance.Location = new System.Drawing.Point(459, 10);
            cbHideZeroBalance.Name = "cbHideZeroBalance";
            cbHideZeroBalance.Size = new System.Drawing.Size(127, 19);
            cbHideZeroBalance.TabIndex = 9;
            cbHideZeroBalance.Text = "Hide Zero Balances";
            cbHideZeroBalance.UseVisualStyleBackColor = true;
            cbHideZeroBalance.CheckedChanged += cbHideZeroBalance_CheckedChanged;
            // 
            // dtAsOf
            // 
            dtAsOf.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(323, 8);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(130, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbFund
            // 
            cmbFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFund.FormattingEnabled = true;
            cmbFund.Location = new System.Drawing.Point(117, 8);
            cmbFund.Name = "cmbFund";
            cmbFund.Size = new System.Drawing.Size(200, 23);
            cmbFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Location = new System.Drawing.Point(592, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(150, 24);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // ucPreClosingTrialBalance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelReport);
            Controls.Add(panel1);
            Name = "ucPreClosingTrialBalance";
            Size = new System.Drawing.Size(749, 440);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbHideZeroBalance;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        internal System.Windows.Forms.ComboBox cmbFund;
        internal System.Windows.Forms.Button btnRetrieve;
    }
}
