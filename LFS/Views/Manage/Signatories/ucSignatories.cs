using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LFS.Views.Manage.Signatories
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

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ValidateReferenced()
        {
            foreach (DataGridViewRow row in dgReferences.Rows)
            {
                int referenceId = Convert.ToInt32(row.Cells["id"].Value);
                bool isReferenced = AccFactory.SignatoriesHasReferencesRepository().ReferenceIdExist(referenceId);
                bool isReferencedBySignatoryId = AccFactory.SignatoriesHasReferencesRepository().ReferenceIdExist(referenceId, signatoriesId);

                if (!isEdit ? isReferenced : isReferencedBySignatoryId)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                    row.DefaultCellStyle.SelectionForeColor = Color.Gray;
                }
            }
        }

        #region References

        internal void LoadReferences()
        {
            HelperLoadRecords.ReferencesDatagridView(null, dgReferences);
            dgReferences.RowHeadersVisible = false;
            string office = cmbxOfficeFilter.Text.Trim();
            var dtViewDocumentReferences = AccFactory.DocumentReferencesRepository().GetViewRecordsByOffice(office);

            foreach (DataRow row in dtViewDocumentReferences.Rows)
            {
                int documentReferencesId = Convert.ToInt32(row["document_references_id"]);
                bool isReferenced = AccFactory.SignatoriesHasReferencesRepository().IsReferencedBySignatory(documentReferencesId, signatoriesId);

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

        #endregion References

        private void ucSignatories_Load(object sender, System.EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                cmbxOfficeFilter.SelectedIndex = 0;
            }
        }

        private void dgReferences_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmbxOfficeFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadReferences();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region Validations

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

        private void dgReferences_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = ReferencesIsEmpty();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgReferences_Validated(object sender, EventArgs e)
        {
            dgReferences.Tag = string.Empty;
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

        #endregion Validations
    }
}