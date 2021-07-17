
namespace AccountingSystem.Views.Manage.ChartOfAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartOfAccounts));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgGeneralLedgerAccounts = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneralLedgers = new System.Windows.Forms.TabPage();
            this.cmbxGenLedgAccountGroup = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbFund = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSubMajorAccount = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMajorAccount = new System.Windows.Forms.ComboBox();
            this.dgSubMajorAccount = new System.Windows.Forms.DataGridView();
            this.tabMajorAccount = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAccountGroup = new System.Windows.Forms.ComboBox();
            this.dgMajorAccountGroup = new System.Windows.Forms.DataGridView();
            this.tabAccountGroup = new System.Windows.Forms.TabPage();
            this.dgAccountGroup = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSubsidiary = new System.Windows.Forms.ToolStripButton();
            this.BtnSetBalance = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneralLedgerAccounts)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneralLedgers.SuspendLayout();
            this.tabSubMajorAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubMajorAccount)).BeginInit();
            this.tabMajorAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMajorAccountGroup)).BeginInit();
            this.tabAccountGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountGroup)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCount,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.lblCreatedAt,
            this.toolStripStatusLabel3,
            this.lblUpdatedAt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1128, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 17);
            this.lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(916, 17);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // dgGeneralLedgerAccounts
            // 
            this.dgGeneralLedgerAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgGeneralLedgerAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGeneralLedgerAccounts.Location = new System.Drawing.Point(3, 35);
            this.dgGeneralLedgerAccounts.Name = "dgGeneralLedgerAccounts";
            this.dgGeneralLedgerAccounts.RowHeadersWidth = 51;
            this.dgGeneralLedgerAccounts.RowTemplate.Height = 29;
            this.dgGeneralLedgerAccounts.Size = new System.Drawing.Size(1109, 422);
            this.dgGeneralLedgerAccounts.TabIndex = 4;
            this.dgGeneralLedgerAccounts.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgGeneralLedgerAccounts_RowHeaderMouseDoubleClick);
            this.dgGeneralLedgerAccounts.SelectionChanged += new System.EventHandler(this.dgGeneralLedgerAccounts_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneralLedgers);
            this.tabControl1.Controls.Add(this.tabSubMajorAccount);
            this.tabControl1.Controls.Add(this.tabMajorAccount);
            this.tabControl1.Controls.Add(this.tabAccountGroup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1128, 491);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabGeneralLedgers
            // 
            this.tabGeneralLedgers.Controls.Add(this.cmbxGenLedgAccountGroup);
            this.tabGeneralLedgers.Controls.Add(this.btnRetrieve);
            this.tabGeneralLedgers.Controls.Add(this.cmbYear);
            this.tabGeneralLedgers.Controls.Add(this.cmbFund);
            this.tabGeneralLedgers.Controls.Add(this.txtSearch);
            this.tabGeneralLedgers.Controls.Add(this.label1);
            this.tabGeneralLedgers.Controls.Add(this.dgGeneralLedgerAccounts);
            this.tabGeneralLedgers.Location = new System.Drawing.Point(4, 24);
            this.tabGeneralLedgers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGeneralLedgers.Name = "tabGeneralLedgers";
            this.tabGeneralLedgers.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralLedgers.Size = new System.Drawing.Size(1120, 463);
            this.tabGeneralLedgers.TabIndex = 0;
            this.tabGeneralLedgers.Text = "General Ledgers";
            this.tabGeneralLedgers.UseVisualStyleBackColor = true;
            // 
            // cmbxGenLedgAccountGroup
            // 
            this.cmbxGenLedgAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxGenLedgAccountGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbxGenLedgAccountGroup.FormattingEnabled = true;
            this.cmbxGenLedgAccountGroup.Location = new System.Drawing.Point(286, 7);
            this.cmbxGenLedgAccountGroup.Name = "cmbxGenLedgAccountGroup";
            this.cmbxGenLedgAccountGroup.Size = new System.Drawing.Size(177, 23);
            this.cmbxGenLedgAccountGroup.TabIndex = 10;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieve.Location = new System.Drawing.Point(1037, 6);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 9;
            this.btnRetrieve.Text = "&Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(938, 6);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 23);
            this.cmbYear.TabIndex = 8;
            // 
            // cmbFund
            // 
            this.cmbFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFund.FormattingEnabled = true;
            this.cmbFund.Location = new System.Drawing.Point(782, 6);
            this.cmbFund.Name = "cmbFund";
            this.cmbFund.Size = new System.Drawing.Size(150, 23);
            this.cmbFund.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(51, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 23);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search";
            // 
            // tabSubMajorAccount
            // 
            this.tabSubMajorAccount.Controls.Add(this.label3);
            this.tabSubMajorAccount.Controls.Add(this.cmbMajorAccount);
            this.tabSubMajorAccount.Controls.Add(this.dgSubMajorAccount);
            this.tabSubMajorAccount.Location = new System.Drawing.Point(4, 24);
            this.tabSubMajorAccount.Name = "tabSubMajorAccount";
            this.tabSubMajorAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubMajorAccount.Size = new System.Drawing.Size(1120, 463);
            this.tabSubMajorAccount.TabIndex = 1;
            this.tabSubMajorAccount.Text = "Sub Major Account Group";
            this.tabSubMajorAccount.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Major Account Group";
            // 
            // cmbMajorAccount
            // 
            this.cmbMajorAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMajorAccount.FormattingEnabled = true;
            this.cmbMajorAccount.Location = new System.Drawing.Point(131, 6);
            this.cmbMajorAccount.Name = "cmbMajorAccount";
            this.cmbMajorAccount.Size = new System.Drawing.Size(321, 23);
            this.cmbMajorAccount.TabIndex = 1;
            this.cmbMajorAccount.SelectionChangeCommitted += new System.EventHandler(this.cmbMajorAccount_SelectionChangeCommitted);
            // 
            // dgSubMajorAccount
            // 
            this.dgSubMajorAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSubMajorAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubMajorAccount.Location = new System.Drawing.Point(5, 38);
            this.dgSubMajorAccount.Name = "dgSubMajorAccount";
            this.dgSubMajorAccount.RowHeadersWidth = 51;
            this.dgSubMajorAccount.RowTemplate.Height = 29;
            this.dgSubMajorAccount.Size = new System.Drawing.Size(1109, 421);
            this.dgSubMajorAccount.TabIndex = 0;
            // 
            // tabMajorAccount
            // 
            this.tabMajorAccount.Controls.Add(this.label2);
            this.tabMajorAccount.Controls.Add(this.cmbAccountGroup);
            this.tabMajorAccount.Controls.Add(this.dgMajorAccountGroup);
            this.tabMajorAccount.Location = new System.Drawing.Point(4, 24);
            this.tabMajorAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMajorAccount.Name = "tabMajorAccount";
            this.tabMajorAccount.Size = new System.Drawing.Size(1120, 463);
            this.tabMajorAccount.TabIndex = 3;
            this.tabMajorAccount.Text = "Major Account Group";
            this.tabMajorAccount.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Group";
            // 
            // cmbAccountGroup
            // 
            this.cmbAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountGroup.FormattingEnabled = true;
            this.cmbAccountGroup.Location = new System.Drawing.Point(99, 6);
            this.cmbAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAccountGroup.Name = "cmbAccountGroup";
            this.cmbAccountGroup.Size = new System.Drawing.Size(177, 23);
            this.cmbAccountGroup.TabIndex = 1;
            this.cmbAccountGroup.SelectionChangeCommitted += new System.EventHandler(this.cmbAccountGroup_SelectionChangeCommitted);
            // 
            // dgMajorAccountGroup
            // 
            this.dgMajorAccountGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMajorAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMajorAccountGroup.Location = new System.Drawing.Point(5, 36);
            this.dgMajorAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgMajorAccountGroup.Name = "dgMajorAccountGroup";
            this.dgMajorAccountGroup.RowHeadersWidth = 51;
            this.dgMajorAccountGroup.RowTemplate.Height = 29;
            this.dgMajorAccountGroup.Size = new System.Drawing.Size(1109, 421);
            this.dgMajorAccountGroup.TabIndex = 0;
            this.dgMajorAccountGroup.SelectionChanged += new System.EventHandler(this.dgMajorAccountGroup_SelectionChanged);
            // 
            // tabAccountGroup
            // 
            this.tabAccountGroup.Controls.Add(this.dgAccountGroup);
            this.tabAccountGroup.Location = new System.Drawing.Point(4, 24);
            this.tabAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAccountGroup.Name = "tabAccountGroup";
            this.tabAccountGroup.Size = new System.Drawing.Size(1120, 463);
            this.tabAccountGroup.TabIndex = 4;
            this.tabAccountGroup.Text = "Account Group";
            this.tabAccountGroup.UseVisualStyleBackColor = true;
            // 
            // dgAccountGroup
            // 
            this.dgAccountGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccountGroup.Location = new System.Drawing.Point(5, 4);
            this.dgAccountGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgAccountGroup.Name = "dgAccountGroup";
            this.dgAccountGroup.RowHeadersWidth = 51;
            this.dgAccountGroup.RowTemplate.Height = 29;
            this.dgAccountGroup.Size = new System.Drawing.Size(1111, 455);
            this.dgAccountGroup.TabIndex = 0;
            this.dgAccountGroup.SelectionChanged += new System.EventHandler(this.dgAccountGroup_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.BtnSubsidiary,
            this.BtnSetBalance});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1128, 50);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 47);
            this.btnAdd.Text = "Add...";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 47);
            this.btnEdit.Text = "Edit...";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // BtnSubsidiary
            // 
            this.BtnSubsidiary.Image = ((System.Drawing.Image)(resources.GetObject("BtnSubsidiary.Image")));
            this.BtnSubsidiary.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSubsidiary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSubsidiary.Name = "BtnSubsidiary";
            this.BtnSubsidiary.Size = new System.Drawing.Size(65, 47);
            this.BtnSubsidiary.Text = "Subsidiary";
            this.BtnSubsidiary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSubsidiary.Click += new System.EventHandler(this.BtnSubsidiary_Click);
            // 
            // BtnSetBalance
            // 
            this.BtnSetBalance.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetBalance.Image")));
            this.BtnSetBalance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSetBalance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSetBalance.Name = "BtnSetBalance";
            this.BtnSetBalance.Size = new System.Drawing.Size(80, 47);
            this.BtnSetBalance.Text = "Set Balance...";
            this.BtnSetBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1128, 563);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1144, 602);
            this.Name = "frmChartOfAccounts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Chart Of Accounts";
            this.Load += new System.EventHandler(this.frmChartOfAccounts_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneralLedgerAccounts)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneralLedgers.ResumeLayout(false);
            this.tabGeneralLedgers.PerformLayout();
            this.tabSubMajorAccount.ResumeLayout(false);
            this.tabSubMajorAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubMajorAccount)).EndInit();
            this.tabMajorAccount.ResumeLayout(false);
            this.tabMajorAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMajorAccountGroup)).EndInit();
            this.tabAccountGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountGroup)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cmbMajorAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnSubsidiary;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton BtnSetBalance;
        private System.Windows.Forms.ComboBox cmbFund;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbxGenLedgAccountGroup;
    }
}