
namespace AccountingSystem.Views.Reports.Financial_Statements
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
            this.tabControlFinancialStatements = new System.Windows.Forms.TabControl();
            this.tabPageSFPosition = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPosition1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPosition();
            this.tabPageSFPerformance = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPerformance1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance();
            this.tabPageSCNAE = new System.Windows.Forms.TabPage();
            this.ucStatementOfChangesInNetAssetsquity1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsquity();
            this.tabPageSCF = new System.Windows.Forms.TabPage();
            this.tabPageSCBAA = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radSFPosition = new System.Windows.Forms.RadioButton();
            this.radSFPerformance = new System.Windows.Forms.RadioButton();
            this.radSCNAE = new System.Windows.Forms.RadioButton();
            this.radSCF = new System.Windows.Forms.RadioButton();
            this.radSCBAA = new System.Windows.Forms.RadioButton();
            this.tabControlFinancialStatements.SuspendLayout();
            this.tabPageSFPosition.SuspendLayout();
            this.tabPageSFPerformance.SuspendLayout();
            this.tabPageSCNAE.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlFinancialStatements
            // 
            this.tabControlFinancialStatements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFinancialStatements.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPosition);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPerformance);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCNAE);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCF);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCBAA);
            this.tabControlFinancialStatements.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlFinancialStatements.Location = new System.Drawing.Point(0, 46);
            this.tabControlFinancialStatements.Name = "tabControlFinancialStatements";
            this.tabControlFinancialStatements.SelectedIndex = 0;
            this.tabControlFinancialStatements.Size = new System.Drawing.Size(1163, 524);
            this.tabControlFinancialStatements.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlFinancialStatements.TabIndex = 1;
            // 
            // tabPageSFPosition
            // 
            this.tabPageSFPosition.Controls.Add(this.ucStatementOfFinancialPosition1);
            this.tabPageSFPosition.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPosition.Name = "tabPageSFPosition";
            this.tabPageSFPosition.Size = new System.Drawing.Size(1155, 515);
            this.tabPageSFPosition.TabIndex = 0;
            this.tabPageSFPosition.Text = "tabSFPosition";
            this.tabPageSFPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            this.ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            this.ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(1155, 515);
            this.ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabPageSFPerformance
            // 
            this.tabPageSFPerformance.Controls.Add(this.ucStatementOfFinancialPerformance1);
            this.tabPageSFPerformance.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPerformance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPerformance.Name = "tabPageSFPerformance";
            this.tabPageSFPerformance.Size = new System.Drawing.Size(1155, 515);
            this.tabPageSFPerformance.TabIndex = 1;
            this.tabPageSFPerformance.Text = "tabSFPerformance";
            this.tabPageSFPerformance.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            this.ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            this.ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(1155, 515);
            this.ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // tabPageSCNAE
            // 
            this.tabPageSCNAE.Controls.Add(this.ucStatementOfChangesInNetAssetsquity1);
            this.tabPageSCNAE.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCNAE.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCNAE.Name = "tabPageSCNAE";
            this.tabPageSCNAE.Size = new System.Drawing.Size(1155, 515);
            this.tabPageSCNAE.TabIndex = 2;
            this.tabPageSCNAE.Text = "tabSCNAE";
            this.tabPageSCNAE.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfChangesInNetAssetsquity1
            // 
            this.ucStatementOfChangesInNetAssetsquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfChangesInNetAssetsquity1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfChangesInNetAssetsquity1.Name = "ucStatementOfChangesInNetAssetsquity1";
            this.ucStatementOfChangesInNetAssetsquity1.Size = new System.Drawing.Size(1155, 515);
            this.ucStatementOfChangesInNetAssetsquity1.TabIndex = 0;
            // 
            // tabPageSCF
            // 
            this.tabPageSCF.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCF.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCF.Name = "tabPageSCF";
            this.tabPageSCF.Size = new System.Drawing.Size(1155, 515);
            this.tabPageSCF.TabIndex = 3;
            this.tabPageSCF.Text = "tabSCF";
            this.tabPageSCF.UseVisualStyleBackColor = true;
            // 
            // tabPageSCBAA
            // 
            this.tabPageSCBAA.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCBAA.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCBAA.Name = "tabPageSCBAA";
            this.tabPageSCBAA.Size = new System.Drawing.Size(1155, 515);
            this.tabPageSCBAA.TabIndex = 4;
            this.tabPageSCBAA.Text = "tabSCBAA";
            this.tabPageSCBAA.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.radSFPosition);
            this.flowLayoutPanel1.Controls.Add(this.radSFPerformance);
            this.flowLayoutPanel1.Controls.Add(this.radSCNAE);
            this.flowLayoutPanel1.Controls.Add(this.radSCF);
            this.flowLayoutPanel1.Controls.Add(this.radSCBAA);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1163, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // radSFPosition
            // 
            this.radSFPosition.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSFPosition.AutoSize = true;
            this.radSFPosition.Enabled = false;
            this.radSFPosition.Location = new System.Drawing.Point(3, 3);
            this.radSFPosition.Name = "radSFPosition";
            this.radSFPosition.Size = new System.Drawing.Size(181, 25);
            this.radSFPosition.TabIndex = 5;
            this.radSFPosition.Text = "Statement of Financial Position";
            this.radSFPosition.UseVisualStyleBackColor = true;
            this.radSFPosition.CheckedChanged += new System.EventHandler(this.radSFPosition_CheckedChanged);
            // 
            // radSFPerformance
            // 
            this.radSFPerformance.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSFPerformance.AutoSize = true;
            this.radSFPerformance.Checked = true;
            this.radSFPerformance.Location = new System.Drawing.Point(190, 3);
            this.radSFPerformance.Name = "radSFPerformance";
            this.radSFPerformance.Size = new System.Drawing.Size(206, 25);
            this.radSFPerformance.TabIndex = 4;
            this.radSFPerformance.TabStop = true;
            this.radSFPerformance.Text = "Statement of Financial Performance";
            this.radSFPerformance.UseVisualStyleBackColor = true;
            this.radSFPerformance.CheckedChanged += new System.EventHandler(this.radSFPerformance_CheckedChanged);
            // 
            // radSCNAE
            // 
            this.radSCNAE.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCNAE.AutoSize = true;
            this.radSCNAE.Location = new System.Drawing.Point(402, 3);
            this.radSCNAE.Name = "radSCNAE";
            this.radSCNAE.Size = new System.Drawing.Size(243, 25);
            this.radSCNAE.TabIndex = 3;
            this.radSCNAE.Text = "Statement of Changes in Net Assets/Equity";
            this.radSCNAE.UseVisualStyleBackColor = true;
            this.radSCNAE.CheckedChanged += new System.EventHandler(this.radSCNAE_CheckedChanged);
            // 
            // radSCF
            // 
            this.radSCF.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCF.AutoSize = true;
            this.radSCF.Enabled = false;
            this.radSCF.Location = new System.Drawing.Point(651, 3);
            this.radSCF.Name = "radSCF";
            this.radSCF.Size = new System.Drawing.Size(147, 25);
            this.radSCF.TabIndex = 2;
            this.radSCF.Text = "Statement of Cash Flows";
            this.radSCF.UseVisualStyleBackColor = true;
            this.radSCF.CheckedChanged += new System.EventHandler(this.radSCF_CheckedChanged);
            // 
            // radSCBAA
            // 
            this.radSCBAA.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCBAA.AutoSize = true;
            this.radSCBAA.Enabled = false;
            this.radSCBAA.Location = new System.Drawing.Point(804, 3);
            this.radSCBAA.Name = "radSCBAA";
            this.radSCBAA.Size = new System.Drawing.Size(320, 25);
            this.radSCBAA.TabIndex = 1;
            this.radSCBAA.Text = "Statement of Comparison of Budget and Actual Amounts";
            this.radSCBAA.UseVisualStyleBackColor = true;
            this.radSCBAA.CheckedChanged += new System.EventHandler(this.radSCBAA_CheckedChanged);
            // 
            // frmFinancialStatements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 570);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControlFinancialStatements);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1138, 583);
            this.Name = "frmFinancialStatements";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Statements";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFinancialStatements_Load);
            this.tabControlFinancialStatements.ResumeLayout(false);
            this.tabPageSFPosition.ResumeLayout(false);
            this.tabPageSFPerformance.ResumeLayout(false);
            this.tabPageSCNAE.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlFinancialStatements;
        private System.Windows.Forms.TabPage tabPageSFPosition;
        private System.Windows.Forms.TabPage tabPageSFPerformance;
        private System.Windows.Forms.TabPage tabPageSCNAE;
        private System.Windows.Forms.TabPage tabPageSCF;
        private System.Windows.Forms.TabPage tabPageSCBAA;
        private ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radSFPosition;
        private System.Windows.Forms.RadioButton radSFPerformance;
        private System.Windows.Forms.RadioButton radSCF;
        private System.Windows.Forms.RadioButton radSCNAE;
        private System.Windows.Forms.RadioButton radSCBAA;
        private ucStatementOfChangesInNetAssetsquity ucStatementOfChangesInNetAssetsquity1;
    }
}