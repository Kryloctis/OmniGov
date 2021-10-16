
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRealignment));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateEntryPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalRealignmentAppropriation = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRealignedFrom = new System.Windows.Forms.TabPage();
            this.dgRealignmentFrom = new System.Windows.Forms.DataGridView();
            this.tabRealignedTo = new System.Windows.Forms.TabPage();
            this.dgRealignmentTo = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRealignedFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignmentFrom)).BeginInit();
            this.tabRealignedTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignmentTo)).BeginInit();
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(587, 17);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total Realignment Appropriation";
            // 
            // txtTotalRealignmentAppropriation
            // 
            this.txtTotalRealignmentAppropriation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRealignmentAppropriation.Location = new System.Drawing.Point(648, 389);
            this.txtTotalRealignmentAppropriation.Name = "txtTotalRealignmentAppropriation";
            this.txtTotalRealignmentAppropriation.ReadOnly = true;
            this.txtTotalRealignmentAppropriation.Size = new System.Drawing.Size(158, 23);
            this.txtTotalRealignmentAppropriation.TabIndex = 11;
            this.txtTotalRealignmentAppropriation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRealignedFrom);
            this.tabControl1.Controls.Add(this.tabRealignedTo);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 335);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabRealignedFrom
            // 
            this.tabRealignedFrom.Controls.Add(this.dgRealignmentFrom);
            this.tabRealignedFrom.ImageIndex = 1;
            this.tabRealignedFrom.Location = new System.Drawing.Point(4, 24);
            this.tabRealignedFrom.Name = "tabRealignedFrom";
            this.tabRealignedFrom.Padding = new System.Windows.Forms.Padding(3);
            this.tabRealignedFrom.Size = new System.Drawing.Size(810, 307);
            this.tabRealignedFrom.TabIndex = 0;
            this.tabRealignedFrom.Text = "Realigned From";
            this.tabRealignedFrom.ToolTipText = "Accounts Realigned to this account.";
            this.tabRealignedFrom.UseVisualStyleBackColor = true;
            // 
            // dgRealignmentFrom
            // 
            this.dgRealignmentFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRealignmentFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRealignmentFrom.Location = new System.Drawing.Point(3, 3);
            this.dgRealignmentFrom.Name = "dgRealignmentFrom";
            this.dgRealignmentFrom.RowTemplate.Height = 25;
            this.dgRealignmentFrom.Size = new System.Drawing.Size(804, 301);
            this.dgRealignmentFrom.TabIndex = 12;
            this.dgRealignmentFrom.SelectionChanged += new System.EventHandler(this.dgRealignmentFrom_SelectionChanged);
            // 
            // tabRealignedTo
            // 
            this.tabRealignedTo.Controls.Add(this.dgRealignmentTo);
            this.tabRealignedTo.ImageIndex = 0;
            this.tabRealignedTo.Location = new System.Drawing.Point(4, 24);
            this.tabRealignedTo.Name = "tabRealignedTo";
            this.tabRealignedTo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRealignedTo.Size = new System.Drawing.Size(810, 307);
            this.tabRealignedTo.TabIndex = 1;
            this.tabRealignedTo.Text = "Realigned To";
            this.tabRealignedTo.ToolTipText = "Realigned to other accounts";
            this.tabRealignedTo.UseVisualStyleBackColor = true;
            // 
            // dgRealignmentTo
            // 
            this.dgRealignmentTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRealignmentTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRealignmentTo.Location = new System.Drawing.Point(3, 3);
            this.dgRealignmentTo.Name = "dgRealignmentTo";
            this.dgRealignmentTo.RowTemplate.Height = 25;
            this.dgRealignmentTo.Size = new System.Drawing.Size(804, 301);
            this.dgRealignmentTo.TabIndex = 11;
            this.dgRealignmentTo.SelectionChanged += new System.EventHandler(this.dgRealignmentTo_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow-up@18px.png");
            this.imageList1.Images.SetKeyName(1, "arrow-down@18px.png");
            // 
            // frmRealignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(818, 437);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalRealignmentAppropriation);
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
            this.tabControl1.ResumeLayout(false);
            this.tabRealignedFrom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignmentFrom)).EndInit();
            this.tabRealignedTo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRealignmentTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntryPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntry;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.DataGridView dgRealignmentTo;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotalRealignmentAppropriation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRealignedFrom;
        private System.Windows.Forms.TabPage tabRealignedTo;
        private System.Windows.Forms.DataGridView dgRealignmentFrom;
        private System.Windows.Forms.ImageList imageList1;
    }
}