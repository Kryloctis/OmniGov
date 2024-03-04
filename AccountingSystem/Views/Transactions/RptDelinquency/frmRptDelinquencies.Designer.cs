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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            bgwRealPropertyTaxDeliquencies = new System.ComponentModel.BackgroundWorker();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDeliquentProperties).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dgDeliquentProperties);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 55);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(895, 424);
            panel2.TabIndex = 25;
            // 
            // dgDeliquentProperties
            // 
            dgDeliquentProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDeliquentProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgDeliquentProperties.Location = new System.Drawing.Point(4, 4);
            dgDeliquentProperties.Name = "dgDeliquentProperties";
            dgDeliquentProperties.RowTemplate.Height = 25;
            dgDeliquentProperties.Size = new System.Drawing.Size(887, 416);
            dgDeliquentProperties.TabIndex = 0;
            dgDeliquentProperties.SelectionChanged += dgDeliquentProperties_SelectionChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(895, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 32;
            statusStrip1.Text = "statusStrip1";
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
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete });
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
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 50);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(895, 5);
            progressBar1.TabIndex = 35;
            // 
            // frmRptDelinquencies
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(895, 501);
            Controls.Add(panel2);
            Controls.Add(progressBar1);
            Controls.Add(toolStrip2);
            Controls.Add(statusStrip1);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgDeliquentProperties;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bgwRealPropertyTaxDeliquencies;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}