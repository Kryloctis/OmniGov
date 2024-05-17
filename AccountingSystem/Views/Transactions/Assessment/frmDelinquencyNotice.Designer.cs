using AccountingSystem.Views.Transactions.Assessment;
namespace AccountingSystem.Views.Transactions.Assessment
{
    partial class frmDelinquencyNotice
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
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            tabPageForm = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            ucDelinquenyNotice1 = new ucDelinquenyNotice();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            panel4 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            dgRoles = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tabControlMain.SuspendLayout();
            tabPageList.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabPageForm.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRoles).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPageList);
            tabControlMain.Controls.Add(tabPageForm);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(848, 515);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageList
            // 
            tabPageList.Controls.Add(panel4);
            tabPageList.Controls.Add(panel1);
            tabPageList.Controls.Add(toolStrip1);
            tabPageList.Controls.Add(statusStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 27);
            tabPageList.Name = "tabPageList";
            tabPageList.Size = new System.Drawing.Size(840, 484);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "tabPageList";
            tabPageList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbxRowLimit);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(840, 30);
            panel1.TabIndex = 19;
            // 
            // cmbxRowLimit
            // 
            cmbxRowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowLimit.FormattingEnabled = true;
            cmbxRowLimit.Location = new System.Drawing.Point(3, 3);
            cmbxRowLimit.Name = "cmbxRowLimit";
            cmbxRowLimit.Size = new System.Drawing.Size(120, 23);
            cmbxRowLimit.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(840, 35);
            toolStrip1.TabIndex = 18;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_24px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_24px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_24px;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 24);
            btnSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // tabPageForm
            // 
            tabPageForm.Controls.Add(panel2);
            tabPageForm.Controls.Add(toolStrip2);
            tabPageForm.Location = new System.Drawing.Point(4, 27);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Size = new System.Drawing.Size(840, 484);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "tabPageForm";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(ucDelinquenyNotice1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(840, 449);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(4, 440);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(815, 100);
            panel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(658, 7);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 23);
            button1.TabIndex = 0;
            button1.Text = "Save (Ctrl + S)";
            button1.UseVisualStyleBackColor = true;
            // 
            // ucDelinquenyNotice1
            // 
            ucDelinquenyNotice1.Dock = System.Windows.Forms.DockStyle.Top;
            ucDelinquenyNotice1.Location = new System.Drawing.Point(4, 4);
            ucDelinquenyNotice1.Name = "ucDelinquenyNotice1";
            ucDelinquenyNotice1.Size = new System.Drawing.Size(815, 436);
            ucDelinquenyNotice1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton1 });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(840, 35);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.arrow_left_20px;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(56, 24);
            toolStripButton1.Text = "Back";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgRoles);
            panel4.Controls.Add(progressBar1);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(0, 65);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(4);
            panel4.Size = new System.Drawing.Size(840, 397);
            panel4.TabIndex = 20;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(832, 5);
            progressBar1.TabIndex = 14;
            // 
            // dgRoles
            // 
            dgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            dgRoles.Location = new System.Drawing.Point(4, 9);
            dgRoles.Name = "dgRoles";
            dgRoles.RowHeadersWidth = 51;
            dgRoles.RowTemplate.Height = 29;
            dgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgRoles.Size = new System.Drawing.Size(832, 384);
            dgRoles.TabIndex = 13;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 462);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(840, 22);
            statusStrip1.TabIndex = 21;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmDelinquencyCenter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(848, 515);
            Controls.Add(tabControlMain);
            MinimizeBox = false;
            Name = "frmDelinquencyCenter";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Assessment > Delinquency Notice";
            Load += frmDelinquencyCenter_Load;
            tabControlMain.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            panel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageForm.ResumeLayout(false);
            tabPageForm.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRoles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel2;
        private ucDelinquenyNotice ucDelinquenyNotice1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgRoles;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
