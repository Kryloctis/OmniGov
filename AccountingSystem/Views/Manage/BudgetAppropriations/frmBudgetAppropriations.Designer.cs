
namespace AccountingSystem.Views.Manage.BudgetAppropriations
{
    partial class frmBudgetAppropriations
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
            this.dgBudgetAppropriations = new System.Windows.Forms.DataGridView();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.cmbxAllotmentClass = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.springLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSupplementalAppropriations = new System.Windows.Forms.ToolStripButton();
            this.btnAugmentation = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBudgetAppropriations
            // 
            this.dgBudgetAppropriations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBudgetAppropriations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetAppropriations.Location = new System.Drawing.Point(12, 53);
            this.dgBudgetAppropriations.Name = "dgBudgetAppropriations";
            this.dgBudgetAppropriations.RowTemplate.Height = 25;
            this.dgBudgetAppropriations.Size = new System.Drawing.Size(1177, 430);
            this.dgBudgetAppropriations.TabIndex = 1;
            this.dgBudgetAppropriations.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(474, 12);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(259, 23);
            this.cmbxFPP.TabIndex = 10;
            this.cmbxFPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxFPP_KeyDown);
            // 
            // nudYear
            // 
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Location = new System.Drawing.Point(1043, 12);
            this.nudYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1987,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.ReadOnly = true;
            this.nudYear.Size = new System.Drawing.Size(146, 23);
            this.nudYear.TabIndex = 9;
            this.nudYear.Value = new decimal(new int[] {
            1987,
            0,
            0,
            0});
            this.nudYear.ValueChanged += new System.EventHandler(this.NudYear_ValueChanged);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(891, 12);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(146, 23);
            this.cmbxFunds.TabIndex = 8;
            this.cmbxFunds.SelectedValueChanged += new System.EventHandler(this.cmbxFundType_SelectedValueChanged);
            // 
            // cmbxAllotmentClass
            // 
            this.cmbxAllotmentClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxAllotmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClass.FormattingEnabled = true;
            this.cmbxAllotmentClass.Location = new System.Drawing.Point(739, 12);
            this.cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            this.cmbxAllotmentClass.Size = new System.Drawing.Size(146, 23);
            this.cmbxAllotmentClass.TabIndex = 6;
            this.cmbxAllotmentClass.SelectedValueChanged += new System.EventHandler(this.cmbxAllotmentClass_SelectedValueChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(1057, 489);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 23);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(942, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Appropriation";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.lblRecords,
            this.springLbl,
            this.toolStripStatusLabel6,
            this.lblDateEntry,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel2,
            this.lblCreatedAt,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.lblUpdatedAt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1201, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel4.Text = "Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(0, 17);
            // 
            // springLbl
            // 
            this.springLbl.Name = "springLbl";
            this.springLbl.Size = new System.Drawing.Size(913, 17);
            this.springLbl.Spring = true;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel6.Text = "Date Entry:";
            // 
            // lblDateEntry
            // 
            this.lblDateEntry.Name = "lblDateEntry";
            this.lblDateEntry.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel5.Text = "|";
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnSupplementalAppropriations,
            this.btnAugmentation});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 50);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::AccountingSystem.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(43, 47);
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::AccountingSystem.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 47);
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnSupplementalAppropriations
            // 
            this.btnSupplementalAppropriations.Image = global::AccountingSystem.Properties.Resources.supplemental_appropriations_28px;
            this.btnSupplementalAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupplementalAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupplementalAppropriations.Name = "btnSupplementalAppropriations";
            this.btnSupplementalAppropriations.Size = new System.Drawing.Size(84, 47);
            this.btnSupplementalAppropriations.Text = "Supplemental";
            this.btnSupplementalAppropriations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSupplementalAppropriations.Click += new System.EventHandler(this.btnSupplementalAppropriations_Click);
            // 
            // btnAugmentation
            // 
            this.btnAugmentation.Enabled = false;
            this.btnAugmentation.Image = global::AccountingSystem.Properties.Resources.augmentation_28px;
            this.btnAugmentation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAugmentation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAugmentation.Name = "btnAugmentation";
            this.btnAugmentation.Size = new System.Drawing.Size(88, 47);
            this.btnAugmentation.Text = "Augmentation";
            this.btnAugmentation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAugmentation.Click += new System.EventHandler(this.btnAugmentation_Click);
            // 
            // frmBudgetAppropriations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1201, 540);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.cmbxAllotmentClass);
            this.Controls.Add(this.cmbxFunds);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgBudgetAppropriations);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1217, 579);
            this.Name = "frmBudgetAppropriations";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Budget Appropriations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBudgetAppropriations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView dgBudgetAppropriations;
        private System.Windows.Forms.ToolStripButton btnAllotment;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClass;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel springLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        internal System.Windows.Forms.ToolStripStatusLabel lblRecords;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntry;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSupplementalAppropriations;
        private System.Windows.Forms.ToolStripButton btnAugmentation;
    }
}