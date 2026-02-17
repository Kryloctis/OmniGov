namespace LFS.Views.Manage.DatabaseSynchronization
{
    partial class frmDatabaseSynchronization
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorkerRptSync = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.ucDatabaseSynchronization1 = new LFS.Views.Manage.DatabaseSynchronization.ucDatabaseSynchronization();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerRptSync
            // 
            this.backgroundWorkerRptSync.WorkerReportsProgress = true;
            this.backgroundWorkerRptSync.WorkerSupportsCancellation = true;
            this.backgroundWorkerRptSync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRptSync_DoWork);
            this.backgroundWorkerRptSync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRptSync_ProgressChanged);
            this.backgroundWorkerRptSync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRptSync_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnSync);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 29);
            this.panel1.TabIndex = 18;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(380, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(67, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSync.Location = new System.Drawing.Point(307, 3);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(67, 23);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Sync";
            this.btnSync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // ucDatabaseSynchronization1
            // 
            this.ucDatabaseSynchronization1.AutoSize = true;
            this.ucDatabaseSynchronization1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDatabaseSynchronization1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDatabaseSynchronization1.Location = new System.Drawing.Point(0, 0);
            this.ucDatabaseSynchronization1.Name = "ucDatabaseSynchronization1";
            this.ucDatabaseSynchronization1.Padding = new System.Windows.Forms.Padding(4);
            this.ucDatabaseSynchronization1.Size = new System.Drawing.Size(450, 37);
            this.ucDatabaseSynchronization1.TabIndex = 19;
            // 
            // frmDatabaseSynchronization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(450, 66);
            this.Controls.Add(this.ucDatabaseSynchronization1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseSynchronization";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Synchronization";
            this.Load += new System.EventHandler(this.frmDatabaseSynchronization_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerRptSync;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSync;
        private ucDatabaseSynchronization ucDatabaseSynchronization1;
    }
}
