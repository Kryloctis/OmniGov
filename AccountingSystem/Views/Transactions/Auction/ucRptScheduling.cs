using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Auction
{
    public partial class ucRptScheduling : UserControl
    {
        internal bool isEdit;
        internal int? rptScheduleId;

        public ucRptScheduling()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(cmbxAuctionSchedule),
                errorProvider1.GetError(cmbxProperty),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? rptScheduleId)
        {
            this.isEdit = isEdit;
            this.rptScheduleId = rptScheduleId;

            LoadAuctionSchedule();
            LoadProperties();

            if (isEdit) LoadSelectedRecord(rptScheduleId.Value); else ResetForm();
            errorProvider1.Clear();

        }

        internal bool Save(ref bool isEdit)
        {
            isEdit = this.isEdit;

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            return isEdit ? AccFactory.RptAuctionRepository().Update(RptAuctionModel()) : AccFactory.RptAuctionRepository().Insert(RptAuctionModel());
        }

        private void LoadAuctionSchedule()
        {
            var dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        //private void LoadProperties()
        //{
        //    var dtRpt = AccFactory.RealPropertiesRepository().GetRecords();

        //    var datatable = new DataTable();
        //    datatable.Columns.Add("id", typeof(int));
        //    datatable.Columns.Add("complete_arp_no", typeof(string));

        //    foreach (DataRow row in dtRpt.Rows)
        //    {
        //        int taxPayersId = Convert.ToInt32(row["taxpayers_id"]);
        //        var dtRptDelinquent = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(taxPayersId);

        //        foreach (DataRow rowRptDelinqeunt in dtRptDelinquent.Rows)
        //        {
        //            DataRow dr = datatable.NewRow();
        //            int rptId = Convert.ToInt32(row["id"]);
        //            string completeArpNo = rowRptDelinqeunt["complete_arp_no"].ToString();
        //            datatable.Rows.Add(rptId, completeArpNo);
        //        }
        //    }

        //    cmbxProperty.DataSource = datatable;
        //    cmbxProperty.ValueMember = "id";
        //    cmbxProperty.DisplayMember = "complete_arp_no";
        //}

        private void LoadProperties()
        {
            var deliquentRpt = AccFactory.DelinquentNoticeRepository().GetViewRecords("3rd Notice");

            cmbxProperty.DataSource = deliquentRpt;
            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
        }

        private void LoadSelectedRecord(int rptScheduleId)
        {
            var dictRptSchedule = AccFactory.RptAuctionRepository().GetRecordByID(rptScheduleId);

            cmbxAuctionSchedule.SelectedValue = dictRptSchedule["auction_id"];
            cmbxProperty.SelectedValue = dictRptSchedule["real_properties_id"];
        }

        private void ResetForm()
        {

        }

        private RptAuctionModel RptAuctionModel()
        {
            var model = new RptAuctionModel()
            {
                RptPropertiesId = Convert.ToInt32(cmbxProperty.SelectedValue),
                AuctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue),
                CreatedBy = Helper.userId
            };

            if (isEdit) model.Id = rptScheduleId.Value;

            return model;
        }

        private void cmbxAuctionSchedule_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAuctionSchedule, "Auction Schedule.");
        }

        private void cmbxAuctionSchedule_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAuctionSchedule);
        }

        private void cmbxProperty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxProperty, "Real Property.");
        }

        private void cmbxProperty_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxProperty);
        }

        private void ucRptScheduling_Load(object sender, EventArgs e)
        {

        }
    }
}
