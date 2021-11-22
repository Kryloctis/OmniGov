using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCD : Form
    {
        private readonly ucCollectorsRCD uc;
        private List<CollectorReportPaymentModel> data;


        public frmCollectorsRCD()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            uc = ucCollectorsRCD1;
        }

        private void CollectorsRCD_Load(object sender, EventArgs e)
        {
            ValidateLocalPermission();
        }


        private void ValidateLocalPermission()
        {
            if (!Helper.HasPermission("Transaction Approved RCD"))
                btnApprove.Visible = false;
            if (!Helper.HasPermission("Transaction Disapproved RCD"))
                btnDisapprove.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCD has been created.");
                uc.ResetForm();
            }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                //Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var collectorsReportModel = new CollectorReportModel()
            {
                CollectorId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                ReportNo = uc.txtReport.Text.Trim(),
                Date = Convert.ToDateTime(uc.dtdate.Value),
                IsApproved = 0,
                IsDisapproved = 0,
                FundId = uc.fundId,
                Remarks = String.Empty
            };

            bool rcdDetailsSaveSuccess = Factory.CollectorReportRepository().Insert(collectorsReportModel);

            if (!rcdDetailsSaveSuccess) return false;
            if (uc.dgPayments.Rows.Count == 0) return false;


            data = new List<CollectorReportPaymentModel>();
            data.Clear();


            foreach (DataGridViewRow item in uc.dgPayments.Rows)
            {
                var PaymentCollectionsId = Convert.ToInt16(item.Cells["payment_collection_id"].Value.ToString());

                var collectorReportPaymentModel = new CollectorReportPaymentModel()
                {
                    CollectorsReportId = CollectorsReportId(),
                    PaymentCollectionsId = PaymentCollectionsId
                };

                Factory.CollectorReportPaymentsRepository().Insert(collectorReportPaymentModel);
            }

            return true;
        }

        private int CollectorsReportId()
        {
            var collectorId = uc.collectorId;
            var reportNumber = uc.txtReport.Text;

            int collectorsReportId = Factory.CollectorReportRepository().GetReportId(collectorId, reportNumber);

            return collectorsReportId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmCollectorsRCDSearch(this, uc).ShowDialog();
        }


        internal void LoadSelectedValue(int reportId)
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(reportId);


                uc.collectorId = (ushort)Convert.ToInt16(rcdData["collecting_officers_id"]);
                uc.fundId = (byte)Convert.ToInt32(rcdData["funds_id"]);
                uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == Convert.ToInt16(rcdData["funds_id"])) ? r.Checked = true : r.Checked = false);
                uc.cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtReport.Text = rcdData["report_no"];
                uc.dtdate.Value = Convert.ToDateTime(rcdData["date"]);


                //uc.approved = Convert.ToBoolean(rcdData["is_approved"]) ? 1 : 0;
                //uc.status = rcdData["status"];
                //lblStatus.Text = rcdData["status"];
                //uc.remarks = rcdData["remarks"];
                //uc.LoadCollections();

                //HelperLoadRecords.PaymentDatagridView(uc.dtPaymentCollection, uc.dgvpayments);


                uc.cmbcollector.Enabled = false;
                uc.txtReport.Enabled = false;

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
