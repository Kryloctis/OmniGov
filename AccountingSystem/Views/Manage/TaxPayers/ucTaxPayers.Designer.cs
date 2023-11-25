
namespace AccountingSystem.Views.Manage.TaxPayers
{
    partial class ucTaxPayers
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
            cmbxTaxPayerType = new System.Windows.Forms.ComboBox();
            txtTIN = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            txtContact = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            chckIsActive = new System.Windows.Forms.CheckBox();
            txtStreet = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtBarangay = new System.Windows.Forms.TextBox();
            txtMunicipality = new System.Windows.Forms.TextBox();
            txtProvince = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxTaxPayerType
            // 
            cmbxTaxPayerType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxTaxPayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxTaxPayerType.FormattingEnabled = true;
            cmbxTaxPayerType.Location = new System.Drawing.Point(97, 86);
            cmbxTaxPayerType.Name = "cmbxTaxPayerType";
            cmbxTaxPayerType.Size = new System.Drawing.Size(250, 23);
            cmbxTaxPayerType.TabIndex = 2;
            // 
            // txtTIN
            // 
            txtTIN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtTIN.Location = new System.Drawing.Point(97, 28);
            txtTIN.Name = "txtTIN";
            txtTIN.Size = new System.Drawing.Size(250, 23);
            txtTIN.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(4, 148);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 15);
            label10.TabIndex = 1;
            label10.Text = "Barangay";
            // 
            // txtContact
            // 
            txtContact.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtContact.Location = new System.Drawing.Point(97, 231);
            txtContact.MaxLength = 13;
            txtContact.Name = "txtContact";
            txtContact.Size = new System.Drawing.Size(250, 23);
            txtContact.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(4, 235);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(76, 15);
            label8.TabIndex = 1;
            label8.Text = "Contact Info.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(4, 90);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 15);
            label7.TabIndex = 1;
            label7.Text = "Type";
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtName.Location = new System.Drawing.Point(97, 57);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(250, 23);
            txtName.TabIndex = 1;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(25, 15);
            label1.TabIndex = 1;
            label1.Text = "TIN";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // chckIsActive
            // 
            chckIsActive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chckIsActive.AutoSize = true;
            chckIsActive.Checked = true;
            chckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chckIsActive.Location = new System.Drawing.Point(288, 3);
            chckIsActive.Name = "chckIsActive";
            chckIsActive.Size = new System.Drawing.Size(59, 19);
            chckIsActive.TabIndex = 5;
            chckIsActive.Text = "Active";
            chckIsActive.UseVisualStyleBackColor = true;
            // 
            // txtStreet
            // 
            txtStreet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtStreet.Location = new System.Drawing.Point(97, 115);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new System.Drawing.Size(250, 23);
            txtStreet.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 119);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 15);
            label3.TabIndex = 1;
            label3.Text = "Street/Address";
            // 
            // txtBarangay
            // 
            txtBarangay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBarangay.Location = new System.Drawing.Point(97, 144);
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new System.Drawing.Size(250, 23);
            txtBarangay.TabIndex = 7;
            // 
            // txtMunicipality
            // 
            txtMunicipality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMunicipality.Location = new System.Drawing.Point(97, 173);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new System.Drawing.Size(250, 23);
            txtMunicipality.TabIndex = 7;
            // 
            // txtProvince
            // 
            txtProvince.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtProvince.Location = new System.Drawing.Point(97, 202);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new System.Drawing.Size(250, 23);
            txtProvince.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(4, 177);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 15);
            label4.TabIndex = 1;
            label4.Text = "Municipality";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 206);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 1;
            label5.Text = "Province";
            // 
            // ucTaxPayers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtProvince);
            Controls.Add(txtMunicipality);
            Controls.Add(txtBarangay);
            Controls.Add(txtStreet);
            Controls.Add(chckIsActive);
            Controls.Add(cmbxTaxPayerType);
            Controls.Add(txtTIN);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label10);
            Controls.Add(label2);
            Controls.Add(txtContact);
            Controls.Add(txtName);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label7);
            Name = "ucTaxPayers";
            Size = new System.Drawing.Size(372, 262);
            Load += ucTaxPayers_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.ComboBox cmbxTaxPayerType;
        internal System.Windows.Forms.TextBox txtTIN;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtContact;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckBox chckIsActive;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.TextBox txtBarangay;
    }
}
