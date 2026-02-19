namespace OmniGov.App.Accounting.Views.Dashboard
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
            ucJevDashboard1 = new ucJevDashboard();
            ucJournalsDashboard1 = new ucJournalsDashboard();
            panel2 = new Panel();
            label2 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ucJevDashboard1
            // 
            ucJevDashboard1.Dock = DockStyle.Top;
            ucJevDashboard1.Location = new Point(0, 0);
            ucJevDashboard1.Margin = new Padding(0);
            ucJevDashboard1.Name = "ucJevDashboard1";
            ucJevDashboard1.Size = new Size(990, 187);
            ucJevDashboard1.TabIndex = 18;
            // 
            // ucJournalsDashboard1
            // 
            ucJournalsDashboard1.AutoValidate = AutoValidate.EnableAllowFocusChange;
            ucJournalsDashboard1.Dock = DockStyle.Top;
            ucJournalsDashboard1.Location = new Point(0, 225);
            ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            ucJournalsDashboard1.Size = new Size(990, 135);
            ucJournalsDashboard1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 187);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(4, 15, 4, 4);
            panel2.Size = new Size(990, 38);
            panel2.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(7, 15);
            label2.Name = "label2";
            label2.Size = new Size(74, 17);
            label2.TabIndex = 0;
            label2.Text = "JOURNALS";
            // 
            // ucAccounting
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(ucJournalsDashboard1);
            Controls.Add(panel2);
            Controls.Add(ucJevDashboard1);
            Name = "ucAccounting";
            Size = new Size(990, 412);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ucJevDashboard ucJevDashboard1;
        private ucJournalsDashboard ucJournalsDashboard1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}
