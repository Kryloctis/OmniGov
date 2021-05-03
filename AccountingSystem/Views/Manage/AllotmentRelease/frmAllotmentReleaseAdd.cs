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
        internal ucAllotmentReleaseMain ucAllotmentReleaseMain;
        private ucAllotmentRelease uc;

        public frmAllotmentReleaseAdd(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            InitializeComponent();
            this.ucAllotmentReleaseMain = ucAllotmentReleaseMain;
            uc = ucAllotmentRelease1;
            Helper.LoadFormIcon(this);
        }

        private void frmAllotmentReleaseAdd_Load(object sender, EventArgs e)
        {
            uc.LoadReference(ucAllotmentReleaseMain);
        }

        private bool AddAllotmentRelease()
        {
            try
            {
                if (!uc.ValidateChildren() || uc.AllotmentReleaseExist())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                int budgetAppropriationId = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
                int fppId = Convert.ToInt32(ucAllotmentReleaseMain.cmbxFPP.SelectedValue);
                int? othersFPPId = string.IsNullOrEmpty(ucAllotmentReleaseMain.cmbxOthersFPP.Text) ? null : Convert.ToInt32(ucAllotmentReleaseMain.cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(ucAllotmentReleaseMain.allotmentClassId);

                var budgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);
                int genLedgerAccId = Convert.ToInt32(budgetAppropriationInfo["general_ledger_accounts_id"]);

                var viewBudgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationId, fppId, othersFPPId, allotmentClassId, genLedgerAccId);

                string accountName = uc.cmbxAccount.Text;
                string accountCode = viewBudgetAppropriationInfo["account_code"].ToString();
                decimal amount = uc.nudAmount.Value;

                ucAllotmentReleaseMain.dgAllotmentRelease.Rows.Add(new object[] {
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
                ucAllotmentReleaseMain.panel1.Enabled = false;
            }
        }
    }
}
