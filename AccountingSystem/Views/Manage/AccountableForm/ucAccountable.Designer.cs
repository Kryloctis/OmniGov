
namespace AccountingSystem.Views.Manage.AccountableForm
{
    partial class ucAccountable
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
            this.txtformno = new System.Windows.Forms.TextBox();
            this.txtformdesc = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form No. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // txtformno
            // 
            this.txtformno.Location = new System.Drawing.Point(73, 1);
            this.txtformno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtformno.MaxLength = 4;
            this.txtformno.Name = "txtformno";
            this.txtformno.Size = new System.Drawing.Size(370, 23);
            this.txtformno.TabIndex = 0;
            this.txtformno.Validating += new System.ComponentModel.CancelEventHandler(this.txtformno_Validating);
            this.txtformno.Validated += new System.EventHandler(this.txtformno_Validated);
            // 
            // txtformdesc
            // 
            this.txtformdesc.Location = new System.Drawing.Point(73, 28);
            this.txtformdesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtformdesc.MaxLength = 45;
            this.txtformdesc.Name = "txtformdesc";
            this.txtformdesc.Size = new System.Drawing.Size(370, 23);
            this.txtformdesc.TabIndex = 1;
            this.txtformdesc.Validating += new System.ComponentModel.CancelEventHandler(this.txtformdesc_Validating);
            this.txtformdesc.Validated += new System.EventHandler(this.txtformdesc_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ucAccountable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtformdesc);
            this.Controls.Add(this.txtformno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucAccountable";
            this.Size = new System.Drawing.Size(468, 53);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.TextBox txtformno;
        internal System.Windows.Forms.TextBox txtformdesc;
    }
}
