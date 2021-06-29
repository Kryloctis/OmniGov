
namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class frmGeneralLedgerReport
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
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.cmbFunds = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 490);
            this.panel1.TabIndex = 1;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(168, 12);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbAccount.TabIndex = 3;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(643, 11);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "&Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // cmbFunds
            // 
            this.cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunds.FormattingEnabled = true;
            this.cmbFunds.Location = new System.Drawing.Point(12, 12);
            this.cmbFunds.Name = "cmbFunds";
            this.cmbFunds.Size = new System.Drawing.Size(150, 23);
            this.cmbFunds.TabIndex = 12;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(544, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 23);
            this.cmbYear.TabIndex = 13;
            // 
            // frmGeneralLedgerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbFunds);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmGeneralLedgerReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report > General Ledger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGeneralLedgerReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.ComboBox cmbYear;
    }
}