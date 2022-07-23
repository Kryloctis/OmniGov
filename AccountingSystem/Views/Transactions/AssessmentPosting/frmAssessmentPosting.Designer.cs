
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnAutoPost = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radLand = new System.Windows.Forms.RadioButton();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.cbmBarangay = new System.Windows.Forms.ComboBox();
            this.cmbEffectivityQuarter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 351);
            this.dataGridView1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPost);
            this.panel2.Controls.Add(this.btnAutoPost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 36);
            this.panel2.TabIndex = 10;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(713, 6);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            // 
            // btnAutoPost
            // 
            this.btnAutoPost.Location = new System.Drawing.Point(632, 6);
            this.btnAutoPost.Name = "btnAutoPost";
            this.btnAutoPost.Size = new System.Drawing.Size(75, 23);
            this.btnAutoPost.TabIndex = 0;
            this.btnAutoPost.Text = "Auto Post";
            this.btnAutoPost.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radLand);
            this.panel1.Controls.Add(this.nudYear);
            this.panel1.Controls.Add(this.cbmBarangay);
            this.panel1.Controls.Add(this.cmbEffectivityQuarter);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 9;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(168, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 19);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Machinery";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(86, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 19);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Building";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radLand
            // 
            this.radLand.AutoSize = true;
            this.radLand.Location = new System.Drawing.Point(12, 12);
            this.radLand.Name = "radLand";
            this.radLand.Size = new System.Drawing.Size(51, 19);
            this.radLand.TabIndex = 10;
            this.radLand.TabStop = true;
            this.radLand.Text = "Land";
            this.radLand.UseVisualStyleBackColor = true;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(490, 12);
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(101, 23);
            this.nudYear.TabIndex = 9;
            // 
            // cbmBarangay
            // 
            this.cbmBarangay.FormattingEnabled = true;
            this.cbmBarangay.Location = new System.Drawing.Point(255, 12);
            this.cbmBarangay.Name = "cbmBarangay";
            this.cbmBarangay.Size = new System.Drawing.Size(160, 23);
            this.cbmBarangay.TabIndex = 7;
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmAssessmentPosting";
            this.Text = "Assessment Posting";
            this.Load += new System.EventHandler(this.frmAssessmentPosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnAutoPost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radLand;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cbmBarangay;
        private System.Windows.Forms.ComboBox cmbEffectivityQuarter;
        private System.Windows.Forms.TextBox txtSearch;
    }
}