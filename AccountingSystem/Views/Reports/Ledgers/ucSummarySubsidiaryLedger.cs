using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucSummarySubsidiaryLedger : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucSummarySubsidiaryLedger()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadAccounts();
                LoadFunds();
                LoadYear();
            }
        }

        private void ucSummarySubsidiaryLedger_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    OnLoad();
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            DataTable dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadYear()
        {
            nudYear.Value = Helper.GetCurrentDate().Year;
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbxAccount.Text))
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbxAccount.Text);

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            cmbxAccount.DroppedDown = false;

            if (DatatableAccounts().Rows.Count == 0) return;

            Dictionary<ushort, string> accountDict = new Dictionary<ushort, string>();
            foreach (DataRow item in DatatableAccounts().Rows)
            {
                ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                accountDict.Add(accountId, accountName);
            }

            cmbxAccount.DataSource = new BindingSource(accountDict, null);
            cmbxAccount.DisplayMember = "value";
            cmbxAccount.ValueMember = "key";
            Cursor.Current = Cursors.Default;
        }
    }
}