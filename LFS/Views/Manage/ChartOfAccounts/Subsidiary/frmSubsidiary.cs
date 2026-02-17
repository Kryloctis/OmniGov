using Accounting.Data;
using Accounting.Domain.Entities;
using LFS.Helpers;
using LFS.Views.Manage.BeginningBalances;
using LFS.Views.Manage.ChartOfAccounts.BeginningBalances;
using MySql.Data.MySqlClient;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts.Subsidiary
{
    public partial class frmSubsidiary : Form
    {
        internal byte fundId;
        internal short year;
        private readonly ushort generalLedgerId;
        private frmChartOfAccounts _frmChartOfAccounts;

        public frmSubsidiary(frmChartOfAccounts frmChartOfAccounts, byte fundId, ushort _generalLedgerId, short year)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;

            this.fundId = fundId;
            generalLedgerId = _generalLedgerId;
            this.year = year;
        }

        private void LoadSelectedGeneralLedger()
        {
            var dictGeneralLedger = AccountingFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
            txtCode.Text = dictGeneralLedger["ledger_code"];
            txtAccount.Text = dictGeneralLedger["ledger_name"];
        }

        internal void LoadSubsidiaryRecordsByFundAndGeneralLedger()
        {
            var dtSubsidiary = AccountingFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);
            HelperLoadRecords.SubsidiaryLedgerAccountsDatagridView(dtSubsidiary, dgSubsidiary, fundId, year);
        }

        private void OnLoad()
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgSubsidiary, true);
            LoadSelectedGeneralLedger();
            LoadSubsidiaryRecordsByFundAndGeneralLedger();
            var dtFunds = Factory.FundsRepository().GetRecordByID(fundId);
            txtFund.Text = dtFunds["fund_name"].ToString();
            txtYear.Text = year.ToString();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSetBalance.Enabled = false;
            EnableDisableButtons();
        }

        private void frmSubsidiary_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void EnableDisableButtons()
        {
            Helper.EnableDisableToolStripButtons(dgSubsidiary, btnEdit, btnDelete);

            if (dgSubsidiary.SelectedRows.Count == 1)
            {
                btnSetBalance.Enabled = true;
                return;
            }

            btnSetBalance.Enabled = false;
        }

        private void dgSubsidiary_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmSubsidiaryAdd(this, fundId, generalLedgerId).ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgSubsidiary.SelectedRows.Count == 1)
                {
                    ushort subsidiaryLedgerId = Convert.ToUInt16(dgSubsidiary.SelectedCells[0].Value);

                    _ = new frmSubsidiaryEdit(this, fundId, generalLedgerId, subsidiaryLedgerId).ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgSubsidiary.SelectedRows.Count;

            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var subsidiaryModelList = new List<SubsidiaryLedgerAccountsModel>();
                    foreach (DataGridViewRow row in dgSubsidiary.SelectedRows)
                    {
                        int subsidiaryLedgerId = Convert.ToInt16(row.Cells[0].Value.ToString());
                        subsidiaryModelList.Add(new SubsidiaryLedgerAccountsModel() { Id = subsidiaryLedgerId });
                    }

                    return AccountingFactory.SubsidiaryLedgerAccountsRepository().Delete(subsidiaryModelList);
                }
            }
            return false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadSubsidiaryRecordsByFundAndGeneralLedger();
            }
            catch (MySqlException mysqlEx)
            {
                switch (mysqlEx.Number)
                {
                    case 1451:
                        Helper.MessageBoxError("Cannot delete this record. It is referenced by atleast one record.");
                        break;

                    default:
                        Helper.MessageBoxError(mysqlEx.Message);
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnSetBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgSubsidiary.SelectedRows.Count == 1)
                {
                    ushort subsidiaryLedgerId = Convert.ToUInt16(dgSubsidiary.SelectedCells[0].Value);

                    var subsidiaryLedgerBalanceExist = AccountingFactory.BeginningBalancesRepository().SubsidiaryLedgerBalanceExist(fundId, generalLedgerId, year, subsidiaryLedgerId);

                    if (subsidiaryLedgerBalanceExist)
                    {
                        _ = new frmBeginningBalanceEdit(_frmChartOfAccounts, this, fundId, generalLedgerId, year, subsidiaryLedgerId).ShowDialog();
                        return;
                    }

                    _ = new frmBeginningBalanceAdd(_frmChartOfAccounts, this, fundId, generalLedgerId, year, subsidiaryLedgerId).ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

