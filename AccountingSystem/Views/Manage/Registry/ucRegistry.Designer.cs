namespace AccountingSystem.Views.Manage.Registry
{
    partial class ucRegistry
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
            txtCountry = new System.Windows.Forms.TextBox();
            dtBirthDate = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            txtProvince = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtMiddleName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtContactInfo = new System.Windows.Forms.TextBox();
            txtNationality = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            flowPanelSex.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // txtCountry
            // 
            txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCountry.Location = new System.Drawing.Point(88, 235);
            txtCountry.MinimumSize = new System.Drawing.Size(99, 23);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Country";
            txtCountry.Size = new System.Drawing.Size(243, 23);
            txtCountry.TabIndex = 10;
            txtCountry.Validating += txtCountry_Validating;
            txtCountry.Validated += txtCountry_Validated;
            // 
            // dtBirthDate
            // 
            dtBirthDate.CustomFormat = "MMM dd, yyyy";
            dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBirthDate.Location = new System.Drawing.Point(88, 148);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new System.Drawing.Size(243, 23);
            dtBirthDate.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 4;
            label1.Text = "First Name*";
            // 
            // txtProvince
            // 
            txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtProvince.Location = new System.Drawing.Point(88, 206);
            txtProvince.MinimumSize = new System.Drawing.Size(99, 23);
            txtProvince.Name = "txtProvince";
            txtProvince.PlaceholderText = "Province";
            txtProvince.Size = new System.Drawing.Size(243, 23);
            txtProvince.TabIndex = 9;
            txtProvince.Validating += txtProvince_Validating;
            txtProvince.Validated += txtProvince_Validated;
            // 
            // txtFirstName
            // 
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(88, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(243, 23);
            txtFirstName.TabIndex = 0;
            txtFirstName.Validating += txtFirstName_Validating;
            txtFirstName.Validated += txtFirstName_Validated;
            // 
            // flowPanelSex
            // 
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Location = new System.Drawing.Point(88, 90);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(243, 23);
            flowPanelSex.TabIndex = 20;
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
            txtMunicipality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMunicipality.Location = new System.Drawing.Point(88, 177);
            txtMunicipality.MinimumSize = new System.Drawing.Size(99, 23);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.PlaceholderText = "City";
            txtMunicipality.Size = new System.Drawing.Size(243, 23);
            txtMunicipality.TabIndex = 8;
            txtMunicipality.Validating += txtMunicipality_Validating;
            txtMunicipality.Validated += txtMunicipality_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 9;
            label2.Text = "Last Name*";
            // 
            // txtMiddleName
            // 
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(88, 32);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new System.Drawing.Size(243, 23);
            txtMiddleName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 94);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(25, 15);
            label4.TabIndex = 11;
            label4.Text = "Sex";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 35);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 15);
            label3.TabIndex = 10;
            label3.Text = "Middle Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(3, 180);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(65, 15);
            label13.TabIndex = 8;
            label13.Text = "Birthplace*";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 152);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(60, 15);
            label12.TabIndex = 7;
            label12.Text = "Birthdate*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 267);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 15);
            label11.TabIndex = 6;
            label11.Text = "Contact Info.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 122);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 15);
            label5.TabIndex = 5;
            label5.Text = "Nationality*";
            // 
            // txtContactInfo
            // 
            txtContactInfo.Location = new System.Drawing.Point(88, 264);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.Size = new System.Drawing.Size(243, 23);
            txtContactInfo.TabIndex = 11;
            // 
            // txtNationality
            // 
            txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtNationality.Location = new System.Drawing.Point(88, 119);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new System.Drawing.Size(243, 23);
            txtNationality.TabIndex = 6;
            txtNationality.Validating += txtNationality_Validating;
            txtNationality.Validated += txtNationality_Validated;
            // 
            // txtLastName
            // 
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(88, 61);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(243, 23);
            txtLastName.TabIndex = 2;
            txtLastName.Validating += txtLastName_Validating;
            txtLastName.Validated += txtLastName_Validated;
            // 
            // ucRegistry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtCountry);
            Controls.Add(dtBirthDate);
            Controls.Add(label1);
            Controls.Add(txtProvince);
            Controls.Add(txtFirstName);
            Controls.Add(flowPanelSex);
            Controls.Add(txtMunicipality);
            Controls.Add(label2);
            Controls.Add(txtMiddleName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(txtContactInfo);
            Controls.Add(txtNationality);
            Controls.Add(txtLastName);
            Name = "ucRegistry";
            Size = new System.Drawing.Size(350, 293);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtContactInfo;
        internal System.Windows.Forms.TextBox txtNationality;
        internal System.Windows.Forms.TextBox txtLastName;
    }
}
