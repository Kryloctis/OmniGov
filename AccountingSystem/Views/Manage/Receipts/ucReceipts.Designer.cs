
namespace AccountingSystem.Views.Manage.Receipts
{
    partial class ucReceipts
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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            cmbAccountableForms = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            label4 = new System.Windows.Forms.Label();
            txtRemark = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);
            txtReceiptNumberFrom = new System.Windows.Forms.TextBox();
            txtReceiptNumberTo = new System.Windows.Forms.TextBox();
            txtQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Accountable Forms";
            // 
            // cmbAccountableForms
            // 
            cmbAccountableForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAccountableForms.DropDownWidth = 400;
            cmbAccountableForms.FormattingEnabled = true;
            cmbAccountableForms.Location = new System.Drawing.Point(139, 12);
            cmbAccountableForms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbAccountableForms.Name = "cmbAccountableForms";
            cmbAccountableForms.Size = new System.Drawing.Size(377, 23);
            cmbAccountableForms.TabIndex = 1;
            cmbAccountableForms.Validating += cmbAccountableForms_Validating;
            cmbAccountableForms.Validated += cmbAccountableForms_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Serial No. From ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 15);
            label3.TabIndex = 3;
            label3.Text = "Serial No. To";
            // 
            // dtpReceivedDate
            // 
            dtpReceivedDate.Location = new System.Drawing.Point(139, 97);
            dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpReceivedDate.Name = "dtpReceivedDate";
            dtpReceivedDate.Size = new System.Drawing.Size(377, 23);
            dtpReceivedDate.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(15, 97);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 15);
            label4.TabIndex = 7;
            label4.Text = "Received Date ";
            // 
            // txtRemark
            // 
            txtRemark.Location = new System.Drawing.Point(139, 151);
            txtRemark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new System.Drawing.Size(377, 46);
            txtRemark.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 124);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 10;
            label5.Text = "Quantity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(15, 151);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 15);
            label6.TabIndex = 11;
            label6.Text = "Remarks ";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // txtReceiptNumberFrom
            // 
            txtReceiptNumberFrom.Location = new System.Drawing.Point(139, 42);
            txtReceiptNumberFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReceiptNumberFrom.MaxLength = 7;
            txtReceiptNumberFrom.Name = "txtReceiptNumberFrom";
            txtReceiptNumberFrom.Size = new System.Drawing.Size(377, 23);
            txtReceiptNumberFrom.TabIndex = 2;
            txtReceiptNumberFrom.TextChanged += txtReceiptNumberFrom_TextChanged;
            txtReceiptNumberFrom.KeyPress += txtfrom_KeyPress;
            txtReceiptNumberFrom.Validating += txtReceiptNumberFrom_Validating;
            txtReceiptNumberFrom.Validated += txtReceiptNumberFrom_Validated;
            // 
            // txtReceiptNumberTo
            // 
            txtReceiptNumberTo.Location = new System.Drawing.Point(139, 69);
            txtReceiptNumberTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReceiptNumberTo.MaxLength = 7;
            txtReceiptNumberTo.Name = "txtReceiptNumberTo";
            txtReceiptNumberTo.Size = new System.Drawing.Size(377, 23);
            txtReceiptNumberTo.TabIndex = 3;
            txtReceiptNumberTo.TextChanged += txtReceiptNumberTo_TextChanged;
            txtReceiptNumberTo.KeyPress += txtto_KeyPress;
            txtReceiptNumberTo.Validating += txtReceiptNumberTo_Validating;
            txtReceiptNumberTo.Validated += txtReceiptNumberTo_Validated;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new System.Drawing.Point(139, 124);
            txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.ReadOnly = true;
            txtQuantity.Size = new System.Drawing.Size(377, 23);
            txtQuantity.TabIndex = 5;
            txtQuantity.KeyPress += txtquantity_KeyPress;
            txtQuantity.Validating += txtQuantity_Validating;
            txtQuantity.Validated += txtQuantity_Validated;
            // 
            // ucReceipts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtQuantity);
            Controls.Add(txtReceiptNumberTo);
            Controls.Add(txtReceiptNumberFrom);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtRemark);
            Controls.Add(label4);
            Controls.Add(dtpReceivedDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbAccountableForms);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucReceipts";
            Size = new System.Drawing.Size(540, 207);
            Load += ucReceipts_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.ComboBox cmbAccountableForms;
        internal System.Windows.Forms.DateTimePicker dtpReceivedDate;
        internal System.Windows.Forms.TextBox txtRemark;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.TextBox txtReceiptNumberTo;
        internal System.Windows.Forms.TextBox txtReceiptNumberFrom;
    }
}
