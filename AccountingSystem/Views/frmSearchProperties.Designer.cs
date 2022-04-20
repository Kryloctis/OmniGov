
namespace AccountingSystem.Views
{
    partial class frmSearchProperties
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
            this.dgSearchProperties = new System.Windows.Forms.DataGridView();
            this.radBtnMachinery = new System.Windows.Forms.RadioButton();
            this.radBtnBuilding = new System.Windows.Forms.RadioButton();
            this.radBtnLand = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSearchProperties
            // 
            this.dgSearchProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSearchProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchProperties.Location = new System.Drawing.Point(12, 46);
            this.dgSearchProperties.Name = "dgSearchProperties";
            this.dgSearchProperties.RowTemplate.Height = 25;
            this.dgSearchProperties.Size = new System.Drawing.Size(901, 406);
            this.dgSearchProperties.TabIndex = 9;
            // 
            // radBtnMachinery
            // 
            this.radBtnMachinery.AutoSize = true;
            this.radBtnMachinery.Location = new System.Drawing.Point(144, 18);
            this.radBtnMachinery.Name = "radBtnMachinery";
            this.radBtnMachinery.Size = new System.Drawing.Size(81, 19);
            this.radBtnMachinery.TabIndex = 6;
            this.radBtnMachinery.Text = "Machinery";
            this.radBtnMachinery.UseVisualStyleBackColor = true;
            this.radBtnMachinery.CheckedChanged += new System.EventHandler(this.radBtnMachinery_CheckedChanged);
            // 
            // radBtnBuilding
            // 
            this.radBtnBuilding.AutoSize = true;
            this.radBtnBuilding.Location = new System.Drawing.Point(69, 18);
            this.radBtnBuilding.Name = "radBtnBuilding";
            this.radBtnBuilding.Size = new System.Drawing.Size(69, 19);
            this.radBtnBuilding.TabIndex = 7;
            this.radBtnBuilding.Text = "Building";
            this.radBtnBuilding.UseVisualStyleBackColor = true;
            this.radBtnBuilding.CheckedChanged += new System.EventHandler(this.radBtnBuilding_CheckedChanged);
            // 
            // radBtnLand
            // 
            this.radBtnLand.AutoSize = true;
            this.radBtnLand.Checked = true;
            this.radBtnLand.Location = new System.Drawing.Point(12, 18);
            this.radBtnLand.Name = "radBtnLand";
            this.radBtnLand.Size = new System.Drawing.Size(51, 19);
            this.radBtnLand.TabIndex = 8;
            this.radBtnLand.TabStop = true;
            this.radBtnLand.Text = "Land";
            this.radBtnLand.UseVisualStyleBackColor = true;
            this.radBtnLand.CheckedChanged += new System.EventHandler(this.radBtnLand_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(458, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(231, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 23);
            this.txtSearch.TabIndex = 4;
            // 
            // frmSearchProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 464);
            this.Controls.Add(this.dgSearchProperties);
            this.Controls.Add(this.radBtnMachinery);
            this.Controls.Add(this.radBtnBuilding);
            this.Controls.Add(this.radBtnLand);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmSearchProperties";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Property";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSearchProperties;
        internal System.Windows.Forms.RadioButton radBtnMachinery;
        internal System.Windows.Forms.RadioButton radBtnBuilding;
        internal System.Windows.Forms.RadioButton radBtnLand;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}