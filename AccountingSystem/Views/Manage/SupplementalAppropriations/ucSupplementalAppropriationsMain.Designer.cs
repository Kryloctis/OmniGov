
namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    partial class ucSupplementalAppropriationsMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalSupplemental = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtAllotmentClass = new System.Windows.Forms.TextBox();
            this.txtFund = new System.Windows.Forms.TextBox();
            this.txtFPP = new System.Windows.Forms.TextBox();
            this.chckbxContinuing = new System.Windows.Forms.CheckBox();
            this.dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.cmbxSubFPP = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(4, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(463, 233);
            this.dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total";
            // 
            // txtTotalSupplemental
            // 
            this.txtTotalSupplemental.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalSupplemental.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSupplemental.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTotalSupplemental.Location = new System.Drawing.Point(41, 502);
            this.txtTotalSupplemental.Name = "txtTotalSupplemental";
            this.txtTotalSupplemental.Size = new System.Drawing.Size(151, 23);
            this.txtTotalSupplemental.TabIndex = 37;
            this.txtTotalSupplemental.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 67;
            this.label9.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(99, 209);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(368, 23);
            this.txtRemarks.TabIndex = 66;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(99, 35);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(368, 23);
            this.txtYear.TabIndex = 65;
            // 
            // txtAllotmentClass
            // 
            this.txtAllotmentClass.Location = new System.Drawing.Point(99, 151);
            this.txtAllotmentClass.Name = "txtAllotmentClass";
            this.txtAllotmentClass.ReadOnly = true;
            this.txtAllotmentClass.Size = new System.Drawing.Size(368, 23);
            this.txtAllotmentClass.TabIndex = 64;
            // 
            // txtFund
            // 
            this.txtFund.Location = new System.Drawing.Point(99, 64);
            this.txtFund.Name = "txtFund";
            this.txtFund.ReadOnly = true;
            this.txtFund.Size = new System.Drawing.Size(368, 23);
            this.txtFund.TabIndex = 63;
            // 
            // txtFPP
            // 
            this.txtFPP.Location = new System.Drawing.Point(99, 93);
            this.txtFPP.Name = "txtFPP";
            this.txtFPP.ReadOnly = true;
            this.txtFPP.Size = new System.Drawing.Size(368, 23);
            this.txtFPP.TabIndex = 62;
            // 
            // chckbxContinuing
            // 
            this.chckbxContinuing.AutoSize = true;
            this.chckbxContinuing.Location = new System.Drawing.Point(304, 238);
            this.chckbxContinuing.Name = "chckbxContinuing";
            this.chckbxContinuing.Size = new System.Drawing.Size(163, 19);
            this.chckbxContinuing.TabIndex = 61;
            this.chckbxContinuing.Text = "Continuing Appropriation";
            this.chckbxContinuing.UseVisualStyleBackColor = true;
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Location = new System.Drawing.Point(99, 6);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(368, 23);
            this.dtpDateEntry.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 52;
            this.label6.Text = "Date Entry";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Account";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 57;
            this.label7.Text = "Allotment Class";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 56;
            this.label8.Text = "Year";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 55;
            this.label10.Text = "Sub FPP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 54;
            this.label11.Text = "Type of Fund";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = "FPP";
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.IntegralHeight = false;
            this.cmbxAccount.Location = new System.Drawing.Point(99, 180);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(368, 23);
            this.cmbxAccount.TabIndex = 60;
            // 
            // cmbxSubFPP
            // 
            this.cmbxSubFPP.FormattingEnabled = true;
            this.cmbxSubFPP.Location = new System.Drawing.Point(99, 122);
            this.cmbxSubFPP.Name = "cmbxSubFPP";
            this.cmbxSubFPP.Size = new System.Drawing.Size(368, 23);
            this.cmbxSubFPP.TabIndex = 59;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 502);
            this.btnAdd.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 68;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(311, 502);
            this.btnEdit.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(392, 502);
            this.btnDelete.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // ucSupplementalAppropriationsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtAllotmentClass);
            this.Controls.Add(this.txtFund);
            this.Controls.Add(this.txtFPP);
            this.Controls.Add(this.chckbxContinuing);
            this.Controls.Add(this.dtpDateEntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.cmbxSubFPP);
            this.Controls.Add(this.txtTotalSupplemental);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucSupplementalAppropriationsMain";
            this.Size = new System.Drawing.Size(485, 528);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.TextBox txtYear;
        internal System.Windows.Forms.TextBox txtAllotmentClass;
        internal System.Windows.Forms.TextBox txtFund;
        internal System.Windows.Forms.TextBox txtFPP;
        internal System.Windows.Forms.CheckBox chckbxContinuing;
        internal System.Windows.Forms.DateTimePicker dtpDateEntry;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        internal System.Windows.Forms.ComboBox cmbxSubFPP;
        internal System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.TextBox txtTotalSupplemental;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnAdd;
    }
}
