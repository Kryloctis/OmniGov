
namespace LFS.Views.Manage.FunctionProgramProject
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
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnSubFPP = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            tabControlFunctionProgramProject = new System.Windows.Forms.TabControl();
            tabFunctionProgramProject = new System.Windows.Forms.TabPage();
            chckbxSpecial = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            cmbServiceName = new System.Windows.Forms.ComboBox();
            dgFunctionalProgramProject = new System.Windows.Forms.DataGridView();
            tabFunctionalClassificationService = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            cmbxSector = new System.Windows.Forms.ComboBox();
            dgFuntionalClassificationServices = new System.Windows.Forms.DataGridView();
            tabFunctionalClassification = new System.Windows.Forms.TabPage();
            dgFunctionalClassification = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStrip1.SuspendLayout();
            tabControlFunctionProgramProject.SuspendLayout();
            tabFunctionProgramProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFunctionalProgramProject).BeginInit();
            tabFunctionalClassificationService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFuntionalClassificationServices).BeginInit();
            tabFunctionalClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFunctionalClassification).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, btnSubFPP, txtSearch, toolStripLabel1 });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(5, 5, 1, 0);
            toolStrip1.Size = new System.Drawing.Size(859, 47);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(42, 47);
            btnAdd.Text = "Add...";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(40, 47);
            btnEdit.Text = "Edit...";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 47);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += BtnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnSubFPP
            // 
            btnSubFPP.Image = Properties.Resources.control_tree_filled_28px;
            btnSubFPP.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSubFPP.Name = "btnSubFPP";
            btnSubFPP.Size = new System.Drawing.Size(63, 39);
            btnSubFPP.Text = "Sub FPP...";
            btnSubFPP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSubFPP.Click += toolStripBtnOthers_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BackColor = System.Drawing.SystemColors.Window;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.ForeColor = System.Drawing.Color.Black;
            txtSearch.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(219, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tabControlFunctionProgramProject
            // 
            tabControlFunctionProgramProject.Controls.Add(tabFunctionProgramProject);
            tabControlFunctionProgramProject.Controls.Add(tabFunctionalClassificationService);
            tabControlFunctionProgramProject.Controls.Add(tabFunctionalClassification);
            tabControlFunctionProgramProject.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlFunctionProgramProject.ItemSize = new System.Drawing.Size(104, 20);
            tabControlFunctionProgramProject.Location = new System.Drawing.Point(0, 47);
            tabControlFunctionProgramProject.Margin = new System.Windows.Forms.Padding(0);
            tabControlFunctionProgramProject.Name = "tabControlFunctionProgramProject";
            tabControlFunctionProgramProject.Padding = new System.Drawing.Point(10, 3);
            tabControlFunctionProgramProject.SelectedIndex = 0;
            tabControlFunctionProgramProject.Size = new System.Drawing.Size(859, 429);
            tabControlFunctionProgramProject.TabIndex = 8;
            tabControlFunctionProgramProject.Selected += tabControlFunctionProgramProject_Selected;
            // 
            // tabFunctionProgramProject
            // 
            tabFunctionProgramProject.Controls.Add(chckbxSpecial);
            tabFunctionProgramProject.Controls.Add(label2);
            tabFunctionProgramProject.Controls.Add(cmbServiceName);
            tabFunctionProgramProject.Controls.Add(dgFunctionalProgramProject);
            tabFunctionProgramProject.Location = new System.Drawing.Point(4, 24);
            tabFunctionProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabFunctionProgramProject.Name = "tabFunctionProgramProject";
            tabFunctionProgramProject.Size = new System.Drawing.Size(851, 401);
            tabFunctionProgramProject.TabIndex = 1;
            tabFunctionProgramProject.Text = "Function, Program and Project";
            // 
            // chckbxSpecial
            // 
            chckbxSpecial.AutoSize = true;
            chckbxSpecial.Location = new System.Drawing.Point(780, 11);
            chckbxSpecial.Name = "chckbxSpecial";
            chckbxSpecial.Size = new System.Drawing.Size(63, 19);
            chckbxSpecial.TabIndex = 20;
            chckbxSpecial.Text = "Special";
            chckbxSpecial.UseVisualStyleBackColor = true;
            chckbxSpecial.CheckedChanged += chckbxSpecial_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 17;
            label2.Text = "Service Name";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbServiceName
            // 
            cmbServiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbServiceName.FormattingEnabled = true;
            cmbServiceName.Location = new System.Drawing.Point(93, 9);
            cmbServiceName.Name = "cmbServiceName";
            cmbServiceName.Size = new System.Drawing.Size(346, 23);
            cmbServiceName.TabIndex = 19;
            // 
            // dgFunctionalProgramProject
            // 
            dgFunctionalProgramProject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgFunctionalProgramProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFunctionalProgramProject.Location = new System.Drawing.Point(8, 37);
            dgFunctionalProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgFunctionalProgramProject.Name = "dgFunctionalProgramProject";
            dgFunctionalProgramProject.RowHeadersWidth = 51;
            dgFunctionalProgramProject.RowTemplate.Height = 29;
            dgFunctionalProgramProject.Size = new System.Drawing.Size(835, 362);
            dgFunctionalProgramProject.TabIndex = 5;
            dgFunctionalProgramProject.RowHeaderMouseDoubleClick += dgFunctionalProgramProject_RowHeaderMouseDoubleClick;
            dgFunctionalProgramProject.SelectionChanged += dgFunctionalProgramProject_SelectionChanged;
            // 
            // tabFunctionalClassificationService
            // 
            tabFunctionalClassificationService.Controls.Add(label1);
            tabFunctionalClassificationService.Controls.Add(cmbxSector);
            tabFunctionalClassificationService.Controls.Add(dgFuntionalClassificationServices);
            tabFunctionalClassificationService.Location = new System.Drawing.Point(4, 24);
            tabFunctionalClassificationService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabFunctionalClassificationService.Name = "tabFunctionalClassificationService";
            tabFunctionalClassificationService.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabFunctionalClassificationService.Size = new System.Drawing.Size(851, 401);
            tabFunctionalClassificationService.TabIndex = 0;
            tabFunctionalClassificationService.Text = "Functional Classification Service";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 15);
            label1.TabIndex = 14;
            label1.Text = "Sector Name";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbxSector
            // 
            cmbxSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxSector.FormattingEnabled = true;
            cmbxSector.Location = new System.Drawing.Point(89, 10);
            cmbxSector.Name = "cmbxSector";
            cmbxSector.Size = new System.Drawing.Size(330, 23);
            cmbxSector.TabIndex = 16;
            cmbxSector.SelectionChangeCommitted += cmbSectorName_SelectionChangeCommitted;
            // 
            // dgFuntionalClassificationServices
            // 
            dgFuntionalClassificationServices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgFuntionalClassificationServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFuntionalClassificationServices.Location = new System.Drawing.Point(8, 39);
            dgFuntionalClassificationServices.Name = "dgFuntionalClassificationServices";
            dgFuntionalClassificationServices.RowHeadersWidth = 51;
            dgFuntionalClassificationServices.RowTemplate.Height = 25;
            dgFuntionalClassificationServices.Size = new System.Drawing.Size(837, 357);
            dgFuntionalClassificationServices.TabIndex = 17;
            dgFuntionalClassificationServices.SelectionChanged += dgFuntionalClassificationServices_SelectionChanged;
            // 
            // tabFunctionalClassification
            // 
            tabFunctionalClassification.Controls.Add(dgFunctionalClassification);
            tabFunctionalClassification.Location = new System.Drawing.Point(4, 24);
            tabFunctionalClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabFunctionalClassification.Name = "tabFunctionalClassification";
            tabFunctionalClassification.Size = new System.Drawing.Size(851, 401);
            tabFunctionalClassification.TabIndex = 2;
            tabFunctionalClassification.Text = "Functional Classifications";
            // 
            // dgFunctionalClassification
            // 
            dgFunctionalClassification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFunctionalClassification.Dock = System.Windows.Forms.DockStyle.Fill;
            dgFunctionalClassification.Location = new System.Drawing.Point(0, 0);
            dgFunctionalClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgFunctionalClassification.Name = "dgFunctionalClassification";
            dgFunctionalClassification.RowHeadersWidth = 51;
            dgFunctionalClassification.RowTemplate.Height = 29;
            dgFunctionalClassification.Size = new System.Drawing.Size(851, 401);
            dgFunctionalClassification.TabIndex = 5;
            dgFunctionalClassification.SelectionChanged += dgFunctionalClassification_SelectionChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 476);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(859, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(629, 17);
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
            toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(42, 39);
            toolStripLabel1.Text = "Search";
            toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmFunctionProgramProject
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(859, 498);
            Controls.Add(tabControlFunctionProgramProject);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(874, 537);
            Name = "frmFunctionProgramProject";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Function, Program & Project...";
            Load += frmFunctionProgramProject_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControlFunctionProgramProject.ResumeLayout(false);
            tabFunctionProgramProject.ResumeLayout(false);
            tabFunctionProgramProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgFunctionalProgramProject).EndInit();
            tabFunctionalClassificationService.ResumeLayout(false);
            tabFunctionalClassificationService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgFuntionalClassificationServices).EndInit();
            tabFunctionalClassification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgFunctionalClassification).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbxSector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSubFPP;
        internal System.Windows.Forms.ComboBox cmbServiceName;
        internal System.Windows.Forms.CheckBox chckbxSpecial;
        internal System.Windows.Forms.DataGridView dgFunctionalProgramProject;
        internal System.Windows.Forms.DataGridView dgFuntionalClassificationServices;
        internal System.Windows.Forms.DataGridView dgFunctionalClassification;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}