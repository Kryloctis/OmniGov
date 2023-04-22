
namespace AccountingSystem.Views.Manage.AccountableForm
{
    partial class frmAccountable
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
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnFaceValue = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            panel1 = new System.Windows.Forms.Panel();
            dgAccountableForm = new System.Windows.Forms.DataGridView();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAccountableForm).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripSeparator1, btnFaceValue, txtSearch });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(794, 50);
            toolStrip.TabIndex = 7;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(42, 39);
            btnAdd.Text = "Add...";
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
            btnEdit.Size = new System.Drawing.Size(40, 39);
            btnEdit.Text = "Edit...";
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
            // btnFaceValue
            // 
            btnFaceValue.Enabled = false;
            btnFaceValue.Image = Properties.Resources.account_book_20px;
            btnFaceValue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnFaceValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnFaceValue.Name = "btnFaceValue";
            btnFaceValue.Size = new System.Drawing.Size(66, 39);
            btnFaceValue.Text = "Face Value";
            btnFaceValue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnFaceValue.Click += btnFaceValue_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 42);
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4 });
            statusStrip.Location = new System.Drawing.Point(0, 375);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(794, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 8;
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(716, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgAccountableForm);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(794, 325);
            panel1.TabIndex = 9;
            // 
            // dgAccountableForm
            // 
            dgAccountableForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAccountableForm.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAccountableForm.Location = new System.Drawing.Point(4, 4);
            dgAccountableForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgAccountableForm.Name = "dgAccountableForm";
            dgAccountableForm.RowHeadersWidth = 51;
            dgAccountableForm.RowTemplate.Height = 29;
            dgAccountableForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgAccountableForm.Size = new System.Drawing.Size(786, 317);
            dgAccountableForm.TabIndex = 10;
            dgAccountableForm.SelectionChanged += dgAccountableForm_SelectionChanged;
            // 
            // frmAccountable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(794, 397);
            Controls.Add(panel1);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAccountable";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Accountable Form";
            Load += frmAccountable_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAccountableForm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton btnFaceValue;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgAccountableForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}