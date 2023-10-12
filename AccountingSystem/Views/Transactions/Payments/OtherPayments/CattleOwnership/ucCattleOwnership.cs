using ACC.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        internal int ownerID;

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
                errorProvider1.GetError(cmbxSex)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

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
                HelperLoadRecords.SexComboBox(cmbxSex);
            }
        }
    }
}
