namespace AccountingSystem.Views.Manage.BusinessCategories
{
    partial class ucBusinessCategories
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtOrdinanceReferenceNo = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbxLineOfBusiness = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ordinance Reference No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description";
            // 
            // txtCode
            // 
            this.txtCode.AcceptsTab = true;
            this.txtCode.AllowDrop = true;
            this.txtCode.Location = new System.Drawing.Point(153, 7);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(244, 23);
            this.txtCode.TabIndex = 0;
            // 
            // txtOrdinanceReferenceNo
            // 
            this.txtOrdinanceReferenceNo.AcceptsTab = true;
            this.txtOrdinanceReferenceNo.AllowDrop = true;
            this.txtOrdinanceReferenceNo.Location = new System.Drawing.Point(153, 38);
            this.txtOrdinanceReferenceNo.Name = "txtOrdinanceReferenceNo";
            this.txtOrdinanceReferenceNo.Size = new System.Drawing.Size(244, 23);
            this.txtOrdinanceReferenceNo.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsTab = true;
            this.txtDescription.AllowDrop = true;
            this.txtDescription.Location = new System.Drawing.Point(153, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(244, 23);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            // 
            // cbxLineOfBusiness
            // 
            this.cbxLineOfBusiness.AutoSize = true;
            this.cbxLineOfBusiness.Location = new System.Drawing.Point(287, 96);
            this.cbxLineOfBusiness.Name = "cbxLineOfBusiness";
            this.cbxLineOfBusiness.Size = new System.Drawing.Size(110, 19);
            this.cbxLineOfBusiness.TabIndex = 2;
            this.cbxLineOfBusiness.Text = "Line of Business";
            this.cbxLineOfBusiness.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBusinessCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtOrdinanceReferenceNo);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cbxLineOfBusiness);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBusinessCategories";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(415, 120);
            this.Load += new System.EventHandler(this.ucBusinessCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtOrdinanceReferenceNo;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.CheckBox cbxLineOfBusiness;
    }
}
