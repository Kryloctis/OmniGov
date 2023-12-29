namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    partial class ucRemainsInfo
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
            label1 = new System.Windows.Forms.Label();
            cmbxRegistry = new System.Windows.Forms.ComboBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            txtCountry = new System.Windows.Forms.TextBox();
            dtBirthDate = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            txtProvince = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtMiddleName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtContactInfo = new System.Windows.Forms.TextBox();
            txtNationality = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            nudAge = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            flowPanelSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Registry*";
            // 
            // cmbxRegistry
            // 
            cmbxRegistry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxRegistry.FormattingEnabled = true;
            cmbxRegistry.Location = new System.Drawing.Point(89, 3);
            cmbxRegistry.Name = "cmbxRegistry";
            cmbxRegistry.Size = new System.Drawing.Size(250, 23);
            cmbxRegistry.TabIndex = 1;
            cmbxRegistry.SelectedValueChanged += cmbxRegistry_SelectedValueChanged;
            cmbxRegistry.KeyPress += cmbxRegistry_KeyPress;
            cmbxRegistry.Validating += cmbxRegistry_Validating;
            cmbxRegistry.Validated += cmbxRegistry_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtCountry
            // 
            txtCountry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCountry.Location = new System.Drawing.Point(89, 293);
            txtCountry.MinimumSize = new System.Drawing.Size(99, 23);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Country";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new System.Drawing.Size(250, 23);
            txtCountry.TabIndex = 35;
            // 
            // dtBirthDate
            // 
            dtBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtBirthDate.CustomFormat = "MMM dd, yyyy";
            dtBirthDate.Enabled = false;
            dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBirthDate.Location = new System.Drawing.Point(89, 177);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new System.Drawing.Size(250, 23);
            dtBirthDate.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 15);
            label2.TabIndex = 24;
            label2.Text = "First Name";
            // 
            // txtProvince
            // 
            txtProvince.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtProvince.Location = new System.Drawing.Point(89, 264);
            txtProvince.MinimumSize = new System.Drawing.Size(99, 23);
            txtProvince.Name = "txtProvince";
            txtProvince.PlaceholderText = "Province";
            txtProvince.ReadOnly = true;
            txtProvince.Size = new System.Drawing.Size(250, 23);
            txtProvince.TabIndex = 32;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(89, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new System.Drawing.Size(250, 23);
            txtFirstName.TabIndex = 21;
            // 
            // flowPanelSex
            // 
            flowPanelSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Enabled = false;
            flowPanelSex.Location = new System.Drawing.Point(89, 119);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(250, 23);
            flowPanelSex.TabIndex = 37;
            // 
            // radMale
            // 
            radMale.AutoSize = true;
            radMale.Checked = true;
            radMale.Location = new System.Drawing.Point(3, 3);
            radMale.Name = "radMale";
            radMale.Size = new System.Drawing.Size(51, 19);
            radMale.TabIndex = 4;
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
            radFemale.TabIndex = 5;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
            // 
            // txtMunicipality
            // 
            txtMunicipality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMunicipality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMunicipality.Location = new System.Drawing.Point(89, 235);
            txtMunicipality.MinimumSize = new System.Drawing.Size(99, 23);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.PlaceholderText = "City";
            txtMunicipality.ReadOnly = true;
            txtMunicipality.Size = new System.Drawing.Size(250, 23);
            txtMunicipality.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 33;
            label3.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(89, 61);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.ReadOnly = true;
            txtMiddleName.Size = new System.Drawing.Size(250, 23);
            txtMiddleName.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(4, 64);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(79, 15);
            label4.TabIndex = 34;
            label4.Text = "Middle Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(4, 238);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(60, 15);
            label13.TabIndex = 31;
            label13.Text = "Birthplace";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(4, 181);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(55, 15);
            label12.TabIndex = 29;
            label12.Text = "Birthdate";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(4, 325);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 15);
            label11.TabIndex = 27;
            label11.Text = "Contact Info.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 151);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 15);
            label5.TabIndex = 25;
            label5.Text = "Nationality";
            // 
            // txtContactInfo
            // 
            txtContactInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtContactInfo.Location = new System.Drawing.Point(89, 322);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.ReadOnly = true;
            txtContactInfo.Size = new System.Drawing.Size(250, 23);
            txtContactInfo.TabIndex = 36;
            // 
            // txtNationality
            // 
            txtNationality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtNationality.Location = new System.Drawing.Point(89, 148);
            txtNationality.Name = "txtNationality";
            txtNationality.ReadOnly = true;
            txtNationality.Size = new System.Drawing.Size(250, 23);
            txtNationality.TabIndex = 26;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(89, 90);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new System.Drawing.Size(250, 23);
            txtLastName.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(4, 208);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(28, 15);
            label6.TabIndex = 29;
            label6.Text = "Age";
            // 
            // nudAge
            // 
            nudAge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAge.Location = new System.Drawing.Point(89, 206);
            nudAge.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.ReadOnly = true;
            nudAge.Size = new System.Drawing.Size(250, 23);
            nudAge.TabIndex = 38;
            nudAge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(4, 125);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(25, 15);
            label7.TabIndex = 33;
            label7.Text = "Sex";
            // 
            // ucRemainsInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(nudAge);
            Controls.Add(txtCountry);
            Controls.Add(dtBirthDate);
            Controls.Add(label2);
            Controls.Add(txtProvince);
            Controls.Add(txtFirstName);
            Controls.Add(flowPanelSex);
            Controls.Add(txtMunicipality);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(txtMiddleName);
            Controls.Add(label4);
            Controls.Add(label13);
            Controls.Add(label6);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(txtContactInfo);
            Controls.Add(txtNationality);
            Controls.Add(txtLastName);
            Controls.Add(cmbxRegistry);
            Controls.Add(label1);
            Name = "ucRemainsInfo";
            Size = new System.Drawing.Size(360, 351);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtContactInfo;
        internal System.Windows.Forms.TextBox txtNationality;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAge;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbxRegistry;
    }
}
