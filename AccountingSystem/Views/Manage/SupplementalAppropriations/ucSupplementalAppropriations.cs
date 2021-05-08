using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class ucSupplementalAppropriations : UserControl
    {
        internal int supplementalAppropriationId;
        internal int budgetAppropriationId;
        internal DateTime dateEntry;

        public ucSupplementalAppropriations()
        {
            InitializeComponent();
        }

        internal void ResetForm() 
        {
            nudAmount.Value = 0;
            txtRemarks.Text = string.Empty;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];

            errorArray[0] = epAmount.GetError(nudAmount);
            errorArray[1] = epRemarks.GetError(txtRemarks);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool AmountIsZero() 
        {
            try
            {
                if (nudAmount.Value == 0 && !string.IsNullOrEmpty(nudAmount.Text)) 
                {
                    epAmount.SetError(nudAmount, "Valuable amount is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else
                e.Cancel = AmountIsZero();

        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epRemarks, txtRemarks, "Remarks");
        }

        private void txtRemarks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epRemarks, txtRemarks);
        }

        private void ucSupplementalAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                dtDateEntry.MinDate = dateEntry;
            }
        }
    }
}
