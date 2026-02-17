using Accounting.Data.Factories;
using Accounting.Domain.Entities;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data;

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
            var checkDisbursementsDict = AccountingFactory.CashReceiptsJournalRepository().GetViewRecordByJevID(jevId);

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

        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

            txtOrNo.Clear();
            dtOrDate.Value = Helper.GetCurrentDate();
            txtRcdNo.Clear();
            cmbxCollctngOffcr.Refresh();
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
            var dtCollectingOfficer = TreasuryFactory.CollectingOfficerRepository().GetRecords();

            var officerData = dtCollectingOfficer
                .AsEnumerable()
                .Select(o => new
                {
                    Id = o.Field<byte>("id"),
                    FullName = Helper.GenerateFullName(
                        o.Field<string>("prefix"),
                        o.Field<string>("first_name"),
                        o.Field<string>("mid_initial"),
                        o.Field<string>("last_name"),
                        o.Field<string>("suffix")
                    )
                })
                .ToList();

            // Fill target DataTable
            foreach (var item in officerData)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = item.Id;
                newRow["full_name"] = item.FullName;
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
