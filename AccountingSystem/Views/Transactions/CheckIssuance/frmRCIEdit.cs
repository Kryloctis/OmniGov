using ACC.Domain.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIEdit : Form
    {
        private frmRCI _frmrci;
        private readonly ucRCI uc;
        
        public frmRCIEdit(frmRCI frmrci, int rciId)
        {
            InitializeComponent();
            _frmrci = frmrci;
            uc = ucrci1;
            uc.Id = rciId;
        }


        private void LoadRCIObligations()
        {
            try
            {
                //var rciObligationsRepo = Factory.RCIObligationsRepository();
                //var dtRCIObligations = rciObligationsRepo.GetRecordsByRCIId(uc.Id);



                //foreach (DataRow item in dtRCIObligations.Rows)
                //{
                //    uc.dgObligationNoList.Rows.Add(item[0].ToString(), "Remove");
                //}

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
                uc.txtamount.Value = Convert.ToDecimal(rcidata["amount"]);

                
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord(ucRCI uc,string table,int Id)
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
        }


        private void UpdateRCIObligation()
        {
            //var rciObligationRepo = Factory.RCIObligationsRepository();
            //var deleteSuccess = rciObligationRepo.DeleteRecordsByRCIId(uc.Id);

            //if (deleteSuccess)
            //{
            //    short rcid = (short)uc.Id;
            //    string obligationNo = String.Empty;

            //    foreach (DataGridViewRow item in uc.dgObligationNoList.Rows)
            //    {
            //        obligationNo = item.Cells["obligation_no"].Value.ToString();
            //        Factory.RCIRepository().SaveRCIDVObligations(rcid, obligationNo);
            //    }
            //}
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucrci1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var rciModel = new RCIModel()
                {
                    Id = uc.Id,
                    BankId = Convert.ToInt32(uc.cmbbank.SelectedValue),
                    FundsId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    FunctionProgramProjectId = uc.functionId,
                    CheckNo = uc.txtcheckno.Text.Trim(),
                    CheckDate = Convert.ToDateTime(uc.dtcheckdate.Text.Trim()),
                    DvNo = uc.txtdvno.Text.Trim(),
                    Payee = uc.txtpayee.Text.Trim(),
                    NaturePayment = uc.txtnature.Text.Trim(),
                    Amount = Convert.ToDecimal(uc.txtamount.Value)
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
            if (SaveData())
            {
                UpdateRCIObligation();
                Helper.MessageBoxSuccess("Account has been updated.");
                _frmrci.LoadRecords();
                this.Close();
            }
        }

    }
}
