namespace AccountingSystem.Views.Transactions.Payments
{
    partial class ucPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpBxChequeDetails = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgCheques = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.radPaymentCashCheque = new System.Windows.Forms.RadioButton();
            this.radPaymentCheque = new System.Windows.Forms.RadioButton();
            this.radPaymentCash = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtTaxpayer = new System.Windows.Forms.TextBox();
            this.txtCollectingOfficer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbxAccountableForm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceipts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpBxChequeDetails.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(848, 205);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Payment";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotalPayment);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(4, 23);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(840, 179);
            this.panel5.TabIndex = 1;
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPayment.Location = new System.Drawing.Point(4, 49);
            this.lblTotalPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(832, 65);
            this.lblTotalPayment.TabIndex = 2;
            this.lblTotalPayment.Text = "0.00";
            this.lblTotalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total Payment";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 205);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpBxChequeDetails);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Size = new System.Drawing.Size(848, 311);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 53;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // gpBxChequeDetails
            // 
            this.gpBxChequeDetails.Controls.Add(this.panel9);
            this.gpBxChequeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpBxChequeDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gpBxChequeDetails.Location = new System.Drawing.Point(0, 57);
            this.gpBxChequeDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpBxChequeDetails.Name = "gpBxChequeDetails";
            this.gpBxChequeDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpBxChequeDetails.Size = new System.Drawing.Size(418, 254);
            this.gpBxChequeDetails.TabIndex = 9;
            this.gpBxChequeDetails.TabStop = false;
            this.gpBxChequeDetails.Text = "Cheque Details";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgCheques);
            this.panel9.Controls.Add(this.toolStrip1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel9.Location = new System.Drawing.Point(4, 19);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Size = new System.Drawing.Size(410, 232);
            this.panel9.TabIndex = 0;
            // 
            // dgCheques
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCheques.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheques.Location = new System.Drawing.Point(4, 28);
            this.dgCheques.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgCheques.Name = "dgCheques";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgCheques.RowTemplate.Height = 25;
            this.dgCheques.Size = new System.Drawing.Size(402, 201);
            this.dgCheques.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDelete,
            this.toolStripButtonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(4, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(402, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::AccountingSystem.Properties.Resources.waste_bin_filled_14px;
            this.toolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "Delete";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::AccountingSystem.Properties.Resources.symbol_add_14px;
            this.toolStripButtonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Add";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(418, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Methods";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCashCheque);
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCheque);
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCash);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(4, 23);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(410, 31);
            this.flowLayoutPanel6.TabIndex = 5;
            // 
            // radPaymentCashCheque
            // 
            this.radPaymentCashCheque.AutoSize = true;
            this.radPaymentCashCheque.Location = new System.Drawing.Point(290, 6);
            this.radPaymentCashCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCashCheque.Name = "radPaymentCashCheque";
            this.radPaymentCashCheque.Size = new System.Drawing.Size(108, 19);
            this.radPaymentCashCheque.TabIndex = 8;
            this.radPaymentCashCheque.Text = "Cash && Cheque";
            this.radPaymentCashCheque.UseVisualStyleBackColor = true;
            // 
            // radPaymentCheque
            // 
            this.radPaymentCheque.AutoSize = true;
            this.radPaymentCheque.Location = new System.Drawing.Point(216, 6);
            this.radPaymentCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCheque.Name = "radPaymentCheque";
            this.radPaymentCheque.Size = new System.Drawing.Size(66, 19);
            this.radPaymentCheque.TabIndex = 7;
            this.radPaymentCheque.Text = "Cheque";
            this.radPaymentCheque.UseVisualStyleBackColor = true;
            // 
            // radPaymentCash
            // 
            this.radPaymentCash.AutoSize = true;
            this.radPaymentCash.Checked = true;
            this.radPaymentCash.Location = new System.Drawing.Point(157, 6);
            this.radPaymentCash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCash.Name = "radPaymentCash";
            this.radPaymentCash.Size = new System.Drawing.Size(51, 19);
            this.radPaymentCash.TabIndex = 6;
            this.radPaymentCash.TabStop = true;
            this.radPaymentCash.Text = "Cash";
            this.radPaymentCash.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(426, 311);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Payment Details";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtTaxpayer);
            this.panel7.Controls.Add(this.txtCollectingOfficer);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.cmbxAccountableForm);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.txtReceipts);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.txtPayee);
            this.panel7.Controls.Add(this.dtPaymentDate);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel7.Location = new System.Drawing.Point(4, 23);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel7.Size = new System.Drawing.Size(418, 285);
            this.panel7.TabIndex = 13;
            // 
            // txtTaxpayer
            // 
            this.txtTaxpayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxpayer.Location = new System.Drawing.Point(123, 11);
            this.txtTaxpayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTaxpayer.Name = "txtTaxpayer";
            this.txtTaxpayer.ReadOnly = true;
            this.txtTaxpayer.Size = new System.Drawing.Size(272, 23);
            this.txtTaxpayer.TabIndex = 14;
            this.txtTaxpayer.WordWrap = false;
            // 
            // txtCollectingOfficer
            // 
            this.txtCollectingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollectingOfficer.Location = new System.Drawing.Point(123, 40);
            this.txtCollectingOfficer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCollectingOfficer.Name = "txtCollectingOfficer";
            this.txtCollectingOfficer.ReadOnly = true;
            this.txtCollectingOfficer.Size = new System.Drawing.Size(272, 23);
            this.txtCollectingOfficer.TabIndex = 15;
            this.txtCollectingOfficer.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 46;
            this.label1.Text = "Tapayer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "Collecting Officer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "Accountable Form";
            // 
            // cmbxAccountableForm
            // 
            this.cmbxAccountableForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccountableForm.FormattingEnabled = true;
            this.cmbxAccountableForm.ItemHeight = 15;
            this.cmbxAccountableForm.Location = new System.Drawing.Point(123, 69);
            this.cmbxAccountableForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbxAccountableForm.Name = "cmbxAccountableForm";
            this.cmbxAccountableForm.Size = new System.Drawing.Size(272, 23);
            this.cmbxAccountableForm.TabIndex = 51;
            this.cmbxAccountableForm.SelectionChangeCommitted += new System.EventHandler(this.cmbxAccountableForm_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Receipt No.";
            // 
            // txtReceipts
            // 
            this.txtReceipts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtReceipts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReceipts.Location = new System.Drawing.Point(123, 126);
            this.txtReceipts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtReceipts.MaxLength = 999999999;
            this.txtReceipts.Name = "txtReceipts";
            this.txtReceipts.Size = new System.Drawing.Size(272, 23);
            this.txtReceipts.TabIndex = 18;
            this.txtReceipts.WordWrap = false;
            this.txtReceipts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceipts_KeyPress);
            this.txtReceipts.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceipts_Validating);
            this.txtReceipts.Validated += new System.EventHandler(this.txtReceipts_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Payment Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 159);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Payee";
            // 
            // txtPayee
            // 
            this.txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayee.Location = new System.Drawing.Point(123, 155);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(272, 23);
            this.txtPayee.TabIndex = 19;
            this.txtPayee.WordWrap = false;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayee_Validated);
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(123, 97);
            this.dtPaymentDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(272, 23);
            this.dtPaymentDate.TabIndex = 17;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox6);
            this.Name = "ucPayment";
            this.Size = new System.Drawing.Size(848, 516);
            this.Load += new System.EventHandler(this.ucPayment_Load);
            this.groupBox6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpBxChequeDetails.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpBxChequeDetails;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgCheques;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.RadioButton radPaymentCashCheque;
        private System.Windows.Forms.RadioButton radPaymentCheque;
        private System.Windows.Forms.RadioButton radPaymentCash;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.TextBox txtCollectingOfficer;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbxAccountableForm;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtReceipts;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.DateTimePicker dtPaymentDate;
        internal System.Windows.Forms.TextBox txtTaxpayer;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
