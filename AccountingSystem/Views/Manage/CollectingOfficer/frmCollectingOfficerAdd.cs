using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerAdd : Form
    {
        private readonly frmCollectingOfficer frmCollectingOfficer;
        private readonly ucCollectingOfficer uc;

        public frmCollectingOfficerAdd(frmCollectingOfficer _frmCollectingOfficer)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmCollectingOfficer = _frmCollectingOfficer;
            uc = ucCollectingOfficer1;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var model = new CollectingOfficerModel()
            {
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastName.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                JobTitle = uc.txtJobtitle.Text.Trim(),
                UserId = uc.cmbxLinkedAcc.SelectedValue
            };

            return AccFactory.CollectingOfficerRepository().Insert(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                    frmCollectingOfficer.LoadCollectingOfficers();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}