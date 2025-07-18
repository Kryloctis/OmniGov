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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccounting));
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            manageTstrpDrpDwnBtn = new System.Windows.Forms.ToolStripDropDownButton();
            chartOfAccountsTStrpMnuItm = new System.Windows.Forms.ToolStripMenuItem();
            journalsTStrpMnuItm = new System.Windows.Forms.ToolStripMenuItem();
            ucJevDashboard1 = new ucJevDashboard();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { manageTstrpDrpDwnBtn });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.ShowItemToolTips = false;
            toolStrip2.Size = new System.Drawing.Size(990, 30);
            toolStrip2.TabIndex = 9;
            toolStrip2.Text = "toolStrip2";
            // 
            // manageTstrpDrpDwnBtn
            // 
            manageTstrpDrpDwnBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            manageTstrpDrpDwnBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { chartOfAccountsTStrpMnuItm, journalsTStrpMnuItm });
            manageTstrpDrpDwnBtn.Image = (System.Drawing.Image)resources.GetObject("manageTstrpDrpDwnBtn.Image");
            manageTstrpDrpDwnBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            manageTstrpDrpDwnBtn.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            manageTstrpDrpDwnBtn.Name = "manageTstrpDrpDwnBtn";
            manageTstrpDrpDwnBtn.Size = new System.Drawing.Size(73, 19);
            manageTstrpDrpDwnBtn.Text = "● Manage";
            // 
            // chartOfAccountsTStrpMnuItm
            // 
            chartOfAccountsTStrpMnuItm.Name = "chartOfAccountsTStrpMnuItm";
            chartOfAccountsTStrpMnuItm.Size = new System.Drawing.Size(179, 22);
            chartOfAccountsTStrpMnuItm.Text = "Chart of Accounts...";
            chartOfAccountsTStrpMnuItm.Click += chartOfAccountsTStrpMnuItm_Click;
            // 
            // journalsTStrpMnuItm
            // 
            journalsTStrpMnuItm.Name = "journalsTStrpMnuItm";
            journalsTStrpMnuItm.Size = new System.Drawing.Size(179, 22);
            journalsTStrpMnuItm.Text = "Journals...";
            journalsTStrpMnuItm.Click += journalsTStrpMnuItm_Click;
            // 
            // ucJevDashboard1
            // 
            ucJevDashboard1.AutoSize = true;
            ucJevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            ucJevDashboard1.Location = new System.Drawing.Point(0, 30);
            ucJevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            ucJevDashboard1.MinimumSize = new System.Drawing.Size(782, 160);
            ucJevDashboard1.Name = "ucJevDashboard1";
            ucJevDashboard1.Size = new System.Drawing.Size(990, 170);
            ucJevDashboard1.TabIndex = 10;
            // 
            // ucAccounting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(ucJevDashboard1);
            Controls.Add(toolStrip2);
            Name = "ucAccounting";
            Size = new System.Drawing.Size(990, 525);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton manageTstrpDrpDwnBtn;
        private System.Windows.Forms.ToolStripMenuItem chartOfAccountsTStrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem journalsTStrpMnuItm;
        private ucJevDashboard ucJevDashboard1;
    }
}
