using ACC.Data;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseAdd : Form
    {
        internal ucAllotmentReleaseMain _ucAllotmentReleaseMain;
        private ucAllotmentRelease uc;

        public frmAllotmentReleaseAdd(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            InitializeComponent();
            this._ucAllotmentReleaseMain = ucAllotmentReleaseMain;
            uc = ucAllotmentRelease1;
            Helper.LoadFormIcon(this);
        }

        private void frmAllotmentReleaseAdd_Load(object sender, EventArgs e)
        {
            uc.LoadReference(_ucAllotmentReleaseMain);
        }

        private bool AddAllotmentRelease()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                int budgetAppropriationId = Convert.ToInt32(uc.cmbxBudgetAppropriations.SelectedValue);
                var budgetAppropriationsDict = AccFactory.BudgetAppropriationsRepository().GetViewRecordByID(budgetAppropriationId);

                string remarks = string.IsNullOrEmpty(budgetAppropriationsDict["remarks"].ToString()) ? string.Empty : $"({budgetAppropriationsDict["remarks"]})";
                string accountName = $"{budgetAppropriationsDict["general_ledger_accounts_name"]} {remarks}";
                string accountCode = budgetAppropriationsDict["account_code"].ToString();
                decimal amount = uc.nudAmount.Value;
                short year = (short)uc.nudYear.Value;

                var items = new object[]
                {
                    year,
                    budgetAppropriationId,
                    accountName,
                    accountCode,
                    amount
                };

                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows.Add(items);
                _ucAllotmentReleaseMain.DisplayTotalAllotmentRelease();
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnAddToList_Click(object sender, EventArgs e)
        {
            if (AddAllotmentRelease())
            {
                _ucAllotmentReleaseMain.panel1.Enabled = false;
                _ucAllotmentReleaseMain.dtDateIssued.Enabled = false;
                uc.ResetForm();
            }
        }
    }
}