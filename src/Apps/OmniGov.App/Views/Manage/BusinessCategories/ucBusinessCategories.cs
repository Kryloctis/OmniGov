using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.BusinessCategories
{
    public partial class ucBusinessCategories : UserControl
    {
        internal int businessCategoryID;
        internal bool isEdit;

        public ucBusinessCategories()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDescription)
        };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtOrdinanceReferenceNo.Clear();
            txtDescription.Clear();
            cbxLineOfBusiness.Checked = false;
            txtCode.Focus();
        }

        private bool DescriptionValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool descriptionExist;
            descriptionExist = isEdit ? TreasuryFactory.BusinessCategoriesRepository().DescriptionExist(businessCategoryID, textBox.Text.Trim()) : TreasuryFactory.BusinessCategoriesRepository().DescriptionExist(textBox.Text.Trim());

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Description"))
                return false;
            else if (descriptionExist)
            {
                errorProvider.SetError(textBox, "Description exist on your record");
                return false;
            }
            else
                return true;
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !DescriptionValidated(errorProvider1, txtDescription);
        }

        private void ucBusinessCategories_Load(object sender, EventArgs e)
        {
        }
    }
}