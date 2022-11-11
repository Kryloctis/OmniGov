namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
{
    partial class ucBusinessAdOnCharges
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtOrdinanceReferenceNo = new System.Windows.Forms.TextBox();
            this.cbxLineOfBusiness = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.AllowDrop = true;
            this.txtCode.Location = new System.Drawing.Point(85, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(244, 23);
            this.txtCode.TabIndex = 3;
            // 
            // txtOrdinanceReferenceNo
            // 
            this.txtOrdinanceReferenceNo.AllowDrop = true;
            this.txtOrdinanceReferenceNo.Location = new System.Drawing.Point(85, 40);
            this.txtOrdinanceReferenceNo.Name = "txtOrdinanceReferenceNo";
            this.txtOrdinanceReferenceNo.Size = new System.Drawing.Size(244, 23);
            this.txtOrdinanceReferenceNo.TabIndex = 7;
            // 
            // cbxLineOfBusiness
            // 
            this.cbxLineOfBusiness.AutoSize = true;
            this.cbxLineOfBusiness.Location = new System.Drawing.Point(169, 69);
            this.cbxLineOfBusiness.Name = "cbxLineOfBusiness";
            this.cbxLineOfBusiness.Size = new System.Drawing.Size(160, 19);
            this.cbxLineOfBusiness.TabIndex = 9;
            this.cbxLineOfBusiness.Text = "Applied on each business";
            this.cbxLineOfBusiness.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code";
            // 
            // ucBusinessAdOnCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtOrdinanceReferenceNo);
            this.Controls.Add(this.cbxLineOfBusiness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBusinessAdOnCharges";
            this.Size = new System.Drawing.Size(344, 97);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtOrdinanceReferenceNo;
        internal System.Windows.Forms.CheckBox cbxLineOfBusiness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
