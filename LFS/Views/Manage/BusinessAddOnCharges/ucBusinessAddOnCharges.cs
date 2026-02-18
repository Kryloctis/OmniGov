using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.BusinessAddOnCharges
{
    public partial class ucBusinessAddOnCharges : UserControl
    {
        internal bool isEdit = false;
        internal int id;

        public ucBusinessAddOnCharges()
        {
            InitializeComponent();
        }

        private void ucBusinessAdOnCharges_Load(object sender, EventArgs e)
        {
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
            txtDescription.Clear();
            cbxAppliedToEachBusiness.Checked = false;
        }

        private bool IsDescriptionValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool descriptionExist = isEdit ? TreasuryFactory.BusinessAddOnChargesRepository().DescriptionExist(id, textBox.Text.Trim()) : TreasuryFactory.BusinessAddOnChargesRepository().DescriptionExist(textBox.Text.Trim());

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Description"))
                return false;
            else if (descriptionExist)
            {
                errorProvider.SetError(textBox, "Description exist in your records.");
                return false;
            }
            else
                return true;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !IsDescriptionValidated(errorProvider1, txtDescription);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }
    }
}

