using ACC.Data;
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
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SetRemarks()
        {
            string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;
            string remark = txtRemarks.Text.Trim();

            if (String.IsNullOrEmpty(remark))
                return false;

            var remarks = AccFactory.CollectorReportRepository().SetRemarks(reportNo, remark);

            return remarks;
        }

        private void OnLoad()
        {
            string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;

            txtRemarks.Text = AccFactory.CollectorReportRepository().GetRemarks(reportNo);
            txtRemarks.SelectionStart = 0;
        }

        private void frmCollectorsRCDRemarks_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}