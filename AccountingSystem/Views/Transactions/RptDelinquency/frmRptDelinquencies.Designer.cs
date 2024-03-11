namespace AccountingSystem.Views.Reports.RptDeliquency
{
    partial class frmRptDelinquencies
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
            panel2 = new System.Windows.Forms.Panel();
            dgDeliquentProperties = new System.Windows.Forms.DataGridView();
            bgwRealPropertyTaxDeliquencies = new System.ComponentModel.BackgroundWorker();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            panel3 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            cmbxDelinquentStatus = new System.Windows.Forms.ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDeliquentProperties).BeginInit();
            toolStrip2.SuspendLayout();
            statusStrip.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dgDeliquentProperties);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 86);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(895, 393);
            panel2.TabIndex = 25;
            // 
            // dgDeliquentProperties
            // 
            dgDeliquentProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDeliquentProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgDeliquentProperties.Location = new System.Drawing.Point(4, 4);
            dgDeliquentProperties.Name = "dgDeliquentProperties";
            dgDeliquentProperties.RowTemplate.Height = 25;
            dgDeliquentProperties.Size = new System.Drawing.Size(887, 385);
            dgDeliquentProperties.TabIndex = 0;
            dgDeliquentProperties.SelectionChanged += dgDeliquentProperties_SelectionChanged;
            // 
            // bgwRealPropertyTaxDeliquencies
            // 
            bgwRealPropertyTaxDeliquencies.WorkerReportsProgress = true;
            bgwRealPropertyTaxDeliquencies.WorkerSupportsCancellation = true;
            bgwRealPropertyTaxDeliquencies.DoWork += bgwRealPropertyTaxDeliquencies_DoWork;
            bgwRealPropertyTaxDeliquencies.ProgressChanged += bgwRealPropertyTaxDeliquencies_ProgressChanged;
            bgwRealPropertyTaxDeliquencies.RunWorkerCompleted += bgwRealPropertyTaxDeliquencies_RunWorkerCompleted;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(895, 50);
            toolStrip2.TabIndex = 34;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
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
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(24, 39);
            btnSearch.Text = "toolStripButton1";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 42);
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 81);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(895, 5);
            progressBar1.TabIndex = 35;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, lblCreatedAt, lblUpdatedAt });
            statusStrip.Location = new System.Drawing.Point(0, 479);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(895, 22);
            statusStrip.TabIndex = 36;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(817, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cmbxDelinquentStatus);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 50);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(895, 31);
            panel3.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 15);
            label1.TabIndex = 5;
            label1.Text = "Deliquency Status ";
            // 
            // cmbxDelinquentStatus
            // 
            cmbxDelinquentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxDelinquentStatus.FormattingEnabled = true;
            cmbxDelinquentStatus.Location = new System.Drawing.Point(108, 3);
            cmbxDelinquentStatus.Name = "cmbxDelinquentStatus";
            cmbxDelinquentStatus.Size = new System.Drawing.Size(139, 23);
            cmbxDelinquentStatus.TabIndex = 4;
            cmbxDelinquentStatus.SelectedIndexChanged += cmbxDelinquentStatus_SelectedIndexChanged;
            // 
            // frmRptDelinquencies
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(895, 501);
            Controls.Add(panel2);
            Controls.Add(progressBar1);
            Controls.Add(panel3);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip2);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(911, 540);
            Name = "frmRptDelinquencies";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Real Property Tax Delinquencies";
            Load += frmRptDeliquencies_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDeliquentProperties).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgDeliquentProperties;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bgwRealPropertyTaxDeliquencies;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        internal System.Windows.Forms.ComboBox cmbxDelinquentStatus;
        private System.Windows.Forms.Label label1;
    }
}