
namespace AccountingSystem.Views.Manage.AccountableForm
{
    partial class frmFaceValue
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
            dgfacevalue = new System.Windows.Forms.DataGridView();
            txtamount = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnsave = new System.Windows.Forms.Button();
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);
            dtdate = new System.Windows.Forms.DateTimePicker();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblRecords = new System.Windows.Forms.ToolStripStatusLabel();
            springLbl = new System.Windows.Forms.ToolStripStatusLabel();
            lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgfacevalue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtamount).BeginInit();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgfacevalue
            // 
            dgfacevalue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgfacevalue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgfacevalue.Location = new System.Drawing.Point(10, 83);
            dgfacevalue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgfacevalue.Name = "dgfacevalue";
            dgfacevalue.RowHeadersWidth = 51;
            dgfacevalue.RowTemplate.Height = 29;
            dgfacevalue.Size = new System.Drawing.Size(491, 140);
            dgfacevalue.TabIndex = 0;
            dgfacevalue.SelectionChanged += new System.EventHandler(dgfacevalue_SelectionChanged);
            // 
            // txtamount
            // 
            txtamount.DecimalPlaces = 2;
            txtamount.Location = new System.Drawing.Point(231, 56);
            txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtamount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtamount.Name = "txtamount";
            txtamount.Size = new System.Drawing.Size(81, 23);
            txtamount.TabIndex = 1;
            txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 56);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(4);
            label1.Size = new System.Drawing.Size(42, 23);
            label1.TabIndex = 3;
            label1.Text = "Date ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(163, 57);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(4);
            label2.Size = new System.Drawing.Size(62, 23);
            label2.TabIndex = 4;
            label2.Text = "Amount ";
            // 
            // btnsave
            // 
            btnsave.Location = new System.Drawing.Point(318, 57);
            btnsave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnsave.Name = "btnsave";
            btnsave.Size = new System.Drawing.Size(69, 22);
            btnsave.TabIndex = 2;
            btnsave.Text = "Add";
            btnsave.UseVisualStyleBackColor = true;
            btnsave.Click += new System.EventHandler(btnsave_Click);
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnEdit, btnDelete });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(511, 50);
            toolStrip.TabIndex = 9;
            toolStrip.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(31, 39);
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += new System.EventHandler(btnEdit_Click);
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += new System.EventHandler(btnDelete_Click);
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // dtdate
            // 
            dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtdate.Location = new System.Drawing.Point(53, 56);
            dtdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtdate.Name = "dtdate";
            dtdate.Size = new System.Drawing.Size(103, 23);
            dtdate.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblRecords, springLbl, lblDateEntry, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel1, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 225);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(511, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.Stretch = false;
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblRecords
            // 
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new System.Drawing.Size(0, 17);
            // 
            // springLbl
            // 
            springLbl.Name = "springLbl";
            springLbl.Size = new System.Drawing.Size(354, 17);
            springLbl.Spring = true;
            // 
            // lblDateEntry
            // 
            lblDateEntry.Name = "lblDateEntry";
            lblDateEntry.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel1.Text = "|";
            toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // frmFaceValue
            // 
            AcceptButton = btnsave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(511, 247);
            Controls.Add(statusStrip1);
            Controls.Add(label1);
            Controls.Add(dtdate);
            Controls.Add(toolStrip);
            Controls.Add(label2);
            Controls.Add(dgfacevalue);
            Controls.Add(txtamount);
            Controls.Add(btnsave);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFaceValue";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Face Values";
            Load += new System.EventHandler(frmFaceValue_Load);
            ((System.ComponentModel.ISupportInitialize)dgfacevalue).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtamount).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgfacevalue;
        private System.Windows.Forms.NumericUpDown txtamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtdate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lblRecords;
        private System.Windows.Forms.ToolStripStatusLabel springLbl;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntry;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
    }
}