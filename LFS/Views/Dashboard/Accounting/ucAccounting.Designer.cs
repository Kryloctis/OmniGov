namespace LFS.Views.Dashboard.Accounting
{
    partial class ucAccounting
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
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            ucJevDashboard1 = new ucJevDashboard();
            ucJournalsDashboard1 = new LFS.Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            panel2 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4, 15, 4, 4);
            panel1.Size = new System.Drawing.Size(990, 38);
            panel1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(7, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(177, 17);
            label1.TabIndex = 0;
            label1.Text = "JOURNAL ENTRY VOUCHER";
            // 
            // ucJevDashboard1
            // 
            ucJevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            ucJevDashboard1.Location = new System.Drawing.Point(0, 38);
            ucJevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            ucJevDashboard1.Name = "ucJevDashboard1";
            ucJevDashboard1.Padding = new System.Windows.Forms.Padding(4);
            ucJevDashboard1.Size = new System.Drawing.Size(990, 133);
            ucJevDashboard1.TabIndex = 18;
            // 
            // ucJournalsDashboard1
            // 
            ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            ucJournalsDashboard1.Location = new System.Drawing.Point(0, 209);
            ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            ucJournalsDashboard1.Padding = new System.Windows.Forms.Padding(4);
            ucJournalsDashboard1.Size = new System.Drawing.Size(990, 135);
            ucJournalsDashboard1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 171);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4, 15, 4, 4);
            panel2.Size = new System.Drawing.Size(990, 38);
            panel2.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(7, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 17);
            label2.TabIndex = 0;
            label2.Text = "JOURNALS";
            // 
            // ucAccounting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(ucJournalsDashboard1);
            Controls.Add(panel2);
            Controls.Add(ucJevDashboard1);
            Controls.Add(panel1);
            Name = "ucAccounting";
            Size = new System.Drawing.Size(990, 412);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ucJevDashboard ucJevDashboard1;
        private AccountingDashboard.ucJournalsDashboard ucJournalsDashboard1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}
