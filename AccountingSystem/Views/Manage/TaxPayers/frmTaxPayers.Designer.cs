
namespace AccountingSystem.Views.Manage.TaxPayers
{
    partial class frmTaxpayers
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
            panel1 = new System.Windows.Forms.Panel();
            dgTaxpayers = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            chckBxInactiveTaxpayers = new System.Windows.Forms.CheckBox();
            btnSearch = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgTaxpayers);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 82);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(822, 377);
            panel1.TabIndex = 1;
            // 
            // dgTaxpayers
            // 
            dgTaxpayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTaxpayers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgTaxpayers.Location = new System.Drawing.Point(4, 4);
            dgTaxpayers.Name = "dgTaxpayers";
            dgTaxpayers.RowHeadersWidth = 51;
            dgTaxpayers.RowTemplate.Height = 25;
            dgTaxpayers.Size = new System.Drawing.Size(814, 369);
            dgTaxpayers.TabIndex = 1;
            dgTaxpayers.SelectionChanged += dgTaxpayers_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(822, 54);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_24px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(33, 43);
            btnAdd.Text = "&Add";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_24px;
            btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(31, 43);
            btnEdit.Text = "&Edit";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelRecordCount, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabelCreatedAt, toolStripStatusLabel5, toolStripStatusLabel6, toolStripStatusLabelUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 459);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(822, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            toolStripStatusLabel1.Text = "Records: ";
            // 
            // toolStripStatusLabelRecordCount
            // 
            toolStripStatusLabelRecordCount.Name = "toolStripStatusLabelRecordCount";
            toolStripStatusLabelRecordCount.Size = new System.Drawing.Size(13, 17);
            toolStripStatusLabelRecordCount.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(567, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            toolStripStatusLabel3.Text = "Created at: ";
            // 
            // toolStripStatusLabelCreatedAt
            // 
            toolStripStatusLabelCreatedAt.Name = "toolStripStatusLabelCreatedAt";
            toolStripStatusLabelCreatedAt.Size = new System.Drawing.Size(12, 17);
            toolStripStatusLabelCreatedAt.Text = "-";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(71, 17);
            toolStripStatusLabel6.Text = "Updated at: ";
            // 
            // toolStripStatusLabelUpdatedAt
            // 
            toolStripStatusLabelUpdatedAt.Name = "toolStripStatusLabelUpdatedAt";
            toolStripStatusLabelUpdatedAt.Size = new System.Drawing.Size(12, 17);
            toolStripStatusLabelUpdatedAt.Text = "-";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(chckBxInactiveTaxpayers);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(822, 23);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // chckBxInactiveTaxpayers
            // 
            chckBxInactiveTaxpayers.AutoSize = true;
            chckBxInactiveTaxpayers.Location = new System.Drawing.Point(667, 3);
            chckBxInactiveTaxpayers.Name = "chckBxInactiveTaxpayers";
            chckBxInactiveTaxpayers.Size = new System.Drawing.Size(152, 19);
            chckBxInactiveTaxpayers.TabIndex = 0;
            chckBxInactiveTaxpayers.Text = "Show Inactive taxpayers";
            chckBxInactiveTaxpayers.UseVisualStyleBackColor = true;
            chckBxInactiveTaxpayers.CheckedChanged += chckBxInactiveTaxpayers_CheckedChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(743, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(75, 23);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(537, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.TabIndex = 10;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 77);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(822, 5);
            pbLoadRecords.TabIndex = 24;
            // 
            // frmTaxpayers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(822, 481);
            Controls.Add(panel1);
            Controls.Add(pbLoadRecords);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmTaxpayers";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Taxpayers";
            Load += frmTaxPayersSearch_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgTaxpayers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdatedAt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chckBxInactiveTaxpayers;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
    }
}