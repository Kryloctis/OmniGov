
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
            components = new System.ComponentModel.Container();
            txtName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            epName = new System.Windows.Forms.ErrorProvider(components);
            chkSpecialJournal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtName.Location = new System.Drawing.Point(52, 25);
            txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(333, 23);
            txtName.TabIndex = 0;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(2, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Name*";
            // 
            // epName
            // 
            epName.ContainerControl = this;
            // 
            // chkSpecialJournal
            // 
            chkSpecialJournal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkSpecialJournal.AutoSize = true;
            chkSpecialJournal.Location = new System.Drawing.Point(239, 2);
            chkSpecialJournal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            chkSpecialJournal.Name = "chkSpecialJournal";
            chkSpecialJournal.Size = new System.Drawing.Size(146, 19);
            chkSpecialJournal.TabIndex = 2;
            chkSpecialJournal.Text = "This is a special journal";
            chkSpecialJournal.UseVisualStyleBackColor = true;
            chkSpecialJournal.CheckedChanged += chkSpecialJournal_CheckedChanged;
            // 
            // ucJournals
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chkSpecialJournal);
            Controls.Add(label1);
            Controls.Add(txtName);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucJournals";
            Size = new System.Drawing.Size(402, 58);
            Load += ucJournals_Load;
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epName;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.CheckBox chkSpecialJournal;
    }
}
