
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
            cmbxFPP = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxAllotmentClass = new System.Windows.Forms.ComboBox();
            txtTotal = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecords = new System.Windows.Forms.ToolStripStatusLabel();
            springLbl = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnSupplementalAppropriations = new System.Windows.Forms.ToolStripButton();
            btnRealignment = new System.Windows.Forms.ToolStripButton();
            btnAugmentation = new System.Windows.Forms.ToolStripButton();
            lnkSelectAll = new System.Windows.Forms.LinkLabel();
            lnkClearSelection = new System.Windows.Forms.LinkLabel();
            panel1 = new System.Windows.Forms.Panel();
            dgBudgetAppropriations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgBudgetAppropriations).BeginInit();
            SuspendLayout();
            // 
            // cmbxFPP
            // 
            cmbxFPP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFPP.FormattingEnabled = true;
            cmbxFPP.Location = new System.Drawing.Point(474, 14);
            cmbxFPP.Name = "cmbxFPP";
            cmbxFPP.Size = new System.Drawing.Size(259, 23);
            cmbxFPP.TabIndex = 10;
            cmbxFPP.KeyDown += cmbxFPP_KeyDown;
            cmbxFPP.Validating += cmbxFPP_Validating;
            cmbxFPP.Validated += cmbxFPP_Validated;
            // 
            // nudYear
            // 
            nudYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudYear.BackColor = System.Drawing.Color.White;
            nudYear.Location = new System.Drawing.Point(1043, 14);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(146, 23);
            nudYear.TabIndex = 9;
            nudYear.Value = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.ValueChanged += NudYear_ValueChanged;
            nudYear.Validating += nudYear_Validating;
            nudYear.Validated += nudYear_Validated;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(891, 14);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(146, 23);
            cmbxFunds.TabIndex = 8;
            cmbxFunds.SelectedValueChanged += cmbxFundType_SelectedValueChanged;
            cmbxFunds.Validating += cmbxFunds_Validating;
            cmbxFunds.Validated += cmbxFunds_Validated;
            // 
            // cmbxAllotmentClass
            // 
            cmbxAllotmentClass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxAllotmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAllotmentClass.FormattingEnabled = true;
            cmbxAllotmentClass.Location = new System.Drawing.Point(739, 14);
            cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            cmbxAllotmentClass.Size = new System.Drawing.Size(146, 23);
            cmbxAllotmentClass.TabIndex = 6;
            cmbxAllotmentClass.SelectedValueChanged += cmbxAllotmentClass_SelectedValueChanged;
            cmbxAllotmentClass.Validating += cmbxAllotmentClass_Validating;
            cmbxAllotmentClass.Validated += cmbxAllotmentClass_Validated;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            txtTotal.BackColor = System.Drawing.SystemColors.Control;
            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtTotal.Location = new System.Drawing.Point(1057, 534);
            txtTotal.MaxLength = 999999;
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new System.Drawing.Size(132, 23);
            txtTotal.TabIndex = 4;
            txtTotal.Text = "0.00";
            txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtTotal.WordWrap = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(942, 538);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 15);
            label1.TabIndex = 3;
            label1.Text = "Total Appropriation";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel4, lblRecords, springLbl, toolStripStatusLabel6, lblDateEntry, toolStripStatusLabel5, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel1, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 563);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1201, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(49, 17);
            toolStripStatusLabel4.Text = "Records";
            // 
            // lblRecords
            // 
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new System.Drawing.Size(0, 17);
            // 
            // springLbl
            // 
            springLbl.Name = "springLbl";
            springLbl.Size = new System.Drawing.Size(916, 17);
            springLbl.Spring = true;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel6.Text = "Date Entry:";
            // 
            // lblDateEntry
            // 
            lblDateEntry.Name = "lblDateEntry";
            lblDateEntry.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel1.Text = "|";
            toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, btnSupplementalAppropriations, btnRealignment, btnAugmentation });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(1201, 50);
            toolStrip1.TabIndex = 9;
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
            btnAdd.Click += btnAdd_Click;
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
            btnEdit.Click += btnEdit_Click;
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
            btnDelete.Click += btnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // btnSupplementalAppropriations
            // 
            btnSupplementalAppropriations.Image = Properties.Resources.money_banknote_filled_money_coins_20px;
            btnSupplementalAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSupplementalAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSupplementalAppropriations.Name = "btnSupplementalAppropriations";
            btnSupplementalAppropriations.Size = new System.Drawing.Size(93, 39);
            btnSupplementalAppropriations.Text = "Supplemental...";
            btnSupplementalAppropriations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSupplementalAppropriations.Click += btnSupplementalAppropriations_Click;
            // 
            // btnRealignment
            // 
            btnRealignment.Image = Properties.Resources.modify_object_align_vertical_center_money_coins_20px;
            btnRealignment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnRealignment.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnRealignment.Name = "btnRealignment";
            btnRealignment.Size = new System.Drawing.Size(87, 39);
            btnRealignment.Text = "Realignment...";
            btnRealignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnRealignment.Click += btnRealignment_Click;
            // 
            // btnAugmentation
            // 
            btnAugmentation.Image = Properties.Resources.money_banknote_filled_archive_20px;
            btnAugmentation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAugmentation.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAugmentation.Name = "btnAugmentation";
            btnAugmentation.Size = new System.Drawing.Size(97, 39);
            btnAugmentation.Text = "Augmentation...";
            btnAugmentation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAugmentation.Click += btnAugmentation_Click;
            // 
            // lnkSelectAll
            // 
            lnkSelectAll.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            lnkSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lnkSelectAll.AutoSize = true;
            lnkSelectAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkSelectAll.LinkColor = System.Drawing.SystemColors.Highlight;
            lnkSelectAll.Location = new System.Drawing.Point(1038, 66);
            lnkSelectAll.Name = "lnkSelectAll";
            lnkSelectAll.Size = new System.Drawing.Size(55, 15);
            lnkSelectAll.TabIndex = 11;
            lnkSelectAll.TabStop = true;
            lnkSelectAll.Text = "Select All";
            lnkSelectAll.LinkClicked += lnkSelectAll_LinkClicked;
            // 
            // lnkClearSelection
            // 
            lnkClearSelection.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            lnkClearSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lnkClearSelection.AutoSize = true;
            lnkClearSelection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkClearSelection.LinkColor = System.Drawing.SystemColors.Highlight;
            lnkClearSelection.Location = new System.Drawing.Point(1104, 66);
            lnkClearSelection.Name = "lnkClearSelection";
            lnkClearSelection.Size = new System.Drawing.Size(85, 15);
            lnkClearSelection.TabIndex = 11;
            lnkClearSelection.TabStop = true;
            lnkClearSelection.Text = "Clear Selection";
            lnkClearSelection.LinkClicked += lnkClearSelection_LinkClicked;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgBudgetAppropriations);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1201, 513);
            panel1.TabIndex = 12;
            // 
            // dgBudgetAppropriations
            // 
            dgBudgetAppropriations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgBudgetAppropriations.Dock = System.Windows.Forms.DockStyle.Fill;
            dgBudgetAppropriations.Location = new System.Drawing.Point(4, 4);
            dgBudgetAppropriations.Name = "dgBudgetAppropriations";
            dgBudgetAppropriations.RowTemplate.Height = 25;
            dgBudgetAppropriations.Size = new System.Drawing.Size(1193, 505);
            dgBudgetAppropriations.TabIndex = 2;
            dgBudgetAppropriations.ColumnAdded += dgBudgetAppropriations_ColumnAdded;
            dgBudgetAppropriations.SelectionChanged += dgBudgetAppropriations_SelectionChanged;
            // 
            // frmBudgetAppropriations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(1201, 585);
            Controls.Add(panel1);
            Controls.Add(lnkClearSelection);
            Controls.Add(lnkSelectAll);
            Controls.Add(label1);
            Controls.Add(cmbxFPP);
            Controls.Add(nudYear);
            Controls.Add(cmbxAllotmentClass);
            Controls.Add(cmbxFunds);
            Controls.Add(txtTotal);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1217, 624);
            Name = "frmBudgetAppropriations";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Budget Appropriations";
            Load += frmBudgetAppropriations_Load;
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgBudgetAppropriations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ToolStripButton btnRealignment;
        private System.Windows.Forms.ToolStripButton btnAugmentation;
        private System.Windows.Forms.LinkLabel lnkSelectAll;
        private System.Windows.Forms.LinkLabel lnkClearSelection;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView dgBudgetAppropriations;
    }
}