
namespace LFS.Budget.Views.SupplementalAppropriations
{
    partial class frmSupplementalAppropriationsMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkSelectAll = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgSupplementalAppropriations = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTotalSupplemental = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtAllotmentClass = new System.Windows.Forms.TextBox();
            this.txtFund = new System.Windows.Forms.TextBox();
            this.txtFPP = new System.Windows.Forms.TextBox();
            this.chckbxContinuing = new System.Windows.Forms.CheckBox();
            this.dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.cmbxSubFPP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplementalAppropriations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 575);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(417, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LFS.Properties.Resources.save14px;
            this.btnSave.Location = new System.Drawing.Point(336, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkSelectAll
            // 
            this.lnkSelectAll.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.lnkSelectAll.AutoSize = true;
            this.lnkSelectAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectAll.LinkColor = System.Drawing.SystemColors.Highlight;
            this.lnkSelectAll.Location = new System.Drawing.Point(400, 0);
            this.lnkSelectAll.Name = "lnkSelectAll";
            this.lnkSelectAll.Size = new System.Drawing.Size(55, 15);
            this.lnkSelectAll.TabIndex = 69;
            this.lnkSelectAll.TabStop = true;
            this.lnkSelectAll.Text = "Select All";
            this.lnkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectAll_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 297);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplemental Appropriations";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkSelectAll);
            this.panel1.Controls.Add(this.dgSupplementalAppropriations);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtTotalSupplemental);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 275);
            this.panel1.TabIndex = 0;
            // 
            // dgSupplementalAppropriations
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSupplementalAppropriations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgSupplementalAppropriations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSupplementalAppropriations.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgSupplementalAppropriations.Location = new System.Drawing.Point(3, 18);
            this.dgSupplementalAppropriations.Name = "dgSupplementalAppropriations";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSupplementalAppropriations.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgSupplementalAppropriations.RowTemplate.Height = 25;
            this.dgSupplementalAppropriations.Size = new System.Drawing.Size(452, 220);
            this.dgSupplementalAppropriations.TabIndex = 5;
            this.dgSupplementalAppropriations.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgSupplementalAppropriations_RowsAdded);
            this.dgSupplementalAppropriations.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgSupplementalAppropriations_RowsRemoved);
            this.dgSupplementalAppropriations.SelectionChanged += new System.EventHandler(this.dgSupplementalAppropriations_SelectionChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(380, 244);
            this.btnRemove.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 68;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(301, 244);
            this.btnEdit.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(220, 244);
            this.btnAdd.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 68;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTotalSupplemental
            // 
            this.txtTotalSupplemental.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalSupplemental.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSupplemental.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTotalSupplemental.Location = new System.Drawing.Point(41, 244);
            this.txtTotalSupplemental.Name = "txtTotalSupplemental";
            this.txtTotalSupplemental.Size = new System.Drawing.Size(151, 23);
            this.txtTotalSupplemental.TabIndex = 37;
            this.txtTotalSupplemental.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 86;
            this.label9.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(108, 215);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(368, 23);
            this.txtRemarks.TabIndex = 85;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(108, 41);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(368, 23);
            this.txtYear.TabIndex = 84;
            // 
            // txtAllotmentClass
            // 
            this.txtAllotmentClass.Location = new System.Drawing.Point(108, 157);
            this.txtAllotmentClass.Name = "txtAllotmentClass";
            this.txtAllotmentClass.ReadOnly = true;
            this.txtAllotmentClass.Size = new System.Drawing.Size(368, 23);
            this.txtAllotmentClass.TabIndex = 83;
            // 
            // txtFund
            // 
            this.txtFund.Location = new System.Drawing.Point(108, 70);
            this.txtFund.Name = "txtFund";
            this.txtFund.ReadOnly = true;
            this.txtFund.Size = new System.Drawing.Size(368, 23);
            this.txtFund.TabIndex = 82;
            // 
            // txtFPP
            // 
            this.txtFPP.Location = new System.Drawing.Point(108, 99);
            this.txtFPP.Name = "txtFPP";
            this.txtFPP.ReadOnly = true;
            this.txtFPP.Size = new System.Drawing.Size(368, 23);
            this.txtFPP.TabIndex = 81;
            // 
            // chckbxContinuing
            // 
            this.chckbxContinuing.AutoSize = true;
            this.chckbxContinuing.Location = new System.Drawing.Point(313, 244);
            this.chckbxContinuing.Name = "chckbxContinuing";
            this.chckbxContinuing.Size = new System.Drawing.Size(163, 19);
            this.chckbxContinuing.TabIndex = 80;
            this.chckbxContinuing.Text = "Continuing Appropriation";
            this.chckbxContinuing.UseVisualStyleBackColor = true;
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Location = new System.Drawing.Point(108, 12);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(368, 23);
            this.dtpDateEntry.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 71;
            this.label6.Text = "Date Entry";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "Account";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 75;
            this.label8.Text = "Year";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 74;
            this.label10.Text = "Sub FPP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 73;
            this.label11.Text = "Type of Fund";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 72;
            this.label12.Text = "FPP";
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.IntegralHeight = false;
            this.cmbxAccount.Location = new System.Drawing.Point(108, 186);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(368, 23);
            this.cmbxAccount.TabIndex = 79;
            this.cmbxAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxAccount_KeyDown);
            this.cmbxAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccount_Validating);
            this.cmbxAccount.Validated += new System.EventHandler(this.cmbxAccount_Validated);
            // 
            // cmbxSubFPP
            // 
            this.cmbxSubFPP.FormattingEnabled = true;
            this.cmbxSubFPP.Location = new System.Drawing.Point(108, 128);
            this.cmbxSubFPP.Name = "cmbxSubFPP";
            this.cmbxSubFPP.Size = new System.Drawing.Size(368, 23);
            this.cmbxSubFPP.TabIndex = 78;
            this.cmbxSubFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxSubFPP_Validating);
            this.cmbxSubFPP.Validated += new System.EventHandler(this.cmbxSubFPP_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Allotment Class";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSupplementalAppropriationsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(495, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtAllotmentClass);
            this.Controls.Add(this.txtFund);
            this.Controls.Add(this.txtFPP);
            this.Controls.Add(this.chckbxContinuing);
            this.Controls.Add(this.dtpDateEntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.cmbxSubFPP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplementalAppropriationsMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Budget Appropriations > Supplemental Appropriations";
            this.Load += new System.EventHandler(this.frmSupplementalAppropriationsMain_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplementalAppropriations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.LinkLabel lnkSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView dgSupplementalAppropriations;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtTotalSupplemental;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.TextBox txtYear;
        internal System.Windows.Forms.TextBox txtAllotmentClass;
        internal System.Windows.Forms.TextBox txtFund;
        internal System.Windows.Forms.TextBox txtFPP;
        internal System.Windows.Forms.CheckBox chckbxContinuing;
        internal System.Windows.Forms.DateTimePicker dtpDateEntry;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        internal System.Windows.Forms.ComboBox cmbxSubFPP;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
