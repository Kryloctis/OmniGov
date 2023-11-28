
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
            txtFormNo = new System.Windows.Forms.TextBox();
            txtFormDescription = new System.Windows.Forms.TextBox();
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
            // txtFormNo
            // 
            txtFormNo.Location = new System.Drawing.Point(73, 1);
            txtFormNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtFormNo.MaxLength = 10;
            txtFormNo.Name = "txtFormNo";
            txtFormNo.Size = new System.Drawing.Size(370, 23);
            txtFormNo.TabIndex = 0;
            txtFormNo.Validating += new System.ComponentModel.CancelEventHandler(txtformno_Validating);
            txtFormNo.Validated += new System.EventHandler(txtformno_Validated);
            // 
            // txtFormDescription
            // 
            txtFormDescription.Location = new System.Drawing.Point(73, 28);
            txtFormDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtFormDescription.MaxLength = 45;
            txtFormDescription.Name = "txtFormDescription";
            txtFormDescription.Size = new System.Drawing.Size(370, 23);
            txtFormDescription.TabIndex = 1;
            txtFormDescription.Validating += new System.ComponentModel.CancelEventHandler(txtformdesc_Validating);
            txtFormDescription.Validated += new System.EventHandler(txtformdesc_Validated);
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucAccountableForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtFormDescription);
            Controls.Add(txtFormNo);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucAccountableForm";
            Size = new System.Drawing.Size(463, 53);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtFormNo;
        internal System.Windows.Forms.TextBox txtFormDescription;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
