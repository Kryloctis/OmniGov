
namespace AccountingSystem.Views.Manage.Realignment
{
    partial class frmRealignment
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRecordsCountsPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCounts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateEntryPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgRealignment = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalSupplementalAppropriations = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBudgetTotalAppropriation = new System.Windows.Forms.TextBox();
            this.txtAccountSelected = new System.Windows.Forms.TextBox();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignment)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(818, 50);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::AccountingSystem.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 47);
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::AccountingSystem.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 47);
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRecordsCountsPlaceHolder,
            this.lblRecordCounts,
            this.toolStripStatusLabel1,
            this.lblDateEntryPlaceHolder,
            this.lblDateEntry,
            this.toolStripStatusLabel3,
            this.lblCreatedAtPlaceHolder,
            this.lblCreatedAt,
            this.toolStripStatusLabel2,
            this.lblUpdatedAtPlaceHolder,
            this.lblUpdatedAt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(818, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRecordsCountsPlaceHolder
            // 
            this.labelRecordsCountsPlaceHolder.Name = "labelRecordsCountsPlaceHolder";
            this.labelRecordsCountsPlaceHolder.Size = new System.Drawing.Size(49, 17);
            this.labelRecordsCountsPlaceHolder.Text = "records:";
            // 
            // lblRecordCounts
            // 
            this.lblRecordCounts.Name = "lblRecordCounts";
            this.lblRecordCounts.Size = new System.Drawing.Size(13, 17);
            this.lblRecordCounts.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(525, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblDateEntryPlaceHolder
            // 
            this.lblDateEntryPlaceHolder.Name = "lblDateEntryPlaceHolder";
            this.lblDateEntryPlaceHolder.Size = new System.Drawing.Size(64, 17);
            this.lblDateEntryPlaceHolder.Text = "Date Entry:";
            // 
            // lblDateEntry
            // 
            this.lblDateEntry.Name = "lblDateEntry";
            this.lblDateEntry.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCreatedAtPlaceHolder
            // 
            this.lblCreatedAtPlaceHolder.Name = "lblCreatedAtPlaceHolder";
            this.lblCreatedAtPlaceHolder.Size = new System.Drawing.Size(64, 17);
            this.lblCreatedAtPlaceHolder.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUpdatedAtPlaceHolder
            // 
            this.lblUpdatedAtPlaceHolder.Name = "lblUpdatedAtPlaceHolder";
            this.lblUpdatedAtPlaceHolder.Size = new System.Drawing.Size(68, 17);
            this.lblUpdatedAtPlaceHolder.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // dgRealignment
            // 
            this.dgRealignment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRealignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRealignment.Location = new System.Drawing.Point(12, 53);
            this.dgRealignment.Name = "dgRealignment";
            this.dgRealignment.RowTemplate.Height = 25;
            this.dgRealignment.Size = new System.Drawing.Size(794, 326);
            this.dgRealignment.TabIndex = 10;
            this.dgRealignment.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total Realigned Appropriation";
            // 
            // txtTotalSupplementalAppropriations
            // 
            this.txtTotalSupplementalAppropriations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSupplementalAppropriations.Location = new System.Drawing.Point(648, 385);
            this.txtTotalSupplementalAppropriations.Name = "txtTotalSupplementalAppropriations";
            this.txtTotalSupplementalAppropriations.ReadOnly = true;
            this.txtTotalSupplementalAppropriations.Size = new System.Drawing.Size(158, 23);
            this.txtTotalSupplementalAppropriations.TabIndex = 11;
            this.txtTotalSupplementalAppropriations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Budget Total Appropriation : ";
            // 
            // txtBudgetTotalAppropriation
            // 
            this.txtBudgetTotalAppropriation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBudgetTotalAppropriation.Location = new System.Drawing.Point(181, 385);
            this.txtBudgetTotalAppropriation.Name = "txtBudgetTotalAppropriation";
            this.txtBudgetTotalAppropriation.ReadOnly = true;
            this.txtBudgetTotalAppropriation.Size = new System.Drawing.Size(158, 23);
            this.txtBudgetTotalAppropriation.TabIndex = 15;
            this.txtBudgetTotalAppropriation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAccountSelected
            // 
            this.txtAccountSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountSelected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountSelected.Enabled = false;
            this.txtAccountSelected.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAccountSelected.Location = new System.Drawing.Point(127, 22);
            this.txtAccountSelected.Name = "txtAccountSelected";
            this.txtAccountSelected.ReadOnly = true;
            this.txtAccountSelected.Size = new System.Drawing.Size(677, 18);
            this.txtAccountSelected.TabIndex = 17;
            this.txtAccountSelected.Text = "Selected Account";
            this.txtAccountSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmRealignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(818, 437);
            this.Controls.Add(this.txtAccountSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBudgetTotalAppropriation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalSupplementalAppropriations);
            this.Controls.Add(this.dgRealignment);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRealignment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Budget Appropriations > Realignment";
            this.Load += new System.EventHandler(this.frmRealignment_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel labelRecordsCountsPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblRecordCounts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntryPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntry;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.DataGridView dgRealignment;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotalSupplementalAppropriations;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtBudgetTotalAppropriation;
        internal System.Windows.Forms.TextBox txtAccountSelected;
    }
}