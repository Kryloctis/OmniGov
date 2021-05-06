
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
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bank Name";
            // 
            // txtacode
            // 
            this.txtacode.Location = new System.Drawing.Point(86, 5);
            this.txtacode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtacode.MaxLength = 45;
            this.txtacode.Name = "txtacode";
            this.txtacode.Size = new System.Drawing.Size(327, 23);
            this.txtacode.TabIndex = 0;
            this.txtacode.Validating += new System.ComponentModel.CancelEventHandler(this.txtacode_Validating);
            this.txtacode.Validated += new System.EventHandler(this.txtacode_Validated);
            // 
            // txtbankname
            // 
            this.txtbankname.Location = new System.Drawing.Point(86, 32);
            this.txtbankname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbankname.MaxLength = 99;
            this.txtbankname.Name = "txtbankname";
            this.txtbankname.Size = new System.Drawing.Size(327, 23);
            this.txtbankname.TabIndex = 1;
            this.txtbankname.Validating += new System.ComponentModel.CancelEventHandler(this.txtbankname_Validating);
            this.txtbankname.Validated += new System.EventHandler(this.txtbankname_Validated);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ucBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbankname);
            this.Controls.Add(this.txtacode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucBanks";
            this.Size = new System.Drawing.Size(438, 62);
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
