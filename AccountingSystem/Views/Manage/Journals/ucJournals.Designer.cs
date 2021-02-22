
namespace AccountingSystem.Views.Manage.Journals
{
    partial class ucJournals
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkSpecialJournal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(370, 27);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // chkSpecialJournal
            // 
            this.chkSpecialJournal.AutoSize = true;
            this.chkSpecialJournal.Location = new System.Drawing.Point(56, 44);
            this.chkSpecialJournal.Name = "chkSpecialJournal";
            this.chkSpecialJournal.Size = new System.Drawing.Size(183, 24);
            this.chkSpecialJournal.TabIndex = 2;
            this.chkSpecialJournal.Text = "This is a special journal";
            this.chkSpecialJournal.UseVisualStyleBackColor = true;
            // 
            // ucJournals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSpecialJournal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "ucJournals";
            this.Size = new System.Drawing.Size(458, 77);
            this.Load += new System.EventHandler(this.ucJournals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epName;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.CheckBox chkSpecialJournal;
    }
}
