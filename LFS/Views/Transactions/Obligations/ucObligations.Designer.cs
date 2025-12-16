
namespace LFS.Views.Transactions.ObligationRequest
{
    partial class ucObligations
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
            dtDateRequest = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            mskTxtOblgtnNo = new System.Windows.Forms.MaskedTextBox();
            label5 = new System.Windows.Forms.Label();
            txtPayee = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtReferenceNo = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            dgObligationRequests = new System.Windows.Forms.DataGridView();
            txtTotalObligations = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            cmbxFPP = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            customTabControl1 = new LFS.CustomTools.CustomTabControl();
            tbPgDetails = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            label11 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            txtExplanation = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            tbPgEntries = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnEntrRemove = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnEntrAdd = new System.Windows.Forms.ToolStripButton();
            mskTxtTransNo = new System.Windows.Forms.MaskedTextBox();
            label2 = new System.Windows.Forms.Label();
            lblStatIndctr = new System.Windows.Forms.Label();
            lblCreatedBy = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgObligationRequests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            customTabControl1.SuspendLayout();
            tbPgDetails.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tbPgEntries.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dtDateRequest
            // 
            dtDateRequest.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDateRequest.Location = new System.Drawing.Point(105, 23);
            dtDateRequest.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtDateRequest.Name = "dtDateRequest";
            dtDateRequest.Size = new System.Drawing.Size(242, 23);
            dtDateRequest.TabIndex = 8;
            dtDateRequest.ValueChanged += dtDateRequest_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "Date Request";
            // 
            // mskTxtOblgtnNo
            // 
            mskTxtOblgtnNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mskTxtOblgtnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mskTxtOblgtnNo.Location = new System.Drawing.Point(23, 38);
            mskTxtOblgtnNo.Mask = "0000-00-00-000";
            mskTxtOblgtnNo.Name = "mskTxtOblgtnNo";
            mskTxtOblgtnNo.ReadOnly = true;
            mskTxtOblgtnNo.Size = new System.Drawing.Size(328, 23);
            mskTxtOblgtnNo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(23, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 15);
            label5.TabIndex = 10;
            label5.Text = "Obligation No.";
            // 
            // txtPayee
            // 
            txtPayee.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPayee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPayee.Location = new System.Drawing.Point(99, 105);
            txtPayee.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(252, 23);
            txtPayee.TabIndex = 10;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(24, 107);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 15);
            label6.TabIndex = 12;
            label6.Text = "Payee*";
            // 
            // txtReferenceNo
            // 
            txtReferenceNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtReferenceNo.Location = new System.Drawing.Point(105, 64);
            txtReferenceNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.Size = new System.Drawing.Size(242, 23);
            txtReferenceNo.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 68);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(46, 15);
            label8.TabIndex = 12;
            label8.Text = "Ref No.";
            // 
            // dgObligationRequests
            // 
            dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgObligationRequests.Dock = System.Windows.Forms.DockStyle.Top;
            dgObligationRequests.Location = new System.Drawing.Point(15, 40);
            dgObligationRequests.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dgObligationRequests.Name = "dgObligationRequests";
            dgObligationRequests.Size = new System.Drawing.Size(712, 208);
            dgObligationRequests.TabIndex = 12;
            dgObligationRequests.SelectionChanged += dgObligationRequests_SelectionChanged;
            // 
            // txtTotalObligations
            // 
            txtTotalObligations.BackColor = System.Drawing.SystemColors.Control;
            txtTotalObligations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalObligations.Location = new System.Drawing.Point(56, 262);
            txtTotalObligations.MaxLength = 999999999;
            txtTotalObligations.Name = "txtTotalObligations";
            txtTotalObligations.ReadOnly = true;
            txtTotalObligations.Size = new System.Drawing.Size(236, 23);
            txtTotalObligations.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(18, 266);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(32, 15);
            label9.TabIndex = 17;
            label9.Text = "Total";
            // 
            // cmbxFPP
            // 
            cmbxFPP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxFPP.FormattingEnabled = true;
            cmbxFPP.Location = new System.Drawing.Point(99, 23);
            cmbxFPP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxFPP.Name = "cmbxFPP";
            cmbxFPP.Size = new System.Drawing.Size(252, 23);
            cmbxFPP.TabIndex = 18;
            cmbxFPP.KeyDown += cmbxFPP_KeyDown;
            cmbxFPP.Validating += cmbxFPP_Validating;
            cmbxFPP.Validated += cmbxFPP_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 20;
            label1.Text = "FPP*";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgDetails);
            customTabControl1.Controls.Add(tbPgEntries);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.ItemSize = new System.Drawing.Size(136, 24);
            customTabControl1.Location = new System.Drawing.Point(0, 99);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.Padding = new System.Drawing.Point(30, 5);
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(756, 338);
            customTabControl1.TabIndex = 24;
            // 
            // tbPgDetails
            // 
            tbPgDetails.BackColor = System.Drawing.SystemColors.Control;
            tbPgDetails.Controls.Add(panel2);
            tbPgDetails.Location = new System.Drawing.Point(4, 28);
            tbPgDetails.Name = "tbPgDetails";
            tbPgDetails.Size = new System.Drawing.Size(748, 306);
            tbPgDetails.TabIndex = 0;
            tbPgDetails.Text = "Details";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(splitContainer2);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(748, 306);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label11);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(txtExplanation);
            panel3.Controls.Add(label7);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 135);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            panel3.Size = new System.Drawing.Size(748, 108);
            panel3.TabIndex = 22;
            // 
            // label11
            // 
            label11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label11.Location = new System.Drawing.Point(376, 78);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(309, 15);
            label11.TabIndex = 42;
            label11.Text = "Section for approval, disapproval, or cancellation remarks.";
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Location = new System.Drawing.Point(99, 52);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(626, 23);
            textBox1.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(24, 54);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(52, 15);
            label10.TabIndex = 40;
            label10.Text = "Remarks";
            // 
            // txtExplanation
            // 
            txtExplanation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtExplanation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtExplanation.Location = new System.Drawing.Point(99, 11);
            txtExplanation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.Size = new System.Drawing.Size(626, 23);
            txtExplanation.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(24, 13);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 15);
            label7.TabIndex = 41;
            label7.Text = "Explanation";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(cmbxFPP);
            splitContainer2.Panel1.Controls.Add(label6);
            splitContainer2.Panel1.Controls.Add(comboBox1);
            splitContainer2.Panel1.Controls.Add(txtPayee);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dtDateRequest);
            splitContainer2.Panel2.Controls.Add(txtReferenceNo);
            splitContainer2.Panel2.Controls.Add(label3);
            splitContainer2.Panel2.Controls.Add(label8);
            splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(20);
            splitContainer2.Size = new System.Drawing.Size(748, 135);
            splitContainer2.SplitterDistance = 374;
            splitContainer2.TabIndex = 21;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(99, 64);
            comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(252, 23);
            comboBox1.TabIndex = 18;
            comboBox1.KeyDown += cmbxFPP_KeyDown;
            comboBox1.Validating += cmbxFPP_Validating;
            comboBox1.Validated += cmbxFPP_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 67);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 20;
            label4.Text = "Fund*";
            // 
            // tbPgEntries
            // 
            tbPgEntries.BackColor = System.Drawing.SystemColors.Control;
            tbPgEntries.Controls.Add(panel1);
            tbPgEntries.Location = new System.Drawing.Point(4, 28);
            tbPgEntries.Name = "tbPgEntries";
            tbPgEntries.Padding = new System.Windows.Forms.Padding(3);
            tbPgEntries.Size = new System.Drawing.Size(748, 306);
            tbPgEntries.TabIndex = 1;
            tbPgEntries.Text = "Entries";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgObligationRequests);
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(txtTotalObligations);
            panel1.Controls.Add(label9);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(15);
            panel1.Size = new System.Drawing.Size(742, 300);
            panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnEntrRemove, tlStrpBtnEntrAdd });
            toolStrip1.Location = new System.Drawing.Point(15, 15);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(712, 25);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnEntrRemove
            // 
            tlStrpBtnEntrRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnEntrRemove.Image = Properties.Resources.symbol_cancel_16px;
            tlStrpBtnEntrRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnEntrRemove.Name = "tlStrpBtnEntrRemove";
            tlStrpBtnEntrRemove.Size = new System.Drawing.Size(70, 22);
            tlStrpBtnEntrRemove.Text = "Remove";
            // 
            // tlStrpBtnEntrAdd
            // 
            tlStrpBtnEntrAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnEntrAdd.Image = Properties.Resources.symbol_add_16px;
            tlStrpBtnEntrAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnEntrAdd.Name = "tlStrpBtnEntrAdd";
            tlStrpBtnEntrAdd.Size = new System.Drawing.Size(49, 22);
            tlStrpBtnEntrAdd.Text = "Add";
            // 
            // mskTxtTransNo
            // 
            mskTxtTransNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mskTxtTransNo.BackColor = System.Drawing.SystemColors.Control;
            mskTxtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mskTxtTransNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            mskTxtTransNo.Location = new System.Drawing.Point(23, 38);
            mskTxtTransNo.Mask = " 00-0000";
            mskTxtTransNo.Name = "mskTxtTransNo";
            mskTxtTransNo.ReadOnly = true;
            mskTxtTransNo.Size = new System.Drawing.Size(332, 23);
            mskTxtTransNo.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(23, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 64;
            label2.Text = "Trans. No. *";
            // 
            // lblStatIndctr
            // 
            lblStatIndctr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblStatIndctr.AutoSize = true;
            lblStatIndctr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblStatIndctr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatIndctr.Location = new System.Drawing.Point(335, 18);
            lblStatIndctr.Margin = new System.Windows.Forms.Padding(0);
            lblStatIndctr.Name = "lblStatIndctr";
            lblStatIndctr.Size = new System.Drawing.Size(16, 17);
            lblStatIndctr.TabIndex = 68;
            lblStatIndctr.Text = "●";
            lblStatIndctr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCreatedBy.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCreatedBy.Location = new System.Drawing.Point(23, 64);
            lblCreatedBy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new System.Drawing.Size(328, 13);
            lblCreatedBy.TabIndex = 66;
            lblCreatedBy.Text = "Created by: --";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatus.Location = new System.Drawing.Point(130, 21);
            lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(205, 13);
            lblStatus.TabIndex = 67;
            lblStatus.Text = "Status: Draft";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(mskTxtTransNo);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(lblStatIndctr);
            splitContainer1.Panel2.Controls.Add(mskTxtOblgtnNo);
            splitContainer1.Panel2.Controls.Add(lblCreatedBy);
            splitContainer1.Panel2.Controls.Add(lblStatus);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(20);
            splitContainer1.Size = new System.Drawing.Size(756, 99);
            splitContainer1.SplitterDistance = 378;
            splitContainer1.TabIndex = 69;
            // 
            // ucObligations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(customTabControl1);
            Controls.Add(splitContainer1);
            Name = "ucObligations";
            Size = new System.Drawing.Size(756, 437);
            ((System.ComponentModel.ISupportInitialize)dgObligationRequests).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            customTabControl1.ResumeLayout(false);
            tbPgDetails.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tbPgEntries.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.DateTimePicker dtDateRequest;
        internal System.Windows.Forms.MaskedTextBox mskTxtOblgtnNo;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataGridView dgObligationRequests;
        internal System.Windows.Forms.TextBox txtTotalObligations;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgDetails;
        private System.Windows.Forms.TabPage tbPgEntries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnEntrAdd;
        private System.Windows.Forms.ToolStripButton tlStrpBtnEntrRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox mskTxtTransNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatIndctr;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.Label label7;
    }
}
