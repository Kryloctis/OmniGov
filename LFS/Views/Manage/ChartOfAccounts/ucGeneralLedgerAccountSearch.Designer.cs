
namespace LFS.Views.Manage.ChartOfAccounts
{
    partial class ucGeneralLedgerAccountSearch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGeneralLedgerAccountSearch));
            this.cmbGeneralLedgerAccount = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGeneralLedgerAccount
            // 
            this.cmbGeneralLedgerAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGeneralLedgerAccount.FormattingEnabled = true;
            this.epAccount.SetIconPadding(this.cmbGeneralLedgerAccount, 35);
            this.cmbGeneralLedgerAccount.Location = new System.Drawing.Point(0, 0);
            this.cmbGeneralLedgerAccount.Name = "cmbGeneralLedgerAccount";
            this.cmbGeneralLedgerAccount.Size = new System.Drawing.Size(308, 23);
            this.cmbGeneralLedgerAccount.TabIndex = 4;
            this.cmbGeneralLedgerAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGeneralLedgerAccount_Validating);
            this.cmbGeneralLedgerAccount.Validated += new System.EventHandler(this.cmbGeneralLedgerAccount_Validated);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Image = ((System.Drawing.Image)(resources.GetObject("btnGet.Image")));
            this.btnGet.Location = new System.Drawing.Point(314, -1);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(25, 23);
            this.btnGet.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnGet, "Get general ledget accounts");
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // ucGeneralLedgerAccountSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.cmbGeneralLedgerAccount);
            this.epAccount.SetIconPadding(this, 30);
            this.Name = "ucGeneralLedgerAccountSearch";
            this.Size = new System.Drawing.Size(366, 31);
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGet;
        internal System.Windows.Forms.ComboBox cmbGeneralLedgerAccount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider epAccount;
    }
}
