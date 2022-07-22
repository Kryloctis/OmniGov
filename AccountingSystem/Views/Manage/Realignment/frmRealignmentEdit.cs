using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentEdit : Form
    {
        ucRealignment uc;
        internal string _budgetAppropriationId;
        internal string _budgetAppropriationAmount;
        internal string _budgetRealignmentId;
        internal frmRealignment _frmRealignment;
        internal frmBudgetAppropriations _frmBudgetAppropriations;

        public frmRealignmentEdit(frmRealignment frmRealignment, frmBudgetAppropriations frmBudgetAppropriation)
        {
            InitializeComponent();
            uc = ucRealignment1;

            _frmRealignment = frmRealignment;
            _frmBudgetAppropriations = frmBudgetAppropriation;
            _budgetRealignmentId = _frmRealignment.budgetRealignmentId;
        }

        private void frmRealignmentEdit_Load(object sender, EventArgs e)
        {
            LoadRealignmentAccount();
            LoadRealignmentDetails();

            uc.txtAppropriationBalance.Text = Convert.ToDecimal(_budgetAppropriationAmount).ToString("N2");

            decimal appropriation = Convert.ToDecimal(uc.txtAppropriationBalance.Text);

            uc.nudAmount.Maximum = appropriation;
            uc.nudAmount.Value = appropriation;
            uc.ComputeTotalRealignment();
        }

        private void LoadRealignmentDetails()
        {
            int realignmentId = int.Parse(_budgetRealignmentId);
            Dictionary<string, string> realignmentDict = AccFactory.BudgetRealignmentRepository().GetRecordByRealignmentId(realignmentId);


            uc.txtRemarks.Text = realignmentDict["remarks"];
            uc.dtDateIssued.Value = Convert.ToDateTime(realignmentDict["date_entry"]);
        }

        private void LoadRealignmentAccount()
        {
            int budgetRealignmentId = int.Parse(_budgetRealignmentId);

            var dtBudgetRealignment = AccFactory.BudgetRealignmentRepository().GetRealignedAccountsByRealignmentId(budgetRealignmentId);
            HelperLoadRecords.BudgetRealignmentAccountsDatagridView(dtBudgetRealignment, uc.dgBudgetRealignment);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                if (SaveRealignmentAccounts())
                {
                    _frmRealignment.LoadBudgetRealignments();
                    _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                    Helper.MessageBoxSuccess("Budget Realignment has been updated.");
                    uc.ResetForm();
                }
            }
        }

        private bool SaveRealignmentAccounts()
        {
            try
            {
                foreach (DataGridViewRow item in uc.dgBudgetRealignment.Rows)
                {
                    string account = item.Cells["to_budget"].Value.ToString();
                    decimal amount = Convert.ToDecimal(item.Cells["amount"].Value.ToString());
                    int realignmentId = int.Parse(_budgetRealignmentId);
                    int toBudgetId = int.Parse(item.Cells["to_budget_appropriations_id"].Value.ToString());

                    var budgetRealignmentModel = new BudgetRealignmentModel()
                    {
                        ToBudgetAppropriationId = toBudgetId,
                        RealignmentId = realignmentId,
                        Amount = amount
                    };

                    AccFactory.BudgetRealignmentRepository().InsertRealignment(budgetRealignmentModel);
                }

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool UpdateRealignmentAccount()
        {
            int realignmentId = int.Parse(_budgetRealignmentId);
            DateTime dateIssued = uc.dtDateIssued.Value;
            string remarks = uc.txtRemarks.Text;

            var realignmentModel = new BudgetRealignmentModel()
            {
                RealignmentId = realignmentId,
                DateEntry = dateIssued,
                Remarks = remarks
            };

            var isAccountUpdateSuccess =  AccFactory.BudgetRealignmentRepository().RemoveRealignmentAccounts(realignmentId);

            var isDetailUpdateSuccess = AccFactory.BudgetRealignmentRepository().Update(realignmentModel);

            return isAccountUpdateSuccess && isDetailUpdateSuccess;

        }


        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            using (TransactionScope scope = new TransactionScope())
            {
                bool updated = true;

                try
                {
                    if (!UpdateRealignmentAccount())
                    {
                        return false;
                    }
                    
                    if (updated == true)
                    {
                        scope.Complete();
                        return true;
                    }
                    else
                        throw new TransactionAbortedException();

                }
                catch (TransactionAbortedException ex)
                {
                    Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
                    updated = false;
                }
                catch (ApplicationException ex)
                {
                    Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
                    updated = false;
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
                    updated = false;
                }
                return false;
            }

        }

    }
}
