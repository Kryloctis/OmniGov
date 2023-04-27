
namespace AccountingSystem.Views.Manage.AccountableForm
{
    partial class ucAccountableForm
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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtformno = new System.Windows.Forms.TextBox();
            txtformdesc = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Form No. ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // txtformno
            // 
            txtformno.Location = new System.Drawing.Point(73, 1);
            txtformno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtformno.MaxLength = 10;
            txtformno.Name = "txtformno";
            txtformno.Size = new System.Drawing.Size(370, 23);
            txtformno.TabIndex = 0;
            txtformno.Validating += txtformno_Validating;
            txtformno.Validated += txtformno_Validated;
            // 
            // txtformdesc
            // 
            txtformdesc.Location = new System.Drawing.Point(73, 28);
            txtformdesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtformdesc.MaxLength = 45;
            txtformdesc.Name = "txtformdesc";
            txtformdesc.Size = new System.Drawing.Size(370, 23);
            txtformdesc.TabIndex = 1;
            txtformdesc.Validating += txtformdesc_Validating;
            txtformdesc.Validated += txtformdesc_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucAccountable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtformdesc);
            Controls.Add(txtformno);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucAccountable";
            Size = new System.Drawing.Size(463, 53);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtformno;
        internal System.Windows.Forms.TextBox txtformdesc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
