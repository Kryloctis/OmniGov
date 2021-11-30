using ACC.Domain.Models;
using AccountingSystem.Views.Reports.PaymentCollection;
using AccountingSystem.Views.Transactions.BankDeposits;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRCD : Form
    {

        internal ushort collectorId;
        internal int collectorsReportId;
        internal sbyte fundId;
        internal string reportNo;
        internal string rcdNo;
        internal string rcdId;


        internal DateTime date;


        private List<GeneralCollectionsModel> data;

        public frmRCD()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgpayments, true);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _ = new frmRCDAdd(this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmSearch(this).ShowDialog();
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {

        }


        internal void LoadSelectedRCD(string rcdNo)
        {
            try
            {

                var generalCollectionsPaymentRepo = Factory.GeneralCollectionsPaymentsRepository();
                var dtRCD = generalCollectionsPaymentRepo.GetRecordsByRCDNO(rcdNo);


                string reportId = String.Empty;
                string collectingOfficer = String.Empty;
                string reportNo = String.Empty;
                string reportNoChecker = String.Empty;
                string amount = String.Empty;


                foreach (DataRow row in dtRCD.Rows)
                {
                    reportId = row["collectors_report_id"].ToString();
                    collectingOfficer = row["collecting_officer"].ToString();
                    reportNo = row["report_no"].ToString();
                    amount = Convert.ToDecimal(row["amount"].ToString()).ToString("N2");


                    object[] reportRow = new object[]
                    {
                        reportId,
                        collectingOfficer,
                        reportNo,
                        amount
                    };

                    dgpayments.Rows.Add(reportRow);
                }



            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadSelectedReport(string reportNo)
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(reportNo);


                collectorId = (ushort)Convert.ToInt16(rcdData["collecting_officers_id"]);
                fundId = (sbyte)Convert.ToInt32(rcdData["funds_id"]);
                reportNo = rcdData["report_no"];
                date = Convert.ToDateTime(rcdData["date"]);

                

                var colectorRepository = Factory.CollectorReportRepository();
                var dtrcd = new DataTable();
                dtrcd = colectorRepository.FilterRecords(fundId, collectorId, reportNo);
                HelperLoadRecords.RCDDatagridView(dtrcd, dgpayments);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCD has been created.");
                ResetForm();
            }

        }

        private void ResetForm()
        {
            txtRCDNo.Text = string.Empty;
            dtpdate.Value = DateTime.Now;

            dgpayments.Rows.Clear();
            panelRCD.Enabled = true;
        }

        private bool SaveData()
        {

            using (var scope = new TransactionScope())
            {
                if (ValidateInputs())
                {
                    Helper.MessageBoxError("Please add collector's report and RCD number.");
                    return false;
                }

                var generalCollectionModel = new GeneralCollectionsModel()
                {
                    RcdNo = txtRCDNo.Text,
                    Rcddate = Convert.ToDateTime(dtpdate.Value),
                    Userid = Helper.UserId
                };

                bool rcdSaveSuccess = Factory.GeneralCollectionsRepository().Insert(generalCollectionModel);
                if (!rcdSaveSuccess) return false;

                var generalCollectionsId = GetGeneralCollectionsId();
                

                foreach (DataGridViewRow row in dgpayments.Rows)
                {
                    ushort collectionsReportId = (ushort)Convert.ToInt32(row.Cells["reportId"].Value);

                    var generalCollectionPaymentModel = new GeneralCollectionPaymentsModel()
                    {
                        CollectorsReportId = collectionsReportId,
                        GeneralCollectionsId = generalCollectionsId
                    };

                    Factory.GeneralCollectionsPaymentsRepository().Insert(generalCollectionPaymentModel);
                }
               
                scope.Complete();
                return true;
            }
        }

        private int GetGeneralCollectionsId()
        {
            var rcdNo = txtRCDNo.Text;
            int generalCollectionId = Factory.GeneralCollectionsRepository().GetGeneralCollectionId(rcdNo);
            return generalCollectionId;
        }
         
        private bool ValidateInputs()
        {
            bool hasError = String.IsNullOrEmpty(txtRCDNo.Text) || dgpayments.Rows.Count == 0;
            return hasError;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            _ = new frmBankDepositsAdd(new frmBankDeposits()).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _ = new frmCDReport(rcdId).ShowDialog();
        }

        private void dgpayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
