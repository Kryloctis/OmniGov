using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIEdit : Form
    {
        private frmRCI _frmrci;
        public frmRCIEdit(frmRCI frmrci, int Id)
        {
            InitializeComponent();
            _frmrci = frmrci;
            ucrci1.Id = Id;
        }

        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucrci1;
                var rciRepository = Factory.RCIRepository();
                var rcidata = rciRepository.GetRecordByID(uc.Id);
                uc.txtObno.Text = rcidata["obligation_no"];
                uc.txtdvno.Text = rcidata["dv_no"];
                //uc.setSelectedValue(Convert.ToInt16(rcidata["banks_id"]), "banks");
               // uc.setSelectedValue(Convert.ToInt16(rcidata["funds_id"]), "funds");
                //uc.setSelectedValue(Convert.ToInt16(rcidata["function_program_project_id"]), "functions");
                LoadSelectedRecord(uc, "banks", Convert.ToInt16(rcidata["banks_id"]));
                LoadSelectedRecord(uc, "funds", Convert.ToInt16(rcidata["funds_id"]));
                LoadSelectedRecord(uc, "functions", Convert.ToInt16(rcidata["function_program_project_id"]));
                uc.txtcheckno.Text = rcidata["check_no"];
                uc.dtcheckdate.Value = Convert.ToDateTime(rcidata["check_date"]);
                uc.txtpayee.Text = rcidata["payee"];
                uc.txtnature.Text = rcidata["nature_of_payment"];
                uc.txttrust.Value = Convert.ToDecimal(rcidata["trust_liabilities"]);
                uc.txtvat.Value = Convert.ToDecimal(rcidata["bir_vat_nonvat"]);
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
                    if (table.Equals("banks"))
                    {
                        var banksrepository = Factory.BanksRepository();
                        var bankdata = banksrepository.GetRecordByID(Id);
                        uc.bankId = Id;
                        uc.txtbank.Text = String.Format("{0} - {1}", bankdata["account_no"], bankdata["bank_name"]);
                    }
                    if (table.Equals("funds"))
                    {
                        var fundsrepository = Factory.FundsRepository();
                        var funddata = fundsrepository.GetRecordByID(Id);
                        uc.fundsId = Id;
                        uc.txtfund.Text = String.Format("{0} - {1}", funddata["fund_code"], funddata["fund_name"]);
                    }
                    if (table.Equals("functions"))
                    {
                        var functionreposity = Factory.FunctionProgramProjectRepository();
                        var functiondata = functionreposity.GetRecordByID(Id);
                        uc.functionId = Id;
                        uc.txtfunction.Text = String.Format("{0} - {1}", functiondata["fpp_code"], functiondata["fpp_name"]);
                    }

                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRCIEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedValue();
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
                    BankId = uc.bankId,
                    FundsId = uc.fundsId,
                    FunctionProgramProjectId = uc.functionId,
                    CheckNo = uc.txtcheckno.Text.Trim(),
                    CheckDate = Convert.ToDateTime(uc.dtcheckdate.Text.Trim()),
                    ObNo = uc.txtObno.Text.Trim(),
                    DvNo = uc.txtdvno.Text.Trim(),
                    Payee = uc.txtpayee.Text.Trim(),
                    NaturePayment = uc.txtnature.Text.Trim(),
                    TrustLiabilities = Convert.ToDecimal(uc.txttrust.Value),
                    BirVatNonVat = Convert.ToDecimal(uc.txtvat.Value),
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
                Helper.MessageBoxSuccess("Account has been updated.");
                _frmrci.LoadRecords();
            }
        }
    }
}
