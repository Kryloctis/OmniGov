namespace AccountingSystem.Views.Manage.Barangay
{
    partial class frmBarangay
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
            toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            panel1 = new System.Windows.Forms.Panel();
            dgBarangay = new System.Windows.Forms.DataGridView();
            toolStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgBarangay).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, toolStripTextBoxSearch });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            toolStrip.Size = new System.Drawing.Size(612, 50);
            toolStrip.TabIndex = 7;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(39, 39);
            btnAdd.Text = "&Add..";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.ToolTipText = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(37, 39);
            btnEdit.Text = "&Edit..";
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
            btnDelete.Text = "&Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // toolStripTextBoxSearch
            // 
            toolStripTextBoxSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            toolStripTextBoxSearch.Size = new System.Drawing.Size(200, 42);
            toolStripTextBoxSearch.TextChanged += toolStripTextBoxSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgBarangay);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(612, 335);
            panel1.TabIndex = 11;
            // 
            // dgBarangay
            // 
            dgBarangay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgBarangay.Dock = System.Windows.Forms.DockStyle.Fill;
            dgBarangay.Location = new System.Drawing.Point(4, 4);
            dgBarangay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgBarangay.Name = "dgBarangay";
            dgBarangay.RowHeadersWidth = 51;
            dgBarangay.RowTemplate.Height = 29;
            dgBarangay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgBarangay.Size = new System.Drawing.Size(604, 327);
            dgBarangay.TabIndex = 9;
            dgBarangay.SelectionChanged += dgBarangay_SelectionChanged;
            // 
            // frmBarangay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(612, 385);
            Controls.Add(panel1);
            Controls.Add(toolStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "frmBarangay";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Barangay";
            Load += frmBarangay_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgBarangay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgBarangay;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
    }
}