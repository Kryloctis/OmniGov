using Accounting.Data;
using Accounting.Domain.Entities;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucCshDsbrsmntJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucCshDsbrsmntJrnl()
        {
            InitializeComponent();
        }

        internal string[] GetFormErrors()
        {
            return new string[]
            {
                errorProvider1.GetError(cmbxDsbrsngOffcr)
            };
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

            dtDatePaid.Value = Helper.GetCurrentDate();
            txtDvNo.Clear();
            cmbxDsbrsngOffcr.Refresh();
        }

        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;

            dtDatePaid.Value = Helper.GetCurrentDate();
            LoadDisbursingOfficer();

            if (isEdit)
            {
                this.jevId = jevId;
                LoadCshDsbrsmntData(jevId.Value);
            }
        }

        private void LoadCshDsbrsmntData(int jevId)
        {
            var cashDisbursementsDict = AccountingFactory.CashDisbursementsJournalRepository().GetViewRecordByJevID(jevId);

            if (cashDisbursementsDict is not null && cashDisbursementsDict.Count > 0)
            {
                dtDatePaid.Value = Convert.ToDateTime(cashDisbursementsDict["date_paid"]);
                txtDvNo.Text = cashDisbursementsDict["dv_no"];
                cmbxDsbrsngOffcr.SelectedValue = Convert.ToInt32(cashDisbursementsDict["disbursing_officers_id"]);
            }
        }

        private DataTable DataTableDisbursingOfficer()
        {
            var dtColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string)),
                new DataColumn(Name = "job_title", typeof(string)),
                new DataColumn(Name = "created_at", typeof(string)),
                new DataColumn(Name = "updated_at", typeof(string)),
                new DataColumn(Name = "users_id", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dtColumns);
            DataTable dtDisbursingOfficers = TreasuryFactory.DisbursingOfficerRepository().GetRecords();

            foreach (DataRow row in dtDisbursingOfficers.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowPrefix = row["prefix"].ToString();
                string rowFirstName = row["first_name"].ToString();
                string rowMiddleInitial = row["mid_initial"].ToString();
                string rowLastName = row["last_name"].ToString();
                string rowSuffix = row["suffix"].ToString();
                string rowJobTitle = row["job_title"].ToString();
                string rowCreatedAt = row["created_at"].ToString();
                string rowUpdatedAt = row["updated_at"].ToString();
                string rowUsersId = row["users_id"].ToString();

                var disbursingOfficerFullName = Helper.GenerateFullName(rowPrefix, rowFirstName, rowMiddleInitial, rowLastName, rowSuffix);

                var dtRow = dataTable.NewRow();
                dtRow["id"] = rowId;
                dtRow["full_name"] = disbursingOfficerFullName;
                dtRow["job_title"] = rowJobTitle;
                dtRow["created_at"] = rowCreatedAt;
                dtRow["updated_at"] = rowUpdatedAt;
                dtRow["users_id"] = rowUsersId;

                dataTable.Rows.Add(dtRow);
            }

            return dataTable;
        }

        internal void LoadDisbursingOfficer()
        {
            HelperLoadRecords.DisbursingOfficerComboBox(DataTableDisbursingOfficer(), cmbxDsbrsngOffcr, "full_name", "id");
        }

        internal CashDisbursementsJournalModel CashDisbursementsJournalModel()
        {
            int.TryParse(cmbxDsbrsngOffcr.SelectedValue.ToString(), out int dsbursingOffcrId);

            var model = new CashDisbursementsJournalModel()
            {
                DVNo = txtDvNo.Text.Trim(),
                DatePaid = dtDatePaid.Value,
                DisbursingOfficerId = dsbursingOffcrId
            };

            if (isEdit) model.JevId = jevId.Value;

            return model;
        }

        private void cmbxDsbrsngOffcr_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxDsbrsngOffcr, "Disbursing Officer");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxDsbrsngOffcr_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxDsbrsngOffcr);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}