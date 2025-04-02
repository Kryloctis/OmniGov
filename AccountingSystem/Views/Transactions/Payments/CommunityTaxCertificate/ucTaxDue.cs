using ACC.Data;
using System;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.CommunityTaxCertificate
{
    public partial class ucTaxDue : UserControl
    {
        public ucTaxDue()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(nudAdditionalBasicTax),
                errorProvider1.GetError(nudBasicTax)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            nudBasicTax.Value = 0;
            nudAdditionalBasicTax.Value = 0;
            nudGrossReceipt.Value = 0;
            nudSalary.Value = 0;
            nudIncomeFromRpt.Value = 0;
        }

        internal decimal ComputeTotalAmountPayable()
        {
            decimal totalAmountPayable = 0;

            return totalAmountPayable += nudBasicTax.Value + nudAdditionalBasicTax.Value + nudGrossReceipt.Value + nudSalary.Value + nudIncomeFromRpt.Value;

        }

        internal decimal AdditionalCommunityTaxSum()
        {
            return nudAdditionalBasicTax.Value + nudGrossReceipt.Value + nudSalary.Value + nudIncomeFromRpt.Value;
        }


        private void ucTaxDue_Load(object sender, EventArgs e)
        {

        }
    }
}
