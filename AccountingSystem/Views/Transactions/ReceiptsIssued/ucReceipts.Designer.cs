
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collecting Officer :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date Issued :";
            // 
            // dtpissued
            // 
            this.dtpissued.Location = new System.Drawing.Point(152, 79);
            this.dtpissued.Name = "dtpissued";
            this.dtpissued.Size = new System.Drawing.Size(425, 27);
            this.dtpissued.TabIndex = 3;
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(152, 11);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(425, 28);
            this.cmbcollector.TabIndex = 4;
            this.cmbcollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbcollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // cmbreceipt
            // 
            this.cmbreceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreceipt.FormattingEnabled = true;
            this.cmbreceipt.Location = new System.Drawing.Point(152, 45);
            this.cmbreceipt.Name = "cmbreceipt";
            this.cmbreceipt.Size = new System.Drawing.Size(425, 28);
            this.cmbreceipt.TabIndex = 5;
            this.cmbreceipt.Validating += new System.ComponentModel.CancelEventHandler(this.cmbreceipt_Validating);
            this.cmbreceipt.Validated += new System.EventHandler(this.cmbreceipt_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ucReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbreceipt);
            this.Controls.Add(this.cmbcollector);
            this.Controls.Add(this.dtpissued);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucReceipts";
            this.Size = new System.Drawing.Size(589, 122);
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
    }
}
