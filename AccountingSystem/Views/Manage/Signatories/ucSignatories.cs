using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class ucSignatories : UserControl
    {
        internal int signatoriesId = 0;
        internal bool isEdit = false;

        public ucSignatories()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            if (isEdit)
                signatoriesId = 0;

            txtPrefix.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSuffix.Text = string.Empty;
            txtTitle.Text = string.Empty;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtPrefix),
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtMiddleInitial),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtTitle),
                dgReferences.Tag.ToString()
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ValidatePermissions()
        {
            string office = Helper.LoggedInUserData()["office"];

            switch (office)
            {
                case "Budget":
                    cmbxOfficeFilter.Text = "Budget";
                    cmbxOfficeFilter.Enabled = false;
                    break;
                case "Accounting":
                    cmbxOfficeFilter.Text = "Accounting";
                    cmbxOfficeFilter.Enabled = false;
                    break;
                case "Treasury":
                    cmbxOfficeFilter.Text = "Treasury";
                    cmbxOfficeFilter.Enabled = false;
                    break;

                default:
                    cmbxOfficeFilter.Enabled = true;
                    break;
            }
        }

        private void ValidateReferenced()
        {
            try
            {
                foreach (DataGridViewRow row in dgReferences.Rows)
                {
                    int referenceId = Convert.ToInt32(row.Cells["id"].Value);
                    bool isReferenced = Factory.SignatoriesHasReferencesRepository().ReferenceIdExist(referenceId);
                    bool isReferencedBySignatoryId = Factory.SignatoriesHasReferencesRepository().ReferenceIdExist(referenceId, signatoriesId);

                    if (!isEdit ? isReferenced : isReferencedBySignatoryId)
                    {
                        row.ReadOnly = true;
                        row.DefaultCellStyle.BackColor = Color.DarkGray;
                        row.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region References

        internal void LoadReferences()
        {
            HelperLoadRecords.ReferencesDatagridView(null, dgReferences);
            string office = cmbxOfficeFilter.Text.Trim();
            var dtViewDocumentReferences = Factory.DocumentReferencesRepository().GetViewRecordsByOffice(office);

            foreach (DataRow row in dtViewDocumentReferences.Rows)
            {
                int documentReferencesId = Convert.ToInt32(row["document_references_id"]);
                bool isReferenced = Factory.SignatoriesHasReferencesRepository().IsReferencedBySignatory(documentReferencesId, signatoriesId);

                var data = new object[]
                {
                    documentReferencesId,
                    isEdit? isReferenced : false,
                    row["document_references_name"],
                    row["documents_name"]
                };

                dgReferences.Rows.Add(data);
            }

            ValidateReferenced();
        }

        #endregion

        #region Validation

        private void txtPrefix_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPrefix, "Prefix");
        }

        private void txtPrefix_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPrefix);
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "First Name");
        }

        private void txtFirstName_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtMiddleInitial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMiddleInitial, "Middle Initial");
        }

        private void txtMiddleInitial_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMiddleInitial);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "Last Name");
        }

        private void txtLastName_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtTitle, "Title");
        }

        private void txtTitle_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtTitle);
        }


        private List<int> SelectedReferences()
        {
            List<int> referencesIdList = new List<int>();

            foreach (DataGridViewRow row in dgReferences.Rows)
            {
                var isReferenced = Convert.ToBoolean(row.Cells["is_referenced"].Value);
                if (isReferenced)
                    referencesIdList.Add(Convert.ToInt32(row.Cells["id"].Value));
            }

            return referencesIdList;
        }

        private bool ReferencesIsEmpty()
        {
            if (SelectedReferences().Count < 1)
            {
                dgReferences.Tag = "No reference has been selected";
                return true;
            }
            return false;
        }

        #endregion

        private void ucSignatories_Load(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
                cmbxOfficeFilter.SelectedIndex = 0;
                ValidatePermissions();
                LoadReferences();
            }
        }

        private void dgReferences_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgReferences_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ReferencesIsEmpty();
        }

        private void dgReferences_Validated(object sender, EventArgs e)
        {
            dgReferences.Tag = string.Empty;
        }

        private void cmbxOfficeFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadReferences();
        }
    }
}
