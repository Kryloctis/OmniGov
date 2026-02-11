
namespace LFS.Budget.Views.AllotmentRelease
{
    partial class ucAllotmentReleaseMain
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            cmbxFPP = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbxSubFPP = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanelAllotmentClass = new System.Windows.Forms.FlowLayoutPanel();
            dtDateIssued = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            mskYear = new System.Windows.Forms.MaskedTextBox();
            mskSeriesNo = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            txtPurpose = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            txtTotal = new System.Windows.Forms.ToolStripTextBox();
            btnRemove = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            panel2 = new System.Windows.Forms.Panel();
            dgAllotmentRelease = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAllotmentRelease).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanelFunds);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(0, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(647, 53);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fund";
            // 
            // flowLayoutPanelFunds
            // 
            flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            flowLayoutPanelFunds.Size = new System.Drawing.Size(641, 31);
            flowLayoutPanelFunds.TabIndex = 2;
            // 
            // cmbxFPP
            // 
            cmbxFPP.FormattingEnabled = true;
            cmbxFPP.Location = new System.Drawing.Point(66, 6);
            cmbxFPP.Name = "cmbxFPP";
            cmbxFPP.Size = new System.Drawing.Size(581, 23);
            cmbxFPP.TabIndex = 0;
            cmbxFPP.KeyDown += cmbxFPP_KeyDown;
            cmbxFPP.Validating += cmbxFPP_Validating;
            cmbxFPP.Validated += cmbxFPP_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(0, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(27, 15);
            label5.TabIndex = 12;
            label5.Text = "FPP";
            // 
            // cmbxSubFPP
            // 
            cmbxSubFPP.FormattingEnabled = true;
            cmbxSubFPP.Location = new System.Drawing.Point(66, 35);
            cmbxSubFPP.Name = "cmbxSubFPP";
            cmbxSubFPP.Size = new System.Drawing.Size(581, 23);
            cmbxSubFPP.TabIndex = 1;
            cmbxSubFPP.KeyDown += cmbxSubFPP_KeyDown;
            cmbxSubFPP.Validating += cmbxSubFPP_Validating;
            cmbxSubFPP.Validated += cmbxSubFPP_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(0, 38);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 15);
            label6.TabIndex = 12;
            label6.Text = "Sub FPP";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(cmbxSubFPP);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbxFPP);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(667, 175);
            panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanelAllotmentClass);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(0, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(647, 53);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Allotment";
            // 
            // flowLayoutPanelAllotmentClass
            // 
            flowLayoutPanelAllotmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelAllotmentClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanelAllotmentClass.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelAllotmentClass.Name = "flowLayoutPanelAllotmentClass";
            flowLayoutPanelAllotmentClass.Size = new System.Drawing.Size(641, 31);
            flowLayoutPanelAllotmentClass.TabIndex = 3;
            // 
            // dtDateIssued
            // 
            dtDateIssued.Location = new System.Drawing.Point(431, 181);
            dtDateIssued.Name = "dtDateIssued";
            dtDateIssued.Size = new System.Drawing.Size(216, 23);
            dtDateIssued.TabIndex = 5;
            dtDateIssued.ValueChanged += dtDateIssued_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(358, 183);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 34;
            label2.Text = "Date Issued";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(96, 184);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(12, 15);
            label3.TabIndex = 43;
            label3.Text = "-";
            // 
            // mskYear
            // 
            mskYear.Location = new System.Drawing.Point(111, 181);
            mskYear.Mask = "0000";
            mskYear.Name = "mskYear";
            mskYear.ReadOnly = true;
            mskYear.Size = new System.Drawing.Size(41, 23);
            mskYear.TabIndex = 44;
            mskYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mskSeriesNo
            // 
            mskSeriesNo.Location = new System.Drawing.Point(66, 181);
            mskSeriesNo.Mask = "000";
            mskSeriesNo.Name = "mskSeriesNo";
            mskSeriesNo.Size = new System.Drawing.Size(27, 23);
            mskSeriesNo.TabIndex = 41;
            mskSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            mskSeriesNo.Validating += mskSeriesNo_Validating;
            mskSeriesNo.Validated += mskSeriesNo_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 184);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 42;
            label1.Text = "ARO No.";
            // 
            // txtPurpose
            // 
            txtPurpose.Location = new System.Drawing.Point(66, 210);
            txtPurpose.MaxLength = 200;
            txtPurpose.Multiline = true;
            txtPurpose.Name = "txtPurpose";
            txtPurpose.Size = new System.Drawing.Size(581, 39);
            txtPurpose.TabIndex = 45;
            txtPurpose.Validating += txtPurpose_Validating;
            txtPurpose.Validated += txtPurpose_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 213);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(50, 15);
            label4.TabIndex = 46;
            label4.Text = "Purpose";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1, txtTotal, btnRemove, btnEdit, btnAdd });
            toolStrip1.Location = new System.Drawing.Point(0, 578);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(670, 31);
            toolStrip1.TabIndex = 49;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(32, 20);
            toolStripLabel1.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new System.Drawing.Size(200, 23);
            // 
            // btnRemove
            // 
            btnRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnRemove.Image = Properties.Resources.waste_bin_filled_20px;
            btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(23, 20);
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnEdit.Image = Properties.Resources.tool_pencil_filled_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(23, 20);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnAdd.Image = Properties.Resources.symbol_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(23, 20);
            btnAdd.Text = "toolStripButton5";
            btnAdd.Click += btnAdd_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgAllotmentRelease);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 255);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(670, 323);
            panel2.TabIndex = 50;
            // 
            // dgAllotmentRelease
            // 
            dgAllotmentRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAllotmentRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAllotmentRelease.Location = new System.Drawing.Point(4, 4);
            dgAllotmentRelease.Name = "dgAllotmentRelease";
            dgAllotmentRelease.RowTemplate.Height = 25;
            dgAllotmentRelease.Size = new System.Drawing.Size(662, 315);
            dgAllotmentRelease.TabIndex = 8;
            dgAllotmentRelease.Tag = "";
            dgAllotmentRelease.SelectionChanged += dgAllotmentRelease_SelectionChanged;
            dgAllotmentRelease.Validating += dgAllotmentRelease_Validating;
            dgAllotmentRelease.Validated += dgAllotmentRelease_Validated;
            // 
            // ucAllotmentReleaseMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(panel2);
            Controls.Add(toolStrip1);
            Controls.Add(dtDateIssued);
            Controls.Add(label2);
            Controls.Add(txtPurpose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(mskYear);
            Controls.Add(mskSeriesNo);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "ucAllotmentReleaseMain";
            Size = new System.Drawing.Size(670, 609);
            Load += ucAllotmentReleaseMain_Load;
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAllotmentRelease).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.ComboBox cmbxSubFPP;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotmentClass;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.TextBox txtPurpose;
        internal System.Windows.Forms.MaskedTextBox mskYear;
        internal System.Windows.Forms.MaskedTextBox mskSeriesNo;
        internal System.Windows.Forms.DataGridView dgAllotmentRelease;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripTextBox txtTotal;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ToolStripButton btnRemove;
        internal System.Windows.Forms.ToolStripButton btnEdit;
        internal System.Windows.Forms.ToolStripButton btnAdd;
    }
}
