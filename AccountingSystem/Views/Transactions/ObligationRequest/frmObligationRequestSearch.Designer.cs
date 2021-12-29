
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class frmObligationRequestSearch
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgObligationRequests = new System.Windows.Forms.DataGridView();
            this.cmbxStatus = new System.Windows.Forms.ComboBox();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.cmbxAllotmentClasses = new System.Windows.Forms.ComboBox();
            this.dtDateRequested = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).BeginInit();
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(842, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(746, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::AccountingSystem.Properties.Resources.ok14px;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(647, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(93, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "OK";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(505, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(753, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgObligationRequests
            // 
            this.dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationRequests.Location = new System.Drawing.Point(12, 41);
            this.dgObligationRequests.Name = "dgObligationRequests";
            this.dgObligationRequests.RowTemplate.Height = 25;
            this.dgObligationRequests.Size = new System.Drawing.Size(816, 394);
            this.dgObligationRequests.TabIndex = 2;
            this.dgObligationRequests.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgObligationRequests_ColumnAdded);
            this.dgObligationRequests.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgObligationRequests_RowHeaderMouseDoubleClick);
            this.dgObligationRequests.SelectionChanged += new System.EventHandler(this.dgObligationRequests_SelectionChanged);
            // 
            // cmbxStatus
            // 
            this.cmbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxStatus.FormattingEnabled = true;
            this.cmbxStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Approved",
            "Disapproved",
            "Cancelled"});
            this.cmbxStatus.Location = new System.Drawing.Point(12, 12);
            this.cmbxStatus.Name = "cmbxStatus";
            this.cmbxStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbxStatus.TabIndex = 3;
            this.cmbxStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbxStatus_SelectionChangeCommitted);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(113, 12);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(165, 23);
            this.cmbxFunds.TabIndex = 4;
            this.cmbxFunds.SelectionChangeCommitted += new System.EventHandler(this.cmbxFunds_SelectionChangeCommitted);
            // 
            // cmbxAllotmentClasses
            // 
            this.cmbxAllotmentClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClasses.FormattingEnabled = true;
            this.cmbxAllotmentClasses.Location = new System.Drawing.Point(284, 12);
            this.cmbxAllotmentClasses.Name = "cmbxAllotmentClasses";
            this.cmbxAllotmentClasses.Size = new System.Drawing.Size(80, 23);
            this.cmbxAllotmentClasses.TabIndex = 5;
            this.cmbxAllotmentClasses.SelectionChangeCommitted += new System.EventHandler(this.cmbxAllotmentClasses_SelectionChangeCommitted);
            // 
            // dtDateRequested
            // 
            this.dtDateRequested.CustomFormat = "MMM dd, yyy";
            this.dtDateRequested.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateRequested.Location = new System.Drawing.Point(370, 12);
            this.dtDateRequested.Name = "dtDateRequested";
            this.dtDateRequested.Size = new System.Drawing.Size(106, 23);
            this.dtDateRequested.TabIndex = 6;
            this.dtDateRequested.ValueChanged += new System.EventHandler(this.dtDateRequested_ValueChanged);
            // 
            // frmObligationRequestSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(842, 471);
            this.Controls.Add(this.dtDateRequested);
            this.Controls.Add(this.cmbxAllotmentClasses);
            this.Controls.Add(this.cmbxFunds);
            this.Controls.Add(this.cmbxStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgObligationRequests);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObligationRequestSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Obligation Request";
            this.Load += new System.EventHandler(this.frmObligationRequestSearch_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgObligationRequests;
        internal System.Windows.Forms.ComboBox cmbxStatus;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClasses;
        internal System.Windows.Forms.DateTimePicker dtDateRequested;
    }
}