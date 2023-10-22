
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
            this.components = new System.ComponentModel.Container();
            this.cmbxTaxPayerType = new System.Windows.Forms.ComboBox();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chckIsActive = new System.Windows.Forms.CheckBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarangay = new System.Windows.Forms.TextBox();
            this.txtMunicipality = new System.Windows.Forms.TextBox();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbxTaxPayerType
            // 
            this.cmbxTaxPayerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxTaxPayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTaxPayerType.FormattingEnabled = true;
            this.cmbxTaxPayerType.Location = new System.Drawing.Point(93, 87);
            this.cmbxTaxPayerType.Name = "cmbxTaxPayerType";
            this.cmbxTaxPayerType.Size = new System.Drawing.Size(299, 23);
            this.cmbxTaxPayerType.TabIndex = 2;
            // 
            // txtTIN
            // 
            this.txtTIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTIN.Location = new System.Drawing.Point(93, 29);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(299, 23);
            this.txtTIN.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Barangay";
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContact.Location = new System.Drawing.Point(93, 232);
            this.txtContact.MaxLength = 13;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(299, 23);
            this.txtContact.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Contact Info.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Type";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Location = new System.Drawing.Point(93, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(299, 23);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIN";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // chckIsActive
            // 
            this.chckIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckIsActive.AutoSize = true;
            this.chckIsActive.Checked = true;
            this.chckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckIsActive.Location = new System.Drawing.Point(333, 4);
            this.chckIsActive.Name = "chckIsActive";
            this.chckIsActive.Size = new System.Drawing.Size(59, 19);
            this.chckIsActive.TabIndex = 5;
            this.chckIsActive.Text = "Active";
            this.chckIsActive.UseVisualStyleBackColor = true;
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreet.Location = new System.Drawing.Point(93, 116);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(299, 23);
            this.txtStreet.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Street/Address";
            // 
            // txtBarangay
            // 
            this.txtBarangay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarangay.Location = new System.Drawing.Point(93, 145);
            this.txtBarangay.Name = "txtBarangay";
            this.txtBarangay.Size = new System.Drawing.Size(299, 23);
            this.txtBarangay.TabIndex = 7;
            // 
            // txtMunicipality
            // 
            this.txtMunicipality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMunicipality.Location = new System.Drawing.Point(93, 174);
            this.txtMunicipality.Name = "txtMunicipality";
            this.txtMunicipality.Size = new System.Drawing.Size(299, 23);
            this.txtMunicipality.TabIndex = 7;
            // 
            // txtProvince
            // 
            this.txtProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProvince.Location = new System.Drawing.Point(93, 203);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(299, 23);
            this.txtProvince.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Municipality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Province";
            // 
            // ucTaxPayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtProvince);
            this.Controls.Add(this.txtMunicipality);
            this.Controls.Add(this.txtBarangay);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.chckIsActive);
            this.Controls.Add(this.cmbxTaxPayerType);
            this.Controls.Add(this.txtTIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Name = "ucTaxPayers";
            this.Size = new System.Drawing.Size(414, 261);
            this.Load += new System.EventHandler(this.ucTaxPayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
