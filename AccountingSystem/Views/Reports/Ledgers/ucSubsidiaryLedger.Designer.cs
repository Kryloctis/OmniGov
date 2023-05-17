
namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class ucSubsidiaryLedger
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
            this.cmbSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbFunds = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSubsidiaryLedger
            // 
            this.cmbSubsidiaryLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubsidiaryLedger.FormattingEnabled = true;
            this.cmbSubsidiaryLedger.Location = new System.Drawing.Point(536, 7);
            this.cmbSubsidiaryLedger.Name = "cmbSubsidiaryLedger";
            this.cmbSubsidiaryLedger.Size = new System.Drawing.Size(283, 23);
            this.cmbSubsidiaryLedger.TabIndex = 23;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(825, 7);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 23);
            this.cmbYear.TabIndex = 22;
            // 
            // cmbFunds
            // 
            this.cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunds.FormattingEnabled = true;
            this.cmbFunds.Location = new System.Drawing.Point(4, 7);
            this.cmbFunds.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cmbFunds.Name = "cmbFunds";
            this.cmbFunds.Size = new System.Drawing.Size(150, 23);
            this.cmbFunds.TabIndex = 21;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(924, 7);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 20;
            this.btnRetrieve.Text = "&Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(160, 7);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbAccount.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 492);
            this.panel1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cmbFunds);
            this.flowLayoutPanel1.Controls.Add(this.cmbAccount);
            this.flowLayoutPanel1.Controls.Add(this.cmbSubsidiaryLedger);
            this.flowLayoutPanel1.Controls.Add(this.cmbYear);
            this.flowLayoutPanel1.Controls.Add(this.btnRetrieve);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1034, 37);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1034, 5);
            this.progressBar1.TabIndex = 26;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // ucSubsidiaryLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucSubsidiaryLedger";
            this.Size = new System.Drawing.Size(1034, 534);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubsidiaryLedger;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
