using ACC.Data;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom33 : Form
    {
        private ucCancellationOfWarrantOfLevy UcCancellationOfWarrantOfLevy;
        private DataTable dtRpt;

        public frmLtom33()
        {
            InitializeComponent();
            UcCancellationOfWarrantOfLevy = ucCancellationOfWarrantOfLevy1;
        }

        private void LoadReport()
        {
            try
            {
                int warrantOfLevyId = Convert.ToInt32(cmbxWarrantLevy.SelectedValue);

                if (cmbxWarrantLevy.SelectedIndex == -1)
                    return;

                UcCancellationOfWarrantOfLevy.OnLoad(warrantOfLevyId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            LoadIssuedWarrantLevy();
        }

        private void frmLtom33_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRealProperties()
        {
            dtRpt = AccFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadIssuedWarrantLevy()
        {
            var rptId = dtRpt.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            if (rptId is not null)
            {
                var dtNoticeDelinquencies = AccFactory.RptLevyRepository().GetCancelledLevy(Convert.ToInt32(rptId));
                cmbxWarrantLevy.DataSource = dtNoticeDelinquencies;
                cmbxWarrantLevy.ValueMember = "rpt_levy_id";
                cmbxWarrantLevy.DisplayMember = "date_issued";
            }
        }
    }
}
