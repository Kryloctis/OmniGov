
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.cmbxAllotmentClasses = new System.Windows.Forms.ComboBox();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgAllotmentRelease = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(828, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(744, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(78, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "OK";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtDateIssued);
            this.panel1.Controls.Add(this.cmbxAllotmentClasses);
            this.panel1.Controls.Add(this.cmbxFunds);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 31);
            this.panel1.TabIndex = 3;
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.CustomFormat = "MMM dd, yyy";
            this.dtDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateIssued.Location = new System.Drawing.Point(260, 3);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(121, 23);
            this.dtDateIssued.TabIndex = 15;
            this.dtDateIssued.ValueChanged += new System.EventHandler(this.dtDateIssued_ValueChanged);
            // 
            // cmbxAllotmentClasses
            // 
            this.cmbxAllotmentClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClasses.FormattingEnabled = true;
            this.cmbxAllotmentClasses.Location = new System.Drawing.Point(174, 3);
            this.cmbxAllotmentClasses.Name = "cmbxAllotmentClasses";
            this.cmbxAllotmentClasses.Size = new System.Drawing.Size(80, 23);
            this.cmbxAllotmentClasses.TabIndex = 14;
            this.cmbxAllotmentClasses.SelectionChangeCommitted += new System.EventHandler(this.cmbxAllotmentClasses_SelectionChangeCommitted);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(3, 3);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(165, 23);
            this.cmbxFunds.TabIndex = 13;
            this.cmbxFunds.SelectionChangeCommitted += new System.EventHandler(this.cmbxFunds_SelectionChangeCommitted);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(837, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(606, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(225, 23);
            this.txtSearch.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgAllotmentRelease);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(915, 410);
            this.panel2.TabIndex = 4;
            // 
            // dgAllotmentRelease
            // 
            this.dgAllotmentRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllotmentRelease.Location = new System.Drawing.Point(3, 3);
            this.dgAllotmentRelease.Name = "dgAllotmentRelease";
            this.dgAllotmentRelease.RowTemplate.Height = 25;
            this.dgAllotmentRelease.Size = new System.Drawing.Size(909, 404);
            this.dgAllotmentRelease.TabIndex = 3;
            this.dgAllotmentRelease.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAllotmentRelease_CellDoubleClick);
            this.dgAllotmentRelease.SelectionChanged += new System.EventHandler(this.dgAllotmentRelease_SelectionChanged);
            // 
            // frmAllotmentReleaseSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(915, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "frmAllotmentReleaseSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Allotment Release";
            this.Load += new System.EventHandler(this.frmAllotmentReleaseSearch_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClasses;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgAllotmentRelease;
    }
}