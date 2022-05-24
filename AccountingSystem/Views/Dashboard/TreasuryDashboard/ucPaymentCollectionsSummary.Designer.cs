
namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    partial class ucPaymentCollectionsSummary
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.dgCollectorsCollection = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCollectorsCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Image = global::AccountingSystem.Properties.Resources.symbol_refresh_14px;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(252, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 27);
            this.btnRefresh.TabIndex = 86;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            this.dtAsOf.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtAsOf.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtAsOf.Location = new System.Drawing.Point(2, 6);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(246, 23);
            this.dtAsOf.TabIndex = 85;
            // 
            // dgCollectorsCollection
            // 
            this.dgCollectorsCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCollectorsCollection.Location = new System.Drawing.Point(3, 33);
            this.dgCollectorsCollection.Name = "dgCollectorsCollection";
            this.dgCollectorsCollection.RowTemplate.Height = 25;
            this.dgCollectorsCollection.Size = new System.Drawing.Size(504, 337);
            this.dgCollectorsCollection.TabIndex = 87;
            // 
            // ucPaymentCollectionsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgCollectorsCollection);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtAsOf);
            this.Name = "ucPaymentCollectionsSummary";
            this.Size = new System.Drawing.Size(511, 373);
            ((System.ComponentModel.ISupportInitialize)(this.dgCollectorsCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.DataGridView dgCollectorsCollection;
    }
}
