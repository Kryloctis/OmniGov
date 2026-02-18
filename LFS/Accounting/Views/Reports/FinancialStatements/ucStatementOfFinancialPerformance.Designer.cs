
namespace OmniGov.App.Accounting.Views.Reports.FinancialStatements
{
    partial class ucStatementOfFinancialPerformance
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
            panel2 = new System.Windows.Forms.Panel();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            dtPickerDateEnds = new System.Windows.Forms.DateTimePicker();
            btnRetrieve = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxFunds);
            panel2.Controls.Add(dtPickerDateEnds);
            panel2.Controls.Add(btnRetrieve);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(552, 39);
            panel2.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(53, 7);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(200, 23);
            cmbxFunds.TabIndex = 3;
            // 
            // dtPickerDateEnds
            // 
            dtPickerDateEnds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtPickerDateEnds.CustomFormat = "MMM dd, yyyy";
            dtPickerDateEnds.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPickerDateEnds.Location = new System.Drawing.Point(259, 7);
            dtPickerDateEnds.Name = "dtPickerDateEnds";
            dtPickerDateEnds.Size = new System.Drawing.Size(130, 23);
            dtPickerDateEnds.TabIndex = 4;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRetrieve.Location = new System.Drawing.Point(395, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(150, 23);
            btnRetrieve.TabIndex = 5;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 39);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(552, 328);
            panel1.TabIndex = 3;
            // 
            // ucStatementOfFinancialPerformance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucStatementOfFinancialPerformance";
            Size = new System.Drawing.Size(552, 367);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.DateTimePicker dtPickerDateEnds;
        internal System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel1;
    }
}
