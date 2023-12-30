namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    partial class ucSpouseInfo
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
            cmbxRegistry = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            txtCountry = new System.Windows.Forms.TextBox();
            dtBirthDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            txtProvince = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtMiddleName = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            txtContactInfo = new System.Windows.Forms.TextBox();
            txtNationality = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtCurrenResidence = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtReligion = new System.Windows.Forms.TextBox();
            nudAge = new System.Windows.Forms.NumericUpDown();
            nudMonths = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            flowPanelSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxRegistry
            // 
            cmbxRegistry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxRegistry.FormattingEnabled = true;
            cmbxRegistry.Location = new System.Drawing.Point(121, 3);
            cmbxRegistry.Name = "cmbxRegistry";
            cmbxRegistry.Size = new System.Drawing.Size(243, 23);
            cmbxRegistry.TabIndex = 0;
            cmbxRegistry.SelectedValueChanged += cmbxRegistry_SelectedValueChanged;
            cmbxRegistry.KeyPress += cmbxRegistry_KeyPress;
            cmbxRegistry.Validating += cmbxRegistry_Validating;
            cmbxRegistry.Validated += cmbxRegistry_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "Find Registry*";
            // 
            // txtCountry
            // 
            txtCountry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCountry.Location = new System.Drawing.Point(121, 264);
            txtCountry.MinimumSize = new System.Drawing.Size(99, 23);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Country";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new System.Drawing.Size(243, 23);
            txtCountry.TabIndex = 11;
            // 
            // dtBirthDate
            // 
            dtBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtBirthDate.CustomFormat = "MMM dd, yyyy";
            dtBirthDate.Enabled = false;
            dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBirthDate.Location = new System.Drawing.Point(121, 177);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new System.Drawing.Size(243, 23);
            dtBirthDate.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(7, 35);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(64, 15);
            label7.TabIndex = 24;
            label7.Text = "First Name";
            // 
            // txtProvince
            // 
            txtProvince.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtProvince.Location = new System.Drawing.Point(121, 235);
            txtProvince.MinimumSize = new System.Drawing.Size(99, 23);
            txtProvince.Name = "txtProvince";
            txtProvince.PlaceholderText = "Province";
            txtProvince.ReadOnly = true;
            txtProvince.Size = new System.Drawing.Size(243, 23);
            txtProvince.TabIndex = 10;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(121, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new System.Drawing.Size(243, 23);
            txtFirstName.TabIndex = 1;
            // 
            // flowPanelSex
            // 
            flowPanelSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Enabled = false;
            flowPanelSex.Location = new System.Drawing.Point(121, 119);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(243, 23);
            flowPanelSex.TabIndex = 4;
            // 
            // radMale
            // 
            radMale.AutoSize = true;
            radMale.Checked = true;
            radMale.Location = new System.Drawing.Point(3, 3);
            radMale.Name = "radMale";
            radMale.Size = new System.Drawing.Size(51, 19);
            radMale.TabIndex = 5;
            radMale.TabStop = true;
            radMale.Text = "Male";
            radMale.UseVisualStyleBackColor = true;
            // 
            // radFemale
            // 
            radFemale.AutoSize = true;
            radFemale.Location = new System.Drawing.Point(60, 3);
            radFemale.Name = "radFemale";
            radFemale.Size = new System.Drawing.Size(63, 19);
            radFemale.TabIndex = 6;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
            // 
            // txtMunicipality
            // 
            txtMunicipality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMunicipality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMunicipality.Location = new System.Drawing.Point(121, 206);
            txtMunicipality.MinimumSize = new System.Drawing.Size(99, 23);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.PlaceholderText = "City";
            txtMunicipality.ReadOnly = true;
            txtMunicipality.Size = new System.Drawing.Size(243, 23);
            txtMunicipality.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(7, 93);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(63, 15);
            label8.TabIndex = 33;
            label8.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(121, 61);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.ReadOnly = true;
            txtMiddleName.Size = new System.Drawing.Size(243, 23);
            txtMiddleName.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(7, 123);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(25, 15);
            label9.TabIndex = 36;
            label9.Text = "Sex";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(7, 64);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 15);
            label10.TabIndex = 34;
            label10.Text = "Middle Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(7, 209);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(60, 15);
            label13.TabIndex = 31;
            label13.Text = "Birthplace";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(7, 181);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(55, 15);
            label12.TabIndex = 29;
            label12.Text = "Birthdate";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(7, 296);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 15);
            label11.TabIndex = 27;
            label11.Text = "Contact Info.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(7, 151);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(65, 15);
            label14.TabIndex = 25;
            label14.Text = "Nationality";
            // 
            // txtContactInfo
            // 
            txtContactInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtContactInfo.Location = new System.Drawing.Point(121, 293);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.ReadOnly = true;
            txtContactInfo.Size = new System.Drawing.Size(243, 23);
            txtContactInfo.TabIndex = 12;
            // 
            // txtNationality
            // 
            txtNationality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtNationality.Location = new System.Drawing.Point(121, 148);
            txtNationality.Name = "txtNationality";
            txtNationality.ReadOnly = true;
            txtNationality.Size = new System.Drawing.Size(243, 23);
            txtNationality.TabIndex = 7;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(121, 90);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new System.Drawing.Size(243, 23);
            txtLastName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 412);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(108, 15);
            label2.TabIndex = 27;
            label2.Text = "Current Residence*";
            // 
            // txtCurrenResidence
            // 
            txtCurrenResidence.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCurrenResidence.Location = new System.Drawing.Point(121, 409);
            txtCurrenResidence.Name = "txtCurrenResidence";
            txtCurrenResidence.Size = new System.Drawing.Size(243, 23);
            txtCurrenResidence.TabIndex = 16;
            txtCurrenResidence.Validating += txtCurrenResidence_Validating;
            txtCurrenResidence.Validated += txtCurrenResidence_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 383);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 15);
            label3.TabIndex = 27;
            label3.Text = "Religion*";
            // 
            // txtReligion
            // 
            txtReligion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtReligion.Location = new System.Drawing.Point(121, 380);
            txtReligion.Name = "txtReligion";
            txtReligion.Size = new System.Drawing.Size(243, 23);
            txtReligion.TabIndex = 15;
            txtReligion.Validating += txtReligion_Validating;
            txtReligion.Validated += txtReligion_Validated;
            // 
            // nudAge
            // 
            nudAge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAge.Location = new System.Drawing.Point(121, 322);
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(243, 23);
            nudAge.TabIndex = 13;
            nudAge.Validating += nudAge_Validating;
            nudAge.Validated += nudAge_Validated;
            // 
            // nudMonths
            // 
            nudMonths.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudMonths.Location = new System.Drawing.Point(121, 351);
            nudMonths.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudMonths.Name = "nudMonths";
            nudMonths.Size = new System.Drawing.Size(243, 23);
            nudMonths.TabIndex = 14;
            nudMonths.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudMonths.Validating += nudMonths_Validating;
            nudMonths.Validated += nudMonths_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 353);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 27;
            label4.Text = "Months*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 324);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 15);
            label5.TabIndex = 27;
            label5.Text = "Age*";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucSpouseInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(nudMonths);
            Controls.Add(nudAge);
            Controls.Add(txtReligion);
            Controls.Add(txtCurrenResidence);
            Controls.Add(txtCountry);
            Controls.Add(dtBirthDate);
            Controls.Add(label7);
            Controls.Add(txtProvince);
            Controls.Add(txtFirstName);
            Controls.Add(flowPanelSex);
            Controls.Add(txtMunicipality);
            Controls.Add(label8);
            Controls.Add(txtMiddleName);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label13);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label12);
            Controls.Add(label2);
            Controls.Add(label11);
            Controls.Add(label14);
            Controls.Add(txtContactInfo);
            Controls.Add(txtNationality);
            Controls.Add(txtLastName);
            Controls.Add(label1);
            Controls.Add(cmbxRegistry);
            Name = "ucSpouseInfo";
            Size = new System.Drawing.Size(387, 438);
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxRegistry;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtContactInfo;
        internal System.Windows.Forms.TextBox txtNationality;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrenResidence;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReligion;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.NumericUpDown nudMonths;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
