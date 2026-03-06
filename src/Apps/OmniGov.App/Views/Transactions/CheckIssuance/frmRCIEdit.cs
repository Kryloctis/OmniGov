using OmniGov.App.Helpers;
using OmniGov.App.Views.Transactions.CheckIssuance.Deductions;
using OmniGov.App.Views.Transactions.CheckIssuance.Obligations;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.App.Views.Transactions.CheckIssuance
{
    public partial class frmRCIEdit : Form
    {
        private readonly frmRCI _frmRCI;
        private readonly ucRCI uc;
        private int _rciID;
        private int checkID;

        public frmRCIEdit(frmRCI frmRCI, int rciId)
        {
            InitializeComponent();
            _frmRCI = frmRCI;
            _rciID = rciId;
            uc = ucrci2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                UpdateCheque();
                UpdateRCIObligation();
                UpdateRCIDeductions();
                Helper.MessageBoxSuccess("RCI has been updated.");
                _frmRCI.LoadRci();
                Close();
            }
        }

        private void frmRCIEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedValue();
            LoadRCIObligations();
            LoadRCIDeductions();

            uc.SetObligationLabel();
            uc.SetDeductionLabel();
        }

        private void LoadRCIDeductions()
        {
            frmDeductions frmDeductions = new(uc);

            var rciDeductionRepo = TreasuryFactory.RCIDeductionsRepository();
            var dtRCIDeductions = rciDeductionRepo.GetDeductionsByRCIId(_rciID);

            foreach (DataRow row in dtRCIDeductions.Rows)
                uc.dtDeductions.Rows.Add(row[0].ToString(), row[1].ToString());

            HelperLoadRecords.RCIDeductionsDatagridview(uc.dtDeductions, frmDeductions.dgDeductions);
        }

        private void LoadRCIObligations()
        {
            frmChckIssOblgtns frmObligations = new(uc);

            var rciObligationsRepo = TreasuryFactory.RCIObligationsRepository();
            var dtRCIObligations = rciObligationsRepo.GetRecordsByRCIId(_rciID);

            foreach (DataRow row in dtRCIObligations.Rows)
            {
                string obligationNumber = row["obligation_no"].ToString();
                var dateEntry = Convert.ToDateTime(row["date_entry"]);

                uc.dtObligations.Rows.Add(obligationNumber, dateEntry);
            }

            HelperLoadRecords.RCIObligationDatagridview(uc.dtObligations, frmObligations.dgObligation);
        }

        private void LoadSelectedValue()
        {
            var dictRCI = TreasuryFactory.RciRepository().GetViewRecordById(_rciID);

            if (dictRCI.Count == 0) return;

            int chequeId = Convert.ToInt32(dictRCI["cheques_id"]);
            string dvNumber = dictRCI["dv_no"];
            int bankId = Convert.ToInt32(dictRCI["bank_id"]);
            int fundId = Convert.ToInt32(dictRCI["fund_id"]);
            int fppId = Convert.ToInt32(dictRCI["function_program_project_id"]);
            string checkNumber = dictRCI["cheque_no"];
            DateTime checkDate = Convert.ToDateTime(dictRCI["cheque_date"]);
            string payee = dictRCI["payee"];
            string natureOfPayment = dictRCI["nature_of_payment"];
            decimal amount = Convert.ToDecimal(dictRCI["amount"]);

            uc.txtDVNo.Text = dvNumber;
            uc.cmbBank.SelectedValue = bankId;
            uc.cmbFund.SelectedValue = fundId;
            uc.cmbFPP.SelectedValue = fppId;
            uc.txtCheckNo.Text = checkNumber;
            uc.dtCheckDate.Value = checkDate;
            uc.txtPayee.Text = payee;
            uc.txtNatureOfPayment.Text = natureOfPayment;
            uc.nudNetAmount.Value = amount;
            checkID = chequeId;
        }

        private void UpdateCheque()
        {
            var chequesModel = new ChequesModel()
            {
                Id = checkID,
                BankAccountsId = Convert.ToInt32(uc.cmbBankAccounts.SelectedValue),
                ChequeNo = uc.txtCheckNo.Text,
                ChequeDate = Convert.ToDateTime(uc.dtCheckDate.Value),
                Amount = uc.nudNetAmount.Value,
            };

            var chequesRepository = TreasuryFactory.ChequesRepository();
            _ = chequesRepository.Update(chequesModel);
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int fundID = Convert.ToInt32(uc.cmbFund.SelectedValue);
            int fpp = Convert.ToInt32(uc.cmbFPP.SelectedValue);
            string dVNo = uc.txtDVNo.Text.Trim();
            string payee = uc.txtPayee.Text.Trim();
            string natureOfPayment = uc.txtNatureOfPayment.Text.Trim();

            var rciModel = new RciModel()
            {
                Id = _rciID,
                FundId = fundID,
                FunctionProgramProjectId = fpp,
                DVNo = dVNo,
                Payee = payee,
                NaturePayment = natureOfPayment
            };

            return TreasuryFactory.RciRepository().Update(rciModel);
        }

        private void UpdateRCIDeductions()
        {
            var deleteResult = TreasuryFactory.RCIDeductionsRepository().DeleteRecordsByRCIId(_rciID);

            if (deleteResult)
            {
                short rcid = (short)_rciID;
                foreach (DataRow row in uc.dtDeductions.Rows)
                {
                    string description = row["description"].ToString();
                    decimal amount = Convert.ToDecimal(row["amount"]);
                    TreasuryFactory.RciRepository().SaveRciDeductions(rcid, description, amount);
                }
            }
        }

        private void UpdateRCIObligation()
        {
            var deleteResult = TreasuryFactory.RCIObligationsRepository().DeleteRecordsByRCIId(_rciID);

            if (deleteResult)
            {
                int rciId = _rciID;
                string obligationNo;
                DateTime dateEntry;

                foreach (DataRow row in uc.dtObligations.Rows)
                {
                    obligationNo = row["obligation_no"].ToString();
                    dateEntry = Convert.ToDateTime(row["date_entry"]);
                    TreasuryFactory.RciRepository().SaveRciDvObligations(rciId, obligationNo, dateEntry);
                }
            }
        }
    }
}