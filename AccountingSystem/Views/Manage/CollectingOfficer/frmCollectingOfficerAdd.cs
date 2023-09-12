using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerAdd : Form
    {
        private readonly frmCollectingOfficer _frmCollectingOfficer;
        private readonly ucCollectingOfficer _uc;

        public frmCollectingOfficerAdd(frmCollectingOfficer frmCollectingOfficer)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmCollectingOfficer = frmCollectingOfficer;
            _uc = ucCollectingOfficer1;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!_uc.ValidateChildren())
            {
                Helper.MessageBoxError(_uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var model = new CollectingOfficerModel()
            {
                Prefix = _uc.txtPrefix.Text.Trim(),
                FirstName = _uc.txtFirstName.Text.Trim(),
                MiddleInitial = _uc.txtMiddleInitial.Text.Trim(),
                LastName = _uc.txtLastName.Text.Trim(),
                Suffix = _uc.txtSuffix.Text.Trim(),
                JobTitle = _uc.txtJobtitle.Text.Trim(),
                UserId = _uc.userID
            };

            var collectingOfficerRepo = AccFactory.CollectingOfficerRepository();
            return collectingOfficerRepo.Insert(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                    _frmCollectingOfficer.LoadRecords();
                    _uc.ResetForm();
                    _uc.SetReadOnlyConrol(false);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCollectingOfficerAdd_Load(object sender, EventArgs e)
        {

        }

    }
}