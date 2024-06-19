namespace AccountingSystem.Views.Reports.Ltom
{
    partial class frmLtom33
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
            txtRpt = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cmbxWarrantLevy = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            btnRunReport = new System.Windows.Forms.Button();
            panel3 = new System.Windows.Forms.Panel();
            ucCancellationOfWarrantOfLevy1 = new Transactions.Biddings.BiddingReports.ucCancellationOfWarrantOfLevy();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
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
            splitContainer1.Panel1.Controls.Add(txtRpt);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(cmbxWarrantLevy);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(btnRunReport);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(840, 406);
            splitContainer1.SplitterDistance = 211;
            splitContainer1.TabIndex = 14;
            // 
            // txtRpt
            // 
            txtRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            txtRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtRpt.Location = new System.Drawing.Point(6, 30);
            txtRpt.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtRpt.Name = "txtRpt";
            txtRpt.Size = new System.Drawing.Size(200, 23);
            txtRpt.TabIndex = 32;
            txtRpt.TextChanged += txtRpt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 15);
            label1.TabIndex = 31;
            label1.Text = "ARP No. :";
            // 
            // cmbxWarrantLevy
            // 
            cmbxWarrantLevy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxWarrantLevy.FormattingEnabled = true;
            cmbxWarrantLevy.Location = new System.Drawing.Point(6, 81);
            cmbxWarrantLevy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxWarrantLevy.Name = "cmbxWarrantLevy";
            cmbxWarrantLevy.Size = new System.Drawing.Size(200, 23);
            cmbxWarrantLevy.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(6, 63);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 19;
            label2.Text = "Issued at:";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new System.Drawing.Point(6, 117);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(200, 23);
            btnRunReport.TabIndex = 30;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(ucCancellationOfWarrantOfLevy1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(617, 398);
            panel3.TabIndex = 12;
            // 
            // ucCancellationOfWarrantOfLevy1
            // 
            ucCancellationOfWarrantOfLevy1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCancellationOfWarrantOfLevy1.Location = new System.Drawing.Point(0, 0);
            ucCancellationOfWarrantOfLevy1.Name = "ucCancellationOfWarrantOfLevy1";
            ucCancellationOfWarrantOfLevy1.Size = new System.Drawing.Size(617, 398);
            ucCancellationOfWarrantOfLevy1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 406);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmLtom33
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Name = "frmLtom33";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Treasury > Cancellation of Warrant of Levy (Local Assessor and Registrar of Deeds)";
            Load += frmLtom33_Load;
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
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Transactions.Biddings.BiddingReports.ucCancellationOfWarrantOfLevy ucCancellationOfWarrantOfLevy1;
        private System.Windows.Forms.ComboBox cmbxWarrantLevy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRpt;
        private System.Windows.Forms.Label label1;
    }
}