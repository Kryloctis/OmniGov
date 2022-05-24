
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
            this.dgBankDeposit = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBankDeposit
            // 
            this.dgBankDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBankDeposit.Location = new System.Drawing.Point(3, 32);
            this.dgBankDeposit.Name = "dgBankDeposit";
            this.dgBankDeposit.RowTemplate.Height = 25;
            this.dgBankDeposit.Size = new System.Drawing.Size(504, 337);
            this.dgBankDeposit.TabIndex = 90;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Image = global::AccountingSystem.Properties.Resources.symbol_refresh_14px;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(252, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 27);
            this.btnRefresh.TabIndex = 89;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            this.dtAsOf.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtAsOf.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtAsOf.Location = new System.Drawing.Point(2, 5);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(246, 23);
            this.dtAsOf.TabIndex = 88;
            // 
            // ucBankDepositsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgBankDeposit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtAsOf);
            this.Name = "ucBankDepositsSummary";
            this.Size = new System.Drawing.Size(510, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dgBankDeposit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBankDeposit;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
    }
}
