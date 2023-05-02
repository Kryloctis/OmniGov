namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    partial class ucAF51_57
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
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            txtContact = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtType = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtTaxpayer = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(panel2);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(711, 60);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Taxpayer Information";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtContact);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtType);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtTaxpayer);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel2.Location = new System.Drawing.Point(3, 19);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(705, 38);
            panel2.TabIndex = 0;
            // 
            // txtContact
            // 
            txtContact.Location = new System.Drawing.Point(493, 8);
            txtContact.Name = "txtContact";
            txtContact.ReadOnly = true;
            txtContact.Size = new System.Drawing.Size(195, 23);
            txtContact.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(438, 11);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "Contact";
            // 
            // txtType
            // 
            txtType.Location = new System.Drawing.Point(339, 8);
            txtType.Name = "txtType";
            txtType.ReadOnly = true;
            txtType.Size = new System.Drawing.Size(78, 23);
            txtType.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(302, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "Type";
            // 
            // txtTaxpayer
            // 
            txtTaxpayer.Location = new System.Drawing.Point(60, 8);
            txtTaxpayer.Name = "txtTaxpayer";
            txtTaxpayer.ReadOnly = true;
            txtTaxpayer.Size = new System.Drawing.Size(223, 23);
            txtTaxpayer.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // ucAF51_57
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "ucAF51_57";
            Size = new System.Drawing.Size(711, 60);
            Load += ucAF51_57_Load;
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtContact;
        internal System.Windows.Forms.TextBox txtType;
        internal System.Windows.Forms.TextBox txtTaxpayer;
    }
}
