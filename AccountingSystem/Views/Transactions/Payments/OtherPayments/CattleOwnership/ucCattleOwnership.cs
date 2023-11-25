using ACC.Data;
using AccountingSystem.Views.Shared;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        internal int ownerID;
        internal frmCattleOwnership frmCattleOwnership;

        public ucCattleOwnership()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtOwnerName),
                errorProvider1.GetError(cmbxType),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerList(frmCattleOwnership).ShowDialog();
        }

        internal void LoadTaxpayerInfo(int taxpayerID)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);

            ownerID = taxpayerID;
            txtOwnerName.Text = dictTaxpayer["taxpayers_name"];
            cmbxProvince.Text = dictTaxpayer["taxpayers_province"];
            cmbxMunicipality.Text = dictTaxpayer["taxpayers_municipality"];
            cmbxBarangay.Text = dictTaxpayer["taxpayers_barangay"];
        }

        private void ucCattleOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }

        private void txtOwnerName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtOwnerName, "Owner Name.");
        }

        private void txtOwnerName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtOwnerName);
        }

        private void cmbxType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxType, "Cattle Type.");
        }

        private void cmbxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxType);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            tabControlOwner.SelectedTab = tabPageNewOwner;
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            tabControlOwner.SelectedTab = tabPageList;
        }
    }
}