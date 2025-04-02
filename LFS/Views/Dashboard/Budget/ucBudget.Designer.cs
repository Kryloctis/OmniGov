namespace LFS.Views.Dashboard.Budget
{
    partial class ucBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudget));
            ucBudgetSummary1 = new BudgetDashboard.BudgetSummary.ucBudgetSummary();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            transactionsTstrpDrpDwnBtn = new System.Windows.Forms.ToolStripDropDownButton();
            appropriationsTStrpMnuItm = new System.Windows.Forms.ToolStripMenuItem();
            allotmentReleaseTStrpMnuItm = new System.Windows.Forms.ToolStripMenuItem();
            obligationsTStrpMnuItm = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ucBudgetSummary1
            // 
            ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBudgetSummary1.Location = new System.Drawing.Point(0, 30);
            ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            ucBudgetSummary1.Name = "ucBudgetSummary1";
            ucBudgetSummary1.Size = new System.Drawing.Size(1195, 558);
            ucBudgetSummary1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { transactionsTstrpDrpDwnBtn });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.ShowItemToolTips = false;
            toolStrip1.Size = new System.Drawing.Size(1195, 30);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // transactionsTstrpDrpDwnBtn
            // 
            transactionsTstrpDrpDwnBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            transactionsTstrpDrpDwnBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { appropriationsTStrpMnuItm, allotmentReleaseTStrpMnuItm, obligationsTStrpMnuItm });
            transactionsTstrpDrpDwnBtn.Image = (System.Drawing.Image)resources.GetObject("transactionsTstrpDrpDwnBtn.Image");
            transactionsTstrpDrpDwnBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            transactionsTstrpDrpDwnBtn.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            transactionsTstrpDrpDwnBtn.Name = "transactionsTstrpDrpDwnBtn";
            transactionsTstrpDrpDwnBtn.Size = new System.Drawing.Size(95, 19);
            transactionsTstrpDrpDwnBtn.Text = "● Transactions";
            // 
            // appropriationsTStrpMnuItm
            // 
            appropriationsTStrpMnuItm.Name = "appropriationsTStrpMnuItm";
            appropriationsTStrpMnuItm.Size = new System.Drawing.Size(180, 22);
            appropriationsTStrpMnuItm.Text = "Appropriations...";
            appropriationsTStrpMnuItm.Click += appropriationsTStrpMnuItm_Click;
            // 
            // allotmentReleaseTStrpMnuItm
            // 
            allotmentReleaseTStrpMnuItm.Name = "allotmentReleaseTStrpMnuItm";
            allotmentReleaseTStrpMnuItm.Size = new System.Drawing.Size(180, 22);
            allotmentReleaseTStrpMnuItm.Text = "Allotment Release...";
            allotmentReleaseTStrpMnuItm.Click += allotmentReleaseTStrpMnuItm_Click;
            // 
            // obligationsTStrpMnuItm
            // 
            obligationsTStrpMnuItm.Name = "obligationsTStrpMnuItm";
            obligationsTStrpMnuItm.Size = new System.Drawing.Size(180, 22);
            obligationsTStrpMnuItm.Text = "Obligations...";
            obligationsTStrpMnuItm.Click += obligationsTStrpMnuItm_Click;
            // 
            // ucBudget
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ucBudgetSummary1);
            Controls.Add(toolStrip1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ucBudget";
            Size = new System.Drawing.Size(1195, 588);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BudgetDashboard.BudgetSummary.ucBudgetSummary ucBudgetSummary1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton transactionsTstrpDrpDwnBtn;
        private System.Windows.Forms.ToolStripMenuItem appropriationsTStrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem allotmentReleaseTStrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem obligationsTStrpMnuItm;
    }
}
