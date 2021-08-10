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
            ChangePanelDisplayForm();
        }

        private void ChangePanelDisplayForm()
        {
            if (radioPreTB.Checked)
            {
                ShowPreTrialBalance();
                radioPreTB.Image = Properties.Resources.ok14px;
                radioPostTB.Image = null;
            }

            else
            {
                ShowPostTrialBalance();
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

        private void ShowPostTrialBalance()
        {
            var frmPostTrialBalance = new frmPostClosingTrialBalance
            {
                TopLevel = false,
                AutoScroll = true
            };

            panelReport.Controls.Add(frmPostTrialBalance);
            frmPostTrialBalance.Show();
        }

        private void ShowPreTrialBalance()
        {
            var frmPreTrialBalance = new frmPreClosingTrialBalance
            {
                TopLevel = false,
                AutoScroll = true
            };

            panelReport.Controls.Add(frmPreTrialBalance);
            frmPreTrialBalance.Show();
        }


    }
}
