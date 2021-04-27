
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
            this.dgObligationRequests = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAllotment = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDateRequested = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.mskObligationSeriesNo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mskTxtObligationNoTemplate = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOtherFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.epExplanation = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.epReferenceNo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOtherFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgObligationRequests
            // 
            this.dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationRequests.Location = new System.Drawing.Point(2, 302);
            this.dgObligationRequests.Name = "dgObligationRequests";
            this.dgObligationRequests.RowTemplate.Height = 25;
            this.dgObligationRequests.Size = new System.Drawing.Size(571, 185);
            this.dgObligationRequests.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(2, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fund";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(565, 31);
            this.flowLayoutPanelFunds.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelAllotment);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(2, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allotment";
            // 
            // flowLayoutPanelAllotment
            // 
            this.flowLayoutPanelAllotment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAllotment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelAllotment.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelAllotment.Name = "flowLayoutPanelAllotment";
            this.flowLayoutPanelAllotment.Size = new System.Drawing.Size(565, 31);
            this.flowLayoutPanelAllotment.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "FPP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Other FPP";
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(96, 0);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(477, 23);
            this.cmbxFPP.TabIndex = 0;
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(96, 29);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(477, 23);
            this.cmbxOthersFPP.TabIndex = 1;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Obligation No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date of Request";
            // 
            // dtDateRequested
            // 
            this.dtDateRequested.Location = new System.Drawing.Point(364, 173);
            this.dtDateRequested.Name = "dtDateRequested";
            this.dtDateRequested.Size = new System.Drawing.Size(209, 23);
            this.dtDateRequested.TabIndex = 7;
            this.dtDateRequested.ValueChanged += new System.EventHandler(this.dtDateRequested_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Payee";
            // 
            // mskObligationSeriesNo
            // 
            this.mskObligationSeriesNo.Location = new System.Drawing.Point(96, 173);
            this.mskObligationSeriesNo.Mask = "0000";
            this.mskObligationSeriesNo.Name = "mskObligationSeriesNo";
            this.mskObligationSeriesNo.Size = new System.Drawing.Size(33, 23);
            this.mskObligationSeriesNo.TabIndex = 6;
            this.mskObligationSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskObligationSeriesNo.Validating += new System.ComponentModel.CancelEventHandler(this.mskObligationSeriesNo_Validating);
            this.mskObligationSeriesNo.Validated += new System.EventHandler(this.mskObligationSeriesNo_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "-";
            // 
            // mskTxtObligationNoTemplate
            // 
            this.mskTxtObligationNoTemplate.Location = new System.Drawing.Point(147, 173);
            this.mskTxtObligationNoTemplate.Mask = "00-00-000";
            this.mskTxtObligationNoTemplate.Name = "mskTxtObligationNoTemplate";
            this.mskTxtObligationNoTemplate.ReadOnly = true;
            this.mskTxtObligationNoTemplate.Size = new System.Drawing.Size(72, 23);
            this.mskTxtObligationNoTemplate.TabIndex = 14;
            this.mskTxtObligationNoTemplate.Text = "0000000";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(417, 493);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(498, 493);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(96, 202);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(477, 23);
            this.txtPayee.TabIndex = 8;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayee_Validated);
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOtherFPP
            // 
            this.epOtherFPP.ContainerControl = this;
            // 
            // epObligationNo
            // 
            this.epObligationNo.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Explanation";
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(96, 231);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(477, 36);
            this.txtExplanation.TabIndex = 9;
            this.txtExplanation.Validating += new System.ComponentModel.CancelEventHandler(this.txtExplanation_Validating);
            this.txtExplanation.Validated += new System.EventHandler(this.txtExplanation_Validated);
            // 
            // epExplanation
            // 
            this.epExplanation.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Reference No.";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(96, 273);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(477, 23);
            this.txtReferenceNo.TabIndex = 10;
            this.txtReferenceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferenceNo_Validating);
            this.txtReferenceNo.Validated += new System.EventHandler(this.txtReferenceNo_Validated);
            // 
            // epReferenceNo
            // 
            this.epReferenceNo.ContainerControl = this;
            // 
            // ucObligationRequestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mskTxtObligationNoTemplate);
            this.Controls.Add(this.mskObligationSeriesNo);
            this.Controls.Add(this.dtDateRequested);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgObligationRequests);
            this.Name = "ucObligationRequestMain";
            this.Size = new System.Drawing.Size(597, 522);
            this.Load += new System.EventHandler(this.ucObligationRequestMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOtherFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.DateTimePicker dtDateRequested;
        internal System.Windows.Forms.MaskedTextBox mskObligationSeriesNo;
        internal System.Windows.Forms.MaskedTextBox mskTxtObligationNoTemplate;
        internal System.Windows.Forms.DataGridView dgObligationRequests;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.ErrorProvider epPayee;
        internal System.Windows.Forms.ErrorProvider epOtherFPP;
        internal System.Windows.Forms.ErrorProvider epObligationNo;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ErrorProvider epExplanation;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.ErrorProvider epReferenceNo;
    }
}
