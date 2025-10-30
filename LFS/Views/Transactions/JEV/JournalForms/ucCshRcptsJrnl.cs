using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucCshRcptsJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucCshRcptsJrnl()
        {
            InitializeComponent();
        }

        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;

            LoadCollectingOfficer();
            dtOrDate.Value = Helper.GetCurrentDate();

            if (isEdit)
            {
                this.jevId = jevId;
                LoadCshRcptsData(jevId.Value);
            }
        }

        private void LoadCshRcptsData(int jevId)
        {
            var checkDisbursementsDict = AccFactory.CashReceiptsJournalRepository().GetViewRecordByJevID(jevId);

            if (checkDisbursementsDict is not null && checkDisbursementsDict.Count > 0)
            {
                txtRcdNo.Text = checkDisbursementsDict["rcd_no"];
                cmbxCollctngOffcr.SelectedValue = checkDisbursementsDict["collecting_officers_id"];
                txtOrNo.Text = checkDisbursementsDict["or_no"];
                dtOrDate.Value = Convert.ToDateTime(checkDisbursementsDict["or_date"]);
            }
        }

        internal string[] GetFormErrors()
        {
            return new string[]
            {
                errorProvider1.GetError(cmbxCollctngOffcr),
            };
        }

        internal void ResetFields()
        {
            txtOrNo.Clear();
            dtOrDate.Value = Helper.GetCurrentDate();
            txtRcdNo.Clear();
            LoadCollectingOfficer();
        }

        private DataTable DataTableCollectingOfficer()
        {
            var dtColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dtColumns);
            var dtCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dtCollectingOfficer.Rows)
            {
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string midInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);
                int Id = Convert.ToInt32(row["id"]);

                var newRow = dataTable.NewRow();

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private void LoadCollectingOfficer()
        {
            HelperLoadRecords.CollectingOfficerComboBox(DataTableCollectingOfficer(), cmbxCollctngOffcr, "full_name", "id");
        }

        internal CashReceiptsJournalModel @CashReceiptsJournalModel()
        {
            int.TryParse(cmbxCollctngOffcr.SelectedValue.ToString(), out int cllctngOffcrId);

            var model = new CashReceiptsJournalModel
            {
                ORDate = dtOrDate.Value,
                ORNo = txtOrNo.Text.Trim(),
                RCDNo = txtRcdNo.Text.Trim(),
                CollectingOfficerId = (byte)cllctngOffcrId
            };

            if (isEdit) model.JevId = jevId.Value;

            return model;
        }

        private void cmbxCollctngOffcr_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxCollctngOffcr, "Collecting Officer");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxCollctngOffcr_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxCollctngOffcr);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}