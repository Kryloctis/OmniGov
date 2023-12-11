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
            label1 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtMiddleName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            label5 = new System.Windows.Forms.Label();
            txtNationality = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtStreet = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            txtCountry = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            txtProvince = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtBarangay = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            dtBirthDate = new System.Windows.Forms.DateTimePicker();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            txtContactInfo = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            flowPanelSex.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "First Name*";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(88, 6);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(250, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.Validating += txtFirstName_Validating;
            txtFirstName.Validated += txtFirstName_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 0;
            label2.Text = "Last Name*";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(88, 64);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(250, 23);
            txtLastName.TabIndex = 1;
            txtLastName.Validating += txtLastName_Validating;
            txtLastName.Validated += txtLastName_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 38);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 15);
            label3.TabIndex = 0;
            label3.Text = "Middle Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(88, 35);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new System.Drawing.Size(250, 23);
            txtMiddleName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 97);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(25, 15);
            label4.TabIndex = 0;
            label4.Text = "Sex";
            // 
            // flowPanelSex
            // 
            flowPanelSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Location = new System.Drawing.Point(88, 93);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(250, 23);
            flowPanelSex.TabIndex = 2;
            // 
            // radMale
            // 
            radMale.AutoSize = true;
            radMale.Checked = true;
            radMale.Location = new System.Drawing.Point(3, 3);
            radMale.Name = "radMale";
            radMale.Size = new System.Drawing.Size(51, 19);
            radMale.TabIndex = 0;
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
            radFemale.TabIndex = 0;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 125);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 15);
            label5.TabIndex = 0;
            label5.Text = "Nationality*";
            // 
            // txtNationality
            // 
            txtNationality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtNationality.Location = new System.Drawing.Point(88, 122);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new System.Drawing.Size(250, 23);
            txtNationality.TabIndex = 1;
            txtNationality.Validating += txtNationality_Validating;
            txtNationality.Validated += txtNationality_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 9);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 15);
            label6.TabIndex = 0;
            label6.Text = "Street";
            // 
            // txtStreet
            // 
            txtStreet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtStreet.Location = new System.Drawing.Point(88, 6);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new System.Drawing.Size(250, 23);
            txtStreet.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(3, 253);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(364, 178);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Place of Birth";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCountry);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtProvince);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtMunicipality);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtBarangay);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtStreet);
            panel1.Controls.Add(label6);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            panel1.Location = new System.Drawing.Point(3, 23);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(358, 152);
            panel1.TabIndex = 0;
            // 
            // txtCountry
            // 
            txtCountry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCountry.Location = new System.Drawing.Point(88, 122);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new System.Drawing.Size(250, 23);
            txtCountry.TabIndex = 1;
            txtCountry.Validating += txtCountry_Validating;
            txtCountry.Validated += txtCountry_Validated;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 125);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(55, 15);
            label10.TabIndex = 0;
            label10.Text = "Country*";
            // 
            // txtProvince
            // 
            txtProvince.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtProvince.Location = new System.Drawing.Point(88, 93);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new System.Drawing.Size(250, 23);
            txtProvince.TabIndex = 1;
            txtProvince.Validating += txtProvince_Validating;
            txtProvince.Validated += txtProvince_Validated;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 96);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(58, 15);
            label9.TabIndex = 0;
            label9.Text = "Province*";
            // 
            // txtMunicipality
            // 
            txtMunicipality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMunicipality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMunicipality.Location = new System.Drawing.Point(88, 64);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new System.Drawing.Size(250, 23);
            txtMunicipality.TabIndex = 1;
            txtMunicipality.Validating += txtMunicipality_Validating;
            txtMunicipality.Validated += txtMunicipality_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(3, 67);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(78, 15);
            label8.TabIndex = 0;
            label8.Text = "Municipality*";
            // 
            // txtBarangay
            // 
            txtBarangay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBarangay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtBarangay.Location = new System.Drawing.Point(88, 35);
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new System.Drawing.Size(250, 23);
            txtBarangay.TabIndex = 1;
            txtBarangay.Validating += txtBarangay_Validating;
            txtBarangay.Validated += txtBarangay_Validated;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 38);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 15);
            label7.TabIndex = 0;
            label7.Text = "Barangay*";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(364, 237);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Personal Info.";
            // 
            // panel2
            // 
            panel2.Controls.Add(dtBirthDate);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(flowPanelSex);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtMiddleName);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtContactInfo);
            panel2.Controls.Add(txtNationality);
            panel2.Controls.Add(txtLastName);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.Location = new System.Drawing.Point(3, 23);
            panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(358, 211);
            panel2.TabIndex = 0;
            // 
            // dtBirthDate
            // 
            dtBirthDate.CustomFormat = "MMM dd, yyyy";
            dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBirthDate.Location = new System.Drawing.Point(88, 180);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new System.Drawing.Size(250, 23);
            dtBirthDate.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 184);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(55, 15);
            label12.TabIndex = 0;
            label12.Text = "Birthdate";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 154);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 15);
            label11.TabIndex = 0;
            label11.Text = "Contact Info.";
            // 
            // txtContactInfo
            // 
            txtContactInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContactInfo.Location = new System.Drawing.Point(88, 151);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.Size = new System.Drawing.Size(250, 23);
            txtContactInfo.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucRegistry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ucRegistry";
            Size = new System.Drawing.Size(370, 435);
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtNationality;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox txtProvince;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtBarangay;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtCountry;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtContactInfo;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        internal System.Windows.Forms.Label label12;
    }
}
