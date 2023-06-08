namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class ucSummarySubsidiaryLedger
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxAccount = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            btnRetrieve = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(cmbxFunds);
            flowLayoutPanel1.Controls.Add(cmbxAccount);
            flowLayoutPanel1.Controls.Add(nudYear);
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel1.Size = new System.Drawing.Size(1140, 37);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(7, 7);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(150, 23);
            cmbxFunds.TabIndex = 0;
            cmbxFunds.Validating += cmbxFunds_Validating;
            cmbxFunds.Validated += cmbxFunds_Validated;
            // 
            // cmbxAccount
            // 
            cmbxAccount.FormattingEnabled = true;
            cmbxAccount.Location = new System.Drawing.Point(163, 7);
            cmbxAccount.Name = "cmbxAccount";
            cmbxAccount.Size = new System.Drawing.Size(370, 23);
            cmbxAccount.TabIndex = 1;
            cmbxAccount.KeyDown += cmbxAccount_KeyDown;
            cmbxAccount.Validating += cmbxAccount_Validating;
            cmbxAccount.Validated += cmbxAccount_Validated;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(539, 7);
            nudYear.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(97, 23);
            nudYear.TabIndex = 2;
           
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new System.Drawing.Point(642, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(75, 23);
            btnRetrieve.TabIndex = 25;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 37);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1140, 5);
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1140, 529);
            panel1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // ucSummarySubsidiaryLedger
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "ucSummarySubsidiaryLedger";
            Size = new System.Drawing.Size(1140, 571);
            Load += ucSummarySubsidiaryLedger_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnRetrieve;
    }
}
