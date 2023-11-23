namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    partial class ucBurialPermit
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
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageRemainsInfo = new System.Windows.Forms.TabPage();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radMale = new System.Windows.Forms.RadioButton();
            radFemale = new System.Windows.Forms.RadioButton();
            label6 = new System.Windows.Forms.Label();
            nudRemainsAge = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            txtRemainsNationality = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtRemainsName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tabPageDeathDetails = new System.Windows.Forms.TabPage();
            flpEmbalmed = new System.Windows.Forms.FlowLayoutPanel();
            radEmbalmedYes = new System.Windows.Forms.RadioButton();
            radEmbalmedNo = new System.Windows.Forms.RadioButton();
            flpInfectious = new System.Windows.Forms.FlowLayoutPanel();
            radInfectiousYes = new System.Windows.Forms.RadioButton();
            radInfectiousNo = new System.Windows.Forms.RadioButton();
            dtpDeathDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txtCauseOfDeath = new System.Windows.Forms.TextBox();
            txtDisposition = new System.Windows.Forms.TextBox();
            txtDisinterment = new System.Windows.Forms.TextBox();
            txtCemetery = new System.Windows.Forms.TextBox();
            tabPageCharges = new System.Windows.Forms.TabPage();
            ucOtherCharges1 = new ucOtherCharges();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageRemainsInfo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRemainsAge).BeginInit();
            tabPageDeathDetails.SuspendLayout();
            flpEmbalmed.SuspendLayout();
            flpInfectious.SuspendLayout();
            tabPageCharges.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageRemainsInfo);
            tabControl1.Controls.Add(tabPageDeathDetails);
            tabControl1.Controls.Add(tabPageCharges);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(590, 402);
            tabControl1.TabIndex = 4;
            // 
            // tabPageRemainsInfo
            // 
            tabPageRemainsInfo.Controls.Add(flowLayoutPanel1);
            tabPageRemainsInfo.Controls.Add(label6);
            tabPageRemainsInfo.Controls.Add(nudRemainsAge);
            tabPageRemainsInfo.Controls.Add(label5);
            tabPageRemainsInfo.Controls.Add(txtRemainsNationality);
            tabPageRemainsInfo.Controls.Add(label3);
            tabPageRemainsInfo.Controls.Add(txtRemainsName);
            tabPageRemainsInfo.Controls.Add(label4);
            tabPageRemainsInfo.Location = new System.Drawing.Point(4, 24);
            tabPageRemainsInfo.Name = "tabPageRemainsInfo";
            tabPageRemainsInfo.Padding = new System.Windows.Forms.Padding(4);
            tabPageRemainsInfo.Size = new System.Drawing.Size(582, 374);
            tabPageRemainsInfo.TabIndex = 2;
            tabPageRemainsInfo.Text = "Remains Info.";
            tabPageRemainsInfo.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radMale);
            flowLayoutPanel1.Controls.Add(radFemale);
            flowLayoutPanel1.Location = new System.Drawing.Point(7, 175);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(554, 25);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // radMale
            // 
            radMale.AutoSize = true;
            radMale.Checked = true;
            radMale.Location = new System.Drawing.Point(3, 3);
            radMale.Name = "radMale";
            radMale.Size = new System.Drawing.Size(51, 19);
            radMale.TabIndex = 12;
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
            radFemale.TabIndex = 12;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 157);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(25, 15);
            label6.TabIndex = 6;
            label6.Text = "Sex";
            // 
            // nudRemainsAge
            // 
            nudRemainsAge.Location = new System.Drawing.Point(7, 124);
            nudRemainsAge.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            nudRemainsAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudRemainsAge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRemainsAge.Name = "nudRemainsAge";
            nudRemainsAge.Size = new System.Drawing.Size(76, 23);
            nudRemainsAge.TabIndex = 11;
            nudRemainsAge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 106);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(28, 15);
            label5.TabIndex = 7;
            label5.Text = "Age";
            // 
            // txtRemainsNationality
            // 
            txtRemainsNationality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRemainsNationality.Location = new System.Drawing.Point(7, 73);
            txtRemainsNationality.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtRemainsNationality.Name = "txtRemainsNationality";
            txtRemainsNationality.Size = new System.Drawing.Size(554, 23);
            txtRemainsNationality.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 9;
            label3.Text = "Nationality";
            // 
            // txtRemainsName
            // 
            txtRemainsName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRemainsName.Location = new System.Drawing.Point(7, 22);
            txtRemainsName.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtRemainsName.Name = "txtRemainsName";
            txtRemainsName.Size = new System.Drawing.Size(554, 23);
            txtRemainsName.TabIndex = 5;
            txtRemainsName.Validating += txtRemainsName_Validating;
            txtRemainsName.Validated += txtRemainsName_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 4);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 10;
            label4.Text = "Name";
            // 
            // tabPageDeathDetails
            // 
            tabPageDeathDetails.Controls.Add(flpEmbalmed);
            tabPageDeathDetails.Controls.Add(flpInfectious);
            tabPageDeathDetails.Controls.Add(dtpDeathDate);
            tabPageDeathDetails.Controls.Add(label7);
            tabPageDeathDetails.Controls.Add(label12);
            tabPageDeathDetails.Controls.Add(label11);
            tabPageDeathDetails.Controls.Add(label13);
            tabPageDeathDetails.Controls.Add(label10);
            tabPageDeathDetails.Controls.Add(label9);
            tabPageDeathDetails.Controls.Add(label8);
            tabPageDeathDetails.Controls.Add(txtCauseOfDeath);
            tabPageDeathDetails.Controls.Add(txtDisposition);
            tabPageDeathDetails.Controls.Add(txtDisinterment);
            tabPageDeathDetails.Controls.Add(txtCemetery);
            tabPageDeathDetails.Location = new System.Drawing.Point(4, 24);
            tabPageDeathDetails.Name = "tabPageDeathDetails";
            tabPageDeathDetails.Padding = new System.Windows.Forms.Padding(4);
            tabPageDeathDetails.Size = new System.Drawing.Size(582, 374);
            tabPageDeathDetails.TabIndex = 0;
            tabPageDeathDetails.Text = "Death Details";
            tabPageDeathDetails.UseVisualStyleBackColor = true;
            // 
            // flpEmbalmed
            // 
            flpEmbalmed.Controls.Add(radEmbalmedYes);
            flpEmbalmed.Controls.Add(radEmbalmedNo);
            flpEmbalmed.Location = new System.Drawing.Point(7, 330);
            flpEmbalmed.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            flpEmbalmed.Name = "flpEmbalmed";
            flpEmbalmed.Size = new System.Drawing.Size(200, 25);
            flpEmbalmed.TabIndex = 29;
            // 
            // radEmbalmedYes
            // 
            radEmbalmedYes.AutoSize = true;
            radEmbalmedYes.Checked = true;
            radEmbalmedYes.Location = new System.Drawing.Point(3, 3);
            radEmbalmedYes.Name = "radEmbalmedYes";
            radEmbalmedYes.Size = new System.Drawing.Size(42, 19);
            radEmbalmedYes.TabIndex = 28;
            radEmbalmedYes.TabStop = true;
            radEmbalmedYes.Text = "Yes";
            radEmbalmedYes.UseVisualStyleBackColor = true;
            // 
            // radEmbalmedNo
            // 
            radEmbalmedNo.AutoSize = true;
            radEmbalmedNo.Location = new System.Drawing.Point(51, 3);
            radEmbalmedNo.Name = "radEmbalmedNo";
            radEmbalmedNo.Size = new System.Drawing.Size(41, 19);
            radEmbalmedNo.TabIndex = 28;
            radEmbalmedNo.TabStop = true;
            radEmbalmedNo.Text = "No";
            radEmbalmedNo.UseVisualStyleBackColor = true;
            // 
            // flpInfectious
            // 
            flpInfectious.Controls.Add(radInfectiousYes);
            flpInfectious.Controls.Add(radInfectiousNo);
            flpInfectious.Location = new System.Drawing.Point(7, 277);
            flpInfectious.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            flpInfectious.Name = "flpInfectious";
            flpInfectious.Size = new System.Drawing.Size(200, 25);
            flpInfectious.TabIndex = 29;
            // 
            // radInfectiousYes
            // 
            radInfectiousYes.AutoSize = true;
            radInfectiousYes.Location = new System.Drawing.Point(3, 3);
            radInfectiousYes.Name = "radInfectiousYes";
            radInfectiousYes.Size = new System.Drawing.Size(42, 19);
            radInfectiousYes.TabIndex = 28;
            radInfectiousYes.TabStop = true;
            radInfectiousYes.Text = "Yes";
            radInfectiousYes.UseVisualStyleBackColor = true;
            // 
            // radInfectiousNo
            // 
            radInfectiousNo.AutoSize = true;
            radInfectiousNo.Checked = true;
            radInfectiousNo.Location = new System.Drawing.Point(51, 3);
            radInfectiousNo.Name = "radInfectiousNo";
            radInfectiousNo.Size = new System.Drawing.Size(41, 19);
            radInfectiousNo.TabIndex = 28;
            radInfectiousNo.TabStop = true;
            radInfectiousNo.Text = "No";
            radInfectiousNo.UseVisualStyleBackColor = true;
            // 
            // dtpDeathDate
            // 
            dtpDeathDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDeathDate.Location = new System.Drawing.Point(7, 22);
            dtpDeathDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            dtpDeathDate.Name = "dtpDeathDate";
            dtpDeathDate.Size = new System.Drawing.Size(554, 23);
            dtpDeathDate.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(7, 4);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 15);
            label7.TabIndex = 12;
            label7.Text = "Date of Death";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(7, 312);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(64, 15);
            label12.TabIndex = 13;
            label12.Text = "Embalmed";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(7, 259);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(59, 15);
            label11.TabIndex = 14;
            label11.Text = "Infectious";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(7, 208);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(87, 15);
            label13.TabIndex = 15;
            label13.Text = "Cause of Death";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(7, 157);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(66, 15);
            label10.TabIndex = 16;
            label10.Text = "Disposition";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(7, 106);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(75, 15);
            label9.TabIndex = 17;
            label9.Text = "Disinterment";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(7, 55);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(58, 15);
            label8.TabIndex = 18;
            label8.Text = "Cemetery";
            // 
            // txtCauseOfDeath
            // 
            txtCauseOfDeath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCauseOfDeath.Location = new System.Drawing.Point(7, 226);
            txtCauseOfDeath.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtCauseOfDeath.Name = "txtCauseOfDeath";
            txtCauseOfDeath.Size = new System.Drawing.Size(554, 23);
            txtCauseOfDeath.TabIndex = 23;
            txtCauseOfDeath.Validating += txtCauseOfDeath_Validating;
            txtCauseOfDeath.Validated += txtCauseOfDeath_Validated;
            // 
            // txtDisposition
            // 
            txtDisposition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDisposition.Location = new System.Drawing.Point(7, 175);
            txtDisposition.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtDisposition.Name = "txtDisposition";
            txtDisposition.Size = new System.Drawing.Size(554, 23);
            txtDisposition.TabIndex = 22;
            txtDisposition.Validating += txtDisposition_Validating;
            txtDisposition.Validated += txtDisposition_Validated;
            // 
            // txtDisinterment
            // 
            txtDisinterment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDisinterment.Location = new System.Drawing.Point(7, 124);
            txtDisinterment.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtDisinterment.Name = "txtDisinterment";
            txtDisinterment.Size = new System.Drawing.Size(554, 23);
            txtDisinterment.TabIndex = 21;
            txtDisinterment.Validating += txtDisinterment_Validating;
            txtDisinterment.Validated += txtDisinterment_Validated;
            // 
            // txtCemetery
            // 
            txtCemetery.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCemetery.Location = new System.Drawing.Point(7, 73);
            txtCemetery.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            txtCemetery.Name = "txtCemetery";
            txtCemetery.Size = new System.Drawing.Size(554, 23);
            txtCemetery.TabIndex = 20;
            txtCemetery.Validating += txtCemetery_Validating;
            txtCemetery.Validated += txtCemetery_Validated;
            // 
            // tabPageCharges
            // 
            tabPageCharges.Controls.Add(ucOtherCharges1);
            tabPageCharges.Location = new System.Drawing.Point(4, 24);
            tabPageCharges.Name = "tabPageCharges";
            tabPageCharges.Padding = new System.Windows.Forms.Padding(3);
            tabPageCharges.Size = new System.Drawing.Size(582, 374);
            tabPageCharges.TabIndex = 1;
            tabPageCharges.Text = "Charges";
            tabPageCharges.UseVisualStyleBackColor = true;
            // 
            // ucOtherCharges1
            // 
            ucOtherCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucOtherCharges1.Location = new System.Drawing.Point(3, 3);
            ucOtherCharges1.Name = "ucOtherCharges1";
            ucOtherCharges1.Size = new System.Drawing.Size(576, 368);
            ucOtherCharges1.TabIndex = 0;
            // 
            // ucBurialPermit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(tabControl1);
            Name = "ucBurialPermit";
            Size = new System.Drawing.Size(590, 402);
            Load += ucBurialPermit_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageRemainsInfo.ResumeLayout(false);
            tabPageRemainsInfo.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRemainsAge).EndInit();
            tabPageDeathDetails.ResumeLayout(false);
            tabPageDeathDetails.PerformLayout();
            flpEmbalmed.ResumeLayout(false);
            flpEmbalmed.PerformLayout();
            flpInfectious.ResumeLayout(false);
            flpInfectious.PerformLayout();
            tabPageCharges.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.NumericUpDown nudRemainsAge;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtRemainsNationality;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtRemainsName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtpDeathDate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtCauseOfDeath;
        internal System.Windows.Forms.TextBox txtDisposition;
        internal System.Windows.Forms.TextBox txtDisinterment;
        internal System.Windows.Forms.TextBox txtCemetery;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPageDeathDetails;
        internal System.Windows.Forms.TabPage tabPageCharges;
        internal System.Windows.Forms.TabPage tabPageRemainsInfo;
        internal ucOtherCharges ucOtherCharges1;
        internal System.Windows.Forms.RadioButton radFemale;
        internal System.Windows.Forms.RadioButton radMale;
        internal System.Windows.Forms.FlowLayoutPanel flpEmbalmed;
        internal System.Windows.Forms.RadioButton radEmbalmedYes;
        internal System.Windows.Forms.RadioButton radEmbalmedNo;
        internal System.Windows.Forms.FlowLayoutPanel flpInfectious;
        internal System.Windows.Forms.RadioButton radInfectiousYes;
        internal System.Windows.Forms.RadioButton radInfectiousNo;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
