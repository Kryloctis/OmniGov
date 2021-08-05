
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJEVAccount));
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
            this.cmbSubsidiary = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubsidiaryLedger = new System.Windows.Forms.Button();
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtObligationNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epObligationNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.pnlCollectionsDeposits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPP";
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(91, 29);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(466, 23);
            this.cmbFPP.TabIndex = 1;
            this.cmbFPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxFPP_KeyDown);
            this.cmbFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFPP_Validating);
            this.cmbFPP.Validated += new System.EventHandler(this.cmbFPP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account";
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(91, 58);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(466, 23);
            this.cmbAccount.TabIndex = 2;
            this.cmbAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAccount_Validating);
            this.cmbAccount.Validated += new System.EventHandler(this.cmbAccount_Validated);
            // 
            // radioDebit
            // 
            this.radioDebit.AutoSize = true;
            this.radioDebit.Checked = true;
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
            this.panel1.Location = new System.Drawing.Point(91, 116);
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
            this.radioCredit.Text = "Credit";
            this.radioCredit.UseVisualStyleBackColor = true;
            // 
            // pnlCollectionsDeposits
            // 
            this.pnlCollectionsDeposits.Controls.Add(this.radioDeposits);
            this.pnlCollectionsDeposits.Controls.Add(this.radioCollections);
            this.pnlCollectionsDeposits.Location = new System.Drawing.Point(359, 116);
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
            this.radioDeposits.TabIndex = 7;
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
            this.radioCollections.TabIndex = 6;
            this.radioCollections.TabStop = true;
            this.radioCollections.Text = "Collections";
            this.radioCollections.UseVisualStyleBackColor = true;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(91, 149);
            this.nudAmount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(466, 23);
            this.nudAmount.TabIndex = 8;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // cmbSubsidiary
            // 
            this.cmbSubsidiary.AutoCompleteCustomSource.AddRange(new string[] {
            "[1] wait",
            "[2] go"});
            this.cmbSubsidiary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbSubsidiary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubsidiary.FormattingEnabled = true;
            this.cmbSubsidiary.Location = new System.Drawing.Point(91, 87);
            this.cmbSubsidiary.Name = "cmbSubsidiary";
            this.cmbSubsidiary.Size = new System.Drawing.Size(466, 23);
            this.cmbSubsidiary.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Subsidiary";
            // 
            // btnSubsidiaryLedger
            // 
            this.btnSubsidiaryLedger.Enabled = false;
            this.btnSubsidiaryLedger.Image = ((System.Drawing.Image)(resources.GetObject("btnSubsidiaryLedger.Image")));
            this.btnSubsidiaryLedger.Location = new System.Drawing.Point(563, 87);
            this.btnSubsidiaryLedger.Name = "btnSubsidiaryLedger";
            this.btnSubsidiaryLedger.Size = new System.Drawing.Size(22, 22);
            this.btnSubsidiaryLedger.TabIndex = 9;
            this.btnSubsidiaryLedger.UseVisualStyleBackColor = true;
            this.btnSubsidiaryLedger.Click += new System.EventHandler(this.btnSubsidiaryLedger_Click);
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // txtObligationNo
            // 
            this.txtObligationNo.Location = new System.Drawing.Point(91, 0);
            this.txtObligationNo.Name = "txtObligationNo";
            this.txtObligationNo.Size = new System.Drawing.Size(466, 23);
            this.txtObligationNo.TabIndex = 0;
            this.txtObligationNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtObligationNo_Validating);
            this.txtObligationNo.Validated += new System.EventHandler(this.txtObligationNo_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Obligation No.";
            // 
            // epObligationNo
            // 
            this.epObligationNo.ContainerControl = this;
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // ucJEVAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtObligationNo);
            this.Controls.Add(this.btnSubsidiaryLedger);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSubsidiary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.pnlCollectionsDeposits);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFPP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "ucJEVAccount";
            this.Size = new System.Drawing.Size(588, 175);
            this.Load += new System.EventHandler(this.ucJEVAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCollectionsDeposits.ResumeLayout(false);
            this.pnlCollectionsDeposits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.RadioButton radioDebit;
        internal System.Windows.Forms.RadioButton radioCredit;
        internal System.Windows.Forms.RadioButton radioDeposits;
        internal System.Windows.Forms.RadioButton radioCollections;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.ComboBox cmbSubsidiary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubsidiaryLedger;
        internal System.Windows.Forms.Panel pnlCollectionsDeposits;
        private System.Windows.Forms.ErrorProvider epAccount;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtObligationNo;
        internal System.Windows.Forms.ErrorProvider epObligationNo;
        internal System.Windows.Forms.ErrorProvider epFPP;
    }
}
