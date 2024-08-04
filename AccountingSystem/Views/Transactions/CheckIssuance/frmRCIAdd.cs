using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIAdd : Form
    {
        private readonly frmRCI _frmRCI;
        private readonly ucRCI uc;

        public frmRCIAdd(frmRCI frmRCI)
        {
            InitializeComponent();
            _frmRCI = frmRCI;
            uc = ucrci1;
        }

        private void frmRCIAdd_Load(object sender, EventArgs e)
        {
            uc.cmbFPP.SelectedIndex = -1;
            uc.cmbFPP.TextChanged += new EventHandler(uc.cmbxFPP_TextChanged);
        }

        private bool SaveCheque()
        {
            int bankAccountId = Convert.ToInt32(uc.cmbBankAccounts.SelectedValue);
            string chequeNo = uc.txtCheckNo.Text.Trim();
            DateTime chequeDate = uc.dtCheckDate.Value;
            decimal amount = uc.nudNetAmount.Value;

            var chequeModel = new ChequesModel()
            {
                BankAccountsId = bankAccountId,
                ChequeNo = chequeNo,
                ChequeDate = chequeDate,
                Amount = amount
            };

            return AccFactory.ChequesRepository().Insert(chequeModel);
        }

        private bool SaveRCI()
        {
            var chequeID = AccFactory.ChequesRepository().GetLastInsertId();
            int fundID = Convert.ToInt32(uc.cmbFund.SelectedValue);
            int fpp = Convert.ToInt32(uc.cmbFPP.SelectedValue);
            string dVNo = uc.txtDVNo.Text.Trim();
            string payee = uc.txtPayee.Text.Trim();
            string natureOfPayment = uc.txtNatureOfPayment.Text.Trim();

            var RCIModel = new RciModel()
            {
                ChequeID = chequeID,
                FundId = fundID,
                FunctionProgramProjectId = fpp,
                DVNo = dVNo,
                Payee = payee,
                NaturePayment = natureOfPayment
            };

            return AccFactory.RciRepository().Insert(RCIModel);
        }

        internal void SaveDVObligationsNumber()
        {
            int lastInsertedId = AccFactory.RciRepository().GetLastInsertId();
            string obligationNo;
            DateTime dateEntry;

            foreach (DataRow row in uc.dtObligations.Rows)
            {
                obligationNo = row["obligation_no"].ToString();
                dateEntry = Convert.ToDateTime(row["date_entry"]);
                AccFactory.RciRepository().SaveRciDvObligations(lastInsertedId, obligationNo, dateEntry);
            }
        }

        internal void SaveDeductions()
        {
            int lastRecentRCIId = AccFactory.RciRepository().GetLastInsertId();
            string deductionDescription;
            decimal deductionAmount;

            foreach (DataRow row in uc.dtDeductions.Rows)
            {
                deductionDescription = row["description"].ToString();
                deductionAmount = Convert.ToDecimal(row["amount"]);
                uc.totalDeduction += deductionAmount;

                AccFactory.RciRepository().SaveRciDeductions(lastRecentRCIId, deductionDescription, deductionAmount);
            }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            using var scope = new TransactionScope();
            if (SaveCheque())
            {
                SaveRCI();
                SaveDVObligationsNumber();
                SaveDeductions();
                scope.Complete();
                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("RCI has been saved.");
                    _frmRCI.LoadRci();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}