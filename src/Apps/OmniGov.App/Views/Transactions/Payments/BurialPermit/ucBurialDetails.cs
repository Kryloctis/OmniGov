using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.Payments.BurialPermit
{
    public partial class ucBurialDetails : UserControl
    {
        public ucBurialDetails()
        {
            InitializeComponent();
        }

        internal (bool isInfectious, bool isEmbalmed, DateTime deathDate, string causeOfDeath, string cemetery, string disinterment, string disposition) GetBurialDetails()
        {
            var infectious = radInfectiousYes.Checked;
            var embalmed = radEmbalmedYes.Checked;
            var deathDate = dtDeathDate.Value;
            var causeOfDeath = txtCauseOfDeath.Text.Trim();
            var cemetery = txtCemetery.Text.Trim();
            var disinterment = txtDisinterment.Text.Trim();
            var disposition = txtDisposition.Text.Trim();

            return (infectious, embalmed, deathDate, causeOfDeath, cemetery, disinterment, disposition);
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtCauseOfDeath),
                errorProvider1.GetError(txtCemetery)
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            dtDeathDate.Value = Helper.GetCurrentDate();
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

        private void txtCauseOfDeath_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCauseOfDeath);
        }

        private void txtCauseOfDeath_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCauseOfDeath, "Cause of death.");
        }

        private void txtCemetery_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCemetery);
        }

        private void txtCemetery_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCemetery, "Cemetery");
        }
    }
}