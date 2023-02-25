using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReleasedAndUnReleasedChecks
{
    public partial class frmReleasedAndUnreleaseChecks : Form
    {

        private DataTable releasedAndUnreleasedDT;

        public frmReleasedAndUnreleaseChecks()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRCI, false);
        }

        private void frmReleasedAndUnreleaseChecks_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadBankAccounts();
            LoadFunds();
            LoadCheques();
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbxBank.DataSource = dtBank;
                cmbxBank.ValueMember = "id";
                cmbxBank.DisplayMember = "bank_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbxBankAccountNo.DataSource = dtBankAccounts;
            cmbxBankAccountNo.ValueMember = "id";
            cmbxBankAccountNo.DisplayMember = "account_no";
        }


        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");
        }

        private void cmbxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }

        internal void LoadCheques()
        {
            try
            {
                var rciRepository = AccFactory.RCIRepository();
                var dtViewRCI = rciRepository.GetViewRecords();

                releasedAndUnreleasedDT = new DataTable();
                releasedAndUnreleasedDT.Columns.AddRange(ReleasedAndUnreleaseChequesColumn());

                foreach (DataRow row in dtViewRCI.Rows)
                {
                    var newRow = releasedAndUnreleasedDT.NewRow();

                    string id = row["id"].ToString();
                    string chquesID = row["cheques_id"].ToString();
                    string bankAccountsID = row["bank_accounts_id"].ToString();
                    string bankID = row["bank_id"].ToString();
                    string fundID = row["fund_id"].ToString();
                    string fpp = row["fpp_id"].ToString();
                    string createdAt = row["created_at"].ToString();
                    string updatedAt = row["updated_at"].ToString();
                    string chequeNo = row["cheque_no"].ToString();
                    string chequeDate = row["cheque_date"].ToString();
                    string amount = row["amount"].ToString();
                    string bankAccountNo = row["bank_account_no"].ToString();
                    string bankName = row["bank_name"].ToString();
                    string fundCode = row["fund_code"].ToString();
                    string fundName = row["fund_name"].ToString();
                    string dvNo = row["dv_no"].ToString();
                    string payee = row["payee"].ToString();
                    string natureOfPayment = row["nature_of_payment"].ToString();
                    string obligationNumber = row["obligation_no"].ToString();
                    string fppCode = row["fpp_code"].ToString();
                    string totalDeductions = row["total_deductions"].ToString();
                    string status = "Released";


                    newRow["id"] = id;
                    newRow["cheques_id"] = chquesID;
                    newRow["bank_accounts_id"] = bankAccountsID;
                    newRow["bank_id"] = bankID;
                    newRow["fund_id"] = fundID;
                    newRow["fpp_id"] = fpp;
                    newRow["created_at"] = createdAt;
                    newRow["updated_at"] = updatedAt;
                    newRow["cheque_no"] = chequeNo;
                    newRow["cheque_date"] = chequeDate;
                    newRow["amount"] = amount;
                    newRow["bank_account_no"] = bankAccountNo;
                    newRow["bank_name"] = bankName;
                    newRow["fund_code"] = fundCode;
                    newRow["fund_name"] = fundName;
                    newRow["dv_no"] = dvNo;
                    newRow["payee"] = payee;
                    newRow["nature_of_payment"] = natureOfPayment;
                    newRow["obligation_no"] = obligationNumber;
                    newRow["fpp_code"] = fppCode;
                    newRow["total_deductions"] = totalDeductions;
                    newRow["status"] = status;

                    releasedAndUnreleasedDT.Rows.Add(newRow);
                }


                HelperLoadRecords.RCIReleasedAndUnreleaseDatagridView(releasedAndUnreleasedDT, dgRCI);
                lblRecordCount.Text = rciRepository.CountRecords().ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataColumn[] ReleasedAndUnreleaseChequesColumn()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(string)),
                new DataColumn("cheques_id", typeof(string)),
                new DataColumn("bank_accounts_id", typeof(string)),
                new DataColumn("bank_id", typeof(string)),
                new DataColumn("fund_id", typeof(string)),
                new DataColumn("fpp_id", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
                new DataColumn("cheque_no", typeof(string)),
                new DataColumn("cheque_date", typeof(string)),
                new DataColumn("amount", typeof(string)),
                new DataColumn("bank_account_no", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("fund_code", typeof(string)),
                new DataColumn("fund_name", typeof(string)),
                new DataColumn("dv_no", typeof(string)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("nature_of_payment", typeof(string)),
                new DataColumn("obligation_no", typeof(string)),
                new DataColumn("fpp_code", typeof(string)),
                new DataColumn("total_deductions", typeof(string)),
                new DataColumn("status", typeof(string)),

        };

            return dataColumns;
        }
    }
}
