
namespace AccountingSystem.Views.Manage.LinkUser
{
    partial class frmLinkUser
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
            this.dgvusers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvusers
            // 
            this.dgvusers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusers.Location = new System.Drawing.Point(10, 9);
            this.dgvusers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvusers.Name = "dgvusers";
            this.dgvusers.RowHeadersWidth = 51;
            this.dgvusers.RowTemplate.Height = 29;
            this.dgvusers.Size = new System.Drawing.Size(660, 278);
            this.dgvusers.TabIndex = 0;
            this.dgvusers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvusers_CellDoubleClick);
            this.dgvusers.SelectionChanged += new System.EventHandler(this.dgvusers_SelectionChanged);
            // 
            // frmlinkuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 296);
            this.Controls.Add(this.dgvusers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmlinkuser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link User";
            this.Load += new System.EventHandler(this.frmlinkuser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvusers;
    }
}