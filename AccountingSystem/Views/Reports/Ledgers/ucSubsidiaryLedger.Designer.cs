
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
            cmbSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            cmbFunds = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            cmbAccount = new System.Windows.Forms.ComboBox();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            nudYear = new System.Windows.Forms.NumericUpDown();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // cmbSubsidiaryLedger
            // 
            cmbSubsidiaryLedger.FormattingEnabled = true;
            cmbSubsidiaryLedger.Location = new System.Drawing.Point(536, 7);
            cmbSubsidiaryLedger.Name = "cmbSubsidiaryLedger";
            cmbSubsidiaryLedger.Size = new System.Drawing.Size(283, 23);
            cmbSubsidiaryLedger.TabIndex = 23;
            cmbSubsidiaryLedger.Validating += cmbSubsidiaryLedger_Validating;
            cmbSubsidiaryLedger.Validated += cmbSubsidiaryLedger_Validated;
            // 
            // cmbFunds
            // 
            cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFunds.FormattingEnabled = true;
            cmbFunds.Location = new System.Drawing.Point(4, 7);
            cmbFunds.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cmbFunds.Name = "cmbFunds";
            cmbFunds.Size = new System.Drawing.Size(150, 23);
            cmbFunds.TabIndex = 21;
            cmbFunds.Validating += cmbFunds_Validating;
            cmbFunds.Validated += cmbFunds_Validated;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new System.Drawing.Point(928, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(75, 23);
            btnRetrieve.TabIndex = 20;
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
            cmbAccount.TabIndex = 19;
            cmbAccount.KeyDown += cmbAccount_KeyDown;
            cmbAccount.Validating += cmbAccount_Validating;
            cmbAccount.Validated += cmbAccount_Validated;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1034, 492);
            panel1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(cmbFunds);
            flowLayoutPanel1.Controls.Add(cmbAccount);
            flowLayoutPanel1.Controls.Add(cmbSubsidiaryLedger);
            flowLayoutPanel1.Controls.Add(nudYear);
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel1.Size = new System.Drawing.Size(1034, 37);
            flowLayoutPanel1.TabIndex = 25;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(825, 7);
            nudYear.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(97, 23);
            nudYear.TabIndex = 24;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 37);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1034, 5);
            progressBar1.TabIndex = 26;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // ucSubsidiaryLedger
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "ucSubsidiaryLedger";
            Size = new System.Drawing.Size(1034, 534);
            Load += ucSubsidiaryLedger_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubsidiaryLedger;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.NumericUpDown nudYear;
    }
}
