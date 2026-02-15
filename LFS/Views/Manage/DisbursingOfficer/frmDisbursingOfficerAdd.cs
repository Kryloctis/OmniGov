using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficerAdd : Form
    {
        private ucDisbursingOfficer uc;
        private frmDisbursingOfficer frmDisbursingOfficer;

        public frmDisbursingOfficerAdd(frmDisbursingOfficer _frmDisbursingOfficer)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            frmDisbursingOfficer = _frmDisbursingOfficer;
            uc = ucDisbursingOfficer1;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var disbursingOfficerModel = new DisbursingOfficerModel()
            {
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = uc.txtMidInitial.Text.Trim(),
                LastName = uc.txtLastName.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                JobTitle = uc.txtJobTitle.Text.Trim(),
                UserId = uc.UserId
            };

            return TreasuryFactory.DisbursingOfficerRepository().Insert(disbursingOfficerModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Disbursing office has been saved.");
                    frmDisbursingOfficer.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}