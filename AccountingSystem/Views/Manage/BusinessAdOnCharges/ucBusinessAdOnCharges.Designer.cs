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
            this.components = new System.ComponentModel.Container();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbxAppliedToEachBusiness = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.Location = new System.Drawing.Point(85, 40);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(244, 23);
            this.txtDescription.TabIndex = 7;
            // 
            // cbxAppliedToEachBusiness
            // 
            this.cbxAppliedToEachBusiness.AutoSize = true;
            this.cbxAppliedToEachBusiness.Location = new System.Drawing.Point(169, 69);
            this.cbxAppliedToEachBusiness.Name = "cbxAppliedToEachBusiness";
            this.cbxAppliedToEachBusiness.Size = new System.Drawing.Size(160, 19);
            this.cbxAppliedToEachBusiness.TabIndex = 9;
            this.cbxAppliedToEachBusiness.Text = "Applied on each business";
            this.cbxAppliedToEachBusiness.UseVisualStyleBackColor = true;
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
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBusinessAdOnCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cbxAppliedToEachBusiness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBusinessAdOnCharges";
            this.Size = new System.Drawing.Size(344, 97);
            this.Load += new System.EventHandler(this.ucBusinessAdOnCharges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.CheckBox cbxAppliedToEachBusiness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
