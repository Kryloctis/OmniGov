
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
            this.btnfunction = new System.Windows.Forms.Button();
            this.txtfunction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcheckno = new System.Windows.Forms.TextBox();
            this.dtcheckdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObno = new System.Windows.Forms.TextBox();
            this.txtdvno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpayee = new System.Windows.Forms.TextBox();
            this.txtnature = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txttrust = new System.Windows.Forms.NumericUpDown();
            this.txtvat = new System.Windows.Forms.NumericUpDown();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.cmbbank = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttrust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fund";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "FPP";
            // 
            // btnfunction
            // 
            this.btnfunction.Image = global::AccountingSystem.Properties.Resources.find1;
            this.btnfunction.Location = new System.Drawing.Point(702, 76);
            this.btnfunction.Name = "btnfunction";
            this.btnfunction.Size = new System.Drawing.Size(32, 31);
            this.btnfunction.TabIndex = 8;
            this.btnfunction.UseVisualStyleBackColor = true;
            this.btnfunction.Click += new System.EventHandler(this.btnfunction_Click);
            // 
            // txtfunction
            // 
            this.errorProvider.SetIconAlignment(this.txtfunction, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtfunction.Location = new System.Drawing.Point(161, 76);
            this.txtfunction.Name = "txtfunction";
            this.txtfunction.ReadOnly = true;
            this.txtfunction.Size = new System.Drawing.Size(534, 27);
            this.txtfunction.TabIndex = 3;
            this.txtfunction.DoubleClick += new System.EventHandler(this.txtfunction_DoubleClick);
            this.txtfunction.Validating += new System.ComponentModel.CancelEventHandler(this.txtfunction_Validating);
            this.txtfunction.Validated += new System.EventHandler(this.txtfunction_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Check No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Check Date";
            // 
            // txtcheckno
            // 
            this.txtcheckno.Location = new System.Drawing.Point(161, 143);
            this.txtcheckno.MaxLength = 15;
            this.txtcheckno.Name = "txtcheckno";
            this.txtcheckno.Size = new System.Drawing.Size(222, 27);
            this.txtcheckno.TabIndex = 5;
            this.txtcheckno.Validating += new System.ComponentModel.CancelEventHandler(this.txtcheckno_Validating);
            this.txtcheckno.Validated += new System.EventHandler(this.txtcheckno_Validated);
            // 
            // dtcheckdate
            // 
            this.dtcheckdate.Location = new System.Drawing.Point(483, 143);
            this.dtcheckdate.Name = "dtcheckdate";
            this.dtcheckdate.Size = new System.Drawing.Size(251, 27);
            this.dtcheckdate.TabIndex = 6;
            this.dtcheckdate.Validating += new System.ComponentModel.CancelEventHandler(this.dtcheckdate_Validating);
            this.dtcheckdate.Validated += new System.EventHandler(this.dtcheckdate_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Obligation No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "DV No. ";
            // 
            // txtObno
            // 
            this.txtObno.Location = new System.Drawing.Point(161, 9);
            this.txtObno.MaxLength = 20;
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(222, 27);
            this.txtObno.TabIndex = 0;
            this.txtObno.Validating += new System.ComponentModel.CancelEventHandler(this.txtObno_Validating);
            this.txtObno.Validated += new System.EventHandler(this.txtObno_Validated);
            // 
            // txtdvno
            // 
            this.txtdvno.Location = new System.Drawing.Point(474, 9);
            this.txtdvno.MaxLength = 20;
            this.txtdvno.Name = "txtdvno";
            this.txtdvno.Size = new System.Drawing.Size(260, 27);
            this.txtdvno.TabIndex = 1;
            this.txtdvno.Validating += new System.ComponentModel.CancelEventHandler(this.txtdvno_Validating);
            this.txtdvno.Validated += new System.EventHandler(this.txtdvno_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Payee";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nature of Payment";
            // 
            // txtpayee
            // 
            this.txtpayee.Location = new System.Drawing.Point(161, 179);
            this.txtpayee.MaxLength = 150;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(572, 27);
            this.txtpayee.TabIndex = 7;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtnature
            // 
            this.txtnature.Location = new System.Drawing.Point(161, 215);
            this.txtnature.MaxLength = 150;
            this.txtnature.Multiline = true;
            this.txtnature.Name = "txtnature";
            this.txtnature.Size = new System.Drawing.Size(572, 88);
            this.txtnature.TabIndex = 8;
            this.txtnature.Validating += new System.ComponentModel.CancelEventHandler(this.txtnature_Validating);
            this.txtnature.Validated += new System.EventHandler(this.txtnature_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Trust Liabilities";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 383);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "BIR Vat/Non-Vat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Amount";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txttrust
            // 
            this.txttrust.DecimalPlaces = 2;
            this.txttrust.Location = new System.Drawing.Point(161, 345);
            this.txttrust.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txttrust.Name = "txttrust";
            this.txttrust.Size = new System.Drawing.Size(573, 27);
            this.txttrust.TabIndex = 9;
            this.txttrust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttrust.Validating += new System.ComponentModel.CancelEventHandler(this.txttrust_Validating);
            this.txttrust.Validated += new System.EventHandler(this.txttrust_Validated);
            // 
            // txtvat
            // 
            this.txtvat.DecimalPlaces = 2;
            this.txtvat.Location = new System.Drawing.Point(161, 381);
            this.txtvat.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txtvat.Name = "txtvat";
            this.txtvat.Size = new System.Drawing.Size(573, 27);
            this.txtvat.TabIndex = 10;
            this.txtvat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(161, 309);
            this.txtamount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(573, 27);
            this.txtamount.TabIndex = 11;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(161, 42);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(572, 28);
            this.cmbfund.TabIndex = 26;
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // cmbbank
            // 
            this.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbank.FormattingEnabled = true;
            this.cmbbank.Location = new System.Drawing.Point(161, 109);
            this.cmbbank.Name = "cmbbank";
            this.cmbbank.Size = new System.Drawing.Size(572, 28);
            this.cmbbank.TabIndex = 27;
            this.cmbbank.Validating += new System.ComponentModel.CancelEventHandler(this.cmbbank_Validating);
            this.cmbbank.Validated += new System.EventHandler(this.cmbbank_Validated);
            // 
            // ucRCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbbank);
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.txtvat);
            this.Controls.Add(this.txttrust);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtnature);
            this.Controls.Add(this.txtpayee);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtdvno);
            this.Controls.Add(this.txtObno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtcheckdate);
            this.Controls.Add(this.txtcheckno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnfunction);
            this.Controls.Add(this.txtfunction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucRCI";
            this.Size = new System.Drawing.Size(748, 422);
            this.Load += new System.EventHandler(this.ucRCI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttrust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnfunction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.TextBox txtfunction;
        internal System.Windows.Forms.TextBox txtcheckno;
        internal System.Windows.Forms.DateTimePicker dtcheckdate;
        internal System.Windows.Forms.TextBox txtObno;
        internal System.Windows.Forms.TextBox txtdvno;
        internal System.Windows.Forms.TextBox txtpayee;
        internal System.Windows.Forms.TextBox txtnature;
        internal System.Windows.Forms.NumericUpDown txtamount;
        internal System.Windows.Forms.NumericUpDown txtvat;
        internal System.Windows.Forms.NumericUpDown txttrust;
        internal System.Windows.Forms.ComboBox cmbbank;
        internal System.Windows.Forms.ComboBox cmbfund;
    }
}
