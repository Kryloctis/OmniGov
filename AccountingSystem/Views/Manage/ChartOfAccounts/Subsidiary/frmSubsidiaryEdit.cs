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

namespace AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary
{
    public partial class frmSubsidiaryEdit : Form
    {
        private readonly frmSubsidiary frmSubsidiary;
        private readonly ushort subsidiaryLedgerId;
  

        public frmSubsidiaryEdit(frmSubsidiary _frmSubsidiary, byte fundId, ushort generalLedgerId, ushort _subsidiaryLedgerId)
        {
            InitializeComponent();
            frmSubsidiary = _frmSubsidiary;
            ucSubsidiary1.fundId = fundId;
            ucSubsidiary1.generalLedgerId = generalLedgerId;
            subsidiaryLedgerId = _subsidiaryLedgerId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucSubsidiary1;
                Dictionary<string, string> data = Factory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);

                uc.txtCode.Text = data["sub_code"];
                uc.txtName.Text = data["sub_name"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmSubsidiaryEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucSubsidiary1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var subsidiaryLedgerAccountsModel = new SubsidiaryLedgerAccountsModel()
                {
                    Id = subsidiaryLedgerId,
                    FundId = uc.fundId,
                    GeneralLedgerAccountsId = uc.generalLedgerId,
                    Code = uc.txtCode.Text.Trim(),
                    Name = uc.txtName.Text.Trim()
                };

                return Factory.SubsidiaryLedgerAccountsRepository().Update(subsidiaryLedgerAccountsModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Subsidiary ledger has been saved.");
                frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger(ucSubsidiary1.fundId);
            }
        }
    }
}
