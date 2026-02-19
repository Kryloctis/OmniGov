using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Transactions.Payments.CommunityTaxCertificate
{
    public partial class ucTaxPayerDetails : UserControl
    {
        public ucTaxPayerDetails()
        {
            InitializeComponent();
            nudYear.Maximum = DateTime.Now.Year;
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtLastName)
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        private void ucTaxPayerDetails_Load(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        internal void ResetForm()
        {
            nudYear.Value = DateTime.Now.Year;
            txtPlaceOfIssue.Clear();
            dtpDateOfIssued.Value = DateTime.Now.Date;
            txtTIN.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtAddress.Clear();
            radMale.Checked = true;
            txtCitizenship.Clear();
            txtICR.Clear();
            txtPlaceOfBirth.Clear();
            radSingle.Checked = true;
            dtpDateOfBirth.Value = DateTime.Now.Date;
            nudHeight.Value = 0;
            nudWeight.Value = 0;
            txtOccupation.Clear();
        }
    }
}