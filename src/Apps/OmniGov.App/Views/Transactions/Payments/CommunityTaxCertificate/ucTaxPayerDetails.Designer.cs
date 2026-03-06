namespace OmniGov.App.Views.Transactions.Payments.CommunityTaxCertificate
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
            components = new System.ComponentModel.Container();
            radWidow = new System.Windows.Forms.RadioButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radSingle = new System.Windows.Forms.RadioButton();
            radMarried = new System.Windows.Forms.RadioButton();
            radDivorced = new System.Windows.Forms.RadioButton();
            nudYear = new System.Windows.Forms.NumericUpDown();
            label17 = new System.Windows.Forms.Label();
            dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            label16 = new System.Windows.Forms.Label();
            txtPlaceOfBirth = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            txtICR = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtCitizenship = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtTIN = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            txtMiddleName = new System.Windows.Forms.TextBox();
            txtOccupation = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            radFemale = new System.Windows.Forms.RadioButton();
            radMale = new System.Windows.Forms.RadioButton();
            flowPanelSex = new System.Windows.Forms.FlowLayoutPanel();
            txtPlaceOfIssue = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            dtpDateOfIssued = new System.Windows.Forms.DateTimePicker();
            nudHeight = new System.Windows.Forms.NumericUpDown();
            nudWeight = new System.Windows.Forms.NumericUpDown();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            flowPanelSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // radWidow
            // 
            radWidow.AutoSize = true;
            radWidow.Location = new System.Drawing.Point(138, 3);
            radWidow.Name = "radWidow";
            radWidow.Size = new System.Drawing.Size(62, 19);
            radWidow.TabIndex = 2;
            radWidow.Text = "Widow";
            radWidow.UseVisualStyleBackColor = true;
            radWidow.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(radSingle);
            flowLayoutPanel1.Controls.Add(radMarried);
            flowLayoutPanel1.Controls.Add(radWidow);
            flowLayoutPanel1.Controls.Add(radDivorced);
            flowLayoutPanel1.Location = new System.Drawing.Point(216, 363);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(289, 23);
            flowLayoutPanel1.TabIndex = 75;
            // 
            // radSingle
            // 
            radSingle.AutoSize = true;
            radSingle.Checked = true;
            radSingle.Location = new System.Drawing.Point(3, 3);
            radSingle.Name = "radSingle";
            radSingle.Size = new System.Drawing.Size(57, 19);
            radSingle.TabIndex = 0;
            radSingle.TabStop = true;
            radSingle.Text = "Single";
            radSingle.UseVisualStyleBackColor = true;
            // 
            // radMarried
            // 
            radMarried.AutoSize = true;
            radMarried.Location = new System.Drawing.Point(66, 3);
            radMarried.Name = "radMarried";
            radMarried.Size = new System.Drawing.Size(66, 19);
            radMarried.TabIndex = 1;
            radMarried.Text = "Married";
            radMarried.UseVisualStyleBackColor = true;
            // 
            // radDivorced
            // 
            radDivorced.AutoSize = true;
            radDivorced.Location = new System.Drawing.Point(206, 3);
            radDivorced.Name = "radDivorced";
            radDivorced.Size = new System.Drawing.Size(72, 19);
            radDivorced.TabIndex = 3;
            radDivorced.Text = "Divorced";
            radDivorced.UseVisualStyleBackColor = true;
            // 
            // nudYear
            // 
            nudYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudYear.Location = new System.Drawing.Point(216, 11);
            nudYear.Maximum = new decimal(new int[] { 2099, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 2023, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(289, 23);
            nudYear.TabIndex = 0;
            nudYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(10, 398);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(73, 15);
            label17.TabIndex = 73;
            label17.Text = "Date of Birth";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDateOfBirth.CustomFormat = "MMM dd, yyyy";
            dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new System.Drawing.Point(216, 394);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new System.Drawing.Size(289, 23);
            dtpDateOfBirth.TabIndex = 11;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(10, 366);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 15);
            label16.TabIndex = 71;
            label16.Text = "Civil Status";
            // 
            // txtPlaceOfBirth
            // 
            txtPlaceOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPlaceOfBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPlaceOfBirth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPlaceOfBirth.Location = new System.Drawing.Point(216, 335);
            txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            txtPlaceOfBirth.Size = new System.Drawing.Size(289, 23);
            txtPlaceOfBirth.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(10, 335);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(77, 15);
            label15.TabIndex = 69;
            label15.Text = "Place of Birth";
            // 
            // txtICR
            // 
            txtICR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtICR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtICR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtICR.Location = new System.Drawing.Point(216, 306);
            txtICR.Name = "txtICR";
            txtICR.Size = new System.Drawing.Size(289, 23);
            txtICR.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 306);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 15);
            label3.TabIndex = 67;
            label3.Text = "ICR No. (If an Alien)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 277);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 56;
            label2.Text = "Citizenship";
            // 
            // txtCitizenship
            // 
            txtCitizenship.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCitizenship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCitizenship.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCitizenship.Location = new System.Drawing.Point(216, 277);
            txtCitizenship.Name = "txtCitizenship";
            txtCitizenship.Size = new System.Drawing.Size(289, 23);
            txtCitizenship.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 15);
            label1.TabIndex = 65;
            label1.Text = "Year";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(10, 481);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(200, 15);
            label9.TabIndex = 56;
            label9.Text = "Professional / Occupation / Business";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 423);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(87, 15);
            label6.TabIndex = 53;
            label6.Text = "Height (in cm.)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 99);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(25, 15);
            label5.TabIndex = 63;
            label5.Text = "TIN";
            // 
            // txtTIN
            // 
            txtTIN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTIN.Location = new System.Drawing.Point(216, 98);
            txtTIN.Name = "txtTIN";
            txtTIN.Size = new System.Drawing.Size(289, 23);
            txtTIN.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(216, 190);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(289, 23);
            txtLastName.TabIndex = 6;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleName.Location = new System.Drawing.Point(216, 158);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new System.Drawing.Size(289, 23);
            txtMiddleName.TabIndex = 5;
            // 
            // txtOccupation
            // 
            txtOccupation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOccupation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtOccupation.Location = new System.Drawing.Point(216, 481);
            txtOccupation.Name = "txtOccupation";
            txtOccupation.Size = new System.Drawing.Size(289, 23);
            txtOccupation.TabIndex = 14;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(9, 190);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(63, 15);
            label14.TabIndex = 52;
            label14.Text = "Last Name";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(10, 251);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(25, 15);
            label11.TabIndex = 56;
            label11.Text = "Sex";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(10, 73);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(60, 15);
            label12.TabIndex = 57;
            label12.Text = "Date Issue";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 452);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 15);
            label4.TabIndex = 53;
            label4.Text = "Weight (in kg.)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(10, 219);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(49, 15);
            label13.TabIndex = 58;
            label13.Text = "Address";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(10, 129);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(64, 15);
            label10.TabIndex = 60;
            label10.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(216, 129);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(289, 23);
            txtFirstName.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(10, 158);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(79, 15);
            label8.TabIndex = 59;
            label8.Text = "Middle Name";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtAddress.Location = new System.Drawing.Point(216, 219);
            txtAddress.MinimumSize = new System.Drawing.Size(99, 23);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(289, 23);
            txtAddress.TabIndex = 7;
            // 
            // radFemale
            // 
            radFemale.AutoSize = true;
            radFemale.Location = new System.Drawing.Point(60, 3);
            radFemale.Name = "radFemale";
            radFemale.Size = new System.Drawing.Size(63, 19);
            radFemale.TabIndex = 1;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
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
            // flowPanelSex
            // 
            flowPanelSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowPanelSex.Controls.Add(radMale);
            flowPanelSex.Controls.Add(radFemale);
            flowPanelSex.Location = new System.Drawing.Point(216, 248);
            flowPanelSex.Name = "flowPanelSex";
            flowPanelSex.Size = new System.Drawing.Size(289, 23);
            flowPanelSex.TabIndex = 40;
            // 
            // txtPlaceOfIssue
            // 
            txtPlaceOfIssue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPlaceOfIssue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPlaceOfIssue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPlaceOfIssue.Location = new System.Drawing.Point(216, 40);
            txtPlaceOfIssue.Name = "txtPlaceOfIssue";
            txtPlaceOfIssue.Size = new System.Drawing.Size(289, 23);
            txtPlaceOfIssue.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(11, 40);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(78, 15);
            label7.TabIndex = 51;
            label7.Text = "Place of Issue";
            // 
            // dtpDateOfIssued
            // 
            dtpDateOfIssued.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDateOfIssued.CustomFormat = "MMM dd, yyyy";
            dtpDateOfIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateOfIssued.Location = new System.Drawing.Point(216, 69);
            dtpDateOfIssued.Name = "dtpDateOfIssued";
            dtpDateOfIssued.Size = new System.Drawing.Size(289, 23);
            dtpDateOfIssued.TabIndex = 2;
            // 
            // nudHeight
            // 
            nudHeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudHeight.DecimalPlaces = 2;
            nudHeight.Location = new System.Drawing.Point(216, 423);
            nudHeight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudHeight.Name = "nudHeight";
            nudHeight.Size = new System.Drawing.Size(289, 23);
            nudHeight.TabIndex = 12;
            // 
            // nudWeight
            // 
            nudWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudWeight.DecimalPlaces = 2;
            nudWeight.Location = new System.Drawing.Point(216, 452);
            nudWeight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new System.Drawing.Size(289, 23);
            nudWeight.TabIndex = 13;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucTaxPayerDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(nudYear);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(txtPlaceOfBirth);
            Controls.Add(label3);
            Controls.Add(txtICR);
            Controls.Add(label1);
            Controls.Add(txtTIN);
            Controls.Add(label5);
            Controls.Add(txtLastName);
            Controls.Add(nudWeight);
            Controls.Add(nudHeight);
            Controls.Add(dtpDateOfIssued);
            Controls.Add(label7);
            Controls.Add(txtPlaceOfIssue);
            Controls.Add(flowPanelSex);
            Controls.Add(txtAddress);
            Controls.Add(label8);
            Controls.Add(txtFirstName);
            Controls.Add(label10);
            Controls.Add(label13);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label12);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(label14);
            Controls.Add(txtCitizenship);
            Controls.Add(txtOccupation);
            Controls.Add(txtMiddleName);
            Name = "ucTaxPayerDetails";
            Size = new System.Drawing.Size(534, 509);
            Load += ucTaxPayerDetails_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            flowPanelSex.ResumeLayout(false);
            flowPanelSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.RadioButton radWidow;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.RadioButton radSingle;
        internal System.Windows.Forms.RadioButton radMarried;
        internal System.Windows.Forms.RadioButton radDivorced;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtPlaceOfBirth;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtICR;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtCitizenship;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.TextBox txtMiddleName;
        internal System.Windows.Forms.TextBox txtOccupation;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.FlowLayoutPanel flowPanelSex;
        internal System.Windows.Forms.TextBox txtPlaceOfIssue;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.NumericUpDown nudYear;
        internal System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        internal System.Windows.Forms.TextBox txtTIN;
        internal System.Windows.Forms.DateTimePicker dtpDateOfIssued;
        internal System.Windows.Forms.NumericUpDown nudHeight;
        internal System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
