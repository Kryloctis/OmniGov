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
            //if (isDissaprove)
            //{
            //    if (MessageBox.Show("Are you sure you want to disapproved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {

            //        if (SetJEVToDisapproved() && SetRemarks())
            //        {
            //            Helper.MessageBoxSuccess("JEV has been disapproved.");
            //            _frmJEV.ucjev1.isDisapproved = 1;
            //            _frmJEV.CheckJevStatus(_frmJEV.ucjev1.jevId);
            //            _frmJEV._frmJEVList.LoadJEVList();
            //            _frmJEV._ucJEVDashboard.LoadJEVCounter();
            //            Close();
            //        }
            //    }
            //}
            //else
            //{
            //    _frmJEV.btnSave.Enabled = true;
            //    _frmJEV.btnSave.Text = "Update";
            //    _frmJEV.ucjev1.Enabled = true;
            //    Close();
            //}
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            if (SetRemarks())
            {
                Helper.MessageBoxSuccess("Dissaproval message has been saved.");
            }
        }

        private bool SetRemarks()
        {
            try
            {
                //if (!uc.FormValidations())
                //    return false;

                string reportNo = _frmCollectorsRCD.ucCollectorsRCD1.txtReport.Text;
                string remark = txtRemarks.Text.Trim();

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

            ///PermissionVerification();
        }
    }
}
