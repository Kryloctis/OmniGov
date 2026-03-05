using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using System.ComponentModel;

namespace OmniGov.App.Views.Manage.RptPenalties

{
    public partial class ucRptPenalties : UserControl

    {
        internal bool isEdit = false;
        internal int rptPenaltiesId;

        public ucRptPenalties()

        {
            InitializeComponent();
        }

        internal string GetFormErrors()

        {
            var errorArray = new string[]

            {
                errorProvider1.GetError(txtDescription),

                errorProvider1.GetError(nudRate)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()

        {
            if (isEdit)

                rptPenaltiesId = 0;

            LoadFrequencies();

            txtDescription.Clear();

            nudRate.Value = 0;
        }

        private bool DescriptionValidated()

        {
            return Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void LoadFrequencies()

        {
            cmbxFrequency.Items.AddRange(new string[] { "Monthly", "Annually" });

            cmbxFrequency.SelectedIndex = 0;
        }

        private void nudRate_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudRate);
        }

        private void nudRate_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = RateValidated();
        }

        private void OnLoad()

        {
            if (!DesignMode)

            {
                LoadFrequencies();
            }
        }

        private bool RateValidated()

        {
            bool isValidated;

            bool isZero = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudRate, "Rate");

            bool isEmpty = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudRate, "Rate");

            if (isZero || isEmpty)

                isValidated = true;
            else

                isValidated = false;

            return isValidated;
        }

        private void txtDescription_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = DescriptionValidated();
        }

        private void ucRptPenalties_Load(object sender, EventArgs e)

        {
            OnLoad();
        }
    }
}