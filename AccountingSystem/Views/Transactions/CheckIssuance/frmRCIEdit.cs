using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.CheckIssuance.Deductions;
using AccountingSystem.Views.Transactions.CheckIssuance.Obligations;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIEdit : Form
    {
        private readonly frmRCI _frmRCI;
        private readonly ucRCI uc;
        private int  _rciID;
        private int checkID;


        public frmRCIEdit(frmRCI frmRCI, int rciId)
        {
            InitializeComponent();
            _frmRCI = frmRCI;
            uc = ucrci2;
            _rciID = rciId;
        }

        private void LoadRCIObligations()
        {
            try
            {
                frmObligations frmObligations = new(uc);

                var rciObligationsRepo = AccFactory.RCIObligationsRepository();
                var dtRCIObligations = rciObligationsRepo.GetRecordsByRCIId(_rciID);

                foreach (DataRow row in dtRCIObligations.Rows)
                    uc.dtObligations.Rows.Add(row[0].ToString());

                HelperLoadRecords.RCIObligationDatagridview(uc.dtObligations, frmObligations.dgObligation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadRCIDeductions()
        {
            try
            {
                frmDeductions frmDeductions = new(uc);

                var rciDeductionRepo = AccFactory.RCIDeductionsRepository();
                var dtRCIDeductions = rciDeductionRepo.GetDeductionsByRCIId(_rciID);

                foreach (DataRow row in dtRCIDeductions.Rows)
                    uc.dtDeductions.Rows.Add(row[0].ToString(), row[1].ToString());

                HelperLoadRecords.RCIDeductionsDatagridview(uc.dtDeductions, frmDeductions.dgDeductions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadSelectedValue()
        {
            try
            {
                var rciRepository = AccFactory.RCIRepository();
                var rcidata = rciRepository.GetRecordByID(_rciID);

                uc.txtDVNo.Text = rcidata["dv_no"];
                uc.cmbBank.SelectedValue = rcidata["bank_id"];
                uc.cmbfund.SelectedValue = rcidata["fund_id"];
                LoadSelectedRecord(uc, "functions", Convert.ToInt16(rcidata["function_program_project_id"]));
                uc.txtCheckNo.Text = rcidata["cheque_no"];
                uc.dtCheckDate.Value = Convert.ToDateTime(rcidata["cheque_date"]);
                uc.txtPayee.Text = rcidata["payee"];
                uc.txtNature.Text = rcidata["nature_of_payment"];
                uc.nudNetAmount.Value = Convert.ToDecimal(rcidata["amount"]);
                checkID = Convert.ToInt32(rcidata["cheques_id"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord(ucRCI uc, string table, int Id)
        {
            try
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("functions"))
                    {
                        var functionreposity = AccFactory.FunctionProgramProjectRepository();
                        var functiondata = functionreposity.GetRecordByID(Id);
                        uc.functionId = Id;
                        uc.cmbFPP.Text = String.Format("{0} - {1}", functiondata["fpp_code"], functiondata["fpp_name"]);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRCIEdit_Load(object sender, EventArgs e)
        {
            uc.LoadFunds();
            uc.LoadBanks();

            LoadSelectedValue();
            LoadRCIObligations();
            LoadRCIDeductions();

            uc.SetObligationLabel();
            uc.SetDeductionLabel();
        }

        private void UpdateRCIObligation()
        {
            var deleteResult = AccFactory.RCIObligationsRepository().DeleteRecordsByRCIId(_rciID);

            if (deleteResult)
            {
                short rcid = (short)_rciID;
                string obligationNo = String.Empty;

                foreach (DataRow row in uc.dtObligations.Rows)
                {
                    obligationNo = row[0].ToString();
                    AccFactory.RCIRepository().SaveRCIDVObligations(rcid, obligationNo);
                }
            }
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

            var chequesRepository = AccFactory.ChequesRepository();
            _ = chequesRepository.Update(chequesModel);
        }


        private void UpdateRCIDeductions()
        {
            var deleteResult = AccFactory.RCIDeductionsRepository().DeleteRecordsByRCIId(_rciID);

            if (deleteResult)
            {
                short rcid = (short)_rciID;
                foreach (DataRow row in uc.dtDeductions.Rows)
                {
                    string description = row[0].ToString();
                    decimal amount = Convert.ToDecimal(row[1].ToString());
                    AccFactory.RCIRepository().SaveRCIDeductions(rcid, description, amount);
                }
            }
        }

        private bool UpdateData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var rciModel = new RCIModel()
                {
                    Id = _rciID,
                    FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    FunctionProgramProjectId = uc.functionId,
                    DVNo = uc.txtDVNo.Text.Trim(),
                    Payee = uc.txtPayee.Text.Trim(),
                    NaturePayment = uc.txtNature.Text.Trim(),
                };

                var rcirepository = AccFactory.RCIRepository();
                return rcirepository.Update(rciModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                UpdateCheque();
                UpdateRCIObligation();
                UpdateRCIDeductions();
                Helper.MessageBoxSuccess("Account has been updated.");
                _frmRCI.LoadRecords();
                this.Close();
            }
        }
    }
}