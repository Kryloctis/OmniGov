
namespace AccountingSystem.Views.Reports.RCD
{
    partial class frmGenerateRCD
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
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPreview = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPreview)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "";
            this.dtfrom.Location = new System.Drawing.Point(63, 8);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(226, 23);
            this.dtfrom.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "From";
            // 
            // dgPreview
            // 
            this.dgPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPreview.Location = new System.Drawing.Point(10, 36);
            this.dgPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPreview.Name = "dgPreview";
            this.dgPreview.RowHeadersWidth = 51;
            this.dgPreview.RowTemplate.Height = 29;
            this.dgPreview.Size = new System.Drawing.Size(758, 346);
            this.dgPreview.TabIndex = 25;
            this.dgPreview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPreview_CellContentClick);
            this.dgPreview.SelectionChanged += new System.EventHandler(this.dgPreview_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Total";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnGenerate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 416);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(779, 27);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(692, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(602, 2);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGenerate.Size = new System.Drawing.Size(84, 22);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Ok";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.Location = new System.Drawing.Point(670, 8);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPreview.Size = new System.Drawing.Size(97, 22);
            this.btnPreview.TabIndex = 30;
            this.btnPreview.Text = "Load";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "To ";
            // 
            // dtto
            // 
            this.dtto.Location = new System.Drawing.Point(370, 8);
            this.dtto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(226, 23);
            this.dtto.TabIndex = 32;
            // 
            // txttotalamount
            // 
            this.txttotalamount.Location = new System.Drawing.Point(63, 386);
            this.txttotalamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.ReadOnly = true;
            this.txttotalamount.Size = new System.Drawing.Size(215, 23);
            this.txttotalamount.TabIndex = 34;
            this.txttotalamount.Text = "0.00";
            this.txttotalamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmGenerateRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 443);
            this.Controls.Add(this.txttotalamount);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgPreview);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateRCD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Collection";
            this.Load += new System.EventHandler(this.frmGenerateRCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPreview)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Button btnCancel;
    }
}