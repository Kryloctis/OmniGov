using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Shared;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class ucDelinquenyNotice : UserControl
    {
        private bool isEdit;
        private int delinquencyNoticeId;
        private DataTable dtRealProperties;

        public ucDelinquenyNotice()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgDelinquencies, true);
        }

        private string GetNoticeType()
        {
            if (rad1stNotice.Checked)
                return "1st Notice";
            else if (rad2ndNotice.Checked)
                return "2nd Notice";
            else
                return "3rd Notice";
        }

        private void LoadSelectedRecord(int delinquencyNoticeId)
        {
            dtPckrDate.ValueChanged -= new EventHandler(dtPckrDate_ValueChanged);

            var dictDelinquencyNoticeId = AccFactory.DelinquentNoticeRepository().GetViewRecordById(delinquencyNoticeId);
            dtPckrDate.Value = Convert.ToDateTime(dictDelinquencyNoticeId["notice_date"]);
            string propertyKind = dictDelinquencyNoticeId["property_kind"];
            string noticeType = dictDelinquencyNoticeId["notice_type"];

            switch (propertyKind)
            {
                case "L":
                    radLand.Checked = true;
                    break;

                case "B":
                    radBuilding.Checked = true;
                    break;

                case "M":
                    radMachinery.Checked = true;
                    break;
            }

            switch (noticeType)
            {
                case "1st Notice":
                    rad1stNotice.Checked = true;
                    break;

                case "2nd Notice":
                    rad2ndNotice.Checked = true;
                    break;

                case "3rd Notice":
                    rad3rdNotice.Checked = true;
                    break;
            }

            txtRpt.Text = dictDelinquencyNoticeId["complete_arp_no"];
            dtPckrDate.ValueChanged += new EventHandler(dtPckrDate_ValueChanged);
        }

        private DelinquentNoticeModel InsertDelinquentNoticeModel()
        {
            var dictRpt = dtRealProperties.AsEnumerable().Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text).FirstOrDefault();

            return new DelinquentNoticeModel()
            {
                NoticeDate = dtPckrDate.Value,
                NoticeType = GetNoticeType(),
                RealPropertiesId = Convert.ToInt32(dictRpt["real_property_id"]),
                CreatedBy = Helper.userId,
            };
        }

        private DelinquentNoticeModel UpdateDelinquentNoticeModel()
        {
            var dictRpt = dtRealProperties.AsEnumerable().Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text).FirstOrDefault();

            return new DelinquentNoticeModel()
            {
                Id = delinquencyNoticeId,
                NoticeDate = dtPckrDate.Value,
                NoticeType = GetNoticeType(),
                RealPropertiesId = Convert.ToInt32(dictRpt["real_property_id"]),
                UpdatedBy = Helper.userId,
            };
        }

        internal bool InsertData()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            var model = InsertDelinquentNoticeModel();
            return AccFactory.DelinquentNoticeRepository().Insert(model);
        }

        internal bool UpdateData()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            var model = UpdateDelinquentNoticeModel();
            return AccFactory.DelinquentNoticeRepository().Update(model);
        }

        internal void OnLoad(bool isEdit, int? delinquencyNoticeId = null)
        {
            this.isEdit = isEdit;
            LoadRealProperties();

            if (isEdit)
            {
                this.delinquencyNoticeId = delinquencyNoticeId.Value;
                LoadSelectedRecord(this.delinquencyNoticeId);
            }
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtRpt)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtRpt.Clear();
            rad1stNotice.Checked = true;
            radLand.Checked = true;
            dtPckrDate.Value = Helper.GetCurrentDate();
            LoadRealProperties();
        }

        private void LoadRealProperties()
        {
            var dtRealProperties = new DataTable();

            if (radLand.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewRecordsByKind('L');
            else if (radBuilding.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewRecordsByKind('B');
            else if (radMachinery.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewRecordsByKind('M');

            var autoCompleteSrc = dtRealProperties.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;

            this.dtRealProperties = dtRealProperties;
        }

        private void ResetRealProperty()
        {
            txtRpt.Clear();
            txtOwner.Clear();
            txtLocation.Clear();
            txtAssessedValue.Clear();
            LoadRealProperties();
        }

        private void radLand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radBuilding_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radMachinery_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRptDetails(DataRow dataRow)
        {
            if (dataRow is null)
            {
                txtOwner.Clear();
                txtLocation.Clear();
                txtAssessedValue.Clear();
                LoadRptDelinquencies();
                return;
            };

            txtOwner.Text = dataRow["taxpayer_name"].ToString();
            txtLocation.Text = $"{dataRow["barangay_name"]}, {dataRow["municipality_name"]}, {dataRow["province_name"]}";
            txtAssessedValue.Text = Convert.ToDecimal(dataRow["assessed_value"]).ToString("N2");
            LoadRptDelinquencies();
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rptDetails = dtRealProperties.AsEnumerable().Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text).FirstOrDefault();
                LoadRptDetails(rptDetails);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private (decimal basicPenalty, decimal sefPenalty) GetPenalties(DateTime transactionDate, (int assessmentYear, string compelteArpNo, int effectivityQuarter, int effectivityYear) currentAssmntParameters, decimal penaltyRate, decimal basicTaxDue, decimal sefTaxDue)
        {
            var dictPrevAssmnt = AccFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(currentAssmntParameters.compelteArpNo, currentAssmntParameters.assessmentYear);

            int? prevAssmntYear = null;

            if (dictPrevAssmnt.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(transactionDate, (currentAssmntParameters.assessmentYear, currentAssmntParameters.effectivityQuarter, currentAssmntParameters.effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            return (basicPenalty, sefPenalty);
        }

        private void LoadRptDelinquencies()
        {
            if (!bgwDelinquencies.IsBusy)
            {
                pbDelinquencies.Value = 0;
                string completeArpNo = txtRpt.Text;
                var delinquencyNoticeDate = dtPckrDate.Value;
                bgwDelinquencies.RunWorkerAsync((completeArpNo, delinquencyNoticeDate));
            }
        }

        private void bgwDelinquencies_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string completeArpNo, DateTime date))e.Argument;
                var dataTable = new DataTable();
                var dtAssessmentPostingDb = AccFactory.RptAssessmentPostsRepository().GetViewDelinquentRecords(parameters.completeArpNo, parameters.date);
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("tax_year", typeof(int)),
                    new DataColumn("tax_type", typeof(string)),
                    new DataColumn("tax_due", typeof(string)),
                    new DataColumn("penalty_amount", typeof(string)),
                    new DataColumn("total_amount", typeof(string)),
                };

                dataTable.Columns.AddRange(dataColumns);
                int totalProgressCount = dtAssessmentPostingDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dtAssessmentPostingDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    decimal assessedValue = Convert.ToDecimal(dataRow["assessed_value"]);
                    decimal basicRate = Convert.ToDecimal(dataRow["basic_rate"]);
                    decimal sefRate = Convert.ToDecimal(dataRow["sef_rate"]);
                    string completeArpNo = dataRow["complete_arp_no"].ToString();
                    int assessmentYear = Convert.ToInt32(dataRow["year"]);
                    int effectivityQuarter = Convert.ToInt32(dataRow["effectivity_quarterly"]);
                    int effectivityYear = Convert.ToInt32(dataRow["effectivity_year"]);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal penaltyRate = Convert.ToDecimal(dataRow["penalty_rate"]);

                    var penaltyParameters = (assessmentYear, completeArpNo, effectivityQuarter, effectivityYear);
                    var penalties = GetPenalties(dtPckrDate.Value, penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);

                    if (penalties.basicPenalty <= 0 && penalties.sefPenalty <= 0)
                    {
                        totalProgressCount--;
                        Helper.ProgressCounter(bgwDelinquencies, totalProgressCount, progressCount);
                        continue;
                    }

                    newRow["tax_year"] = dataRow["year"];
                    newRow["tax_type"] = "Basic\nSEF";
                    newRow["tax_due"] = $"{basicTaxDue.ToString("N2")}\n{sefTaxDue.ToString("N2")}";
                    newRow["penalty_amount"] = $"{penalties.basicPenalty.ToString("N2")}\n{penalties.sefPenalty.ToString("N2")}";
                    newRow["total_amount"] = (penalties.basicPenalty + penalties.sefPenalty).ToString("N2");
                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(bgwDelinquencies, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwDelinquencies_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pbDelinquencies.Value = e.ProgressPercentage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwDelinquencies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    pbDelinquencies.Value = 100;

                dgDelinquencies.DataSource = dataTable;
                dgDelinquencies.Columns["tax_year"].HeaderText = "Year";
                dgDelinquencies.Columns["tax_type"].HeaderText = "Type";
                dgDelinquencies.Columns["tax_due"].HeaderText = "Tax Due";
                dgDelinquencies.Columns["tax_due"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.Columns["tax_due"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.Columns["penalty_amount"].HeaderText = "Penalty";
                dgDelinquencies.Columns["penalty_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.Columns["penalty_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.Columns["total_amount"].HeaderText = "Total";
                dgDelinquencies.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.Columns["total_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDelinquencies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgDelinquencies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtPckrDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRptDelinquencies();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ValidateDelinquencies(ErrorProvider errorProvider, TextBox textBox, DataGridView dataGridView, string errorMessage)
        {
            if (dataGridView.Rows.Count < 1)
            {
                errorProvider.SetError(textBox, errorMessage);
                return false;
            }
            return true;
        }

        private void dgDelinquencies_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ValidateDelinquencies(errorProvider1, txtRpt, dgDelinquencies, "No record of delinquencies found");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgDelinquencies_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRpt);
        }
    }
}