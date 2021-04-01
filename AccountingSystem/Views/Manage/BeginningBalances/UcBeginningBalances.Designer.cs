
namespace AccountingSystem.Views.Manage.BeginningBalances
{
    partial class UcBeginningBalances
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
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubsidiaryAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneralAccount = new System.Windows.Forms.TextBox();
            this.lstBoxGeneralAccount = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.epGeneralAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSubsidiaryAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupFunds = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubsidiaryAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.groupFunds.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(115, 264);
            this.nudYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(370, 23);
            this.nudYear.TabIndex = 3;
            this.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.nudYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudYear_Validating);
            this.nudYear.Validated += new System.EventHandler(this.nudYear_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Year";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(115, 293);
            this.nudAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(370, 23);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount";
            // 
            // cmbSubsidiaryAccount
            // 
            this.cmbSubsidiaryAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubsidiaryAccount.FormattingEnabled = true;
            this.cmbSubsidiaryAccount.Location = new System.Drawing.Point(115, 235);
            this.cmbSubsidiaryAccount.Name = "cmbSubsidiaryAccount";
            this.cmbSubsidiaryAccount.Size = new System.Drawing.Size(370, 23);
            this.cmbSubsidiaryAccount.TabIndex = 2;
            this.cmbSubsidiaryAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubsidiaryAccount_Validating);
            this.cmbSubsidiaryAccount.Validated += new System.EventHandler(this.cmbSubsidiaryAccount_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Subsidiary Account";
            // 
            // txtGeneralAccount
            // 
            this.txtGeneralAccount.Location = new System.Drawing.Point(0, 88);
            this.txtGeneralAccount.Name = "txtGeneralAccount";
            this.txtGeneralAccount.Size = new System.Drawing.Size(485, 23);
            this.txtGeneralAccount.TabIndex = 0;
            this.txtGeneralAccount.TextChanged += new System.EventHandler(this.txtGeneralAccount_TextChanged);
            // 
            // lstBoxGeneralAccount
            // 
            this.lstBoxGeneralAccount.FormattingEnabled = true;
            this.lstBoxGeneralAccount.ItemHeight = 15;
            this.lstBoxGeneralAccount.Location = new System.Drawing.Point(0, 117);
            this.lstBoxGeneralAccount.Name = "lstBoxGeneralAccount";
            this.lstBoxGeneralAccount.Size = new System.Drawing.Size(485, 109);
            this.lstBoxGeneralAccount.TabIndex = 1;
            this.lstBoxGeneralAccount.SelectedValueChanged += new System.EventHandler(this.lstBoxGeneralAccount_SelectedValueChanged);
            this.lstBoxGeneralAccount.Validating += new System.ComponentModel.CancelEventHandler(this.lstBoxGeneralAccount_Validating);
            this.lstBoxGeneralAccount.Validated += new System.EventHandler(this.lstBoxGeneralAccount_Validated);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(3, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(370, 79);
            this.listBox2.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(370, 23);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "General Ledger Account:";
            // 
            // epGeneralAccount
            // 
            this.epGeneralAccount.ContainerControl = this;
            // 
            // epSubsidiaryAccount
            // 
            this.epSubsidiaryAccount.ContainerControl = this;
            // 
            // epYear
            // 
            this.epYear.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // groupFunds
            // 
            this.groupFunds.AutoSize = true;
            this.groupFunds.Controls.Add(this.flowLayoutPanelFunds);
            this.groupFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupFunds.Location = new System.Drawing.Point(0, 0);
            this.groupFunds.Name = "groupFunds";
            this.groupFunds.Size = new System.Drawing.Size(485, 61);
            this.groupFunds.TabIndex = 13;
            this.groupFunds.TabStop = false;
            this.groupFunds.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.AutoSize = true;
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(479, 39);
            this.flowLayoutPanelFunds.TabIndex = 0;
            // 
            // UcBeginningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupFunds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBoxGeneralAccount);
            this.Controls.Add(this.txtGeneralAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSubsidiaryAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudYear);
            this.Name = "UcBeginningBalances";
            this.Size = new System.Drawing.Size(515, 350);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubsidiaryAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.groupFunds.ResumeLayout(false);
            this.groupFunds.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider epGeneralAccount;
        private System.Windows.Forms.ErrorProvider epSubsidiaryAccount;
        private System.Windows.Forms.ErrorProvider epYear;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.GroupBox groupFunds;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.NumericUpDown nudYear;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.ComboBox cmbSubsidiaryAccount;
        internal System.Windows.Forms.TextBox txtGeneralAccount;
        internal System.Windows.Forms.ListBox lstBoxGeneralAccount;
    }
}
