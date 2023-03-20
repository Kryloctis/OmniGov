
namespace AccountingSystem.Views.Reports.Cashbook
{
    partial class frmCashbook
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBankAccounts = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1051, 525);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(50, 8);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(245, 23);
            this.cmbBank.TabIndex = 4;
            this.cmbBank.SelectionChangeCommitted += new System.EventHandler(this.cmbBank_SelectionChangeCommitted);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrieve.Location = new System.Drawing.Point(608, 8);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(82, 23);
            this.btnRetrieve.TabIndex = 7;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnretrieve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account";
            // 
            // cmbBankAccounts
            // 
            this.cmbBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccounts.FormattingEnabled = true;
            this.cmbBankAccounts.Location = new System.Drawing.Point(357, 8);
            this.cmbBankAccounts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBankAccounts.Name = "cmbBankAccounts";
            this.cmbBankAccounts.Size = new System.Drawing.Size(245, 23);
            this.cmbBankAccounts.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 37);
            this.panel2.TabIndex = 8;
            // 
            // frmCashbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.cmbBankAccounts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1067, 601);
            this.Name = "frmCashbook";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports > Check Cashbook";
            this.Load += new System.EventHandler(this.frmCashbook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBankAccounts;
        private System.Windows.Forms.Panel panel2;
    }
}