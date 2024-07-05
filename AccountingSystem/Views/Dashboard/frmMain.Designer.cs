namespace AccountingSystem.Views.Dashboard
{
    partial class frmMain
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
            panel1 = new System.Windows.Forms.Panel();
            radReports = new System.Windows.Forms.RadioButton();
            radMyAccount = new System.Windows.Forms.RadioButton();
            radSettings = new System.Windows.Forms.RadioButton();
            btnLogout = new System.Windows.Forms.Button();
            radTreasury = new System.Windows.Forms.RadioButton();
            radAccounting = new System.Windows.Forms.RadioButton();
            radBudget = new System.Windows.Forms.RadioButton();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageBudget = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            ucBudget1 = new Budget.ucBudget();
            label4 = new System.Windows.Forms.Label();
            tabPageAccounting = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            ucAccounting1 = new Accounting.ucAccounting();
            label2 = new System.Windows.Forms.Label();
            tabPageTreasury = new System.Windows.Forms.TabPage();
            panel4 = new System.Windows.Forms.Panel();
            ucTreasury1 = new Treasury.ucTreasury();
            label3 = new System.Windows.Forms.Label();
            tabPageSettings = new System.Windows.Forms.TabPage();
            ucSettings1 = new Settings.ucSettings();
            label5 = new System.Windows.Forms.Label();
            tabPageReports = new System.Windows.Forms.TabPage();
            ucReports1 = new Reports.ucReports();
            label1 = new System.Windows.Forms.Label();
            tabPageMyAccount = new System.Windows.Forms.TabPage();
            ucMyAccount1 = new MyAccount.ucMyAccount();
            label6 = new System.Windows.Forms.Label();
            taxRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            discountRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageBudget.SuspendLayout();
            panel2.SuspendLayout();
            tabPageAccounting.SuspendLayout();
            panel3.SuspendLayout();
            tabPageTreasury.SuspendLayout();
            panel4.SuspendLayout();
            tabPageSettings.SuspendLayout();
            tabPageReports.SuspendLayout();
            tabPageMyAccount.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Controls.Add(radReports);
            panel1.Controls.Add(radMyAccount);
            panel1.Controls.Add(radSettings);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(radTreasury);
            panel1.Controls.Add(radAccounting);
            panel1.Controls.Add(radBudget);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(142, 666);
            panel1.TabIndex = 1;
            // 
            // radReports
            // 
            radReports.Appearance = System.Windows.Forms.Appearance.Button;
            radReports.AutoSize = true;
            radReports.Dock = System.Windows.Forms.DockStyle.Top;
            radReports.FlatAppearance.BorderSize = 0;
            radReports.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radReports.Location = new System.Drawing.Point(0, 99);
            radReports.Margin = new System.Windows.Forms.Padding(0);
            radReports.Name = "radReports";
            radReports.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radReports.Size = new System.Drawing.Size(142, 33);
            radReports.TabIndex = 10;
            radReports.Text = "Reports";
            radReports.UseVisualStyleBackColor = true;
            radReports.CheckedChanged += radReports_CheckedChanged;
            // 
            // radMyAccount
            // 
            radMyAccount.Appearance = System.Windows.Forms.Appearance.Button;
            radMyAccount.AutoSize = true;
            radMyAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            radMyAccount.FlatAppearance.BorderSize = 0;
            radMyAccount.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radMyAccount.Image = Properties.Resources.users_20px;
            radMyAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radMyAccount.Location = new System.Drawing.Point(0, 566);
            radMyAccount.Margin = new System.Windows.Forms.Padding(0);
            radMyAccount.Name = "radMyAccount";
            radMyAccount.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radMyAccount.Size = new System.Drawing.Size(142, 34);
            radMyAccount.TabIndex = 11;
            radMyAccount.Text = "My Account";
            radMyAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radMyAccount.CheckedChanged += radMyAccount_CheckedChanged;
            // 
            // radSettings
            // 
            radSettings.Appearance = System.Windows.Forms.Appearance.Button;
            radSettings.AutoSize = true;
            radSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            radSettings.FlatAppearance.BorderSize = 0;
            radSettings.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radSettings.Image = Properties.Resources.gear_filled_16px;
            radSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radSettings.Location = new System.Drawing.Point(0, 600);
            radSettings.Margin = new System.Windows.Forms.Padding(0);
            radSettings.Name = "radSettings";
            radSettings.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radSettings.Size = new System.Drawing.Size(142, 33);
            radSettings.TabIndex = 9;
            radSettings.Text = "Settings";
            radSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radSettings.CheckedChanged += radSettings_CheckedChanged;
            // 
            // btnLogout
            // 
            btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Image = Properties.Resources.logout_16px;
            btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLogout.Location = new System.Drawing.Point(0, 633);
            btnLogout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnLogout.Size = new System.Drawing.Size(142, 33);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // radTreasury
            // 
            radTreasury.Appearance = System.Windows.Forms.Appearance.Button;
            radTreasury.AutoSize = true;
            radTreasury.Dock = System.Windows.Forms.DockStyle.Top;
            radTreasury.FlatAppearance.BorderSize = 0;
            radTreasury.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radTreasury.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radTreasury.Location = new System.Drawing.Point(0, 66);
            radTreasury.Margin = new System.Windows.Forms.Padding(0);
            radTreasury.Name = "radTreasury";
            radTreasury.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radTreasury.Size = new System.Drawing.Size(142, 33);
            radTreasury.TabIndex = 5;
            radTreasury.Text = "Treasury";
            radTreasury.UseVisualStyleBackColor = true;
            radTreasury.CheckedChanged += radTreasury_CheckedChanged;
            // 
            // radAccounting
            // 
            radAccounting.Appearance = System.Windows.Forms.Appearance.Button;
            radAccounting.AutoSize = true;
            radAccounting.Dock = System.Windows.Forms.DockStyle.Top;
            radAccounting.FlatAppearance.BorderSize = 0;
            radAccounting.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radAccounting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radAccounting.Location = new System.Drawing.Point(0, 33);
            radAccounting.Margin = new System.Windows.Forms.Padding(0);
            radAccounting.Name = "radAccounting";
            radAccounting.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radAccounting.Size = new System.Drawing.Size(142, 33);
            radAccounting.TabIndex = 4;
            radAccounting.Text = "Accounting";
            radAccounting.UseVisualStyleBackColor = true;
            radAccounting.CheckedChanged += radAccounting_CheckedChanged;
            // 
            // radBudget
            // 
            radBudget.Appearance = System.Windows.Forms.Appearance.Button;
            radBudget.AutoSize = true;
            radBudget.Checked = true;
            radBudget.Dock = System.Windows.Forms.DockStyle.Top;
            radBudget.FlatAppearance.BorderSize = 0;
            radBudget.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radBudget.Location = new System.Drawing.Point(0, 0);
            radBudget.Margin = new System.Windows.Forms.Padding(0);
            radBudget.Name = "radBudget";
            radBudget.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            radBudget.Size = new System.Drawing.Size(142, 33);
            radBudget.TabIndex = 3;
            radBudget.TabStop = true;
            radBudget.Text = "Budget";
            radBudget.UseVisualStyleBackColor = true;
            radBudget.CheckedChanged += radBudget_CheckedChanged;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageBudget);
            tabControlMain.Controls.Add(tabPageAccounting);
            tabControlMain.Controls.Add(tabPageTreasury);
            tabControlMain.Controls.Add(tabPageSettings);
            tabControlMain.Controls.Add(tabPageReports);
            tabControlMain.Controls.Add(tabPageMyAccount);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tabControlMain.Location = new System.Drawing.Point(142, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(1133, 666);
            tabControlMain.TabIndex = 2;
            tabControlMain.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageBudget
            // 
            tabPageBudget.Controls.Add(panel2);
            tabPageBudget.Controls.Add(label4);
            tabPageBudget.Location = new System.Drawing.Point(4, 24);
            tabPageBudget.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageBudget.Name = "tabPageBudget";
            tabPageBudget.Size = new System.Drawing.Size(1125, 638);
            tabPageBudget.TabIndex = 1;
            tabPageBudget.Text = "tabPageBudget";
            tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(ucBudget1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 80);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            panel2.Size = new System.Drawing.Size(1125, 558);
            panel2.TabIndex = 4;
            // 
            // ucBudget1
            // 
            ucBudget1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBudget1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucBudget1.Location = new System.Drawing.Point(5, 4);
            ucBudget1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ucBudget1.Name = "ucBudget1";
            ucBudget1.Size = new System.Drawing.Size(1115, 550);
            ucBudget1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Dock = System.Windows.Forms.DockStyle.Top;
            label4.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label4.Location = new System.Drawing.Point(0, 0);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label4.Size = new System.Drawing.Size(1125, 80);
            label4.TabIndex = 5;
            label4.Text = "Budget";
            // 
            // tabPageAccounting
            // 
            tabPageAccounting.Controls.Add(panel3);
            tabPageAccounting.Controls.Add(label2);
            tabPageAccounting.Location = new System.Drawing.Point(4, 24);
            tabPageAccounting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageAccounting.Name = "tabPageAccounting";
            tabPageAccounting.Size = new System.Drawing.Size(1125, 638);
            tabPageAccounting.TabIndex = 2;
            tabPageAccounting.Text = "tabPageAccounting";
            tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(ucAccounting1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 80);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            panel3.Size = new System.Drawing.Size(1125, 558);
            panel3.TabIndex = 5;
            // 
            // ucAccounting1
            // 
            ucAccounting1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucAccounting1.Location = new System.Drawing.Point(5, 4);
            ucAccounting1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ucAccounting1.Name = "ucAccounting1";
            ucAccounting1.Size = new System.Drawing.Size(1115, 550);
            ucAccounting1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Top;
            label2.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label2.Size = new System.Drawing.Size(1125, 80);
            label2.TabIndex = 3;
            label2.Text = "Accounting";
            // 
            // tabPageTreasury
            // 
            tabPageTreasury.Controls.Add(panel4);
            tabPageTreasury.Controls.Add(label3);
            tabPageTreasury.Location = new System.Drawing.Point(4, 24);
            tabPageTreasury.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageTreasury.Name = "tabPageTreasury";
            tabPageTreasury.Size = new System.Drawing.Size(1125, 638);
            tabPageTreasury.TabIndex = 3;
            tabPageTreasury.Text = "tabPageTreasury";
            tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(ucTreasury1);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(0, 80);
            panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            panel4.Size = new System.Drawing.Size(1125, 558);
            panel4.TabIndex = 5;
            // 
            // ucTreasury1
            // 
            ucTreasury1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTreasury1.Location = new System.Drawing.Point(5, 4);
            ucTreasury1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ucTreasury1.Name = "ucTreasury1";
            ucTreasury1.Size = new System.Drawing.Size(1115, 550);
            ucTreasury1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = System.Windows.Forms.DockStyle.Top;
            label3.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label3.Size = new System.Drawing.Size(1125, 80);
            label3.TabIndex = 4;
            label3.Text = "Treasury";
            // 
            // tabPageSettings
            // 
            tabPageSettings.Controls.Add(ucSettings1);
            tabPageSettings.Controls.Add(label5);
            tabPageSettings.Location = new System.Drawing.Point(4, 24);
            tabPageSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Size = new System.Drawing.Size(1125, 638);
            tabPageSettings.TabIndex = 4;
            tabPageSettings.Text = "tabPageSettings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // ucSettings1
            // 
            ucSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSettings1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucSettings1.Location = new System.Drawing.Point(0, 80);
            ucSettings1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ucSettings1.Name = "ucSettings1";
            ucSettings1.Size = new System.Drawing.Size(1125, 558);
            ucSettings1.TabIndex = 6;
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label5.Location = new System.Drawing.Point(0, 0);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label5.Size = new System.Drawing.Size(1125, 80);
            label5.TabIndex = 5;
            label5.Text = "Settings";
            // 
            // tabPageReports
            // 
            tabPageReports.Controls.Add(ucReports1);
            tabPageReports.Controls.Add(label1);
            tabPageReports.Location = new System.Drawing.Point(4, 24);
            tabPageReports.Name = "tabPageReports";
            tabPageReports.Size = new System.Drawing.Size(1125, 638);
            tabPageReports.TabIndex = 5;
            tabPageReports.Text = "tabPageReports";
            tabPageReports.UseVisualStyleBackColor = true;
            // 
            // ucReports1
            // 
            ucReports1.AutoScroll = true;
            ucReports1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucReports1.Location = new System.Drawing.Point(0, 80);
            ucReports1.Name = "ucReports1";
            ucReports1.Padding = new System.Windows.Forms.Padding(4);
            ucReports1.Size = new System.Drawing.Size(1125, 558);
            ucReports1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label1.Size = new System.Drawing.Size(1125, 80);
            label1.TabIndex = 6;
            label1.Text = "Reports";
            // 
            // tabPageMyAccount
            // 
            tabPageMyAccount.Controls.Add(ucMyAccount1);
            tabPageMyAccount.Controls.Add(label6);
            tabPageMyAccount.Location = new System.Drawing.Point(4, 24);
            tabPageMyAccount.Name = "tabPageMyAccount";
            tabPageMyAccount.Size = new System.Drawing.Size(1125, 638);
            tabPageMyAccount.TabIndex = 6;
            tabPageMyAccount.Text = "tabPageMyAccount";
            tabPageMyAccount.UseVisualStyleBackColor = true;
            // 
            // ucMyAccount1
            // 
            ucMyAccount1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucMyAccount1.Location = new System.Drawing.Point(0, 80);
            ucMyAccount1.Name = "ucMyAccount1";
            ucMyAccount1.Padding = new System.Windows.Forms.Padding(2);
            ucMyAccount1.Size = new System.Drawing.Size(1125, 558);
            ucMyAccount1.TabIndex = 5;
            // 
            // label6
            // 
            label6.Dock = System.Windows.Forms.DockStyle.Top;
            label6.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            label6.Location = new System.Drawing.Point(0, 0);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            label6.Size = new System.Drawing.Size(1125, 80);
            label6.TabIndex = 4;
            label6.Text = "My Account";
            // 
            // taxRatesToolStripMenuItem
            // 
            taxRatesToolStripMenuItem.Name = "taxRatesToolStripMenuItem";
            taxRatesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            taxRatesToolStripMenuItem.Text = "Tax Rates...";
            // 
            // discountRatesToolStripMenuItem
            // 
            discountRatesToolStripMenuItem.Name = "discountRatesToolStripMenuItem";
            discountRatesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            discountRatesToolStripMenuItem.Text = "Discount Rates...";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1275, 666);
            Controls.Add(tabControlMain);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1291, 705);
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Local Finance System";
            FormClosed += Dashboard_FormClosed;
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabPageBudget.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPageAccounting.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabPageTreasury.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tabPageSettings.ResumeLayout(false);
            tabPageReports.ResumeLayout(false);
            tabPageMyAccount.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radTreasury;
        private System.Windows.Forms.RadioButton radAccounting;
        private System.Windows.Forms.RadioButton radBudget;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBudget;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.RadioButton radSettings;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem taxRatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discountRatesToolStripMenuItem;
        private Budget.ucBudget ucBudget1;
        private Accounting.ucAccounting ucAccounting1;
        private Treasury.ucTreasury ucTreasury1;
        private Settings.ucSettings ucSettings1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radReports;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Label label1;
        private Reports.ucReports ucReports1;
        private System.Windows.Forms.RadioButton radMyAccount;
        private System.Windows.Forms.TabPage tabPageMyAccount;
        private System.Windows.Forms.Label label6;
        private MyAccount.ucMyAccount ucMyAccount1;
    }
}