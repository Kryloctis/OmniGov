using ACC.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class ucBurialDetails : UserControl
    {
        public ucBurialDetails()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            dtDeathDate.Value = Helper.GetCurrentDate();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtCauseOfDeath),
                errorProvider1.GetError(txtCemetery)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            dtDeathDate.Value = Helper.GetCurrentDate();
            txtCauseOfDeath.Clear();
            txtCemetery.Clear();
            txtDisposition.Clear();
            txtDisinterment.Clear();
            radInfectiousNo.Checked = true;
            radEmbalmedYes.Checked = true;
        }

        private void txtCauseOfDeath_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCauseOfDeath, "Cause of death.");
        }

        private void txtCauseOfDeath_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCauseOfDeath);
        }

        private void txtCemetery_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCemetery, "Cemetery");
        }

        private void txtCemetery_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCemetery);
        }
    }
}