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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            gpBxChequeDetails = new System.Windows.Forms.GroupBox();
            panel9 = new System.Windows.Forms.Panel();
            dgCheques = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnDeleteCheque = new System.Windows.Forms.ToolStripButton();
            btnAddCheque = new System.Windows.Forms.ToolStripButton();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            radPaymentCashCheque = new System.Windows.Forms.RadioButton();
            radPaymentCheque = new System.Windows.Forms.RadioButton();
            radPaymentCash = new System.Windows.Forms.RadioButton();
            groupBox5 = new System.Windows.Forms.GroupBox();
            panel7 = new System.Windows.Forms.Panel();
            txtCollectingOfficer = new System.Windows.Forms.TextBox();
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
            panel5 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            lblTotalPayment = new System.Windows.Forms.Label();
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
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Location = new System.Drawing.Point(0, 118);
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
            splitContainer1.Size = new System.Drawing.Size(796, 398);
            splitContainer1.SplitterDistance = 393;
            splitContainer1.TabIndex = 53;
            // 
            // gpBxChequeDetails
            // 
            gpBxChequeDetails.Controls.Add(panel9);
            gpBxChequeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            gpBxChequeDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            gpBxChequeDetails.Location = new System.Drawing.Point(0, 57);
            gpBxChequeDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gpBxChequeDetails.Name = "gpBxChequeDetails";
            gpBxChequeDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gpBxChequeDetails.Size = new System.Drawing.Size(393, 341);
            gpBxChequeDetails.TabIndex = 9;
            gpBxChequeDetails.TabStop = false;
            gpBxChequeDetails.Text = "Cheque Details";
            // 
            // panel9
            // 
            panel9.Controls.Add(dgCheques);
            panel9.Controls.Add(toolStrip1);
            panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            panel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel9.Location = new System.Drawing.Point(4, 19);
            panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel9.Name = "panel9";
            panel9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel9.Size = new System.Drawing.Size(385, 319);
            panel9.TabIndex = 0;
            // 
            // dgCheques
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgCheques.RowTemplate.Height = 25;
            dgCheques.Size = new System.Drawing.Size(377, 288);
            dgCheques.TabIndex = 11;
            dgCheques.Tag = "\"\"";
            dgCheques.DataError += dgCheques_DataError;
            dgCheques.RowsAdded += DgCheques_RowsAdded;
            dgCheques.Validating += dgCheques_Validating;
            dgCheques.Validated += dgCheques_Validated;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnDeleteCheque, btnAddCheque });
            toolStrip1.Location = new System.Drawing.Point(4, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(377, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnDeleteCheque
            // 
            btnDeleteCheque.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnDeleteCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnDeleteCheque.Image = Properties.Resources.waste_bin_filled_14px;
            btnDeleteCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDeleteCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDeleteCheque.Name = "btnDeleteCheque";
            btnDeleteCheque.Size = new System.Drawing.Size(23, 22);
            btnDeleteCheque.Text = "Delete";
            btnDeleteCheque.Click += BtnDeleteCheque_Click;
            // 
            // btnAddCheque
            // 
            btnAddCheque.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnAddCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnAddCheque.Image = Properties.Resources.symbol_add_14px;
            btnAddCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAddCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddCheque.Name = "btnAddCheque";
            btnAddCheque.Size = new System.Drawing.Size(23, 22);
            btnAddCheque.Text = "Add";
            btnAddCheque.Click += BtnAddCheque_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel6);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(393, 57);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payment Method";
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(radPaymentCashCheque);
            flowLayoutPanel6.Controls.Add(radPaymentCheque);
            flowLayoutPanel6.Controls.Add(radPaymentCash);
            flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel6.Enabled = false;
            flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            flowLayoutPanel6.Location = new System.Drawing.Point(4, 23);
            flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel6.Size = new System.Drawing.Size(385, 31);
            flowLayoutPanel6.TabIndex = 5;
            // 
            // radPaymentCashCheque
            // 
            radPaymentCashCheque.AutoSize = true;
            radPaymentCashCheque.Location = new System.Drawing.Point(265, 6);
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
            radPaymentCheque.Location = new System.Drawing.Point(191, 6);
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
            radPaymentCash.Location = new System.Drawing.Point(132, 6);
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
            groupBox5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox5.Location = new System.Drawing.Point(0, 0);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Size = new System.Drawing.Size(399, 398);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Payment Details";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtCollectingOfficer);
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
            panel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel7.Location = new System.Drawing.Point(4, 23);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4);
            panel7.Size = new System.Drawing.Size(391, 372);
            panel7.TabIndex = 13;
            // 
            // txtCollectingOfficer
            // 
            txtCollectingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCollectingOfficer.Location = new System.Drawing.Point(120, 6);
            txtCollectingOfficer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCollectingOfficer.Name = "txtCollectingOfficer";
            txtCollectingOfficer.ReadOnly = true;
            txtCollectingOfficer.Size = new System.Drawing.Size(250, 23);
            txtCollectingOfficer.TabIndex = 15;
            txtCollectingOfficer.WordWrap = false;
            txtCollectingOfficer.Validating += txtCollectingOfficer_Validating;
            txtCollectingOfficer.Validated += txtCollectingOfficer_Validated;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(7, 11);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(100, 15);
            label7.TabIndex = 46;
            label7.Text = "Collecting Officer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 39);
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
            cmbxAccountableForm.Location = new System.Drawing.Point(120, 35);
            cmbxAccountableForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxAccountableForm.Name = "cmbxAccountableForm";
            cmbxAccountableForm.Size = new System.Drawing.Size(250, 23);
            cmbxAccountableForm.TabIndex = 51;
            cmbxAccountableForm.SelectionChangeCommitted += cmbxAccountableForm_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 96);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 15);
            label3.TabIndex = 44;
            label3.Text = "Receipt No.";
            // 
            // txtReceipts
            // 
            txtReceipts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtReceipts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtReceipts.Location = new System.Drawing.Point(120, 92);
            txtReceipts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtReceipts.MaxLength = 999999999;
            txtReceipts.Name = "txtReceipts";
            txtReceipts.Size = new System.Drawing.Size(250, 23);
            txtReceipts.TabIndex = 18;
            txtReceipts.WordWrap = false;
            txtReceipts.KeyPress += txtReceipts_KeyPress;
            txtReceipts.Validating += txtReceipts_Validating;
            txtReceipts.Validated += txtReceipts_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 67);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 15);
            label2.TabIndex = 43;
            label2.Text = "Payment Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 126);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 15);
            label4.TabIndex = 42;
            label4.Text = "Payee";
            // 
            // txtPayee
            // 
            txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPayee.Location = new System.Drawing.Point(120, 121);
            txtPayee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(250, 23);
            txtPayee.TabIndex = 19;
            txtPayee.WordWrap = false;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.Location = new System.Drawing.Point(120, 63);
            dtPaymentDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Size = new System.Drawing.Size(250, 23);
            dtPaymentDate.TabIndex = 17;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // panel5
            // 
            panel5.Controls.Add(label5);
            panel5.Controls.Add(lblTotalPayment);
            panel5.Dock = System.Windows.Forms.DockStyle.Top;
            panel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(796, 118);
            panel5.TabIndex = 54;
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Location = new System.Drawing.Point(0, 65);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(796, 15);
            label5.TabIndex = 3;
            label5.Text = "Amount to pay";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPayment
            // 
            lblTotalPayment.Dock = System.Windows.Forms.DockStyle.Top;
            lblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 36F);
            lblTotalPayment.Location = new System.Drawing.Point(0, 0);
            lblTotalPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalPayment.Name = "lblTotalPayment";
            lblTotalPayment.Size = new System.Drawing.Size(796, 65);
            lblTotalPayment.TabIndex = 2;
            lblTotalPayment.Text = "0.00";
            lblTotalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPayment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(splitContainer1);
            Controls.Add(panel5);
            Name = "ucPayment";
            Size = new System.Drawing.Size(796, 516);
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
            panel5.ResumeLayout(false);
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
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.GroupBox gpBxChequeDetails;
        internal System.Windows.Forms.Panel panel9;
        internal System.Windows.Forms.DataGridView dgCheques;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnDeleteCheque;
        internal System.Windows.Forms.ToolStripButton btnAddCheque;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        internal System.Windows.Forms.RadioButton radPaymentCashCheque;
        internal System.Windows.Forms.RadioButton radPaymentCheque;
        internal System.Windows.Forms.RadioButton radPaymentCash;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.ComboBox cmbxAccountableForm;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lblTotalPayment;
    }
}
