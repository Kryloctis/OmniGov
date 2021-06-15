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
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                short year = (short)uc.nudYear.Value;
                int accountId = Convert.ToInt32(uc.cmbxBudgetAppropriations.SelectedValue);

                var budgetAppropriationRepo = Factory.BudgetAppropriationsRepository().GetViewRecord(uc.fppID, uc.othersFPPId, uc.fundId, uc.allotmentClassId, accountId, uc.dateIssued, year);

                int budgetAppropriationId = Convert.ToInt32(budgetAppropriationRepo["id"]);

                string accountName = budgetAppropriationRepo["general_ledger_accounts_name"];
                string accountCode = budgetAppropriationRepo["account_code"].ToString();
                decimal amount = uc.nudAmount.Value;

                ucAllotmentReleaseMain.dgAllotmentRelease.Rows.Add(new object[]
                {
                    budgetAppropriationId,
                    accountId,
                    accountCode,
                    accountName,
                    amount
                });

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
                ucAllotmentReleaseMain.panel1.Enabled = false;
                ucAllotmentReleaseMain.dtDateIssued.Enabled = false;
            }
        }
    }
}
