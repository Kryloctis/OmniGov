
namespace AccountingSystem.Views.Transactions.AssessmentPosting
{
    partial class frmAssessmentPosting
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chckBxAll = new System.Windows.Forms.CheckBox();
            this.dgProperties = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.cmbxBarangays = new System.Windows.Forms.ToolStripComboBox();
            this.btnPostSelected = new System.Windows.Forms.ToolStripButton();
            this.btnUnpostSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnManualPosting = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPostedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chckBxAll);
            this.panel2.Controls.Add(this.dgProperties);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1039, 425);
            this.panel2.TabIndex = 10;
            // 
            // chckBxAll
            // 
            this.chckBxAll.AutoSize = true;
            this.chckBxAll.Location = new System.Drawing.Point(8, 41);
            this.chckBxAll.Name = "chckBxAll";
            this.chckBxAll.Size = new System.Drawing.Size(15, 14);
            this.chckBxAll.TabIndex = 16;
            this.chckBxAll.UseVisualStyleBackColor = true;
            this.chckBxAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkAll_MouseClick);
            // 
            // dgProperties
            // 
            this.dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProperties.Location = new System.Drawing.Point(4, 34);
            this.dgProperties.Name = "dgProperties";
            this.dgProperties.RowTemplate.Height = 25;
            this.dgProperties.Size = new System.Drawing.Size(1031, 387);
            this.dgProperties.TabIndex = 15;
            this.dgProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProperties_CellValueChanged);
            this.dgProperties.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgProperties_ColumnAdded);
            this.dgProperties.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgProperties_CurrentCellDirtyStateChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 30);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Year";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(950, 3);
            this.nudYear.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(73, 23);
            this.nudYear.TabIndex = 14;
            this.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudYear.Value = new decimal(new int[] {
            1971,
            0,
            0,
            0});
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.cmbxBarangays,
            this.btnPostSelected,
            this.btnUnpostSelected,
            this.toolStripSeparator1,
            this.btnManualPosting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Size = new System.Drawing.Size(1039, 58);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 50);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbxBarangays
            // 
            this.cmbxBarangays.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbxBarangays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxBarangays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxBarangays.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbxBarangays.Name = "cmbxBarangays";
            this.cmbxBarangays.Size = new System.Drawing.Size(200, 50);
            // 
            // btnPostSelected
            // 
            this.btnPostSelected.Enabled = false;
            this.btnPostSelected.Image = global::AccountingSystem.Properties.Resources.task_list_pin_28px;
            this.btnPostSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPostSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPostSelected.Name = "btnPostSelected";
            this.btnPostSelected.Size = new System.Drawing.Size(34, 47);
            this.btnPostSelected.Text = "Post";
            this.btnPostSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPostSelected.Click += new System.EventHandler(this.btnPostSelected_Click);
            // 
            // btnUnpostSelected
            // 
            this.btnUnpostSelected.Enabled = false;
            this.btnUnpostSelected.Image = global::AccountingSystem.Properties.Resources.pin_red_filled_cancel_28px;
            this.btnUnpostSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnpostSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnpostSelected.Name = "btnUnpostSelected";
            this.btnUnpostSelected.Size = new System.Drawing.Size(49, 47);
            this.btnUnpostSelected.Text = "Unpost";
            this.btnUnpostSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUnpostSelected.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnManualPosting
            // 
            this.btnManualPosting.Image = global::AccountingSystem.Properties.Resources.gear_filled_pin_28px;
            this.btnManualPosting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManualPosting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManualPosting.Name = "btnManualPosting";
            this.btnManualPosting.Size = new System.Drawing.Size(94, 47);
            this.btnManualPosting.Text = "Manual Posting";
            this.btnManualPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManualPosting.Click += new System.EventHandler(this.btnManualPosting_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCount,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblPostedAt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.TabIndex = 15;
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(800, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "Posted at:";
            // 
            // lblPostedAt
            // 
            this.lblPostedAt.Name = "lblPostedAt";
            this.lblPostedAt.Size = new System.Drawing.Size(69, 17);
            this.lblPostedAt.Text = "date posted";
            // 
            // frmAssessmentPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 505);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "frmAssessmentPosting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Payments > Assessment Posting";
            this.Load += new System.EventHandler(this.frmAssessmentPosting_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chckBxAll;
        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbxBarangays;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnManualPosting;
        private System.Windows.Forms.ToolStripButton btnPostSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripButton btnUnpostSelected;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblPostedAt;
    }
}