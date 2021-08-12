
namespace AccountingSystem.Views.Reports.TrialBalance
{
    partial class ucPostClosingTrialBalance
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
            this.panelReport = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbHideZeroBalance = new System.Windows.Forms.CheckBox();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.cmbFund = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelReport
            // 
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 28);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(1037, 541);
            this.panelReport.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbHideZeroBalance);
            this.panel1.Controls.Add(this.dtAsOf);
            this.panel1.Controls.Add(this.cmbFund);
            this.panel1.Controls.Add(this.btnRetrieve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 28);
            this.panel1.TabIndex = 5;
            // 
            // cbHideZeroBalance
            // 
            this.cbHideZeroBalance.AutoSize = true;
            this.cbHideZeroBalance.Enabled = false;
            this.cbHideZeroBalance.Location = new System.Drawing.Point(544, 0);
            this.cbHideZeroBalance.Name = "cbHideZeroBalance";
            this.cbHideZeroBalance.Size = new System.Drawing.Size(127, 19);
            this.cbHideZeroBalance.TabIndex = 9;
            this.cbHideZeroBalance.Text = "Hide Zero Balances";
            this.cbHideZeroBalance.UseVisualStyleBackColor = true;
            this.cbHideZeroBalance.CheckedChanged += new System.EventHandler(this.cbHideZeroBalance_CheckedChanged);
            // 
            // dtAsOf
            // 
            this.dtAsOf.Location = new System.Drawing.Point(312, 0);
            this.dtAsOf.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(208, 23);
            this.dtAsOf.TabIndex = 6;
            // 
            // cmbFund
            // 
            this.cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFund.FormattingEnabled = true;
            this.cmbFund.Location = new System.Drawing.Point(40, 0);
            this.cmbFund.Name = "cmbFund";
            this.cmbFund.Size = new System.Drawing.Size(216, 23);
            this.cmbFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(688, 0);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(96, 24);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "As of";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // ucPostClosingTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panel1);
            this.Name = "ucPostClosingTrialBalance";
            this.Size = new System.Drawing.Size(1037, 569);
            this.Load += new System.EventHandler(this.ucPostClosingTrialBalance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbHideZeroBalance;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        internal System.Windows.Forms.ComboBox cmbFund;
        internal System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
