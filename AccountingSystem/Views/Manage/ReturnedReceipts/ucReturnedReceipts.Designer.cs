
namespace AccountingSystem.Views.Manage.ReturnedReceipts
{
    partial class ucReturnedReceipts
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
            this.dgreceipts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgreceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgreceipts
            // 
            this.dgreceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgreceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgreceipts.Location = new System.Drawing.Point(3, 36);
            this.dgreceipts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgreceipts.Name = "dgreceipts";
            this.dgreceipts.RowHeadersWidth = 51;
            this.dgreceipts.RowTemplate.Height = 29;
            this.dgreceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgreceipts.Size = new System.Drawing.Size(837, 402);
            this.dgreceipts.TabIndex = 8;
            this.dgreceipts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgreceipts_CellContentClick);
            // 
            // ucReturnedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgreceipts);
            this.Name = "ucReturnedReceipts";
            this.Size = new System.Drawing.Size(843, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgreceipts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgreceipts;
    }
}
