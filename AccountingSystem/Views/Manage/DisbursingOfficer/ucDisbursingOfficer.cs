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

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class ucDisbursingOfficer : UserControl
    {
        public ucDisbursingOfficer()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epFirstName.GetError(txtFirstName);
            errorArray[1] = epMidInitial.GetError(txtMidInitial);
            errorArray[2] = epLastName.GetError(txtLastName);
            errorArray[3] = epJobTitle.GetError(txtJobTitle);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtFirstName.Clear();
            txtMidInitial.Clear();
            txtLastName.Clear();
            txtJobTitle.Clear();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFirstName, txtFirstName, lblFirstName.Text);
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFirstName, txtFirstName);
        }

        private void txtMidInitial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epMidInitial, txtMidInitial, lblMidInitial.Text);
        }

        private void txtMidInitial_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epMidInitial, txtMidInitial);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epLastName, txtLastName, lblLastName.Text);
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epLastName, txtLastName);
        }

        private void txtJobTitle_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epJobTitle, txtJobTitle, lblJobTitle.Text);
        }

        private void txtJobTitle_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epJobTitle, txtJobTitle);
        }
    }
}
