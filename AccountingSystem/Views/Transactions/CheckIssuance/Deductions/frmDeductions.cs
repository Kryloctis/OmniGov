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

namespace AccountingSystem.Views.Transactions.CheckIssuance.Deductions
{
    public partial class frmDeductions : Form
    {

        DataTable dtObligations = new();

        

        public frmDeductions()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgDeductions);
        }

        private void frmDeductions_Load(object sender, EventArgs e)
        {
            CreateDatagridColumn();
        }

        private void CreateDatagridColumn() 
        {
            dtObligations.Columns.Add("Description");
            dtObligations.Columns.Add("Amount");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epDescription.GetError(txtDescription);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epDescription, txtDescription, "Description.");
        }
        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epDescription, txtDescription);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount.");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }
        #endregion

    }
}
