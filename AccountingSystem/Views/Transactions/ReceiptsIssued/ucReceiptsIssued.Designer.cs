
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
            this.dtpIssued = new System.Windows.Forms.DateTimePicker();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.cmbReceipt = new System.Windows.Forms.ComboBox();
            this.epCollectingOfficer = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtReceiptQuantity = new System.Windows.Forms.TextBox();
            this.epReceipt = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFrom = new System.Windows.Forms.ErrorProvider(this.components);
            this.epQuantity = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbCollector = new System.Windows.Forms.CheckBox();
            this.txtReceiptIssuedFrom = new System.Windows.Forms.TextBox();
            this.txtReceiptIssuedTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpIssued
            // 
            this.dtpIssued.Location = new System.Drawing.Point(165, 178);
            this.dtpIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpIssued.Name = "dtpIssued";
            this.dtpIssued.Size = new System.Drawing.Size(398, 23);
            this.dtpIssued.TabIndex = 6;
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(165, 33);
            this.cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(398, 23);
            this.cmbCollector.TabIndex = 0;
            this.cmbCollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbCollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // cmbReceipt
            // 
            this.cmbReceipt.DropDownHeight = 400;
            this.cmbReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceipt.FormattingEnabled = true;
            this.cmbReceipt.IntegralHeight = false;
            this.cmbReceipt.Location = new System.Drawing.Point(165, 62);
            this.cmbReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbReceipt.Name = "cmbReceipt";
            this.cmbReceipt.Size = new System.Drawing.Size(398, 23);
            this.cmbReceipt.TabIndex = 1;
            this.cmbReceipt.SelectionChangeCommitted += new System.EventHandler(this.cmbReceipt_SelectionChangeCommitted);
            this.cmbReceipt.Validating += new System.ComponentModel.CancelEventHandler(this.cmbreceipt_Validating);
            this.cmbReceipt.Validated += new System.EventHandler(this.cmbreceipt_Validated);
            // 
            // epCollectingOfficer
            // 
            this.epCollectingOfficer.ContainerControl = this;
            // 
            // txtReceiptQuantity
            // 
            this.txtReceiptQuantity.Location = new System.Drawing.Point(165, 149);
            this.txtReceiptQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptQuantity.Name = "txtReceiptQuantity";
            this.txtReceiptQuantity.ReadOnly = true;
            this.txtReceiptQuantity.Size = new System.Drawing.Size(398, 23);
            this.txtReceiptQuantity.TabIndex = 5;
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
            // cbCollector
            // 
            this.cbCollector.AutoSize = true;
            this.cbCollector.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCollector.Location = new System.Drawing.Point(165, 11);
            this.cbCollector.Name = "cbCollector";
            this.cbCollector.Size = new System.Drawing.Size(82, 17);
            this.cbCollector.TabIndex = 14;
            this.cbCollector.Text = "Job Orders";
            this.cbCollector.UseVisualStyleBackColor = true;
            this.cbCollector.CheckedChanged += new System.EventHandler(this.cbCollector_CheckedChanged);
            // 
            // txtReceiptIssuedFrom
            // 
            this.txtReceiptIssuedFrom.Location = new System.Drawing.Point(165, 91);
            this.txtReceiptIssuedFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptIssuedFrom.MaxLength = 7;
            this.txtReceiptIssuedFrom.Name = "txtReceiptIssuedFrom";
            this.txtReceiptIssuedFrom.Size = new System.Drawing.Size(398, 23);
            this.txtReceiptIssuedFrom.TabIndex = 3;
            this.txtReceiptIssuedFrom.Text = "0";
            this.txtReceiptIssuedFrom.TextChanged += new System.EventHandler(this.txtReceiptIssuedFrom_TextChanged);
            this.txtReceiptIssuedFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptIssuedFrom_KeyPress);
            this.txtReceiptIssuedFrom.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceiptNumberFrom_Validating);
            this.txtReceiptIssuedFrom.Validated += new System.EventHandler(this.txtReceiptNumberFrom_Validated);
            // 
            // txtReceiptIssuedTo
            // 
            this.txtReceiptIssuedTo.Location = new System.Drawing.Point(165, 120);
            this.txtReceiptIssuedTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptIssuedTo.MaxLength = 7;
            this.txtReceiptIssuedTo.Name = "txtReceiptIssuedTo";
            this.txtReceiptIssuedTo.Size = new System.Drawing.Size(398, 23);
            this.txtReceiptIssuedTo.TabIndex = 4;
            this.txtReceiptIssuedTo.Text = "0";
            this.txtReceiptIssuedTo.TextChanged += new System.EventHandler(this.txtReceiptIssuedTo_TextChanged);
            this.txtReceiptIssuedTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptIssuedTo_KeyPress);
            this.txtReceiptIssuedTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceiptNumberTo_Validating);
            this.txtReceiptIssuedTo.Validated += new System.EventHandler(this.txtReceiptNumberTo_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Receipt Number To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Collecting Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Receipt ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Quantity ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Receipt Number From ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Date Issued ";
            // 
            // ucReceiptsIssued
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.cbCollector);
            this.Controls.Add(this.cmbReceipt);
            this.Controls.Add(this.txtReceiptQuantity);
            this.Controls.Add(this.txtReceiptIssuedFrom);
            this.Controls.Add(this.txtReceiptIssuedTo);
            this.Controls.Add(this.dtpIssued);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucReceiptsIssued";
            this.Size = new System.Drawing.Size(586, 214);
            this.Load += new System.EventHandler(this.ucReceiptsIssued_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epCollectingOfficer;
        internal System.Windows.Forms.DateTimePicker dtpIssued;
        internal System.Windows.Forms.ComboBox cmbCollector;
        internal System.Windows.Forms.ComboBox cmbReceipt;
        internal System.Windows.Forms.TextBox txtReceiptQuantity;
        private System.Windows.Forms.ErrorProvider epReceipt;
        private System.Windows.Forms.ErrorProvider epTo;
        private System.Windows.Forms.ErrorProvider epFrom;
        private System.Windows.Forms.ErrorProvider epQuantity;
        private System.Windows.Forms.CheckBox cbCollector;
        internal System.Windows.Forms.TextBox txtReceiptIssuedFrom;
        internal System.Windows.Forms.TextBox txtReceiptIssuedTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
