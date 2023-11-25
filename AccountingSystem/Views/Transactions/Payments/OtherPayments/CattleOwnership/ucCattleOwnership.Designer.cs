namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    partial class ucCattleOwnership
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
            components = new System.ComponentModel.Container();
            nudAge = new System.Windows.Forms.NumericUpDown();
            nudPrice = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cmbxType = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageOwner = new System.Windows.Forms.TabPage();
            tabControlOwner = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            tabPageNewOwner = new System.Windows.Forms.TabPage();
            ucTaxPayers1 = new Manage.TaxPayers.ucTaxPayers();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            tabPage2 = new System.Windows.Forms.TabPage();
            flwPanelCattleSex = new System.Windows.Forms.FlowLayoutPanel();
            radCattleMale = new System.Windows.Forms.RadioButton();
            radCattleFemale = new System.Windows.Forms.RadioButton();
            tabPage1 = new System.Windows.Forms.TabPage();
            ucOtherCharges1 = new ucFeesCharges();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageOwner.SuspendLayout();
            tabControlOwner.SuspendLayout();
            tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            tabPageNewOwner.SuspendLayout();
            toolStrip2.SuspendLayout();
            tabPage2.SuspendLayout();
            flwPanelCattleSex.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // nudAge
            // 
            nudAge.Location = new System.Drawing.Point(76, 36);
            nudAge.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(80, 23);
            nudAge.TabIndex = 5;
            // 
            // nudPrice
            // 
            nudPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new System.Drawing.Point(76, 127);
            nudPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new System.Drawing.Size(394, 23);
            nudPrice.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(3, 39);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(28, 15);
            label8.TabIndex = 2;
            label8.Text = "Age";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 130);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(33, 15);
            label9.TabIndex = 2;
            label9.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 70);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(25, 15);
            label7.TabIndex = 2;
            label7.Text = "Sex";
            // 
            // cmbxType
            // 
            cmbxType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxType.FormattingEnabled = true;
            cmbxType.Location = new System.Drawing.Point(76, 7);
            cmbxType.Name = "cmbxType";
            cmbxType.Size = new System.Drawing.Size(394, 23);
            cmbxType.TabIndex = 4;
            cmbxType.Validating += cmbxType_Validating;
            cmbxType.Validated += cmbxType_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 10);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 2;
            label6.Text = "Type";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDescription.Location = new System.Drawing.Point(76, 98);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(394, 23);
            txtDescription.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 101);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(67, 15);
            label10.TabIndex = 2;
            label10.Text = "Description";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageOwner);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(500, 394);
            tabControl1.TabIndex = 7;
            // 
            // tabPageOwner
            // 
            tabPageOwner.Controls.Add(tabControlOwner);
            tabPageOwner.Location = new System.Drawing.Point(4, 24);
            tabPageOwner.Margin = new System.Windows.Forms.Padding(0);
            tabPageOwner.Name = "tabPageOwner";
            tabPageOwner.Size = new System.Drawing.Size(492, 366);
            tabPageOwner.TabIndex = 0;
            tabPageOwner.Text = "Owner";
            tabPageOwner.UseVisualStyleBackColor = true;
            // 
            // tabControlOwner
            // 
            tabControlOwner.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControlOwner.Controls.Add(tabPageList);
            tabControlOwner.Controls.Add(tabPageNewOwner);
            tabControlOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlOwner.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControlOwner.ItemSize = new System.Drawing.Size(0, 1);
            tabControlOwner.Location = new System.Drawing.Point(0, 0);
            tabControlOwner.Margin = new System.Windows.Forms.Padding(0);
            tabControlOwner.Name = "tabControlOwner";
            tabControlOwner.Padding = new System.Drawing.Point(0, 0);
            tabControlOwner.SelectedIndex = 0;
            tabControlOwner.Size = new System.Drawing.Size(492, 366);
            tabControlOwner.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlOwner.TabIndex = 1;
            // 
            // tabPageList
            // 
            tabPageList.BackColor = System.Drawing.Color.Transparent;
            tabPageList.Controls.Add(dataGridView1);
            tabPageList.Controls.Add(progressBar1);
            tabPageList.Controls.Add(toolStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 5);
            tabPageList.Margin = new System.Windows.Forms.Padding(0);
            tabPageList.Name = "tabPageList";
            tabPageList.Size = new System.Drawing.Size(484, 357);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "tabPageList";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(484, 321);
            dataGridView1.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 31);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(484, 5);
            progressBar1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonAdd, toolStripButtonFind, toolStripTextBoxSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(484, 31);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = Properties.Resources.symbol_add_20px;
            toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new System.Drawing.Size(23, 20);
            toolStripButtonAdd.Text = "toolStripButton1";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonFind
            // 
            toolStripButtonFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonFind.Image = Properties.Resources.find_20px;
            toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonFind.Name = "toolStripButtonFind";
            toolStripButtonFind.Size = new System.Drawing.Size(23, 20);
            toolStripButtonFind.Text = "toolStripButton3";
            // 
            // toolStripTextBoxSearch
            // 
            toolStripTextBoxSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            toolStripTextBoxSearch.Size = new System.Drawing.Size(200, 23);
            // 
            // tabPageNewOwner
            // 
            tabPageNewOwner.Controls.Add(ucTaxPayers1);
            tabPageNewOwner.Controls.Add(toolStrip2);
            tabPageNewOwner.Location = new System.Drawing.Point(4, 5);
            tabPageNewOwner.Name = "tabPageNewOwner";
            tabPageNewOwner.Padding = new System.Windows.Forms.Padding(3);
            tabPageNewOwner.Size = new System.Drawing.Size(484, 357);
            tabPageNewOwner.TabIndex = 1;
            tabPageNewOwner.Text = "tabPageNewOwner";
            tabPageNewOwner.UseVisualStyleBackColor = true;
            // 
            // ucTaxPayers1
            // 
            ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucTaxPayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxPayers1.Location = new System.Drawing.Point(3, 28);
            ucTaxPayers1.Name = "ucTaxPayers1";
            ucTaxPayers1.Size = new System.Drawing.Size(478, 326);
            ucTaxPayers1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonBack });
            toolStrip2.Location = new System.Drawing.Point(3, 3);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new System.Drawing.Size(478, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonBack
            // 
            toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonBack.Image = Properties.Resources.arrow_left_20px;
            toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonBack.Name = "toolStripButtonBack";
            toolStripButtonBack.Size = new System.Drawing.Size(23, 22);
            toolStripButtonBack.Text = "toolStripButton2";
            toolStripButtonBack.Click += toolStripButtonBack_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flwPanelCattleSex);
            tabPage2.Controls.Add(nudAge);
            tabPage2.Controls.Add(txtDescription);
            tabPage2.Controls.Add(nudPrice);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(cmbxType);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4);
            tabPage2.Size = new System.Drawing.Size(492, 366);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cattle Details";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flwPanelCattleSex
            // 
            flwPanelCattleSex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flwPanelCattleSex.Controls.Add(radCattleMale);
            flwPanelCattleSex.Controls.Add(radCattleFemale);
            flwPanelCattleSex.Location = new System.Drawing.Point(76, 65);
            flwPanelCattleSex.Name = "flwPanelCattleSex";
            flwPanelCattleSex.Size = new System.Drawing.Size(394, 27);
            flwPanelCattleSex.TabIndex = 7;
            // 
            // radCattleMale
            // 
            radCattleMale.AutoSize = true;
            radCattleMale.Checked = true;
            radCattleMale.Location = new System.Drawing.Point(3, 3);
            radCattleMale.Name = "radCattleMale";
            radCattleMale.Size = new System.Drawing.Size(51, 19);
            radCattleMale.TabIndex = 6;
            radCattleMale.TabStop = true;
            radCattleMale.Text = "Male";
            radCattleMale.UseVisualStyleBackColor = true;
            // 
            // radCattleFemale
            // 
            radCattleFemale.AutoSize = true;
            radCattleFemale.Location = new System.Drawing.Point(60, 3);
            radCattleFemale.Name = "radCattleFemale";
            radCattleFemale.Size = new System.Drawing.Size(63, 19);
            radCattleFemale.TabIndex = 6;
            radCattleFemale.Text = "Female";
            radCattleFemale.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucOtherCharges1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(492, 366);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Charges";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucOtherCharges1
            // 
            ucOtherCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucOtherCharges1.Location = new System.Drawing.Point(3, 3);
            ucOtherCharges1.Name = "ucOtherCharges1";
            ucOtherCharges1.Size = new System.Drawing.Size(486, 360);
            ucOtherCharges1.TabIndex = 0;
            // 
            // ucCattleOwnership
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(tabControl1);
            Name = "ucCattleOwnership";
            Size = new System.Drawing.Size(500, 394);
            Load += ucCattleOwnership_Load;
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageOwner.ResumeLayout(false);
            tabControlOwner.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageNewOwner.ResumeLayout(false);
            tabPageNewOwner.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flwPanelCattleSex.ResumeLayout(false);
            flwPanelCattleSex.PerformLayout();
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ComboBox cmbxBarangay;
        internal System.Windows.Forms.ComboBox cmbxMunicipality;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbxProvince;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtOwnerName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.NumericUpDown nudPrice;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbxType;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.NumericUpDown nudAge;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPageOwner;
        internal System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.FlowLayoutPanel flwPanelCattleSex;
        internal System.Windows.Forms.RadioButton radCattleMale;
        internal System.Windows.Forms.RadioButton radCattleFemale;
        internal System.Windows.Forms.TabControl tabControlOwner;
        internal System.Windows.Forms.TabPage tabPageList;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.TabPage tabPageNewOwner;
        internal Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
        internal System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton toolStripButtonBack;
        internal System.Windows.Forms.TabPage tabPage1;
        internal ucFeesCharges ucOtherCharges1;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        internal System.Windows.Forms.ToolStripButton toolStripButtonFind;
        internal System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
    }
}
