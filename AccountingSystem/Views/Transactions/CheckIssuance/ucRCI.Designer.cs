
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
            this.txtfunction = new System.Windows.Forms.TextBox();
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
            this.dgObligationNoList = new System.Windows.Forms.DataGridView();
            this.obligation_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.options = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationNoList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fund";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "FPP";
            // 
            // txtfunction
            // 
            this.errorProvider.SetIconAlignment(this.txtfunction, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtfunction.Location = new System.Drawing.Point(142, 150);
            this.txtfunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfunction.Name = "txtfunction";
            this.txtfunction.ReadOnly = true;
            this.txtfunction.Size = new System.Drawing.Size(501, 23);
            this.txtfunction.TabIndex = 4;
            this.txtfunction.DoubleClick += new System.EventHandler(this.txtfunction_DoubleClick);
            this.txtfunction.Validating += new System.ComponentModel.CancelEventHandler(this.txtfunction_Validating);
            this.txtfunction.Validated += new System.EventHandler(this.txtfunction_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Check No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Check Date";
            // 
            // txtcheckno
            // 
            this.txtcheckno.Location = new System.Drawing.Point(142, 114);
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
            this.dtcheckdate.Location = new System.Drawing.Point(142, 182);
            this.dtcheckdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtcheckdate.Name = "dtcheckdate";
            this.dtcheckdate.Size = new System.Drawing.Size(501, 23);
            this.dtcheckdate.TabIndex = 5;
            this.dtcheckdate.Validating += new System.ComponentModel.CancelEventHandler(this.dtcheckdate_Validating);
            this.dtcheckdate.Validated += new System.EventHandler(this.dtcheckdate_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Obligation No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "DV No. ";
            // 
            // txtdvno
            // 
            this.txtdvno.Location = new System.Drawing.Point(142, 18);
            this.txtdvno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdvno.MaxLength = 20;
            this.txtdvno.Name = "txtdvno";
            this.txtdvno.Size = new System.Drawing.Size(162, 23);
            this.txtdvno.TabIndex = 1;
            this.txtdvno.Validating += new System.ComponentModel.CancelEventHandler(this.txtdvno_Validating);
            this.txtdvno.Validated += new System.EventHandler(this.txtdvno_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Payee";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nature of Payment";
            // 
            // txtpayee
            // 
            this.txtpayee.Location = new System.Drawing.Point(142, 214);
            this.txtpayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpayee.MaxLength = 150;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(501, 23);
            this.txtpayee.TabIndex = 7;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtnature
            // 
            this.txtnature.Location = new System.Drawing.Point(142, 246);
            this.txtnature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnature.MaxLength = 150;
            this.txtnature.Multiline = true;
            this.txtnature.Name = "txtnature";
            this.txtnature.Size = new System.Drawing.Size(501, 67);
            this.txtnature.TabIndex = 8;
            this.txtnature.Validating += new System.ComponentModel.CancelEventHandler(this.txtnature_Validating);
            this.txtnature.Validated += new System.EventHandler(this.txtnature_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Amount";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(142, 322);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(501, 23);
            this.txtamount.TabIndex = 9;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(142, 50);
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
            this.cmbbank.Location = new System.Drawing.Point(142, 82);
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
            this.txtObno.Location = new System.Drawing.Point(416, 18);
            this.txtObno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(146, 23);
            this.txtObno.TabIndex = 1;
            this.txtObno.TextChanged += new System.EventHandler(this.txtObno_TextChanged);
            // 
            // dgObligationNoList
            // 
            this.dgObligationNoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgObligationNoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationNoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.obligation_no,
            this.options});
            this.dgObligationNoList.Location = new System.Drawing.Point(416, 50);
            this.dgObligationNoList.MultiSelect = false;
            this.dgObligationNoList.Name = "dgObligationNoList";
            this.dgObligationNoList.RowTemplate.Height = 25;
            this.dgObligationNoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgObligationNoList.Size = new System.Drawing.Size(227, 87);
            this.dgObligationNoList.TabIndex = 3;
            this.dgObligationNoList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgObligationNoList_CellContentClick);
            // 
            // obligation_no
            // 
            this.obligation_no.HeaderText = "Obligation No.";
            this.obligation_no.Name = "obligation_no";
            this.obligation_no.Width = 140;
            // 
            // options
            // 
            this.options.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.options.FillWeight = 50F;
            this.options.HeaderText = "";
            this.options.Name = "options";
            this.options.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.options.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(568, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucRCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgObligationNoList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtObno);
            this.Controls.Add(this.cmbbank);
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtnature);
            this.Controls.Add(this.txtpayee);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtdvno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtcheckdate);
            this.Controls.Add(this.txtcheckno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtfunction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucRCI";
            this.Size = new System.Drawing.Size(671, 354);
            this.Load += new System.EventHandler(this.ucRCI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationNoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        internal System.Windows.Forms.TextBox txtfunction;
        internal System.Windows.Forms.TextBox txtcheckno;
        internal System.Windows.Forms.DateTimePicker dtcheckdate;
        internal System.Windows.Forms.TextBox txtdvno;
        internal System.Windows.Forms.TextBox txtpayee;
        internal System.Windows.Forms.TextBox txtnature;
        internal System.Windows.Forms.NumericUpDown txtamount;
        internal System.Windows.Forms.ComboBox cmbbank;
        internal System.Windows.Forms.ComboBox cmbfund;
        internal System.Windows.Forms.ComboBox txtObno;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn obligation_no;
        private System.Windows.Forms.DataGridViewButtonColumn options;
        internal System.Windows.Forms.DataGridView dgObligationNoList;
    }
}
