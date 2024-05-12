using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmEditSignatories : Form
    {
        internal ucSignatories uc;
        private frmSignatories _frmSignatories;

        public frmEditSignatories(frmSignatories frmSignatories)
        {
            InitializeComponent();
            uc = ucSignatories1;
            _frmSignatories = frmSignatories;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Signatory has been updated.");
                    _frmSignatories.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditSignatories_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord()
        {
            var dictSignatories = AccFactory.SignatoriesRepository().GetRecordByID(uc.signatoriesId);

            uc.txtPrefix.Text = dictSignatories["prefix"];
            uc.txtFirstName.Text = dictSignatories["first_name"];
            uc.txtMiddleInitial.Text = dictSignatories["middle_initial"];
            uc.txtLastName.Text = dictSignatories["last_name"];
            uc.txtSuffix.Text = dictSignatories["suffix"];
            uc.txtTitle.Text = dictSignatories["title"];
        }

        private void OnLoad()
        {
            uc.isEdit = true;
            LoadSelectedRecord();
            uc.LoadReferences();
        }

        private bool UpdateData()
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

            return AccFactory.SignatoriesRepository().Update(signatoriesModel, signatoriesHasDocumentReferences);
        }
    }
}