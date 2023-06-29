namespace AccountingSystem.Views.Manage.Preferences
{
    partial class frmPreferences
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radLguDetails = new System.Windows.Forms.RadioButton();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageLguDetails = new System.Windows.Forms.TabPage();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtMunicipality = new System.Windows.Forms.TextBox();
            txtProvince = new System.Windows.Forms.TextBox();
            btnEmblem = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            flowLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLguDetails.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(radLguDetails);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(196, 311);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // radLguDetails
            // 
            radLguDetails.Appearance = System.Windows.Forms.Appearance.Button;
            radLguDetails.Checked = true;
            radLguDetails.FlatAppearance.BorderSize = 0;
            radLguDetails.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radLguDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radLguDetails.Location = new System.Drawing.Point(0, 0);
            radLguDetails.Margin = new System.Windows.Forms.Padding(0);
            radLguDetails.Name = "radLguDetails";
            radLguDetails.Size = new System.Drawing.Size(195, 37);
            radLguDetails.TabIndex = 6;
            radLguDetails.TabStop = true;
            radLguDetails.Text = "LGU Details";
            radLguDetails.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageLguDetails);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.Location = new System.Drawing.Point(196, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(448, 311);
            tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // tabPageLguDetails
            // 
            tabPageLguDetails.Controls.Add(btnEmblem);
            tabPageLguDetails.Controls.Add(txtProvince);
            tabPageLguDetails.Controls.Add(textBox3);
            tabPageLguDetails.Controls.Add(txtMunicipality);
            tabPageLguDetails.Controls.Add(label2);
            tabPageLguDetails.Controls.Add(label3);
            tabPageLguDetails.Controls.Add(label1);
            tabPageLguDetails.Location = new System.Drawing.Point(4, 5);
            tabPageLguDetails.Name = "tabPageLguDetails";
            tabPageLguDetails.Padding = new System.Windows.Forms.Padding(3);
            tabPageLguDetails.Size = new System.Drawing.Size(440, 302);
            tabPageLguDetails.TabIndex = 0;
            tabPageLguDetails.Text = "LGU Details";
            tabPageLguDetails.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(btnClose);
            flowLayoutPanel2.Controls.Add(btnSave);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 311);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(644, 30);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(566, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(485, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Muncipality / City";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 15);
            label2.TabIndex = 0;
            label2.Text = "Province";
            // 
            // txtMunicipality
            // 
            txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMunicipality.Location = new System.Drawing.Point(116, 36);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new System.Drawing.Size(304, 23);
            txtMunicipality.TabIndex = 1;
            // 
            // txtProvince
            // 
            txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtProvince.Location = new System.Drawing.Point(116, 65);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new System.Drawing.Size(304, 23);
            txtProvince.TabIndex = 1;
            // 
            // btnEmblem
            // 
            btnEmblem.Location = new System.Drawing.Point(395, 6);
            btnEmblem.Name = "btnEmblem";
            btnEmblem.Size = new System.Drawing.Size(25, 25);
            btnEmblem.TabIndex = 3;
            btnEmblem.Text = "...";
            btnEmblem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 11);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 15);
            label3.TabIndex = 0;
            label3.Text = "Emblem / Logo";
            // 
            // textBox3
            // 
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox3.Location = new System.Drawing.Point(116, 7);
            textBox3.MaxLength = 99999999;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(273, 23);
            textBox3.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmPreferences
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new System.Drawing.Size(644, 341);
            Controls.Add(tabControl1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPreferences";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Preferences";
            flowLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageLguDetails.ResumeLayout(false);
            tabPageLguDetails.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radLguDetails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLguDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtMunicipality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmblem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}