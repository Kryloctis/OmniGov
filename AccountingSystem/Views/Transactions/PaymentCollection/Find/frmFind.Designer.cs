
namespace AccountingSystem.Views.Transactions.PaymentCollection.Find
{
    partial class frmFind
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dgSelect = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find :";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(62, 6);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderText = "Search...";
            this.txtsearch.Size = new System.Drawing.Size(596, 27);
            this.txtsearch.TabIndex = 1;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dgSelect
            // 
            this.dgSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelect.Location = new System.Drawing.Point(12, 39);
            this.dgSelect.Name = "dgSelect";
            this.dgSelect.RowHeadersWidth = 51;
            this.dgSelect.RowTemplate.Height = 29;
            this.dgSelect.Size = new System.Drawing.Size(646, 380);
            this.dgSelect.TabIndex = 2;
            this.dgSelect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSelect_CellDoubleClick);
            this.dgSelect.SelectionChanged += new System.EventHandler(this.dgSelect_SelectionChanged);
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 431);
            this.Controls.Add(this.dgSelect);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select";
            this.Load += new System.EventHandler(this.frmFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridView dgSelect;
    }
}