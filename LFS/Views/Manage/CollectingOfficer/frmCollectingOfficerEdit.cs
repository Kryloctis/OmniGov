using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerEdit : Form
    {
        private frmCollectingOfficer frmCollectingOfficer;
        private ucCollectingOfficer uc;

        public frmCollectingOfficerEdit(frmCollectingOfficer _frmCollectingOfficer, int OfficerId)
        {
            InitializeComponent();
            frmCollectingOfficer = _frmCollectingOfficer;
            uc = ucCollectingOfficer1;
            uc.Id = OfficerId;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = new CollectingOfficerModel()
            {
                Id = uc.Id,
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastName.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                JobTitle = uc.txtJobtitle.Text.Trim(),
                UserId = uc.cmbxLinkedAcc.SelectedValue
            };

            return TreasuryFactory.CollectingOfficerRepository().Update(model);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                    frmCollectingOfficer.LoadCollectingOfficers();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            Helper.LoadFormIcon(this);
            uc.LoadSelectedRecord();
        }

        private void frmCollectingOfficerEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
