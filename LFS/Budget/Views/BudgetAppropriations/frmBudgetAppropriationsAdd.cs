using Budget.Data;
using Budget.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Budget.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsAdd : Form
    {
        private frmBudgetAppropriations _frmBudgetAppropriations;
        private ucBudgetAppropriations uc;

        public frmBudgetAppropriationsAdd(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
            uc = ucBudgetAppropriations1;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = uc.fundId,
                    FunctionProgramProjectId = uc.fppId,
                    OthersFPPId = uc.cmbxOthersFPP.SelectedValue == null ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue),
                    AllotmentClassesId = uc.allotmentClassId,
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxAccount.SelectedValue),
                    Year = uc.year,
                    DateEntry = uc.dtDateEntry.Value,
                    Amount = uc.nudAmount.Value,
                    Continuing = uc.chckbxContinuing.Checked,
                    Remarks = uc.txtRemarks.Text.Trim()
                };

                return BudgetFactory.BudgetAppropriationsRepository().Insert(budgetAppropriationsModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                string generalLedgerAccountName = uc.cmbxAccount.Text;
                string remarks = uc.txtRemarks.Text;
                string objectOfExpenditures = $"   {generalLedgerAccountName}{(string.IsNullOrEmpty(remarks) ? string.Empty : $" ? {remarks}")}";
                string subFPP = uc.cmbxOthersFPP.Text;
                int allotmentClassID = uc.allotmentClassId;
                int fundID = uc.fundId;

                _frmBudgetAppropriations.cmbxAllotmentClass.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFunds.SelectedValue = fundID;

                //Reset User Control Form
                uc.cmbxAccount.SelectedIndex = -1;
                uc.nudAmount.Value = 0;

                Helper.MessageBoxSuccess("Budget Appropriation has been saved.");
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();

                _frmBudgetAppropriations.DatagridViewRecordFinder(_frmBudgetAppropriations.dgBudgetAppropriations, objectOfExpenditures, subFPP);
            }
        }
    }
}
