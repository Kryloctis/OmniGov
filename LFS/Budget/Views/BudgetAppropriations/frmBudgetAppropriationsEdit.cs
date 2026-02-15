using Budget.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Budget.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsEdit : Form
    {
        private frmBudgetAppropriations _frmBudgetAppropriations;
        private ucBudgetAppropriations uc;

        public frmBudgetAppropriationsEdit(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
            uc = ucBudgetAppropriations1;
        }

        private void LoadSelected()
        {
            try
            {
                int ucBudgetAppropriationId = uc.budgetAppropriationId;

                var selectedBudgetAppropriation = AccFactory.BudgetAppropriationsRepository().GetRecordByID(ucBudgetAppropriationId);

                int fundId = Convert.ToInt32(selectedBudgetAppropriation["funds_id"]);
                int fppId = Convert.ToInt32(selectedBudgetAppropriation["function_program_project_id"]);
                int? othersFPPId = string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_id"]) ? null : Convert.ToInt32(selectedBudgetAppropriation["others_fpp_id"]);
                int allotmentClassId = Convert.ToInt32(selectedBudgetAppropriation["allotment_classes_id"]);
                int generalLedgerAccountId = Convert.ToInt32(selectedBudgetAppropriation["general_ledger_accounts_id"]);
                DateTime dateEntry = Convert.ToDateTime(selectedBudgetAppropriation["date_entry"]);
                short year = Convert.ToInt16(selectedBudgetAppropriation["year"]);
                decimal appropriationAmount = Convert.ToDecimal(selectedBudgetAppropriation["amount"]);

                bool continuing = Convert.ToByte(selectedBudgetAppropriation["continuing"]) == 0 ? false : true;

                uc.fundId = fundId;
                uc.fppId = fppId;

                if (othersFPPId == null)
                    uc.cmbxOthersFPP.SelectedIndex = -1;
                else
                    uc.cmbxOthersFPP.SelectedValue = othersFPPId;

                uc.allotmentClassId = allotmentClassId;
                uc.cmbxAccount.SelectedValue = generalLedgerAccountId;
                uc.dtDateEntry.Value = dateEntry;
                uc.txtYear.Text = year.ToString();
                uc.year = year;
                uc.nudAmount.Value = appropriationAmount;
                uc.chckbxContinuing.Checked = continuing;
                uc.txtRemarks.Text = selectedBudgetAppropriation["remarks"];
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveData()
        {
            try
            {
                int? othersFPPId;

                //Check Validation
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.cmbxOthersFPP.SelectedValue == null)
                    othersFPPId = null;
                else
                    othersFPPId = Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);

                var budgetAppModel = new BudgetAppropriationsModel()
                {
                    Id = uc.budgetAppropriationId,
                    FundsId = uc.fundId,
                    FunctionProgramProjectId = uc.fppId,
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = uc.allotmentClassId,
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxAccount.SelectedValue),
                    DateEntry = uc.dtDateEntry.Value,
                    Year = uc.year,
                    Amount = uc.nudAmount.Value,
                    Continuing = uc.chckbxContinuing.Checked,
                    Remarks = uc.txtRemarks.Text.Trim()
                };

                return AccFactory.BudgetAppropriationsRepository().Update(budgetAppModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmBudgetAppropriationsEdit_Load(object sender, EventArgs e)
        {
            LoadSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                //Initialze data references
                int allotmentClassID = uc.allotmentClassId;
                int fundID = uc.fundId;

                string generalLedgerAccountName = uc.cmbxAccount.Text;
                string subFPP = uc.cmbxOthersFPP.Text;
                string remarks = uc.txtRemarks.Text;
                string objectOfExpenditures = $"   {generalLedgerAccountName}{(string.IsNullOrEmpty(remarks) ? string.Empty : $" → {remarks}")}";

                _frmBudgetAppropriations.cmbxAllotmentClass.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFunds.SelectedValue = fundID;

                Helper.MessageBoxSuccess("Budget Appropriation has been updated.");
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                _frmBudgetAppropriations.DatagridViewRecordFinder(_frmBudgetAppropriations.dgBudgetAppropriations, objectOfExpenditures, subFPP);
                Close();
            }
        }
    }
}