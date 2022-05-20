
namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    partial class frmCollectorsRCDLoad
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectCollections = new System.Windows.Forms.Button();
            this.txtCollectionsCount = new System.Windows.Forms.TextBox();
            this.dtfrom = new System.Windows.Forms.MonthCalendar();
            this.dtto = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCollectionsFrom = new System.Windows.Forms.Label();
            this.lblCollectionsTo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "To ";
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Location = new System.Drawing.Point(394, 189);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoad.Size = new System.Drawing.Size(74, 22);
            this.btnLoad.TabIndex = 35;
            this.btnLoad.Text = "Fetch";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "From";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnSelectCollections);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 218);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 27);
            this.flowLayoutPanel1.TabIndex = 38;
            // 
            // btnSelectCollections
            // 
            this.btnSelectCollections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectCollections.Enabled = false;
            this.btnSelectCollections.Location = new System.Drawing.Point(389, 2);
            this.btnSelectCollections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectCollections.Name = "btnSelectCollections";
            this.btnSelectCollections.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectCollections.Size = new System.Drawing.Size(84, 22);
            this.btnSelectCollections.TabIndex = 1;
            this.btnSelectCollections.Text = "Ok";
            this.btnSelectCollections.UseVisualStyleBackColor = true;
            this.btnSelectCollections.Click += new System.EventHandler(this.btnSelectCollections_Click);
            // 
            // txtCollectionsCount
            // 
            this.txtCollectionsCount.Location = new System.Drawing.Point(241, 188);
            this.txtCollectionsCount.Name = "txtCollectionsCount";
            this.txtCollectionsCount.ReadOnly = true;
            this.txtCollectionsCount.Size = new System.Drawing.Size(142, 23);
            this.txtCollectionsCount.TabIndex = 39;
            // 
            // dtfrom
            // 
            this.dtfrom.BackColor = System.Drawing.SystemColors.Control;
            this.dtfrom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtfrom.Location = new System.Drawing.Point(9, 20);
            this.dtfrom.MaxSelectionCount = 1;
            this.dtfrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.ShowToday = false;
            this.dtfrom.ShowTodayCircle = false;
            this.dtfrom.TabIndex = 42;
            this.dtfrom.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dtfrom_DateChanged);
            // 
            // dtto
            // 
            this.dtto.BackColor = System.Drawing.SystemColors.Control;
            this.dtto.Location = new System.Drawing.Point(241, 20);
            this.dtto.MaxSelectionCount = 1;
            this.dtto.Name = "dtto";
            this.dtto.ShowToday = false;
            this.dtto.ShowTodayCircle = false;
            this.dtto.TabIndex = 43;
            this.dtto.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dtto_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "Total Records of Collection Loaded";
            // 
            // lblCollectionsFrom
            // 
            this.lblCollectionsFrom.AutoSize = true;
            this.lblCollectionsFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCollectionsFrom.Location = new System.Drawing.Point(45, 4);
            this.lblCollectionsFrom.Name = "lblCollectionsFrom";
            this.lblCollectionsFrom.Size = new System.Drawing.Size(52, 15);
            this.lblCollectionsFrom.TabIndex = 45;
            this.lblCollectionsFrom.Text = "<From>";
            // 
            // lblCollectionsTo
            // 
            this.lblCollectionsTo.AutoSize = true;
            this.lblCollectionsTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCollectionsTo.Location = new System.Drawing.Point(259, 4);
            this.lblCollectionsTo.Name = "lblCollectionsTo";
            this.lblCollectionsTo.Size = new System.Drawing.Size(36, 15);
            this.lblCollectionsTo.TabIndex = 45;
            this.lblCollectionsTo.Text = "<To>";
            // 
            // frmCollectorsRCDLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 245);
            this.Controls.Add(this.lblCollectionsTo);
            this.Controls.Add(this.lblCollectionsFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.txtCollectionsCount);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCollectorsRCDLoad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Collections";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelectCollections;
        private System.Windows.Forms.TextBox txtCollectionsCount;
        private System.Windows.Forms.MonthCalendar dtto;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.MonthCalendar dtfrom;
        private System.Windows.Forms.Label lblCollectionsFrom;
        private System.Windows.Forms.Label lblCollectionsTo;
    }
}