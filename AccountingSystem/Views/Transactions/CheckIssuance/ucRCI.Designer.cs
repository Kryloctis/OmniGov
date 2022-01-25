
namespace AccountingSystem.Views.Transactions.RCI
{
    partial class ucRCI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcheckno = new System.Windows.Forms.TextBox();
            this.dtcheckdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdvno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpayee = new System.Windows.Forms.TextBox();
            this.txtnature = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.cmbbank = new System.Windows.Forms.ComboBox();
            this.txtObno = new System.Windows.Forms.ComboBox();
            this.btnAddObligation = new System.Windows.Forms.Button();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddDeductions = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fund";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "FPP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Check No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Check Date";
            // 
            // txtcheckno
            // 
            this.txtcheckno.Location = new System.Drawing.Point(137, 134);
            this.txtcheckno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcheckno.MaxLength = 15;
            this.txtcheckno.Name = "txtcheckno";
            this.txtcheckno.Size = new System.Drawing.Size(254, 23);
            this.txtcheckno.TabIndex = 3;
            this.txtcheckno.Validating += new System.ComponentModel.CancelEventHandler(this.txtcheckno_Validating);
            this.txtcheckno.Validated += new System.EventHandler(this.txtcheckno_Validated);
            // 
            // dtcheckdate
            // 
            this.dtcheckdate.Location = new System.Drawing.Point(137, 194);
            this.dtcheckdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtcheckdate.Name = "dtcheckdate";
            this.dtcheckdate.Size = new System.Drawing.Size(254, 23);
            this.dtcheckdate.TabIndex = 5;
            this.dtcheckdate.Validating += new System.ComponentModel.CancelEventHandler(this.dtcheckdate_Validating);
            this.dtcheckdate.Validated += new System.EventHandler(this.dtcheckdate_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Obligation No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "DV No. ";
            // 
            // txtdvno
            // 
            this.txtdvno.Location = new System.Drawing.Point(137, 43);
            this.txtdvno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdvno.MaxLength = 20;
            this.txtdvno.Name = "txtdvno";
            this.txtdvno.Size = new System.Drawing.Size(254, 23);
            this.txtdvno.TabIndex = 1;
            this.txtdvno.Validating += new System.ComponentModel.CancelEventHandler(this.txtdvno_Validating);
            this.txtdvno.Validated += new System.EventHandler(this.txtdvno_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Payee";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nature of Payment";
            // 
            // txtpayee
            // 
            this.txtpayee.Location = new System.Drawing.Point(137, 224);
            this.txtpayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpayee.MaxLength = 150;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(254, 23);
            this.txtpayee.TabIndex = 7;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtnature
            // 
            this.txtnature.Location = new System.Drawing.Point(137, 253);
            this.txtnature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnature.MaxLength = 150;
            this.txtnature.Multiline = true;
            this.txtnature.Name = "txtnature";
            this.txtnature.Size = new System.Drawing.Size(254, 67);
            this.txtnature.TabIndex = 8;
            this.txtnature.Validating += new System.ComponentModel.CancelEventHandler(this.txtnature_Validating);
            this.txtnature.Validated += new System.EventHandler(this.txtnature_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Net Amount";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(137, 359);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(254, 23);
            this.txtamount.TabIndex = 9;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(137, 73);
            this.cmbfund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(254, 23);
            this.cmbfund.TabIndex = 2;
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // cmbbank
            // 
            this.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbank.FormattingEnabled = true;
            this.cmbbank.Location = new System.Drawing.Point(137, 104);
            this.cmbbank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbank.Name = "cmbbank";
            this.cmbbank.Size = new System.Drawing.Size(254, 23);
            this.cmbbank.TabIndex = 2;
            this.cmbbank.Validating += new System.ComponentModel.CancelEventHandler(this.cmbbank_Validating);
            this.cmbbank.Validated += new System.EventHandler(this.cmbbank_Validated);
            // 
            // txtObno
            // 
            this.txtObno.FormattingEnabled = true;
            this.txtObno.Location = new System.Drawing.Point(137, 14);
            this.txtObno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(223, 23);
            this.txtObno.TabIndex = 1;
            this.txtObno.TextChanged += new System.EventHandler(this.txtObno_TextChanged);
            // 
            // btnAddObligation
            // 
            this.btnAddObligation.Location = new System.Drawing.Point(366, 14);
            this.btnAddObligation.Name = "btnAddObligation";
            this.btnAddObligation.Size = new System.Drawing.Size(25, 23);
            this.btnAddObligation.TabIndex = 2;
            this.btnAddObligation.Text = "...";
            this.btnAddObligation.UseVisualStyleBackColor = true;
            this.btnAddObligation.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(137, 163);
            this.cmbFPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(254, 23);
            this.cmbFPP.TabIndex = 26;
            this.cmbFPP.SelectedValueChanged += new System.EventHandler(this.cmbFPP_SelectedValueChanged);
            this.cmbFPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFPP_KeyDown);
            this.cmbFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFPP_Validating_1);
            this.cmbFPP.Validated += new System.EventHandler(this.cmbFPP_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddDeductions);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtObno);
            this.groupBox2.Controls.Add(this.cmbFPP);
            this.groupBox2.Controls.Add(this.txtdvno);
            this.groupBox2.Controls.Add(this.txtamount);
            this.groupBox2.Controls.Add(this.txtnature);
            this.groupBox2.Controls.Add(this.cmbbank);
            this.groupBox2.Controls.Add(this.txtpayee);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtcheckdate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtcheckno);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbfund);
            this.groupBox2.Controls.Add(this.btnAddObligation);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 388);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnAddDeductions
            // 
            this.btnAddDeductions.Location = new System.Drawing.Point(366, 327);
            this.btnAddDeductions.Name = "btnAddDeductions";
            this.btnAddDeductions.Size = new System.Drawing.Size(25, 23);
            this.btnAddDeductions.TabIndex = 29;
            this.btnAddDeductions.Text = "...";
            this.btnAddDeductions.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(137, 327);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(223, 23);
            this.numericUpDown1.TabIndex = 29;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Total Deductions";
            // 
            // ucRCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucRCI";
            this.Size = new System.Drawing.Size(422, 395);
            this.Load += new System.EventHandler(this.ucRCI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.TextBox txtcheckno;
        internal System.Windows.Forms.DateTimePicker dtcheckdate;
        internal System.Windows.Forms.TextBox txtdvno;
        internal System.Windows.Forms.TextBox txtpayee;
        internal System.Windows.Forms.TextBox txtnature;
        internal System.Windows.Forms.NumericUpDown txtamount;
        internal System.Windows.Forms.ComboBox cmbbank;
        internal System.Windows.Forms.ComboBox cmbfund;
        internal System.Windows.Forms.ComboBox txtObno;
        private System.Windows.Forms.Button btnAddObligation;
        internal System.Windows.Forms.ComboBox cmbFPP;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddDeductions;
    }
}
