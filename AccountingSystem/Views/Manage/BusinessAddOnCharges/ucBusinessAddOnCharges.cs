using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
{
    public partial class ucBusinessAddOnCharges : UserControl
    {
        public ucBusinessAddOnCharges()
        {
            InitializeComponent();
        }

        private void ucBusinessAdOnCharges_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {

            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = errorProvider1.GetError(txtDescription);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtDescription.Clear();
            cbxAppliedToEachBusiness.Checked = false;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");

            var description = txtDescription.Text.Trim();

            if (AccFactory.BusinessAddOnChargesRepository().DescriptionExist(description))
            {
                errorProvider1.SetError(txtDescription, "Description already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }
    }
}
