namespace AccountingSystem.Views.Manage.TaxTypes
{
    partial class frmTaxTypes
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewTaxTypes = new System.Windows.Forms.TreeView();
            this.pbLoadRecords = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbxParent = new System.Windows.Forms.ComboBox();
            this.cmbxFundType = new System.Windows.Forms.ComboBox();
            this.txtBLFGAccountCode = new System.Windows.Forms.TextBox();
            this.txtCOAAccountCode = new System.Windows.Forms.TextBox();
            this.txtDesciption = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndelete = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            //
            // flowLayoutPanel1
            //
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 470);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(508, 29);
            this.flowLayoutPanel1.TabIndex = 12;
            //
            // btnCancel
            //
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(430, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnSave
            //
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(349, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(268, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // errorProvider1
            //
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            //
            // backgroundWorker1
            //
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            //
            // splitContainer1
            //
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.pbLoadRecords);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(508, 470);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 29;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.treeViewTaxTypes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(508, 235);
            this.panel1.TabIndex = 28;
            //
            // treeViewTaxTypes
            //
            this.treeViewTaxTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewTaxTypes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeViewTaxTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTaxTypes.HideSelection = false;
            this.treeViewTaxTypes.Location = new System.Drawing.Point(4, 4);
            this.treeViewTaxTypes.Name = "treeViewTaxTypes";
            this.treeViewTaxTypes.Size = new System.Drawing.Size(500, 227);
            this.treeViewTaxTypes.TabIndex = 29;
            this.treeViewTaxTypes.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewTaxTypes_BeforeSelect);
            this.treeViewTaxTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTaxTypes_AfterSelect);
            //
            // pbLoadRecords
            //
            this.pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLoadRecords.Location = new System.Drawing.Point(0, 0);
            this.pbLoadRecords.Name = "pbLoadRecords";
            this.pbLoadRecords.Size = new System.Drawing.Size(508, 5);
            this.pbLoadRecords.TabIndex = 27;
            //
            // panel2
            //
            this.panel2.Controls.Add(this.cmbxParent);
            this.panel2.Controls.Add(this.cmbxFundType);
            this.panel2.Controls.Add(this.txtBLFGAccountCode);
            this.panel2.Controls.Add(this.txtCOAAccountCode);
            this.panel2.Controls.Add(this.txtDesciption);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 172);
            this.panel2.TabIndex = 29;
            //
            // cmbxParent
            //
            this.cmbxParent.DropDownHeight = 100;
            this.cmbxParent.FormattingEnabled = true;
            this.cmbxParent.IntegralHeight = false;
            this.cmbxParent.Location = new System.Drawing.Point(132, 60);
            this.cmbxParent.Name = "cmbxParent";
            this.cmbxParent.Size = new System.Drawing.Size(353, 23);
            this.cmbxParent.TabIndex = 3;
            this.cmbxParent.DropDown += new System.EventHandler(this.cmbxParent_DropDown);
            this.cmbxParent.SelectedIndexChanged += new System.EventHandler(this.cmbxParent_SelectedIndexChanged);
            //
            // cmbxFundType
            //
            this.cmbxFundType.FormattingEnabled = true;
            this.cmbxFundType.Location = new System.Drawing.Point(132, 87);
            this.cmbxFundType.Name = "cmbxFundType";
            this.cmbxFundType.Size = new System.Drawing.Size(353, 23);
            this.cmbxFundType.TabIndex = 4;
            //
            // txtBLFGAccountCode
            //
            this.txtBLFGAccountCode.Location = new System.Drawing.Point(132, 141);
            this.txtBLFGAccountCode.MaxLength = 99;
            this.txtBLFGAccountCode.Name = "txtBLFGAccountCode";
            this.txtBLFGAccountCode.Size = new System.Drawing.Size(353, 23);
            this.txtBLFGAccountCode.TabIndex = 6;
            //
            // txtCOAAccountCode
            //
            this.txtCOAAccountCode.Location = new System.Drawing.Point(132, 114);
            this.txtCOAAccountCode.MaxLength = 99;
            this.txtCOAAccountCode.Name = "txtCOAAccountCode";
            this.txtCOAAccountCode.Size = new System.Drawing.Size(353, 23);
            this.txtCOAAccountCode.TabIndex = 5;
            //
            // txtDesciption
            //
            this.txtDesciption.Location = new System.Drawing.Point(132, 33);
            this.txtDesciption.MaxLength = 99;
            this.txtDesciption.Name = "txtDesciption";
            this.txtDesciption.Size = new System.Drawing.Size(353, 23);
            this.txtDesciption.TabIndex = 2;
            this.txtDesciption.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesciption_Validating);
            this.txtDesciption.Validated += new System.EventHandler(this.txtDesciption_Validated);
            //
            // txtCode
            //
            this.txtCode.Location = new System.Drawing.Point(132, 6);
            this.txtCode.MaxLength = 45;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(353, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            this.txtCode.Validated += new System.EventHandler(this.txtCode_Validated);
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "BLGF Account Code";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "COA Account Code";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fund Type";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parent";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            //
            // toolStrip2
            //
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnUndelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            this.toolStrip2.Size = new System.Drawing.Size(508, 54);
            this.toolStrip2.TabIndex = 28;
            this.toolStrip2.Text = "toolStrip2";
            //
            // btnNew
            //
            this.btnNew.Image = global::AccountingSystem.Properties.Resources.button_rounded_add_20px;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(35, 43);
            this.btnNew.Text = "&New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            //
            // btnEdit
            //
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::AccountingSystem.Properties.Resources.button_rounded_edit_20px;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 43);
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.button_rounded_remove_20px;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 43);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            this.toolStripSeparator1.Visible = false;
            //
            // btnUndelete
            //
            this.btnUndelete.Image = global::AccountingSystem.Properties.Resources.symbol_refresh_28px;
            this.btnUndelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUndelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Size = new System.Drawing.Size(58, 43);
            this.btnUndelete.Text = "&Undelete";
            this.btnUndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUndelete.Visible = false;
            this.btnUndelete.Click += new System.EventHandler(this.toolStripButtonUndelete_Click);
            //
            // frmTaxTypes
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(508, 499);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(524, 538);
            this.Name = "frmTaxTypes";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Types";
            this.Load += new System.EventHandler(this.frmTaxTypes_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewTaxTypes;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxParent;
        private System.Windows.Forms.ComboBox cmbxFundType;
        private System.Windows.Forms.TextBox txtBLFGAccountCode;
        private System.Windows.Forms.TextBox txtCOAAccountCode;
        private System.Windows.Forms.TextBox txtDesciption;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUndelete;
    }
}