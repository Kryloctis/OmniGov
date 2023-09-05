
namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    partial class frmAF51_57
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPayeeList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.tabNewPayee = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.ucTaxPayers1 = new AccountingSystem.Views.Manage.TaxPayers.ucTaxPayers();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radTaxpayer = new System.Windows.Forms.RadioButton();
            this.radTaxDues = new System.Windows.Forms.RadioButton();
            this.radPayment = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPayeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabNewPayee.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPayeeList);
            this.tabControl1.Controls.Add(this.tabNewPayee);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(195, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 557);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPayeeList
            // 
            this.tabPayeeList.Controls.Add(this.dataGridView1);
            this.tabPayeeList.Controls.Add(this.toolStrip1);
            this.tabPayeeList.Location = new System.Drawing.Point(4, 5);
            this.tabPayeeList.Name = "tabPayeeList";
            this.tabPayeeList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPayeeList.Size = new System.Drawing.Size(859, 548);
            this.tabPayeeList.TabIndex = 0;
            this.tabPayeeList.Text = "tabPayeeList";
            this.tabPayeeList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(853, 504);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.txtSearch,
            this.btnNew});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(853, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Image = global::AccountingSystem.Properties.Resources.user_browse_20px;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 35);
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.MaxLength = 999999999;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 38);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::AccountingSystem.Properties.Resources.create_new_20px;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(35, 35);
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tabNewPayee
            // 
            this.tabNewPayee.Controls.Add(this.label2);
            this.tabNewPayee.Controls.Add(this.label1);
            this.tabNewPayee.Controls.Add(this.btnSave);
            this.tabNewPayee.Controls.Add(this.toolStrip2);
            this.tabNewPayee.Controls.Add(this.ucTaxPayers1);
            this.tabNewPayee.Location = new System.Drawing.Point(4, 5);
            this.tabNewPayee.Name = "tabNewPayee";
            this.tabNewPayee.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewPayee.Size = new System.Drawing.Size(859, 548);
            this.tabNewPayee.TabIndex = 1;
            this.tabNewPayee.Text = "tabNewPayee";
            this.tabNewPayee.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(394, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Provide payee details to proceed.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(535, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payee";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(524, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(853, 38);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnBack
            // 
            this.btnBack.Image = global::AccountingSystem.Properties.Resources.arrow_left_20px;
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 35);
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ucTaxPayers1
            // 
            this.ucTaxPayers1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucTaxPayers1.Location = new System.Drawing.Point(206, 161);
            this.ucTaxPayers1.Name = "ucTaxPayers1";
            this.ucTaxPayers1.Size = new System.Drawing.Size(414, 261);
            this.ucTaxPayers1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radTaxpayer);
            this.flowLayoutPanel2.Controls.Add(this.radTaxDues);
            this.flowLayoutPanel2.Controls.Add(this.radPayment);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(195, 557);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // radTaxpayer
            // 
            this.radTaxpayer.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTaxpayer.Checked = true;
            this.radTaxpayer.FlatAppearance.BorderSize = 0;
            this.radTaxpayer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radTaxpayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTaxpayer.Location = new System.Drawing.Point(0, 0);
            this.radTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            this.radTaxpayer.Name = "radTaxpayer";
            this.radTaxpayer.Size = new System.Drawing.Size(195, 37);
            this.radTaxpayer.TabIndex = 5;
            this.radTaxpayer.TabStop = true;
            this.radTaxpayer.Text = "Payee";
            this.radTaxpayer.UseVisualStyleBackColor = true;
            // 
            // radTaxDues
            // 
            this.radTaxDues.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTaxDues.FlatAppearance.BorderSize = 0;
            this.radTaxDues.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radTaxDues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTaxDues.Location = new System.Drawing.Point(0, 37);
            this.radTaxDues.Margin = new System.Windows.Forms.Padding(0);
            this.radTaxDues.Name = "radTaxDues";
            this.radTaxDues.Size = new System.Drawing.Size(195, 37);
            this.radTaxDues.TabIndex = 5;
            this.radTaxDues.Text = "Fees && Charges";
            this.radTaxDues.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            this.radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPayment.FlatAppearance.BorderSize = 0;
            this.radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radPayment.Location = new System.Drawing.Point(0, 74);
            this.radPayment.Margin = new System.Windows.Forms.Padding(0);
            this.radPayment.Name = "radPayment";
            this.radPayment.Size = new System.Drawing.Size(195, 37);
            this.radPayment.TabIndex = 2;
            this.radPayment.Text = "Payment";
            this.radPayment.UseVisualStyleBackColor = true;
            // 
            // frmAF51_57
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 557);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MinimizeBox = false;
            this.Name = "frmAF51_57";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments > AF51 & 57";
            this.tabControl1.ResumeLayout(false);
            this.tabPayeeList.ResumeLayout(false);
            this.tabPayeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabNewPayee.ResumeLayout(false);
            this.tabNewPayee.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPayeeList;
        private System.Windows.Forms.TabPage tabNewPayee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radTaxpayer;
        private System.Windows.Forms.RadioButton radTaxDues;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
    }
}