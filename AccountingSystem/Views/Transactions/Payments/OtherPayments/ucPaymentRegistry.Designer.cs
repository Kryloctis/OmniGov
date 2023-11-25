namespace AccountingSystem.Views.Transactions.Payments.OtherPayments
{
    partial class ucPaymentRegistry
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
            tabControlRegistry = new System.Windows.Forms.TabControl();
            tabRegistryList = new System.Windows.Forms.TabPage();
            dgPayees = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            btnRegister = new System.Windows.Forms.ToolStripButton();
            tabRegister = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucTaxPayers1 = new Manage.TaxPayers.ucTaxPayers();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnBack = new System.Windows.Forms.ToolStripButton();
            tabControlRegistry.SuspendLayout();
            tabRegistryList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPayees).BeginInit();
            toolStrip1.SuspendLayout();
            tabRegister.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlRegistry
            // 
            tabControlRegistry.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlRegistry.Controls.Add(tabRegistryList);
            tabControlRegistry.Controls.Add(tabRegister);
            tabControlRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlRegistry.ItemSize = new System.Drawing.Size(0, 1);
            tabControlRegistry.Location = new System.Drawing.Point(0, 0);
            tabControlRegistry.Margin = new System.Windows.Forms.Padding(0);
            tabControlRegistry.Name = "tabControlRegistry";
            tabControlRegistry.Padding = new System.Drawing.Point(0, 0);
            tabControlRegistry.SelectedIndex = 0;
            tabControlRegistry.Size = new System.Drawing.Size(677, 350);
            tabControlRegistry.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlRegistry.TabIndex = 4;
            // 
            // tabRegistryList
            // 
            tabRegistryList.Controls.Add(dgPayees);
            tabRegistryList.Controls.Add(progressBar1);
            tabRegistryList.Controls.Add(toolStrip1);
            tabRegistryList.Location = new System.Drawing.Point(4, 5);
            tabRegistryList.Margin = new System.Windows.Forms.Padding(0);
            tabRegistryList.Name = "tabRegistryList";
            tabRegistryList.Size = new System.Drawing.Size(669, 341);
            tabRegistryList.TabIndex = 0;
            tabRegistryList.Text = "tabPayeeList";
            tabRegistryList.UseVisualStyleBackColor = true;
            // 
            // dgPayees
            // 
            dgPayees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPayees.Dock = System.Windows.Forms.DockStyle.Fill;
            dgPayees.Location = new System.Drawing.Point(0, 36);
            dgPayees.Name = "dgPayees";
            dgPayees.RowTemplate.Height = 25;
            dgPayees.Size = new System.Drawing.Size(669, 305);
            dgPayees.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 31);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(669, 5);
            progressBar1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSearch, txtSearch, btnRegister });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(669, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(23, 20);
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.MaxLength = 999999999;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 23);
            // 
            // btnRegister
            // 
            btnRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnRegister.Image = Properties.Resources.symbol_add_20px;
            btnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(23, 20);
            btnRegister.Text = "Register";
            btnRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnRegister.Click += btnRegister_Click;
            // 
            // tabRegister
            // 
            tabRegister.Controls.Add(groupBox1);
            tabRegister.Controls.Add(toolStrip2);
            tabRegister.Location = new System.Drawing.Point(4, 5);
            tabRegister.Margin = new System.Windows.Forms.Padding(0);
            tabRegister.Name = "tabRegister";
            tabRegister.Size = new System.Drawing.Size(669, 341);
            tabRegister.TabIndex = 1;
            tabRegister.Text = "tabNewPayee";
            tabRegister.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucTaxPayers1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(669, 310);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Register";
            // 
            // ucTaxPayers1
            // 
            ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucTaxPayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxPayers1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucTaxPayers1.Location = new System.Drawing.Point(3, 23);
            ucTaxPayers1.Name = "ucTaxPayers1";
            ucTaxPayers1.Size = new System.Drawing.Size(663, 284);
            ucTaxPayers1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnBack });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(669, 31);
            toolStrip2.TabIndex = 2;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnBack
            // 
            btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnBack.Image = Properties.Resources.arrow_left_20px;
            btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(23, 20);
            btnBack.Text = "Back";
            btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnBack.Click += btnBack_Click;
            // 
            // ucPaymentRegistry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControlRegistry);
            Name = "ucPaymentRegistry";
            Size = new System.Drawing.Size(677, 350);
            Load += ucRegistry_Load;
            tabControlRegistry.ResumeLayout(false);
            tabRegistryList.ResumeLayout(false);
            tabRegistryList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgPayees).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabRegister.ResumeLayout(false);
            tabRegister.PerformLayout();
            groupBox1.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRegistry;
        private System.Windows.Forms.TabPage tabRegistryList;
        private System.Windows.Forms.DataGridView dgPayees;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnRegister;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
    }
}
