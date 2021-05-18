
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class ucObligationRequest
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mskTxtTemplate = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtSeriesNo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtDateRequest = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAllotmentReleaseBalance = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.epExplanation = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationSeriesNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epReferenceNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationSeriesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date of Request";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Payee";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(96, 150);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(469, 23);
            this.txtPayee.TabIndex = 10;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayee_Validated);
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(96, 179);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(469, 39);
            this.txtExplanation.TabIndex = 11;
            this.txtExplanation.Validating += new System.ComponentModel.CancelEventHandler(this.txtExplanation_Validating);
            this.txtExplanation.Validated += new System.EventHandler(this.txtExplanation_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Explanation";
            // 
            // mskTxtTemplate
            // 
            this.mskTxtTemplate.Location = new System.Drawing.Point(149, 92);
            this.mskTxtTemplate.Mask = "00-00-000";
            this.mskTxtTemplate.Name = "mskTxtTemplate";
            this.mskTxtTemplate.ReadOnly = true;
            this.mskTxtTemplate.Size = new System.Drawing.Size(64, 23);
            this.mskTxtTemplate.TabIndex = 4;
            this.mskTxtTemplate.Text = "0000000";
            this.mskTxtTemplate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mskTxtSeriesNo
            // 
            this.mskTxtSeriesNo.Location = new System.Drawing.Point(96, 92);
            this.mskTxtSeriesNo.Mask = "0000";
            this.mskTxtSeriesNo.Name = "mskTxtSeriesNo";
            this.mskTxtSeriesNo.Size = new System.Drawing.Size(35, 23);
            this.mskTxtSeriesNo.TabIndex = 3;
            this.mskTxtSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTxtSeriesNo.Validating += new System.ComponentModel.CancelEventHandler(this.mskTxtSeriesNo_Validating);
            this.mskTxtSeriesNo.Validated += new System.EventHandler(this.mskTxtSeriesNo_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Obligation No.";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(96, 121);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(469, 23);
            this.txtReferenceNo.TabIndex = 9;
            this.txtReferenceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferenceNo_Validating);
            this.txtReferenceNo.Validated += new System.EventHandler(this.txtReferenceNo_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Reference No.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "-";
            // 
            // dtDateRequest
            // 
            this.dtDateRequest.Location = new System.Drawing.Point(346, 92);
            this.dtDateRequest.Name = "dtDateRequest";
            this.dtDateRequest.Size = new System.Drawing.Size(219, 23);
            this.dtDateRequest.TabIndex = 5;
            this.dtDateRequest.ValueChanged += new System.EventHandler(this.dtDateRequest_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Account";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Balance";
            // 
            // txtAllotmentReleaseBalance
            // 
            this.txtAllotmentReleaseBalance.Location = new System.Drawing.Point(93, 32);
            this.txtAllotmentReleaseBalance.Name = "txtAllotmentReleaseBalance";
            this.txtAllotmentReleaseBalance.ReadOnly = true;
            this.txtAllotmentReleaseBalance.Size = new System.Drawing.Size(460, 23);
            this.txtAllotmentReleaseBalance.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(0, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(565, 82);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Allotment Release Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAccountName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtAllotmentReleaseBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 60);
            this.panel1.TabIndex = 0;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(93, 3);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(460, 23);
            this.txtAccountName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(96, 224);
            this.nudAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(469, 23);
            this.nudAmount.TabIndex = 12;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // epExplanation
            // 
            this.epExplanation.ContainerControl = this;
            // 
            // epObligationSeriesNo
            // 
            this.epObligationSeriesNo.ContainerControl = this;
            // 
            // epReferenceNo
            // 
            this.epReferenceNo.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtDateRequest);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mskTxtSeriesNo);
            this.Controls.Add(this.mskTxtTemplate);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(586, 253);
            this.Load += new System.EventHandler(this.ucObligationRequest_Load);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationSeriesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.TextBox txtAllotmentReleaseBalance;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.DateTimePicker dtDateRequest;
        internal System.Windows.Forms.MaskedTextBox mskTxtTemplate;
        internal System.Windows.Forms.MaskedTextBox mskTxtSeriesNo;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.ErrorProvider epPayee;
        internal System.Windows.Forms.ErrorProvider epExplanation;
        internal System.Windows.Forms.ErrorProvider epObligationSeriesNo;
        internal System.Windows.Forms.ErrorProvider epReferenceNo;
        internal System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.TextBox txtAccountName;
    }
}
