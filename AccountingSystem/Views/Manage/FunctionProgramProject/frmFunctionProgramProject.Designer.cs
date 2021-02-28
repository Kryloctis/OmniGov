
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunctionProgramProject));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.tabControlFunctionProgramProject = new System.Windows.Forms.TabControl();
            this.tabFunctionalClassification = new System.Windows.Forms.TabPage();
            this.dgFunctionalClassification = new System.Windows.Forms.DataGridView();
            this.tabFunctionalClassificationService = new System.Windows.Forms.TabPage();
            this.dgFuntionalClassificationService = new System.Windows.Forms.DataGridView();
            this.tabFunctionProgramProject = new System.Windows.Forms.TabPage();
            this.dgFunctionalProgramProject = new System.Windows.Forms.DataGridView();
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
            this.tabFunctionalClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalClassification)).BeginInit();
            this.tabFunctionalClassificationService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuntionalClassificationService)).BeginInit();
            this.tabFunctionProgramProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalProgramProject)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(859, 46);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 43);
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
            this.btnEdit.Size = new System.Drawing.Size(40, 43);
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
            this.btnDelete.Size = new System.Drawing.Size(44, 43);
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
            this.btnFind.Size = new System.Drawing.Size(37, 43);
            this.btnFind.Text = "Filter";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabControlFunctionProgramProject
            // 
            this.tabControlFunctionProgramProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFunctionProgramProject.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionalClassification);
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionalClassificationService);
            this.tabControlFunctionProgramProject.Controls.Add(this.tabFunctionProgramProject);
            this.tabControlFunctionProgramProject.Location = new System.Drawing.Point(10, 48);
            this.tabControlFunctionProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlFunctionProgramProject.Multiline = true;
            this.tabControlFunctionProgramProject.Name = "tabControlFunctionProgramProject";
            this.tabControlFunctionProgramProject.SelectedIndex = 0;
            this.tabControlFunctionProgramProject.Size = new System.Drawing.Size(838, 421);
            this.tabControlFunctionProgramProject.TabIndex = 8;
            this.tabControlFunctionProgramProject.SelectedIndexChanged += new System.EventHandler(this.dgFunctionalClassification_SelectedIndexChanged);
            // 
            // tabFunctionalClassification
            // 
            this.tabFunctionalClassification.Controls.Add(this.dgFunctionalClassification);
            this.tabFunctionalClassification.Location = new System.Drawing.Point(4, 27);
            this.tabFunctionalClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassification.Name = "tabFunctionalClassification";
            this.tabFunctionalClassification.Size = new System.Drawing.Size(830, 390);
            this.tabFunctionalClassification.TabIndex = 2;
            this.tabFunctionalClassification.Text = "Functional Classifications";
            this.tabFunctionalClassification.UseVisualStyleBackColor = true;
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
            this.dgFunctionalClassification.Size = new System.Drawing.Size(830, 390);
            this.dgFunctionalClassification.TabIndex = 5;
            this.dgFunctionalClassification.SelectionChanged += new System.EventHandler(this.dgFunctionalClassification_SelectionChanged);
            // 
            // tabFunctionalClassificationService
            // 
            this.tabFunctionalClassificationService.Controls.Add(this.dgFuntionalClassificationService);
            this.tabFunctionalClassificationService.Location = new System.Drawing.Point(4, 27);
            this.tabFunctionalClassificationService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassificationService.Name = "tabFunctionalClassificationService";
            this.tabFunctionalClassificationService.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionalClassificationService.Size = new System.Drawing.Size(830, 390);
            this.tabFunctionalClassificationService.TabIndex = 0;
            this.tabFunctionalClassificationService.Text = "Functional Classification Service";
            this.tabFunctionalClassificationService.UseVisualStyleBackColor = true;
            // 
            // dgFuntionalClassificationService
            // 
            this.dgFuntionalClassificationService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuntionalClassificationService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgFuntionalClassificationService.Location = new System.Drawing.Point(3, 2);
            this.dgFuntionalClassificationService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgFuntionalClassificationService.Name = "dgFuntionalClassificationService";
            this.dgFuntionalClassificationService.RowHeadersWidth = 51;
            this.dgFuntionalClassificationService.RowTemplate.Height = 29;
            this.dgFuntionalClassificationService.Size = new System.Drawing.Size(824, 386);
            this.dgFuntionalClassificationService.TabIndex = 4;
            this.dgFuntionalClassificationService.SelectionChanged += new System.EventHandler(this.dgFuntionalClassificationService_SelectionChanged);
            // 
            // tabFunctionProgramProject
            // 
            this.tabFunctionProgramProject.Controls.Add(this.dgFunctionalProgramProject);
            this.tabFunctionProgramProject.Location = new System.Drawing.Point(4, 27);
            this.tabFunctionProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionProgramProject.Name = "tabFunctionProgramProject";
            this.tabFunctionProgramProject.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFunctionProgramProject.Size = new System.Drawing.Size(830, 390);
            this.tabFunctionProgramProject.TabIndex = 1;
            this.tabFunctionProgramProject.Text = "Function Program Project";
            this.tabFunctionProgramProject.UseVisualStyleBackColor = true;
            // 
            // dgFunctionalProgramProject
            // 
            this.dgFunctionalProgramProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFunctionalProgramProject.Location = new System.Drawing.Point(3, 2);
            this.dgFunctionalProgramProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgFunctionalProgramProject.Name = "dgFunctionalProgramProject";
            this.dgFunctionalProgramProject.RowHeadersWidth = 51;
            this.dgFunctionalProgramProject.RowTemplate.Height = 29;
            this.dgFunctionalProgramProject.Size = new System.Drawing.Size(824, 393);
            this.dgFunctionalProgramProject.TabIndex = 5;
            this.dgFunctionalProgramProject.SelectionChanged += new System.EventHandler(this.dgFunctionalProgramProject_SelectionChanged);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
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
            this.ClientSize = new System.Drawing.Size(859, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlFunctionProgramProject);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFunctionProgramProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage > Function, Program, Project...";
            this.Load += new System.EventHandler(this.frmFunctionProgramProject_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlFunctionProgramProject.ResumeLayout(false);
            this.tabFunctionalClassification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalClassification)).EndInit();
            this.tabFunctionalClassificationService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFuntionalClassificationService)).EndInit();
            this.tabFunctionProgramProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFunctionalProgramProject)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.TabControl tabControlFunctionProgramProject;
        private System.Windows.Forms.TabPage tabFunctionalClassification;
        private System.Windows.Forms.TabPage tabFunctionalClassificationService;
        private System.Windows.Forms.DataGridView dgFuntionalClassificationService;
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
    }
}