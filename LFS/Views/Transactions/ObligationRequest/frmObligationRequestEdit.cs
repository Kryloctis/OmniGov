using ACC.Data;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestEdit : Form
    {
        private ucObligationRequest uc;
        private ucObligationRequestMain _ucObligationRequestMain;

        public frmObligationRequestEdit(ucObligationRequestMain ucObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
            _ucObligationRequestMain = ucObligationRequestMain;
            uc.LoadReferences(_ucObligationRequestMain);
        }

        private bool ApplyEdited()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var rowIndex = _ucObligationRequestMain.dgObligationRequests.CurrentCell.RowIndex;

                int budgetAppropriationId = Convert.ToInt32(uc.cmbxObjectOfExpenditure.SelectedValue);
                var budgetAppropriationsDict = AccFactory.BudgetAppropriationsRepository().GetViewRecordByID(budgetAppropriationId);

                string remarks = string.IsNullOrEmpty(budgetAppropriationsDict["remarks"].ToString()) ? string.Empty : $"({budgetAppropriationsDict["remarks"]})";

                string objectOfExpenditure = $"{budgetAppropriationsDict["general_ledger_accounts_name"]} {remarks}";
                string accountCode = budgetAppropriationsDict["account_code"].ToString();

                var amount = uc.nudAmount.Value;

                _ucObligationRequestMain.dgObligationRequests.Rows[rowIndex].Cells["budget_appropriation_id"].Value = budgetAppropriationId;
                _ucObligationRequestMain.dgObligationRequests.Rows[rowIndex].Cells["object_expenditure"].Value = objectOfExpenditure;
                _ucObligationRequestMain.dgObligationRequests.Rows[rowIndex].Cells["account_code"].Value = accountCode;
                _ucObligationRequestMain.dgObligationRequests.Rows[rowIndex].Cells["obligation_amount"].Value = amount;

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ApplyEdited())
            {
                Close();
            }
        }
    }
}