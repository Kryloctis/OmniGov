namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    partial class ucCattleTransfer
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
            cmbxNewOwner = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dtTransfer = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            nudAmountOfPurchase = new System.Windows.Forms.NumericUpDown();
            cmbxOldOwner = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            radIsCattleMale = new System.Windows.Forms.RadioButton();
            radIsCattleFemale = new System.Windows.Forms.RadioButton();
            label7 = new System.Windows.Forms.Label();
            nudCattleAge = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            nudCattleYears = new System.Windows.Forms.NumericUpDown();
            cmbxCattle = new System.Windows.Forms.ComboBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            label9 = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)nudAmountOfPurchase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCattleAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCattleYears).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxNewOwner
            // 
            cmbxNewOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxNewOwner.FormattingEnabled = true;
            cmbxNewOwner.Location = new System.Drawing.Point(134, 206);
            cmbxNewOwner.Name = "cmbxNewOwner";
            cmbxNewOwner.Size = new System.Drawing.Size(200, 23);
            cmbxNewOwner.TabIndex = 0;
            cmbxNewOwner.KeyDown += cmbxNewOwner_KeyDown;
            cmbxNewOwner.Validating += cmbxNewOwner_Validating;
            cmbxNewOwner.Validated += cmbxNewOwner_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 210);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "New Owner*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 241);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Date of Transfer*";
            // 
            // dtTransfer
            // 
            dtTransfer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtTransfer.CustomFormat = "MMM dd,yyyy";
            dtTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTransfer.Location = new System.Drawing.Point(134, 235);
            dtTransfer.Name = "dtTransfer";
            dtTransfer.Size = new System.Drawing.Size(200, 23);
            dtTransfer.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 266);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 15);
            label3.TabIndex = 1;
            label3.Text = "Amount of Purchase*";
            // 
            // nudAmountOfPurchase
            // 
            nudAmountOfPurchase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAmountOfPurchase.DecimalPlaces = 2;
            nudAmountOfPurchase.Location = new System.Drawing.Point(134, 264);
            nudAmountOfPurchase.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudAmountOfPurchase.Name = "nudAmountOfPurchase";
            nudAmountOfPurchase.Size = new System.Drawing.Size(200, 23);
            nudAmountOfPurchase.TabIndex = 3;
            nudAmountOfPurchase.ThousandsSeparator = true;
            nudAmountOfPurchase.Validating += nudAmountOfPurchase_Validating;
            nudAmountOfPurchase.Validated += nudAmountOfPurchase_Validated;
            // 
            // cmbxOldOwner
            // 
            cmbxOldOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxOldOwner.FormattingEnabled = true;
            cmbxOldOwner.Location = new System.Drawing.Point(134, 3);
            cmbxOldOwner.Name = "cmbxOldOwner";
            cmbxOldOwner.Size = new System.Drawing.Size(200, 23);
            cmbxOldOwner.TabIndex = 0;
            cmbxOldOwner.SelectedValueChanged += cmbxOldOwner_SelectedValueChanged;
            cmbxOldOwner.KeyDown += cmbxOldOwner_KeyDown;
            cmbxOldOwner.Validating += cmbxOldOwner_Validating;
            cmbxOldOwner.Validated += cmbxOldOwner_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(69, 15);
            label4.TabIndex = 1;
            label4.Text = "Old Owner*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 36);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 15);
            label5.TabIndex = 1;
            label5.Text = "Cattle*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 63);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(30, 15);
            label6.TabIndex = 1;
            label6.Text = "Sex*";
            // 
            // radIsCattleMale
            // 
            radIsCattleMale.AutoSize = true;
            radIsCattleMale.Checked = true;
            radIsCattleMale.Location = new System.Drawing.Point(134, 60);
            radIsCattleMale.Name = "radIsCattleMale";
            radIsCattleMale.Size = new System.Drawing.Size(51, 19);
            radIsCattleMale.TabIndex = 4;
            radIsCattleMale.TabStop = true;
            radIsCattleMale.Text = "Male";
            radIsCattleMale.UseVisualStyleBackColor = true;
            // 
            // radIsCattleFemale
            // 
            radIsCattleFemale.AutoSize = true;
            radIsCattleFemale.Location = new System.Drawing.Point(191, 60);
            radIsCattleFemale.Name = "radIsCattleFemale";
            radIsCattleFemale.Size = new System.Drawing.Size(63, 19);
            radIsCattleFemale.TabIndex = 4;
            radIsCattleFemale.Text = "Female";
            radIsCattleFemale.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(7, 88);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(33, 15);
            label7.TabIndex = 1;
            label7.Text = "Age*";
            // 
            // nudCattleAge
            // 
            nudCattleAge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudCattleAge.DecimalPlaces = 2;
            nudCattleAge.Location = new System.Drawing.Point(134, 85);
            nudCattleAge.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudCattleAge.Name = "nudCattleAge";
            nudCattleAge.Size = new System.Drawing.Size(200, 23);
            nudCattleAge.TabIndex = 3;
            nudCattleAge.ThousandsSeparator = true;
            nudCattleAge.Validating += nudCattleAge_Validating;
            nudCattleAge.Validated += nudCattleAge_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(7, 117);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(39, 15);
            label8.TabIndex = 1;
            label8.Text = "Years*";
            // 
            // nudCattleYears
            // 
            nudCattleYears.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudCattleYears.DecimalPlaces = 2;
            nudCattleYears.Location = new System.Drawing.Point(134, 114);
            nudCattleYears.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudCattleYears.Name = "nudCattleYears";
            nudCattleYears.Size = new System.Drawing.Size(200, 23);
            nudCattleYears.TabIndex = 3;
            nudCattleYears.ThousandsSeparator = true;
            nudCattleYears.Validating += nudCattleYears_Validating;
            nudCattleYears.Validated += nudCattleYears_Validated;
            // 
            // cmbxCattle
            // 
            cmbxCattle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxCattle.FormattingEnabled = true;
            cmbxCattle.Location = new System.Drawing.Point(134, 32);
            cmbxCattle.Name = "cmbxCattle";
            cmbxCattle.Size = new System.Drawing.Size(200, 23);
            cmbxCattle.TabIndex = 0;
            cmbxCattle.SelectedValueChanged += cmbxCattle_SelectedValueChanged;
            cmbxCattle.Validating += cmbxCattle_Validating;
            cmbxCattle.Validated += cmbxCattle_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(7, 148);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(67, 15);
            label9.TabIndex = 1;
            label9.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDescription.Location = new System.Drawing.Point(134, 143);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(200, 57);
            txtDescription.TabIndex = 5;
            // 
            // ucCattleTransfer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtDescription);
            Controls.Add(cmbxNewOwner);
            Controls.Add(label1);
            Controls.Add(nudAmountOfPurchase);
            Controls.Add(cmbxCattle);
            Controls.Add(label2);
            Controls.Add(cmbxOldOwner);
            Controls.Add(dtTransfer);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(radIsCattleFemale);
            Controls.Add(nudCattleYears);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(radIsCattleMale);
            Controls.Add(label6);
            Controls.Add(nudCattleAge);
            Name = "ucCattleTransfer";
            Size = new System.Drawing.Size(353, 293);
            Load += ucCattleTransferOfOwnership_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmountOfPurchase).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCattleAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCattleYears).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox cmbxNewOwner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTransfer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAmountOfPurchase;
        private System.Windows.Forms.ComboBox cmbxOldOwner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radIsCattleMale;
        private System.Windows.Forms.RadioButton radIsCattleFemale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCattleAge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudCattleYears;
        private System.Windows.Forms.ComboBox cmbxCattle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
