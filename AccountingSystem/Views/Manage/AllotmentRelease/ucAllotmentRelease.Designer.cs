
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class ucAllotmentRelease
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
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFPP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFPPCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOtherFPP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblGenLedgerAcc = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAllotmentClass = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSelectBudgetAppropriation = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAllotmentReleaseNo = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epBudgetAppropriations = new System.Windows.Forms.ErrorProvider(this.components);
            this.epARONo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPurpose = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDateIssued = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARO No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date Issued";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.lblSelectBudgetAppropriation);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.epBudgetAppropriations.SetIconAlignment(this.groupBox1, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 205);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Budget Appropriation Details";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(517, 183);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFPP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblFPPCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 39);
            this.panel1.TabIndex = 0;
            // 
            // lblFPP
            // 
            this.lblFPP.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFPP.Location = new System.Drawing.Point(143, 21);
            this.lblFPP.Margin = new System.Windows.Forms.Padding(3);
            this.lblFPP.Name = "lblFPP";
            this.lblFPP.Size = new System.Drawing.Size(368, 15);
            this.lblFPP.TabIndex = 3;
            this.lblFPP.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "FPP:";
            // 
            // lblFPPCode
            // 
            this.lblFPPCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFPPCode.Location = new System.Drawing.Point(143, 0);
            this.lblFPPCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblFPPCode.Name = "lblFPPCode";
            this.lblFPPCode.Size = new System.Drawing.Size(368, 15);
            this.lblFPPCode.TabIndex = 1;
            this.lblFPPCode.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "FPP Code:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOtherFPP);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(3, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 19);
            this.panel2.TabIndex = 1;
            // 
            // lblOtherFPP
            // 
            this.lblOtherFPP.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOtherFPP.Location = new System.Drawing.Point(143, 0);
            this.lblOtherFPP.Margin = new System.Windows.Forms.Padding(3);
            this.lblOtherFPP.Name = "lblOtherFPP";
            this.lblOtherFPP.Size = new System.Drawing.Size(368, 15);
            this.lblOtherFPP.TabIndex = 1;
            this.lblOtherFPP.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Other FPP:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAmount);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblAccountCode);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.lblYear);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lblGenLedgerAcc);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lblAllotmentClass);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(3, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(505, 107);
            this.panel3.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount.Location = new System.Drawing.Point(143, 84);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(368, 15);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "-";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(0, 84);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 15);
            this.label21.TabIndex = 8;
            this.label21.Text = "Amount:";
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccountCode.Location = new System.Drawing.Point(143, 0);
            this.lblAccountCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(368, 15);
            this.lblAccountCode.TabIndex = 7;
            this.lblAccountCode.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "Account Code:";
            // 
            // lblYear
            // 
            this.lblYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYear.Location = new System.Drawing.Point(143, 63);
            this.lblYear.Margin = new System.Windows.Forms.Padding(3);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(368, 15);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 63);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "Year:";
            // 
            // lblGenLedgerAcc
            // 
            this.lblGenLedgerAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGenLedgerAcc.Location = new System.Drawing.Point(143, 42);
            this.lblGenLedgerAcc.Margin = new System.Windows.Forms.Padding(3);
            this.lblGenLedgerAcc.Name = "lblGenLedgerAcc";
            this.lblGenLedgerAcc.Size = new System.Drawing.Size(368, 15);
            this.lblGenLedgerAcc.TabIndex = 3;
            this.lblGenLedgerAcc.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "General Ledger Account:";
            // 
            // lblAllotmentClass
            // 
            this.lblAllotmentClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAllotmentClass.Location = new System.Drawing.Point(143, 21);
            this.lblAllotmentClass.Margin = new System.Windows.Forms.Padding(3);
            this.lblAllotmentClass.Name = "lblAllotmentClass";
            this.lblAllotmentClass.Size = new System.Drawing.Size(368, 15);
            this.lblAllotmentClass.TabIndex = 1;
            this.lblAllotmentClass.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(0, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Allotment Class:";
            // 
            // lblSelectBudgetAppropriation
            // 
            this.lblSelectBudgetAppropriation.AutoSize = true;
            this.lblSelectBudgetAppropriation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectBudgetAppropriation.Location = new System.Drawing.Point(361, 0);
            this.lblSelectBudgetAppropriation.Name = "lblSelectBudgetAppropriation";
            this.lblSelectBudgetAppropriation.Size = new System.Drawing.Size(156, 15);
            this.lblSelectBudgetAppropriation.TabIndex = 0;
            this.lblSelectBudgetAppropriation.TabStop = true;
            this.lblSelectBudgetAppropriation.Text = "Select Budget Appropriation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "FPP";
            // 
            // txtAllotmentReleaseNo
            // 
            this.txtAllotmentReleaseNo.Location = new System.Drawing.Point(152, 211);
            this.txtAllotmentReleaseNo.Name = "txtAllotmentReleaseNo";
            this.txtAllotmentReleaseNo.Size = new System.Drawing.Size(374, 23);
            this.txtAllotmentReleaseNo.TabIndex = 2;
            this.txtAllotmentReleaseNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtAllotmentReleaseNo_Validating);
            this.txtAllotmentReleaseNo.Validated += new System.EventHandler(this.txtAllotmentReleaseNo_Validated);
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(152, 240);
            this.txtPurpose.MaxLength = 100000;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(374, 23);
            this.txtPurpose.TabIndex = 3;
            this.txtPurpose.Validating += new System.ComponentModel.CancelEventHandler(this.txtPurpose_Validating);
            this.txtPurpose.Validated += new System.EventHandler(this.txtPurpose_Validated);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(152, 269);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(374, 23);
            this.dtDateIssued.TabIndex = 4;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(152, 298);
            this.nudAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(374, 23);
            this.nudAmount.TabIndex = 5;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epBudgetAppropriations
            // 
            this.epBudgetAppropriations.ContainerControl = this;
            // 
            // epARONo
            // 
            this.epARONo.ContainerControl = this;
            // 
            // epPurpose
            // 
            this.epPurpose.ContainerControl = this;
            // 
            // epDateIssued
            // 
            this.epDateIssued.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // ucAllotmentRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.dtDateIssued);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.txtAllotmentReleaseNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAllotmentRelease";
            this.Size = new System.Drawing.Size(550, 324);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label lblFPP;
        internal System.Windows.Forms.Label lblOtherFPP;
        internal System.Windows.Forms.Label lblGenLedgerAcc;
        internal System.Windows.Forms.Label lblAllotmentClass;
        internal System.Windows.Forms.Label lblYear;
        internal System.Windows.Forms.Label lblFPPCode;
        internal System.Windows.Forms.Label lblAccountCode;
        internal System.Windows.Forms.Label lblAmount;
        internal System.Windows.Forms.TextBox txtAllotmentReleaseNo;
        internal System.Windows.Forms.TextBox txtPurpose;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.LinkLabel lblSelectBudgetAppropriation;
        private System.Windows.Forms.ErrorProvider epBudgetAppropriations;
        private System.Windows.Forms.ErrorProvider epARONo;
        private System.Windows.Forms.ErrorProvider epPurpose;
        private System.Windows.Forms.ErrorProvider epDateIssued;
        private System.Windows.Forms.ErrorProvider epAmount;
    }
}
