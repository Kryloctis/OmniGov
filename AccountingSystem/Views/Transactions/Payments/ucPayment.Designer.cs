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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox6 = new System.Windows.Forms.GroupBox();
            panel5 = new System.Windows.Forms.Panel();
            lblTotalPayment = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            gpBxChequeDetails = new System.Windows.Forms.GroupBox();
            panel9 = new System.Windows.Forms.Panel();
            dgCheques = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            radPaymentCashCheque = new System.Windows.Forms.RadioButton();
            radPaymentCheque = new System.Windows.Forms.RadioButton();
            radPaymentCash = new System.Windows.Forms.RadioButton();
            groupBox5 = new System.Windows.Forms.GroupBox();
            panel7 = new System.Windows.Forms.Panel();
            txtTaxpayer = new System.Windows.Forms.TextBox();
            txtCollectingOfficer = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cmbxAccountableForm = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            txtReceipts = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtPayee = new System.Windows.Forms.TextBox();
            dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox6.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            gpBxChequeDetails.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCheques).BeginInit();
            toolStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            groupBox5.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(panel5);
            groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox6.Location = new System.Drawing.Point(0, 0);
            groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Size = new System.Drawing.Size(848, 205);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Payment";
            // 
            // panel5
            // 
            panel5.Controls.Add(lblTotalPayment);
            panel5.Controls.Add(label5);
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel5.Location = new System.Drawing.Point(4, 23);
            panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(840, 179);
            panel5.TabIndex = 1;
            // 
            // lblTotalPayment
            // 
            lblTotalPayment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblTotalPayment.Location = new System.Drawing.Point(4, 49);
            lblTotalPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalPayment.Name = "lblTotalPayment";
            lblTotalPayment.Size = new System.Drawing.Size(832, 65);
            lblTotalPayment.TabIndex = 2;
            lblTotalPayment.Text = "0.00";
            lblTotalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(379, 115);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 15);
            label5.TabIndex = 3;
            label5.Text = "Total Payment";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 205);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(gpBxChequeDetails);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox5);
            splitContainer1.Size = new System.Drawing.Size(848, 311);
            splitContainer1.SplitterDistance = 418;
            splitContainer1.TabIndex = 53;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // gpBxChequeDetails
            // 
            gpBxChequeDetails.Controls.Add(panel9);
            gpBxChequeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            gpBxChequeDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            gpBxChequeDetails.Location = new System.Drawing.Point(0, 57);
            gpBxChequeDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gpBxChequeDetails.Name = "gpBxChequeDetails";
            gpBxChequeDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gpBxChequeDetails.Size = new System.Drawing.Size(418, 254);
            gpBxChequeDetails.TabIndex = 9;
            gpBxChequeDetails.TabStop = false;
            gpBxChequeDetails.Text = "Cheque Details";
            // 
            // panel9
            // 
            panel9.Controls.Add(dgCheques);
            panel9.Controls.Add(toolStrip1);
            panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            panel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel9.Location = new System.Drawing.Point(4, 19);
            panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel9.Name = "panel9";
            panel9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel9.Size = new System.Drawing.Size(410, 232);
            panel9.TabIndex = 0;
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
            dgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgCheques.DefaultCellStyle = dataGridViewCellStyle2;
            dgCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            dgCheques.Location = new System.Drawing.Point(4, 28);
            dgCheques.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgCheques.Name = "dgCheques";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgCheques.RowTemplate.Height = 25;
            dgCheques.Size = new System.Drawing.Size(402, 201);
            dgCheques.TabIndex = 11;
            dgCheques.Tag = "\"\"";
            dgCheques.RowsAdded += dgCheques_RowsAdded;
            dgCheques.Validating += dgCheques_Validating;
            dgCheques.Validated += dgCheques_Validated;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonDelete, toolStripButtonAdd });
            toolStrip1.Location = new System.Drawing.Point(4, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(402, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = Properties.Resources.waste_bin_filled_14px;
            toolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = Properties.Resources.symbol_add_14px;
            toolStripButtonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel6);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(418, 57);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payment Methods";
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(radPaymentCashCheque);
            flowLayoutPanel6.Controls.Add(radPaymentCheque);
            flowLayoutPanel6.Controls.Add(radPaymentCash);
            flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanel6.Location = new System.Drawing.Point(4, 23);
            flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel6.Size = new System.Drawing.Size(410, 31);
            flowLayoutPanel6.TabIndex = 5;
            // 
            // radPaymentCashCheque
            // 
            radPaymentCashCheque.AutoSize = true;
            radPaymentCashCheque.Location = new System.Drawing.Point(290, 6);
            radPaymentCashCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radPaymentCashCheque.Name = "radPaymentCashCheque";
            radPaymentCashCheque.Size = new System.Drawing.Size(108, 19);
            radPaymentCashCheque.TabIndex = 8;
            radPaymentCashCheque.Text = "Cash && Cheque";
            radPaymentCashCheque.UseVisualStyleBackColor = true;
            radPaymentCashCheque.CheckedChanged += radPaymentCashCheque_CheckedChanged;
            // 
            // radPaymentCheque
            // 
            radPaymentCheque.AutoSize = true;
            radPaymentCheque.Location = new System.Drawing.Point(216, 6);
            radPaymentCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radPaymentCheque.Name = "radPaymentCheque";
            radPaymentCheque.Size = new System.Drawing.Size(66, 19);
            radPaymentCheque.TabIndex = 7;
            radPaymentCheque.Text = "Cheque";
            radPaymentCheque.UseVisualStyleBackColor = true;
            radPaymentCheque.CheckedChanged += radPaymentCheque_CheckedChanged;
            // 
            // radPaymentCash
            // 
            radPaymentCash.AutoSize = true;
            radPaymentCash.Checked = true;
            radPaymentCash.Location = new System.Drawing.Point(157, 6);
            radPaymentCash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radPaymentCash.Name = "radPaymentCash";
            radPaymentCash.Size = new System.Drawing.Size(51, 19);
            radPaymentCash.TabIndex = 6;
            radPaymentCash.TabStop = true;
            radPaymentCash.Text = "Cash";
            radPaymentCash.UseVisualStyleBackColor = true;
            radPaymentCash.CheckedChanged += radPaymentCash_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(panel7);
            groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox5.Location = new System.Drawing.Point(0, 0);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Size = new System.Drawing.Size(426, 311);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Payment Details";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtTaxpayer);
            panel7.Controls.Add(txtCollectingOfficer);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(label6);
            panel7.Controls.Add(cmbxAccountableForm);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(txtReceipts);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(txtPayee);
            panel7.Controls.Add(dtPaymentDate);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel7.Location = new System.Drawing.Point(4, 23);
            panel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel7.Size = new System.Drawing.Size(418, 285);
            panel7.TabIndex = 13;
            // 
            // txtTaxpayer
            // 
            txtTaxpayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTaxpayer.Location = new System.Drawing.Point(123, 11);
            txtTaxpayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTaxpayer.Name = "txtTaxpayer";
            txtTaxpayer.ReadOnly = true;
            txtTaxpayer.Size = new System.Drawing.Size(272, 23);
            txtTaxpayer.TabIndex = 14;
            txtTaxpayer.WordWrap = false;
            // 
            // txtCollectingOfficer
            // 
            txtCollectingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCollectingOfficer.Location = new System.Drawing.Point(123, 40);
            txtCollectingOfficer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCollectingOfficer.Name = "txtCollectingOfficer";
            txtCollectingOfficer.ReadOnly = true;
            txtCollectingOfficer.Size = new System.Drawing.Size(272, 23);
            txtCollectingOfficer.TabIndex = 15;
            txtCollectingOfficer.WordWrap = false;
            txtCollectingOfficer.Validating += txtCollectingOfficer_Validating;
            txtCollectingOfficer.Validated += txtCollectingOfficer_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 13);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 46;
            label1.Text = "Taxpayer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 44);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(100, 15);
            label7.TabIndex = 46;
            label7.Text = "Collecting Officer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 72);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(105, 15);
            label6.TabIndex = 45;
            label6.Text = "Accountable Form";
            // 
            // cmbxAccountableForm
            // 
            cmbxAccountableForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAccountableForm.FormattingEnabled = true;
            cmbxAccountableForm.ItemHeight = 15;
            cmbxAccountableForm.Location = new System.Drawing.Point(123, 69);
            cmbxAccountableForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxAccountableForm.Name = "cmbxAccountableForm";
            cmbxAccountableForm.Size = new System.Drawing.Size(272, 23);
            cmbxAccountableForm.TabIndex = 51;
            cmbxAccountableForm.SelectionChangeCommitted += cmbxAccountableForm_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 129);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 15);
            label3.TabIndex = 44;
            label3.Text = "Receipt No.";
            // 
            // txtReceipts
            // 
            txtReceipts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            txtReceipts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtReceipts.Location = new System.Drawing.Point(123, 126);
            txtReceipts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtReceipts.MaxLength = 999999999;
            txtReceipts.Name = "txtReceipts";
            txtReceipts.Size = new System.Drawing.Size(272, 23);
            txtReceipts.TabIndex = 18;
            txtReceipts.WordWrap = false;
            txtReceipts.KeyPress += txtReceipts_KeyPress;
            txtReceipts.Validating += txtReceipts_Validating;
            txtReceipts.Validated += txtReceipts_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 100);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 15);
            label2.TabIndex = 43;
            label2.Text = "Payment Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 159);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 15);
            label4.TabIndex = 42;
            label4.Text = "Payee";
            // 
            // txtPayee
            // 
            txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPayee.Location = new System.Drawing.Point(123, 155);
            txtPayee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(272, 23);
            txtPayee.TabIndex = 19;
            txtPayee.WordWrap = false;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.Location = new System.Drawing.Point(123, 97);
            dtPaymentDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Size = new System.Drawing.Size(272, 23);
            dtPaymentDate.TabIndex = 17;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucPayment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(splitContainer1);
            Controls.Add(groupBox6);
            Name = "ucPayment";
            Size = new System.Drawing.Size(848, 516);
            Load += ucPayment_Load;
            groupBox6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            gpBxChequeDetails.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgCheques).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            groupBox5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.TextBox txtCollectingOfficer;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtReceipts;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.DateTimePicker dtPaymentDate;
        internal System.Windows.Forms.TextBox txtTaxpayer;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label lblTotalPayment;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.GroupBox gpBxChequeDetails;
        internal System.Windows.Forms.Panel panel9;
        internal System.Windows.Forms.DataGridView dgCheques;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        internal System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        internal System.Windows.Forms.RadioButton radPaymentCashCheque;
        internal System.Windows.Forms.RadioButton radPaymentCheque;
        internal System.Windows.Forms.RadioButton radPaymentCash;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.ComboBox cmbxAccountableForm;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
