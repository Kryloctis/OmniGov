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

namespace AccountingSystem.Views.Manage.BusinessCategories
{
    public partial class ucBusinessCategories : UserControl
    {


        internal int businessCategoryID = 0;
        public ucBusinessCategories()
        {
            InitializeComponent();
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
            txtOrdinanceReferenceNo.Clear();
            txtDescription.Clear();
            cbxLineOfBusiness.Checked = false;
            txtCode.Focus();
        }

        private void ucBusinessCategories_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
           e.Cancel=   Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }
    }
}
