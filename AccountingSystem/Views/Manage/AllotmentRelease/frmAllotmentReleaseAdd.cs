using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseAdd : Form
    {
        internal ucAllotmentReleaseMain _ucAllotmentReleaseMain;

        public frmAllotmentReleaseAdd(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            InitializeComponent();
            _ucAllotmentReleaseMain = ucAllotmentReleaseMain;
        }

        private void frmAllotmentReleaseAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private bool ShowErrorAppropriationExistOnList()
        {
            try
            {
                var uc = ucAllotmentRelease1;
                int budgetAppropriationId = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
;
                foreach (DataGridViewRow row in _ucAllotmentReleaseMain.dgAllotmentRelease.Rows)
                {
                    int rowBudgetAppropriationId = Convert.ToInt32(row.Cells["budget_appropriation_id"]);
                    bool budgetAppropriationIdExist = rowBudgetAppropriationId == budgetAppropriationId? true : false ;

                    if (budgetAppropriationIdExist)
                    {
                        uc.epAccount.SetError(uc.groupBox1, "Account is already on the list.");
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AddAllotmentRelease() 
        {
            try
            {
                var uc = ucAllotmentRelease1;

                if (!uc.ValidateChildren() || !string.IsNullOrEmpty(uc.epAccount.GetError(uc.groupBox1))) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                int budgetAppropriationId = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
                int fppId = Convert.ToInt32(_ucAllotmentReleaseMain.cmbxFPP.SelectedValue);
                int? othersFPPId = string.IsNullOrEmpty(_ucAllotmentReleaseMain.cmbxOthersFPP.Text) ? null : Convert.ToInt32(_ucAllotmentReleaseMain.cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(_ucAllotmentReleaseMain.allotmentClassId);

                var budgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);
                int genLedgerAccId = Convert.ToInt32(budgetAppropriationInfo["general_ledger_accounts_id"]);

                var viewBudgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationId, fppId, othersFPPId, allotmentClassId, genLedgerAccId);

                string accountName = uc.cmbxAccount.Text;
                string accountCode = viewBudgetAppropriationInfo["account_code"].ToString();
                decimal amount = uc.nudAmount.Value;

                _ucAllotmentReleaseMain.dgAllotmentRelease.Rows.Add(new object[] {  
                    budgetAppropriationId,
                    accountName,
                    accountCode,
                    amount});


                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddAllotmentRelease()) 
            {
                Close();
                _ucAllotmentReleaseMain.panel1.Enabled = false;
            }
        }
    }
}
