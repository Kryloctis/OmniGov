using OmniGov.App.Helpers;
using OmniGov.App.Views.Transactions.CheckIssuance.Deductions;
using OmniGov.App.Views.Transactions.CheckIssuance.Obligations;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Transactions.CheckIssuance
{
    public partial class ucRCI : UserControl
    {
        internal int Id;
        internal int bankId;
        internal int fundsId;
        internal int fppId;
        internal short obligationNumberCount;
        internal decimal totalDeduction;
        internal DataTable dtObligations = new();
        internal DataTable dtDeductions = new();

        public ucRCI()
        {
            InitializeComponent();
            CreateObligationAndDeductionsColumns();
        }

        private void CreateObligationAndDeductionsColumns()
        {
            //obligations
            dtObligations.Columns.Add("obligation_no", typeof(string));
            dtObligations.Columns.Add("date_entry", typeof(DateTime));

            //deductions
            dtDeductions.Columns.Add("description", typeof(string));
            dtDeductions.Columns.Add("amount", typeof(decimal));
        }

        private void ucRCI_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBanks();
                LoadBankAccounts();
                LoadFunds();
                LoadFPP();
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = TreasuryFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }

        internal void LoadFPP()
        {
            cmbFPP.DroppedDown = false;
            Cursor.Current = Cursors.Default;

            if (DataTableFPP().Rows.Count == 0) return;

            var fppDict = new Dictionary<int, string>();
            foreach (DataRow item in DataTableFPP().Rows)
            {
                int fppId = Convert.ToInt32(item["id"]);
                string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                fppDict.Add(fppId, fppName);
            }

            cmbFPP.DataSource = new BindingSource(fppDict, null);
            cmbFPP.DisplayMember = "value";
            cmbFPP.ValueMember = "key";
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }

        internal void ResetForm()
        {
            txtDVNo.Clear();
            txtCheckNo.Clear();
            txtPayee.Clear();
            txtNatureOfPayment.Clear();
            dtObligations.Rows.Clear();
            dtDeductions.Rows.Clear();
            cmbFund.SelectedIndex = -1;
            cmbBank.SelectedIndex = -1;
            cmbBankAccounts.SelectedIndex = -1;
            cmbFPP.SelectedIndex = -1;
            bankId = 0;
            fundsId = 0;
            fppId = 0;
            dtCheckDate.Value = DateTime.Now;
            nudNetAmount.Value = Convert.ToDecimal("0.00");
            btnAddObligation.Text = "Click to add obligation no.";
            btnAddDeductions.Text = "Click to add deductions.";
        }

        internal void LoadFunds()
        {
            var fundRepository = Factory.FundsRepository();
            var dtFunds = fundRepository.GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "id", "fund_name");
        }

        internal void LoadBanks()
        {
            var banksRepository = TreasuryFactory.BanksRepository();
            var dtBank = banksRepository.GetRecords();
            HelperLoadRecords.BankComboBox(dtBank, cmbBank, "id", "bank_name");
        }

        internal void SetSelectedValue(int Id, string table)
        {
            if (!string.IsNullOrEmpty(table) || Id > 0)
            {
                if (table.Equals("functions"))
                {
                    var functionData = Factory.FunctionProgramProjectRepository().GetRecordByID(Id);
                    fppId = Convert.ToInt16(functionData["id"]);
                    cmbFPP.Text = String.Format("{0} - {1}", functionData["fpp_code"], functionData["fpp_name"]);
                }
            }
        }

        internal void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFPP.Text))
            {
                cmbFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP();
                cmbFPP.SelectedIndex = -1;
                cmbFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void btnAddObligation_Click(object sender, EventArgs e)
        {
            _ = new frmChckIssOblgtns(this).ShowDialog();
        }

        private void btnAddDeductions_Click(object sender, EventArgs e)
        {
            _ = new frmDeductions(this).ShowDialog();
        }

        internal void SetObligationLabel()
        {
            obligationNumberCount = (short)dtObligations.Rows.Count;
            btnAddObligation.Text = $"({obligationNumberCount}) obligation/s number added.";
        }

        internal void SetDeductionLabel()
        {
            foreach (DataRow row in dtDeductions.Rows)
                totalDeduction += Convert.ToDecimal(row[1].ToString());

            btnAddDeductions.Text = $"({totalDeduction:N2}) total deductions.";
            totalDeduction = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbFund),
                errorProvider1.GetError(cmbBank),
                errorProvider1.GetError(cmbBankAccounts),
                errorProvider1.GetError(txtCheckNo),
                errorProvider1.GetError(cmbFPP),
                errorProvider1.GetError(dtCheckDate),
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtNatureOfPayment),
                errorProvider1.GetError(nudNetAmount)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void txtdvno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDVNo, "Disbursement No.");
        }

        private void txtdvno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDVNo);
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbFund, "Fund.");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbFund);
        }

        private void cmbbank_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbBank, "Bank.");
        }

        private void cmbbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbBank);
        }

        private void cmbBankAccounts_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbBankAccounts, "Bank Account.");
        }

        private void cmbBankAccounts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbBankAccounts);
        }

        private void txtcheckno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCheckNo, "Check No.");
        }

        private void txtcheckno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCheckNo);
        }

        private bool FPPNameNotExist()
        {
            string fppName = cmbFPP.Text.Trim();

            if (cmbFPP.FindStringExact(fppName) == -1 && !string.IsNullOrWhiteSpace(fppName))
            {
                errorProvider1.SetError(cmbFPP, "FPP you entered doesn't exist.");
                return true;
            }

            return false;
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = FPPNameNotExist();
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbFPP);
        }

        private void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee.");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void txtnature_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtNatureOfPayment, "Nature of Payment.");
        }

        private void txtnature_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtNatureOfPayment);
        }

        private void txtamount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudNetAmount, "Net Amount.");
        }

        private void txtamount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudNetAmount);
        }
    }
}