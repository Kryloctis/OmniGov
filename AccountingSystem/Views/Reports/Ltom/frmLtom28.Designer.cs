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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            cmbxProperty = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            cmbxAuctionSchedule = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            ucRulesAndRegulation1 = new Transactions.Biddings.BiddingReports.ucRulesAndRegulation();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(cmbxProperty);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnRunReport);
            splitContainer1.Panel1.Controls.Add(cmbxAuctionSchedule);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(800, 450);
            splitContainer1.SplitterDistance = 211;
            splitContainer1.TabIndex = 14;
            // 
            // cmbxProperty
            // 
            cmbxProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxProperty.FormattingEnabled = true;
            cmbxProperty.Location = new System.Drawing.Point(7, 78);
            cmbxProperty.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxProperty.Name = "cmbxProperty";
            cmbxProperty.Size = new System.Drawing.Size(200, 23);
            cmbxProperty.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(11, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(111, 15);
            label2.TabIndex = 25;
            label2.Text = "Auction Properties :";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(7, 27);
            comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(200, 23);
            comboBox1.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(11, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 15);
            label1.TabIndex = 23;
            label1.Text = "Auction Schedule :";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(7, 156);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 22;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            // 
            // cmbxAuctionSchedule
            // 
            cmbxAuctionSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAuctionSchedule.FormattingEnabled = true;
            cmbxAuctionSchedule.Location = new System.Drawing.Point(7, 127);
            cmbxAuctionSchedule.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxAuctionSchedule.Name = "cmbxAuctionSchedule";
            cmbxAuctionSchedule.Size = new System.Drawing.Size(200, 23);
            cmbxAuctionSchedule.TabIndex = 21;
            cmbxAuctionSchedule.SelectedIndexChanged += cmbxAuctionSchedule_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(11, 113);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 15);
            label3.TabIndex = 20;
            label3.Text = "Biiders : ";
            // 
            // panel1
            // 
            panel1.Controls.Add(ucRulesAndRegulation1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(577, 442);
            panel1.TabIndex = 12;
            // 
            // ucRulesAndRegulation1
            // 
            ucRulesAndRegulation1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRulesAndRegulation1.Location = new System.Drawing.Point(0, 0);
            ucRulesAndRegulation1.Name = "ucRulesAndRegulation1";
            ucRulesAndRegulation1.Size = new System.Drawing.Size(577, 442);
            ucRulesAndRegulation1.TabIndex = 1;
            // 
            // frmLtom28
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(splitContainer1);
            MinimizeBox = false;
            Name = "frmLtom28";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > LTOM Form No. 28 - Rules and Regulations of Public Auction";
            Load += frmLtom28_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private Transactions.Biddings.BiddingReports.ucRulesAndRegulation ucRulesAndRegulation1;
        private System.Windows.Forms.ComboBox cmbxProperty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ComboBox cmbxAuctionSchedule;
        private System.Windows.Forms.Label label3;
    }
}