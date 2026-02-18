namespace OmniGov.App.Budget.Views.Dashboard
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
            ucBudgetSummary1 = new ucBudgetSummary();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnAppropriations = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnAlltmntRelease = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnObligationRequest = new System.Windows.Forms.ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ucBudgetSummary1
            // 
            ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBudgetSummary1.Location = new System.Drawing.Point(0, 47);
            ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            ucBudgetSummary1.Name = "ucBudgetSummary1";
            ucBudgetSummary1.Size = new System.Drawing.Size(1125, 541);
            ucBudgetSummary1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnAppropriations, tlStrpBtnAlltmntRelease, tlStrpBtnObligationRequest });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 20);
            toolStrip1.ShowItemToolTips = false;
            toolStrip1.Size = new System.Drawing.Size(1125, 47);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnAppropriations
            // 
            tlStrpBtnAppropriations.Image = Properties.Resources.folder_filled_20px;
            tlStrpBtnAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnAppropriations.Name = "tlStrpBtnAppropriations";
            tlStrpBtnAppropriations.Size = new System.Drawing.Size(106, 20);
            tlStrpBtnAppropriations.Text = "Appropriations";
            tlStrpBtnAppropriations.Click += tlStrpBtnAppropriations_Click;
            // 
            // tlStrpBtnAlltmntRelease
            // 
            tlStrpBtnAlltmntRelease.Image = Properties.Resources.folder_filled_20px;
            tlStrpBtnAlltmntRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnAlltmntRelease.Name = "tlStrpBtnAlltmntRelease";
            tlStrpBtnAlltmntRelease.Size = new System.Drawing.Size(122, 20);
            tlStrpBtnAlltmntRelease.Text = "Allotment Release";
            tlStrpBtnAlltmntRelease.Click += tlStrpBtnAlltmntRelease_Click;
            // 
            // tlStrpBtnObligationRequest
            // 
            tlStrpBtnObligationRequest.Image = Properties.Resources.folder_filled_20px;
            tlStrpBtnObligationRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnObligationRequest.Name = "tlStrpBtnObligationRequest";
            tlStrpBtnObligationRequest.Size = new System.Drawing.Size(128, 20);
            tlStrpBtnObligationRequest.Text = "Obligation Request";
            tlStrpBtnObligationRequest.Click += tlStrpBtnObligations_Click;
            // 
            // ucBudget
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(ucBudgetSummary1);
            Controls.Add(toolStrip1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ucBudget";
            Size = new System.Drawing.Size(1125, 588);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ucBudgetSummary ucBudgetSummary1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAlltmntRelease;
        private System.Windows.Forms.ToolStripButton tlStrpBtnObligationRequest;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAppropriations;
    }
}
