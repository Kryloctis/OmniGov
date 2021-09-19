
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.dgBudgetRealignment = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Appropriation";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(133, 8);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(375, 23);
            this.txtYear.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Realign to ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Amount ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Remarks ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 127);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(375, 46);
            this.textBox2.TabIndex = 19;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(134, 66);
            this.nudAmount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(375, 23);
            this.nudAmount.TabIndex = 20;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.IntegralHeight = false;
            this.cmbxAccount.Location = new System.Drawing.Point(134, 37);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(375, 23);
            this.cmbxAccount.TabIndex = 21;
            // 
            // dgBudgetRealignment
            // 
            this.dgBudgetRealignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetRealignment.Location = new System.Drawing.Point(5, 208);
            this.dgBudgetRealignment.Name = "dgBudgetRealignment";
            this.dgBudgetRealignment.RowTemplate.Height = 25;
            this.dgBudgetRealignment.Size = new System.Drawing.Size(505, 181);
            this.dgBudgetRealignment.TabIndex = 22;
            this.dgBudgetRealignment.Tag = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(434, 179);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(134, 95);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(375, 23);
            this.dtDateIssued.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Date Issued";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(435, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "Remove...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Edit...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ucRealignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtDateIssued);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgBudgetRealignment);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label1);
            this.Name = "ucRealignment";
            this.Size = new System.Drawing.Size(534, 421);
            this.Load += new System.EventHandler(this.ucRealignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        internal System.Windows.Forms.DataGridView dgBudgetRealignment;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button1;
    }
}
