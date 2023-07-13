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
            components = new System.ComponentModel.Container();
            panel1 = new System.Windows.Forms.Panel();
            treeViewTaxTypes = new System.Windows.Forms.TreeView();
            panel2 = new System.Windows.Forms.Panel();
            cmbxParent = new System.Windows.Forms.ComboBox();
            cmbxFundType = new System.Windows.Forms.ComboBox();
            txtBLFGAccountCode = new System.Windows.Forms.TextBox();
            txtCOAAccountCode = new System.Windows.Forms.TextBox();
            txtDesciption = new System.Windows.Forms.TextBox();
            txtCode = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonUndelete = new System.Windows.Forms.ToolStripButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            panel3 = new System.Windows.Forms.Panel();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(treeViewTaxTypes);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(798, 169);
            panel1.TabIndex = 0;
            // 
            // treeViewTaxTypes
            // 
            treeViewTaxTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewTaxTypes.HideSelection = false;
            treeViewTaxTypes.Location = new System.Drawing.Point(4, 4);
            treeViewTaxTypes.Name = "treeViewTaxTypes";
            treeViewTaxTypes.Size = new System.Drawing.Size(790, 161);
            treeViewTaxTypes.TabIndex = 1;
            treeViewTaxTypes.BeforeSelect += treeViewTaxTypes_BeforeSelect;
            treeViewTaxTypes.AfterSelect += treeViewTaxTypes_AfterSelect;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxParent);
            panel2.Controls.Add(cmbxFundType);
            panel2.Controls.Add(txtBLFGAccountCode);
            panel2.Controls.Add(txtCOAAccountCode);
            panel2.Controls.Add(txtDesciption);
            panel2.Controls.Add(txtCode);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Enabled = false;
            panel2.Location = new System.Drawing.Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(798, 179);
            panel2.TabIndex = 1;
            // 
            // cmbxParent
            // 
            cmbxParent.DropDownHeight = 100;
            cmbxParent.FormattingEnabled = true;
            cmbxParent.IntegralHeight = false;
            cmbxParent.Location = new System.Drawing.Point(163, 66);
            cmbxParent.Name = "cmbxParent";
            cmbxParent.Size = new System.Drawing.Size(353, 23);
            cmbxParent.TabIndex = 3;
            // 
            // cmbxFundType
            // 
            cmbxFundType.FormattingEnabled = true;
            cmbxFundType.Location = new System.Drawing.Point(163, 93);
            cmbxFundType.Name = "cmbxFundType";
            cmbxFundType.Size = new System.Drawing.Size(353, 23);
            cmbxFundType.TabIndex = 4;
            // 
            // txtBLFGAccountCode
            // 
            txtBLFGAccountCode.Location = new System.Drawing.Point(163, 147);
            txtBLFGAccountCode.Name = "txtBLFGAccountCode";
            txtBLFGAccountCode.Size = new System.Drawing.Size(353, 23);
            txtBLFGAccountCode.TabIndex = 6;
            // 
            // txtCOAAccountCode
            // 
            txtCOAAccountCode.Location = new System.Drawing.Point(163, 120);
            txtCOAAccountCode.Name = "txtCOAAccountCode";
            txtCOAAccountCode.Size = new System.Drawing.Size(353, 23);
            txtCOAAccountCode.TabIndex = 5;
            // 
            // txtDesciption
            // 
            txtDesciption.Location = new System.Drawing.Point(163, 39);
            txtDesciption.Name = "txtDesciption";
            txtDesciption.Size = new System.Drawing.Size(353, 23);
            txtDesciption.TabIndex = 2;
            txtDesciption.Validating += txtDesciption_Validating;
            txtDesciption.Validated += txtDesciption_Validated;
            // 
            // txtCode
            // 
            txtCode.Location = new System.Drawing.Point(163, 12);
            txtCode.Name = "txtCode";
            txtCode.Size = new System.Drawing.Size(353, 23);
            txtCode.TabIndex = 1;
            txtCode.Validating += txtCode_Validating;
            txtCode.Validated += txtCode_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(35, 150);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(113, 15);
            label6.TabIndex = 0;
            label6.Text = "BLGF Account Code";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(35, 123);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 15);
            label5.TabIndex = 0;
            label5.Text = "COA Account Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(35, 96);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 0;
            label4.Text = "Fund Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(35, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 15);
            label3.TabIndex = 0;
            label3.Text = "Parent";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(35, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 0;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(35, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Code";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonNew, toolStripButtonEdit, toolStripButtonDelete, toolStripSeparator1, toolStripButtonUndelete });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(798, 54);
            toolStrip2.TabIndex = 10;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.Image = Properties.Resources.button_rounded_add_24px;
            toolStripButtonNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new System.Drawing.Size(35, 43);
            toolStripButtonNew.Text = "&New";
            toolStripButtonNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            toolStripButtonNew.Click += toolStripButtonNew_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.Enabled = false;
            toolStripButtonEdit.Image = Properties.Resources.button_rounded_edit_20px;
            toolStripButtonEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new System.Drawing.Size(31, 43);
            toolStripButtonEdit.Text = "&Edit";
            toolStripButtonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDelete.Image = Properties.Resources.button_rounded_remove_20px;
            toolStripButtonDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new System.Drawing.Size(44, 43);
            toolStripButtonDelete.Text = "&Delete";
            toolStripButtonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripButtonUndelete
            // 
            toolStripButtonUndelete.Image = Properties.Resources.symbol_refresh_28px;
            toolStripButtonUndelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripButtonUndelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonUndelete.Name = "toolStripButtonUndelete";
            toolStripButtonUndelete.Size = new System.Drawing.Size(58, 43);
            toolStripButtonUndelete.Text = "&Undelete";
            toolStripButtonUndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            toolStripButtonUndelete.Visible = false;
            toolStripButtonUndelete.Click += toolStripButtonUndelete_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnUpdate);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 402);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(798, 29);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new System.Drawing.Point(720, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(639, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(558, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(75, 23);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(toolStrip2);
            panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel3.Location = new System.Drawing.Point(0, 169);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(798, 233);
            panel3.TabIndex = 13;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmTaxTypes
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(798, 431);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(flowLayoutPanel1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(814, 470);
            Name = "frmTaxTypes";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TaxTypes";
            Load += frmTaxTypes_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewTaxTypes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ComboBox cmbxFundType;
        private System.Windows.Forms.TextBox txtBLFGAccountCode;
        private System.Windows.Forms.TextBox txtCOAAccountCode;
        private System.Windows.Forms.TextBox txtDesciption;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cmbxParent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUpdate;
    }
}