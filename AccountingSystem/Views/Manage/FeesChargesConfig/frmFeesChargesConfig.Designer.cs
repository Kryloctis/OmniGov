namespace LFS.Views.Manage.FeesChargesConfig
{
    partial class frmFeesChargesConfig
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            treeViewFeesCharges = new System.Windows.Forms.TreeView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            drpDownBtnNew = new System.Windows.Forms.ToolStripDropDownButton();
            btnNewClassification = new System.Windows.Forms.ToolStripMenuItem();
            btnNewFeesCharges = new System.Windows.Forms.ToolStripMenuItem();
            btnModify = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnUndelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 35);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(854, 5);
            pbLoadRecords.TabIndex = 34;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 495);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(854, 22);
            statusStrip1.TabIndex = 35;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(treeViewFeesCharges);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 40);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(854, 455);
            panel1.TabIndex = 36;
            // 
            // treeViewFeesCharges
            // 
            treeViewFeesCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            treeViewFeesCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewFeesCharges.HideSelection = false;
            treeViewFeesCharges.Location = new System.Drawing.Point(4, 4);
            treeViewFeesCharges.Name = "treeViewFeesCharges";
            treeViewFeesCharges.Size = new System.Drawing.Size(846, 447);
            treeViewFeesCharges.TabIndex = 30;
            treeViewFeesCharges.AfterSelect += treeViewFeesCharges_AfterSelect;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { drpDownBtnNew, btnModify, toolStripSeparator2, btnDelete, btnUndelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(854, 35);
            toolStrip1.TabIndex = 37;
            toolStrip1.Text = "toolStrip1";
            // 
            // drpDownBtnNew
            // 
            drpDownBtnNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { btnNewClassification, btnNewFeesCharges });
            drpDownBtnNew.Image = Properties.Resources.button_rounded_add_20px;
            drpDownBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            drpDownBtnNew.Name = "drpDownBtnNew";
            drpDownBtnNew.Size = new System.Drawing.Size(64, 24);
            drpDownBtnNew.Text = "New";
            // 
            // btnNewClassification
            // 
            btnNewClassification.Name = "btnNewClassification";
            btnNewClassification.Size = new System.Drawing.Size(166, 22);
            btnNewClassification.Text = "Classification";
            btnNewClassification.Click += btnNewClassification_Click;
            // 
            // btnNewFeesCharges
            // 
            btnNewFeesCharges.Name = "btnNewFeesCharges";
            btnNewFeesCharges.Size = new System.Drawing.Size(166, 22);
            btnNewFeesCharges.Text = "Fees and Charges";
            btnNewFeesCharges.Click += btnNewFeesCharges_Click;
            // 
            // btnModify
            // 
            btnModify.Image = Properties.Resources.button_rounded_edit_20px;
            btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnModify.Name = "btnModify";
            btnModify.Size = new System.Drawing.Size(69, 24);
            btnModify.Text = "Modify";
            btnModify.Click += btnModify_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUndelete
            // 
            btnUndelete.Image = Properties.Resources.symbol_refresh_28px;
            btnUndelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnUndelete.Name = "btnUndelete";
            btnUndelete.Size = new System.Drawing.Size(78, 24);
            btnUndelete.Text = "Undelete";
            btnUndelete.Click += btnUndelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 24);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // frmFeesChargesConfig
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(854, 517);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(pbLoadRecords);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            Name = "frmFeesChargesConfig";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Treasury > Manage > Fees & Charges Config.";
            Load += frmFeesChargesConfig_Load;
            panel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion Windows Form Designer generated code
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewFeesCharges;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUndelete;
        private System.Windows.Forms.ToolStripDropDownButton drpDownBtnNew;
        private System.Windows.Forms.ToolStripMenuItem btnNewClassification;
        private System.Windows.Forms.ToolStripMenuItem btnNewFeesCharges;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
    }
}