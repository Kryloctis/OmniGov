
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
            this.components = new System.ComponentModel.Container();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccountableForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chckBxJobOrder = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCollectingOfficer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            // chckBxJobOrder
            // 
            this.chckBxJobOrder.AutoSize = true;
            this.chckBxJobOrder.Enabled = false;
            this.chckBxJobOrder.Location = new System.Drawing.Point(341, 0);
            this.chckBxJobOrder.Name = "chckBxJobOrder";
            this.chckBxJobOrder.Size = new System.Drawing.Size(77, 19);
            this.chckBxJobOrder.TabIndex = 6;
            this.chckBxJobOrder.Text = "Job Order";
            this.chckBxJobOrder.UseVisualStyleBackColor = true;
            this.chckBxJobOrder.CheckedChanged += new System.EventHandler(this.chckBxJobOrders_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txtCollectingOfficer
            // 
            this.txtCollectingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollectingOfficer.Location = new System.Drawing.Point(110, 25);
            this.txtCollectingOfficer.Name = "txtCollectingOfficer";
            this.txtCollectingOfficer.ReadOnly = true;
            this.txtCollectingOfficer.Size = new System.Drawing.Size(308, 23);
            this.txtCollectingOfficer.TabIndex = 17;
            // 
            // ucPropertyTaxPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtCollectingOfficer);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.txtAccountableForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chckBxJobOrder);
            this.Name = "ucPropertyTaxPayment";
            this.Size = new System.Drawing.Size(437, 167);
            this.Load += new System.EventHandler(this.ucPropertyTaxPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtReceiptNo;
        internal System.Windows.Forms.DateTimePicker dtPaymentDate;
        internal System.Windows.Forms.TextBox txtAccountableForm;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox chckBxJobOrder;
        private System.Windows.Forms.TextBox txtCollectingOfficer;
    }
}
