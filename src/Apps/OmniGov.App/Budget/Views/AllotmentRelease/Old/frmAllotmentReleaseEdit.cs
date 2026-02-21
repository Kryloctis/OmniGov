using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;

namespace OmniGov.App.Budget.Views.AllotmentRelease.Old
{
    public partial class frmAllotmentReleaseEdit : Form
    {
        internal ucAllotmentReleaseMain _ucAllotmentReleaseMain;
        private ucAllotmentRelease uc;

        public frmAllotmentReleaseEdit(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _ucAllotmentReleaseMain = ucAllotmentReleaseMain;
            uc = ucAllotmentRelease1;
        }

        private void frmAllotmentReleaseEdit_Load(object sender, EventArgs e)
        {
            uc.LoadReference(_ucAllotmentReleaseMain);
        }

        private bool ChangesSaved()
        {
            try
            {
                int rowIndex = _ucAllotmentReleaseMain.dgAllotmentRelease.CurrentCell.RowIndex;
                int budgetAppropriationId = Convert.ToInt32(uc.cmbxBudgetAppropriations.SelectedValue);
                var budgetAppropriationsDict = BudgetFactory.BudgetAppropriationsRepository().GetViewRecordByID(budgetAppropriationId);
                string remarks = string.IsNullOrEmpty(budgetAppropriationsDict["remarks"].ToString()) ? string.Empty : $"({budgetAppropriationsDict["remarks"]})";
                string accountName = $"{budgetAppropriationsDict["general_ledger_accounts_name"]} {remarks}";
                string accountCode = budgetAppropriationsDict["account_code"].ToString();

                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows[rowIndex].Cells["year"].Value = uc.nudYear.Value;
                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows[rowIndex].Cells["budget_appropriation_id"].Value = uc.cmbxBudgetAppropriations.SelectedValue;
                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows[rowIndex].Cells["account_name"].Value = accountName;
                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows[rowIndex].Cells["account_code"].Value = accountCode;
                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows[rowIndex].Cells["allotment_amount"].Value = uc.nudAmount.Value;
                _ucAllotmentReleaseMain.DisplayTotalAllotmentRelease();
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
            if (ChangesSaved()) { uc.ResetForm(); Close(); }
            ;
        }
    }
}