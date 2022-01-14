
namespace AccountingSystem.Views.Reports.RCDCollector
{
    partial class ucCollectorsRCD
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



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtRCDDate = new System.Windows.Forms.DateTimePicker();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epReportNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgPayments = new System.Windows.Forms.DataGridView();
            this.groubBoxFund = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.epCollector = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayments = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epReportNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).BeginInit();
            this.groubBoxFund.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCollector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dtRCDDate
            // 
            this.dtRCDDate.Location = new System.Drawing.Point(569, 75);
            this.dtRCDDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtRCDDate.Name = "dtRCDDate";
            this.dtRCDDate.Size = new System.Drawing.Size(225, 23);
            this.dtRCDDate.TabIndex = 19;
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(82, 75);
            this.txtReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReport.MaxLength = 20;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(171, 23);
            this.txtReport.TabIndex = 17;
            this.txtReport.Validating += new System.ComponentModel.CancelEventHandler(this.txtReport_Validating);
            this.txtReport.Validated += new System.EventHandler(this.txtReport_Validated);
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(339, 76);
            this.cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(171, 23);
            this.cmbCollector.TabIndex = 15;
            this.cmbCollector.SelectedValueChanged += new System.EventHandler(this.cmbcollector_SelectedValueChanged);
            this.cmbCollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCollector_Validating);
            this.cmbCollector.Validated += new System.EventHandler(this.cmbCollector_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Report No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Collector";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // epReportNo
            // 
            this.epReportNo.ContainerControl = this;
            // 
            // dgPayments
            // 
            this.dgPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.epPayments.SetIconAlignment(this.dgPayments, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.dgPayments.Location = new System.Drawing.Point(19, 107);
            this.dgPayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPayments.Name = "dgPayments";
            this.dgPayments.RowHeadersWidth = 51;
            this.dgPayments.RowTemplate.Height = 29;
            this.dgPayments.Size = new System.Drawing.Size(878, 370);
            this.dgPayments.TabIndex = 21;
            this.dgPayments.SelectionChanged += new System.EventHandler(this.dgPayments_SelectionChanged);
            this.dgPayments.Validating += new System.ComponentModel.CancelEventHandler(this.dgPayments_Validating);
            this.dgPayments.Validated += new System.EventHandler(this.dgPayments_Validated);
            // 
            // groubBoxFund
            // 
            this.groubBoxFund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groubBoxFund.Controls.Add(this.flowLayoutPanelFunds);
            this.groubBoxFund.Location = new System.Drawing.Point(16, 3);
            this.groubBoxFund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groubBoxFund.Name = "groubBoxFund";
            this.groubBoxFund.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groubBoxFund.Size = new System.Drawing.Size(881, 59);
            this.groubBoxFund.TabIndex = 27;
            this.groubBoxFund.TabStop = false;
            this.groubBoxFund.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanelFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(875, 39);
            this.flowLayoutPanelFunds.TabIndex = 0;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.Location = new System.Drawing.Point(54, 483);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(229, 23);
            this.txtTotal.TabIndex = 26;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemove.Location = new System.Drawing.Point(744, 483);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(74, 23);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "Remove";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.Location = new System.Drawing.Point(823, 483);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 23);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(668, 483);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add...";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Total";
            // 
            // epCollector
            // 
            this.epCollector.ContainerControl = this;
            // 
            // epPayments
            // 
            this.epPayments.ContainerControl = this;
            // 
            // ucCollectorsRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dtRCDDate);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groubBoxFund);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgPayments);
            this.Name = "ucCollectorsRCD";
            this.Size = new System.Drawing.Size(913, 510);
            this.Load += new System.EventHandler(this.ucRCDCollector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epReportNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).EndInit();
            this.groubBoxFund.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epCollector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtRCDDate;
        internal System.Windows.Forms.TextBox txtReport;
        internal System.Windows.Forms.ComboBox cmbCollector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epReportNo;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgPayments;
        internal System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ErrorProvider epCollector;
        internal System.Windows.Forms.GroupBox groubBoxFund;
        private System.Windows.Forms.ErrorProvider epPayments;
    }
}
