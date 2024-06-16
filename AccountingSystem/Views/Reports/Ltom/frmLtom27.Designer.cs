namespace AccountingSystem.Views.Reports.Ltom
{
    partial class frmLtom27
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
            cmbxBidders = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            cmbxAuctionSchedule = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            ucUnderTakingAndWaiverOfBidders1 = new Transactions.Biddings.BiddingReports.ucUnderTakingAndWaiverOfBidders();
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
            splitContainer1.Panel1.Controls.Add(cmbxBidders);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnRunReport);
            splitContainer1.Panel1.Controls.Add(cmbxAuctionSchedule);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(800, 428);
            splitContainer1.SplitterDistance = 211;
            splitContainer1.TabIndex = 8;
            // 
            // cmbxBidders
            // 
            cmbxBidders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBidders.FormattingEnabled = true;
            cmbxBidders.Location = new System.Drawing.Point(7, 77);
            cmbxBidders.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxBidders.Name = "cmbxBidders";
            cmbxBidders.Size = new System.Drawing.Size(200, 23);
            cmbxBidders.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(7, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 20;
            label1.Text = "Bidders : ";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(7, 108);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 19;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // cmbxAuctionSchedule
            // 
            cmbxAuctionSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAuctionSchedule.FormattingEnabled = true;
            cmbxAuctionSchedule.Location = new System.Drawing.Point(7, 29);
            cmbxAuctionSchedule.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxAuctionSchedule.Name = "cmbxAuctionSchedule";
            cmbxAuctionSchedule.Size = new System.Drawing.Size(200, 23);
            cmbxAuctionSchedule.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(7, 12);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 15);
            label3.TabIndex = 17;
            label3.Text = "Auction Schedule :";
            // 
            // panel3
            // 
            panel3.Controls.Add(ucUnderTakingAndWaiverOfBidders1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(577, 420);
            panel3.TabIndex = 12;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // ucUnderTakingAndWaiverOfBidders1
            // 
            ucUnderTakingAndWaiverOfBidders1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucUnderTakingAndWaiverOfBidders1.Location = new System.Drawing.Point(0, 0);
            ucUnderTakingAndWaiverOfBidders1.Name = "ucUnderTakingAndWaiverOfBidders1";
            ucUnderTakingAndWaiverOfBidders1.Size = new System.Drawing.Size(577, 420);
            ucUnderTakingAndWaiverOfBidders1.TabIndex = 0;
            // 
            // frmLtom27
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmLtom27";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > Undertaking and Waivers of Bidders";
            Load += frmLtom27_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbxBidders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ComboBox cmbxAuctionSchedule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Transactions.Biddings.BiddingReports.ucUnderTakingAndWaiverOfBidders ucUnderTakingAndWaiverOfBidders1;
    }
}