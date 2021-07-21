
namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    partial class ucPC
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtledger = new System.Windows.Forms.TextBox();
            this.txtpayee = new System.Windows.Forms.TextBox();
            this.txtreceipt = new System.Windows.Forms.TextBox();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbcollector = new System.Windows.Forms.ComboBox();
            this.btnledger = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbforms = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.cmbsubsidiary = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "General Ledger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Receipt No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount";
            // 
            // txtledger
            // 
            this.txtledger.Enabled = false;
            this.errorProvider.SetIconAlignment(this.txtledger, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtledger.Location = new System.Drawing.Point(161, 111);
            this.txtledger.Name = "txtledger";
            this.txtledger.ReadOnly = true;
            this.txtledger.Size = new System.Drawing.Size(506, 27);
            this.txtledger.TabIndex = 2;
            this.txtledger.TextChanged += new System.EventHandler(this.txtledger_TextChanged);
            this.txtledger.DoubleClick += new System.EventHandler(this.txtledger_DoubleClick);
            this.txtledger.Validating += new System.ComponentModel.CancelEventHandler(this.txtledger_Validating);
            this.txtledger.Validated += new System.EventHandler(this.txtledger_Validated);
            // 
            // txtpayee
            // 
            this.txtpayee.Enabled = false;
            this.txtpayee.Location = new System.Drawing.Point(161, 183);
            this.txtpayee.MaxLength = 200;
            this.txtpayee.Multiline = true;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(546, 95);
            this.txtpayee.TabIndex = 4;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtreceipt
            // 
            this.txtreceipt.Enabled = false;
            this.txtreceipt.Location = new System.Drawing.Point(161, 284);
            this.txtreceipt.MaxLength = 20;
            this.txtreceipt.Name = "txtreceipt";
            this.txtreceipt.ReadOnly = true;
            this.txtreceipt.Size = new System.Drawing.Size(212, 27);
            this.txtreceipt.TabIndex = 5;
            this.txtreceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtreceipt_KeyPress);
            this.txtreceipt.Validating += new System.ComponentModel.CancelEventHandler(this.txtreceipt_Validating);
            this.txtreceipt.Validated += new System.EventHandler(this.txtreceipt_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Enabled = false;
            this.dtdate.Location = new System.Drawing.Point(454, 284);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(253, 27);
            this.dtdate.TabIndex = 6;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Enabled = false;
            this.txtamount.Location = new System.Drawing.Point(161, 320);
            this.txtamount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(546, 27);
            this.txtamount.TabIndex = 7;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtamount.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Collecting Officer";
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(161, 3);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(546, 28);
            this.cmbcollector.TabIndex = 0;
            this.cmbcollector.SelectedIndexChanged += new System.EventHandler(this.cmbcollector_SelectedIndexChanged);
            this.cmbcollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbcollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // btnledger
            // 
            this.btnledger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnledger.Enabled = false;
            this.btnledger.Image = global::AccountingSystem.Properties.Resources.find1;
            this.btnledger.Location = new System.Drawing.Point(673, 109);
            this.btnledger.Name = "btnledger";
            this.btnledger.Size = new System.Drawing.Size(34, 31);
            this.btnledger.TabIndex = 15;
            this.btnledger.UseVisualStyleBackColor = true;
            this.btnledger.Click += new System.EventHandler(this.btnledger_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Subsidiary";
            // 
            // cmbforms
            // 
            this.cmbforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbforms.FormattingEnabled = true;
            this.cmbforms.Location = new System.Drawing.Point(161, 75);
            this.cmbforms.Name = "cmbforms";
            this.cmbforms.Size = new System.Drawing.Size(546, 28);
            this.cmbforms.TabIndex = 19;
            this.cmbforms.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbforms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbforms_Validating);
            this.cmbforms.Validated += new System.EventHandler(this.cmbforms_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Fund";
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(161, 39);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(546, 28);
            this.cmbfund.TabIndex = 21;
            this.cmbfund.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // cmbsubsidiary
            // 
            this.cmbsubsidiary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsubsidiary.FormattingEnabled = true;
            this.cmbsubsidiary.Location = new System.Drawing.Point(161, 147);
            this.cmbsubsidiary.Name = "cmbsubsidiary";
            this.cmbsubsidiary.Size = new System.Drawing.Size(546, 28);
            this.cmbsubsidiary.TabIndex = 22;
            this.cmbsubsidiary.Validating += new System.ComponentModel.CancelEventHandler(this.cmbsubsidiary_Validating);
            this.cmbsubsidiary.Validated += new System.EventHandler(this.cmbsubsidiary_Validated);
            // 
            // ucPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbsubsidiary);
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbforms);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnledger);
            this.Controls.Add(this.cmbcollector);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.txtreceipt);
            this.Controls.Add(this.txtpayee);
            this.Controls.Add(this.txtledger);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucPC";
            this.Size = new System.Drawing.Size(734, 361);
            this.Load += new System.EventHandler(this.ucPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.Button btnledger;
        internal System.Windows.Forms.TextBox txtledger;
        internal System.Windows.Forms.TextBox txtpayee;
        internal System.Windows.Forms.TextBox txtreceipt;
        internal System.Windows.Forms.DateTimePicker dtdate;
        internal System.Windows.Forms.NumericUpDown txtamount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.ComboBox cmbcollector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cmbfund;
        internal System.Windows.Forms.ComboBox cmbforms;
        internal System.Windows.Forms.ComboBox cmbsubsidiary;
    }
}
