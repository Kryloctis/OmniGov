
namespace AccountingSystem.Views.Manage.Banks
{
    partial class ucBanks
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
            this.txtacode = new System.Windows.Forms.TextBox();
            this.txtbankname = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bank Name :";
            // 
            // txtacode
            // 
            this.txtacode.Location = new System.Drawing.Point(112, 8);
            this.txtacode.Name = "txtacode";
            this.txtacode.Size = new System.Drawing.Size(373, 27);
            this.txtacode.TabIndex = 2;
            this.txtacode.Validating += new System.ComponentModel.CancelEventHandler(this.txtacode_Validating);
            this.txtacode.Validated += new System.EventHandler(this.txtacode_Validated);
            // 
            // txtbankname
            // 
            this.txtbankname.Location = new System.Drawing.Point(112, 49);
            this.txtbankname.Name = "txtbankname";
            this.txtbankname.Size = new System.Drawing.Size(373, 27);
            this.txtbankname.TabIndex = 3;
            this.txtbankname.Validating += new System.ComponentModel.CancelEventHandler(this.txtbankname_Validating);
            this.txtbankname.Validated += new System.EventHandler(this.txtbankname_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ucBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbankname);
            this.Controls.Add(this.txtacode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBanks";
            this.Size = new System.Drawing.Size(506, 89);
            this.Load += new System.EventHandler(this.ucBanks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.TextBox txtacode;
        internal System.Windows.Forms.TextBox txtbankname;
    }
}
