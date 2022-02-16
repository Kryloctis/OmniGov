using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCD : Form
    {
        internal readonly ucCollectorsRCD uc;
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
            if (!Helper.HasPermission("Transaction RCD Approval"))
            {
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uc.isSaveFunction)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Collector's report has been created.");
                    CheckRCDStatus(uc.txtReport.Text.Trim());
                    ResetLocalControls();
                    uc.ResetForm();
                }
            }

            else
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Collector's report has been updated.");
                    CheckRCDStatus(uc.txtReport.Text.Trim());
                    ResetLocalControls();
                    uc.ResetForm();
                }
            }

        }

        private bool UpdateData()
        {

            using (var scope = new TransactionScope())
            {
                var collectorsReportModel = new CollectorReportModel()
                {
                    Id = uc.reportId,
                    CollectorId = Convert.ToInt16(uc.cmbCollector.SelectedValue),
                    ReportNo = uc.txtReport.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtRCDDate.Value),
                    IsApproved = 0,
                    IsDisapproved = 0,
                    FundId = uc.fundId,
                    Remarks = string.Empty
                };

                bool rcdDetailsUpdateSuccess = Factory.CollectorReportRepository().Update(collectorsReportModel);
                var collectorReportPaymentModel = new CollectorReportPaymentModel() { CollectorsReportId = uc.reportId };
                bool isDeleteSuccess = Factory.CollectorReportPaymentsRepository().Delete(collectorReportPaymentModel);

                if (rcdDetailsUpdateSuccess == false || isDeleteSuccess == false) return false;

                InsertPaymentsIntoReport();

                scope.Complete();
                return true;
            }
        }

        private void InsertPaymentsIntoReport()
        {
            foreach (DataGridViewRow item in uc.dgPayments.Rows)
            {
                var CollectorsReportId = GetCollectorsReportId();
                var PaymentCollectionsId = Convert.ToInt16(item.Cells["payment_collections_id"].Value.ToString());

                var collectorReportPaymentModel = new CollectorReportPaymentModel()
                {
                    CollectorsReportId = CollectorsReportId,
                    PaymentCollectionsId = PaymentCollectionsId
                };

                Factory.CollectorReportPaymentsRepository().Insert(collectorReportPaymentModel);
            }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            using (var scope = new TransactionScope())
            {

                var reportCollectorId = Convert.ToInt16(uc.cmbCollector.SelectedValue);
                var reportNo = uc.txtReport.Text.Trim();
                var reportDate = Convert.ToDateTime(uc.dtRCDDate.Value);
                var reportFund = uc.fundId;

                var collectorsReportModel = new CollectorReportModel()
                {
                    CollectorId = reportCollectorId,
                    ReportNo = reportNo,
                    Date = reportDate,
                    IsApproved = 0,
                    IsDisapproved = 0,
                    FundId = reportFund,
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
                    var PaymentCollectionsId = Convert.ToInt16(item.Cells["payment_collections_id"].Value.ToString());

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

                uc.reportId = (ushort)Convert.ToInt32(rcdData["id"]);
                uc.collectorId = (ushort)Convert.ToInt16(rcdData["collecting_officers_id"]);
                uc.fundId = (byte)Convert.ToInt32(rcdData["funds_id"]);
                uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == Convert.ToInt16(rcdData["funds_id"])) ? r.Checked = true : r.Checked = false);
                uc.cmbCollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtReport.Text = rcdData["report_no"];
                uc.dtRCDDate.Value = Convert.ToDateTime(rcdData["date"]);

                var collectionOfPaymentReportsRepo = Factory.CollectorReportPaymentsRepository();
                var collectionOfPaymentReportDt = collectionOfPaymentReportsRepo.GetRecordsByReportNo(reportNo);
                HelperLoadRecords.PaymentCollectionReportDatagrid(collectionOfPaymentReportDt, uc.dgPayments);

            }
            catch (Exception ex)
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        internal void CheckRCDStatus(string reportNo)
        {
            try
            {
                switch (Factory.CollectorReportRepository().GetRCDStatus(reportNo))
                {
                    case "pending":
                        //PENDING
                        lblReportStatus.Text = "PENDING";
                        lblReportStatus.ForeColor = Color.FromArgb(216, 146, 22);
                        lblShowMessage.Visible = false;
                        btnPrint.Enabled = false;
                        btnCancelPrint.Enabled = false;
                        btnApprove.Enabled = true;
                        btnDisapprove.Enabled = true;
                        btnDelete.Enabled = true;
                        uc.Enabled = true;
                        //btnSave.Enabled = true;
                        break;
                    case "approved":
                        //APPROVED
                        lblReportStatus.Text = "APPROVED";
                        lblReportStatus.ForeColor = Color.FromArgb(78, 159, 61);
                        lblShowMessage.Visible = false;
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnPrint.Enabled = true;
                        btnCancelPrint.Enabled = true;
                        btnSave.Enabled = true;
                        uc.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    case "disapproved":
                        //DISSAPROVED
                        lblReportStatus.Text = "DISAPPROVED";
                        lblReportStatus.ForeColor = Color.FromArgb(149, 1, 1);
                        lblShowMessage.Visible = true;
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnPrint.Enabled = false;
                        btnCancelPrint.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        uc.Enabled = false;
                        break;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        internal bool SetRCDStatus(byte status, string reportNo)
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
            string reportNumber = uc.txtReport.Text.Trim();
            _ = new PaymentCollection.frmCollectorsRCD(reportNumber).ShowDialog();
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            string reportNo = uc.txtReport.Text;
            if (String.IsNullOrEmpty(reportNo)) return;

            _ = new frmCollectorsRCDRemarks(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteReport())
            {
                Helper.MessageBoxSuccess("Report of Collection successfully deleted.");
                ResetLocalControls();
                uc.ResetForm();
            }
        }

        private bool DeleteReport()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete report of collection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ushort reportId = uc.reportId;
                    string reportNo = uc.txtReport.Text.Trim();

                    var collectorReportPaymentModel = new CollectorReportPaymentModel() {CollectorsReportId = reportId };
                    var collectorReportPaymentRepo = Factory.CollectorReportPaymentsRepository();
                    bool isDeleteSuccess =  collectorReportPaymentRepo.Delete(collectorReportPaymentModel);

                    if (isDeleteSuccess)
                    {
                        var collectorReportModel = new CollectorReportModel() { Id = reportId, ReportNo = reportNo };
                        var collectorReportRepo = Factory.CollectorReportRepository();
                        return collectorReportRepo.Delete(collectorReportModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void ResetLocalControls()
        {
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnApprove.Enabled = false;
            btnDisapprove.Enabled = false;
            btnPrint.Enabled = false;
            btnCancelPrint.Enabled = false;

            lblReportStatus.Text = "--";
            lblReportStatus.ForeColor = Color.Black;
        }

        private void btnSave_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                uc.ActionPerformIsSave(true);
            else
                uc.ActionPerformIsSave(false);
        }

        private void btnCancelPrint_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to cancel printing."))
            {
                ResetLocalControls();
                uc.ResetForm();
                uc.Enabled = true;
            }
        }

    }
}
