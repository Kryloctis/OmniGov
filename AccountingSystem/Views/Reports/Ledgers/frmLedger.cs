using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class frmLedger : Form
    {
        public frmLedger()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void ChangePanelDisplayForm(string radioSelected)
        {

            radioGeneralLedger.Image = null;
            radioSubsidiaryLedger.Image = null;
            radioTransactionLog.Image = null;

            switch (radioSelected)
            {
                case "1":
                    ShowGeneralLedger();
                    radioGeneralLedger.Image = Properties.Resources.ok14px;
                    break;

                case "2":
                    ShowSubsidiaryLedger();
                    radioSubsidiaryLedger.Image = Properties.Resources.ok14px;
                    break;

                case "3":
                    ShowTransactionLog();
                    radioTransactionLog.Image = Properties.Resources.ok14px;
                    break;
                default:
                    break;
            }
        }

        private void ShowTransactionLog()
        {
            panelReport.Controls.Clear();
        }

        private void ShowSubsidiaryLedger()
        {
            var frmSubsidiaryLedger = new frmSubsidiaryLedgerReport
            {
                TopLevel = false,
                AutoScroll = true
            };

            panelReport.Controls.Add(frmSubsidiaryLedger);
            frmSubsidiaryLedger.Show();
        }

        private void ShowGeneralLedger()
        {
            var frmGeneralLEdger = new frmGeneralLedgerReport
            {
                TopLevel = false,
                AutoScroll = true
            };

            panelReport.Controls.Add(frmGeneralLEdger);
            frmGeneralLEdger.Show();
        }

        private void radioGeneralLedger_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm(radioGeneralLedger.Tag.ToString());
        }

        private void radioSubsidiaryLedger_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm(radioSubsidiaryLedger.Tag.ToString());
        }

        private void radioTransactionLog_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm(radioTransactionLog.Tag.ToString());
        }

        private void frmLedger_Load(object sender, EventArgs e)
        {
            ChangePanelDisplayForm(radioGeneralLedger.Tag.ToString());
        }
    }
}
