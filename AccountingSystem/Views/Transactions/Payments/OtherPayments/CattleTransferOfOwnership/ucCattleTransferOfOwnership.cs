using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    public partial class ucCattleTransferOfOwnership : UserControl
    {
        internal int oldOwnerID;
        internal frmPayments _frmPayments;
        internal bool searchPanelVisible = false;

        public ucCattleTransferOfOwnership()
        {
            InitializeComponent();
        }

        internal void LoadOldOwnerInfo(int taxpayerID)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);

            txtCattleOldOwner.Text = dictTaxpayer["taxpayers_name"];
            oldOwnerID = Convert.ToInt32(dictTaxpayer["taxpayers_id"]);
        }

        private void ucCattleTransferOfOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.SexComboBox(cmbxSex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayerList(null, null, null, null, _frmPayments).ShowDialog();
        }

        private void linkSearch_Click(object sender, EventArgs e)
        {
            if (!searchPanelVisible)
            {
                panel1Control.BringToFront();
                searchPanelVisible = true;
            }
            else
            {
                panel1Control.SendToBack();
                searchPanelVisible = false;
            }
        }
    }


}
