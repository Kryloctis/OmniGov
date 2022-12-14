using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerEdit : Form
    {
        private frmCollectingOfficer _frmCollectingOfficer;
        private ucCollectingOfficer _uc;

        public frmCollectingOfficerEdit(frmCollectingOfficer frmCollectingOfficer, int OfficerId)
        {
            InitializeComponent();
            _frmCollectingOfficer = frmCollectingOfficer;
            _uc = ucCollectingOfficer1;
            _uc.OfficerId = OfficerId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucCollectingOfficer1;
                var repository = AccFactory.CollectingOfficerRepository();
                var data = repository.GetRecordByID(uc.OfficerId);

                uc.txtPrefix.Text = data["prefix"];
                uc.txtFirstName.Text = data["first_name"];
                uc.txtMiddleInitial.Text = data["mid_initial"];
                uc.txtLastName.Text = data["last_name"];
                uc.txtSuffix.Text = data["suffix"];
                uc.txtJobtitle.Text = data["job_title"];
                uc.UserId = data["users_id"] == string.Empty ? 0 : Convert.ToInt16(data["users_id"]);
                uc.LoadLink(uc.UserId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                if (!_uc.ValidateChildren())
                {
                    Helper.MessageBoxError(_uc.GetFormErrors());
                    return false;
                }

                var collectingmodel = new CollectingOfficerModel()
                {
                    Id = _uc.OfficerId,
                    Prefix = _uc.txtPrefix.Text.Trim(),
                    FirstName = _uc.txtFirstName.Text.Trim(),
                    MiddleInitial = _uc.txtMiddleInitial.Text.Trim(),
                    LastName = _uc.txtLastName.Text.Trim(),
                    Suffix = _uc.txtSuffix.Text.Trim(),
                    JobTitle = _uc.txtJobtitle.Text.Trim(),
                    UserId = _uc.UserId
                };

                var collectingrepository = AccFactory.CollectingOfficerRepository();
                return collectingrepository.Update(collectingmodel);
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
                Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                _frmCollectingOfficer.LoadRecords();
            }
        }

        private void frmCollectingOfficerEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
            _uc.SetReadOnlyConrol(true);
            _uc.linkuser.LinkClicked -= new LinkLabelLinkClickedEventHandler(_uc.linkuser_LinkClicked);
        }
    }
}