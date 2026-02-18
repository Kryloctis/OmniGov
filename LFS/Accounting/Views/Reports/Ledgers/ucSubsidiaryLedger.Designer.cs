
namespace OmniGov.App.Accounting.Views.Reports.Ledgers
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
            cmbxSubsidiaryLedger = new System.Windows.Forms.ComboBox();
            cmbFunds = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            cmbxAccount = new System.Windows.Forms.ComboBox();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            nudYear = new System.Windows.Forms.NumericUpDown();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // cmbxSubsidiaryLedger
            // 
            cmbxSubsidiaryLedger.FormattingEnabled = true;
            cmbxSubsidiaryLedger.Location = new System.Drawing.Point(374, 7);
            cmbxSubsidiaryLedger.Name = "cmbxSubsidiaryLedger";
            cmbxSubsidiaryLedger.Size = new System.Drawing.Size(200, 23);
            cmbxSubsidiaryLedger.TabIndex = 23;
            cmbxSubsidiaryLedger.KeyDown += cmbxSubsidiaryLedger_KeyDown;
            cmbxSubsidiaryLedger.Validating += cmbSubsidiaryLedger_Validating;
            cmbxSubsidiaryLedger.Validated += cmbSubsidiaryLedger_Validated;
            // 
            // cmbFunds
            // 
            cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFunds.FormattingEnabled = true;
            cmbFunds.Location = new System.Drawing.Point(12, 7);
            cmbFunds.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cmbFunds.Name = "cmbFunds";
            cmbFunds.Size = new System.Drawing.Size(150, 23);
            cmbFunds.TabIndex = 21;
            cmbFunds.Validating += cmbFunds_Validating;
            cmbFunds.Validated += cmbFunds_Validated;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new System.Drawing.Point(683, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(150, 23);
            btnRetrieve.TabIndex = 20;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // cmbxAccount
            // 
            cmbxAccount.FormattingEnabled = true;
            cmbxAccount.Location = new System.Drawing.Point(168, 7);
            cmbxAccount.Name = "cmbxAccount";
            cmbxAccount.Size = new System.Drawing.Size(200, 23);
            cmbxAccount.TabIndex = 19;
            cmbxAccount.KeyDown += cmbxAccount_KeyDown;
            cmbxAccount.Validating += cmbAccount_Validating;
            cmbxAccount.Validated += cmbAccount_Validated;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(844, 416);
            panel1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Controls.Add(nudYear);
            flowLayoutPanel1.Controls.Add(cmbxSubsidiaryLedger);
            flowLayoutPanel1.Controls.Add(cmbxAccount);
            flowLayoutPanel1.Controls.Add(cmbFunds);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel1.Size = new System.Drawing.Size(844, 37);
            flowLayoutPanel1.TabIndex = 25;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(580, 7);
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
            progressBar1.Size = new System.Drawing.Size(844, 5);
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
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "ucSubsidiaryLedger";
            Size = new System.Drawing.Size(844, 458);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxSubsidiaryLedger;
        private System.Windows.Forms.ComboBox cmbFunds;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.NumericUpDown nudYear;
    }
}
