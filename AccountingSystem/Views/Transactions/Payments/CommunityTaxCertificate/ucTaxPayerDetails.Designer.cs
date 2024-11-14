namespace AccountingSystem.Views.Transactions.Payments.CommunityTaxCertificate
{
    partial class ucTaxPayerDetails
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
            nudMonths = new System.Windows.Forms.NumericUpDown();
            nudAge = new System.Windows.Forms.NumericUpDown();
            dtBirthDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtMiddleName = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            txtContactInfo = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBox5 = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            textBox6 = new System.Windows.Forms.TextBox();
            textBox7 = new System.Windows.Forms.TextBox();
            label16 = new System.Windows.Forms.Label();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            flowPanelSex.SuspendLayout();
            SuspendLayout();
            // 
            // nudMonths
            // 
            nudMonths.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudMonths.Location = new System.Drawing.Point(236, 461);
            nudMonths.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudMonths.Name = "nudMonths";
            nudMonths.Size = new System.Drawing.Size(216, 23);
            nudMonths.TabIndex = 48;
            nudMonths.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudAge
            // 
            nudAge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAge.Location = new System.Drawing.Point(236, 432);
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(216, 23);
            nudAge.TabIndex = 47;
            // 
            // dtBirthDate
            // 
            dtBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtBirthDate.CustomFormat = "MMM dd, yyyy";
            dtBirthDate.Enabled = false;
            dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBirthDate.Location = new System.Drawing.Point(236, 78);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new System.Drawing.Size(216, 23);
            dtBirthDate.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(20, 49);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(78, 15);
            label7.TabIndex = 51;
            label7.Text = "Place of Issue";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(236, 49);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new System.Drawing.Size(216, 23);
            txtFirstName.TabIndex = 37;
            // 
            // flowPanelSex
            // 
            flowPanelSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Enabled = false;
            flowPanelSex.Location = new System.Drawing.Point(236, 257);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(216, 23);
            flowPanelSex.TabIndex = 40;
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
            txtMunicipality.Location = new System.Drawing.Point(236, 228);
            txtMunicipality.MinimumSize = new System.Drawing.Size(99, 23);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.PlaceholderText = "City";
            txtMunicipality.ReadOnly = true;
            txtMunicipality.Size = new System.Drawing.Size(216, 23);
            txtMunicipality.TabIndex = 43;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(20, 166);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(79, 15);
            label8.TabIndex = 59;
            label8.Text = "Middle Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(236, 138);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.ReadOnly = true;
            txtMiddleName.Size = new System.Drawing.Size(216, 23);
            txtMiddleName.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(20, 137);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(64, 15);
            label10.TabIndex = 60;
            label10.Text = "First Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(20, 228);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(49, 15);
            label13.TabIndex = 58;
            label13.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 463);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 15);
            label4.TabIndex = 53;
            label4.Text = "Weight";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(20, 75);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(81, 15);
            label12.TabIndex = 57;
            label12.Text = "Date of Issued";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(20, 259);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(25, 15);
            label11.TabIndex = 56;
            label11.Text = "Sex";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(20, 198);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(54, 15);
            label14.TabIndex = 52;
            label14.Text = "Surname";
            // 
            // txtContactInfo
            // 
            txtContactInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtContactInfo.Location = new System.Drawing.Point(236, 490);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.ReadOnly = true;
            txtContactInfo.Size = new System.Drawing.Size(216, 23);
            txtContactInfo.TabIndex = 46;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(236, 167);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new System.Drawing.Size(216, 23);
            txtLastName.TabIndex = 39;
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textBox1.Location = new System.Drawing.Point(236, 199);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(216, 23);
            textBox1.TabIndex = 61;
            // 
            // textBox2
            // 
            textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox2.Location = new System.Drawing.Point(236, 107);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(216, 23);
            textBox2.TabIndex = 62;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(20, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(30, 15);
            label5.TabIndex = 63;
            label5.Text = "TIN*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(20, 434);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 15);
            label6.TabIndex = 53;
            label6.Text = "Height";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(20, 492);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(200, 15);
            label9.TabIndex = 56;
            label9.Text = "Professional / Occupation / Business";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 15);
            label1.TabIndex = 65;
            label1.Text = "Year";
            // 
            // textBox3
            // 
            textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textBox3.Location = new System.Drawing.Point(236, 20);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(216, 23);
            textBox3.TabIndex = 64;
            // 
            // textBox4
            // 
            textBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox4.Location = new System.Drawing.Point(236, 286);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new System.Drawing.Size(216, 23);
            textBox4.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 285);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 56;
            label2.Text = "Citezenship";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 314);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 15);
            label3.TabIndex = 67;
            label3.Text = "ICR No. (If an Alien)";
            // 
            // textBox5
            // 
            textBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox5.Location = new System.Drawing.Point(236, 315);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new System.Drawing.Size(216, 23);
            textBox5.TabIndex = 66;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(20, 343);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(77, 15);
            label15.TabIndex = 69;
            label15.Text = "Place of Birth";
            // 
            // textBox6
            // 
            textBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox6.Location = new System.Drawing.Point(236, 344);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new System.Drawing.Size(216, 23);
            textBox6.TabIndex = 68;
            // 
            // textBox7
            // 
            textBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox7.Location = new System.Drawing.Point(236, 373);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new System.Drawing.Size(216, 23);
            textBox7.TabIndex = 70;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(20, 372);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 15);
            label16.TabIndex = 71;
            label16.Text = "Civil Status";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dateTimePicker1.CustomFormat = "MMM dd, yyyy";
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new System.Drawing.Point(236, 403);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(216, 23);
            dateTimePicker1.TabIndex = 72;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(20, 400);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(73, 15);
            label17.TabIndex = 73;
            label17.Text = "Date of Birth";
            // 
            // ucTaxPayerDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dateTimePicker1);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(textBox7);
            Controls.Add(label15);
            Controls.Add(textBox6);
            Controls.Add(label3);
            Controls.Add(textBox5);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(nudMonths);
            Controls.Add(nudAge);
            Controls.Add(dtBirthDate);
            Controls.Add(label7);
            Controls.Add(txtFirstName);
            Controls.Add(flowPanelSex);
            Controls.Add(txtMunicipality);
            Controls.Add(label8);
            Controls.Add(txtMiddleName);
            Controls.Add(label10);
            Controls.Add(label13);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label12);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(label14);
            Controls.Add(textBox4);
            Controls.Add(txtContactInfo);
            Controls.Add(txtLastName);
            Name = "ucTaxPayerDetails";
            Size = new System.Drawing.Size(477, 528);
            Load += ucTaxPayerDetails_Load;
            ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMonths;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.TextBox txtMunicipality;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtContactInfo;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox textBox6;
        internal System.Windows.Forms.TextBox textBox7;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label label17;
    }
}
