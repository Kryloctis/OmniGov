using LFS.Helpers;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Domain.Entities;
using Treasury.Data.Factories;

namespace LFS.Views.Transactions.CashTicketIssuance
{
    public partial class ucCashTicketIssuance : UserControl
    {
        private bool isEdit;

        internal int unusedCashTcktCount;
        internal int usedCashTcktCount;

        public ucCashTicketIssuance()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbCollector),
                errorProvider1.GetError(cmbxCashTickets),
                errorProvider1.GetError(nudQuantity),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadCollectors()
        {
            DataTable dataTable = cbCollectingOfficerTypeJO.Checked ? DataTableJobOrderCollectionOfficers() : DataTableRegularCollectingOfficers();
            HelperLoadRecords.CollectingOfficerComboBox(dataTable, cmbCollector, "full_name", "id");
        }

        private void LoadCashTickets()
        {
            DataTable cashTicketsDT = TreasuryFactory.CashTicketsRepository().GetRecords();

            foreach (DataRow row in cashTicketsDT.Rows)
            {
                int cashTicketId = Convert.ToInt32(row["id"]);
                string description = row["description"].ToString();
                int cashTicketStockQty = Convert.ToInt32(row["quantity"]);
            }

            HelperLoadRecords.CashTicketsCmbx(cmbxCashTickets, cashTicketsDT);
        }

        internal void LoadSelectedValue(Dictionary<string, string> dictSelectedData)
        {
            if (dictSelectedData == null) return;

            string joId = dictSelectedData["jo_id"];
            string coId = dictSelectedData["co_id"];

            int.TryParse(string.IsNullOrEmpty(joId) ? coId : joId, out int collectorsId);
            int.TryParse(dictSelectedData["cash_tickets_id"], out int cashTcktId);
            int.TryParse(dictSelectedData["quantity"], out int quantity);
            DateTime.TryParse(dictSelectedData["date_issued"], out DateTime dateIssued);

            cbCollectingOfficerTypeJO.Checked = !string.IsNullOrEmpty(joId);
            cmbCollector.SelectedValue = collectorsId;
            cmbxCashTickets.SelectedValue = cashTcktId;
            dtpDateIssued.Value = dateIssued;
            nudQuantity.Text = quantity.ToString();
        }

        internal void OnLoad(bool isEdit)
        {
            this.isEdit = isEdit;

            LoadCollectors();
            LoadCashTickets();
            GetCashTckStat();
        }

        private (int coId, int? joId) GetCollectorsId()
        {
            bool isJo = cbCollectingOfficerTypeJO.Checked;
            int CoJoId = Convert.ToInt32(cmbCollector.SelectedValue);
            (int coId, int? joId) collectorsId = (isJo ? (GetCoId(CoJoId), CoJoId) : (CoJoId, null));

            int GetCoId(int joId)
            {
                var coId = TreasuryFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(joId);
                return coId;
            }

            return collectorsId;
        }

        internal CashTicketsIssuedModel CashTicketsIssuedModel()
        {
            var collectorsId = GetCollectorsId();
            var model = new CashTicketsIssuedModel()
            {
                CollectorId = collectorsId.coId,
                DateIssued = dtpDateIssued.Value,
                IssuedBy = UserHelper.loggedUser.Id,
                CashTicketId = Convert.ToInt32(cmbxCashTickets.SelectedValue),
                JobOrderId = collectorsId.joId,
                Quantity = (int)nudQuantity.Value
            };

            return model;
        }

        internal void ResetForm()
        {
            nudQuantity.Value = 0;
            dtpDateIssued.Value = DateTime.Today;
            LoadCollectors();
            LoadCashTickets();
        }

        private DataColumn[] DataColumnsCollectingOfficers()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };
        }

        private DataTable DataTableRegularCollectingOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            DataTable dtCollectingOfficers = TreasuryFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dtCollectingOfficers.Rows)
            {
                var newRow = dataTable.NewRow();
                int Id = Convert.ToInt32(row["id"]);
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string middleInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private DataTable DataTableJobOrderCollectionOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            DataTable dtCollectingOfficerHasJobOrder = TreasuryFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecords();

            foreach (DataRow row in dtCollectingOfficerHasJobOrder.Rows)
            {
                int jobOrderId = Convert.ToInt32(row["jo_id"]);
                string prefix = row["jo_prefix"].ToString();
                string firstName = row["jo_first_name"].ToString();
                string middleInitial = row["jo_mid_initial"].ToString();
                string lastName = row["jo_last_name"].ToString();
                string suffix = row["jo_suffix"].ToString();
                string jobOrderFullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                var newRow = dataTable.NewRow();
                newRow["id"] = jobOrderId;
                newRow["full_name"] = jobOrderFullName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void cbCollectingOfficerTypeJO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCollectors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudQuantity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudQuantity, "Quantity");
                int quantity = Convert.ToInt32(nudQuantity.Value);

                if (unusedCashTcktCount < quantity)
                {
                    errorProvider1.SetError(nudQuantity, "Not enough quantity.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudQuantity_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorNumericUpDown(errorProvider1, nudQuantity);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void GetCashTckStat()
        {
            if (cmbxCashTickets.SelectedValue is null) return;
            var dtrCashTckt = cmbxCashTickets.SelectedItem as DataRowView;
            int.TryParse(dtrCashTckt["quantity"].ToString(), out int origCashTcktQnty);
            int.TryParse(dtrCashTckt["id"].ToString(), out int cashTcktId);

            var issdCashTcktQnty = TreasuryFactory.CashTicketsIssuedRepository().GetIssuedCountByCashTcktId(cashTcktId);

            usedCashTcktCount = issdCashTcktQnty;
            unusedCashTcktCount = origCashTcktQnty - issdCashTcktQnty;

            nudQuantity.Maximum = unusedCashTcktCount;
            var cashTcktStat = $"used:{usedCashTcktCount}       unused: {unusedCashTcktCount}";
            lblCashTcktStat.Text = cashTcktStat;
        }

        private void cmbxCashTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCashTckStat();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

