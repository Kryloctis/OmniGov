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
            btnEmblem = new System.Windows.Forms.Button();
            txtProvince = new System.Windows.Forms.TextBox();
            txtMunicipality = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            pcEmblem = new System.Windows.Forms.PictureBox();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            flowLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLguDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcEmblem).BeginInit();
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
            flowLayoutPanel1.Size = new System.Drawing.Size(190, 311);
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
            tabControl1.Location = new System.Drawing.Point(190, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(454, 311);
            tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // tabPageLguDetails
            // 
            tabPageLguDetails.Controls.Add(btnEmblem);
            tabPageLguDetails.Controls.Add(txtProvince);
            tabPageLguDetails.Controls.Add(txtMunicipality);
            tabPageLguDetails.Controls.Add(label2);
            tabPageLguDetails.Controls.Add(label3);
            tabPageLguDetails.Controls.Add(label1);
            tabPageLguDetails.Controls.Add(pcEmblem);
            tabPageLguDetails.Location = new System.Drawing.Point(4, 5);
            tabPageLguDetails.Name = "tabPageLguDetails";
            tabPageLguDetails.Padding = new System.Windows.Forms.Padding(3);
            tabPageLguDetails.Size = new System.Drawing.Size(446, 302);
            tabPageLguDetails.TabIndex = 0;
            tabPageLguDetails.Text = "LGU Details";
            tabPageLguDetails.UseVisualStyleBackColor = true;
            // 
            // btnEmblem
            // 
            btnEmblem.Location = new System.Drawing.Point(391, 15);
            btnEmblem.Name = "btnEmblem";
            btnEmblem.Size = new System.Drawing.Size(25, 25);
            btnEmblem.TabIndex = 3;
            btnEmblem.Text = "...";
            btnEmblem.UseVisualStyleBackColor = true;
            btnEmblem.Click += btnEmblem_Click;
            // 
            // txtProvince
            // 
            txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtProvince.Location = new System.Drawing.Point(116, 154);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new System.Drawing.Size(304, 23);
            txtProvince.TabIndex = 1;
            // 
            // txtMunicipality
            // 
            txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMunicipality.Location = new System.Drawing.Point(116, 125);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new System.Drawing.Size(304, 23);
            txtMunicipality.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 158);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 15);
            label2.TabIndex = 0;
            label2.Text = "Province";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 129);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Muncipality / City";
            // 
            // pcEmblem
            // 
            pcEmblem.BackColor = System.Drawing.Color.White;
            pcEmblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pcEmblem.Location = new System.Drawing.Point(116, 11);
            pcEmblem.Name = "pcEmblem";
            pcEmblem.Size = new System.Drawing.Size(304, 108);
            pcEmblem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pcEmblem.TabIndex = 4;
            pcEmblem.TabStop = false;
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
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "\"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...\"";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPreferences";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Preferences";
            Load += frmPreferences_Load;
            flowLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageLguDetails.ResumeLayout(false);
            tabPageLguDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcEmblem).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pcEmblem;
    }
}