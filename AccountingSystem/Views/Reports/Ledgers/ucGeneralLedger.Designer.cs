
namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class ucGeneralLedger
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
            cmbYear = new System.Windows.Forms.ComboBox();
            cmbFunds = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            cmbAccount = new System.Windows.Forms.ComboBox();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new System.Drawing.Point(536, 7);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new System.Drawing.Size(93, 23);
            cmbYear.TabIndex = 17;
            // 
            // cmbFunds
            // 
            cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFunds.FormattingEnabled = true;
            cmbFunds.Location = new System.Drawing.Point(4, 7);
            cmbFunds.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cmbFunds.Name = "cmbFunds";
            cmbFunds.Size = new System.Drawing.Size(150, 23);
            cmbFunds.TabIndex = 16;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new System.Drawing.Point(635, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(75, 23);
            btnRetrieve.TabIndex = 15;
            btnRetrieve.Text = "&Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new System.Drawing.Point(160, 7);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new System.Drawing.Size(370, 23);
            cmbAccount.TabIndex = 14;
            cmbAccount.KeyDown += cmbAccount_KeyDown;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 36);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(849, 469);
            panel1.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cmbFunds);
            flowLayoutPanel1.Controls.Add(cmbAccount);
            flowLayoutPanel1.Controls.Add(cmbYear);
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel1.Size = new System.Drawing.Size(849, 36);
            flowLayoutPanel1.TabIndex = 19;
            // 
            // ucGeneralLedger
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "ucGeneralLedger";
            Size = new System.Drawing.Size(849, 505);
            Load += ucGeneralLedger_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
