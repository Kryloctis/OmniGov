using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class ucRealignment : UserControl
    {
        public ucRealignment()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgBudgetRealignment);
        }

        private void ucRealignment_Load(object sender, EventArgs e)
        {
            LoadBudgetAppropriationAccounts();

        }

        private void LoadBudgetAppropriationAccounts()
        {
            try
            {
                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["general_ledger_accounts_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbAccount.DataSource = new BindingSource(accountDict, null);
                cmbAccount.DisplayMember = "value";
                cmbAccount.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtRealignmentAccounts;
            dtRealignmentAccounts = Factory.BudgetAppropriationsRepository().GetRecords();
            return dtRealignmentAccounts;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRealignment();
        }

        private void AddRealignment()
        {
            string budgetAppropriationId = GetBudgetIdByGeneralLedgerAccountId(cmbAccount.SelectedValue.ToString());
            string realignmentAccount = cmbAccount.GetItemText(cmbAccount.SelectedItem);
            string realignmentAmount = nudAmount.Value.ToString("N2");
            string realignmentDateEntry = dtDateIssued.Value.ToString("MM/dd/yyyy");

            object[] accountRow = new object[]
            {
                budgetAppropriationId,
                realignmentAccount,
                realignmentAmount
            };

            dgBudgetRealignment.Rows.Add(accountRow);
        }

        private string GetBudgetIdByGeneralLedgerAccountId(string generalLedgerId)
        {
            return Factory.BudgetAppropriationsRepository().GetBudgetIdByGeneralLedgerId(generalLedgerId);
        }
    }
}
