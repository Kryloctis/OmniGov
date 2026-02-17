
namespace LFS.Views.Manage.TaxPayers
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
            txtContact = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            chckIsActive = new System.Windows.Forms.CheckBox();
            txtAddress = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtProvince = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            chckRepresentative = new System.Windows.Forms.CheckBox();
            cmbxRepresentative = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxTaxPayerType
            // 
            cmbxTaxPayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxTaxPayerType.FormattingEnabled = true;
            cmbxTaxPayerType.Location = new System.Drawing.Point(98, 88);
            cmbxTaxPayerType.Name = "cmbxTaxPayerType";
            cmbxTaxPayerType.Size = new System.Drawing.Size(313, 23);
            cmbxTaxPayerType.TabIndex = 3;
            // 
            // txtTIN
            // 
            txtTIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtTIN.Location = new System.Drawing.Point(98, 30);
            txtTIN.Name = "txtTIN";
            txtTIN.Size = new System.Drawing.Size(313, 23);
            txtTIN.TabIndex = 0;
            // 
            // txtContact
            // 
            txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtContact.Location = new System.Drawing.Point(98, 204);
            txtContact.MaxLength = 13;
            txtContact.Name = "txtContact";
            txtContact.Size = new System.Drawing.Size(313, 23);
            txtContact.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(5, 206);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(76, 15);
            label8.TabIndex = 1;
            label8.Text = "Contact Info.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 90);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 15);
            label7.TabIndex = 1;
            label7.Text = "Type";
            // 
            // txtName
            // 
            txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtName.Location = new System.Drawing.Point(98, 59);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(313, 23);
            txtName.TabIndex = 2;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Name*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 32);
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
            chckIsActive.AutoSize = true;
            chckIsActive.Checked = true;
            chckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chckIsActive.Location = new System.Drawing.Point(352, 5);
            chckIsActive.Name = "chckIsActive";
            chckIsActive.Size = new System.Drawing.Size(59, 19);
            chckIsActive.TabIndex = 1;
            chckIsActive.Text = "Active";
            chckIsActive.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new System.Drawing.Point(98, 117);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(313, 23);
            txtAddress.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 119);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 15);
            label3.TabIndex = 1;
            label3.Text = "Address";
            // 
            // txtMunicipality
            // 
            txtMunicipality.Location = new System.Drawing.Point(98, 146);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new System.Drawing.Size(313, 23);
            txtMunicipality.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(5, 240);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(84, 15);
            label6.TabIndex = 1;
            label6.Text = "Representative";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(5, 146);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(28, 15);
            label4.TabIndex = 1;
            label4.Text = "City";
            // 
            // txtProvince
            // 
            txtProvince.Location = new System.Drawing.Point(98, 175);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new System.Drawing.Size(313, 23);
            txtProvince.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 175);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 1;
            label5.Text = "Province";
            // 
            // chckRepresentative
            // 
            chckRepresentative.AutoSize = true;
            chckRepresentative.Location = new System.Drawing.Point(98, 240);
            chckRepresentative.Name = "chckRepresentative";
            chckRepresentative.Size = new System.Drawing.Size(55, 19);
            chckRepresentative.TabIndex = 8;
            chckRepresentative.Text = "None";
            chckRepresentative.UseVisualStyleBackColor = true;
            chckRepresentative.CheckedChanged += chckRepresentative_CheckedChanged;
            // 
            // cmbxRepresentative
            // 
            cmbxRepresentative.FormattingEnabled = true;
            cmbxRepresentative.Location = new System.Drawing.Point(98, 265);
            cmbxRepresentative.Name = "cmbxRepresentative";
            cmbxRepresentative.Size = new System.Drawing.Size(313, 23);
            cmbxRepresentative.TabIndex = 9;
            cmbxRepresentative.KeyPress += cmbxRepresentative_KeyPress;
            // 
            // ucTaxPayers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbxRepresentative);
            Controls.Add(chckRepresentative);
            Controls.Add(txtTIN);
            Controls.Add(label7);
            Controls.Add(txtContact);
            Controls.Add(label2);
            Controls.Add(chckIsActive);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Controls.Add(txtProvince);
            Controls.Add(txtMunicipality);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(cmbxTaxPayerType);
            Name = "ucTaxPayers";
            Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            Size = new System.Drawing.Size(430, 291);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.ComboBox cmbxTaxPayerType;
        internal System.Windows.Forms.TextBox txtTIN;
        internal System.Windows.Forms.TextBox txtContact;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckBox chckIsActive;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.CheckBox chckRepresentative;
        internal System.Windows.Forms.ComboBox cmbxRepresentative;
    }
}
