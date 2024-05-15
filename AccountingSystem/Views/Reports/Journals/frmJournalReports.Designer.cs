namespace AccountingSystem.Views.Reports.Journals
{
    partial class frmJournalReports
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
            tabControlJournals = new System.Windows.Forms.TabControl();
            tabPageGenJrnl = new System.Windows.Forms.TabPage();
            ucGenJrnlReport1 = new ucGenJrnlReport();
            tabPageCashReceiptsJrnl = new System.Windows.Forms.TabPage();
            tabPageProcReceivedJrnl = new System.Windows.Forms.TabPage();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            button3 = new System.Windows.Forms.Button();
            dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            comboBox2 = new System.Windows.Forms.ComboBox();
            tabPageCashDisbursementJrnl = new System.Windows.Forms.TabPage();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            button4 = new System.Windows.Forms.Button();
            dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            comboBox3 = new System.Windows.Forms.ComboBox();
            tabPageChckDisbursementJrnl = new System.Windows.Forms.TabPage();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            button5 = new System.Windows.Forms.Button();
            dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            comboBox4 = new System.Windows.Forms.ComboBox();
            tabPageAdaDisbursementJrnl = new System.Windows.Forms.TabPage();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            button6 = new System.Windows.Forms.Button();
            dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            comboBox5 = new System.Windows.Forms.ComboBox();
            ucCashReceiptsJournalReport1 = new ucCashReceiptsJournalReport();
            tabControlJournals.SuspendLayout();
            tabPageGenJrnl.SuspendLayout();
            tabPageCashReceiptsJrnl.SuspendLayout();
            tabPageProcReceivedJrnl.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tabPageCashDisbursementJrnl.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            tabPageChckDisbursementJrnl.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            tabPageAdaDisbursementJrnl.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControlJournals
            // 
            tabControlJournals.Controls.Add(tabPageGenJrnl);
            tabControlJournals.Controls.Add(tabPageCashReceiptsJrnl);
            tabControlJournals.Controls.Add(tabPageProcReceivedJrnl);
            tabControlJournals.Controls.Add(tabPageCashDisbursementJrnl);
            tabControlJournals.Controls.Add(tabPageChckDisbursementJrnl);
            tabControlJournals.Controls.Add(tabPageAdaDisbursementJrnl);
            tabControlJournals.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlJournals.Location = new System.Drawing.Point(0, 0);
            tabControlJournals.Name = "tabControlJournals";
            tabControlJournals.SelectedIndex = 0;
            tabControlJournals.Size = new System.Drawing.Size(800, 428);
            tabControlJournals.TabIndex = 4;
            tabControlJournals.SelectedIndexChanged += tabControlJournals_SelectedIndexChanged;
            // 
            // tabPageGenJrnl
            // 
            tabPageGenJrnl.Controls.Add(ucGenJrnlReport1);
            tabPageGenJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageGenJrnl.Name = "tabPageGenJrnl";
            tabPageGenJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageGenJrnl.TabIndex = 0;
            tabPageGenJrnl.Text = "General Journal";
            tabPageGenJrnl.UseVisualStyleBackColor = true;
            // 
            // ucGenJrnlReport1
            // 
            ucGenJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGenJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucGenJrnlReport1.Name = "ucGenJrnlReport1";
            ucGenJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucGenJrnlReport1.TabIndex = 0;
            // 
            // tabPageCashReceiptsJrnl
            // 
            tabPageCashReceiptsJrnl.Controls.Add(ucCashReceiptsJournalReport1);
            tabPageCashReceiptsJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageCashReceiptsJrnl.Name = "tabPageCashReceiptsJrnl";
            tabPageCashReceiptsJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageCashReceiptsJrnl.TabIndex = 1;
            tabPageCashReceiptsJrnl.Text = "Cash Receipts Journal";
            tabPageCashReceiptsJrnl.UseVisualStyleBackColor = true;
            // 
            // tabPageProcReceivedJrnl
            // 
            tabPageProcReceivedJrnl.Controls.Add(flowLayoutPanel3);
            tabPageProcReceivedJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageProcReceivedJrnl.Name = "tabPageProcReceivedJrnl";
            tabPageProcReceivedJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageProcReceivedJrnl.TabIndex = 2;
            tabPageProcReceivedJrnl.Text = "Procurement Received Journal";
            tabPageProcReceivedJrnl.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(button3);
            flowLayoutPanel3.Controls.Add(dateTimePicker3);
            flowLayoutPanel3.Controls.Add(comboBox2);
            flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel3.Size = new System.Drawing.Size(792, 37);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(631, 7);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(150, 23);
            button3.TabIndex = 2;
            button3.Text = "Run Report";
            button3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.CustomFormat = "MMM,  yyyy";
            dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker3.Location = new System.Drawing.Point(495, 7);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new System.Drawing.Size(130, 23);
            dateTimePicker3.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(289, 7);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(200, 23);
            comboBox2.TabIndex = 0;
            // 
            // tabPageCashDisbursementJrnl
            // 
            tabPageCashDisbursementJrnl.Controls.Add(flowLayoutPanel4);
            tabPageCashDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageCashDisbursementJrnl.Name = "tabPageCashDisbursementJrnl";
            tabPageCashDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageCashDisbursementJrnl.TabIndex = 3;
            tabPageCashDisbursementJrnl.Text = "Cash Disbursements Journal";
            tabPageCashDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Controls.Add(button4);
            flowLayoutPanel4.Controls.Add(dateTimePicker4);
            flowLayoutPanel4.Controls.Add(comboBox3);
            flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel4.Size = new System.Drawing.Size(792, 37);
            flowLayoutPanel4.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(631, 7);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(150, 23);
            button4.TabIndex = 2;
            button4.Text = "Run Report";
            button4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.CustomFormat = "MMM,  yyyy";
            dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker4.Location = new System.Drawing.Point(495, 7);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new System.Drawing.Size(130, 23);
            dateTimePicker4.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(289, 7);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(200, 23);
            comboBox3.TabIndex = 0;
            // 
            // tabPageChckDisbursementJrnl
            // 
            tabPageChckDisbursementJrnl.Controls.Add(flowLayoutPanel5);
            tabPageChckDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageChckDisbursementJrnl.Name = "tabPageChckDisbursementJrnl";
            tabPageChckDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageChckDisbursementJrnl.TabIndex = 4;
            tabPageChckDisbursementJrnl.Text = "Check Disbursements Journal";
            tabPageChckDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.Controls.Add(button5);
            flowLayoutPanel5.Controls.Add(dateTimePicker5);
            flowLayoutPanel5.Controls.Add(comboBox4);
            flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel5.Size = new System.Drawing.Size(792, 37);
            flowLayoutPanel5.TabIndex = 7;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(631, 7);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(150, 23);
            button5.TabIndex = 2;
            button5.Text = "Run Report";
            button5.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.CustomFormat = "MMM,  yyyy";
            dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker5.Location = new System.Drawing.Point(495, 7);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new System.Drawing.Size(130, 23);
            dateTimePicker5.TabIndex = 1;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(289, 7);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(200, 23);
            comboBox4.TabIndex = 0;
            // 
            // tabPageAdaDisbursementJrnl
            // 
            tabPageAdaDisbursementJrnl.Controls.Add(flowLayoutPanel6);
            tabPageAdaDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageAdaDisbursementJrnl.Name = "tabPageAdaDisbursementJrnl";
            tabPageAdaDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageAdaDisbursementJrnl.TabIndex = 5;
            tabPageAdaDisbursementJrnl.Text = "ADA Disbursement Journals";
            tabPageAdaDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.Controls.Add(button6);
            flowLayoutPanel6.Controls.Add(dateTimePicker6);
            flowLayoutPanel6.Controls.Add(comboBox5);
            flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel6.Size = new System.Drawing.Size(792, 37);
            flowLayoutPanel6.TabIndex = 8;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(631, 7);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(150, 23);
            button6.TabIndex = 2;
            button6.Text = "Run Report";
            button6.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker6
            // 
            dateTimePicker6.CustomFormat = "MMM,  yyyy";
            dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker6.Location = new System.Drawing.Point(495, 7);
            dateTimePicker6.Name = "dateTimePicker6";
            dateTimePicker6.Size = new System.Drawing.Size(130, 23);
            dateTimePicker6.TabIndex = 1;
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new System.Drawing.Point(289, 7);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(200, 23);
            comboBox5.TabIndex = 0;
            // 
            // ucCashReceiptsJournalReport1
            // 
            ucCashReceiptsJournalReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCashReceiptsJournalReport1.Location = new System.Drawing.Point(0, 0);
            ucCashReceiptsJournalReport1.Name = "ucCashReceiptsJournalReport1";
            ucCashReceiptsJournalReport1.Size = new System.Drawing.Size(792, 400);
            ucCashReceiptsJournalReport1.TabIndex = 5;
            // 
            // frmJournalReports
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(tabControlJournals);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmJournalReports";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Journals";
            Load += frmJournalReports_Load;
            tabControlJournals.ResumeLayout(false);
            tabPageGenJrnl.ResumeLayout(false);
            tabPageCashReceiptsJrnl.ResumeLayout(false);
            tabPageProcReceivedJrnl.ResumeLayout(false);
            tabPageProcReceivedJrnl.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            tabPageCashDisbursementJrnl.ResumeLayout(false);
            tabPageCashDisbursementJrnl.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            tabPageChckDisbursementJrnl.ResumeLayout(false);
            tabPageChckDisbursementJrnl.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            tabPageAdaDisbursementJrnl.ResumeLayout(false);
            tabPageAdaDisbursementJrnl.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlJournals;
        private System.Windows.Forms.TabPage tabPageGenJrnl;
        private System.Windows.Forms.TabPage tabPageCashReceiptsJrnl;
        private System.Windows.Forms.TabPage tabPageProcReceivedJrnl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        internal System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabPageCashDisbursementJrnl;
        private System.Windows.Forms.TabPage tabPageChckDisbursementJrnl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        internal System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        internal System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPageAdaDisbursementJrnl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        internal System.Windows.Forms.ComboBox comboBox5;
        private ucGenJrnlReport ucGenJrnlReport1;
        private ucCashReceiptsJournalReport ucCashReceiptsJournalReport1;
    }
}