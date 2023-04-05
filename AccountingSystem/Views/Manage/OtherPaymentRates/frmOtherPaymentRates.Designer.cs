namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    partial class frmOtherPaymentRates
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
            panel1 = new System.Windows.Forms.Panel();
            dgOtherPaymentRates = new System.Windows.Forms.DataGridView();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblDateEntry = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAtPlaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgOtherPaymentRates).BeginInit();
            toolStrip2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgOtherPaymentRates);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 54);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(791, 342);
            panel1.TabIndex = 16;
            // 
            // dgOtherPaymentRates
            // 
            dgOtherPaymentRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgOtherPaymentRates.Dock = System.Windows.Forms.DockStyle.Fill;
            dgOtherPaymentRates.Location = new System.Drawing.Point(4, 4);
            dgOtherPaymentRates.Name = "dgOtherPaymentRates";
            dgOtherPaymentRates.RowHeadersWidth = 51;
            dgOtherPaymentRates.RowTemplate.Height = 25;
            dgOtherPaymentRates.Size = new System.Drawing.Size(783, 334);
            dgOtherPaymentRates.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonNew, toolStripButtonEdit, toolStripButtonDelete });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(791, 54);
            toolStrip2.TabIndex = 15;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.Image = Properties.Resources.button_rounded_add_24px;
            toolStripButtonNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new System.Drawing.Size(33, 43);
            toolStripButtonNew.Text = "&Add";
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
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.Color.White;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblDateEntry, lblCreatedAtPlaceHolder, lblCreatedAt, toolStripStatusLabel2, lblUpdatedAtPlaceHolder, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 396);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(791, 22);
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(634, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblDateEntry
            // 
            lblDateEntry.Name = "lblDateEntry";
            lblDateEntry.Size = new System.Drawing.Size(0, 17);
            // 
            // lblCreatedAtPlaceHolder
            // 
            lblCreatedAtPlaceHolder.Name = "lblCreatedAtPlaceHolder";
            lblCreatedAtPlaceHolder.Size = new System.Drawing.Size(64, 17);
            lblCreatedAtPlaceHolder.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel2.Text = "|";
            toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUpdatedAtPlaceHolder
            // 
            lblUpdatedAtPlaceHolder.Name = "lblUpdatedAtPlaceHolder";
            lblUpdatedAtPlaceHolder.Size = new System.Drawing.Size(68, 17);
            lblUpdatedAtPlaceHolder.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // frmOtherPaymentRates
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(791, 418);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip2);
            Name = "frmOtherPaymentRates";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Other Payment Rates";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgOtherPaymentRates).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgOtherPaymentRates;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblDateEntry;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAtPlaceHolder;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
    }
}