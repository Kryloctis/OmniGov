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
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            txtPermission = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtPayer = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            nudRemainsAge = new System.Windows.Forms.NumericUpDown();
            cmbxRemainsSex = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtRemainsNationality = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtRemainsName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            cbxIsEmbalbed = new System.Windows.Forms.CheckBox();
            cbxIsInfectious = new System.Windows.Forms.CheckBox();
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
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRemainsAge).BeginInit();
            groupBox3.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5);
            groupBox2.Size = new System.Drawing.Size(299, 241);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payer's Info.";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPermission);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtPayer);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel2.Location = new System.Drawing.Point(5, 21);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(289, 215);
            panel2.TabIndex = 0;
            // 
            // txtPermission
            // 
            txtPermission.Location = new System.Drawing.Point(77, 47);
            txtPermission.Name = "txtPermission";
            txtPermission.Size = new System.Drawing.Size(203, 23);
            txtPermission.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 47);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "Permission";
            // 
            // txtPayer
            // 
            txtPayer.Location = new System.Drawing.Point(77, 18);
            txtPayer.Name = "txtPayer";
            txtPayer.ReadOnly = true;
            txtPayer.Size = new System.Drawing.Size(203, 23);
            txtPayer.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(308, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5);
            groupBox1.Size = new System.Drawing.Size(303, 241);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Remain's Info.";
            // 
            // panel1
            // 
            panel1.Controls.Add(nudRemainsAge);
            panel1.Controls.Add(cmbxRemainsSex);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtRemainsNationality);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtRemainsName);
            panel1.Controls.Add(label4);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel1.Location = new System.Drawing.Point(5, 21);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(293, 215);
            panel1.TabIndex = 0;
            // 
            // nudRemainsAge
            // 
            nudRemainsAge.Location = new System.Drawing.Point(77, 76);
            nudRemainsAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudRemainsAge.Name = "nudRemainsAge";
            nudRemainsAge.Size = new System.Drawing.Size(99, 23);
            nudRemainsAge.TabIndex = 5;
            // 
            // cmbxRemainsSex
            // 
            cmbxRemainsSex.FormattingEnabled = true;
            cmbxRemainsSex.Location = new System.Drawing.Point(77, 105);
            cmbxRemainsSex.Name = "cmbxRemainsSex";
            cmbxRemainsSex.Size = new System.Drawing.Size(99, 23);
            cmbxRemainsSex.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 105);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(25, 15);
            label6.TabIndex = 2;
            label6.Text = "Sex";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 76);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(28, 15);
            label5.TabIndex = 2;
            label5.Text = "Age";
            // 
            // txtRemainsNationality
            // 
            txtRemainsNationality.Location = new System.Drawing.Point(77, 47);
            txtRemainsNationality.Name = "txtRemainsNationality";
            txtRemainsNationality.Size = new System.Drawing.Size(203, 23);
            txtRemainsNationality.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 47);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 2;
            label3.Text = "Nationality";
            // 
            // txtRemainsName
            // 
            txtRemainsName.Location = new System.Drawing.Point(77, 18);
            txtRemainsName.Name = "txtRemainsName";
            txtRemainsName.Size = new System.Drawing.Size(203, 23);
            txtRemainsName.TabIndex = 3;
            txtRemainsName.Validating += txtRemainsName_Validating;
            txtRemainsName.Validated += txtRemainsName_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 18);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 2;
            label4.Text = "Name";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel3);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox3.Location = new System.Drawing.Point(617, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(5);
            groupBox3.Size = new System.Drawing.Size(322, 239);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Death Details";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbxIsEmbalbed);
            panel3.Controls.Add(cbxIsInfectious);
            panel3.Controls.Add(dtpDeathDate);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtCauseOfDeath);
            panel3.Controls.Add(txtDisposition);
            panel3.Controls.Add(txtDisinterment);
            panel3.Controls.Add(txtCemetery);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel3.Location = new System.Drawing.Point(5, 21);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(312, 213);
            panel3.TabIndex = 0;
            // 
            // cbxIsEmbalbed
            // 
            cbxIsEmbalbed.AutoSize = true;
            cbxIsEmbalbed.Location = new System.Drawing.Point(99, 190);
            cbxIsEmbalbed.Name = "cbxIsEmbalbed";
            cbxIsEmbalbed.Size = new System.Drawing.Size(15, 14);
            cbxIsEmbalbed.TabIndex = 4;
            cbxIsEmbalbed.UseVisualStyleBackColor = true;
            // 
            // cbxIsInfectious
            // 
            cbxIsInfectious.AutoSize = true;
            cbxIsInfectious.Location = new System.Drawing.Point(99, 166);
            cbxIsInfectious.Name = "cbxIsInfectious";
            cbxIsInfectious.Size = new System.Drawing.Size(15, 14);
            cbxIsInfectious.TabIndex = 4;
            cbxIsInfectious.UseVisualStyleBackColor = true;
            // 
            // dtpDeathDate
            // 
            dtpDeathDate.Location = new System.Drawing.Point(99, 18);
            dtpDeathDate.Name = "dtpDeathDate";
            dtpDeathDate.Size = new System.Drawing.Size(200, 23);
            dtpDeathDate.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 21);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 15);
            label7.TabIndex = 2;
            label7.Text = "Date of Death";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(6, 187);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(64, 15);
            label12.TabIndex = 2;
            label12.Text = "Embalmed";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 163);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(59, 15);
            label11.TabIndex = 2;
            label11.Text = "Infectious";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 134);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(87, 15);
            label13.TabIndex = 2;
            label13.Text = "Cause of Death";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 105);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(66, 15);
            label10.TabIndex = 2;
            label10.Text = "Disposition";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 76);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(75, 15);
            label9.TabIndex = 2;
            label9.Text = "Disinterment";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 47);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(58, 15);
            label8.TabIndex = 2;
            label8.Text = "Cemetery";
            // 
            // txtCauseOfDeath
            // 
            txtCauseOfDeath.Location = new System.Drawing.Point(99, 132);
            txtCauseOfDeath.Name = "txtCauseOfDeath";
            txtCauseOfDeath.Size = new System.Drawing.Size(200, 23);
            txtCauseOfDeath.TabIndex = 3;
            // 
            // txtDisposition
            // 
            txtDisposition.Location = new System.Drawing.Point(99, 103);
            txtDisposition.Name = "txtDisposition";
            txtDisposition.Size = new System.Drawing.Size(200, 23);
            txtDisposition.TabIndex = 3;
            // 
            // txtDisinterment
            // 
            txtDisinterment.Location = new System.Drawing.Point(99, 74);
            txtDisinterment.Name = "txtDisinterment";
            txtDisinterment.Size = new System.Drawing.Size(200, 23);
            txtDisinterment.TabIndex = 3;
            // 
            // txtCemetery
            // 
            txtCemetery.Location = new System.Drawing.Point(99, 45);
            txtCemetery.Name = "txtCemetery";
            txtCemetery.Size = new System.Drawing.Size(200, 23);
            txtCemetery.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucBurialPermit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ucBurialPermit";
            Size = new System.Drawing.Size(946, 247);
            Load += ucBurialPermit_Load;
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRemainsAge).EndInit();
            groupBox3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.NumericUpDown nudRemainsAge;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox txtPermission;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtPayer;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox txtRemainsNationality;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtRemainsName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbxRemainsSex;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.DateTimePicker dtpDeathDate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtCemetery;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtDisposition;
        internal System.Windows.Forms.TextBox txtDisinterment;
        internal System.Windows.Forms.CheckBox cbxIsEmbalbed;
        internal System.Windows.Forms.CheckBox cbxIsInfectious;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtCauseOfDeath;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
