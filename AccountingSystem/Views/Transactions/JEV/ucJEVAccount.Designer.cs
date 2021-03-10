
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class ucJEVAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.radioDebit = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioCredit = new System.Windows.Forms.RadioButton();
            this.pnlCollectionsDeposits = new System.Windows.Forms.Panel();
            this.radioDeposits = new System.Windows.Forms.RadioButton();
            this.radioCollections = new System.Windows.Forms.RadioButton();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlCollectionsDeposits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPP";
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(66, 9);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(370, 23);
            this.cmbFPP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account";
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(66, 38);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbAccount.TabIndex = 3;
            // 
            // radioDebit
            // 
            this.radioDebit.AutoSize = true;
            this.radioDebit.Location = new System.Drawing.Point(3, 3);
            this.radioDebit.Name = "radioDebit";
            this.radioDebit.Size = new System.Drawing.Size(53, 19);
            this.radioDebit.TabIndex = 4;
            this.radioDebit.TabStop = true;
            this.radioDebit.Text = "Debit";
            this.radioDebit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioCredit);
            this.panel1.Controls.Add(this.radioDebit);
            this.panel1.Location = new System.Drawing.Point(66, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 27);
            this.panel1.TabIndex = 5;
            // 
            // radioCredit
            // 
            this.radioCredit.AutoSize = true;
            this.radioCredit.Location = new System.Drawing.Point(62, 3);
            this.radioCredit.Name = "radioCredit";
            this.radioCredit.Size = new System.Drawing.Size(57, 19);
            this.radioCredit.TabIndex = 5;
            this.radioCredit.TabStop = true;
            this.radioCredit.Text = "Credit";
            this.radioCredit.UseVisualStyleBackColor = true;
            // 
            // pnlCollectionsDeposits
            // 
            this.pnlCollectionsDeposits.Controls.Add(this.radioDeposits);
            this.pnlCollectionsDeposits.Controls.Add(this.radioCollections);
            this.pnlCollectionsDeposits.Location = new System.Drawing.Point(238, 67);
            this.pnlCollectionsDeposits.Name = "pnlCollectionsDeposits";
            this.pnlCollectionsDeposits.Size = new System.Drawing.Size(198, 27);
            this.pnlCollectionsDeposits.TabIndex = 6;
            // 
            // radioDeposits
            // 
            this.radioDeposits.AutoSize = true;
            this.radioDeposits.Location = new System.Drawing.Point(93, 3);
            this.radioDeposits.Name = "radioDeposits";
            this.radioDeposits.Size = new System.Drawing.Size(70, 19);
            this.radioDeposits.TabIndex = 5;
            this.radioDeposits.TabStop = true;
            this.radioDeposits.Text = "Deposits";
            this.radioDeposits.UseVisualStyleBackColor = true;
            // 
            // radioCollections
            // 
            this.radioCollections.AutoSize = true;
            this.radioCollections.Location = new System.Drawing.Point(3, 3);
            this.radioCollections.Name = "radioCollections";
            this.radioCollections.Size = new System.Drawing.Size(84, 19);
            this.radioCollections.TabIndex = 4;
            this.radioCollections.TabStop = true;
            this.radioCollections.Text = "Collections";
            this.radioCollections.UseVisualStyleBackColor = true;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(66, 100);
            this.nudAmount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(370, 23);
            this.nudAmount.TabIndex = 7;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // ucJEVAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.pnlCollectionsDeposits);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFPP);
            this.Controls.Add(this.label1);
            this.Name = "ucJEVAccount";
            this.Size = new System.Drawing.Size(465, 133);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCollectionsDeposits.ResumeLayout(false);
            this.pnlCollectionsDeposits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlCollectionsDeposits;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.RadioButton radioDebit;
        internal System.Windows.Forms.RadioButton radioCredit;
        internal System.Windows.Forms.RadioButton radioDeposits;
        internal System.Windows.Forms.RadioButton radioCollections;
        internal System.Windows.Forms.NumericUpDown nudAmount;
    }
}
