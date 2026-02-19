namespace OmniGov.App.Views.Transactions.Auction
{
    partial class ucRptScheduling
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
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cmbxAuctionSchedule = new System.Windows.Forms.ComboBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            cmbxProperty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Auction Schedule*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Property*";
            // 
            // cmbxAuctionSchedule
            // 
            cmbxAuctionSchedule.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxAuctionSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAuctionSchedule.FormattingEnabled = true;
            cmbxAuctionSchedule.Location = new System.Drawing.Point(114, 7);
            cmbxAuctionSchedule.Name = "cmbxAuctionSchedule";
            cmbxAuctionSchedule.Size = new System.Drawing.Size(235, 23);
            cmbxAuctionSchedule.TabIndex = 2;
            cmbxAuctionSchedule.Validating += cmbxAuctionSchedule_Validating;
            cmbxAuctionSchedule.Validated += cmbxAuctionSchedule_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // cmbxProperty
            // 
            cmbxProperty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxProperty.FormattingEnabled = true;
            cmbxProperty.Location = new System.Drawing.Point(114, 36);
            cmbxProperty.Name = "cmbxProperty";
            cmbxProperty.Size = new System.Drawing.Size(235, 23);
            cmbxProperty.TabIndex = 2;
            cmbxProperty.Validating += cmbxProperty_Validating;
            cmbxProperty.Validated += cmbxProperty_Validated;
            // 
            // ucRptScheduling
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(cmbxProperty);
            Controls.Add(cmbxAuctionSchedule);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "ucRptScheduling";
            Size = new System.Drawing.Size(367, 67);
            Load += ucRptScheduling_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxAuctionSchedule;
        private System.Windows.Forms.ComboBox cmbxProperty;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
