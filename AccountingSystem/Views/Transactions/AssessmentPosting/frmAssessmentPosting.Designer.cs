
namespace AccountingSystem.Views.Transactions.AssessmentPosting
{
    partial class frmAssessmentPosting
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
            this.dgProperties = new System.Windows.Forms.DataGridView();
            this.btnPost = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudEffectivityYear = new System.Windows.Forms.NumericUpDown();
            this.cmbBarangays = new System.Windows.Forms.ComboBox();
            this.cmbEffectivityQuarter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProperties
            // 
            this.dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProperties.Location = new System.Drawing.Point(12, 51);
            this.dgProperties.Name = "dgProperties";
            this.dgProperties.RowTemplate.Height = 25;
            this.dgProperties.Size = new System.Drawing.Size(776, 393);
            this.dgProperties.TabIndex = 11;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(12, 12);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(126, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post Selected Rows";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.nudEffectivityYear);
            this.panel1.Controls.Add(this.cmbBarangays);
            this.panel1.Controls.Add(this.cmbEffectivityQuarter);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 9;
            // 
            // nudEffectivityYear
            // 
            this.nudEffectivityYear.Location = new System.Drawing.Point(490, 12);
            this.nudEffectivityYear.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.nudEffectivityYear.Name = "nudEffectivityYear";
            this.nudEffectivityYear.Size = new System.Drawing.Size(101, 23);
            this.nudEffectivityYear.TabIndex = 9;
            this.nudEffectivityYear.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nudEffectivityYear.ValueChanged += new System.EventHandler(this.nudEffectivityYear_ValueChanged);
            // 
            // cmbBarangays
            // 
            this.cmbBarangays.FormattingEnabled = true;
            this.cmbBarangays.Location = new System.Drawing.Point(255, 12);
            this.cmbBarangays.Name = "cmbBarangays";
            this.cmbBarangays.Size = new System.Drawing.Size(160, 23);
            this.cmbBarangays.TabIndex = 7;
            this.cmbBarangays.SelectionChangeCommitted += new System.EventHandler(this.cmbBarangays_SelectionChangeCommitted);
            // 
            // cmbEffectivityQuarter
            // 
            this.cmbEffectivityQuarter.FormattingEnabled = true;
            this.cmbEffectivityQuarter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbEffectivityQuarter.Location = new System.Drawing.Point(421, 12);
            this.cmbEffectivityQuarter.Name = "cmbEffectivityQuarter";
            this.cmbEffectivityQuarter.Size = new System.Drawing.Size(63, 23);
            this.cmbEffectivityQuarter.TabIndex = 8;
            this.cmbEffectivityQuarter.SelectionChangeCommitted += new System.EventHandler(this.cmbEffectivityQuarter_SelectionChangeCommitted);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(597, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 23);
            this.txtSearch.TabIndex = 6;
            // 
            // frmAssessmentPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgProperties);
            this.Controls.Add(this.panel1);
            this.Name = "frmAssessmentPosting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assessment Posting";
            this.Load += new System.EventHandler(this.frmAssessmentPosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudEffectivityYear;
        private System.Windows.Forms.ComboBox cmbBarangays;
        private System.Windows.Forms.ComboBox cmbEffectivityQuarter;
        private System.Windows.Forms.TextBox txtSearch;
    }
}