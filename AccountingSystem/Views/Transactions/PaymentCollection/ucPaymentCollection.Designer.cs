
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
            this.txtpayee = new System.Windows.Forms.TextBox();
            this.txtreceipt = new System.Windows.Forms.TextBox();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbcollector = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbforms = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPaymentType = new System.Windows.Forms.TabControl();
            this.tabNonCashTickets = new System.Windows.Forms.TabPage();
            this.tabCashTickets = new System.Windows.Forms.TabPage();
            this.nudCashTicketAmount = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.dtCashTicketDateOfCollection = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCashTicketQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPaymentType.SuspendLayout();
            this.tabNonCashTickets.SuspendLayout();
            this.tabCashTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCashTicketAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Abstract of General Collection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "OR/Serial Number ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of Collection ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount";
            // 
            // txtpayee
            // 
            this.txtpayee.Location = new System.Drawing.Point(174, 76);
            this.txtpayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpayee.MaxLength = 200;
            this.txtpayee.Multiline = true;
            this.txtpayee.Name = "txtpayee";
            this.txtpayee.Size = new System.Drawing.Size(296, 46);
            this.txtpayee.TabIndex = 4;
            this.txtpayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtpayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtreceipt
            // 
            this.txtreceipt.Location = new System.Drawing.Point(174, 45);
            this.txtreceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtreceipt.MaxLength = 20;
            this.txtreceipt.Name = "txtreceipt";
            this.txtreceipt.Size = new System.Drawing.Size(296, 23);
            this.txtreceipt.TabIndex = 5;
            this.txtreceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtreceipt_KeyPress);
            this.txtreceipt.Validating += new System.ComponentModel.CancelEventHandler(this.txtreceipt_Validating);
            this.txtreceipt.Validated += new System.EventHandler(this.txtreceipt_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Enabled = false;
            this.dtdate.Location = new System.Drawing.Point(174, 12);
            this.dtdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(296, 23);
            this.dtdate.TabIndex = 6;
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(173, 128);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(297, 23);
            this.txtamount.TabIndex = 7;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtamount.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Collecting Officer";
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(181, 16);
            this.cmbcollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(297, 23);
            this.cmbcollector.TabIndex = 0;
            this.cmbcollector.SelectedIndexChanged += new System.EventHandler(this.cmbcollector_SelectedIndexChanged);
            this.cmbcollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbcollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cmbforms
            // 
            this.cmbforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbforms.FormattingEnabled = true;
            this.cmbforms.Location = new System.Drawing.Point(181, 80);
            this.cmbforms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbforms.Name = "cmbforms";
            this.cmbforms.Size = new System.Drawing.Size(297, 23);
            this.cmbforms.TabIndex = 19;
            this.cmbforms.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbforms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbforms_Validating);
            this.cmbforms.Validated += new System.EventHandler(this.cmbforms_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAccount);
            this.groupBox1.Controls.Add(this.cmbfund);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbforms);
            this.groupBox1.Controls.Add(this.cmbcollector);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 145);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(181, 114);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(297, 23);
            this.cmbAccount.TabIndex = 24;
            this.cmbAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccount_KeyDown);
            // 
            // cmbfund
            // 
            this.cmbfund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(181, 48);
            this.cmbfund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(297, 23);
            this.cmbfund.TabIndex = 23;
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fund";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabPaymentType);
            this.groupBox2.Location = new System.Drawing.Point(3, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 196);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // tabPaymentType
            // 
            this.tabPaymentType.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabPaymentType.Controls.Add(this.tabNonCashTickets);
            this.tabPaymentType.Controls.Add(this.tabCashTickets);
            this.tabPaymentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaymentType.ItemSize = new System.Drawing.Size(0, 1);
            this.tabPaymentType.Location = new System.Drawing.Point(3, 19);
            this.tabPaymentType.Name = "tabPaymentType";
            this.tabPaymentType.SelectedIndex = 0;
            this.tabPaymentType.Size = new System.Drawing.Size(497, 174);
            this.tabPaymentType.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPaymentType.TabIndex = 24;
            // 
            // tabNonCashTickets
            // 
            this.tabNonCashTickets.BackColor = System.Drawing.SystemColors.Control;
            this.tabNonCashTickets.Controls.Add(this.label3);
            this.tabNonCashTickets.Controls.Add(this.dtdate);
            this.tabNonCashTickets.Controls.Add(this.txtamount);
            this.tabNonCashTickets.Controls.Add(this.txtreceipt);
            this.tabNonCashTickets.Controls.Add(this.label6);
            this.tabNonCashTickets.Controls.Add(this.label4);
            this.tabNonCashTickets.Controls.Add(this.txtpayee);
            this.tabNonCashTickets.Controls.Add(this.label5);
            this.tabNonCashTickets.Location = new System.Drawing.Point(4, 5);
            this.tabNonCashTickets.Name = "tabNonCashTickets";
            this.tabNonCashTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabNonCashTickets.Size = new System.Drawing.Size(489, 165);
            this.tabNonCashTickets.TabIndex = 0;
            // 
            // tabCashTickets
            // 
            this.tabCashTickets.BackColor = System.Drawing.SystemColors.Control;
            this.tabCashTickets.Controls.Add(this.nudCashTicketAmount);
            this.tabCashTickets.Controls.Add(this.label14);
            this.tabCashTickets.Controls.Add(this.dtCashTicketDateOfCollection);
            this.tabCashTickets.Controls.Add(this.label15);
            this.tabCashTickets.Controls.Add(this.label16);
            this.tabCashTickets.Controls.Add(this.txtCashTicketQuantity);
            this.tabCashTickets.Location = new System.Drawing.Point(4, 5);
            this.tabCashTickets.Name = "tabCashTickets";
            this.tabCashTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabCashTickets.Size = new System.Drawing.Size(489, 165);
            this.tabCashTickets.TabIndex = 1;
            // 
            // nudCashTicketAmount
            // 
            this.nudCashTicketAmount.DecimalPlaces = 2;
            this.nudCashTicketAmount.Location = new System.Drawing.Point(173, 84);
            this.nudCashTicketAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCashTicketAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudCashTicketAmount.Name = "nudCashTicketAmount";
            this.nudCashTicketAmount.ReadOnly = true;
            this.nudCashTicketAmount.Size = new System.Drawing.Size(297, 23);
            this.nudCashTicketAmount.TabIndex = 15;
            this.nudCashTicketAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCashTicketAmount.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 15);
            this.label14.TabIndex = 12;
            this.label14.Text = "Amount";
            // 
            // dtCashTicketDateOfCollection
            // 
            this.dtCashTicketDateOfCollection.Location = new System.Drawing.Point(174, 18);
            this.dtCashTicketDateOfCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtCashTicketDateOfCollection.Name = "dtCashTicketDateOfCollection";
            this.dtCashTicketDateOfCollection.Size = new System.Drawing.Size(296, 23);
            this.dtCashTicketDateOfCollection.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "Date of Collection ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Cash Tickets Quantity";
            // 
            // txtCashTicketQuantity
            // 
            this.txtCashTicketQuantity.Location = new System.Drawing.Point(174, 51);
            this.txtCashTicketQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCashTicketQuantity.MaxLength = 20;
            this.txtCashTicketQuantity.Name = "txtCashTicketQuantity";
            this.txtCashTicketQuantity.Size = new System.Drawing.Size(296, 23);
            this.txtCashTicketQuantity.TabIndex = 13;
            // 
            // ucPaymentCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucPaymentCollection";
            this.Size = new System.Drawing.Size(510, 341);
            this.Load += new System.EventHandler(this.ucPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPaymentType.ResumeLayout(false);
            this.tabNonCashTickets.ResumeLayout(false);
            this.tabNonCashTickets.PerformLayout();
            this.tabCashTickets.ResumeLayout(false);
            this.tabCashTickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCashTicketAmount)).EndInit();
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
        internal System.Windows.Forms.TextBox txtpayee;
        internal System.Windows.Forms.TextBox txtreceipt;
        internal System.Windows.Forms.DateTimePicker dtdate;
        internal System.Windows.Forms.NumericUpDown txtamount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.ComboBox cmbcollector;
        internal System.Windows.Forms.ComboBox cmbforms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cmbfund;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.TabControl tabPaymentType;
        private System.Windows.Forms.TabPage tabNonCashTickets;
        private System.Windows.Forms.TabPage tabCashTickets;
        internal System.Windows.Forms.NumericUpDown nudCashTicketAmount;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.DateTimePicker dtCashTicketDateOfCollection;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtCashTicketQuantity;
    }
}
