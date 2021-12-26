
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
            this.dtDateRequest = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.mskTxtObligationNoSeries = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtObligationNoTemplate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgObligationRequests = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSubFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epReferenceNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epExplanation = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationRequest = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTotalObligations = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAllotmentClass = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDateRequest
            // 
            this.dtDateRequest.Location = new System.Drawing.Point(472, 155);
            this.dtDateRequest.Name = "dtDateRequest";
            this.dtDateRequest.Size = new System.Drawing.Size(221, 23);
            this.dtDateRequest.TabIndex = 8;
            this.dtDateRequest.ValueChanged += new System.EventHandler(this.dtDateRequest_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date of Request";
            // 
            // mskTxtObligationNoSeries
            // 
            this.mskTxtObligationNoSeries.Location = new System.Drawing.Point(105, 155);
            this.mskTxtObligationNoSeries.Mask = "0000";
            this.mskTxtObligationNoSeries.Name = "mskTxtObligationNoSeries";
            this.mskTxtObligationNoSeries.Size = new System.Drawing.Size(46, 23);
            this.mskTxtObligationNoSeries.TabIndex = 6;
            this.mskTxtObligationNoSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTxtObligationNoSeries.Validating += new System.ComponentModel.CancelEventHandler(this.mskTxtObligationNoSeries_Validating);
            this.mskTxtObligationNoSeries.Validated += new System.EventHandler(this.mskTxtObligationNoSeries_Validated);
            // 
            // mskTxtObligationNoTemplate
            // 
            this.mskTxtObligationNoTemplate.Location = new System.Drawing.Point(169, 155);
            this.mskTxtObligationNoTemplate.Mask = "00-00-000";
            this.mskTxtObligationNoTemplate.Name = "mskTxtObligationNoTemplate";
            this.mskTxtObligationNoTemplate.ReadOnly = true;
            this.mskTxtObligationNoTemplate.Size = new System.Drawing.Size(73, 23);
            this.mskTxtObligationNoTemplate.TabIndex = 7;
            this.mskTxtObligationNoTemplate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Obligation No.";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(105, 213);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(588, 23);
            this.txtPayee.TabIndex = 10;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayee_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Payee";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Explanation";
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(105, 242);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(588, 36);
            this.txtExplanation.TabIndex = 11;
            this.txtExplanation.Validating += new System.ComponentModel.CancelEventHandler(this.txtExplanation_Validating);
            this.txtExplanation.Validated += new System.EventHandler(this.txtExplanation_Validated);
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(105, 184);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(588, 23);
            this.txtReferenceNo.TabIndex = 9;
            this.txtReferenceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferenceNo_Validating);
            this.txtReferenceNo.Validated += new System.EventHandler(this.txtReferenceNo_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Reference No.";
            // 
            // dgObligationRequests
            // 
            this.dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationRequests.Location = new System.Drawing.Point(6, 283);
            this.dgObligationRequests.Name = "dgObligationRequests";
            this.dgObligationRequests.RowTemplate.Height = 25;
            this.dgObligationRequests.Size = new System.Drawing.Size(687, 208);
            this.dgObligationRequests.TabIndex = 12;
            this.dgObligationRequests.SelectionChanged += new System.EventHandler(this.dgObligationRequests_SelectionChanged);
            this.dgObligationRequests.Validating += new System.ComponentModel.CancelEventHandler(this.dgObligationRequests_Validating);
            this.dgObligationRequests.Validated += new System.EventHandler(this.dgObligationRequests_Validated);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(618, 497);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(540, 497);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(459, 497);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epSubFPP
            // 
            this.epSubFPP.ContainerControl = this;
            // 
            // epObligationNo
            // 
            this.epObligationNo.ContainerControl = this;
            // 
            // epReferenceNo
            // 
            this.epReferenceNo.ContainerControl = this;
            // 
            // epExplanation
            // 
            this.epExplanation.ContainerControl = this;
            // 
            // epObligationRequest
            // 
            this.epObligationRequest.ContainerControl = this;
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // txtTotalObligations
            // 
            this.txtTotalObligations.Location = new System.Drawing.Point(105, 497);
            this.txtTotalObligations.MaxLength = 999999999;
            this.txtTotalObligations.Name = "txtTotalObligations";
            this.txtTotalObligations.ReadOnly = true;
            this.txtTotalObligations.Size = new System.Drawing.Size(137, 23);
            this.txtTotalObligations.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Total Obligations";
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(104, 3);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(589, 23);
            this.cmbxFPP.TabIndex = 18;
            this.cmbxFPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxFPP_KeyDown);
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "FPP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelAllotmentClass);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 54);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allotment Class";
            // 
            // flowLayoutPanelAllotmentClass
            // 
            this.flowLayoutPanelAllotmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAllotmentClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelAllotmentClass.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelAllotmentClass.Name = "flowLayoutPanelAllotmentClass";
            this.flowLayoutPanelAllotmentClass.Size = new System.Drawing.Size(684, 32);
            this.flowLayoutPanelAllotmentClass.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 54);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(684, 32);
            this.flowLayoutPanelFunds.TabIndex = 3;
            // 
            // ucObligationRequestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalObligations);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgObligationRequests);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mskTxtObligationNoTemplate);
            this.Controls.Add(this.mskTxtObligationNoSeries);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDateRequest);
            this.Name = "ucObligationRequestMain";
            this.Size = new System.Drawing.Size(710, 523);
            this.Load += new System.EventHandler(this.ucObligationRequestMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.MaskedTextBox mskTxtObligationNoTemplate;
        internal System.Windows.Forms.DateTimePicker dtDateRequest;
        internal System.Windows.Forms.MaskedTextBox mskTxtObligationNoSeries;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.ErrorProvider epSubFPP;
        internal System.Windows.Forms.ErrorProvider epObligationNo;
        internal System.Windows.Forms.ErrorProvider epReferenceNo;
        internal System.Windows.Forms.ErrorProvider epExplanation;
        internal System.Windows.Forms.ErrorProvider epObligationRequest;
        internal System.Windows.Forms.ErrorProvider epPayee;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataGridView dgObligationRequests;
        internal System.Windows.Forms.TextBox txtTotalObligations;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotmentClass;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.Label label9;
    }
}
