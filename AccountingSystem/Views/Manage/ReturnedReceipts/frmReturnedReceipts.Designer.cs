
namespace AccountingSystem.Views.Manage.ReturnedReceipts
{
    partial class frmReturnedReceipts
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
            this.dgReturnedReceipts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgReturnedReceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgReturnedReceipts
            // 
            this.dgReturnedReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgReturnedReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReturnedReceipts.Location = new System.Drawing.Point(12, 30);
            this.dgReturnedReceipts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgReturnedReceipts.Name = "dgReturnedReceipts";
            this.dgReturnedReceipts.RowHeadersWidth = 51;
            this.dgReturnedReceipts.RowTemplate.Height = 29;
            this.dgReturnedReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReturnedReceipts.Size = new System.Drawing.Size(711, 354);
            this.dgReturnedReceipts.TabIndex = 9;
            // 
            // frmReturnedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(735, 395);
            this.Controls.Add(this.dgReturnedReceipts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReturnedReceipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Returned Receipts";
            ((System.ComponentModel.ISupportInitialize)(this.dgReturnedReceipts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgReturnedReceipts;
    }
}