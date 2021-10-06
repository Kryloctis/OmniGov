
namespace AccountingSystem.Views.Transactions.ReceiptsIssued
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpissued = new System.Windows.Forms.DateTimePicker();
            this.cmbcollector = new System.Windows.Forms.ComboBox();
            this.cmbreceipt = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfrom = new System.Windows.Forms.TextBox();
            this.txtto = new System.Windows.Forms.TextBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collecting Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date Issued ";
            // 
            // dtpissued
            // 
            this.dtpissued.Location = new System.Drawing.Point(123, 111);
            this.dtpissued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpissued.Name = "dtpissued";
            this.dtpissued.Size = new System.Drawing.Size(372, 23);
            this.dtpissued.TabIndex = 3;
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(123, 2);
            this.cmbcollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(372, 23);
            this.cmbcollector.TabIndex = 4;
            this.cmbcollector.SelectedIndexChanged += new System.EventHandler(this.cmbcollector_SelectedIndexChanged);
            this.cmbcollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbcollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // cmbreceipt
            // 
            this.cmbreceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreceipt.FormattingEnabled = true;
            this.cmbreceipt.Location = new System.Drawing.Point(123, 29);
            this.cmbreceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbreceipt.Name = "cmbreceipt";
            this.cmbreceipt.Size = new System.Drawing.Size(372, 23);
            this.cmbreceipt.TabIndex = 5;
            this.cmbreceipt.SelectedIndexChanged += new System.EventHandler(this.cmbreceipt_SelectedIndexChanged);
            this.cmbreceipt.Validating += new System.ComponentModel.CancelEventHandler(this.cmbreceipt_Validating);
            this.cmbreceipt.Validated += new System.EventHandler(this.cmbreceipt_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Issue From ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quantity ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "To";
            // 
            // txtfrom
            // 
            this.txtfrom.Location = new System.Drawing.Point(123, 57);
            this.txtfrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.Size = new System.Drawing.Size(161, 23);
            this.txtfrom.TabIndex = 9;
            this.txtfrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfrom_KeyPress);
            this.txtfrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtfrom_KeyUp);
            this.txtfrom.Validating += new System.ComponentModel.CancelEventHandler(this.txtfrom_Validating);
            this.txtfrom.Validated += new System.EventHandler(this.txtfrom_Validated);
            // 
            // txtto
            // 
            this.txtto.Location = new System.Drawing.Point(335, 57);
            this.txtto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtto.Name = "txtto";
            this.txtto.Size = new System.Drawing.Size(161, 23);
            this.txtto.TabIndex = 10;
            this.txtto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtto_KeyPress);
            this.txtto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtto_KeyUp);
            this.txtto.Validating += new System.ComponentModel.CancelEventHandler(this.txtto_Validating);
            this.txtto.Validated += new System.EventHandler(this.txtto_Validated);
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(123, 84);
            this.txtquantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.ReadOnly = true;
            this.txtquantity.Size = new System.Drawing.Size(372, 23);
            this.txtquantity.TabIndex = 11;
            this.txtquantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtquantity_Validating);
            this.txtquantity.Validated += new System.EventHandler(this.txtquantity_Validated);
            // 
            // ucReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.txtto);
            this.Controls.Add(this.txtfrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbreceipt);
            this.Controls.Add(this.cmbcollector);
            this.Controls.Add(this.dtpissued);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucReceipts";
            this.Size = new System.Drawing.Size(499, 137);
            this.Load += new System.EventHandler(this.ucReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.DateTimePicker dtpissued;
        internal System.Windows.Forms.ComboBox cmbcollector;
        internal System.Windows.Forms.ComboBox cmbreceipt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtquantity;
        internal System.Windows.Forms.TextBox txtto;
        internal System.Windows.Forms.TextBox txtfrom;
    }
}
