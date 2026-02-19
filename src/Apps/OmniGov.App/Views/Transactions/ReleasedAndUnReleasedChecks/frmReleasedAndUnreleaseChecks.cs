using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.Data;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.ReleasedAndUnReleasedChecks
{
    public partial class frmReleasedAndUnreleaseChecks : Form
    {
        private DataTable releasedAndUnreleasedDT;

        public frmReleasedAndUnreleaseChecks()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReleasedAndUnreleaseCheques, false);
        }

        private void frmReleasedAndUnreleaseChecks_Load(object sender, EventArgs e)
        {
            cmbxBank.SelectedValueChanged -= new EventHandler(cmbxBank_SelectedValueChanged);
            cmbxBankAccountNo.SelectedValueChanged -= new EventHandler(cmbxBankAccountNo_SelectedValueChanged);
            cmbxFund.SelectedValueChanged -= new EventHandler(cmbxFund_SelectedValueChanged);

            LoadBanks();
            LoadFunds();
            LoadChecks();

            cmbxBank.SelectedValueChanged += new EventHandler(cmbxBank_SelectedValueChanged);
            cmbxBankAccountNo.SelectedValueChanged += new EventHandler(cmbxBankAccountNo_SelectedValueChanged);
            cmbxFund.SelectedValueChanged += new EventHandler(cmbxFund_SelectedValueChanged);
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = TreasuryFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbxBank.DataSource = dtBank;
                cmbxBank.ValueMember = "id";
                cmbxBank.DisplayMember = "bank_name";
                LoadBankAccounts();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBank.SelectedValue);
            DataTable dtBankAccounts = TreasuryFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbxBankAccountNo.DataSource = dtBankAccounts;
            cmbxBankAccountNo.ValueMember = "id";
            cmbxBankAccountNo.DisplayMember = "account_no";
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "id", "fund_name");
        }

        private void cmbxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }

        internal void LoadChecks()
        {
            string txtSeach = txtSearch.Text;
            int bankAccountID = Convert.ToInt32(cmbxBankAccountNo.SelectedValue);
            int fundsID = Convert.ToInt32(cmbxFund.SelectedValue);

            var releasedChequesRepo = TreasuryFactory.ReleasedChequesRepository();
            var dtViewReleasedCheques = releasedChequesRepo.GetViewRecords(bankAccountID, fundsID, txtSeach, cbxShowReleasedChecks.Checked);

            releasedAndUnreleasedDT = new DataTable();
            releasedAndUnreleasedDT.Columns.AddRange(ReleasedAndUnreleaseChequesColumn());

            foreach (DataRow row in dtViewReleasedCheques.Rows)
            {
                var newRow = releasedAndUnreleasedDT.NewRow();

                string id = row["rci_id"].ToString();
                string chquesID = row["cheques_id"].ToString();
                string bankAccountsID = row["bank_accounts_id"].ToString();
                string fundID = row["funds_id"].ToString();
                string chequeNo = row["cheque_no"].ToString();
                string chequeDate = row["cheque_date"].ToString();
                decimal amount = Convert.ToDecimal(row["cheque_amount"]);
                string fundCode = row["fund_code"].ToString();
                string fundName = row["fund_name"].ToString();
                string dvNo = row["dv_no"].ToString();
                string payee = row["payee"].ToString();
                string natureOfPayment = row["nature_of_payment"].ToString();
                string releasedDate = string.IsNullOrEmpty(row["date_released"].ToString()) ? string.Empty : row["date_released"].ToString();
                string status = string.IsNullOrEmpty(row["released_cheques_id"].ToString()) ? "Unreleased" : "Released";

                newRow["rci_id"] = id;
                newRow["cheques_id"] = chquesID;
                newRow["bank_accounts_id"] = bankAccountsID;
                newRow["funds_id"] = fundID;
                newRow["cheque_no"] = chequeNo;
                newRow["cheque_date"] = chequeDate;
                newRow["cheque_amount"] = amount;
                newRow["fund_code"] = fundCode;
                newRow["fund_name"] = fundName;
                newRow["dv_no"] = dvNo;
                newRow["payee"] = payee;
                newRow["nature_of_payment"] = natureOfPayment;
                newRow["released_date"] = releasedDate;
                newRow["status"] = status;

                releasedAndUnreleasedDT.Rows.Add(newRow);
            }

            HelperLoadRecords.RCIReleasedAndUnreleasedDatagridView(releasedAndUnreleasedDT, dgReleasedAndUnreleaseCheques);

            lblRecordCount.Text = dtViewReleasedCheques.Rows.Count.ToString();
        }

        private DataColumn[] ReleasedAndUnreleaseChequesColumn()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("rci_id", typeof(string)),
                new DataColumn("cheques_id", typeof(string)),
                new DataColumn("bank_accounts_id", typeof(string)),
                new DataColumn("funds_id", typeof(string)),
                new DataColumn("cheque_no", typeof(string)),
                new DataColumn("cheque_date", typeof(string)),
                new DataColumn("cheque_amount", typeof(decimal)),
                new DataColumn("fund_code", typeof(string)),
                new DataColumn("fund_name", typeof(string)),
                new DataColumn("dv_no", typeof(string)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("nature_of_payment", typeof(string)),
                new DataColumn("released_date", typeof(string)),
                new DataColumn("status", typeof(string)),
        };

            return dataColumns;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgReleasedAndUnreleaseCheques.SelectedRows.Count == 0)
                return;

            if (Helper.MessageBoxConfirmCancel("Release Cheque?"))
            {
                if (ReleasedCheque())
                {
                    Helper.MessageBoxSuccess("Cheque has been released.");
                    LoadChecks();
                }
            }

            return;
        }

        private bool ReleasedCheque()
        {
            try
            {
                int selectedrowindex = dgReleasedAndUnreleaseCheques.SelectedCells[0].RowIndex;
                int RCIID = Convert.ToInt32(dgReleasedAndUnreleaseCheques.Rows[selectedrowindex].Cells["rci_id"].Value);
                int chequeID = Convert.ToInt32(dgReleasedAndUnreleaseCheques.Rows[selectedrowindex].Cells["cheques_id"].Value);

                var releasedChequesModel = new ReleasedChequesModel()
                {
                    RCIID = RCIID,
                    DateReleased = DateTime.Now,
                };

                var releasedChequesRepository = TreasuryFactory.ReleasedChequesRepository();
                return releasedChequesRepository.Insert(releasedChequesModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void cmbxBank_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadBankAccounts();
            LoadChecks();
        }

        private void cmbxBankAccountNo_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadChecks();
        }

        private void cmbxFund_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadChecks();
        }

        private void cbxShowReleasedChecks_CheckedChanged(object sender, EventArgs e)
        {
            LoadChecks();
        }

        private void TogglePreviewPermissions()
        {
            switch (pnlFilter.Visible)
            {
                case true:
                    pnlFilter.Visible = false;
                    btnToggleFilter.Text = "?";
                    break;

                case false:
                    pnlFilter.Visible = true;
                    btnToggleFilter.Text = "?";
                    break;
            }
        }

        private void btnToggleFilter_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePreviewPermissions();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                LoadChecks();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgReleasedAndUnreleaseCheques_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgReleasedAndUnreleaseCheques.SelectedRows.Count;
                btnAdd.Text = $"Release({selectedRowCount})";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}