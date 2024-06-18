namespace AccountingSystem.Views.Reports.Ltom
{
    partial class frmLtom28
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
            panel3 = new System.Windows.Forms.Panel();
            ucPublicAuctionRegistrationForm1 = new Transactions.Biddings.BiddingReports.ucPublicAuctionRegistrationForm();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(ucPublicAuctionRegistrationForm1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(5);
            panel3.Size = new System.Drawing.Size(800, 450);
            panel3.TabIndex = 13;
            // 
            // ucPublicAuctionRegistrationForm1
            // 
            ucPublicAuctionRegistrationForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPublicAuctionRegistrationForm1.Location = new System.Drawing.Point(5, 5);
            ucPublicAuctionRegistrationForm1.Name = "ucPublicAuctionRegistrationForm1";
            ucPublicAuctionRegistrationForm1.Size = new System.Drawing.Size(790, 440);
            ucPublicAuctionRegistrationForm1.TabIndex = 0;
            ucPublicAuctionRegistrationForm1.Load += ucPublicAuctionRegistrationForm1_Load;
            // 
            // frmLtom28
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel3);
            MinimizeBox = false;
            Name = "frmLtom28";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > Rules and Regulations of Public Auction";
            Load += frmLtom28_Load;
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Transactions.Biddings.BiddingReports.ucPublicAuctionRegistrationForm ucPublicAuctionRegistrationForm1;
    }
}