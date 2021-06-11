
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
            this.txttotal = new System.Windows.Forms.NumericUpDown();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttotal)).BeginInit();
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
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 635);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total :";
            // 
            // txttotal
            // 
            this.txttotal.DecimalPlaces = 2;
            this.txttotal.Location = new System.Drawing.Point(729, 633);
            this.txttotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(289, 27);
            this.txttotal.TabIndex = 7;
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnadd
            // 
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Enabled = false;
            this.btnadd.Image = global::AccountingSystem.Properties.Resources.rcd1;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(690, 86);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(161, 29);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Add Payments";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclear
            // 
            this.btnclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclear.Enabled = false;
            this.btnclear.Image = global::AccountingSystem.Properties.Resources.remove;
            this.btnclear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclear.Location = new System.Drawing.Point(857, 86);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(161, 29);
            this.btnclear.TabIndex = 9;
            this.btnclear.Text = "Clear Payments";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // ucRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txttotal);
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
            ((System.ComponentModel.ISupportInitialize)(this.txttotal)).EndInit();
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
        internal System.Windows.Forms.NumericUpDown txttotal;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox chckapproved;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.DataGridView dgvpayments;
        internal System.Windows.Forms.Button btnclear;
    }
}
