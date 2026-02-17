namespace LFS.Views.Manage.DatabaseSynchronization
{
    partial class ucDatabaseSynchronization
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
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxSyncType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoEllipsis = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(5, 33);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(440, 22);
            this.lblProgressStatus.TabIndex = 23;
            this.lblProgressStatus.Text = "status";
            this.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProgressStatus.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 55);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 10);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Choose what to Sync";
            // 
            // cmbxSyncType
            // 
            this.cmbxSyncType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSyncType.FormattingEnabled = true;
            this.cmbxSyncType.Location = new System.Drawing.Point(129, 7);
            this.cmbxSyncType.Name = "cmbxSyncType";
            this.cmbxSyncType.Size = new System.Drawing.Size(316, 23);
            this.cmbxSyncType.TabIndex = 24;
            // 
            // ucDatabaseSynchronization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxSyncType);
            this.Controls.Add(this.lblProgressStatus);
            this.Controls.Add(this.progressBar1);
            this.Name = "ucDatabaseSynchronization";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(452, 69);
            this.Load += new System.EventHandler(this.ucDatabaseSynchronization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblProgressStatus;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbxSyncType;
    }
}
