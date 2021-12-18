using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmEditSignatories : Form
    {
        internal ucSignatories uc;
        frmSignatories _frmSignatories;

        public frmEditSignatories(frmSignatories frmSignatories)
        {
            InitializeComponent();
            uc = ucSignatories1;
            _frmSignatories = frmSignatories;
        }

        private void LoadSelectedRecord()
        {
            var dictSignatories = Factory.SignatoriesRepository().GetRecordByID(uc.signatoriesId);

            uc.txtPrefix.Text = dictSignatories["prefix"];
            uc.txtFirstName.Text = dictSignatories["first_name"];
            uc.txtMiddleInitial.Text = dictSignatories["middle_initial"];
            uc.txtLastName.Text = dictSignatories["last_name"];
            uc.txtSuffix.Text = dictSignatories["suffix"];
            uc.txtTitle.Text = dictSignatories["title"];
        }

        private bool UpdateData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var signatoriesModel = new SignatoriesModel()
                {
                    Id = uc.signatoriesId,
                    Prefix = uc.txtPrefix.Text.Trim(),
                    FirstName = uc.txtFirstName.Text.Trim(),
                    MiddleInitial = Convert.ToChar(uc.txtMiddleInitial.Text),
                    LastName = uc.txtLastName.Text.Trim(),
                    Suffix = uc.txtSuffix.Text.Trim(),
                    Title = uc.txtTitle.Text.Trim()
                };

                return Factory.SignatoriesRepository().Update(signatoriesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Signatory has been updated.");
                _frmSignatories.LoadSignatories();
                Close();
            }
        }

        private void frmEditSignatories_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
            LoadSelectedRecord();
        }
    }
}
