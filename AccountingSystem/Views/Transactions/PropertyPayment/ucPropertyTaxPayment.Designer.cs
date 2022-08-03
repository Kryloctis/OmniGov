
namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    partial class ucPropertyTaxPayment
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
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccountableForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxCollectingOfficers = new System.Windows.Forms.ComboBox();
            this.chckBxJobOrders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(110, 141);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(308, 23);
            this.txtPayee.TabIndex = 15;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(110, 112);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(308, 23);
            this.txtReceiptNo.TabIndex = 16;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(110, 83);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(308, 23);
            this.dtPaymentDate.TabIndex = 14;
            // 
            // txtAccountableForm
            // 
            this.txtAccountableForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountableForm.Location = new System.Drawing.Point(110, 54);
            this.txtAccountableForm.Name = "txtAccountableForm";
            this.txtAccountableForm.ReadOnly = true;
            this.txtAccountableForm.Size = new System.Drawing.Size(308, 23);
            this.txtAccountableForm.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Payee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Payment Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Receipt No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Accountable Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Collecting Officer";
            // 
            // cmbxCollectingOfficers
            // 
            this.cmbxCollectingOfficers.FormattingEnabled = true;
            this.cmbxCollectingOfficers.Location = new System.Drawing.Point(110, 25);
            this.cmbxCollectingOfficers.Name = "cmbxCollectingOfficers";
            this.cmbxCollectingOfficers.Size = new System.Drawing.Size(308, 23);
            this.cmbxCollectingOfficers.TabIndex = 7;
            // 
            // chckBxJobOrders
            // 
            this.chckBxJobOrders.AutoSize = true;
            this.chckBxJobOrders.Location = new System.Drawing.Point(336, 0);
            this.chckBxJobOrders.Name = "chckBxJobOrders";
            this.chckBxJobOrders.Size = new System.Drawing.Size(82, 19);
            this.chckBxJobOrders.TabIndex = 6;
            this.chckBxJobOrders.Text = "Job Orders";
            this.chckBxJobOrders.UseVisualStyleBackColor = true;
            // 
            // ucPropertyTaxPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.txtAccountableForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxCollectingOfficers);
            this.Controls.Add(this.chckBxJobOrders);
            this.Name = "ucPropertyTaxPayment";
            this.Size = new System.Drawing.Size(437, 167);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.TextBox txtAccountableForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxCollectingOfficers;
        private System.Windows.Forms.CheckBox chckBxJobOrders;
    }
}
