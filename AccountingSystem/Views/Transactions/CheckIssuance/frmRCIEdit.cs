using ACC.Domain.Models;
using System;
using System.Windows.Forms;
using AccountingSystem.Views.Transactions.CheckIssuance.Deductions;
using AccountingSystem.Views.Transactions.CheckIssuance.Obligations;
using System.Data;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIEdit : Form
    {
        private readonly frmRCI _frmRCI;
        private readonly ucRCI uc;

        public frmRCIEdit(frmRCI frmRCI, int rciId)
        {
            InitializeComponent();
            _frmRCI = frmRCI;
            uc = ucrci1;
            uc.Id = rciId;
        }


        private void LoadRCIObligations()
        {
            try
            {
                frmObligations frmObligations = new(uc);

                var rciObligationsRepo = Factory.RCIObligationsRepository();
                var dtRCIObligations = rciObligationsRepo.GetRecordsByRCIId(uc.Id);

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

                var rciDeductionRepo = Factory.RCIDeductionsRepository();
                var dtRCIDeductions = rciDeductionRepo.GetDeductionsByRCIId(uc.Id);

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
                var rciRepository = Factory.RCIRepository();
                var rcidata = rciRepository.GetRecordByID(uc.Id);

                uc.txtdvno.Text = rcidata["dv_no"];
                uc.cmbbank.SelectedValue = rcidata["bank_id"];
                uc.cmbfund.SelectedValue = rcidata["fund_id"];
                LoadSelectedRecord(uc, "functions", Convert.ToInt16(rcidata["function_program_project_id"]));
                uc.txtcheckno.Text = rcidata["check_no"];
                uc.dtcheckdate.Value = Convert.ToDateTime(rcidata["check_date"]);
                uc.txtpayee.Text = rcidata["payee"];
                uc.txtnature.Text = rcidata["nature_of_payment"];
                uc.nudNetAmount.Value = Convert.ToDecimal(rcidata["amount"]);


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
                        var functionreposity = Factory.FunctionProgramProjectRepository();
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
            var deleteResult = Factory.RCIObligationsRepository().DeleteRecordsByRCIId(uc.Id);
       
            if (deleteResult)
            {
                short rcid = (short)uc.Id;
                string obligationNo = String.Empty;

                foreach (DataRow row in uc.dtObligations.Rows)
                {
                    obligationNo = row[0].ToString();
                    Factory.RCIRepository().SaveRCIDVObligations(rcid, obligationNo);
                }
            }
        }

        private void UpdateRCIDeductions()
        {
            var deleteResult = Factory.RCIDeductionsRepository().DeleteRecordsByRCIId(uc.Id);

            if (deleteResult)
            {
                short rcid = (short)uc.Id;
                foreach (DataRow row in uc.dtDeductions.Rows)
                {
                    string description = row[0].ToString();
                    decimal amount = Convert.ToDecimal(row[1].ToString());
                    Factory.RCIRepository().SaveRCIDeductions(rcid, description, amount);
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
                    Id = uc.Id,
                    BankId = Convert.ToInt32(uc.cmbbank.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    FunctionProgramProjectId = uc.functionId,
                    CheckNo = uc.txtcheckno.Text.Trim(),
                    CheckDate = Convert.ToDateTime(uc.dtcheckdate.Text.Trim()),
                    DvNo = uc.txtdvno.Text.Trim(),
                    Payee = uc.txtpayee.Text.Trim(),
                    NaturePayment = uc.txtnature.Text.Trim(),
                    Amount = Convert.ToDecimal(uc.nudNetAmount.Value)
                };

                var rcirepository = Factory.RCIRepository();
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
                UpdateRCIObligation();
                UpdateRCIDeductions();
                Helper.MessageBoxSuccess("Account has been updated.");
                _frmRCI.LoadRecords();
                this.Close();
            }
        }

  
    }
}
