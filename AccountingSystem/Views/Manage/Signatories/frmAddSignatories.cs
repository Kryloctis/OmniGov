using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmAddSignatories : Form
    {
        private frmSignatories _frmSignatories;
        private ucSignatories uc;

        public frmAddSignatories(frmSignatories frmSignatories)
        {
            InitializeComponent();
            uc = ucSignatories1;
            _frmSignatories = frmSignatories;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Signatory has been saved");
                    uc.ResetForm();
                    _frmSignatories.LoadSignatories();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddSignatories_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            uc.isEdit = false;
            uc.LoadReferences();
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var signatoriesModel = new SignatoriesModel()
            {
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = Convert.ToChar(uc.txtMiddleInitial.Text),
                LastName = uc.txtLastName.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                Title = uc.txtTitle.Text.Trim()
            };

            var signatoriesHasDocumentReferences = new List<SignatoriesHasReferencesModel>();

            foreach (DataGridViewRow row in uc.dgReferences.Rows)
            {
                if (Convert.ToByte(row.Cells["is_referenced"].Value) == 1)
                {
                    var SignatoriesHasReferencesModel = new SignatoriesHasReferencesModel()
                    {
                        DocumentReferencesId = Convert.ToInt32(row.Cells["id"].Value)
                    };

                    signatoriesHasDocumentReferences.Add(SignatoriesHasReferencesModel);
                }
            }

            return AccFactory.SignatoriesRepository().Insert(signatoriesModel, signatoriesHasDocumentReferences);
        }
    }
}