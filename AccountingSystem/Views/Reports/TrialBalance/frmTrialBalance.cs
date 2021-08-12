using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.TrialBalance
{
    public partial class frmTrialBalance : Form
    {
        public frmTrialBalance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmTrialBalance_Load(object sender, EventArgs e)
        {

            var preTrial = new frmPreClosingTrialBalance() {
                TopLevel = false,
                TopMost = true,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            tabPagePreTrial.Controls.Add(preTrial);
            tabPagePostTrial.Controls.Add(preTrial);
        }

        private void ChangePanelDisplayForm()
        {
            if (radioPreTB.Checked)
            {
                tabTrialBalance.SelectedTab = tabPagePreTrial;
                radioPreTB.Image = Properties.Resources.ok14px;
                radioPostTB.Image = null;
            }
            else
            {
                tabTrialBalance.SelectedTab = tabPagePostTrial;
                radioPostTB.Image = Properties.Resources.ok14px;
                radioPreTB.Image = null;

            }
        }

        private void radioPostTB_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm();
        }

        private void radioPreTB_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm();
        }

    }
}
