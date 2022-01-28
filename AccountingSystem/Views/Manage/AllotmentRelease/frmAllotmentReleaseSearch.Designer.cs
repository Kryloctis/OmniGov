
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class frmAllotmentReleaseSearch
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgAllotmentRelease = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.cmbxAllotmentClasses = new System.Windows.Forms.ComboBox();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 441);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(915, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(798, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::AccountingSystem.Properties.Resources.ok14px;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(684, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "OK";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgAllotmentRelease
            // 
            this.dgAllotmentRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentRelease.Location = new System.Drawing.Point(12, 41);
            this.dgAllotmentRelease.Name = "dgAllotmentRelease";
            this.dgAllotmentRelease.RowTemplate.Height = 25;
            this.dgAllotmentRelease.Size = new System.Drawing.Size(891, 394);
            this.dgAllotmentRelease.TabIndex = 2;
            this.dgAllotmentRelease.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAllotmentRelease_RowHeaderMouseDoubleClick);
            this.dgAllotmentRelease.SelectionChanged += new System.EventHandler(this.dgAllotmentRelease_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(597, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(225, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(828, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.CustomFormat = "MMM dd, yyy";
            this.dtDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateIssued.Location = new System.Drawing.Point(269, 13);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(121, 23);
            this.dtDateIssued.TabIndex = 10;
            this.dtDateIssued.ValueChanged += new System.EventHandler(this.dtDateIssued_ValueChanged);
            // 
            // cmbxAllotmentClasses
            // 
            this.cmbxAllotmentClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClasses.FormattingEnabled = true;
            this.cmbxAllotmentClasses.Location = new System.Drawing.Point(183, 13);
            this.cmbxAllotmentClasses.Name = "cmbxAllotmentClasses";
            this.cmbxAllotmentClasses.Size = new System.Drawing.Size(80, 23);
            this.cmbxAllotmentClasses.TabIndex = 9;
            this.cmbxAllotmentClasses.SelectionChangeCommitted += new System.EventHandler(this.cmbxAllotmentClasses_SelectionChangeCommitted);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(12, 13);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(165, 23);
            this.cmbxFunds.TabIndex = 8;
            this.cmbxFunds.SelectionChangeCommitted += new System.EventHandler(this.cmbxFunds_SelectionChangeCommitted);
            // 
            // frmAllotmentReleaseSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(915, 471);
            this.Controls.Add(this.dtDateIssued);
            this.Controls.Add(this.cmbxAllotmentClasses);
            this.Controls.Add(this.cmbxFunds);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgAllotmentRelease);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllotmentReleaseSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Allotment Release";
            this.Load += new System.EventHandler(this.frmAllotmentReleaseSearch_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.DataGridView dgAllotmentRelease;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClasses;
        internal System.Windows.Forms.ComboBox cmbxFunds;
    }
}