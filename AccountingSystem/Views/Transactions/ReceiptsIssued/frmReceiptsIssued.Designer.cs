
namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    partial class frmReceiptsIssued
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnReturn = new System.Windows.Forms.ToolStripButton();
            dgReceiptIssued = new System.Windows.Forms.DataGridView();
            txtsearch = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            tsJOCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgReceiptIssued).BeginInit();
            panel1.SuspendLayout();
            statusStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, btnReturn });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Margin = new System.Windows.Forms.Padding(4);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(1060, 50);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(33, 39);
            btnAdd.Text = "Add";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(31, 39);
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // btnReturn
            // 
            btnReturn.Enabled = false;
            btnReturn.Image = Properties.Resources.account_book_20px;
            btnReturn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new System.Drawing.Size(46, 39);
            btnReturn.Text = "Return";
            btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnReturn.Click += btnReturn_Click;
            // 
            // dgReceiptIssued
            // 
            dgReceiptIssued.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceiptIssued.Dock = System.Windows.Forms.DockStyle.Fill;
            dgReceiptIssued.Location = new System.Drawing.Point(4, 9);
            dgReceiptIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgReceiptIssued.Name = "dgReceiptIssued";
            dgReceiptIssued.RowHeadersWidth = 51;
            dgReceiptIssued.RowTemplate.Height = 29;
            dgReceiptIssued.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgReceiptIssued.Size = new System.Drawing.Size(1052, 477);
            dgReceiptIssued.TabIndex = 8;
            dgReceiptIssued.SelectionChanged += dgissue_SelectionChanged;
            // 
            // txtsearch
            // 
            txtsearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtsearch.Location = new System.Drawing.Point(855, 18);
            txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtsearch.Name = "txtsearch";
            txtsearch.Size = new System.Drawing.Size(200, 23);
            txtsearch.TabIndex = 11;
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(628, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 31;
            label2.Text = "Date Issued";
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtpDateIssued.CustomFormat = "dd/MM/yyyy";
            dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateIssued.Location = new System.Drawing.Point(701, 18);
            dtpDateIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new System.Drawing.Size(148, 23);
            dtpDateIssued.TabIndex = 30;
            dtpDateIssued.ValueChanged += dtpEndingDate_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgReceiptIssued);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1060, 490);
            panel1.TabIndex = 33;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1052, 5);
            progressBar1.TabIndex = 21;
            // 
            // statusStrip2
            // 
            statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel2, lblRecordCount, tsJOCount, toolStripStatusLabel6, lblCreatedAt, toolStripStatusLabel7, lblUpdatedAt });
            statusStrip2.Location = new System.Drawing.Point(0, 540);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip2.Size = new System.Drawing.Size(1060, 22);
            statusStrip2.SizingGrip = false;
            statusStrip2.Stretch = false;
            statusStrip2.TabIndex = 35;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel2.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // tsJOCount
            // 
            tsJOCount.Name = "tsJOCount";
            tsJOCount.Size = new System.Drawing.Size(850, 17);
            tsJOCount.Spring = true;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel6.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel7
            // 
            toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            toolStripStatusLabel7.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel7.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // frmReceiptsIssued
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1060, 562);
            Controls.Add(panel1);
            Controls.Add(statusStrip2);
            Controls.Add(label2);
            Controls.Add(dtpDateIssued);
            Controls.Add(txtsearch);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1076, 601);
            Name = "frmReceiptsIssued";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Issued Receipts";
            Load += frmReceipts_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgReceiptIssued).EndInit();
            panel1.ResumeLayout(false);
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnReturn;
        private System.Windows.Forms.DataGridView dgReceiptIssued;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateIssued;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel tsJOCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}