
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class frmSelectAllotmentRelease
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgFPP = new System.Windows.Forms.DataGridView();
            this.dgAllotmentRelease = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripCmbxYear = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripCmbxAllotmentClass = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripCmbxFunds = new System.Windows.Forms.ToolStripComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgFPP);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 3, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgAllotmentRelease);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.splitContainer1.Size = new System.Drawing.Size(993, 466);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgFPP
            // 
            this.dgFPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFPP.Location = new System.Drawing.Point(5, 5);
            this.dgFPP.Name = "dgFPP";
            this.dgFPP.RowTemplate.Height = 25;
            this.dgFPP.Size = new System.Drawing.Size(292, 461);
            this.dgFPP.TabIndex = 0;
            this.dgFPP.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFPP_RowHeaderMouseDoubleClick);
            this.dgFPP.SelectionChanged += new System.EventHandler(this.dgFPP_SelectionChanged);
            // 
            // dgAllotmentRelease
            // 
            this.dgAllotmentRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllotmentRelease.Location = new System.Drawing.Point(3, 34);
            this.dgAllotmentRelease.Name = "dgAllotmentRelease";
            this.dgAllotmentRelease.RowTemplate.Height = 25;
            this.dgAllotmentRelease.Size = new System.Drawing.Size(681, 432);
            this.dgAllotmentRelease.TabIndex = 1;
            this.dgAllotmentRelease.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAllotmentRelease_RowHeaderMouseDoubleClick);
            this.dgAllotmentRelease.SelectionChanged += new System.EventHandler(this.dgAllotmentRelease_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCmbxYear,
            this.toolStripCmbxAllotmentClass,
            this.toolStripCmbxFunds});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(681, 34);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripCmbxYear
            // 
            this.toolStripCmbxYear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripCmbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripCmbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripCmbxYear.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripCmbxYear.Name = "toolStripCmbxYear";
            this.toolStripCmbxYear.Size = new System.Drawing.Size(150, 28);
            // 
            // toolStripCmbxAllotmentClass
            // 
            this.toolStripCmbxAllotmentClass.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripCmbxAllotmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripCmbxAllotmentClass.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripCmbxAllotmentClass.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripCmbxAllotmentClass.Name = "toolStripCmbxAllotmentClass";
            this.toolStripCmbxAllotmentClass.Size = new System.Drawing.Size(150, 28);
            // 
            // toolStripCmbxFunds
            // 
            this.toolStripCmbxFunds.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripCmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripCmbxFunds.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripCmbxFunds.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripCmbxFunds.Name = "toolStripCmbxFunds";
            this.toolStripCmbxFunds.Size = new System.Drawing.Size(150, 28);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(993, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(915, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(834, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSelectAllotmentRelease
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(993, 495);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1009, 534);
            this.Name = "frmSelectAllotmentRelease";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Obligation Request > Select Allotment Release";
            this.Load += new System.EventHandler(this.frmSelectAllotmentRelease_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.DataGridView dgFPP;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripComboBox toolStripCmbxYear;
        internal System.Windows.Forms.ToolStripComboBox toolStripCmbxAllotmentClass;
        internal System.Windows.Forms.ToolStripComboBox toolStripCmbxFunds;
        internal System.Windows.Forms.DataGridView dgAllotmentRelease;
    }
}