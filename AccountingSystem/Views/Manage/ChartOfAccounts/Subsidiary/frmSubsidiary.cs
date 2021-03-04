using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary
{
    public partial class frmSubsidiary : Form
    {
        private ushort generalLedgerId;

        public frmSubsidiary(ushort _generalLedgerId)
        {
            InitializeComponent();
            generalLedgerId = _generalLedgerId;
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
        }

        private void LoadSelectedRecord()
        {
            var data = Factory.GeneralLedgerAccountsRepository().GetRecordByID(generalLedgerId);
            txtCode.Text = data["ledger_code"];
            txtAccount.Text = data["ledger_name"];
        }

        internal void LoadSubsidiaryRecordsByFundAndGeneralLedger(byte fundId)
        {
            try
            {
                var dtSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);
                HelperLoadRecords.SubsidiaryLedgerAccountsDatagridView(dtSubsidiary, dgSubsidiary);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmSubsidiary_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgSubsidiary);
            LoadFunds();
            LoadSelectedRecord();
            LoadSubsidiaryRecordsByFundAndGeneralLedger(1);
        }

        private void dgSubsidiary_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgSubsidiary, btnEdit, btnDelete);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            byte fundId = Convert.ToByte(cmbFund.SelectedValue);
            _ = new frmSubsidiaryAdd(this, fundId, generalLedgerId).ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmbFund_SelectionChangeCommitted(object sender, EventArgs e)
        {
            byte fundId = Convert.ToByte(cmbFund.SelectedValue);
            LoadSubsidiaryRecordsByFundAndGeneralLedger(fundId);
        }
    }
}
