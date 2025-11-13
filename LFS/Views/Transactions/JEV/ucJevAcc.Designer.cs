
namespace LFS.Views.Transactions.JEV
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJEVAccount));
            label1 = new System.Windows.Forms.Label();
            cmbFPP = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cmbxAccount = new System.Windows.Forms.ComboBox();
            radDebit = new System.Windows.Forms.RadioButton();
            panel1 = new System.Windows.Forms.Panel();
            radCredit = new System.Windows.Forms.RadioButton();
            pnlCollectionsDeposits = new System.Windows.Forms.Panel();
            radDeposits = new System.Windows.Forms.RadioButton();
            radCollections = new System.Windows.Forms.RadioButton();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            cmbSubsidiary = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            btnSubsidiaryLedger = new System.Windows.Forms.Button();
            txtObligationNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            panel1.SuspendLayout();
            pnlCollectionsDeposits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = "FPP";
            // 
            // cmbFPP
            // 
            cmbFPP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbFPP.FormattingEnabled = true;
            cmbFPP.Location = new System.Drawing.Point(113, 59);
            cmbFPP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbFPP.Name = "cmbFPP";
            cmbFPP.Size = new System.Drawing.Size(323, 23);
            cmbFPP.TabIndex = 1;
            cmbFPP.KeyDown += cmbxFPP_KeyDown;
            cmbFPP.Validating += cmbFPP_Validating;
            cmbFPP.Validated += cmbFPP_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 99);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Account";
            // 
            // cmbxAccount
            // 
            cmbxAccount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxAccount.Location = new System.Drawing.Point(113, 95);
            cmbxAccount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxAccount.Name = "cmbxAccount";
            cmbxAccount.Size = new System.Drawing.Size(323, 23);
            cmbxAccount.TabIndex = 2;
            cmbxAccount.KeyDown += cmbxAccount_KeyDown;
            cmbxAccount.Validating += cmbxAccount_Validating;
            cmbxAccount.Validated += cmbxAccount_Validated;
            // 
            // radDebit
            // 
            radDebit.AutoSize = true;
            radDebit.Checked = true;
            radDebit.Location = new System.Drawing.Point(3, 3);
            radDebit.Name = "radDebit";
            radDebit.Size = new System.Drawing.Size(53, 19);
            radDebit.TabIndex = 4;
            radDebit.TabStop = true;
            radDebit.Text = "Debit";
            radDebit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radCredit);
            panel1.Controls.Add(radDebit);
            panel1.Location = new System.Drawing.Point(113, 167);
            panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(122, 27);
            panel1.TabIndex = 5;
            // 
            // radCredit
            // 
            radCredit.AutoSize = true;
            radCredit.Location = new System.Drawing.Point(62, 3);
            radCredit.Name = "radCredit";
            radCredit.Size = new System.Drawing.Size(57, 19);
            radCredit.TabIndex = 5;
            radCredit.Text = "Credit";
            radCredit.UseVisualStyleBackColor = true;
            // 
            // pnlCollectionsDeposits
            // 
            pnlCollectionsDeposits.Controls.Add(radDeposits);
            pnlCollectionsDeposits.Controls.Add(radCollections);
            pnlCollectionsDeposits.Location = new System.Drawing.Point(261, 167);
            pnlCollectionsDeposits.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            pnlCollectionsDeposits.Name = "pnlCollectionsDeposits";
            pnlCollectionsDeposits.Size = new System.Drawing.Size(172, 27);
            pnlCollectionsDeposits.TabIndex = 6;
            // 
            // radDeposits
            // 
            radDeposits.AutoSize = true;
            radDeposits.Location = new System.Drawing.Point(93, 3);
            radDeposits.Name = "radDeposits";
            radDeposits.Size = new System.Drawing.Size(70, 19);
            radDeposits.TabIndex = 7;
            radDeposits.Text = "Deposits";
            radDeposits.UseVisualStyleBackColor = true;
            // 
            // radCollections
            // 
            radCollections.AutoSize = true;
            radCollections.Checked = true;
            radCollections.Location = new System.Drawing.Point(3, 3);
            radCollections.Name = "radCollections";
            radCollections.Size = new System.Drawing.Size(84, 19);
            radCollections.TabIndex = 6;
            radCollections.TabStop = true;
            radCollections.Text = "Collections";
            radCollections.UseVisualStyleBackColor = true;
            // 
            // nudAmount
            // 
            nudAmount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new System.Drawing.Point(113, 207);
            nudAmount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            nudAmount.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(323, 23);
            nudAmount.TabIndex = 8;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 211);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 15);
            label3.TabIndex = 8;
            label3.Text = "Amount";
            // 
            // cmbSubsidiary
            // 
            cmbSubsidiary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbSubsidiary.AutoCompleteCustomSource.AddRange(new string[] { "[1] wait", "[2] go" });
            cmbSubsidiary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            cmbSubsidiary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSubsidiary.FormattingEnabled = true;
            cmbSubsidiary.Location = new System.Drawing.Point(113, 131);
            cmbSubsidiary.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbSubsidiary.Name = "cmbSubsidiary";
            cmbSubsidiary.Size = new System.Drawing.Size(295, 23);
            cmbSubsidiary.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(21, 135);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 10;
            label4.Text = "Subsidiary";
            // 
            // btnSubsidiaryLedger
            // 
            btnSubsidiaryLedger.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSubsidiaryLedger.Enabled = false;
            btnSubsidiaryLedger.Image = (System.Drawing.Image)resources.GetObject("btnSubsidiaryLedger.Image");
            btnSubsidiaryLedger.Location = new System.Drawing.Point(414, 132);
            btnSubsidiaryLedger.Name = "btnSubsidiaryLedger";
            btnSubsidiaryLedger.Size = new System.Drawing.Size(22, 22);
            btnSubsidiaryLedger.TabIndex = 9;
            btnSubsidiaryLedger.UseVisualStyleBackColor = true;
            btnSubsidiaryLedger.Click += btnSubsidiaryLedger_Click;
            // 
            // txtObligationNo
            // 
            txtObligationNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtObligationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtObligationNo.Location = new System.Drawing.Point(113, 23);
            txtObligationNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtObligationNo.Name = "txtObligationNo";
            txtObligationNo.Size = new System.Drawing.Size(323, 23);
            txtObligationNo.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(21, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 15);
            label5.TabIndex = 0;
            label5.Text = "Obligation No.";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucJEVAccount
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtObligationNo);
            Controls.Add(btnSubsidiaryLedger);
            Controls.Add(label4);
            Controls.Add(cmbSubsidiary);
            Controls.Add(label3);
            Controls.Add(nudAmount);
            Controls.Add(pnlCollectionsDeposits);
            Controls.Add(panel1);
            Controls.Add(cmbxAccount);
            Controls.Add(label2);
            Controls.Add(cmbFPP);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "ucJEVAccount";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(459, 257);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlCollectionsDeposits.ResumeLayout(false);
            pnlCollectionsDeposits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubsidiaryLedger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlCollectionsDeposits;
        private System.Windows.Forms.RadioButton radDeposits;
        private System.Windows.Forms.RadioButton radCollections;
        private System.Windows.Forms.RadioButton radDebit;
        private System.Windows.Forms.RadioButton radCredit;
        private System.Windows.Forms.ComboBox cmbFPP;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.TextBox txtObligationNo;
        private System.Windows.Forms.ComboBox cmbSubsidiary;
        private System.Windows.Forms.NumericUpDown nudAmount;
    }
}
