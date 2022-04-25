
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
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.dtDateOfCollection = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.epCollectingOfficer = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbAccountableForms = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCollectorTypeJO = new System.Windows.Forms.CheckBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.cmbFund = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPaymentType = new System.Windows.Forms.TabControl();
            this.tabNonCashTickets = new System.Windows.Forms.TabPage();
            this.tabCashTickets = new System.Windows.Forms.TabPage();
            this.txtCashTicketsAmount = new System.Windows.Forms.NumericUpDown();
            this.txtCashTicketQuantity = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.dtCashTicketDateOfCollection = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.epFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAccountableForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSerialNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAbstractOfGeneralCollection = new System.Windows.Forms.ErrorProvider(this.components);
            this.epORAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCashTicketQuantity = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCashTicketAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epORDateOfCollection = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCashTicketDateOfCollection = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPaymentType.SuspendLayout();
            this.tabNonCashTickets.SuspendLayout();
            this.tabCashTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTicketsAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTicketQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccountableForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSerialNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAbstractOfGeneralCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epORAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epORDateOfCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketDateOfCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Abstract of General Collection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "OR/Serial Number ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of Collection ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(174, 76);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPayee.MaxLength = 200;
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(450, 23);
            this.txtPayee.TabIndex = 6;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Location = new System.Drawing.Point(174, 45);
            this.txtReceiptNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptNumber.MaxLength = 20;
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(450, 23);
            this.txtReceiptNumber.TabIndex = 5;
            this.txtReceiptNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtreceipt_KeyPress);
            this.txtReceiptNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtreceipt_Validating);
            this.txtReceiptNumber.Validated += new System.EventHandler(this.txtreceipt_Validated);
            // 
            // dtDateOfCollection
            // 
            this.dtDateOfCollection.Enabled = false;
            this.dtDateOfCollection.Location = new System.Drawing.Point(174, 12);
            this.dtDateOfCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDateOfCollection.Name = "dtDateOfCollection";
            this.dtDateOfCollection.Size = new System.Drawing.Size(450, 23);
            this.dtDateOfCollection.TabIndex = 4;
            this.dtDateOfCollection.Validating += new System.ComponentModel.CancelEventHandler(this.dtDateOfCollection_Validation);
            this.dtDateOfCollection.Validated += new System.EventHandler(this.dtDateOfCollection_Validated);
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Location = new System.Drawing.Point(174, 104);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(451, 23);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.ThousandsSeparator = true;
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            this.txtAmount.Validated += new System.EventHandler(this.txtAmount_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Collecting Officer";
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(181, 34);
            this.cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(450, 23);
            this.cmbCollector.TabIndex = 0;
            this.cmbCollector.SelectedIndexChanged += new System.EventHandler(this.cmbcollector_SelectedIndexChanged);
            this.cmbCollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbCollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // epCollectingOfficer
            // 
            this.epCollectingOfficer.ContainerControl = this;
            // 
            // cmbAccountableForms
            // 
            this.cmbAccountableForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountableForms.FormattingEnabled = true;
            this.cmbAccountableForms.Location = new System.Drawing.Point(181, 98);
            this.cmbAccountableForms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAccountableForms.Name = "cmbAccountableForms";
            this.cmbAccountableForms.Size = new System.Drawing.Size(450, 23);
            this.cmbAccountableForms.TabIndex = 2;
            this.cmbAccountableForms.SelectionChangeCommitted += new System.EventHandler(this.cmbforms_SelectionChangeCommitted);
            this.cmbAccountableForms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAccountableForms_Validating);
            this.cmbAccountableForms.Validated += new System.EventHandler(this.cmbAccountableForms_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCollectorTypeJO);
            this.groupBox1.Controls.Add(this.cmbAccount);
            this.groupBox1.Controls.Add(this.cmbFund);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbAccountableForms);
            this.groupBox1.Controls.Add(this.cmbCollector);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 170);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // cbCollectorTypeJO
            // 
            this.cbCollectorTypeJO.AutoSize = true;
            this.cbCollectorTypeJO.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCollectorTypeJO.Location = new System.Drawing.Point(181, 13);
            this.cbCollectorTypeJO.Name = "cbCollectorTypeJO";
            this.cbCollectorTypeJO.Size = new System.Drawing.Size(85, 17);
            this.cbCollectorTypeJO.TabIndex = 23;
            this.cbCollectorTypeJO.Text = "Job Orders ";
            this.cbCollectorTypeJO.UseVisualStyleBackColor = true;
            this.cbCollectorTypeJO.CheckedChanged += new System.EventHandler(this.cbCollector_CheckedChanged);
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.DropDownHeight = 200;
            this.cmbAccount.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.IntegralHeight = false;
            this.cmbAccount.Location = new System.Drawing.Point(181, 132);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(450, 21);
            this.cmbAccount.TabIndex = 3;
            this.cmbAccount.SelectionChangeCommitted += new System.EventHandler(this.cmbAccount_SelectionChangeCommitted);
            this.cmbAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccount_KeyDown);
            this.cmbAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAccount_Validating);
            this.cmbAccount.Validated += new System.EventHandler(this.cmbAccount_Validated);
            // 
            // cmbFund
            // 
            this.cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFund.FormattingEnabled = true;
            this.cmbFund.Location = new System.Drawing.Point(181, 66);
            this.cmbFund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFund.Name = "cmbFund";
            this.cmbFund.Size = new System.Drawing.Size(450, 23);
            this.cmbFund.TabIndex = 1;
            this.cmbFund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbFund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fund";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabPaymentType);
            this.groupBox2.Location = new System.Drawing.Point(3, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 163);
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
            this.tabPaymentType.Size = new System.Drawing.Size(653, 141);
            this.tabPaymentType.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPaymentType.TabIndex = 24;
            // 
            // tabNonCashTickets
            // 
            this.tabNonCashTickets.BackColor = System.Drawing.SystemColors.Control;
            this.tabNonCashTickets.Controls.Add(this.label3);
            this.tabNonCashTickets.Controls.Add(this.dtDateOfCollection);
            this.tabNonCashTickets.Controls.Add(this.txtAmount);
            this.tabNonCashTickets.Controls.Add(this.txtReceiptNumber);
            this.tabNonCashTickets.Controls.Add(this.label6);
            this.tabNonCashTickets.Controls.Add(this.label4);
            this.tabNonCashTickets.Controls.Add(this.txtPayee);
            this.tabNonCashTickets.Controls.Add(this.label5);
            this.tabNonCashTickets.Location = new System.Drawing.Point(4, 5);
            this.tabNonCashTickets.Name = "tabNonCashTickets";
            this.tabNonCashTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabNonCashTickets.Size = new System.Drawing.Size(645, 132);
            this.tabNonCashTickets.TabIndex = 0;
            // 
            // tabCashTickets
            // 
            this.tabCashTickets.BackColor = System.Drawing.SystemColors.Control;
            this.tabCashTickets.Controls.Add(this.txtCashTicketsAmount);
            this.tabCashTickets.Controls.Add(this.txtCashTicketQuantity);
            this.tabCashTickets.Controls.Add(this.label14);
            this.tabCashTickets.Controls.Add(this.dtCashTicketDateOfCollection);
            this.tabCashTickets.Controls.Add(this.label15);
            this.tabCashTickets.Controls.Add(this.label16);
            this.tabCashTickets.Location = new System.Drawing.Point(4, 5);
            this.tabCashTickets.Name = "tabCashTickets";
            this.tabCashTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabCashTickets.Size = new System.Drawing.Size(645, 132);
            this.tabCashTickets.TabIndex = 1;
            // 
            // txtCashTicketsAmount
            // 
            this.txtCashTicketsAmount.Location = new System.Drawing.Point(174, 86);
            this.txtCashTicketsAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCashTicketsAmount.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.txtCashTicketsAmount.Name = "txtCashTicketsAmount";
            this.txtCashTicketsAmount.Size = new System.Drawing.Size(450, 23);
            this.txtCashTicketsAmount.TabIndex = 13;
            this.txtCashTicketsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashTicketsAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtCashTicketsAmount_Validating);
            this.txtCashTicketsAmount.Validated += new System.EventHandler(this.txtCashTicketsAmount_Validated);
            // 
            // txtCashTicketQuantity
            // 
            this.txtCashTicketQuantity.Location = new System.Drawing.Point(174, 52);
            this.txtCashTicketQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCashTicketQuantity.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.txtCashTicketQuantity.Name = "txtCashTicketQuantity";
            this.txtCashTicketQuantity.Size = new System.Drawing.Size(450, 23);
            this.txtCashTicketQuantity.TabIndex = 5;
            this.txtCashTicketQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashTicketQuantity.ValueChanged += new System.EventHandler(this.txtCashTicketQuantity_ValueChanged);
            this.txtCashTicketQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtCashTicketQuantity_Validating);
            this.txtCashTicketQuantity.Validated += new System.EventHandler(this.txtCashTicketQuantity_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 86);
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
            this.dtCashTicketDateOfCollection.Size = new System.Drawing.Size(450, 23);
            this.dtCashTicketDateOfCollection.TabIndex = 4;
            this.dtCashTicketDateOfCollection.Validating += new System.ComponentModel.CancelEventHandler(this.dtCashTicketDateOfCollection_Validating);
            this.dtCashTicketDateOfCollection.Validated += new System.EventHandler(this.dtCashTicketDateOfCollection_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "Date of Collection ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Cash Tickets Quantity";
            // 
            // epFund
            // 
            this.epFund.ContainerControl = this;
            // 
            // epAccountableForm
            // 
            this.epAccountableForm.ContainerControl = this;
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // epSerialNo
            // 
            this.epSerialNo.ContainerControl = this;
            // 
            // epAbstractOfGeneralCollection
            // 
            this.epAbstractOfGeneralCollection.ContainerControl = this;
            // 
            // epORAmount
            // 
            this.epORAmount.ContainerControl = this;
            // 
            // epCashTicketQuantity
            // 
            this.epCashTicketQuantity.ContainerControl = this;
            // 
            // epCashTicketAmount
            // 
            this.epCashTicketAmount.ContainerControl = this;
            // 
            // epORDateOfCollection
            // 
            this.epORDateOfCollection.ContainerControl = this;
            // 
            // epCashTicketDateOfCollection
            // 
            this.epCashTicketDateOfCollection.ContainerControl = this;
            // 
            // ucPaymentCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucPaymentCollection";
            this.Size = new System.Drawing.Size(665, 339);
            this.Load += new System.EventHandler(this.ucPaymentCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPaymentType.ResumeLayout(false);
            this.tabNonCashTickets.ResumeLayout(false);
            this.tabNonCashTickets.PerformLayout();
            this.tabCashTickets.ResumeLayout(false);
            this.tabCashTickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTicketsAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTicketQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccountableForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSerialNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAbstractOfGeneralCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epORAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epORDateOfCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCashTicketDateOfCollection)).EndInit();
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
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtReceiptNumber;
        internal System.Windows.Forms.DateTimePicker dtDateOfCollection;
        internal System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.ErrorProvider epCollectingOfficer;
        internal System.Windows.Forms.ComboBox cmbCollector;
        internal System.Windows.Forms.ComboBox cmbAccountableForms;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cmbFund;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.TabControl tabPaymentType;
        private System.Windows.Forms.TabPage tabNonCashTickets;
        private System.Windows.Forms.TabPage tabCashTickets;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.DateTimePicker dtCashTicketDateOfCollection;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.NumericUpDown txtCashTicketQuantity;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.NumericUpDown txtCashTicketsAmount;
        private System.Windows.Forms.ErrorProvider epFund;
        private System.Windows.Forms.ErrorProvider epAccountableForm;
        private System.Windows.Forms.ErrorProvider epPayee;
        private System.Windows.Forms.ErrorProvider epSerialNo;
        private System.Windows.Forms.ErrorProvider epAbstractOfGeneralCollection;
        private System.Windows.Forms.ErrorProvider epORAmount;
        private System.Windows.Forms.ErrorProvider epCashTicketQuantity;
        private System.Windows.Forms.ErrorProvider epCashTicketAmount;
        private System.Windows.Forms.ErrorProvider epORDateOfCollection;
        private System.Windows.Forms.ErrorProvider epCashTicketDateOfCollection;
        internal System.Windows.Forms.CheckBox cbCollectorTypeJO;
    }
}
