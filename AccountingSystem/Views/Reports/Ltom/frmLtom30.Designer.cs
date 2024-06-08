namespace AccountingSystem.Views.Reports.Ltom
{
    partial class frmLtom30
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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            btnRunReport = new System.Windows.Forms.Button();
            panel3 = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            ucDeclarationOfForfeitureOfDelinquentProperty1 = new Transactions.Auction.ucDeclarationOfForfeitureOfDelinquentProperty();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnRunReport);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(840, 406);
            splitContainer1.SplitterDistance = 211;
            splitContainer1.TabIndex = 8;
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(7, 114);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 19;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(ucDeclarationOfForfeitureOfDelinquentProperty1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(617, 398);
            panel3.TabIndex = 12;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // ucDeclarationOfForfeitureOfDelinquentProperty1
            // 
            ucDeclarationOfForfeitureOfDelinquentProperty1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucDeclarationOfForfeitureOfDelinquentProperty1.Location = new System.Drawing.Point(0, 0);
            ucDeclarationOfForfeitureOfDelinquentProperty1.Name = "ucDeclarationOfForfeitureOfDelinquentProperty1";
            ucDeclarationOfForfeitureOfDelinquentProperty1.Size = new System.Drawing.Size(617, 398);
            ucDeclarationOfForfeitureOfDelinquentProperty1.TabIndex = 0;
            // 
            // frmLtom30
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmLtom30";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > Declaration of Forfeiture of Delinquent Property";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Transactions.Auction.ucDeclarationOfForfeitureOfDelinquentProperty ucDeclarationOfForfeitureOfDelinquentProperty1;
    }
}