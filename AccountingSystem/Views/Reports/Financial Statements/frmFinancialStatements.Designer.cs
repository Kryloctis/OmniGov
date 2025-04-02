namespace LFS.Views.Reports.Financial_Statements
{
    partial class frmFinancialStatements
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tabPageScf = new System.Windows.Forms.TabPage();
            tabPageScnae = new System.Windows.Forms.TabPage();
            tabPageSfPerformance = new System.Windows.Forms.TabPage();
            tabPageSfPosition = new System.Windows.Forms.TabPage();
            ucStatementOfFinancialPosition1 = new ucStatementOfFinancialPosition();
            tabControlFinancialStatements = new System.Windows.Forms.TabControl();
            ucStatementOfChangesInNetAssetsEquity1 = new ucStatementOfChangesInNetAssetsEquity();
            ucStatementOfCashFlows1 = new ucStatementOfCashFlows();
            ucStatementOfFinancialPerformance1 = new ucStatementOfFinancialPerformance();
            tabPageScf.SuspendLayout();
            tabPageScnae.SuspendLayout();
            tabPageSfPerformance.SuspendLayout();
            tabPageSfPosition.SuspendLayout();
            tabControlFinancialStatements.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabPageScf
            // 
            tabPageScf.Controls.Add(ucStatementOfCashFlows1);
            tabPageScf.Location = new System.Drawing.Point(4, 24);
            tabPageScf.Name = "tabPageScf";
            tabPageScf.Size = new System.Drawing.Size(792, 400);
            tabPageScf.TabIndex = 3;
            tabPageScf.Text = "Statement of Cash Flows";
            tabPageScf.UseVisualStyleBackColor = true;
            // 
            // tabPageScnae
            // 
            tabPageScnae.Controls.Add(ucStatementOfChangesInNetAssetsEquity1);
            tabPageScnae.Location = new System.Drawing.Point(4, 24);
            tabPageScnae.Name = "tabPageScnae";
            tabPageScnae.Size = new System.Drawing.Size(792, 400);
            tabPageScnae.TabIndex = 2;
            tabPageScnae.Text = "Statement of Changes in Net Assets/Equity";
            tabPageScnae.UseVisualStyleBackColor = true;
            // 
            // tabPageSfPerformance
            // 
            tabPageSfPerformance.Controls.Add(ucStatementOfFinancialPerformance1);
            tabPageSfPerformance.Location = new System.Drawing.Point(4, 24);
            tabPageSfPerformance.Name = "tabPageSfPerformance";
            tabPageSfPerformance.Size = new System.Drawing.Size(792, 400);
            tabPageSfPerformance.TabIndex = 1;
            tabPageSfPerformance.Text = "Statement of Financial Performance";
            tabPageSfPerformance.UseVisualStyleBackColor = true;
            // 
            // tabPageSfPosition
            // 
            tabPageSfPosition.Controls.Add(ucStatementOfFinancialPosition1);
            tabPageSfPosition.Location = new System.Drawing.Point(4, 24);
            tabPageSfPosition.Name = "tabPageSfPosition";
            tabPageSfPosition.Size = new System.Drawing.Size(792, 400);
            tabPageSfPosition.TabIndex = 0;
            tabPageSfPosition.Text = "Statement of Financial Position";
            tabPageSfPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            ucStatementOfFinancialPosition1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(792, 400);
            ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabControlFinancialStatements
            // 
            tabControlFinancialStatements.Controls.Add(tabPageSfPosition);
            tabControlFinancialStatements.Controls.Add(tabPageSfPerformance);
            tabControlFinancialStatements.Controls.Add(tabPageScnae);
            tabControlFinancialStatements.Controls.Add(tabPageScf);
            tabControlFinancialStatements.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlFinancialStatements.Location = new System.Drawing.Point(0, 0);
            tabControlFinancialStatements.Name = "tabControlFinancialStatements";
            tabControlFinancialStatements.SelectedIndex = 0;
            tabControlFinancialStatements.Size = new System.Drawing.Size(800, 428);
            tabControlFinancialStatements.TabIndex = 1;
            tabControlFinancialStatements.SelectedIndexChanged += tabControlFinancialStatements_SelectedIndexChanged;
            // 
            // ucStatementOfChangesInNetAssetsEquity1
            // 
            ucStatementOfChangesInNetAssetsEquity1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfChangesInNetAssetsEquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfChangesInNetAssetsEquity1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfChangesInNetAssetsEquity1.Name = "ucStatementOfChangesInNetAssetsEquity1";
            ucStatementOfChangesInNetAssetsEquity1.Size = new System.Drawing.Size(792, 400);
            ucStatementOfChangesInNetAssetsEquity1.TabIndex = 0;
            // 
            // ucStatementOfCashFlows1
            // 
            ucStatementOfCashFlows1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfCashFlows1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfCashFlows1.Name = "ucStatementOfCashFlows1";
            ucStatementOfCashFlows1.Size = new System.Drawing.Size(792, 400);
            ucStatementOfCashFlows1.TabIndex = 0;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            ucStatementOfFinancialPerformance1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(792, 400);
            ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // frmFinancialStatements
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(tabControlFinancialStatements);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmFinancialStatements";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Financial Statements";
            Load += frmFinancialStatements_Load;
            tabPageScf.ResumeLayout(false);
            tabPageScnae.ResumeLayout(false);
            tabPageSfPerformance.ResumeLayout(false);
            tabPageSfPosition.ResumeLayout(false);
            tabControlFinancialStatements.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPageScf;
        private System.Windows.Forms.TabPage tabPageScnae;
        private System.Windows.Forms.TabPage tabPageSfPerformance;
        private System.Windows.Forms.TabPage tabPageSfPosition;
        private System.Windows.Forms.TabControl tabControlFinancialStatements;
        private ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private ucStatementOfChangesInNetAssetsEquity ucStatementOfChangesInNetAssetsEquity1;
        private ucStatementOfCashFlows ucStatementOfCashFlows1;
        private ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
    }
}