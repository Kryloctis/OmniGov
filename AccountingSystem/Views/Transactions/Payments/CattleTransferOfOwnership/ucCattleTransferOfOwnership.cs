using ACC.Data;
using AccountingSystem.Views.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    public partial class ucCattleTransferOfOwnership : UserControl
    {
        internal int cattleID;
        internal int oldOwnerID;
        internal int newOwnerID;
        internal frmPaymentRpt _frmPayments;

        public ucCattleTransferOfOwnership()
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgCattle, false);
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
            _ = new frmTaxPayerList(_frmPayments).ShowDialog();
        }

        private void linkSearch_Click(object sender, EventArgs e)
        {
            panel1Control.SendToBack();
            txtSearch.Focus();
            LoadCattleByOwnerID();
        }

        private void LoadCattleByOwnerID()
        {
            int ownerID = oldOwnerID;
            string searchKey = txtSearch.Text.Trim();
            DataTable dtCattle = AccFactory.CattleOwnershipRepository().GetRecordsByIDAndSearch(ownerID, searchKey);
            HelperLoadRecords.CattleDatagridView(dgCattle, dtCattle);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1Control.BringToFront();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCattleByOwnerID();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgCattle.Rows.Count == 0)
                return;

            int rowIndex = dgCattle.CurrentRow.Index;

            cattleID = Convert.ToInt32(dgCattle.Rows[rowIndex].Cells["id"].Value);
            var cattleType = dgCattle.Rows[rowIndex].Cells["cattle_type"].Value.ToString();
            var cattleAge = dgCattle.Rows[rowIndex].Cells["cattle_age"].Value.ToString();
            var cattleSex = dgCattle.Rows[rowIndex].Cells["cattle_sex"].Value.ToString();
            var cattleDescription = dgCattle.Rows[rowIndex].Cells["description"].Value.ToString();

            cmbxCattleType.Text = cattleType;
            nudCattleAge.Text = cattleAge;
            cmbxSex.Text = cattleSex;
            txtCattleDescription.Text = cattleDescription;
            panel1Control.BringToFront();
        }
    }
}