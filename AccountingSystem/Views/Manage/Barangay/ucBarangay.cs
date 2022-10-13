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

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class ucBarangay : UserControl
    {
        public ucBarangay()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = errorProvider1.GetError(txtCode);
            errorArray[1] = errorProvider1.GetError(txtBarangay);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtBarangay.Clear();
            txtCode.Focus();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Barangay Code");
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {

        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBarangay, "Barangay Name");
        }

        private void ucBarangay_Load(object sender, EventArgs e)
        {
  
        }
    }
}
