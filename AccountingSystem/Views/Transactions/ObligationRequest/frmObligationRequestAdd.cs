using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestAdd : Form
    {
        private ucObligationRequestMain _ucObligationRequestMain;
        private ucObligationRequest uc;

        public frmObligationRequestAdd(ucObligationRequestMain ucObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
            _ucObligationRequestMain = ucObligationRequestMain;
            uc.LoadReferences(_ucObligationRequestMain);
        }


        private bool AddToListRecord()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                int budgetAppropriationId = Convert.ToInt32(uc.cmbxObjectOfExpenditure.SelectedValue);
                var budgetAppropriationsDict = Factory.BudgetAppropriationsRepository().GetViewRecordByID(budgetAppropriationId);

                string remarks = $"({budgetAppropriationsDict["remarks"]})";

                string objectOfExpenditure = $"{budgetAppropriationsDict["general_ledger_accounts_name"]} {remarks}";
                string accountCode = budgetAppropriationsDict["account_code"].ToString();
                decimal obligationAmount = uc.nudAmount.Value;

                var items = new object[]
                {
                    budgetAppropriationId,
                    objectOfExpenditure,
                    accountCode,
                    obligationAmount
                };

                _ucObligationRequestMain.dgObligationRequests.Rows.Add(items);
                _ucObligationRequestMain.GetTotalObligations();

                return true;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (AddToListRecord())
            {
                uc.ResetForm();
                _ucObligationRequestMain.EnableDisableComponents(false);
            }
        }

    }
}
