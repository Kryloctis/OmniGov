using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptPenalties
{
    public partial class ucRptPenalties : UserControl
    {
        internal int rptPenaltiesId;
        internal bool isEdit = false;

        public ucRptPenalties()
        {
            InitializeComponent();
        }

        private void LoadFrequencies() 
        {
            cmbxFrequency.Items.AddRange(new string[] { "Monthly", "Annually" });
            cmbxFrequency.SelectedIndex = 0;
        }

        internal void ResetForm()
        {
            if (isEdit)
                rptPenaltiesId = 0;

            LoadFrequencies();
            txtDescription.Clear();
            nudRate.Value = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudRate)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        #region Validations
        private bool DescriptionValidated() 
        {
            return Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = DescriptionValidated();
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
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

        private void nudRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = RateValidated();
        }

        private void nudRate_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudRate);
        }
        #endregion

        private void ucRptPenalties_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadFrequencies();
            }
        }
    }
}
