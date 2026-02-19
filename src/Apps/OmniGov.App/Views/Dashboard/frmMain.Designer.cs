namespace OmniGov.App.Views.Dashboard
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
            panel1 = new Panel();
            radManage = new RadioButton();
            radioBtnMyAccount = new RadioButton();
            radReports = new RadioButton();
            btnLogout = new Button();
            radTreasury = new RadioButton();
            radAccounting = new RadioButton();
            radBudget = new RadioButton();
            tabControlMain = new TabControl();
            tabPageBudget = new TabPage();
            panel2 = new Panel();
            ucBudget1 = new OmniGov.App.Budget.Views.Dashboard.ucBudget();
            label4 = new Label();
            tabPageAccounting = new TabPage();
            panel3 = new Panel();
            ucAccounting1 = new OmniGov.App.Accounting.Views.Dashboard.ucAccounting();
            label2 = new Label();
            tabPageTreasury = new TabPage();
            panel4 = new Panel();
            ucTreasury1 = new OmniGov.App.Views.Dashboard.Treasury.ucTreasury();
            label3 = new Label();
            tabPageManage = new TabPage();
            ucManage1 = new OmniGov.App.Views.Dashboard.Manage.ucManage();
            label5 = new Label();
            tabPageReports = new TabPage();
            ucReports1 = new OmniGov.App.Views.Dashboard.Reports.ucReports();
            label1 = new Label();
            tabPageMyAccount = new TabPage();
            ucMyAccount1 = new OmniGov.App.Views.Dashboard.MyAccount.ucMyAccount();
            taxRatesToolStripMenuItem = new ToolStripMenuItem();
            discountRatesToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            tlStrpWhatsNew = new ToolStripStatusLabel();
            toolStripStatusLabel6 = new ToolStripStatusLabel();
            tlStrpLblLoggedUser = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            tlStrpLblServer = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            tlStrpLblVersion = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageBudget.SuspendLayout();
            panel2.SuspendLayout();
            tabPageAccounting.SuspendLayout();
            panel3.SuspendLayout();
            tabPageTreasury.SuspendLayout();
            panel4.SuspendLayout();
            tabPageManage.SuspendLayout();
            tabPageReports.SuspendLayout();
            tabPageMyAccount.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(radManage);
            panel1.Controls.Add(radioBtnMyAccount);
            panel1.Controls.Add(radReports);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(radTreasury);
            panel1.Controls.Add(radAccounting);
            panel1.Controls.Add(radBudget);
            panel1.Dock = DockStyle.Left;
            panel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(142, 680);
            panel1.TabIndex = 1;
            // 
            // radManage
            // 
            radManage.Appearance = Appearance.Button;
            radManage.AutoSize = true;
            radManage.Dock = DockStyle.Top;
            radManage.FlatAppearance.BorderSize = 0;
            radManage.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radManage.FlatStyle = FlatStyle.Flat;
            radManage.ImageAlign = ContentAlignment.MiddleLeft;
            radManage.Location = new Point(0, 132);
            radManage.Margin = new Padding(0);
            radManage.Name = "radManage";
            radManage.Padding = new Padding(5, 4, 5, 4);
            radManage.Size = new Size(142, 33);
            radManage.TabIndex = 9;
            radManage.Text = "Manage";
            radManage.TextImageRelation = TextImageRelation.ImageBeforeText;
            radManage.CheckedChanged += radManage_CheckedChanged;
            // 
            // radioBtnMyAccount
            // 
            radioBtnMyAccount.Appearance = Appearance.Button;
            radioBtnMyAccount.AutoSize = true;
            radioBtnMyAccount.Dock = DockStyle.Bottom;
            radioBtnMyAccount.FlatAppearance.BorderSize = 0;
            radioBtnMyAccount.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radioBtnMyAccount.FlatStyle = FlatStyle.Flat;
            radioBtnMyAccount.Image = Properties.Resources.user_profile_man_20px;
            radioBtnMyAccount.ImageAlign = ContentAlignment.TopLeft;
            radioBtnMyAccount.Location = new Point(0, 613);
            radioBtnMyAccount.Margin = new Padding(0);
            radioBtnMyAccount.Name = "radioBtnMyAccount";
            radioBtnMyAccount.Padding = new Padding(5, 4, 5, 4);
            radioBtnMyAccount.Size = new Size(142, 34);
            radioBtnMyAccount.TabIndex = 11;
            radioBtnMyAccount.Text = " Account";
            radioBtnMyAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            radioBtnMyAccount.CheckedChanged += radioBtnMyAccount_CheckedChanged;
            // 
            // radReports
            // 
            radReports.Appearance = Appearance.Button;
            radReports.AutoSize = true;
            radReports.Dock = DockStyle.Top;
            radReports.FlatAppearance.BorderSize = 0;
            radReports.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radReports.FlatStyle = FlatStyle.Flat;
            radReports.Location = new Point(0, 99);
            radReports.Margin = new Padding(0);
            radReports.Name = "radReports";
            radReports.Padding = new Padding(5, 4, 5, 4);
            radReports.Size = new Size(142, 33);
            radReports.TabIndex = 10;
            radReports.Text = "Reports";
            radReports.UseVisualStyleBackColor = true;
            radReports.CheckedChanged += radReports_CheckedChanged;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Image = Properties.Resources.logout_16px;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 647);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(5, 4, 5, 4);
            btnLogout.Size = new Size(142, 33);
            btnLogout.TabIndex = 8;
            btnLogout.Text = " Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // radTreasury
            // 
            radTreasury.Appearance = Appearance.Button;
            radTreasury.AutoSize = true;
            radTreasury.Dock = DockStyle.Top;
            radTreasury.FlatAppearance.BorderSize = 0;
            radTreasury.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radTreasury.FlatStyle = FlatStyle.Flat;
            radTreasury.Location = new Point(0, 66);
            radTreasury.Margin = new Padding(0);
            radTreasury.Name = "radTreasury";
            radTreasury.Padding = new Padding(5, 4, 5, 4);
            radTreasury.Size = new Size(142, 33);
            radTreasury.TabIndex = 5;
            radTreasury.Text = "Treasury";
            radTreasury.UseVisualStyleBackColor = true;
            radTreasury.CheckedChanged += radTreasury_CheckedChanged;
            // 
            // radAccounting
            // 
            radAccounting.Appearance = Appearance.Button;
            radAccounting.AutoSize = true;
            radAccounting.Dock = DockStyle.Top;
            radAccounting.FlatAppearance.BorderSize = 0;
            radAccounting.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radAccounting.FlatStyle = FlatStyle.Flat;
            radAccounting.Location = new Point(0, 33);
            radAccounting.Margin = new Padding(0);
            radAccounting.Name = "radAccounting";
            radAccounting.Padding = new Padding(5, 4, 5, 4);
            radAccounting.Size = new Size(142, 33);
            radAccounting.TabIndex = 4;
            radAccounting.Text = "Accounting";
            radAccounting.UseVisualStyleBackColor = true;
            radAccounting.CheckedChanged += radAccounting_CheckedChanged;
            // 
            // radBudget
            // 
            radBudget.Appearance = Appearance.Button;
            radBudget.AutoSize = true;
            radBudget.Checked = true;
            radBudget.Dock = DockStyle.Top;
            radBudget.FlatAppearance.BorderSize = 0;
            radBudget.FlatAppearance.CheckedBackColor = SystemColors.Control;
            radBudget.FlatStyle = FlatStyle.Flat;
            radBudget.Location = new Point(0, 0);
            radBudget.Margin = new Padding(0);
            radBudget.Name = "radBudget";
            radBudget.Padding = new Padding(5, 4, 5, 4);
            radBudget.Size = new Size(142, 33);
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
            tabControlMain.Controls.Add(tabPageManage);
            tabControlMain.Controls.Add(tabPageReports);
            tabControlMain.Controls.Add(tabPageMyAccount);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControlMain.Location = new Point(142, 0);
            tabControlMain.Margin = new Padding(4, 3, 4, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1133, 680);
            tabControlMain.TabIndex = 2;
            tabControlMain.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageBudget
            // 
            tabPageBudget.Controls.Add(panel2);
            tabPageBudget.Controls.Add(label4);
            tabPageBudget.Location = new Point(4, 24);
            tabPageBudget.Margin = new Padding(4, 3, 4, 3);
            tabPageBudget.Name = "tabPageBudget";
            tabPageBudget.Size = new Size(1125, 652);
            tabPageBudget.TabIndex = 1;
            tabPageBudget.Text = "tabPageBudget";
            tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(ucBudget1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 80);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5, 0, 5, 5);
            panel2.Size = new Size(1125, 572);
            panel2.TabIndex = 4;
            // 
            // ucBudget1
            // 
            ucBudget1.Dock = DockStyle.Fill;
            ucBudget1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ucBudget1.Location = new Point(5, 0);
            ucBudget1.Margin = new Padding(4, 3, 4, 3);
            ucBudget1.Name = "ucBudget1";
            ucBudget1.Size = new Size(1115, 567);
            ucBudget1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Light", 20F);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 4, 5, 4);
            label4.Size = new Size(1125, 80);
            label4.TabIndex = 5;
            label4.Text = "Budget";
            // 
            // tabPageAccounting
            // 
            tabPageAccounting.Controls.Add(panel3);
            tabPageAccounting.Controls.Add(label2);
            tabPageAccounting.Location = new Point(4, 24);
            tabPageAccounting.Margin = new Padding(4, 3, 4, 3);
            tabPageAccounting.Name = "tabPageAccounting";
            tabPageAccounting.Size = new Size(1125, 652);
            tabPageAccounting.TabIndex = 2;
            tabPageAccounting.Text = "tabPageAccounting";
            tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(ucAccounting1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 80);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5, 0, 5, 5);
            panel3.Size = new Size(1125, 572);
            panel3.TabIndex = 5;
            // 
            // ucAccounting1
            // 
            ucAccounting1.Dock = DockStyle.Fill;
            ucAccounting1.Location = new Point(5, 0);
            ucAccounting1.Name = "ucAccounting1";
            ucAccounting1.Size = new Size(1115, 567);
            ucAccounting1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Light", 20F);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 4, 5, 4);
            label2.Size = new Size(1125, 80);
            label2.TabIndex = 3;
            label2.Text = "Accounting";
            // 
            // tabPageTreasury
            // 
            tabPageTreasury.Controls.Add(panel4);
            tabPageTreasury.Controls.Add(label3);
            tabPageTreasury.Location = new Point(4, 24);
            tabPageTreasury.Margin = new Padding(4, 3, 4, 3);
            tabPageTreasury.Name = "tabPageTreasury";
            tabPageTreasury.Size = new Size(1125, 652);
            tabPageTreasury.TabIndex = 3;
            tabPageTreasury.Text = "tabPageTreasury";
            tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(ucTreasury1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 80);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 0, 5, 5);
            panel4.Size = new Size(1125, 572);
            panel4.TabIndex = 5;
            // 
            // ucTreasury1
            // 
            ucTreasury1.Dock = DockStyle.Fill;
            ucTreasury1.Location = new Point(5, 0);
            ucTreasury1.Margin = new Padding(4, 3, 4, 3);
            ucTreasury1.Name = "ucTreasury1";
            ucTreasury1.Size = new Size(1115, 567);
            ucTreasury1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Light", 20F);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 4, 5, 4);
            label3.Size = new Size(1125, 80);
            label3.TabIndex = 4;
            label3.Text = "Treasury";
            // 
            // tabPageManage
            // 
            tabPageManage.Controls.Add(ucManage1);
            tabPageManage.Controls.Add(label5);
            tabPageManage.Location = new Point(4, 24);
            tabPageManage.Margin = new Padding(4, 3, 4, 3);
            tabPageManage.Name = "tabPageManage";
            tabPageManage.Size = new Size(1125, 652);
            tabPageManage.TabIndex = 4;
            tabPageManage.Text = "tabPageManage";
            tabPageManage.UseVisualStyleBackColor = true;
            // 
            // ucManage1
            // 
            ucManage1.Dock = DockStyle.Fill;
            ucManage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ucManage1.Location = new Point(0, 80);
            ucManage1.Margin = new Padding(4, 3, 4, 3);
            ucManage1.Name = "ucManage1";
            ucManage1.Size = new Size(1125, 572);
            ucManage1.TabIndex = 6;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Light", 20F);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 4, 5, 4);
            label5.Size = new Size(1125, 80);
            label5.TabIndex = 5;
            label5.Text = "Manage";
            // 
            // tabPageReports
            // 
            tabPageReports.Controls.Add(ucReports1);
            tabPageReports.Controls.Add(label1);
            tabPageReports.Location = new Point(4, 24);
            tabPageReports.Name = "tabPageReports";
            tabPageReports.Size = new Size(192, 72);
            tabPageReports.TabIndex = 5;
            tabPageReports.Text = "tabPageReports";
            tabPageReports.UseVisualStyleBackColor = true;
            // 
            // ucReports1
            // 
            ucReports1.AutoScroll = true;
            ucReports1.Dock = DockStyle.Fill;
            ucReports1.Location = new Point(0, 80);
            ucReports1.Name = "ucReports1";
            ucReports1.Padding = new Padding(4);
            ucReports1.Size = new Size(192, 0);
            ucReports1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Light", 20F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 4, 5, 4);
            label1.Size = new Size(192, 80);
            label1.TabIndex = 6;
            label1.Text = "Reports";
            // 
            // tabPageMyAccount
            // 
            tabPageMyAccount.Controls.Add(ucMyAccount1);
            tabPageMyAccount.Location = new Point(4, 24);
            tabPageMyAccount.Name = "tabPageMyAccount";
            tabPageMyAccount.Padding = new Padding(3);
            tabPageMyAccount.Size = new Size(192, 72);
            tabPageMyAccount.TabIndex = 6;
            tabPageMyAccount.Text = "tabPageMyAccount";
            tabPageMyAccount.UseVisualStyleBackColor = true;
            // 
            // ucMyAccount1
            // 
            ucMyAccount1.AutoValidate = AutoValidate.EnableAllowFocusChange;
            ucMyAccount1.Dock = DockStyle.Fill;
            ucMyAccount1.Location = new Point(3, 3);
            ucMyAccount1.Name = "ucMyAccount1";
            ucMyAccount1.Padding = new Padding(2);
            ucMyAccount1.Size = new Size(186, 66);
            ucMyAccount1.TabIndex = 8;
            // 
            // taxRatesToolStripMenuItem
            // 
            taxRatesToolStripMenuItem.Name = "taxRatesToolStripMenuItem";
            taxRatesToolStripMenuItem.Size = new Size(161, 22);
            taxRatesToolStripMenuItem.Text = "Tax Rates...";
            // 
            // discountRatesToolStripMenuItem
            // 
            discountRatesToolStripMenuItem.Name = "discountRatesToolStripMenuItem";
            discountRatesToolStripMenuItem.Size = new Size(161, 22);
            discountRatesToolStripMenuItem.Text = "Discount Rates...";
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, tlStrpWhatsNew, toolStripStatusLabel6, tlStrpLblLoggedUser, toolStripStatusLabel5, tlStrpLblServer, toolStripStatusLabel4, tlStrpLblVersion });
            statusStrip1.Location = new Point(0, 680);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1275, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(887, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // tlStrpWhatsNew
            // 
            tlStrpWhatsNew.ActiveLinkColor = SystemColors.Highlight;
            tlStrpWhatsNew.Image = Properties.Resources.loudspeaker_16px;
            tlStrpWhatsNew.IsLink = true;
            tlStrpWhatsNew.LinkBehavior = LinkBehavior.NeverUnderline;
            tlStrpWhatsNew.LinkColor = SystemColors.ControlText;
            tlStrpWhatsNew.Name = "tlStrpWhatsNew";
            tlStrpWhatsNew.Size = new Size(91, 17);
            tlStrpWhatsNew.Text = "What's New?";
            tlStrpWhatsNew.Click += tlStrpWhatsNew_Click;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.ForeColor = SystemColors.ControlDark;
            toolStripStatusLabel6.Margin = new Padding(4, 3, 4, 2);
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new Size(10, 17);
            toolStripStatusLabel6.Text = "|";
            toolStripStatusLabel6.TextAlign = ContentAlignment.TopCenter;
            // 
            // tlStrpLblLoggedUser
            // 
            tlStrpLblLoggedUser.ForeColor = SystemColors.ControlDarkDark;
            tlStrpLblLoggedUser.Name = "tlStrpLblLoggedUser";
            tlStrpLblLoggedUser.Size = new Size(89, 17);
            tlStrpLblLoggedUser.Text = "Logged User: --";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Margin = new Padding(4, 3, 4, 2);
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = ContentAlignment.TopCenter;
            // 
            // tlStrpLblServer
            // 
            tlStrpLblServer.ForeColor = SystemColors.ControlDarkDark;
            tlStrpLblServer.Name = "tlStrpLblServer";
            tlStrpLblServer.Size = new Size(55, 17);
            tlStrpLblServer.Text = "Server: --";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.ForeColor = SystemColors.ControlDarkDark;
            toolStripStatusLabel4.Margin = new Padding(4, 3, 4, 2);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(10, 17);
            toolStripStatusLabel4.Text = "|";
            toolStripStatusLabel4.TextAlign = ContentAlignment.TopCenter;
            // 
            // tlStrpLblVersion
            // 
            tlStrpLblVersion.ForeColor = SystemColors.ControlDarkDark;
            tlStrpLblVersion.LinkColor = Color.Black;
            tlStrpLblVersion.Name = "tlStrpLblVersion";
            tlStrpLblVersion.Size = new Size(84, 17);
            tlStrpLblVersion.Text = "Version: 0.0.0.0";
            tlStrpLblVersion.VisitedLinkColor = SystemColors.ControlDarkDark;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 702);
            Controls.Add(tabControlMain);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1291, 741);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
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
            tabPageManage.ResumeLayout(false);
            tabPageReports.ResumeLayout(false);
            tabPageMyAccount.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private System.Windows.Forms.RadioButton radManage;
        private System.Windows.Forms.TabPage tabPageManage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem taxRatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discountRatesToolStripMenuItem;
        private OmniGov.App.Budget.Views.Dashboard.ucBudget ucBudget1;
        private Treasury.ucTreasury ucTreasury1;
        private Manage.ucManage ucManage1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radReports;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Label label1;
        private Reports.ucReports ucReports1;
        private System.Windows.Forms.RadioButton radioBtnMyAccount;
        private System.Windows.Forms.TabPage tabPageMyAccount;
        private MyAccount.ucMyAccount ucMyAccount1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpWhatsNew;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpLblVersion;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpLblServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpLblLoggedUser;
        private Accounting.Views.Dashboard.ucAccounting ucAccounting1;
    }
}
