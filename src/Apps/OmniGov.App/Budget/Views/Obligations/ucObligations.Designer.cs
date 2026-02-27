
namespace OmniGov.App.Budget.Views.Obligations
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
            mskTxtOblgtnNo = new MaskedTextBox();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            mskTxtTransNo = new MaskedTextBox();
            label2 = new Label();
            lblStatIndctr = new Label();
            lblCreatedBy = new Label();
            lblStatus = new Label();
            splitContainer1 = new SplitContainer();
            tbControlDetailsEntries = new TabControl();
            tbPgDetails = new TabPage();
            panel2 = new Panel();
            panel3 = new Panel();
            label11 = new Label();
            txtRemarks = new TextBox();
            label10 = new Label();
            txtExplanation = new TextBox();
            label7 = new Label();
            splitContainer2 = new SplitContainer();
            cmbxFPP = new ComboBox();
            cmbxAlltmntClss = new ComboBox();
            cmbxFund = new ComboBox();
            label12 = new Label();
            label1 = new Label();
            label4 = new Label();
            dtDateRequest = new DateTimePicker();
            label6 = new Label();
            txtReferenceNo = new TextBox();
            label3 = new Label();
            label8 = new Label();
            txtPayee = new TextBox();
            tbPgEntries = new TabPage();
            dgvEntries = new DataGridView();
            lblTotalOblgtn = new Label();
            toolStrip1 = new ToolStrip();
            tlStrpBtnEntrRemove = new ToolStripButton();
            tlStrpBtnEntrAdd = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tbControlDetailsEntries.SuspendLayout();
            tbPgDetails.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tbPgEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mskTxtOblgtnNo
            // 
            mskTxtOblgtnNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mskTxtOblgtnNo.BorderStyle = BorderStyle.FixedSingle;
            mskTxtOblgtnNo.Location = new Point(23, 38);
            mskTxtOblgtnNo.Mask = "0000-00-00-000";
            mskTxtOblgtnNo.Name = "mskTxtOblgtnNo";
            mskTxtOblgtnNo.ReadOnly = true;
            mskTxtOblgtnNo.Size = new Size(328, 23);
            mskTxtOblgtnNo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(23, 20);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 10;
            label5.Text = "Obligation No.";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // mskTxtTransNo
            // 
            mskTxtTransNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mskTxtTransNo.BackColor = SystemColors.Control;
            mskTxtTransNo.BorderStyle = BorderStyle.FixedSingle;
            mskTxtTransNo.Font = new Font("Segoe UI", 9F);
            mskTxtTransNo.Location = new Point(23, 38);
            mskTxtTransNo.Mask = " 00-0000";
            mskTxtTransNo.Name = "mskTxtTransNo";
            mskTxtTransNo.ReadOnly = true;
            mskTxtTransNo.Size = new Size(332, 23);
            mskTxtTransNo.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(23, 20);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 64;
            label2.Text = "Transaction No. *";
            // 
            // lblStatIndctr
            // 
            lblStatIndctr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatIndctr.AutoSize = true;
            lblStatIndctr.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatIndctr.ForeColor = SystemColors.ControlDarkDark;
            lblStatIndctr.Location = new Point(335, 18);
            lblStatIndctr.Margin = new Padding(0);
            lblStatIndctr.Name = "lblStatIndctr";
            lblStatIndctr.Size = new Size(16, 17);
            lblStatIndctr.TabIndex = 68;
            lblStatIndctr.Text = "●";
            lblStatIndctr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.Font = new Font("Segoe UI", 8.25F);
            lblCreatedBy.ForeColor = SystemColors.ControlDarkDark;
            lblCreatedBy.Location = new Point(23, 64);
            lblCreatedBy.Margin = new Padding(3, 0, 3, 3);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(328, 13);
            lblCreatedBy.TabIndex = 66;
            lblCreatedBy.Text = "Created by: --";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 8.25F);
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.Location = new Point(130, 21);
            lblStatus.Margin = new Padding(3, 0, 0, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(205, 13);
            lblStatus.TabIndex = 67;
            lblStatus.Text = "Status: Draft";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Top;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(mskTxtTransNo);
            splitContainer1.Panel1.Padding = new Padding(20);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(lblStatIndctr);
            splitContainer1.Panel2.Controls.Add(mskTxtOblgtnNo);
            splitContainer1.Panel2.Controls.Add(lblCreatedBy);
            splitContainer1.Panel2.Controls.Add(lblStatus);
            splitContainer1.Panel2.Padding = new Padding(20);
            splitContainer1.Size = new Size(756, 99);
            splitContainer1.SplitterDistance = 378;
            splitContainer1.TabIndex = 69;
            // 
            // tbControlDetailsEntries
            // 
            tbControlDetailsEntries.Controls.Add(tbPgDetails);
            tbControlDetailsEntries.Controls.Add(tbPgEntries);
            tbControlDetailsEntries.Dock = DockStyle.Fill;
            tbControlDetailsEntries.ItemSize = new Size(136, 24);
            tbControlDetailsEntries.Location = new Point(0, 99);
            tbControlDetailsEntries.Name = "tbControlDetailsEntries";
            tbControlDetailsEntries.Padding = new Point(30, 5);
            tbControlDetailsEntries.SelectedIndex = 0;
            tbControlDetailsEntries.Size = new Size(756, 353);
            tbControlDetailsEntries.TabIndex = 23;
            // 
            // tbPgDetails
            // 
            tbPgDetails.Controls.Add(panel2);
            tbPgDetails.Location = new Point(4, 28);
            tbPgDetails.Name = "tbPgDetails";
            tbPgDetails.Padding = new Padding(3);
            tbPgDetails.Size = new Size(748, 321);
            tbPgDetails.TabIndex = 0;
            tbPgDetails.Text = "Details";
            tbPgDetails.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(splitContainer2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(742, 315);
            panel2.TabIndex = 23;
            // 
            // panel3
            // 
            panel3.Controls.Add(label11);
            panel3.Controls.Add(txtRemarks);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(txtExplanation);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 136);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20, 0, 20, 20);
            panel3.Size = new Size(742, 108);
            panel3.TabIndex = 22;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlDarkDark;
            label11.Location = new Point(410, 78);
            label11.Name = "label11";
            label11.Size = new Size(309, 15);
            label11.TabIndex = 42;
            label11.Text = "Section for approval, disapproval, or cancellation remarks.";
            // 
            // txtRemarks
            // 
            txtRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRemarks.BorderStyle = BorderStyle.FixedSingle;
            txtRemarks.Location = new Point(99, 52);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(620, 23);
            txtRemarks.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(24, 54);
            label10.Name = "label10";
            label10.Size = new Size(52, 15);
            label10.TabIndex = 40;
            label10.Text = "Remarks";
            // 
            // txtExplanation
            // 
            txtExplanation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExplanation.BorderStyle = BorderStyle.FixedSingle;
            txtExplanation.Location = new Point(99, 11);
            txtExplanation.Margin = new Padding(3, 3, 3, 15);
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.Size = new Size(620, 23);
            txtExplanation.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 13);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 41;
            label7.Text = "Explanation";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Top;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(cmbxFPP);
            splitContainer2.Panel1.Controls.Add(cmbxAlltmntClss);
            splitContainer2.Panel1.Controls.Add(cmbxFund);
            splitContainer2.Panel1.Controls.Add(label12);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Padding = new Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dtDateRequest);
            splitContainer2.Panel2.Controls.Add(label6);
            splitContainer2.Panel2.Controls.Add(txtReferenceNo);
            splitContainer2.Panel2.Controls.Add(label3);
            splitContainer2.Panel2.Controls.Add(label8);
            splitContainer2.Panel2.Controls.Add(txtPayee);
            splitContainer2.Panel2.Padding = new Padding(20);
            splitContainer2.Size = new Size(742, 136);
            splitContainer2.SplitterDistance = 371;
            splitContainer2.TabIndex = 21;
            // 
            // cmbxFPP
            // 
            cmbxFPP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbxFPP.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxFPP.FormattingEnabled = true;
            cmbxFPP.Location = new Point(99, 22);
            cmbxFPP.Margin = new Padding(3, 3, 3, 15);
            cmbxFPP.Name = "cmbxFPP";
            cmbxFPP.Size = new Size(249, 23);
            cmbxFPP.TabIndex = 18;
            cmbxFPP.SelectedIndexChanged += cmbxFPP_SelectedIndexChanged;
            cmbxFPP.Validating += cmbxFPP_Validating;
            cmbxFPP.Validated += cmbxFPP_Validated;
            // 
            // cmbxAlltmntClss
            // 
            cmbxAlltmntClss.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbxAlltmntClss.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAlltmntClss.FormattingEnabled = true;
            cmbxAlltmntClss.Location = new Point(99, 105);
            cmbxAlltmntClss.Margin = new Padding(3, 3, 3, 15);
            cmbxAlltmntClss.Name = "cmbxAlltmntClss";
            cmbxAlltmntClss.Size = new Size(249, 23);
            cmbxAlltmntClss.TabIndex = 18;
            cmbxAlltmntClss.Validating += cmbxFPP_Validating;
            cmbxAlltmntClss.Validated += cmbxFPP_Validated;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbxFund.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new Point(99, 64);
            cmbxFund.Margin = new Padding(3, 3, 3, 15);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new Size(249, 23);
            cmbxFund.TabIndex = 18;
            cmbxFund.Validating += cmbxFPP_Validating;
            cmbxFund.Validated += cmbxFPP_Validated;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 101);
            label12.Name = "label12";
            label12.Size = new Size(60, 30);
            label12.TabIndex = 20;
            label12.Text = "Allotment\r\nClass*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 26);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 20;
            label1.Text = "FPP*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 68);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 20;
            label4.Text = "Fund*";
            // 
            // dtDateRequest
            // 
            //
            dtDateRequest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtDateRequest.Location = new Point(105, 64);
            dtDateRequest.Margin = new Padding(3, 3, 3, 15);
            dtDateRequest.Name = "dtDateRequest";
            dtDateRequest.Size = new Size(239, 23);
            dtDateRequest.TabIndex = 8;
            dtDateRequest.ValueChanged += dtDateRequest_ValueChanged;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(23, 27);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 12;
            label6.Text = "Payee*";
            // 
            // txtReferenceNo
            // 
            txtReferenceNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReferenceNo.BorderStyle = BorderStyle.FixedSingle;
            txtReferenceNo.Location = new Point(105, 105);
            txtReferenceNo.Margin = new Padding(3, 3, 3, 15);
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.Size = new Size(239, 23);
            txtReferenceNo.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 68);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "Date Request";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 107);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 12;
            label8.Text = "Ref No.";
            // 
            // txtPayee
            // 
            txtPayee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPayee.BorderStyle = BorderStyle.FixedSingle;
            txtPayee.Location = new Point(105, 23);
            txtPayee.Margin = new Padding(3, 3, 3, 15);
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new Size(239, 23);
            txtPayee.TabIndex = 10;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // tbPgEntries
            // 
            tbPgEntries.Controls.Add(dgvEntries);
            tbPgEntries.Controls.Add(lblTotalOblgtn);
            tbPgEntries.Controls.Add(toolStrip1);
            tbPgEntries.Location = new Point(4, 28);
            tbPgEntries.Name = "tbPgEntries";
            tbPgEntries.Padding = new Padding(20);
            tbPgEntries.Size = new Size(748, 321);
            tbPgEntries.TabIndex = 1;
            tbPgEntries.Text = "Entries";
            tbPgEntries.UseVisualStyleBackColor = true;
            // 
            // dgvEntries
            // 
            dgvEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntries.Dock = DockStyle.Fill;
            dgvEntries.Location = new Point(20, 45);
            dgvEntries.Margin = new Padding(3, 3, 3, 10);
            dgvEntries.Name = "dgvEntries";
            dgvEntries.Size = new Size(708, 214);
            dgvEntries.TabIndex = 12;
            dgvEntries.CellValueChanged += dgvEntries_CellValueChanged;
            dgvEntries.CellValidating += dgvEntries_CellValidating;
            dgvEntries.CurrentCellDirtyStateChanged += dgvEntries_CurrentCellDirtyStateChanged;
            dgvEntries.DataError += dgvEntries_DataError;
            dgvEntries.EditingControlShowing += dgvEntries_EditingControlShowing;
            dgvEntries.SelectionChanged += dgvEntries_SelectionChanged;
            // 
            // lblTotalOblgtn
            // 
            lblTotalOblgtn.Dock = DockStyle.Bottom;
            lblTotalOblgtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalOblgtn.ForeColor = SystemColors.ControlDarkDark;
            lblTotalOblgtn.Location = new Point(20, 259);
            lblTotalOblgtn.Name = "lblTotalOblgtn";
            lblTotalOblgtn.Padding = new Padding(0, 15, 0, 0);
            lblTotalOblgtn.Size = new Size(708, 42);
            lblTotalOblgtn.TabIndex = 14;
            lblTotalOblgtn.Text = "Total: 0.00";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlStrpBtnEntrRemove, tlStrpBtnEntrAdd });
            toolStrip1.Location = new Point(20, 20);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(708, 25);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnEntrRemove
            // 
            tlStrpBtnEntrRemove.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnEntrRemove.Image = Properties.Resources.symbol_cancel_16px;
            tlStrpBtnEntrRemove.ImageTransparentColor = Color.Magenta;
            tlStrpBtnEntrRemove.Name = "tlStrpBtnEntrRemove";
            tlStrpBtnEntrRemove.Size = new Size(70, 22);
            tlStrpBtnEntrRemove.Text = "Remove";
            tlStrpBtnEntrRemove.Click += tlStrpBtnEntrRemove_Click;
            // 
            // tlStrpBtnEntrAdd
            // 
            tlStrpBtnEntrAdd.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnEntrAdd.Image = Properties.Resources.symbol_add_16px;
            tlStrpBtnEntrAdd.ImageTransparentColor = Color.Magenta;
            tlStrpBtnEntrAdd.Name = "tlStrpBtnEntrAdd";
            tlStrpBtnEntrAdd.Size = new Size(49, 22);
            tlStrpBtnEntrAdd.Text = "Add";
            tlStrpBtnEntrAdd.Click += tlStrpBtnEntrAdd_Click;
            // 
            // ucObligations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            Controls.Add(tbControlDetailsEntries);
            Controls.Add(splitContainer1);
            Name = "ucObligations";
            Size = new Size(756, 452);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tbControlDetailsEntries.ResumeLayout(false);
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
            tbPgEntries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.MaskedTextBox mskTxtOblgtnNo;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tbPgEntries;
        private System.Windows.Forms.MaskedTextBox mskTxtTransNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatIndctr;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tbControlDetailsEntries;
        private System.Windows.Forms.TabPage tbPgDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer2;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.ComboBox cmbxAlltmntClss;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtDateRequest;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.DataGridView dgvEntries;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnEntrRemove;
        private System.Windows.Forms.ToolStripButton tlStrpBtnEntrAdd;
        private System.Windows.Forms.Label lblTotalOblgtn;
    }
}
