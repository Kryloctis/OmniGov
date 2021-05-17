
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class ucObligationRequestMain
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
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAllotment = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.dgObligationRequests = new System.Windows.Forms.DataGridView();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOthersFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.cmbxMonths = new System.Windows.Forms.ComboBox();
            this.btnLoadRecords = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTotalObligation = new System.Windows.Forms.TextBox();
            this.lblTotalObligation = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPP";
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(105, 2);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(653, 23);
            this.cmbxFPP.TabIndex = 0;
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Other FPP";
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(105, 31);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(653, 23);
            this.cmbxOthersFPP.TabIndex = 1;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(6, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(746, 33);
            this.flowLayoutPanelFunds.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelAllotment);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(6, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(752, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allotment";
            // 
            // flowLayoutPanelAllotment
            // 
            this.flowLayoutPanelAllotment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAllotment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelAllotment.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelAllotment.Name = "flowLayoutPanelAllotment";
            this.flowLayoutPanelAllotment.Size = new System.Drawing.Size(746, 33);
            this.flowLayoutPanelAllotment.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Account";
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(105, 182);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(653, 23);
            this.cmbxAccount.TabIndex = 4;
            this.cmbxAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxAccount_KeyDown);
            this.cmbxAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccount_Validating);
            this.cmbxAccount.Validated += new System.EventHandler(this.cmbxAccount_Validated);
            // 
            // dgObligationRequests
            // 
            this.dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationRequests.Location = new System.Drawing.Point(9, 286);
            this.dgObligationRequests.Name = "dgObligationRequests";
            this.dgObligationRequests.RowTemplate.Height = 25;
            this.dgObligationRequests.Size = new System.Drawing.Size(749, 257);
            this.dgObligationRequests.TabIndex = 8;
            this.dgObligationRequests.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgObligationRequests_ColumnAdded);
            this.dgObligationRequests.SelectionChanged += new System.EventHandler(this.dgObligationRequests_SelectionChanged);
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOthersFPP
            // 
            this.epOthersFPP.ContainerControl = this;
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Year";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(513, 211);
            this.nudYear.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1971,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(245, 23);
            this.nudYear.TabIndex = 6;
            this.nudYear.Value = new decimal(new int[] {
            1971,
            0,
            0,
            0});
            // 
            // cmbxMonths
            // 
            this.cmbxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMonths.FormattingEnabled = true;
            this.cmbxMonths.Location = new System.Drawing.Point(105, 211);
            this.cmbxMonths.Name = "cmbxMonths";
            this.cmbxMonths.Size = new System.Drawing.Size(218, 23);
            this.cmbxMonths.TabIndex = 5;
            // 
            // btnLoadRecords
            // 
            this.btnLoadRecords.Location = new System.Drawing.Point(652, 257);
            this.btnLoadRecords.Name = "btnLoadRecords";
            this.btnLoadRecords.Size = new System.Drawing.Size(106, 23);
            this.btnLoadRecords.TabIndex = 7;
            this.btnLoadRecords.Text = "Load Records";
            this.btnLoadRecords.UseVisualStyleBackColor = true;
            this.btnLoadRecords.Click += new System.EventHandler(this.btnLoadRecords_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtTotalObligation);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalObligation);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 549);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(749, 27);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // txtTotalObligation
            // 
            this.txtTotalObligation.Location = new System.Drawing.Point(504, 3);
            this.txtTotalObligation.Name = "txtTotalObligation";
            this.txtTotalObligation.ReadOnly = true;
            this.txtTotalObligation.Size = new System.Drawing.Size(242, 23);
            this.txtTotalObligation.TabIndex = 11;
            this.txtTotalObligation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalObligation
            // 
            this.lblTotalObligation.AutoSize = true;
            this.lblTotalObligation.Location = new System.Drawing.Point(407, 6);
            this.lblTotalObligation.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTotalObligation.Name = "lblTotalObligation";
            this.lblTotalObligation.Size = new System.Drawing.Size(91, 15);
            this.lblTotalObligation.TabIndex = 12;
            this.lblTotalObligation.Text = "Total Obligation";
            // 
            // ucObligationRequestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnLoadRecords);
            this.Controls.Add(this.cmbxMonths);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgObligationRequests);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucObligationRequestMain";
            this.Size = new System.Drawing.Size(780, 576);
            this.Load += new System.EventHandler(this.ucObligationRequestMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbBoxOthersFPP;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotment;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.DataGridView dgObligationRequests;
        internal System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.ErrorProvider epOthersFPP;
        internal System.Windows.Forms.ErrorProvider epAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbxMonths;
        internal System.Windows.Forms.Button btnLoadRecords;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Label lblTotalObligation;
        internal System.Windows.Forms.TextBox txtTotalObligation;
        internal System.Windows.Forms.NumericUpDown nudYear;
    }
}
