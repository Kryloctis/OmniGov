using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCDRemarks : Form
    {

        private readonly frmCollectorsRCD _frmCollectorsRCD;
        public frmCollectorsRCDRemarks(frmCollectorsRCD frmCollectorsRCD)
        {
            InitializeComponent();
            _frmCollectorsRCD = frmCollectorsRCD;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _frmCollectorsRCD.btnSave.Enabled = true;
            _frmCollectorsRCD.btnDelete.Enabled = true;
            _frmCollectorsRCD.btnSave.Text = "Update";

            _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Enabled = true;
            _frmCollectorsRCD.ucCollectorsRCD1.dgPayments.Enabled = true;
            _frmCollectorsRCD.ucCollectorsRCD1.dtRCDDate.Enabled = true;
            _frmCollectorsRCD.ucCollectorsRCD1.btnAdd.Enabled = true;

            _frmCollectorsRCD.ucCollectorsRCD1.Enabled = true;
            Close();
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to disapproved this Collector's Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;
                _frmCollectorsRCD.CheckRCDStatus(reportNo);

                if (_frmCollectorsRCD.SetRCDStatus(2, reportNo))
                {
                    Helper.MessageBoxSuccess("Collector's Report has been disapproved.");
                    SetRemarks();
                    _frmCollectorsRCD.CheckRCDStatus(reportNo);
                    this.Close();
                }
             
            }
           
        }

        private bool SetRemarks()
        {
            try
            {
                string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;
                string remark = txtRemarks.Text.Trim();

                if (String.IsNullOrEmpty(remark))
                    return false;

                var remarks = Factory.CollectorReportRepository().SetRemarks(reportNo, remark);

                return remarks;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmCollectorsRCDRemarks_Load(object sender, EventArgs e)
        {
            string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;

            txtRemarks.Text = Factory.CollectorReportRepository().GetRemarks(reportNo);
            txtRemarks.SelectionStart = 0;
        }

    }
}
