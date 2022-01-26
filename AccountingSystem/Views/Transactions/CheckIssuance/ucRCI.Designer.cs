
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
            this.epObligations = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddDeductions = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObno = new System.Windows.Forms.ComboBox();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.txtdvno = new System.Windows.Forms.TextBox();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.txtnature = new System.Windows.Forms.TextBox();
            this.cmbbank = new System.Windows.Forms.ComboBox();
            this.txtpayee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtcheckdate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcheckno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.btnAddObligation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epDVNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epBank = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCheckNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFpp = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCheckDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNatureOfPayment = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTotalDeductions = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNetAmount = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epObligations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDVNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNatureOfPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTotalDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNetAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // epObligations
            // 
            this.epObligations.ContainerControl = this;
            // 
            // btnAddDeductions
            // 
            this.btnAddDeductions.Image = global::AccountingSystem.Properties.Resources.others;
            this.btnAddDeductions.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddDeductions.Location = new System.Drawing.Point(395, 309);
            this.btnAddDeductions.Name = "btnAddDeductions";
            this.btnAddDeductions.Size = new System.Drawing.Size(25, 23);
            this.btnAddDeductions.TabIndex = 53;
            this.btnAddDeductions.UseVisualStyleBackColor = true;
            this.btnAddDeductions.Click += new System.EventHandler(this.btnAddDeductions_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(133, 309);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(254, 23);
            this.numericUpDown1.TabIndex = 52;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 54;
            this.label10.Text = "Total Deductions";
            // 
            // txtObno
            // 
            this.txtObno.FormattingEnabled = true;
            this.txtObno.Location = new System.Drawing.Point(133, 12);
            this.txtObno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(254, 23);
            this.txtObno.TabIndex = 32;
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(133, 152);
            this.cmbFPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(254, 23);
            this.cmbFPP.TabIndex = 51;
            // 
            // txtdvno
            // 
            this.txtdvno.Location = new System.Drawing.Point(133, 40);
            this.txtdvno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdvno.MaxLength = 20;
            this.txtdvno.Name = "txtdvno";
            this.txtdvno.Size = new System.Drawing.Size(254, 23);
            this.txtdvno.TabIndex = 33;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(133, 337);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(254, 23);
            this.txtamount.TabIndex = 43;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnature
            // 
            this.txtnature.Location = new System.Drawing.Point(133, 236);
            this.txtnature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnature.MaxLength = 150;
            this.txtnature.Multiline = true;
            this.txtnature.Name = "txtnature";
            this.txtnature.Size = new System.Drawing.Size(254, 67);
            this.txtnature.TabIndex = 42;
            // 
            // cmbbank
            // 
            this.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbank.FormattingEnabled = true;
            this.cmbbank.Location = new System.Drawing.Point(133, 96);
            this.cmbbank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbank.Name = "cmbbank";
            this.cmbbank.Size = new System.Drawing.Size(254, 23);
            this.cmbbank.TabIndex = 34;
            // 
            // txtpayee
            // 
            this.txtpayee.Location = new System.Drawing.Point(133, 208);
            this.txtpayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpayee.MaxLength = 150;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(254, 23);
            this.txtpayee.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Obligation No.";
            // 
            // dtcheckdate
            // 
            this.dtcheckdate.Location = new System.Drawing.Point(133, 180);
            this.dtcheckdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtcheckdate.Name = "dtcheckdate";
            this.dtcheckdate.Size = new System.Drawing.Size(254, 23);
            this.dtcheckdate.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "DV No. ";
            // 
            // txtcheckno
            // 
            this.txtcheckno.Location = new System.Drawing.Point(133, 124);
            this.txtcheckno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcheckno.MaxLength = 15;
            this.txtcheckno.Name = "txtcheckno";
            this.txtcheckno.Size = new System.Drawing.Size(254, 23);
            this.txtcheckno.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 50;
            this.label12.Text = "Net Amount";
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(133, 68);
            this.cmbfund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(254, 23);
            this.cmbfund.TabIndex = 36;
            // 
            // btnAddObligation
            // 
            this.btnAddObligation.Image = global::AccountingSystem.Properties.Resources.others;
            this.btnAddObligation.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddObligation.Location = new System.Drawing.Point(395, 12);
            this.btnAddObligation.Name = "btnAddObligation";
            this.btnAddObligation.Size = new System.Drawing.Size(25, 23);
            this.btnAddObligation.TabIndex = 35;
            this.btnAddObligation.UseVisualStyleBackColor = true;
            this.btnAddObligation.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Fund";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 49;
            this.label9.Text = "Nature of Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Bank";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 48;
            this.label8.Text = "Payee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "FPP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Check No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Check Date";
            // 
            // epDVNo
            // 
            this.epDVNo.ContainerControl = this;
            // 
            // epFund
            // 
            this.epFund.ContainerControl = this;
            // 
            // epBank
            // 
            this.epBank.ContainerControl = this;
            // 
            // epCheckNo
            // 
            this.epCheckNo.ContainerControl = this;
            // 
            // epFpp
            // 
            this.epFpp.ContainerControl = this;
            // 
            // epCheckDate
            // 
            this.epCheckDate.ContainerControl = this;
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // epNatureOfPayment
            // 
            this.epNatureOfPayment.ContainerControl = this;
            // 
            // epTotalDeductions
            // 
            this.epTotalDeductions.ContainerControl = this;
            // 
            // epNetAmount
            // 
            this.epNetAmount.ContainerControl = this;
            // 
            // ucRCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddDeductions);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtObno);
            this.Controls.Add(this.cmbFPP);
            this.Controls.Add(this.txtdvno);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.txtnature);
            this.Controls.Add(this.cmbbank);
            this.Controls.Add(this.txtpayee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtcheckdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcheckno);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.btnAddObligation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucRCI";
            this.Size = new System.Drawing.Size(427, 370);
            this.Load += new System.EventHandler(this.ucRCI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epObligations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDVNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNatureOfPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTotalDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNetAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epObligations;
        private System.Windows.Forms.Button btnAddDeductions;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox txtObno;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.TextBox txtdvno;
        internal System.Windows.Forms.NumericUpDown txtamount;
        internal System.Windows.Forms.TextBox txtnature;
        internal System.Windows.Forms.ComboBox cmbbank;
        internal System.Windows.Forms.TextBox txtpayee;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtcheckdate;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtcheckno;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbfund;
        private System.Windows.Forms.Button btnAddObligation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epDVNo;
        private System.Windows.Forms.ErrorProvider epFund;
        private System.Windows.Forms.ErrorProvider epBank;
        private System.Windows.Forms.ErrorProvider epCheckNo;
        private System.Windows.Forms.ErrorProvider epFpp;
        private System.Windows.Forms.ErrorProvider epCheckDate;
        private System.Windows.Forms.ErrorProvider epPayee;
        private System.Windows.Forms.ErrorProvider epNatureOfPayment;
        private System.Windows.Forms.ErrorProvider epTotalDeductions;
        private System.Windows.Forms.ErrorProvider epNetAmount;
    }
}
