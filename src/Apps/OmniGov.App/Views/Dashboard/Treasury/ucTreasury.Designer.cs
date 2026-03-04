using OmniGov.App.Views.Dashboard.Treasury;

namespace OmniGov.App.Views.Dashboard.Treasury
{
    partial class ucTreasury
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
            toolStrip3 = new ToolStrip();
            manageTstripDrpDwnBtn = new ToolStripDropDownButton();
            receiptsToolStripMenuItem = new ToolStripMenuItem();
            receiptInventoryTstrpMnuItm = new ToolStripMenuItem();
            recieiptIssuanceTstrpMnuItm = new ToolStripMenuItem();
            cashTicketsToolStripMenuItem = new ToolStripMenuItem();
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            issuanceToolStripMenuItem = new ToolStripMenuItem();
            realPropertiesTstrpMnuItm = new ToolStripMenuItem();
            taxpayersTstrpMnuItm = new ToolStripMenuItem();
            collectingOfficersTstrpMnuItm = new ToolStripMenuItem();
            disbursementOfficersTstrpMnuItm = new ToolStripMenuItem();
            feesChargesTstrpMnuItm = new ToolStripMenuItem();
            transactionsTstripDrpDwnBtn = new ToolStripDropDownButton();
            paymentsToolStripMenuItem = new ToolStripMenuItem();
            aF41CommunityTaxToolStripMenuItem = new ToolStripMenuItem();
            af56TstrpMnuItm = new ToolStripMenuItem();
            af5157TstrpMnuItm = new ToolStripMenuItem();
            af54TstrpMnuItm = new ToolStripMenuItem();
            af58TstrpMnuItm = new ToolStripMenuItem();
            af53TstrpMnuItm = new ToolStripMenuItem();
            af52TstrpMnuItm = new ToolStripMenuItem();
            pymntHstoryTstrpMnuItm = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            tStrpMenuItmPrptyTaxPosting = new ToolStripMenuItem();
            dellinquencyNoticesToolStripMenuItem = new ToolStripMenuItem();
            warrantsOfLevyToolStripMenuItem = new ToolStripMenuItem();
            auctionTstrpMnuItm = new ToolStripMenuItem();
            biddingTstrpMnuItm = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            checkIssuanceTstrpMnuItm = new ToolStripMenuItem();
            releasedAndUnreleaseChecksTstrpMnuItm = new ToolStripMenuItem();
            bankDepositTstrpMnuItm = new ToolStripMenuItem();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = Color.Transparent;
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.Items.AddRange(new ToolStripItem[] { manageTstripDrpDwnBtn, transactionsTstripDrpDwnBtn });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new Padding(4);
            toolStrip3.ShowItemToolTips = false;
            toolStrip3.Size = new Size(810, 31);
            toolStrip3.TabIndex = 6;
            toolStrip3.Text = "toolStrip3";
            // 
            // manageTstripDrpDwnBtn
            // 
            manageTstripDrpDwnBtn.DropDownItems.AddRange(new ToolStripItem[] { receiptsToolStripMenuItem, cashTicketsToolStripMenuItem, realPropertiesTstrpMnuItm, taxpayersTstrpMnuItm, collectingOfficersTstrpMnuItm, disbursementOfficersTstrpMnuItm, feesChargesTstrpMnuItm });
            manageTstripDrpDwnBtn.Image = Properties.Resources.folder_filled_16px;
            manageTstripDrpDwnBtn.ImageTransparentColor = Color.Magenta;
            manageTstripDrpDwnBtn.Margin = new Padding(0, 1, 10, 2);
            manageTstripDrpDwnBtn.Name = "manageTstripDrpDwnBtn";
            manageTstripDrpDwnBtn.Size = new Size(79, 20);
            manageTstripDrpDwnBtn.Text = "Manage";
            // 
            // receiptsToolStripMenuItem
            // 
            receiptsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { receiptInventoryTstrpMnuItm, recieiptIssuanceTstrpMnuItm });
            receiptsToolStripMenuItem.Name = "receiptsToolStripMenuItem";
            receiptsToolStripMenuItem.Size = new Size(204, 22);
            receiptsToolStripMenuItem.Text = "Receipts";
            // 
            // receiptInventoryTstrpMnuItm
            // 
            receiptInventoryTstrpMnuItm.Name = "receiptInventoryTstrpMnuItm";
            receiptInventoryTstrpMnuItm.Size = new Size(124, 22);
            receiptInventoryTstrpMnuItm.Text = "Inventory";
            receiptInventoryTstrpMnuItm.Click += receiptInventoryTstrpMnuItm_Click;
            // 
            // recieiptIssuanceTstrpMnuItm
            // 
            recieiptIssuanceTstrpMnuItm.Name = "recieiptIssuanceTstrpMnuItm";
            recieiptIssuanceTstrpMnuItm.Size = new Size(124, 22);
            recieiptIssuanceTstrpMnuItm.Text = "Issuance";
            recieiptIssuanceTstrpMnuItm.Click += recieiptIssuanceTstrpMnuItm_Click;
            // 
            // cashTicketsToolStripMenuItem
            // 
            cashTicketsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventoryToolStripMenuItem, issuanceToolStripMenuItem });
            cashTicketsToolStripMenuItem.Name = "cashTicketsToolStripMenuItem";
            cashTicketsToolStripMenuItem.Size = new Size(204, 22);
            cashTicketsToolStripMenuItem.Text = "Cash Tickets";
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(124, 22);
            inventoryToolStripMenuItem.Text = "Inventory";
            inventoryToolStripMenuItem.Click += inventoryToolStripMenuItem_Click;
            // 
            // issuanceToolStripMenuItem
            // 
            issuanceToolStripMenuItem.Name = "issuanceToolStripMenuItem";
            issuanceToolStripMenuItem.Size = new Size(124, 22);
            issuanceToolStripMenuItem.Text = "Issuance";
            issuanceToolStripMenuItem.Click += issuanceToolStripMenuItem_Click;
            // 
            // realPropertiesTstrpMnuItm
            // 
            realPropertiesTstrpMnuItm.Name = "realPropertiesTstrpMnuItm";
            realPropertiesTstrpMnuItm.Size = new Size(204, 22);
            realPropertiesTstrpMnuItm.Text = "Real Properties...";
            realPropertiesTstrpMnuItm.Click += realPropertiesTstrpMnuItm_Click;
            // 
            // taxpayersTstrpMnuItm
            // 
            taxpayersTstrpMnuItm.Name = "taxpayersTstrpMnuItm";
            taxpayersTstrpMnuItm.Size = new Size(204, 22);
            taxpayersTstrpMnuItm.Text = "Taxpayers...";
            taxpayersTstrpMnuItm.Click += taxpayersTstrpMnuItm_Click;
            // 
            // collectingOfficersTstrpMnuItm
            // 
            collectingOfficersTstrpMnuItm.Name = "collectingOfficersTstrpMnuItm";
            collectingOfficersTstrpMnuItm.Size = new Size(204, 22);
            collectingOfficersTstrpMnuItm.Text = "Collecting Officers...";
            collectingOfficersTstrpMnuItm.Click += collectingOfficersTstrpMnuItm_Click;
            // 
            // disbursementOfficersTstrpMnuItm
            // 
            disbursementOfficersTstrpMnuItm.Name = "disbursementOfficersTstrpMnuItm";
            disbursementOfficersTstrpMnuItm.Size = new Size(204, 22);
            disbursementOfficersTstrpMnuItm.Text = "Disbursement Officers...";
            disbursementOfficersTstrpMnuItm.Click += disbursementOfficersTstrpMnuItm_Click;
            // 
            // feesChargesTstrpMnuItm
            // 
            feesChargesTstrpMnuItm.Name = "feesChargesTstrpMnuItm";
            feesChargesTstrpMnuItm.Size = new Size(204, 22);
            feesChargesTstrpMnuItm.Text = "Fees && Charges Config...";
            feesChargesTstrpMnuItm.Click += feesChargesTstrpMnuItm_Click;
            // 
            // transactionsTstripDrpDwnBtn
            // 
            transactionsTstripDrpDwnBtn.DropDownItems.AddRange(new ToolStripItem[] { paymentsToolStripMenuItem, pymntHstoryTstrpMnuItm, toolStripSeparator10, tStrpMenuItmPrptyTaxPosting, dellinquencyNoticesToolStripMenuItem, warrantsOfLevyToolStripMenuItem, auctionTstrpMnuItm, biddingTstrpMnuItm, toolStripSeparator11, checkIssuanceTstrpMnuItm, releasedAndUnreleaseChecksTstrpMnuItm, bankDepositTstrpMnuItm });
            transactionsTstripDrpDwnBtn.Image = Properties.Resources.folder_filled_16px;
            transactionsTstripDrpDwnBtn.ImageTransparentColor = Color.Magenta;
            transactionsTstripDrpDwnBtn.Margin = new Padding(0, 1, 10, 2);
            transactionsTstripDrpDwnBtn.Name = "transactionsTstripDrpDwnBtn";
            transactionsTstripDrpDwnBtn.Size = new Size(101, 20);
            transactionsTstripDrpDwnBtn.Text = "Transactions";
            // 
            // paymentsToolStripMenuItem
            // 
            paymentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aF41CommunityTaxToolStripMenuItem, af56TstrpMnuItm, af5157TstrpMnuItm, af54TstrpMnuItm, af58TstrpMnuItm, af53TstrpMnuItm, af52TstrpMnuItm });
            paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            paymentsToolStripMenuItem.Size = new Size(226, 22);
            paymentsToolStripMenuItem.Text = "Payments";
            // 
            // aF41CommunityTaxToolStripMenuItem
            // 
            aF41CommunityTaxToolStripMenuItem.Name = "aF41CommunityTaxToolStripMenuItem";
            aF41CommunityTaxToolStripMenuItem.Size = new Size(369, 22);
            aF41CommunityTaxToolStripMenuItem.Text = "AF 15 - Community Tax Certificate (CTC)";
            aF41CommunityTaxToolStripMenuItem.Click += aF41CommunityTaxToolStripMenuItem_Click;
            // 
            // af56TstrpMnuItm
            // 
            af56TstrpMnuItm.Name = "af56TstrpMnuItm";
            af56TstrpMnuItm.Size = new Size(369, 22);
            af56TstrpMnuItm.Text = "AF 56 - Real Property Tax...";
            af56TstrpMnuItm.Click += af56TstrpMnuItm_Click;
            // 
            // af5157TstrpMnuItm
            // 
            af5157TstrpMnuItm.Name = "af5157TstrpMnuItm";
            af5157TstrpMnuItm.Size = new Size(369, 22);
            af5157TstrpMnuItm.Text = "AF 51 && 57 OR and  Slaughter Permit && Fee...";
            af5157TstrpMnuItm.Click += af5157TstrpMnuItm_Click;
            // 
            // af54TstrpMnuItm
            // 
            af54TstrpMnuItm.Name = "af54TstrpMnuItm";
            af54TstrpMnuItm.Size = new Size(369, 22);
            af54TstrpMnuItm.Text = "AF 54 - Marriage License...";
            af54TstrpMnuItm.Click += af54TstrpMnuItm_Click;
            // 
            // af58TstrpMnuItm
            // 
            af58TstrpMnuItm.Name = "af58TstrpMnuItm";
            af58TstrpMnuItm.Size = new Size(369, 22);
            af58TstrpMnuItm.Text = "AF 58 - Burial Permit && Fee...";
            af58TstrpMnuItm.Click += af58TstrpMnuItm_Click;
            // 
            // af53TstrpMnuItm
            // 
            af53TstrpMnuItm.Name = "af53TstrpMnuItm";
            af53TstrpMnuItm.Size = new Size(369, 22);
            af53TstrpMnuItm.Text = "AF 53 - Certificate of Ownership of Large Cattle...";
            af53TstrpMnuItm.Click += af53TstrpMnuItm_Click;
            // 
            // af52TstrpMnuItm
            // 
            af52TstrpMnuItm.Name = "af52TstrpMnuItm";
            af52TstrpMnuItm.Size = new Size(369, 22);
            af52TstrpMnuItm.Text = "AF 52 - Certificate of Record of Transfer of Large Cattle...";
            af52TstrpMnuItm.Click += af52TstrpMnuItm_Click;
            // 
            // pymntHstoryTstrpMnuItm
            // 
            pymntHstoryTstrpMnuItm.Name = "pymntHstoryTstrpMnuItm";
            pymntHstoryTstrpMnuItm.Size = new Size(226, 22);
            pymntHstoryTstrpMnuItm.Text = "Payment History...";
            pymntHstoryTstrpMnuItm.Click += pymntHstoryTstrpMnuItm_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(223, 6);
            // 
            // tStrpMenuItmPrptyTaxPosting
            // 
            tStrpMenuItmPrptyTaxPosting.Name = "tStrpMenuItmPrptyTaxPosting";
            tStrpMenuItmPrptyTaxPosting.Size = new Size(226, 22);
            tStrpMenuItmPrptyTaxPosting.Text = "Tax Posting..";
            tStrpMenuItmPrptyTaxPosting.Click += propertyTaxPostingToolStripMenuItem1_Click;
            // 
            // dellinquencyNoticesToolStripMenuItem
            // 
            dellinquencyNoticesToolStripMenuItem.Name = "dellinquencyNoticesToolStripMenuItem";
            dellinquencyNoticesToolStripMenuItem.Size = new Size(226, 22);
            dellinquencyNoticesToolStripMenuItem.Text = "Delinquency Notices...";
            dellinquencyNoticesToolStripMenuItem.Click += propertyAssessmentToolStripMenuItem_Click;
            // 
            // warrantsOfLevyToolStripMenuItem
            // 
            warrantsOfLevyToolStripMenuItem.Name = "warrantsOfLevyToolStripMenuItem";
            warrantsOfLevyToolStripMenuItem.Size = new Size(226, 22);
            warrantsOfLevyToolStripMenuItem.Text = "Warrants of Levy...";
            warrantsOfLevyToolStripMenuItem.Click += warrantsOfLevyToolStripMenuItem_Click;
            // 
            // auctionTstrpMnuItm
            // 
            auctionTstrpMnuItm.Name = "auctionTstrpMnuItm";
            auctionTstrpMnuItm.Size = new Size(226, 22);
            auctionTstrpMnuItm.Text = "Auction...";
            auctionTstrpMnuItm.Click += auctionTstrpMnuItm_Click;
            // 
            // biddingTstrpMnuItm
            // 
            biddingTstrpMnuItm.Name = "biddingTstrpMnuItm";
            biddingTstrpMnuItm.Size = new Size(226, 22);
            biddingTstrpMnuItm.Text = "Bidding...";
            biddingTstrpMnuItm.Click += biddingTstrpMnuItm_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(223, 6);
            // 
            // checkIssuanceTstrpMnuItm
            // 
            checkIssuanceTstrpMnuItm.Name = "checkIssuanceTstrpMnuItm";
            checkIssuanceTstrpMnuItm.Size = new Size(226, 22);
            checkIssuanceTstrpMnuItm.Text = "Check Issuance...";
            checkIssuanceTstrpMnuItm.Click += checkIssuanceTstrpMnuItm_Click;
            // 
            // releasedAndUnreleaseChecksTstrpMnuItm
            // 
            releasedAndUnreleaseChecksTstrpMnuItm.Name = "releasedAndUnreleaseChecksTstrpMnuItm";
            releasedAndUnreleaseChecksTstrpMnuItm.Size = new Size(226, 22);
            releasedAndUnreleaseChecksTstrpMnuItm.Text = "Release/Unreleased Checks...";
            releasedAndUnreleaseChecksTstrpMnuItm.Click += releasedAndUnreleaseChecksTstrpMnuItm_Click;
            // 
            // bankDepositTstrpMnuItm
            // 
            bankDepositTstrpMnuItm.Name = "bankDepositTstrpMnuItm";
            bankDepositTstrpMnuItm.Size = new Size(226, 22);
            bankDepositTstrpMnuItm.Text = "Bank Deposit...";
            bankDepositTstrpMnuItm.Click += bankDepositTstrpMnuItm_Click;
            // 
            // ucTreasury
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip3);
            Name = "ucTreasury";
            Size = new Size(810, 441);
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripDropDownButton manageTstripDrpDwnBtn;
        private System.Windows.Forms.ToolStripMenuItem realPropertiesTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem taxpayersTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem collectingOfficersTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem disbursementOfficersTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem feesChargesTstrpMnuItm;
        private System.Windows.Forms.ToolStripDropDownButton transactionsTstripDrpDwnBtn;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem af56TstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem af5157TstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem af54TstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem af58TstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem af53TstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem af52TstrpMnuItm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem auctionTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem biddingTstrpMnuItm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem checkIssuanceTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem releasedAndUnreleaseChecksTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem bankDepositTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem pymntHstoryTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem receiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptInventoryTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem recieiptIssuanceTstrpMnuItm;
        private System.Windows.Forms.ToolStripMenuItem tStrpMenuItmPrptyTaxPosting;
        private System.Windows.Forms.ToolStripMenuItem dellinquencyNoticesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warrantsOfLevyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aF41CommunityTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashTicketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuanceToolStripMenuItem;
    }
}
