
namespace LFS.Views.Manage.ChartOfAccounts
{
    partial class frmChartOfAccounts
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            dgGeneralLedgerAccounts = new System.Windows.Forms.DataGridView();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabGeneralLedgers = new System.Windows.Forms.TabPage();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtTotalCredit = new System.Windows.Forms.TextBox();
            txtTotalDebit = new System.Windows.Forms.TextBox();
            cmbxGenLedgAccountGroup = new System.Windows.Forms.ComboBox();
            btnRetrieveAll = new System.Windows.Forms.Button();
            cmbxYear = new System.Windows.Forms.ComboBox();
            cmbxFund = new System.Windows.Forms.ComboBox();
            txtSearch = new System.Windows.Forms.TextBox();
            tabSubMajorAccount = new System.Windows.Forms.TabPage();
            label3 = new System.Windows.Forms.Label();
            cmbMajorAccount = new System.Windows.Forms.ComboBox();
            dgSubMajorAccount = new System.Windows.Forms.DataGridView();
            tabMajorAccount = new System.Windows.Forms.TabPage();
            label2 = new System.Windows.Forms.Label();
            cmbAccountGroup = new System.Windows.Forms.ComboBox();
            dgMajorAccountGroup = new System.Windows.Forms.DataGridView();
            tabAccountGroup = new System.Windows.Forms.TabPage();
            dgAccountGroup = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            BtnSubsidiary = new System.Windows.Forms.ToolStripButton();
            BtnSetBalance = new System.Windows.Forms.ToolStripButton();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgGeneralLedgerAccounts).BeginInit();
            tabControl1.SuspendLayout();
            tabGeneralLedgers.SuspendLayout();
            tabSubMajorAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSubMajorAccount).BeginInit();
            tabMajorAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgMajorAccountGroup).BeginInit();
            tabAccountGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAccountGroup).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 540);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1128, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(916, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // dgGeneralLedgerAccounts
            // 
            dgGeneralLedgerAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgGeneralLedgerAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgGeneralLedgerAccounts.Location = new System.Drawing.Point(3, 35);
            dgGeneralLedgerAccounts.Name = "dgGeneralLedgerAccounts";
            dgGeneralLedgerAccounts.RowHeadersWidth = 51;
            dgGeneralLedgerAccounts.RowTemplate.Height = 29;
            dgGeneralLedgerAccounts.Size = new System.Drawing.Size(1109, 394);
            dgGeneralLedgerAccounts.TabIndex = 4;
            dgGeneralLedgerAccounts.SelectionChanged += dgGeneralLedgerAccounts_SelectionChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabGeneralLedgers);
            tabControl1.Controls.Add(tabSubMajorAccount);
            tabControl1.Controls.Add(tabMajorAccount);
            tabControl1.Controls.Add(tabAccountGroup);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 48);
            tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(10, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1128, 492);
            tabControl1.TabIndex = 5;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabGeneralLedgers
            // 
            tabGeneralLedgers.Controls.Add(label5);
            tabGeneralLedgers.Controls.Add(label4);
            tabGeneralLedgers.Controls.Add(txtTotalCredit);
            tabGeneralLedgers.Controls.Add(txtTotalDebit);
            tabGeneralLedgers.Controls.Add(cmbxGenLedgAccountGroup);
            tabGeneralLedgers.Controls.Add(btnRetrieveAll);
            tabGeneralLedgers.Controls.Add(cmbxYear);
            tabGeneralLedgers.Controls.Add(cmbxFund);
            tabGeneralLedgers.Controls.Add(txtSearch);
            tabGeneralLedgers.Controls.Add(dgGeneralLedgerAccounts);
            tabGeneralLedgers.Location = new System.Drawing.Point(4, 24);
            tabGeneralLedgers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabGeneralLedgers.Name = "tabGeneralLedgers";
            tabGeneralLedgers.Padding = new System.Windows.Forms.Padding(3);
            tabGeneralLedgers.Size = new System.Drawing.Size(1120, 464);
            tabGeneralLedgers.TabIndex = 0;
            tabGeneralLedgers.Text = "General Ledgers";
            tabGeneralLedgers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(893, 439);
            label5.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 15);
            label5.TabIndex = 12;
            label5.Text = "Total Debit";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(655, 439);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 15);
            label4.TabIndex = 12;
            label4.Text = "Total Credit";
            // 
            // txtTotalCredit
            // 
            txtTotalCredit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            txtTotalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalCredit.Location = new System.Drawing.Point(728, 435);
            txtTotalCredit.MaxLength = 999999;
            txtTotalCredit.Name = "txtTotalCredit";
            txtTotalCredit.ReadOnly = true;
            txtTotalCredit.Size = new System.Drawing.Size(152, 23);
            txtTotalCredit.TabIndex = 11;
            txtTotalCredit.Text = "0.00";
            // 
            // txtTotalDebit
            // 
            txtTotalDebit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            txtTotalDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalDebit.Location = new System.Drawing.Point(962, 435);
            txtTotalDebit.MaxLength = 999999;
            txtTotalDebit.Name = "txtTotalDebit";
            txtTotalDebit.ReadOnly = true;
            txtTotalDebit.Size = new System.Drawing.Size(152, 23);
            txtTotalDebit.TabIndex = 11;
            txtTotalDebit.Text = "0.00";
            // 
            // cmbxGenLedgAccountGroup
            // 
            cmbxGenLedgAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxGenLedgAccountGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cmbxGenLedgAccountGroup.FormattingEnabled = true;
            cmbxGenLedgAccountGroup.Location = new System.Drawing.Point(238, 8);
            cmbxGenLedgAccountGroup.Name = "cmbxGenLedgAccountGroup";
            cmbxGenLedgAccountGroup.Size = new System.Drawing.Size(177, 23);
            cmbxGenLedgAccountGroup.TabIndex = 10;
            // 
            // btnRetrieveAll
            // 
            btnRetrieveAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieveAll.Location = new System.Drawing.Point(1026, 6);
            btnRetrieveAll.Name = "btnRetrieveAll";
            btnRetrieveAll.Size = new System.Drawing.Size(86, 23);
            btnRetrieveAll.TabIndex = 9;
            btnRetrieveAll.Text = "&Retrieve All";
            btnRetrieveAll.UseVisualStyleBackColor = true;
            btnRetrieveAll.Click += btnRetrieveAll_Click;
            // 
            // cmbxYear
            // 
            cmbxYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxYear.FormattingEnabled = true;
            cmbxYear.Location = new System.Drawing.Point(927, 6);
            cmbxYear.Name = "cmbxYear";
            cmbxYear.Size = new System.Drawing.Size(93, 23);
            cmbxYear.TabIndex = 8;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(771, 6);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(150, 23);
            cmbxFund.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(3, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(229, 23);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tabSubMajorAccount
            // 
            tabSubMajorAccount.Controls.Add(label3);
            tabSubMajorAccount.Controls.Add(cmbMajorAccount);
            tabSubMajorAccount.Controls.Add(dgSubMajorAccount);
            tabSubMajorAccount.Location = new System.Drawing.Point(4, 24);
            tabSubMajorAccount.Name = "tabSubMajorAccount";
            tabSubMajorAccount.Padding = new System.Windows.Forms.Padding(3);
            tabSubMajorAccount.Size = new System.Drawing.Size(1120, 464);
            tabSubMajorAccount.TabIndex = 1;
            tabSubMajorAccount.Text = "Sub Major Account Group";
            tabSubMajorAccount.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(122, 15);
            label3.TabIndex = 2;
            label3.Text = "Major Account Group";
            // 
            // cmbMajorAccount
            // 
            cmbMajorAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMajorAccount.FormattingEnabled = true;
            cmbMajorAccount.Location = new System.Drawing.Point(132, 5);
            cmbMajorAccount.Name = "cmbMajorAccount";
            cmbMajorAccount.Size = new System.Drawing.Size(321, 23);
            cmbMajorAccount.TabIndex = 1;
            cmbMajorAccount.SelectionChangeCommitted += cmbMajorAccount_SelectionChangeCommitted;
            // 
            // dgSubMajorAccount
            // 
            dgSubMajorAccount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgSubMajorAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSubMajorAccount.Location = new System.Drawing.Point(3, 33);
            dgSubMajorAccount.Name = "dgSubMajorAccount";
            dgSubMajorAccount.RowHeadersWidth = 51;
            dgSubMajorAccount.RowTemplate.Height = 29;
            dgSubMajorAccount.Size = new System.Drawing.Size(1114, 429);
            dgSubMajorAccount.TabIndex = 0;
            dgSubMajorAccount.SelectionChanged += dgSubMajorAccount_SelectionChanged;
            // 
            // tabMajorAccount
            // 
            tabMajorAccount.Controls.Add(label2);
            tabMajorAccount.Controls.Add(cmbAccountGroup);
            tabMajorAccount.Controls.Add(dgMajorAccountGroup);
            tabMajorAccount.Location = new System.Drawing.Point(4, 24);
            tabMajorAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabMajorAccount.Name = "tabMajorAccount";
            tabMajorAccount.Size = new System.Drawing.Size(1120, 464);
            tabMajorAccount.TabIndex = 3;
            tabMajorAccount.Text = "Major Account Group";
            tabMajorAccount.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 15);
            label2.TabIndex = 2;
            label2.Text = "Account Group";
            // 
            // cmbAccountGroup
            // 
            cmbAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAccountGroup.FormattingEnabled = true;
            cmbAccountGroup.Location = new System.Drawing.Point(99, 5);
            cmbAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbAccountGroup.Name = "cmbAccountGroup";
            cmbAccountGroup.Size = new System.Drawing.Size(177, 23);
            cmbAccountGroup.TabIndex = 1;
            cmbAccountGroup.SelectionChangeCommitted += cmbAccountGroup_SelectionChangeCommitted;
            // 
            // dgMajorAccountGroup
            // 
            dgMajorAccountGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgMajorAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMajorAccountGroup.Location = new System.Drawing.Point(3, 32);
            dgMajorAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgMajorAccountGroup.Name = "dgMajorAccountGroup";
            dgMajorAccountGroup.RowHeadersWidth = 51;
            dgMajorAccountGroup.RowTemplate.Height = 29;
            dgMajorAccountGroup.Size = new System.Drawing.Size(1114, 430);
            dgMajorAccountGroup.TabIndex = 0;
            dgMajorAccountGroup.SelectionChanged += dgMajorAccountGroup_SelectionChanged;
            // 
            // tabAccountGroup
            // 
            tabAccountGroup.Controls.Add(dgAccountGroup);
            tabAccountGroup.Location = new System.Drawing.Point(4, 24);
            tabAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabAccountGroup.Name = "tabAccountGroup";
            tabAccountGroup.Size = new System.Drawing.Size(1120, 464);
            tabAccountGroup.TabIndex = 4;
            tabAccountGroup.Text = "Account Group";
            tabAccountGroup.UseVisualStyleBackColor = true;
            // 
            // dgAccountGroup
            // 
            dgAccountGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAccountGroup.Location = new System.Drawing.Point(3, 2);
            dgAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgAccountGroup.Name = "dgAccountGroup";
            dgAccountGroup.RowHeadersWidth = 51;
            dgAccountGroup.RowTemplate.Height = 29;
            dgAccountGroup.Size = new System.Drawing.Size(1113, 460);
            dgAccountGroup.TabIndex = 0;
            dgAccountGroup.SelectionChanged += dgAccountGroup_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, BtnSubsidiary, BtnSetBalance });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 1, 3);
            toolStrip1.Size = new System.Drawing.Size(1128, 48);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(42, 39);
            btnAdd.Text = "Add...";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(40, 39);
            btnEdit.Text = "Edit...";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += BtnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // BtnSubsidiary
            // 
            BtnSubsidiary.Image = Properties.Resources.subject_writing_filled_20px;
            BtnSubsidiary.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            BtnSubsidiary.ImageTransparentColor = System.Drawing.Color.Magenta;
            BtnSubsidiary.Name = "BtnSubsidiary";
            BtnSubsidiary.Size = new System.Drawing.Size(65, 39);
            BtnSubsidiary.Text = "Subsidiary";
            BtnSubsidiary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            BtnSubsidiary.Click += BtnSubsidiary_Click;
            // 
            // BtnSetBalance
            // 
            BtnSetBalance.Image = Properties.Resources.tool_notebook_filled_money_coins_filled_20px;
            BtnSetBalance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            BtnSetBalance.ImageTransparentColor = System.Drawing.Color.Magenta;
            BtnSetBalance.Name = "BtnSetBalance";
            BtnSetBalance.Size = new System.Drawing.Size(80, 39);
            BtnSetBalance.Text = "Set Balance...";
            BtnSetBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            BtnSetBalance.Click += BtnSetBalance_Click;
            // 
            // frmChartOfAccounts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1128, 562);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimumSize = new System.Drawing.Size(1144, 548);
            Name = "frmChartOfAccounts";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Chart of Accounts";
            Load += frmChartOfAccounts_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgGeneralLedgerAccounts).EndInit();
            tabControl1.ResumeLayout(false);
            tabGeneralLedgers.ResumeLayout(false);
            tabGeneralLedgers.PerformLayout();
            tabSubMajorAccount.ResumeLayout(false);
            tabSubMajorAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgSubMajorAccount).EndInit();
            tabMajorAccount.ResumeLayout(false);
            tabMajorAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgMajorAccountGroup).EndInit();
            tabAccountGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAccountGroup).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.DataGridView dgGeneralLedgerAccounts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneralLedgers;
        private System.Windows.Forms.TabPage tabSubMajorAccount;
        private System.Windows.Forms.TabPage tabMajorAccount;
        private System.Windows.Forms.TabPage tabAccountGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView dgAccountGroup;
        private System.Windows.Forms.DataGridView dgMajorAccountGroup;
        private System.Windows.Forms.ComboBox cmbAccountGroup;
        private System.Windows.Forms.DataGridView dgSubMajorAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnSubsidiary;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton BtnSetBalance;
        private System.Windows.Forms.ComboBox cmbxFund;
        private System.Windows.Forms.ComboBox cmbxYear;
        private System.Windows.Forms.ComboBox cmbxGenLedgAccountGroup;
        private System.Windows.Forms.Button btnRetrieveAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMajorAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalCredit;
        private System.Windows.Forms.TextBox txtTotalDebit;
    }
}