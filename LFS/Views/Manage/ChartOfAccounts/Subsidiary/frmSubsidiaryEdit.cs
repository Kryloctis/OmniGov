using Accounting.Data;
using Accounting.Domain.Entities;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts.Subsidiary
{
    public partial class frmSubsidiaryEdit : Form
    {
        private readonly frmSubsidiary frmSubsidiary;
        private readonly ushort subsidiaryLedgerId;
        private ucSubsidiary uc;

        public frmSubsidiaryEdit(frmSubsidiary _frmSubsidiary, byte fundId, ushort generalLedgerId, ushort _subsidiaryLedgerId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            frmSubsidiary = _frmSubsidiary;
            uc = ucSubsidiary1;
            uc.fundId = fundId;
            uc.generalLedgerId = generalLedgerId;
            subsidiaryLedgerId = _subsidiaryLedgerId;
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> data = AccountingFactory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);

            uc.txtCode.Text = data["sub_code"];
            uc.txtName.Text = data["sub_name"];
            uc.txtAddress.Text = data["address"];
            uc.txtContactPerson.Text = data["contact_person"];
            uc.txtContact.Text = data["contact"];
        }

        private void OnLoad()
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }

        private void frmSubsidiaryEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
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
                Name = uc.txtName.Text.Trim(),
                Address = uc.txtAddress.Text.Trim(),
                ContactPerson = uc.txtContactPerson.Text.Trim(),
                Contact = uc.txtContact.Text.Trim()
            };

            return AccountingFactory.SubsidiaryLedgerAccountsRepository().Update(subsidiaryLedgerAccountsModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Subsidiary ledger has been saved.");
                    frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
