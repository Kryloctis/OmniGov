
namespace LFS.Budget.Views.Obligations
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
            components = new System.ComponentModel.Container();
            dtDateRequest = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            mskTxtObligationNoSeries = new System.Windows.Forms.MaskedTextBox();
            mskTxtObligationNoTemplate = new System.Windows.Forms.MaskedTextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtPayee = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtExplanation = new System.Windows.Forms.TextBox();
            txtReferenceNo = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            dgObligationRequests = new System.Windows.Forms.DataGridView();
            btnRemove = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            txtTotalObligations = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            cmbxFPP = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanelAllotmentClass = new System.Windows.Forms.FlowLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgObligationRequests).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtDateRequest
            // 
            dtDateRequest.Location = new System.Drawing.Point(472, 155);
            dtDateRequest.Name = "dtDateRequest";
            dtDateRequest.Size = new System.Drawing.Size(221, 23);
            dtDateRequest.TabIndex = 8;
            dtDateRequest.ValueChanged += dtDateRequest_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(376, 158);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(90, 15);
            label3.TabIndex = 6;
            label3.Text = "Date of Request";
            // 
            // mskTxtObligationNoSeries
            // 
            mskTxtObligationNoSeries.Location = new System.Drawing.Point(105, 155);
            mskTxtObligationNoSeries.Mask = "0000";
            mskTxtObligationNoSeries.Name = "mskTxtObligationNoSeries";
            mskTxtObligationNoSeries.Size = new System.Drawing.Size(46, 23);
            mskTxtObligationNoSeries.TabIndex = 6;
            mskTxtObligationNoSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            mskTxtObligationNoSeries.Validating += mskTxtObligationNoSeries_Validating;
            mskTxtObligationNoSeries.Validated += mskTxtObligationNoSeries_Validated;
            // 
            // mskTxtObligationNoTemplate
            // 
            mskTxtObligationNoTemplate.Location = new System.Drawing.Point(169, 155);
            mskTxtObligationNoTemplate.Mask = "00-00-000";
            mskTxtObligationNoTemplate.Name = "mskTxtObligationNoTemplate";
            mskTxtObligationNoTemplate.ReadOnly = true;
            mskTxtObligationNoTemplate.Size = new System.Drawing.Size(73, 23);
            mskTxtObligationNoTemplate.TabIndex = 7;
            mskTxtObligationNoTemplate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(154, 158);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(12, 15);
            label4.TabIndex = 9;
            label4.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 158);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 15);
            label5.TabIndex = 10;
            label5.Text = "Obligation No.";
            // 
            // txtPayee
            // 
            txtPayee.Location = new System.Drawing.Point(105, 213);
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(588, 23);
            txtPayee.TabIndex = 10;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(4, 216);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(38, 15);
            label6.TabIndex = 12;
            label6.Text = "Payee";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(4, 245);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 15);
            label7.TabIndex = 13;
            label7.Text = "Explanation";
            // 
            // txtExplanation
            // 
            txtExplanation.Location = new System.Drawing.Point(105, 242);
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.Size = new System.Drawing.Size(588, 36);
            txtExplanation.TabIndex = 11;
            txtExplanation.Validating += txtExplanation_Validating;
            txtExplanation.Validated += txtExplanation_Validated;
            // 
            // txtReferenceNo
            // 
            txtReferenceNo.Location = new System.Drawing.Point(105, 184);
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.Size = new System.Drawing.Size(588, 23);
            txtReferenceNo.TabIndex = 9;
            txtReferenceNo.Validating += txtReferenceNo_Validating;
            txtReferenceNo.Validated += txtReferenceNo_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(4, 187);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(81, 15);
            label8.TabIndex = 12;
            label8.Text = "Reference No.";
            // 
            // dgObligationRequests
            // 
            dgObligationRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgObligationRequests.Location = new System.Drawing.Point(6, 283);
            dgObligationRequests.Name = "dgObligationRequests";
            dgObligationRequests.Size = new System.Drawing.Size(687, 208);
            dgObligationRequests.TabIndex = 12;
            dgObligationRequests.SelectionChanged += dgObligationRequests_SelectionChanged;
            dgObligationRequests.Validating += dgObligationRequests_Validating;
            dgObligationRequests.Validated += dgObligationRequests_Validated;
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(618, 497);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 23);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(540, 497);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(75, 23);
            btnEdit.TabIndex = 15;
            btnEdit.Text = "Edit...";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(459, 497);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add...";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtTotalObligations
            // 
            txtTotalObligations.BackColor = System.Drawing.SystemColors.Control;
            txtTotalObligations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalObligations.Location = new System.Drawing.Point(41, 497);
            txtTotalObligations.MaxLength = 999999999;
            txtTotalObligations.Name = "txtTotalObligations";
            txtTotalObligations.ReadOnly = true;
            txtTotalObligations.Size = new System.Drawing.Size(236, 23);
            txtTotalObligations.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 500);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(32, 15);
            label9.TabIndex = 17;
            label9.Text = "Total";
            // 
            // cmbxFPP
            // 
            cmbxFPP.FormattingEnabled = true;
            cmbxFPP.Location = new System.Drawing.Point(104, 3);
            cmbxFPP.Name = "cmbxFPP";
            cmbxFPP.Size = new System.Drawing.Size(589, 23);
            cmbxFPP.TabIndex = 18;
            cmbxFPP.KeyDown += cmbxFPP_KeyDown;
            cmbxFPP.Validating += cmbxFPP_Validating;
            cmbxFPP.Validated += cmbxFPP_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 15);
            label1.TabIndex = 20;
            label1.Text = "FPP";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanelAllotmentClass);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            groupBox2.Location = new System.Drawing.Point(3, 91);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(690, 54);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Allotment Class";
            // 
            // flowLayoutPanelAllotmentClass
            // 
            flowLayoutPanelAllotmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelAllotmentClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            flowLayoutPanelAllotmentClass.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelAllotmentClass.Name = "flowLayoutPanelAllotmentClass";
            flowLayoutPanelAllotmentClass.Size = new System.Drawing.Size(684, 32);
            flowLayoutPanelAllotmentClass.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanelFunds);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            groupBox1.Location = new System.Drawing.Point(3, 34);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(690, 54);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F);
            flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            flowLayoutPanelFunds.Size = new System.Drawing.Size(684, 32);
            flowLayoutPanelFunds.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucObligationRequestMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(cmbxFPP);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label9);
            Controls.Add(txtTotalObligations);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnRemove);
            Controls.Add(dgObligationRequests);
            Controls.Add(txtExplanation);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(txtReferenceNo);
            Controls.Add(txtPayee);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(mskTxtObligationNoTemplate);
            Controls.Add(mskTxtObligationNoSeries);
            Controls.Add(label3);
            Controls.Add(dtDateRequest);
            Name = "ucObligationRequestMain";
            Size = new System.Drawing.Size(710, 523);
            Load += ucObligationRequestMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgObligationRequests).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
