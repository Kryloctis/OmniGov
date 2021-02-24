
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
            this.tabSubsidiaryLedgers = new System.Windows.Forms.TabPage();
            this.tabGeneralLedgers = new System.Windows.Forms.TabPage();
            this.tabSubMajorAccount = new System.Windows.Forms.TabPage();
            this.tabMajorAccount = new System.Windows.Forms.TabPage();
            this.cmbAccountGroup = new System.Windows.Forms.ComboBox();
            this.dgMajorAccountGroup = new System.Windows.Forms.DataGridView();
            this.tabAccountGroup = new System.Windows.Forms.TabPage();
            this.dgAccountGroup = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneralLedgerAccounts)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneralLedgers.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 20);
            this.toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(17, 20);
            this.lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(717, 20);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 20);
            this.toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(87, 20);
            this.toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(0, 20);
            // 
            // dgGeneralLedgerAccounts
            // 
            this.dgGeneralLedgerAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGeneralLedgerAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGeneralLedgerAccounts.Location = new System.Drawing.Point(3, 3);
            this.dgGeneralLedgerAccounts.Name = "dgGeneralLedgerAccounts";
            this.dgGeneralLedgerAccounts.RowHeadersWidth = 51;
            this.dgGeneralLedgerAccounts.RowTemplate.Height = 29;
            this.dgGeneralLedgerAccounts.Size = new System.Drawing.Size(944, 541);
            this.dgGeneralLedgerAccounts.TabIndex = 4;
            this.dgGeneralLedgerAccounts.SelectionChanged += new System.EventHandler(this.dgGeneralLedgerAccounts_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabSubsidiaryLedgers);
            this.tabControl1.Controls.Add(this.tabGeneralLedgers);
            this.tabControl1.Controls.Add(this.tabSubMajorAccount);
            this.tabControl1.Controls.Add(this.tabMajorAccount);
            this.tabControl1.Controls.Add(this.tabAccountGroup);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 583);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabSubsidiaryLedgers
            // 
            this.tabSubsidiaryLedgers.Location = new System.Drawing.Point(4, 32);
            this.tabSubsidiaryLedgers.Name = "tabSubsidiaryLedgers";
            this.tabSubsidiaryLedgers.Size = new System.Drawing.Size(950, 547);
            this.tabSubsidiaryLedgers.TabIndex = 2;
            this.tabSubsidiaryLedgers.Text = "Subsidiary Ledgers";
            this.tabSubsidiaryLedgers.UseVisualStyleBackColor = true;
            // 
            // tabGeneralLedgers
            // 
            this.tabGeneralLedgers.Controls.Add(this.dgGeneralLedgerAccounts);
            this.tabGeneralLedgers.Location = new System.Drawing.Point(4, 32);
            this.tabGeneralLedgers.Name = "tabGeneralLedgers";
            this.tabGeneralLedgers.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralLedgers.Size = new System.Drawing.Size(950, 547);
            this.tabGeneralLedgers.TabIndex = 0;
            this.tabGeneralLedgers.Text = "General Ledgers";
            this.tabGeneralLedgers.UseVisualStyleBackColor = true;
            // 
            // tabSubMajorAccount
            // 
            this.tabSubMajorAccount.Location = new System.Drawing.Point(4, 32);
            this.tabSubMajorAccount.Name = "tabSubMajorAccount";
            this.tabSubMajorAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubMajorAccount.Size = new System.Drawing.Size(950, 547);
            this.tabSubMajorAccount.TabIndex = 1;
            this.tabSubMajorAccount.Text = "Sub Major Account Group";
            this.tabSubMajorAccount.UseVisualStyleBackColor = true;
            // 
            // tabMajorAccount
            // 
            this.tabMajorAccount.Controls.Add(this.cmbAccountGroup);
            this.tabMajorAccount.Controls.Add(this.dgMajorAccountGroup);
            this.tabMajorAccount.Location = new System.Drawing.Point(4, 32);
            this.tabMajorAccount.Name = "tabMajorAccount";
            this.tabMajorAccount.Size = new System.Drawing.Size(950, 547);
            this.tabMajorAccount.TabIndex = 3;
            this.tabMajorAccount.Text = "Major Account Group";
            this.tabMajorAccount.UseVisualStyleBackColor = true;
            // 
            // cmbAccountGroup
            // 
            this.cmbAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountGroup.FormattingEnabled = true;
            this.cmbAccountGroup.Location = new System.Drawing.Point(3, 3);
            this.cmbAccountGroup.Name = "cmbAccountGroup";
            this.cmbAccountGroup.Size = new System.Drawing.Size(202, 28);
            this.cmbAccountGroup.TabIndex = 1;
            this.cmbAccountGroup.SelectionChangeCommitted += new System.EventHandler(this.cmbAccountGroup_SelectionChangeCommitted);
            // 
            // dgMajorAccountGroup
            // 
            this.dgMajorAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMajorAccountGroup.Location = new System.Drawing.Point(0, 37);
            this.dgMajorAccountGroup.Name = "dgMajorAccountGroup";
            this.dgMajorAccountGroup.RowHeadersWidth = 51;
            this.dgMajorAccountGroup.RowTemplate.Height = 29;
            this.dgMajorAccountGroup.Size = new System.Drawing.Size(950, 510);
            this.dgMajorAccountGroup.TabIndex = 0;
            this.dgMajorAccountGroup.SelectionChanged += new System.EventHandler(this.dgMajorAccountGroup_SelectionChanged);
            // 
            // tabAccountGroup
            // 
            this.tabAccountGroup.Controls.Add(this.dgAccountGroup);
            this.tabAccountGroup.Location = new System.Drawing.Point(4, 32);
            this.tabAccountGroup.Name = "tabAccountGroup";
            this.tabAccountGroup.Size = new System.Drawing.Size(950, 547);
            this.tabAccountGroup.TabIndex = 4;
            this.tabAccountGroup.Text = "Account Group";
            this.tabAccountGroup.UseVisualStyleBackColor = true;
            // 
            // dgAccountGroup
            // 
            this.dgAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccountGroup.Location = new System.Drawing.Point(3, 3);
            this.dgAccountGroup.Name = "dgAccountGroup";
            this.dgAccountGroup.RowHeadersWidth = 51;
            this.dgAccountGroup.RowTemplate.Height = 29;
            this.dgAccountGroup.Size = new System.Drawing.Size(944, 541);
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
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 51);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 48);
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
            this.btnEdit.Size = new System.Drawing.Size(48, 48);
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
            this.btnDelete.Size = new System.Drawing.Size(57, 48);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(46, 48);
            this.btnFind.Text = "Filter";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 666);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "frmChartOfAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Chart Of Accounts";
            this.Load += new System.EventHandler(this.frmChartOfAccounts_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneralLedgerAccounts)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneralLedgers.ResumeLayout(false);
            this.tabMajorAccount.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabSubsidiaryLedgers;
        private System.Windows.Forms.TabPage tabMajorAccount;
        private System.Windows.Forms.TabPage tabAccountGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.DataGridView dgAccountGroup;
        private System.Windows.Forms.DataGridView dgMajorAccountGroup;
        private System.Windows.Forms.ComboBox cmbAccountGroup;
    }
}