namespace AccountingSystem.Views.Manage.Registry
{
    partial class frmRegistry
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(2);
            toolStrip1.Size = new System.Drawing.Size(800, 46);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(42, 39);
            btnAdd.Text = "Add...";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(40, 39);
            btnEdit.Text = "Edit...";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 46);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(800, 382);
            panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(792, 374);
            dataGridView1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(24, 39);
            btnSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 42);
            // 
            // frmRegistry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            Name = "frmRegistry";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Registry";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
    }
}