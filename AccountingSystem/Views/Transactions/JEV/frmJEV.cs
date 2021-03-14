using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        

        public frmJEV()
        {
            InitializeComponent();
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
        }

        private List<JEVAccountsModel> JevAcountsModelList()
        {
            var uc = ucjev1;
            var jevAccountsModelList = new List<JEVAccountsModel>();
            foreach (DataGridViewRow item in uc.dgAccounts.Rows)
            {
                int fppId = Convert.ToInt32(item.Cells["FPPId"].Value);
                ushort generalLedgerId = Convert.ToUInt16(item.Cells["GeneralLedgerId"].Value);
                ushort? subsidiaryLedgerId = (ushort?)item.Cells["SubsidiaryLedgerId"].Value;
                bool isDebit = Convert.ToBoolean(item.Cells["IsDebit"].Value);
                bool? isDeposit = (bool?)item.Cells["IsDeposit"].Value;

                decimal amount;
                if (isDebit)
                    amount = Convert.ToDecimal(item.Cells["Debit"].Value);
                else
                    amount = Convert.ToDecimal(item.Cells["Credit"].Value);

                var jevAccountModel = new JEVAccountsModel()
                {
                    FPPId = fppId,
                    GeneralLedgerId = generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryLedgerId,
                    IsDeposit = isDeposit,
                    IsDebit = isDebit,
                    Amount = amount
                };

                jevAccountsModelList.Add(jevAccountModel);
            }

            return jevAccountsModelList;
        }

        private bool SaveData()
        {
            try
            {
                var user = Helper.GetLoggedInUserAccounting();
                var uc = ucjev1;

                // if no fund or journal selected, show error
                if (uc.fundId == 0 || uc.journalId == 0)
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // if no rows in accounts datagrid, show error
                if (uc.dgAccounts.Rows.Count == 0)
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.txtDebitTotal.Text != uc.txtCreditTotal.Text)
                {
                    Helper.MessageBoxError("Debit & Credit amounts must be equal.");
                    return false;
                }

                string jevNo = $"{uc.txtFundsJevNo.Text}-{uc.txtJEVNo.Text.Trim()}";
                var jevModel = new JEVModel()
                {
                    FundsId = uc.fundId,
                    JournalsId = uc.journalId,
                    JEVNumber = jevNo,
                    DateEntry = uc.dtpDateEntry.Value,
                    Explanation = uc.txtExplanation.Text.Trim(),
                    CreatedBy = Convert.ToByte(user["id"])
                };

                return Factory.JEVRepository().Insert(jevModel, JevAcountsModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("JEV has been saved.");
                ucjev1.ResetForm();
            }
        }
    }
}
