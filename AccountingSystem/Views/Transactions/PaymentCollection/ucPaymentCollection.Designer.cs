
namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    partial class ucPaymentCollection
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
            this.cmbforms = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Abstract of General Collection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payee";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Receipt No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of Collection ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount";
            // 
            // txtledger
            // 
            this.txtledger.Enabled = false;
            this.errorProvider.SetIconAlignment(this.txtledger, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtledger.Location = new System.Drawing.Point(175, 83);
            this.txtledger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtledger.Name = "txtledger";
            this.txtledger.ReadOnly = true;
            this.txtledger.Size = new System.Drawing.Size(443, 23);
            this.txtledger.TabIndex = 2;
            this.txtledger.TextChanged += new System.EventHandler(this.txtledger_TextChanged);
            this.txtledger.DoubleClick += new System.EventHandler(this.txtledger_DoubleClick);
            this.txtledger.Validating += new System.ComponentModel.CancelEventHandler(this.txtledger_Validating);
            this.txtledger.Validated += new System.EventHandler(this.txtledger_Validated);
            // 
            // txtpayee
            // 
            this.txtpayee.Enabled = false;
            this.txtpayee.Location = new System.Drawing.Point(175, 110);
            this.txtpayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpayee.MaxLength = 200;
            this.txtpayee.Multiline = true;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(478, 46);
            this.txtpayee.TabIndex = 4;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtreceipt
            // 
            this.txtreceipt.Enabled = false;
            this.txtreceipt.Location = new System.Drawing.Point(175, 160);
            this.txtreceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtreceipt.MaxLength = 20;
            this.txtreceipt.Name = "txtreceipt";
            this.txtreceipt.ReadOnly = true;
            this.txtreceipt.Size = new System.Drawing.Size(186, 23);
            this.txtreceipt.TabIndex = 5;
            this.txtreceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtreceipt_KeyPress);
            this.txtreceipt.Validating += new System.ComponentModel.CancelEventHandler(this.txtreceipt_Validating);
            this.txtreceipt.Validated += new System.EventHandler(this.txtreceipt_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Enabled = false;
            this.dtdate.Location = new System.Drawing.Point(478, 163);
            this.dtdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(175, 23);
            this.dtdate.TabIndex = 6;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Enabled = false;
            this.txtamount.Location = new System.Drawing.Point(175, 190);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(478, 23);
            this.txtamount.TabIndex = 7;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtamount.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Collecting Officer";
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(175, 2);
            this.cmbcollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(478, 23);
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
            this.btnledger.Location = new System.Drawing.Point(623, 82);
            this.btnledger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnledger.Name = "btnledger";
            this.btnledger.Size = new System.Drawing.Size(30, 23);
            this.btnledger.TabIndex = 15;
            this.btnledger.UseVisualStyleBackColor = true;
            this.btnledger.Click += new System.EventHandler(this.btnledger_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cmbforms
            // 
            this.cmbforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbforms.FormattingEnabled = true;
            this.cmbforms.Location = new System.Drawing.Point(175, 56);
            this.cmbforms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbforms.Name = "cmbforms";
            this.cmbforms.Size = new System.Drawing.Size(478, 23);
            this.cmbforms.TabIndex = 19;
            this.cmbforms.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbforms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbforms_Validating);
            this.cmbforms.Validated += new System.EventHandler(this.cmbforms_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Fund";
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(175, 29);
            this.cmbfund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(478, 23);
            this.cmbfund.TabIndex = 21;
            this.cmbfund.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // ucPaymentCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbforms);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucPaymentCollection";
            this.Size = new System.Drawing.Size(679, 218);
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
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cmbfund;
        internal System.Windows.Forms.ComboBox cmbforms;
    }
}
