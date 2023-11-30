namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    partial class ucCattleDetails
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
            nudPrice = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cmbxType = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            flwPanelCattleSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
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
            flwPanelCattleSex.Location = new System.Drawing.Point(75, 61);
            flwPanelCattleSex.Name = "flwPanelCattleSex";
            flwPanelCattleSex.Size = new System.Drawing.Size(394, 27);
            flwPanelCattleSex.TabIndex = 17;
            // 
            // radCattleMale
            // 
            radCattleMale.AutoSize = true;
            radCattleMale.Checked = true;
            radCattleMale.Location = new System.Drawing.Point(3, 3);
            radCattleMale.Name = "radCattleMale";
            radCattleMale.Size = new System.Drawing.Size(51, 19);
            radCattleMale.TabIndex = 6;
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
            radCattleFemale.TabIndex = 6;
            radCattleFemale.Text = "Female";
            radCattleFemale.UseVisualStyleBackColor = true;
            // 
            // nudAge
            // 
            nudAge.Location = new System.Drawing.Point(75, 32);
            nudAge.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(80, 23);
            nudAge.TabIndex = 15;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDescription.Location = new System.Drawing.Point(75, 94);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(394, 23);
            txtDescription.TabIndex = 13;
            // 
            // nudPrice
            // 
            nudPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new System.Drawing.Point(75, 123);
            nudPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new System.Drawing.Size(394, 23);
            nudPrice.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(2, 97);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(67, 15);
            label10.TabIndex = 8;
            label10.Text = "Description";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(2, 35);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(28, 15);
            label8.TabIndex = 9;
            label8.Text = "Age";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(2, 6);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 10;
            label6.Text = "Type";
            // 
            // cmbxType
            // 
            cmbxType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxType.FormattingEnabled = true;
            cmbxType.Location = new System.Drawing.Point(75, 3);
            cmbxType.Name = "cmbxType";
            cmbxType.Size = new System.Drawing.Size(394, 23);
            cmbxType.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(2, 126);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(33, 15);
            label9.TabIndex = 11;
            label9.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(2, 66);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(25, 15);
            label7.TabIndex = 12;
            label7.Text = "Sex";
            // 
            // ucCattleDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(flwPanelCattleSex);
            Controls.Add(nudAge);
            Controls.Add(txtDescription);
            Controls.Add(nudPrice);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(cmbxType);
            Controls.Add(label9);
            Controls.Add(label7);
            Name = "ucCattleDetails";
            Size = new System.Drawing.Size(487, 149);
            Load += ucCattleOwnership_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            flwPanelCattleSex.ResumeLayout(false);
            flwPanelCattleSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ComboBox cmbxBarangay;
        internal System.Windows.Forms.ComboBox cmbxMunicipality;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbxProvince;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtOwnerName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.FlowLayoutPanel flwPanelCattleSex;
        internal System.Windows.Forms.RadioButton radCattleMale;
        internal System.Windows.Forms.RadioButton radCattleFemale;
        internal System.Windows.Forms.NumericUpDown nudAge;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.NumericUpDown nudPrice;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbxType;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label7;
    }
}
