namespace LFS.Views.Transactions.Payments
{
    partial class ucPaymentFeesCharges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            dgPaymentFeesCharges = new System.Windows.Forms.DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            treeViewFeesCharges = new System.Windows.Forms.TreeView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tStrpBtnSearch = new System.Windows.Forms.ToolStripButton();
            tStrpTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            panel4 = new System.Windows.Forms.Panel();
            btnDelete = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPaymentFeesCharges).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(panel2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(751, 541);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fees && Charges";
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.Location = new System.Drawing.Point(3, 23);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(745, 515);
            panel2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            tableLayoutPanel1.Controls.Add(dgPaymentFeesCharges, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(737, 507);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // dgPaymentFeesCharges
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgPaymentFeesCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgPaymentFeesCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgPaymentFeesCharges.DefaultCellStyle = dataGridViewCellStyle2;
            dgPaymentFeesCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            dgPaymentFeesCharges.Location = new System.Drawing.Point(3, 274);
            dgPaymentFeesCharges.Name = "dgPaymentFeesCharges";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgPaymentFeesCharges.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgPaymentFeesCharges.RowTemplate.Height = 25;
            dgPaymentFeesCharges.Size = new System.Drawing.Size(731, 230);
            dgPaymentFeesCharges.TabIndex = 12;
            dgPaymentFeesCharges.CellValueChanged += dgPaymentFeesCharges_CellValueChanged;
            dgPaymentFeesCharges.EditingControlShowing += dgPaymentFeesCharges_EditingControlShowing;
            dgPaymentFeesCharges.RowsAdded += dgPaymentFeesCharges_RowsAdded;
            dgPaymentFeesCharges.SelectionChanged += dgPaymentFeesCharges_SelectionChanged;
            dgPaymentFeesCharges.Validating += dgPaymentFeesCharges_Validating;
            dgPaymentFeesCharges.Validated += dgPaymentFeesCharges_Validated;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeViewFeesCharges);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(737, 235);
            panel1.TabIndex = 13;
            // 
            // treeViewFeesCharges
            // 
            treeViewFeesCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewFeesCharges.FullRowSelect = true;
            treeViewFeesCharges.HideSelection = false;
            treeViewFeesCharges.Location = new System.Drawing.Point(0, 33);
            treeViewFeesCharges.Name = "treeViewFeesCharges";
            treeViewFeesCharges.Size = new System.Drawing.Size(737, 202);
            treeViewFeesCharges.TabIndex = 1;
            treeViewFeesCharges.AfterSelect += treeViewFeesCharges_AfterSelect;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 28);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(737, 5);
            progressBar1.TabIndex = 13;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tStrpBtnSearch, tStrpTxtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 5);
            toolStrip1.Size = new System.Drawing.Size(737, 28);
            toolStrip1.TabIndex = 15;
            toolStrip1.Text = "toolStrip1";
            // 
            // tStrpBtnSearch
            // 
            tStrpBtnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tStrpBtnSearch.Image = Properties.Resources.find_16px;
            tStrpBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            tStrpBtnSearch.Name = "tStrpBtnSearch";
            tStrpBtnSearch.Size = new System.Drawing.Size(62, 20);
            tStrpBtnSearch.Text = "Search";
            tStrpBtnSearch.ToolTipText = "Search...";
            tStrpBtnSearch.Click += tStrpTxtSearch_Click;
            // 
            // tStrpTxtSearch
            // 
            tStrpTxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tStrpTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tStrpTxtSearch.Name = "tStrpTxtSearch";
            tStrpTxtSearch.Size = new System.Drawing.Size(200, 23);
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnAdd);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(3, 238);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(731, 30);
            panel4.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnDelete.Location = new System.Drawing.Point(354, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(31, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "?";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAdd.Location = new System.Drawing.Point(317, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(31, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "?";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // ucPaymentFeesCharges
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "ucPaymentFeesCharges";
            Size = new System.Drawing.Size(751, 541);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgPaymentFeesCharges).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewFeesCharges;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgPaymentFeesCharges;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tStrpBtnSearch;
        private System.Windows.Forms.ToolStripTextBox tStrpTxtSearch;
    }
}
