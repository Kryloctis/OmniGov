namespace LFS.Views.Transactions.Payments.CattleOwnership
{
    partial class ucCattleOwnership
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
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            flwPanelCattleSex = new System.Windows.Forms.FlowLayoutPanel();
            radCattleMale = new System.Windows.Forms.RadioButton();
            radCattleFemale = new System.Windows.Forms.RadioButton();
            nudAge = new System.Windows.Forms.NumericUpDown();
            txtDescription = new System.Windows.Forms.TextBox();
            nudYears = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cmbxType = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cmbxOwner = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            flwPanelCattleSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYears).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // flwPanelCattleSex
            // 
            flwPanelCattleSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flwPanelCattleSex.Controls.Add(radCattleMale);
            flwPanelCattleSex.Controls.Add(radCattleFemale);
            flwPanelCattleSex.Location = new System.Drawing.Point(79, 119);
            flwPanelCattleSex.Name = "flwPanelCattleSex";
            flwPanelCattleSex.Size = new System.Drawing.Size(250, 23);
            flwPanelCattleSex.TabIndex = 17;
            // 
            // radCattleMale
            // 
            radCattleMale.AutoSize = true;
            radCattleMale.Checked = true;
            radCattleMale.Location = new System.Drawing.Point(3, 3);
            radCattleMale.Name = "radCattleMale";
            radCattleMale.Size = new System.Drawing.Size(51, 19);
            radCattleMale.TabIndex = 3;
            radCattleMale.TabStop = true;
            radCattleMale.Text = "Male";
            radCattleMale.UseVisualStyleBackColor = true;
            // 
            // radCattleFemale
            // 
            radCattleFemale.AutoSize = true;
            radCattleFemale.Location = new System.Drawing.Point(60, 3);
            radCattleFemale.Name = "radCattleFemale";
            radCattleFemale.Size = new System.Drawing.Size(63, 19);
            radCattleFemale.TabIndex = 4;
            radCattleFemale.Text = "Female";
            radCattleFemale.UseVisualStyleBackColor = true;
            // 
            // nudAge
            // 
            nudAge.Location = new System.Drawing.Point(79, 61);
            nudAge.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudAge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(80, 23);
            nudAge.TabIndex = 2;
            nudAge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDescription
            // 
            txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDescription.Location = new System.Drawing.Point(79, 152);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(250, 75);
            txtDescription.TabIndex = 5;
            // 
            // nudYears
            // 
            nudYears.Location = new System.Drawing.Point(79, 90);
            nudYears.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudYears.Name = "nudYears";
            nudYears.Size = new System.Drawing.Size(80, 23);
            nudYears.TabIndex = 6;
            nudYears.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            nudYears.Validating += nudYears_Validating;
            nudYears.Validated += nudYears_Validated;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(1, 155);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(67, 15);
            label10.TabIndex = 8;
            label10.Text = "Description";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(1, 64);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(33, 15);
            label8.TabIndex = 9;
            label8.Text = "Age*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(1, 35);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 15);
            label6.TabIndex = 10;
            label6.Text = "Type*";
            // 
            // cmbxType
            // 
            cmbxType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxType.FormattingEnabled = true;
            cmbxType.Location = new System.Drawing.Point(79, 32);
            cmbxType.Name = "cmbxType";
            cmbxType.Size = new System.Drawing.Size(250, 23);
            cmbxType.TabIndex = 1;
            cmbxType.Validating += cmbxType_Validating;
            cmbxType.Validated += cmbxType_Validated;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(1, 93);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(39, 15);
            label9.TabIndex = 11;
            label9.Text = "Years*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(1, 124);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(30, 15);
            label7.TabIndex = 12;
            label7.Text = "Sex*";
            // 
            // cmbxOwner
            // 
            cmbxOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxOwner.FormattingEnabled = true;
            cmbxOwner.Location = new System.Drawing.Point(79, 3);
            cmbxOwner.Name = "cmbxOwner";
            cmbxOwner.Size = new System.Drawing.Size(250, 23);
            cmbxOwner.TabIndex = 0;
            cmbxOwner.KeyPress += cmbxOwner_KeyPress;
            cmbxOwner.Validating += cmbxOwner_Validating;
            cmbxOwner.Validated += cmbxOwner_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(1, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 15);
            label1.TabIndex = 10;
            label1.Text = "Owner*";
            // 
            // ucCattleOwnership
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbxOwner);
            Controls.Add(flwPanelCattleSex);
            Controls.Add(nudAge);
            Controls.Add(txtDescription);
            Controls.Add(nudYears);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(cmbxType);
            Controls.Add(label9);
            Controls.Add(label7);
            Name = "ucCattleOwnership";
            Size = new System.Drawing.Size(349, 234);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            flwPanelCattleSex.ResumeLayout(false);
            flwPanelCattleSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYears).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.FlowLayoutPanel flwPanelCattleSex;
        internal System.Windows.Forms.RadioButton radCattleMale;
        internal System.Windows.Forms.RadioButton radCattleFemale;
        internal System.Windows.Forms.NumericUpDown nudAge;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.NumericUpDown nudYears;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbxType;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbxOwner;
        internal System.Windows.Forms.Label label1;
    }
}
