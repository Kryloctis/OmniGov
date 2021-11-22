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
                ReportNo = uc.txtreport.Text.Trim(),
                Date = Convert.ToDateTime(uc.dtdate.Value),
                IsApproved = 0,
                IsDisapproved = 0,
                FundId = uc.fundId,
                Remarks = String.Empty
            };

            return Factory.CollectorReportRepository().Insert(collectorsReportModel);

        }
    }
}
