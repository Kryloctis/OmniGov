
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnARODetails = new System.Windows.Forms.ToolStripButton();
            this.cmbxYear = new System.Windows.Forms.ToolStripComboBox();
            this.cmbxFundType = new System.Windows.Forms.ToolStripComboBox();
            this.cmbxAllotmentClass = new System.Windows.Forms.ToolStripComboBox();
            this.dgFPP = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBudgetAppropriations
            // 
            this.dgBudgetAppropriations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBudgetAppropriations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetAppropriations.Location = new System.Drawing.Point(3, 53);
            this.dgBudgetAppropriations.Name = "dgBudgetAppropriations";
            this.dgBudgetAppropriations.RowTemplate.Height = 25;
            this.dgBudgetAppropriations.Size = new System.Drawing.Size(983, 441);
            this.dgBudgetAppropriations.TabIndex = 1;
            this.dgBudgetAppropriations.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            this.dgBudgetAppropriations.SelectionChanged += new System.EventHandler(this.dgBudgetAppropriations_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnARODetails,
            this.cmbxYear,
            this.cmbxFundType,
            this.cmbxAllotmentClass});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(998, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::AccountingSystem.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 47);
            this.btnAdd.Text = "Add...";
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
            this.btnEdit.Size = new System.Drawing.Size(40, 47);
            this.btnEdit.Text = "Edit...";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnARODetails
            // 
            this.btnARODetails.Enabled = false;
            this.btnARODetails.Image = global::AccountingSystem.Properties.Resources.give_money_28px;
            this.btnARODetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnARODetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnARODetails.Name = "btnARODetails";
            this.btnARODetails.Size = new System.Drawing.Size(82, 47);
            this.btnARODetails.Text = "ARO Details...";
            this.btnARODetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cmbxYear
            // 
            this.cmbxYear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbxYear.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.cmbxYear.Name = "cmbxYear";
            this.cmbxYear.Size = new System.Drawing.Size(121, 50);
            // 
            // cmbxFundType
            // 
            this.cmbxFundType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbxFundType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFundType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbxFundType.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.cmbxFundType.Name = "cmbxFundType";
            this.cmbxFundType.Size = new System.Drawing.Size(150, 50);
            // 
            // cmbxAllotmentClass
            // 
            this.cmbxAllotmentClass.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbxAllotmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClass.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbxAllotmentClass.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            this.cmbxAllotmentClass.Size = new System.Drawing.Size(150, 50);
            // 
            // dgFPP
            // 
            this.dgFPP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFPP.Location = new System.Drawing.Point(13, 12);
            this.dgFPP.Name = "dgFPP";
            this.dgFPP.RowTemplate.Height = 25;
            this.dgFPP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFPP.Size = new System.Drawing.Size(284, 482);
            this.dgFPP.TabIndex = 3;
            this.dgFPP.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFPP_RowHeaderMouseDoubleClick);
            this.dgFPP.SelectionChanged += new System.EventHandler(this.dgFPP_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgFPP);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTotal);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.dgBudgetAppropriations);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1302, 538);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 7;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(854, 500);
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
            this.label1.Location = new System.Drawing.Point(739, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Appropriation";
            // 
            // frmBudgetAppropriations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1302, 538);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1318, 575);
            this.Name = "frmBudgetAppropriations";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Budget Appropriations";
            this.Load += new System.EventHandler(this.frmBudgetAppropriationsNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnAdd;
        internal System.Windows.Forms.ToolStripButton btnEdit;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        internal System.Windows.Forms.ToolStripComboBox cmbxAllotmentClass;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStripComboBox cmbxFundType;
        internal System.Windows.Forms.ToolStripComboBox cmbxYear;
        internal System.Windows.Forms.DataGridView dgFPP;
        internal System.Windows.Forms.DataGridView dgBudgetAppropriations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAllotment;
        internal System.Windows.Forms.ToolStripButton btnARODetails;
        internal System.Windows.Forms.TextBox txtTotal;
    }
}