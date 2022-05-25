
namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class ucTransactionLog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbFunds = new System.Windows.Forms.ComboBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.cmbSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmbFunds);
            this.flowLayoutPanel1.Controls.Add(this.cmbAccount);
            this.flowLayoutPanel1.Controls.Add(this.cmbSubsidiaryLedger);
            this.flowLayoutPanel1.Controls.Add(this.cmbYear);
            this.flowLayoutPanel1.Controls.Add(this.btnRetrieve);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1002, 31);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // cmbFunds
            // 
            this.cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunds.FormattingEnabled = true;
            this.cmbFunds.Location = new System.Drawing.Point(0, 3);
            this.cmbFunds.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cmbFunds.Name = "cmbFunds";
            this.cmbFunds.Size = new System.Drawing.Size(150, 23);
            this.cmbFunds.TabIndex = 21;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(156, 3);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbAccount.TabIndex = 19;
            this.cmbAccount.SelectionChangeCommitted += new System.EventHandler(this.cmbAccount_SelectionChangeCommitted);
            this.cmbAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccount_KeyDown);
            // 
            // cmbSubsidiaryLedger
            // 
            this.cmbSubsidiaryLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubsidiaryLedger.FormattingEnabled = true;
            this.cmbSubsidiaryLedger.Location = new System.Drawing.Point(532, 3);
            this.cmbSubsidiaryLedger.Name = "cmbSubsidiaryLedger";
            this.cmbSubsidiaryLedger.Size = new System.Drawing.Size(283, 23);
            this.cmbSubsidiaryLedger.TabIndex = 23;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(821, 3);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 23);
            this.cmbYear.TabIndex = 22;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(920, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 20;
            this.btnRetrieve.Text = "&Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 412);
            this.panel1.TabIndex = 27;
            // 
            // ucTransactionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucTransactionLog";
            this.Size = new System.Drawing.Size(1002, 443);
            this.Load += new System.EventHandler(this.ucTransactionLog_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.ComboBox cmbSubsidiaryLedger;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel1;
    }
}
