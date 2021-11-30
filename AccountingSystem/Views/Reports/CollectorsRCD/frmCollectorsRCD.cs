using ACC.Domain.Models;
using AccountingSystem.Views.Reports.PaymentCollection;
using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

            if (uc.dgPayments.Rows.Count == 0) return;
            
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

            using (var scope = new TransactionScope())
            {
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
                    var CollectorsReportId = GetCollectorsReportId();
                    var PaymentCollectionsId = Convert.ToInt16(item.Cells["payment_collection_id"].Value.ToString());

                    var collectorReportPaymentModel = new CollectorReportPaymentModel()
                    {
                        CollectorsReportId = CollectorsReportId,
                        PaymentCollectionsId = PaymentCollectionsId
                    };

                    Factory.CollectorReportPaymentsRepository().Insert(collectorReportPaymentModel);
                }

                scope.Complete();
                return true;
            }
        }

        private int GetCollectorsReportId()
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


        internal void LoadSelectedValue(string reportNo)
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(reportNo);


                uc.collectorId = (ushort)Convert.ToInt16(rcdData["collecting_officers_id"]);
                uc.fundId = (byte)Convert.ToInt32(rcdData["funds_id"]);
                uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == Convert.ToInt16(rcdData["funds_id"])) ? r.Checked = true : r.Checked = false);
                uc.cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtReport.Text = rcdData["report_no"];
                uc.dtdate.Value = Convert.ToDateTime(rcdData["date"]);


                var collectionOfPaymentReportsRepo = Factory.CollectorReportPaymentsRepository();
                var collectionOfPaymentReportDt = collectionOfPaymentReportsRepo.GetRecordsByReportNo(reportNo);
                HelperLoadRecords.PaymentDatagridView(collectionOfPaymentReportDt, uc.dgPayments);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void CheckRCDStatus(string reportNo)
        {
            try
            {
                switch (Factory.CollectorReportRepository().GetRCDStatus(reportNo))
                {
                    case "pending":
                        //PENDING
                        lblJevStatus.Text = "PENDING";
                        lblJevStatus.ForeColor = Color.FromArgb(216, 146, 22);
                        lblShowMessage.Visible = false;
                        btnPrint.Enabled = false;
                        btnApprove.Enabled = true;
                        btnDisapprove.Enabled = true;
                        btnDelete.Enabled = true;
                        uc.Enabled = true;
                        //btnSave.Enabled = true;
                        break;
                    case "approved":
                        //APPROVED
                        lblJevStatus.Text = "APPROVED";
                        lblJevStatus.ForeColor = Color.FromArgb(78, 159, 61);
                        lblShowMessage.Visible = false;
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnPrint.Enabled = true;
                        btnSave.Enabled = true;
                        uc.Enabled = false;
                        //btnDelete.Enabled = false;
                        //btnSave.Enabled = false;
                        break;
                    case "disapproved":
                        //DISSAPROVED
                        lblJevStatus.Text = "DISAPPROVED";
                        lblJevStatus.ForeColor = Color.FromArgb(149, 1, 1);
                        lblShowMessage.Visible = true;
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnPrint.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        uc.Enabled = false;
                        break;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        private bool SetRCDStatus(byte status, string reportNo)
        {
            try
            {

                var updateResult = Factory.CollectorReportRepository().SetRCDStatus(status, reportNo);

                return updateResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                string reportNo = uc.txtReport.Text;
                if (String.IsNullOrEmpty(reportNo)) return;

            

                if (MessageBox.Show("Are you sure you want to approved this Collector's Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SetRCDStatus(1, reportNo))
                    {
                        Helper.MessageBoxSuccess("Collector's Report has been approved.");
                        CheckRCDStatus(reportNo);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
            }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            var frmCollectorsRCDRemarks = new frmCollectorsRCDRemarks(this);

            if (uc.Enabled)
            {
                frmCollectorsRCDRemarks.btnAccept.Visible = false;
                frmCollectorsRCDRemarks.btnCancel.Text = "Close";
            }

            frmCollectorsRCDRemarks.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _ = new frmCDReport("30").ShowDialog();
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {

            string reportNo = uc.txtReport.Text;
            if (String.IsNullOrEmpty(reportNo)) return;


            if (MessageBox.Show("Are you sure you want to disapproved this Collector's Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SetRCDStatus(2, reportNo))
                {
                    Helper.MessageBoxSuccess("Collector's Report has been disapproved.");
                    if (MessageBox.Show("Do you want to add disapproval message?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _ = new frmCollectorsRCDRemarks(this).ShowDialog();
                    }
                    CheckRCDStatus(reportNo);
                }
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            uc.ResetForm();
        }
    }
}
