namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    partial class ucCattleTransferOfOwnership
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            panelSearch = new System.Windows.Forms.Panel();
            dgCattle = new System.Windows.Forms.DataGridView();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnSelect = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            panel1Control = new System.Windows.Forms.Panel();
            linkSearch = new System.Windows.Forms.LinkLabel();
            nudCattleAge = new System.Windows.Forms.NumericUpDown();
            nudCattlePrice = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            cmbxSex = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cmbxCattleType = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            txtCattleDescription = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            btnBrowse = new System.Windows.Forms.Button();
            cmbxBarangay = new System.Windows.Forms.ComboBox();
            cmbxMunicipality = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbxProvince = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            txtCattleNewOwner = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtCattleOldOwner = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            groupBox1.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCattle).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCattleAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCattlePrice).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1Control);
            groupBox1.Controls.Add(panelSearch);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(367, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5);
            groupBox1.Size = new System.Drawing.Size(387, 188);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cattle's Details";
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(dgCattle);
            panelSearch.Controls.Add(flowLayoutPanel1);
            panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panelSearch.Location = new System.Drawing.Point(5, 21);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new System.Windows.Forms.Padding(4);
            panelSearch.Size = new System.Drawing.Size(377, 162);
            panelSearch.TabIndex = 6;
            // 
            // dgCattle
            // 
            dgCattle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCattle.Dock = System.Windows.Forms.DockStyle.Fill;
            dgCattle.Location = new System.Drawing.Point(4, 4);
            dgCattle.Name = "dgCattle";
            dgCattle.RowTemplate.Height = 25;
            dgCattle.Size = new System.Drawing.Size(369, 124);
            dgCattle.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSelect);
            flowLayoutPanel1.Controls.Add(txtSearch);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 128);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(369, 30);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(291, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new System.Drawing.Point(210, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(75, 23);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(157, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(209, 23);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel1Control
            // 
            panel1Control.Controls.Add(linkSearch);
            panel1Control.Controls.Add(nudCattleAge);
            panel1Control.Controls.Add(nudCattlePrice);
            panel1Control.Controls.Add(label8);
            panel1Control.Controls.Add(cmbxSex);
            panel1Control.Controls.Add(label9);
            panel1Control.Controls.Add(label7);
            panel1Control.Controls.Add(cmbxCattleType);
            panel1Control.Controls.Add(label6);
            panel1Control.Controls.Add(txtCattleDescription);
            panel1Control.Controls.Add(label10);
            panel1Control.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1Control.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel1Control.Location = new System.Drawing.Point(5, 21);
            panel1Control.Name = "panel1Control";
            panel1Control.Size = new System.Drawing.Size(377, 162);
            panel1Control.TabIndex = 0;
            // 
            // linkSearch
            // 
            linkSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkSearch.AutoSize = true;
            linkSearch.BackColor = System.Drawing.Color.Transparent;
            linkSearch.Location = new System.Drawing.Point(283, 3);
            linkSearch.Name = "linkSearch";
            linkSearch.Size = new System.Drawing.Size(76, 15);
            linkSearch.TabIndex = 6;
            linkSearch.TabStop = true;
            linkSearch.Text = "Search Cattle";
            linkSearch.Click += linkSearch_Click;
            // 
            // nudCattleAge
            // 
            nudCattleAge.Enabled = false;
            nudCattleAge.Location = new System.Drawing.Point(279, 50);
            nudCattleAge.Name = "nudCattleAge";
            nudCattleAge.Size = new System.Drawing.Size(80, 23);
            nudCattleAge.TabIndex = 5;
            // 
            // nudCattlePrice
            // 
            nudCattlePrice.DecimalPlaces = 2;
            nudCattlePrice.Location = new System.Drawing.Point(94, 79);
            nudCattlePrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCattlePrice.Name = "nudCattlePrice";
            nudCattlePrice.Size = new System.Drawing.Size(265, 23);
            nudCattlePrice.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(245, 53);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(28, 15);
            label8.TabIndex = 2;
            label8.Text = "Age";
            // 
            // cmbxSex
            // 
            cmbxSex.Enabled = false;
            cmbxSex.FormattingEnabled = true;
            cmbxSex.Location = new System.Drawing.Point(94, 50);
            cmbxSex.Name = "cmbxSex";
            cmbxSex.Size = new System.Drawing.Size(83, 23);
            cmbxSex.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(17, 81);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(33, 15);
            label9.TabIndex = 2;
            label9.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(17, 53);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(25, 15);
            label7.TabIndex = 2;
            label7.Text = "Sex";
            // 
            // cmbxCattleType
            // 
            cmbxCattleType.Enabled = false;
            cmbxCattleType.FormattingEnabled = true;
            cmbxCattleType.Location = new System.Drawing.Point(94, 21);
            cmbxCattleType.Name = "cmbxCattleType";
            cmbxCattleType.Size = new System.Drawing.Size(265, 23);
            cmbxCattleType.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(17, 27);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 2;
            label6.Text = "Type";
            // 
            // txtCattleDescription
            // 
            txtCattleDescription.Enabled = false;
            txtCattleDescription.Location = new System.Drawing.Point(94, 108);
            txtCattleDescription.Multiline = true;
            txtCattleDescription.Name = "txtCattleDescription";
            txtCattleDescription.Size = new System.Drawing.Size(265, 46);
            txtCattleDescription.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(17, 111);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(67, 15);
            label10.TabIndex = 2;
            label10.Text = "Description";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5);
            groupBox2.Size = new System.Drawing.Size(358, 188);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Owners && Information";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnBrowse);
            panel2.Controls.Add(cmbxBarangay);
            panel2.Controls.Add(cmbxMunicipality);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cmbxProvince);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtCattleNewOwner);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtCattleOldOwner);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel2.Location = new System.Drawing.Point(5, 21);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(348, 162);
            panel2.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Image = Properties.Resources.user_browse_14px;
            btnBrowse.Location = new System.Drawing.Point(323, 45);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(22, 23);
            btnBrowse.TabIndex = 7;
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // cmbxBarangay
            // 
            cmbxBarangay.Enabled = false;
            cmbxBarangay.FormattingEnabled = true;
            cmbxBarangay.Location = new System.Drawing.Point(97, 132);
            cmbxBarangay.Name = "cmbxBarangay";
            cmbxBarangay.Size = new System.Drawing.Size(223, 23);
            cmbxBarangay.TabIndex = 4;
            // 
            // cmbxMunicipality
            // 
            cmbxMunicipality.Enabled = false;
            cmbxMunicipality.FormattingEnabled = true;
            cmbxMunicipality.Location = new System.Drawing.Point(97, 103);
            cmbxMunicipality.Name = "cmbxMunicipality";
            cmbxMunicipality.Size = new System.Drawing.Size(223, 23);
            cmbxMunicipality.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 132);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 15);
            label5.TabIndex = 2;
            label5.Text = "Barangay";
            // 
            // cmbxProvince
            // 
            cmbxProvince.Enabled = false;
            cmbxProvince.FormattingEnabled = true;
            cmbxProvince.Location = new System.Drawing.Point(97, 74);
            cmbxProvince.Name = "cmbxProvince";
            cmbxProvince.Size = new System.Drawing.Size(223, 23);
            cmbxProvince.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 103);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 2;
            label4.Text = "Mun./City";
            // 
            // txtCattleNewOwner
            // 
            txtCattleNewOwner.Enabled = false;
            txtCattleNewOwner.Location = new System.Drawing.Point(97, 45);
            txtCattleNewOwner.Name = "txtCattleNewOwner";
            txtCattleNewOwner.Size = new System.Drawing.Size(223, 23);
            txtCattleNewOwner.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 15);
            label3.TabIndex = 2;
            label3.Text = "Province";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "New Owner";
            // 
            // txtCattleOldOwner
            // 
            txtCattleOldOwner.Enabled = false;
            txtCattleOldOwner.Location = new System.Drawing.Point(97, 16);
            txtCattleOldOwner.Name = "txtCattleOldOwner";
            txtCattleOldOwner.Size = new System.Drawing.Size(223, 23);
            txtCattleOldOwner.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Old Owner";
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(groupBox1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(762, 194);
            panel3.TabIndex = 5;
            // 
            // ucCattleTransferOfOwnership
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel3);
            Name = "ucCattleTransferOfOwnership";
            Size = new System.Drawing.Size(762, 194);
            Load += ucCattleTransferOfOwnership_Load;
            groupBox1.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgCattle).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1Control.ResumeLayout(false);
            panel1Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCattleAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCattlePrice).EndInit();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1Control;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.NumericUpDown nudCattlePrice;
        internal System.Windows.Forms.ComboBox cmbxSex;
        internal System.Windows.Forms.ComboBox cmbxCattleType;
        internal System.Windows.Forms.TextBox txtCattleDescription;
        internal System.Windows.Forms.ComboBox cmbxBarangay;
        internal System.Windows.Forms.ComboBox cmbxMunicipality;
        internal System.Windows.Forms.ComboBox cmbxProvince;
        internal System.Windows.Forms.TextBox txtCattleNewOwner;
        internal System.Windows.Forms.TextBox txtCattleOldOwner;
        internal System.Windows.Forms.NumericUpDown nudCattleAge;
        private System.Windows.Forms.LinkLabel linkSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DataGridView dgCattle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.TextBox txtSearch;
    }
}
