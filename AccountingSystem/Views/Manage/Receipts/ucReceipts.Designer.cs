
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAccountableForms = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtORFrom = new System.Windows.Forms.TextBox();
            this.txtORTo = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Forms";
            // 
            // cmbAccountableForms
            // 
            this.cmbAccountableForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountableForms.FormattingEnabled = true;
            this.cmbAccountableForms.Location = new System.Drawing.Point(139, 12);
            this.cmbAccountableForms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAccountableForms.Name = "cmbAccountableForms";
            this.cmbAccountableForms.Size = new System.Drawing.Size(377, 23);
            this.cmbAccountableForms.TabIndex = 1;
            this.cmbAccountableForms.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbAccountableForms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbforms_Validating);
            this.cmbAccountableForms.Validated += new System.EventHandler(this.cmbforms_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Receipt No. From ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "To ";
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.Location = new System.Drawing.Point(139, 81);
            this.dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(377, 23);
            this.dtpReceivedDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Received Date ";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(139, 147);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(377, 46);
            this.txtRemark.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Remarks ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtORFrom
            // 
            this.txtORFrom.Location = new System.Drawing.Point(139, 47);
            this.txtORFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtORFrom.Name = "txtORFrom";
            this.txtORFrom.Size = new System.Drawing.Size(162, 23);
            this.txtORFrom.TabIndex = 2;
            this.txtORFrom.TextChanged += new System.EventHandler(this.txtfrom_TextChanged);
            this.txtORFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfrom_KeyPress);
            this.txtORFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtfrom_KeyUp);
            this.txtORFrom.Validating += new System.ComponentModel.CancelEventHandler(this.txtfrom_Validating);
            this.txtORFrom.Validated += new System.EventHandler(this.txtfrom_Validated);
            // 
            // txtORTo
            // 
            this.txtORTo.Location = new System.Drawing.Point(350, 47);
            this.txtORTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtORTo.Name = "txtORTo";
            this.txtORTo.Size = new System.Drawing.Size(166, 23);
            this.txtORTo.TabIndex = 3;
            this.txtORTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtto_KeyPress);
            this.txtORTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtto_KeyUp);
            this.txtORTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtto_Validating);
            this.txtORTo.Validated += new System.EventHandler(this.txtto_Validated);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(139, 113);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(377, 23);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtquantity_KeyPress);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtquantity_Validating);
            this.txtQuantity.Validated += new System.EventHandler(this.txtquantity_Validated);
            // 
            // ucReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtORTo);
            this.Controls.Add(this.txtORFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpReceivedDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAccountableForms);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucReceipts";
            this.Size = new System.Drawing.Size(540, 203);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        internal System.Windows.Forms.TextBox txtORTo;
        internal System.Windows.Forms.TextBox txtORFrom;
    }
}
