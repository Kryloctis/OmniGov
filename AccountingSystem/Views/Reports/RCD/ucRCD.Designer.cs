
namespace AccountingSystem.Views.Reports.RCD
{
    partial class ucRCD
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbcollector = new System.Windows.Forms.ComboBox();
            this.txtreport = new System.Windows.Forms.TextBox();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chckapproved = new System.Windows.Forms.CheckBox();
            this.dgvpayments = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.txttotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collector :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Report No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date :";
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(105, 16);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(407, 28);
            this.cmbcollector.TabIndex = 0;
            this.cmbcollector.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcollector_Validating);
            this.cmbcollector.Validated += new System.EventHandler(this.cmbcollector_Validated);
            // 
            // txtreport
            // 
            this.txtreport.Location = new System.Drawing.Point(105, 50);
            this.txtreport.MaxLength = 20;
            this.txtreport.Name = "txtreport";
            this.txtreport.Size = new System.Drawing.Size(407, 27);
            this.txtreport.TabIndex = 1;
            this.txtreport.Validating += new System.ComponentModel.CancelEventHandler(this.txtreport_Validating);
            this.txtreport.Validated += new System.EventHandler(this.txtreport_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Location = new System.Drawing.Point(105, 83);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(407, 27);
            this.dtdate.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chckapproved
            // 
            this.chckapproved.AutoSize = true;
            this.chckapproved.Location = new System.Drawing.Point(915, 15);
            this.chckapproved.Name = "chckapproved";
            this.chckapproved.Size = new System.Drawing.Size(97, 24);
            this.chckapproved.TabIndex = 4;
            this.chckapproved.Text = "Approved";
            this.chckapproved.UseVisualStyleBackColor = true;
            this.chckapproved.CheckedChanged += new System.EventHandler(this.chckapproved_CheckedChanged);
            // 
            // dgvpayments
            // 
            this.dgvpayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayments.Location = new System.Drawing.Point(11, 121);
            this.dgvpayments.Name = "dgvpayments";
            this.dgvpayments.RowHeadersWidth = 51;
            this.dgvpayments.RowTemplate.Height = 29;
            this.dgvpayments.Size = new System.Drawing.Size(1007, 506);
            this.dgvpayments.TabIndex = 5;
            this.dgvpayments.SelectionChanged += new System.EventHandler(this.dgvpayments_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(703, 635);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total :";
            // 
            // btnadd
            // 
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Image = global::AccountingSystem.Properties.Resources.rcd1;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnadd.Location = new System.Drawing.Point(759, 69);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(80, 46);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Add";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclear
            // 
            this.btnclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclear.Image = global::AccountingSystem.Properties.Resources.clear;
            this.btnclear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnclear.Location = new System.Drawing.Point(935, 69);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(84, 46);
            this.btnclear.TabIndex = 9;
            this.btnclear.Text = "Clear";
            this.btnclear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btndelete
            // 
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.Image = global::AccountingSystem.Properties.Resources.remove;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btndelete.Location = new System.Drawing.Point(845, 69);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(84, 46);
            this.btndelete.TabIndex = 10;
            this.btndelete.Text = "Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(758, 633);
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(261, 27);
            this.txttotal.TabIndex = 11;
            this.txttotal.Text = "0.00";
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ucRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvpayments);
            this.Controls.Add(this.chckapproved);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.txtreport);
            this.Controls.Add(this.cmbcollector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucRCD";
            this.Size = new System.Drawing.Size(1031, 670);
            this.Load += new System.EventHandler(this.ucRCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.ComboBox cmbcollector;
        internal System.Windows.Forms.TextBox txtreport;
        internal System.Windows.Forms.DateTimePicker dtdate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox chckapproved;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.DataGridView dgvpayments;
        internal System.Windows.Forms.Button btnclear;
        internal System.Windows.Forms.Button btndelete;
        internal System.Windows.Forms.TextBox txttotal;
    }
}
