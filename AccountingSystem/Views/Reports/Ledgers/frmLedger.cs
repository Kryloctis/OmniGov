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
                    tabControlLedger.SelectedTab = tabPageGeneralLedger;
                    radioGeneralLedger.Image = Properties.Resources.ok14px;
                    break;

                case "2":
                    tabControlLedger.SelectedTab = tabPageSubsidiaryLedger;
                    radioSubsidiaryLedger.Image = Properties.Resources.ok14px;
                    break;

                case "3":
                    //Show Transaction Log form.
                    radioTransactionLog.Image = Properties.Resources.ok14px;
                    break;
                default:
                    break;
            }
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
