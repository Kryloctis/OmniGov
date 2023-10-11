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

        private void txtPermission_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPermission, "Permisssion.");
        }

        private void txtPermission_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPermission);
        }

        private void cmbxRemainsSex_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxRemainsSex, "Sex.");
        }

        private void cmbxRemainsSex_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxRemainsSex);
        }

        private void txtCemetery_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCemetery, "Cemetery.");
        }

        private void txtCemetery_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCemetery);
        }

        private void txtDisinterment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDisinterment, "Disinterment.");
        }

        private void txtDisinterment_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDisinterment);
        }

        private void txtDisposition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDisposition, "Disposition.");
        }

        private void txtDisposition_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDisposition);
        }

        private void txtCauseOfDeath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCauseOfDeath, "Cause of Death.");
        }

        private void txtCauseOfDeath_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCauseOfDeath);
        }
    }
}
