
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radPayee = new System.Windows.Forms.RadioButton();
            this.radFees = new System.Windows.Forms.RadioButton();
            this.radPayment = new System.Windows.Forms.RadioButton();
            this.btnBackMain = new System.Windows.Forms.Button();
            this.btnNextMain = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bgwPayee = new System.ComponentModel.BackgroundWorker();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePayee = new System.Windows.Forms.TabPage();
            this.tabControlPayee = new System.Windows.Forms.TabControl();
            this.tabPayeeList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.tabNewPayee = new System.Windows.Forms.TabPage();
            this.ucTaxPayers1 = new AccountingSystem.Views.Manage.TaxPayers.ucTaxPayers();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.tabPageFees = new System.Windows.Forms.TabPage();
            this.tabPagePayment = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPagePayee.SuspendLayout();
            this.tabControlPayee.SuspendLayout();
            this.tabPayeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabNewPayee.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radPayee);
            this.flowLayoutPanel2.Controls.Add(this.radFees);
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
            // radPayee
            // 
            this.radPayee.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPayee.Checked = true;
            this.radPayee.FlatAppearance.BorderSize = 0;
            this.radPayee.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radPayee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radPayee.Location = new System.Drawing.Point(0, 0);
            this.radPayee.Margin = new System.Windows.Forms.Padding(0);
            this.radPayee.Name = "radPayee";
            this.radPayee.Size = new System.Drawing.Size(195, 37);
            this.radPayee.TabIndex = 5;
            this.radPayee.TabStop = true;
            this.radPayee.Text = "Payee";
            this.radPayee.UseVisualStyleBackColor = true;
            // 
            // radFees
            // 
            this.radFees.Appearance = System.Windows.Forms.Appearance.Button;
            this.radFees.FlatAppearance.BorderSize = 0;
            this.radFees.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radFees.Location = new System.Drawing.Point(0, 37);
            this.radFees.Margin = new System.Windows.Forms.Padding(0);
            this.radFees.Name = "radFees";
            this.radFees.Size = new System.Drawing.Size(195, 37);
            this.radFees.TabIndex = 5;
            this.radFees.Text = "Fees && Charges";
            this.radFees.UseVisualStyleBackColor = true;
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
            // btnBackMain
            // 
            this.btnBackMain.Location = new System.Drawing.Point(445, 3);
            this.btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBackMain.Name = "btnBackMain";
            this.btnBackMain.Size = new System.Drawing.Size(134, 23);
            this.btnBackMain.TabIndex = 0;
            this.btnBackMain.Text = "Back";
            this.btnBackMain.UseVisualStyleBackColor = true;
            this.btnBackMain.Click += new System.EventHandler(this.btnBackMain_Click);
            // 
            // btnNextMain
            // 
            this.btnNextMain.Location = new System.Drawing.Point(587, 3);
            this.btnNextMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNextMain.Name = "btnNextMain";
            this.btnNextMain.Size = new System.Drawing.Size(134, 23);
            this.btnNextMain.TabIndex = 0;
            this.btnNextMain.Text = "Next";
            this.btnNextMain.UseVisualStyleBackColor = true;
            this.btnNextMain.Click += new System.EventHandler(this.btnNextMain_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(729, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnNextMain);
            this.flowLayoutPanel1.Controls.Add(this.btnBackMain);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(195, 526);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(867, 31);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // bgwPayee
            // 
            this.bgwPayee.WorkerReportsProgress = true;
            this.bgwPayee.WorkerSupportsCancellation = true;
            this.bgwPayee.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPayee_DoWork);
            this.bgwPayee.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPayee_ProgressChanged);
            this.bgwPayee.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPayee_RunWorkerCompleted);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlMain.Controls.Add(this.tabPagePayee);
            this.tabControlMain.Controls.Add(this.tabPageFees);
            this.tabControlMain.Controls.Add(this.tabPagePayment);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlMain.Location = new System.Drawing.Point(195, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(0, 0);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(867, 526);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 6;
            // 
            // tabPagePayee
            // 
            this.tabPagePayee.Controls.Add(this.tabControlPayee);
            this.tabPagePayee.Location = new System.Drawing.Point(4, 5);
            this.tabPagePayee.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePayee.Name = "tabPagePayee";
            this.tabPagePayee.Size = new System.Drawing.Size(859, 517);
            this.tabPagePayee.TabIndex = 0;
            this.tabPagePayee.Text = "tabPagePayee";
            this.tabPagePayee.UseVisualStyleBackColor = true;
            this.tabPagePayee.Enter += new System.EventHandler(this.tabPagePayee_Enter);
            // 
            // tabControlPayee
            // 
            this.tabControlPayee.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlPayee.Controls.Add(this.tabPayeeList);
            this.tabControlPayee.Controls.Add(this.tabNewPayee);
            this.tabControlPayee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPayee.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlPayee.Location = new System.Drawing.Point(0, 0);
            this.tabControlPayee.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlPayee.Name = "tabControlPayee";
            this.tabControlPayee.Padding = new System.Drawing.Point(0, 0);
            this.tabControlPayee.SelectedIndex = 0;
            this.tabControlPayee.Size = new System.Drawing.Size(859, 517);
            this.tabControlPayee.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlPayee.TabIndex = 1;
            // 
            // tabPayeeList
            // 
            this.tabPayeeList.Controls.Add(this.dataGridView1);
            this.tabPayeeList.Controls.Add(this.progressBar1);
            this.tabPayeeList.Controls.Add(this.toolStrip1);
            this.tabPayeeList.Location = new System.Drawing.Point(4, 5);
            this.tabPayeeList.Margin = new System.Windows.Forms.Padding(0);
            this.tabPayeeList.Name = "tabPayeeList";
            this.tabPayeeList.Size = new System.Drawing.Size(851, 508);
            this.tabPayeeList.TabIndex = 0;
            this.tabPayeeList.Text = "tabPayeeList";
            this.tabPayeeList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(851, 465);
            this.dataGridView1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(851, 5);
            this.progressBar1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.txtSearch,
            this.btnNew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 38);
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
            this.tabNewPayee.Controls.Add(this.ucTaxPayers1);
            this.tabNewPayee.Controls.Add(this.panel1);
            this.tabNewPayee.Controls.Add(this.toolStrip2);
            this.tabNewPayee.Location = new System.Drawing.Point(4, 5);
            this.tabNewPayee.Margin = new System.Windows.Forms.Padding(0);
            this.tabNewPayee.Name = "tabNewPayee";
            this.tabNewPayee.Size = new System.Drawing.Size(851, 508);
            this.tabNewPayee.TabIndex = 1;
            this.tabNewPayee.Text = "tabNewPayee";
            this.tabNewPayee.UseVisualStyleBackColor = true;
            // 
            // ucTaxPayers1
            // 
            this.ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucTaxPayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaxPayers1.Location = new System.Drawing.Point(0, 88);
            this.ucTaxPayers1.Name = "ucTaxPayers1";
            this.ucTaxPayers1.Padding = new System.Windows.Forms.Padding(50);
            this.ucTaxPayers1.Size = new System.Drawing.Size(851, 420);
            this.ucTaxPayers1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.panel1.Size = new System.Drawing.Size(851, 50);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1194, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Provide payee details to proceed.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1335, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payee";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(851, 38);
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
            // tabPageFees
            // 
            this.tabPageFees.Location = new System.Drawing.Point(4, 5);
            this.tabPageFees.Name = "tabPageFees";
            this.tabPageFees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFees.Size = new System.Drawing.Size(859, 517);
            this.tabPageFees.TabIndex = 1;
            this.tabPageFees.Text = "tabPageFees";
            this.tabPageFees.UseVisualStyleBackColor = true;
            this.tabPageFees.Enter += new System.EventHandler(this.tabPageFees_Enter);
            // 
            // tabPagePayment
            // 
            this.tabPagePayment.Location = new System.Drawing.Point(4, 5);
            this.tabPagePayment.Name = "tabPagePayment";
            this.tabPagePayment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePayment.Size = new System.Drawing.Size(859, 517);
            this.tabPagePayment.TabIndex = 2;
            this.tabPagePayment.Text = "tabPagePayment";
            this.tabPagePayment.UseVisualStyleBackColor = true;
            this.tabPagePayment.Enter += new System.EventHandler(this.tabPagePayment_Enter);
            // 
            // frmAF51_57
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 557);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MinimizeBox = false;
            this.Name = "frmAF51_57";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments > AF51 & 57";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPagePayee.ResumeLayout(false);
            this.tabControlPayee.ResumeLayout(false);
            this.tabPayeeList.ResumeLayout(false);
            this.tabPayeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabNewPayee.ResumeLayout(false);
            this.tabNewPayee.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radPayee;
        private System.Windows.Forms.RadioButton radFees;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker bgwPayee;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePayee;
        private System.Windows.Forms.TabControl tabControlPayee;
        private System.Windows.Forms.TabPage tabPayeeList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.TabPage tabNewPayee;
        private Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.TabPage tabPageFees;
        private System.Windows.Forms.TabPage tabPagePayment;
    }
}