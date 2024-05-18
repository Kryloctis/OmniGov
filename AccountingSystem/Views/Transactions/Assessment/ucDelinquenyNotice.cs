using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Data;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Assessment;
using DocumentFormat.OpenXml.Office2010.PowerPoint;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class ucDelinquenyNotice : UserControl
    {
        private int rptId;

        public ucDelinquenyNotice()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgDelinquencies, true);
        }

        internal void OnLoad()
        {
            LoadRealProperties();
        }

        internal void ResetForm()
        {
            rad1stNotice.Checked = true;
            radLand.Checked = true;
            dtPckrDate.Value = Helper.GetCurrentDate();
            LoadRealProperties();
        }

        private void LoadRealProperties()
        {
            var dtRealProperties = new DataTable();

            if (radLand.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewArpNoRecordsByKind('L');
            else if (radBuilding.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewArpNoRecordsByKind('B');
            else if (radMachinery.Checked)
                dtRealProperties = AccFactory.RealPropertiesRepository().GetViewArpNoRecordsByKind('M');

            var autoCompleteSrc = dtRealProperties.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void ResetRealProperty()
        {
            txtRpt.Clear();
            txtOwner.Clear();
            txtLocation.Clear();
            txtAssessedValue.Clear();
        }

        private void LoadRptDetails(Dictionary<string, string> dictRpt)
        {
            if (dictRpt is null || dictRpt.Count < 1)
            {
                txtOwner.Clear();
                txtLocation.Clear();
                txtAssessedValue.Clear();
                return;
            };

            txtOwner.Text = dictRpt["taxpayer_name"].ToString();
            txtLocation.Text = $"{dictRpt["barangay_name"]}, {dictRpt["municipality_name"]}, {dictRpt["province_name"]}";
            txtAssessedValue.Text = Convert.ToDecimal(dictRpt["assessed_value"]).ToString("N2");
            LoadRptDelinquencies();
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dictRpt = AccFactory.RealPropertiesRepository().GetViewRecordByCompleteArpNo(txtRpt.Text);
                LoadRptDetails(dictRpt);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radLand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radBuilding_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radMachinery_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ResetRealProperty();
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRptDelinquencies()
        {
            if (!bgwDelinquencies.IsBusy)
            {
                pbDelinquencies.Value = 0;
                bgwDelinquencies.RunWorkerAsync();
            }
        }

        private void bgwDelinquencies_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("tax_year", typeof(int)),
                    new DataColumn("tax_type", typeof(string)),
                    new DataColumn("tax_amount", typeof(string)),
                    new DataColumn("penalty_amount", typeof(string)),
                    new DataColumn("total_amount", typeof(string)),
                };

                dataTable.Columns.AddRange(dataColumns);
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
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}