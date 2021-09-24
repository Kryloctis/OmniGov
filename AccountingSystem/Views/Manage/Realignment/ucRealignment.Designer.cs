
namespace AccountingSystem.Views.Manage.Realignment
{
    partial class ucRealignment
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
            this.dgBudgetRealignment = new System.Windows.Forms.DataGridView();
            this.budgetAppropriationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realignmentAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realignmentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAllotmentClass = new System.Windows.Forms.ComboBox();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.cmbFunds = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbOthersFPP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBudgetRealignment
            // 
            this.dgBudgetRealignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetRealignment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.budgetAppropriationId,
            this.realignmentAccount,
            this.realignmentAmount});
            this.dgBudgetRealignment.Location = new System.Drawing.Point(13, 325);
            this.dgBudgetRealignment.Name = "dgBudgetRealignment";
            this.dgBudgetRealignment.RowTemplate.Height = 25;
            this.dgBudgetRealignment.Size = new System.Drawing.Size(505, 103);
            this.dgBudgetRealignment.TabIndex = 22;
            this.dgBudgetRealignment.Tag = "";
            // 
            // budgetAppropriationId
            // 
            this.budgetAppropriationId.HeaderText = "BudgetId";
            this.budgetAppropriationId.Name = "budgetAppropriationId";
            this.budgetAppropriationId.Visible = false;
            // 
            // realignmentAccount
            // 
            this.realignmentAccount.HeaderText = "Account";
            this.realignmentAccount.Name = "realignmentAccount";
            this.realignmentAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.realignmentAccount.Width = 300;
            // 
            // realignmentAmount
            // 
            this.realignmentAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.realignmentAmount.HeaderText = "Amount";
            this.realignmentAmount.Name = "realignmentAmount";
            this.realignmentAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.realignmentAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(442, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(105, 243);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(409, 23);
            this.dtDateIssued.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Date Issued";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(76, 463);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(442, 46);
            this.txtRemarks.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 466);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Remarks ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAllotmentClass);
            this.groupBox1.Controls.Add(this.cmbFPP);
            this.groupBox1.Controls.Add(this.cmbFunds);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.nudAmount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbAccount);
            this.groupBox1.Controls.Add(this.dtDateIssued);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbOthersFPP);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 276);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Realign to ";
            // 
            // cmbAllotmentClass
            // 
            this.cmbAllotmentClass.FormattingEnabled = true;
            this.cmbAllotmentClass.Location = new System.Drawing.Point(105, 156);
            this.cmbAllotmentClass.Name = "cmbAllotmentClass";
            this.cmbAllotmentClass.Size = new System.Drawing.Size(410, 23);
            this.cmbAllotmentClass.TabIndex = 48;
            this.cmbAllotmentClass.DropDownClosed += new System.EventHandler(this.cmbAllotmentClass_DropDownClosed);
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(105, 98);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(410, 23);
            this.cmbFPP.TabIndex = 47;
            this.cmbFPP.DropDownClosed += new System.EventHandler(this.cmbFPP_DropDownClosed);
            // 
            // cmbFunds
            // 
            this.cmbFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbFunds.FormattingEnabled = true;
            this.cmbFunds.Location = new System.Drawing.Point(105, 69);
            this.cmbFunds.Name = "cmbFunds";
            this.cmbFunds.Size = new System.Drawing.Size(409, 23);
            this.cmbFunds.TabIndex = 46;
            this.cmbFunds.DropDownClosed += new System.EventHandler(this.cmbFunds_DropDownClosed);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Location = new System.Drawing.Point(137, 22);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(375, 23);
            this.numericUpDown2.TabIndex = 45;
            this.numericUpDown2.ThousandsSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 15);
            this.label13.TabIndex = 44;
            this.label13.Text = "Appropriation Balance ";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(105, 214);
            this.nudAmount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(409, 23);
            this.nudAmount.TabIndex = 23;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Account";
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.IntegralHeight = false;
            this.cmbAccount.Location = new System.Drawing.Point(105, 185);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(409, 23);
            this.cmbAccount.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Allotment Class";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Sub FPP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Type of Fund";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "FPP";
            // 
            // cmbOthersFPP
            // 
            this.cmbOthersFPP.FormattingEnabled = true;
            this.cmbOthersFPP.Location = new System.Drawing.Point(105, 127);
            this.cmbOthersFPP.Name = "cmbOthersFPP";
            this.cmbOthersFPP.Size = new System.Drawing.Size(410, 23);
            this.cmbOthersFPP.TabIndex = 16;
            this.cmbOthersFPP.DropDownClosed += new System.EventHandler(this.cmbOthersFPP_DropDownClosed);
            // 
            // ucRealignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgBudgetRealignment);
            this.Name = "ucRealignment";
            this.Size = new System.Drawing.Size(544, 523);
            this.Load += new System.EventHandler(this.ucRealignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DataGridView dgBudgetRealignment;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn budgetAppropriationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn realignmentAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn realignmentAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cmbOthersFPP;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbFunds;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.ComboBox cmbAllotmentClass;
    }
}
