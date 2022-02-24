
namespace AccountingSystem.Views.Manage.FunctionProgramProject
{
    partial class frmFunctionProgramProject
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSubFPP = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabControlFunctionProgramProject = new System.Windows.Forms.TabControl();
            this.tabFunctionProgramProject = new System.Windows.Forms.TabPage();
            this.chckbxSpecial = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServiceName = new System.Windows.Forms.ComboBox();
            this.dgFunctionalProgramProject = new System.Windows.Forms.DataGridView();
            this.tabFunctionalClassificationService = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSectorName = new System.Windows.Forms.ComboBox();
            this.dgFuntionalClassificationService = new System.Windows.Forms.DataGridView();
            this.btnLoadAllFsc = new System.Windows.Forms.Button();
            this.tabFunctionalClassification = new System.Windows.Forms.TabPage();
            this.dgFunctionalClassification = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.tabControlFunctionProgramProject.SuspendLayout();
            this.tabFunctionProgramProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalProgramProject)).BeginInit();
            this.tabFunctionalClassificationService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuntionalClassificationService)).BeginInit();
            this.tabFunctionalClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalClassification)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnSubFPP,
            this.txtSearch,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 5, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(859, 55);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::AccountingSystem.Properties.Resources.edit;
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
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.delete;
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
            // btnSubFPP
            // 
            this.btnSubFPP.Image = global::AccountingSystem.Properties.Resources.control_tree_filled_28px;
            this.btnSubFPP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSubFPP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubFPP.Name = "btnSubFPP";
            this.btnSubFPP.Size = new System.Drawing.Size(63, 47);
            this.btnSubFPP.Text = "Sub FPP...";
            this.btnSubFPP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSubFPP.Click += new System.EventHandler(this.toolStripBtnOthers_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(219, 50);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 47);
            this.toolStripLabel1.Text = "Search";
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabControlFunctionProgramProject
            // 
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionProgramProject);
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionalClassificationService);
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionalClassification);
            this.tabControlFunctionProgramProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFunctionProgramProject.ItemSize = new System.Drawing.Size(104, 20);
            this.tabControlFunctionProgramProject.Location = new System.Drawing.Point(0, 55);
            this.tabControlFunctionProgramProject.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlFunctionProgramProject.Name = "tabControlFunctionProgramProject";
            this.tabControlFunctionProgramProject.Padding = new System.Drawing.Point(10, 3);
            this.tabControlFunctionProgramProject.SelectedIndex = 0;
            this.tabControlFunctionProgramProject.Size = new System.Drawing.Size(859, 421);
            this.tabControlFunctionProgramProject.TabIndex = 8;
            this.tabControlFunctionProgramProject.SelectedIndexChanged += new System.EventHandler(this.dgFunctionalClassification_SelectedIndexChanged);
            // 
            // tabFunctionProgramProject
            // 
            this.tabFunctionProgramProject.Controls.Add(this.chckbxSpecial);
            this.tabFunctionProgramProject.Controls.Add(this.label2);
            this.tabFunctionProgramProject.Controls.Add(this.cmbServiceName);
            this.tabFunctionProgramProject.Controls.Add(this.dgFunctionalProgramProject);
            this.tabFunctionProgramProject.Location = new System.Drawing.Point(4, 24);
            this.tabFunctionProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionProgramProject.Name = "tabFunctionProgramProject";
            this.tabFunctionProgramProject.Size = new System.Drawing.Size(851, 393);
            this.tabFunctionProgramProject.TabIndex = 1;
            this.tabFunctionProgramProject.Text = "Function, Program and Project";
            // 
            // chckbxSpecial
            // 
            this.chckbxSpecial.AutoSize = true;
            this.chckbxSpecial.Location = new System.Drawing.Point(780, 11);
            this.chckbxSpecial.Name = "chckbxSpecial";
            this.chckbxSpecial.Size = new System.Drawing.Size(63, 19);
            this.chckbxSpecial.TabIndex = 20;
            this.chckbxSpecial.Text = "Special";
            this.chckbxSpecial.UseVisualStyleBackColor = true;
            this.chckbxSpecial.CheckedChanged += new System.EventHandler(this.chckbxSpecial_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Service Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbServiceName
            // 
            this.cmbServiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceName.FormattingEnabled = true;
            this.cmbServiceName.Location = new System.Drawing.Point(93, 9);
            this.cmbServiceName.Name = "cmbServiceName";
            this.cmbServiceName.Size = new System.Drawing.Size(346, 23);
            this.cmbServiceName.TabIndex = 19;
            // 
            // dgFunctionalProgramProject
            // 
            this.dgFunctionalProgramProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFunctionalProgramProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFunctionalProgramProject.Location = new System.Drawing.Point(8, 37);
            this.dgFunctionalProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgFunctionalProgramProject.Name = "dgFunctionalProgramProject";
            this.dgFunctionalProgramProject.RowHeadersWidth = 51;
            this.dgFunctionalProgramProject.RowTemplate.Height = 29;
            this.dgFunctionalProgramProject.Size = new System.Drawing.Size(835, 354);
            this.dgFunctionalProgramProject.TabIndex = 5;
            this.dgFunctionalProgramProject.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFunctionalProgramProject_RowHeaderMouseDoubleClick);
            this.dgFunctionalProgramProject.SelectionChanged += new System.EventHandler(this.dgFunctionalProgramProject_SelectionChanged);
            // 
            // tabFunctionalClassificationService
            // 
            this.tabFunctionalClassificationService.Controls.Add(this.label1);
            this.tabFunctionalClassificationService.Controls.Add(this.cmbSectorName);
            this.tabFunctionalClassificationService.Controls.Add(this.dgFuntionalClassificationService);
            this.tabFunctionalClassificationService.Controls.Add(this.btnLoadAllFsc);
            this.tabFunctionalClassificationService.Location = new System.Drawing.Point(4, 24);
            this.tabFunctionalClassificationService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassificationService.Name = "tabFunctionalClassificationService";
            this.tabFunctionalClassificationService.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassificationService.Size = new System.Drawing.Size(851, 393);
            this.tabFunctionalClassificationService.TabIndex = 0;
            this.tabFunctionalClassificationService.Text = "Functional Classification Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sector Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSectorName
            // 
            this.cmbSectorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectorName.FormattingEnabled = true;
            this.cmbSectorName.Location = new System.Drawing.Point(89, 10);
            this.cmbSectorName.Name = "cmbSectorName";
            this.cmbSectorName.Size = new System.Drawing.Size(330, 23);
            this.cmbSectorName.TabIndex = 16;
            this.cmbSectorName.SelectionChangeCommitted += new System.EventHandler(this.cmbSectorName_SelectionChangeCommitted_2);
            // 
            // dgFuntionalClassificationService
            // 
            this.dgFuntionalClassificationService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFuntionalClassificationService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuntionalClassificationService.Location = new System.Drawing.Point(8, 39);
            this.dgFuntionalClassificationService.Name = "dgFuntionalClassificationService";
            this.dgFuntionalClassificationService.RowHeadersWidth = 51;
            this.dgFuntionalClassificationService.RowTemplate.Height = 25;
            this.dgFuntionalClassificationService.Size = new System.Drawing.Size(837, 349);
            this.dgFuntionalClassificationService.TabIndex = 17;
            this.dgFuntionalClassificationService.SelectionChanged += new System.EventHandler(this.dgFuntionalClassificationService_SelectionChanged_1);
            // 
            // btnLoadAllFsc
            // 
            this.btnLoadAllFsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadAllFsc.Location = new System.Drawing.Point(770, 11);
            this.btnLoadAllFsc.Name = "btnLoadAllFsc";
            this.btnLoadAllFsc.Size = new System.Drawing.Size(75, 22);
            this.btnLoadAllFsc.TabIndex = 15;
            this.btnLoadAllFsc.Text = "Load All";
            this.btnLoadAllFsc.UseVisualStyleBackColor = true;
            this.btnLoadAllFsc.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // tabFunctionalClassification
            // 
            this.tabFunctionalClassification.Controls.Add(this.dgFunctionalClassification);
            this.tabFunctionalClassification.Location = new System.Drawing.Point(4, 24);
            this.tabFunctionalClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassification.Name = "tabFunctionalClassification";
            this.tabFunctionalClassification.Size = new System.Drawing.Size(851, 393);
            this.tabFunctionalClassification.TabIndex = 2;
            this.tabFunctionalClassification.Text = "Functional Classifications";
            // 
            // dgFunctionalClassification
            // 
            this.dgFunctionalClassification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFunctionalClassification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFunctionalClassification.Location = new System.Drawing.Point(0, 0);
            this.dgFunctionalClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgFunctionalClassification.Name = "dgFunctionalClassification";
            this.dgFunctionalClassification.RowHeadersWidth = 51;
            this.dgFunctionalClassification.RowTemplate.Height = 29;
            this.dgFunctionalClassification.Size = new System.Drawing.Size(851, 393);
            this.dgFunctionalClassification.TabIndex = 5;
            this.dgFunctionalClassification.SelectionChanged += new System.EventHandler(this.dgFunctionalClassification_SelectionChanged);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(859, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
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
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(649, 17);
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
            // frmFunctionProgramProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 498);
            this.Controls.Add(this.tabControlFunctionProgramProject);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(874, 537);
            this.Name = "frmFunctionProgramProject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Function, Program & Project...";
            this.Load += new System.EventHandler(this.frmFunctionProgramProject_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlFunctionProgramProject.ResumeLayout(false);
            this.tabFunctionProgramProject.ResumeLayout(false);
            this.tabFunctionProgramProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalProgramProject)).EndInit();
            this.tabFunctionalClassificationService.ResumeLayout(false);
            this.tabFunctionalClassificationService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuntionalClassificationService)).EndInit();
            this.tabFunctionalClassification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalClassification)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.TabControl tabControlFunctionProgramProject;
        private System.Windows.Forms.TabPage tabFunctionalClassification;
        private System.Windows.Forms.TabPage tabFunctionalClassificationService;
        private System.Windows.Forms.TabPage tabFunctionProgramProject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.DataGridView dgFunctionalClassification;
        private System.Windows.Forms.DataGridView dgFunctionalProgramProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLoadAllFsc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ComboBox cmbSectorName;
		private System.Windows.Forms.DataGridView dgFuntionalClassificationService;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSubFPP;
        internal System.Windows.Forms.ComboBox cmbServiceName;
        private System.Windows.Forms.CheckBox chckbxSpecial;
    }
}