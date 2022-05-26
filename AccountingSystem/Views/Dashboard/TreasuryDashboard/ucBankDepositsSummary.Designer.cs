
namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    partial class ucBankDepositsSummary
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
            this.label11 = new System.Windows.Forms.Label();
            this.dgBankDeposit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 16, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 20);
            this.label11.TabIndex = 91;
            this.label11.Text = "BANK DEPOSITS";
            // 
            // dgBankDeposit
            // 
            this.dgBankDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBankDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBankDeposit.Location = new System.Drawing.Point(3, 34);
            this.dgBankDeposit.Name = "dgBankDeposit";
            this.dgBankDeposit.RowTemplate.Height = 25;
            this.dgBankDeposit.Size = new System.Drawing.Size(504, 336);
            this.dgBankDeposit.TabIndex = 92;
            // 
            // ucBankDepositsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgBankDeposit);
            this.Controls.Add(this.label11);
            this.Name = "ucBankDepositsSummary";
            this.Size = new System.Drawing.Size(511, 373);
            this.Load += new System.EventHandler(this.ucBankDepositsSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBankDeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBankDeposit;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView s;
    }
}
