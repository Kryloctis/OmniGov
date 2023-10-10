using ACC.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    public partial class ucBurialPermit : UserControl
    {
        public ucBurialPermit()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtPermission),
                errorProvider1.GetError(txtPayer),
                errorProvider1.GetError(txtRemainsName),
                errorProvider1.GetError(cmbxRemainsSex),
                errorProvider1.GetError(dtpDeathDate),
                errorProvider1.GetError(txtCemetery),
                errorProvider1.GetError(txtDisinterment),
                errorProvider1.GetError(txtDisposition),
                errorProvider1.GetError(txtCauseOfDeath),
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void LoadTaxpayerInfo(int taxpayerId)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);

            txtPayer.Text = dictTaxpayer["taxpayers_name"];
        }

        private void ucBurialPermit_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.SexComboBox(cmbxRemainsSex);
            }
        }

        private void txtRemainsName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRemainsName, "Remains Name.");
        }

        private void txtRemainsName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRemainsName);
        }

    }
}
