
namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    partial class ucReceiptsIssued
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpIssued = new System.Windows.Forms.DateTimePicker();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.cmbReceipt = new System.Windows.Forms.ComboBox();
            this.epCollectingOfficer = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReceiptQuantity = new System.Windows.Forms.TextBox();
            this.epReceipt = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFrom = new System.Windows.Forms.ErrorProvider(this.components);
            this.epQuantity = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudReceiptIssuedFrom = new System.Windows.Forms.NumericUpDown();
            this.nudReceiptIssuedTo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiptIssuedFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiptIssuedTo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collecting Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date Issued ";
            // 
            // dtpIssued
            // 
            this.dtpIssued.Location = new System.Drawing.Point(130, 161);
            this.dtpIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpIssued.Name = "dtpIssued";
            this.dtpIssued.Size = new System.Drawing.Size(372, 23);
            this.dtpIssued.TabIndex = 3;
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(130, 12);
            this.cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(372, 23);
            this.cmbCollector.TabIndex = 4;
            this.cmbCollector.SelectedIndexChanged += new System.EventHandler(this.cmbcollector_SelectedIndexChanged);
            this.cmbCollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbCollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // cmbReceipt
            // 
            this.cmbReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceipt.FormattingEnabled = true;
            this.cmbReceipt.Location = new System.Drawing.Point(130, 50);
            this.cmbReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbReceipt.Name = "cmbReceipt";
            this.cmbReceipt.Size = new System.Drawing.Size(372, 23);
            this.cmbReceipt.TabIndex = 5;
            this.cmbReceipt.SelectionChangeCommitted += new System.EventHandler(this.cmbReceipt_SelectionChangeCommitted);
            this.cmbReceipt.Validating += new System.ComponentModel.CancelEventHandler(this.cmbreceipt_Validating);
            this.cmbReceipt.Validated += new System.EventHandler(this.cmbreceipt_Validated);
            // 
            // epCollectingOfficer
            // 
            this.epCollectingOfficer.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Issue From ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quantity ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "To";
            // 
            // txtReceiptQuantity
            // 
            this.txtReceiptQuantity.Location = new System.Drawing.Point(130, 123);
            this.txtReceiptQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptQuantity.Name = "txtReceiptQuantity";
            this.txtReceiptQuantity.ReadOnly = true;
            this.txtReceiptQuantity.Size = new System.Drawing.Size(372, 23);
            this.txtReceiptQuantity.TabIndex = 11;
            this.txtReceiptQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtquantity_Validating);
            this.txtReceiptQuantity.Validated += new System.EventHandler(this.txtquantity_Validated);
            // 
            // epReceipt
            // 
            this.epReceipt.ContainerControl = this;
            // 
            // epTo
            // 
            this.epTo.ContainerControl = this;
            // 
            // epFrom
            // 
            this.epFrom.ContainerControl = this;
            // 
            // epQuantity
            // 
            this.epQuantity.ContainerControl = this;
            // 
            // nudReceiptIssuedFrom
            // 
            this.nudReceiptIssuedFrom.Location = new System.Drawing.Point(130, 85);
            this.nudReceiptIssuedFrom.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudReceiptIssuedFrom.Name = "nudReceiptIssuedFrom";
            this.nudReceiptIssuedFrom.ReadOnly = true;
            this.nudReceiptIssuedFrom.Size = new System.Drawing.Size(167, 23);
            this.nudReceiptIssuedFrom.TabIndex = 12;
            this.nudReceiptIssuedFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReceiptIssuedFrom.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nudReceiptIssuedTo
            // 
            this.nudReceiptIssuedTo.Location = new System.Drawing.Point(341, 85);
            this.nudReceiptIssuedTo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudReceiptIssuedTo.Name = "nudReceiptIssuedTo";
            this.nudReceiptIssuedTo.Size = new System.Drawing.Size(161, 23);
            this.nudReceiptIssuedTo.TabIndex = 13;
            this.nudReceiptIssuedTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReceiptIssuedTo.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudReceiptIssuedTo.ValueChanged += new System.EventHandler(this.nudReceiptIssuedTo_ValueChanged);
            // 
            // ucReceiptsIssued
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.nudReceiptIssuedTo);
            this.Controls.Add(this.nudReceiptIssuedFrom);
            this.Controls.Add(this.txtReceiptQuantity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbReceipt);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.dtpIssued);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucReceiptsIssued";
            this.Size = new System.Drawing.Size(530, 194);
            this.Load += new System.EventHandler(this.ucReceiptsIssued_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiptIssuedFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiptIssuedTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epCollectingOfficer;
        internal System.Windows.Forms.DateTimePicker dtpIssued;
        internal System.Windows.Forms.ComboBox cmbCollector;
        internal System.Windows.Forms.ComboBox cmbReceipt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtReceiptQuantity;
        private System.Windows.Forms.ErrorProvider epReceipt;
        private System.Windows.Forms.ErrorProvider epTo;
        private System.Windows.Forms.ErrorProvider epFrom;
        private System.Windows.Forms.ErrorProvider epQuantity;
        internal System.Windows.Forms.NumericUpDown nudReceiptIssuedFrom;
        internal System.Windows.Forms.NumericUpDown nudReceiptIssuedTo;
    }
}
